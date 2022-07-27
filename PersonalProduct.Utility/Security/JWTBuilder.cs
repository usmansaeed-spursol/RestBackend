using System;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using PersonalCompany.PersonalProduct.Utility.Configuration;
using System.Linq;

namespace PersonalCompany.PersonalProduct.Utility.Security
{
    public class JWTBuilder
    {
        #region JWT Token Genration
        public static Tuple<string, DateTime?> Generation(int userId, string email, string name, int userTypeId, int businessId, int businessUserId, string password, int? duration = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(EncryptorDecryptorEngine.password);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("USERID", userId.ToString()),
                    new Claim("USEREMAIL", email),
                    new Claim("NAME", name),
                    new Claim("USERTYPEID", userTypeId.ToString()),
                     new Claim("BUSINESSID", businessId.ToString()),
                     new Claim("BUSINESSUSERID", businessUserId.ToString()),
                    new Claim("USERPASSWORD", password),
                }),
                Expires = AppSettings.TokenExpirationInSeconds,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return new Tuple<string, DateTime?>(tokenString, tokenDescriptor.Expires);

        }

        public static Tuple<string, DateTime?> TokenGenerationForPayment(int businessId, int contactId, string[] serviceNames, string[] ServiceAmout, string paymentServiceType, string[] ServiceDate, int invoiceNumber, int bookingId, int[] quantity, int? duration = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(EncryptorDecryptorEngine.password);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {

                    new Claim("BUSINESSID", businessId.ToString()),
                    new Claim("CONTACTID", contactId.ToString()),
                    new Claim("SERVICENAME", String.Join(",", serviceNames).Trim()),
                    new Claim("SERVICEAMOUNT", String.Join(",", ServiceAmout).Trim()),
                    new Claim("PAYMENTSERVICE", paymentServiceType),
                    new Claim("SERVICEDATE", String.Join(",", ServiceDate).Trim()),
                    
                    new Claim("INVOICENUMBER", invoiceNumber.ToString().Trim()),
                    new Claim("BOOKINGID", bookingId.ToString()),
                    new Claim("QUANTITY", String.Join(",", quantity).Trim() )
                }),
                Expires = AppSettings.TokenExpirationInSeconds,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return new Tuple<string, DateTime?>(tokenString, tokenDescriptor.Expires);
        }
        #endregion


        public static List<Claim> IsTokenValid(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();
            SecurityToken validatedToken;
            try
            {
                
                ClaimsPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
                return principal.Claims.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //Sentry.SentrySdk.CaptureException(ex);
                return null;
            }
        }

        public static bool IsTokenExpired(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();
            SecurityToken validatedToken;
            try
            {
                ClaimsPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
                var expire = Convert.ToInt32(principal.Claims.ToList().FirstOrDefault(x => x.Type == "exp").Value);
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(expire);
                if (dateTimeOffset.LocalDateTime < DateTime.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //Sentry.SentrySdk.CaptureException(ex);
                Console.WriteLine(ex);
                return false;
            }
        }

        public static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true, // validate expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(EncryptorDecryptorEngine.password)) // The same key as the one that generate the token
            };
        }
    }
}
