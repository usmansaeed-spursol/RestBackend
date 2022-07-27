using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using PersonalCompany.PersonalProduct.Utility.Exceptions;
using PersonalCompany.PersonalProduct.Utility.Security;
using System;


namespace PersonalCompany.PersonalProduct.Utility.Configuration
{
    public class AppSettings
    {
        private static IConfiguration Configuration;
        //private static IWebHostEnvironment env;
        public static void IntializeConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public static void Enviornment(IWebHostEnvironment environment)
        //{
        //    env = environment;
        //}
        public static string ConnectionString
        {
            get
            {
                if (Configuration["ConnectionStrings:SQLConnection"] == null || string.IsNullOrWhiteSpace(Configuration["ConnectionStrings:SQLConnection"]))
                    throw new AppException("SQL Connectionstring is not valid in AppSettings file");

                return EncryptorDecryptorEngine.DecryptString(Configuration["ConnectionStrings:SQLConnection"]);
            }
        }


        public static string PostGresConnectionString
        {
            get
            {
                if (Configuration["ConnectionStrings:PostGresSQLConnection"] == null || string.IsNullOrWhiteSpace(Configuration["ConnectionStrings:PostGresSQLConnection"]))
                    throw new AppException("PostGresSQL Connectionstring is not valid in AppSettings file");



                return Configuration["ConnectionStrings:PostGresSQLConnection"];
            }
        }


        public static bool IsSQLConnection
        {
            get
            {
                if (Configuration["ConnectionStrings:IsSQLConnection"] == null || string.IsNullOrWhiteSpace(Configuration["ConnectionStrings:IsSQLConnection"]))
                    throw new AppException("IsSQLConnection is not valid in AppSettings file");
                return Convert.ToBoolean(Configuration["ConnectionStrings:IsSQLConnection"].ToString().ToLower());
            }
        }

        public static string DriftAppName
        {
            get {

                if (Configuration["DriftAPI:AppName"] == null || string.IsNullOrWhiteSpace(Configuration["DriftAPI:AppName"]))
                    throw new AppException("Invalid Drift App Name configured");

                return Configuration["DriftAPI:AppName"];

            }
        
        }

        public static string DriftClientId
        {
            get
            {

                if (Configuration["DriftAPI:ClientId"] == null || string.IsNullOrWhiteSpace(Configuration["DriftAPI:ClientId"]))
                    throw new AppException("Invalid Drift Client Id configured");

                return Configuration["DriftAPI:ClientId"];

            }

        }

        public static string DriftSecretId
        {
            get
            {

                if (Configuration["DriftAPI:SecretId"] == null || string.IsNullOrWhiteSpace(Configuration["DriftAPI:SecretId"]))
                    throw new AppException("Invalid Drift Secret Id configured");

                return Configuration["DriftAPI:SecretId"];

            }

        }

        public static string SentryKey
        {
            get
            {
                if (Configuration["SentryConfig:Key"] == null || string.IsNullOrWhiteSpace(Configuration["SentryConfig:Key"]))
                    throw new AppException("Sentry Config Key is not valid in AppSettings file");

                return Configuration["SentryConfig:Key"];
            }
        }

        public static string SerilogSeqURL
        {
            get
            {
                if (Configuration["Serilog:SeqServerUrl"] == null || string.IsNullOrWhiteSpace(Configuration["Serilog:SeqServerUrl"]))
                    throw new AppException("Serilog Seq Server URL is not valid in AppSettings file");

                return Configuration["Serilog:SeqServerUrl"];
            }
        }

        public static String GoogleClientId
        {
            get
            {
                if (Configuration["GoogleAPI:ClientId"] == null || string.IsNullOrWhiteSpace(Configuration["GoogleAPI:ClientId"]))
                    throw new AppException("Google Client Id is not valid in AppSettings file");

                return Configuration["GoogleAPI:ClientId"];
            }
        }

        public static String GoogleAppName
        {
            get
            {
                if (Configuration["GoogleAPI: AppName"] == null || string.IsNullOrWhiteSpace(Configuration["GoogleAPI: AppName"]))
                    throw new AppException("Google App Name is not valid in AppSettings file");

                return Configuration["GoogleAPI: AppName"];
            }

        }

        public static string GoogleApiKey
        {
            get
            {
                if (Configuration["GoogleAPI:ApiKey"] == null || string.IsNullOrWhiteSpace(Configuration["GoogleAPI:ApiKey"]))
                    throw new AppException("Google Api Key is not valid in AppSettings file");
                return Configuration["GoogleAPI:ApiKey"];
            }
        }

        public static String TwilioAccountId
        {
            get {

                return Configuration["Twilio:AccountSid"];
            
            }
        
        }

        public static String TwilioAuthToken
        {

            get {

                return Configuration["Twilio:authToken"];
            
            }
        
        }

        public static String GoogleClientSecret
        {

            get
            {
                if (Configuration["GoogleAPI:ClientSecret"] == null || string.IsNullOrWhiteSpace(Configuration["GoogleAPI:ClientSecret"]))
                    throw new AppException("Google API Client Secret is not valid in AppSettings file");

                return Configuration["GoogleAPI:ClientSecret"];
            }

        }

        public static string[] GoogleScopes
        {
            get
            {

                if (Configuration["GoogleAPI:Scopes"] == null)
                    throw new Exception("Google Scopes are not present in configurtaion");

                String[] values = Configuration["GoogleAPI:Scopes"].Split(',');
                for (int i = 0; i < values.Length; i++)
                {

                    values[i] = values[i].Trim(new char[] { '[', ']' });

                }

                return values;

            }


        }
        public static string LoggingFilePath
        {
            get
            {
                if (Configuration["Serilog:FilePath"] == null || string.IsNullOrWhiteSpace(Configuration["Serilog:FilePath"]))
                    throw new AppException("Serilog Logging File Path is not valid in AppSettings file");

                return Configuration["Serilog:FilePath"];
            }
        }

        public static DateTime TokenExpirationInSeconds
        {
            get
            {
                double tokenExpiryInSeconds = 0;
                if (Configuration["ApplicationSettings:TokenExpiry"] == null || !double.TryParse(Configuration["ApplicationSettings:TokenExpiry"], out tokenExpiryInSeconds))
                    throw new AppException("Token Expiry is not valid in AppSettings file");

                return DateTime.UtcNow.AddMinutes(tokenExpiryInSeconds);
            }
        }

        public static string MailchimpMarketingApiKey
        {
            get
            {
                if (Configuration["MailchimpSettings:MarketingApiKey"] == null || string.IsNullOrWhiteSpace(Configuration["MailchimpSettings:MarketingApiKey"]))
                    throw new AppException("Mailchimp Marketing API Key is not valid in AppSettings file");

                return Configuration["MailchimpSettings:MarketingApiKey"];
            }
        }

        public static string MailchimpTransactionalApiKey
        {
            get
            {
                if (Configuration["MailchimpSettings:TransactionalApiKey"] == null || string.IsNullOrWhiteSpace(Configuration["MailchimpSettings:TransactionalApiKey"]))
                    throw new AppException("Mailchimp Transactional API Key is not valid in AppSettings file");

                return Configuration["MailchimpSettings:TransactionalApiKey"];
            }
        }

        public static string MailchimpDefaultEmail
        {
            get
            {
                if (Configuration["MailchimpSettings:DefaultEmail"] == null || string.IsNullOrWhiteSpace(Configuration["MailchimpSettings:DefaultEmail"]))
                    throw new AppException("Mailchimp Default Email is not valid in AppSettings file");

                return Configuration["MailchimpSettings:DefaultEmail"];
            }
        }

        public static string MailchimpSenderDisplayName
        {
            get
            {
                if (Configuration["MailchimpSettings:SenderDisplayName"] == null || string.IsNullOrWhiteSpace(Configuration["MailchimpSettings:SenderDisplayName"]))
                    throw new AppException("Mailchimp Sender's Display Name is not valid in AppSettings file");

                return Configuration["MailchimpSettings:SenderDisplayName"];
            }
        }

        public static string TransactionalApiBaseUrl
        {
            get
            {
                if (Configuration["MailchimpSettings:TransactionalApiBaseUrl"] == null || string.IsNullOrWhiteSpace(Configuration["MailchimpSettings:TransactionalApiBaseUrl"]))
                    throw new AppException("Transactional API BaseUrl is not valid in AppSettings file");

                return Configuration["MailchimpSettings:TransactionalApiBaseUrl"];
            }
        }

        public static string ADotNetApiLoginID
        {
            get
            {
                if (Configuration["ADotNetSettings:ApiLoginID"] == null || string.IsNullOrWhiteSpace(Configuration["ADotNetSettings:ApiLoginID"]))
                    throw new AppException("Authorize.NET API Login ID is not valid in AppSettings file");

                return Configuration["ADotNetSettings:ApiLoginID"];
            }
        }

        public static string ADotNetTransactionKey
        {
            get
            {
                if (Configuration["ADotNetSettings:TransactionKey"] == null || string.IsNullOrWhiteSpace(Configuration["ADotNetSettings:TransactionKey"]))
                    throw new AppException("Authorize.NET API Transaction Key is not valid in AppSettings file");

                return Configuration["ADotNetSettings:TransactionKey"];
            }
        }

        public static string SMTPServer
        {
            get
            {
                if (Configuration["SMTPConfiguration:SMTPServer"] == null || string.IsNullOrWhiteSpace(Configuration["SMTPConfiguration:SMTPServer"]))
                    throw new AppException("SMPT Server is not valid in AppSettings file");

                return Configuration["SMTPConfiguration:SMTPServer"];
            }
        }

        public static string SMTPUser
        {
            get
            {
                if (Configuration["SMTPConfiguration:SMTPUser"] == null || string.IsNullOrWhiteSpace(Configuration["SMTPConfiguration:SMTPUser"]))
                    throw new AppException("SMPT User is not valid in AppSettings file");

                return Configuration["SMTPConfiguration:SMTPUser"];
            }
        }

        public static string SMTPPassword
        {
            get
            {
                if (Configuration["SMTPConfiguration:SMTPPassword"] == null || string.IsNullOrWhiteSpace(Configuration["SMTPConfiguration:SMTPPassword"]))
                    throw new AppException("SMPT Password is not valid in AppSettings file");

                return Configuration["SMTPConfiguration:SMTPPassword"];
            }
        }


        public static string SMTPUseSSL
        {
            get
            {
                if (Configuration["SMTPConfiguration:SMTPSSL"] == null || string.IsNullOrWhiteSpace(Configuration["SMTPConfiguration:SMTPSSL"]))
                    throw new AppException("SMPT SSL Use is not valid in AppSettings file");

                return Configuration["SMTPConfiguration:SMTPSSL"];
            }
        }

        public static string SMTPPort
        {
            get
            {
                if (Configuration["SMTPConfiguration:SMTPPort"] == null || string.IsNullOrWhiteSpace(Configuration["SMTPConfiguration:SMTPPort"]))
                    throw new AppException("SMPT Port is not valid in AppSettings file");

                return Configuration["SMTPConfiguration:SMTPPort"];
            }
        }

       
        public static string CrispBaseUrl
        {
            get
            {
                if (Configuration["CrispChatConfiguration:BaseUrl"] == null || string.IsNullOrWhiteSpace(Configuration["CrispChatConfiguration:BaseUrl"]))
                    throw new AppException("Crisp base url key is not valid in AppSettings file");

                return Configuration["CrispChatConfiguration:BaseUrl"];
            }

        }
               
        
        public static string GetCrispReceiveMessage
        {
            get
            {
                if (Configuration["CrispChatConfiguration:ReceiveMessage"] == null || string.IsNullOrWhiteSpace(Configuration["CrispChatConfiguration:ReceiveMessage"]))
                    throw new AppException("Crisp receive message key is not valid in AppSettings file");

                return Configuration["CrispChatConfiguration:ReceiveMessage"];
            }

        }
        
        public static string GetCrispSetEmail
        {
            get
            {
                if (Configuration["CrispChatConfiguration:SetEmail"] == null || string.IsNullOrWhiteSpace(Configuration["CrispChatConfiguration:SetEmail"]))
                    throw new AppException("Crisp set email key is not valid in AppSettings file");

                return Configuration["CrispChatConfiguration:SetEmail"];
            }

        }

        //public static string GetAppBaseUrl()
        //{
        //    if (env.IsDevelopment())
        //    {
        //        if (Configuration["ApplicationSettings:AppDevBaseUrl"] == null || string.IsNullOrWhiteSpace(Configuration["ApplicationSettings:AppDevBaseUrl"]))                
        //            throw new AppException("Development base url is not valid in AppSettings file");
        //        return Configuration["ApplicationSettings:AppDevBaseUrl"];
        //    }
        //    else
        //    {
        //        if (Configuration["ApplicationSettings:AppBaseUrl"] == null || string.IsNullOrWhiteSpace(Configuration["ApplicationSettings:AppBaseUrl"]))
        //            throw new AppException("Production base url is not valid in AppSettings file");
             
        //        return Configuration["ApplicationSettings:AppBaseUrl"];
        //    }
        //}

    }

}
