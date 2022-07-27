using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PersonalCompany.PersonalProduct.Utility.Common
{
    public enum HashType : short
    {
        [Description("SHA1CryptoServiceProvider")]
        SHA1 = 0,
        [Description("SHA256Managed")]
        SHA256 = 1,
        [Description("SHA384Managed")]
        SHA384 = 2,
        [Description("SHA512Managed")]
        SHA512 = 3,
        [Description("MD5CryptoServiceProvider")]
        MD5 = 4
    }
  

    public enum TimePeriodName : short
    {
        TODAY = 0,
        YESTERDAY = 1,
        THISWEEK = 2,
        LASTWEEK = 3,
        THISMONTH = 4,
        LASTMONTH = 5,
        THISYEAR = 6,
        LASTYEAR = 7,
        DAYS90 = 8
    }

    public enum UserTypes : short
    {
        SystemAdmin = 1,
        Client = 2,
        API = 3
    }

    public enum Package : short
    {
        Starter=5,
        Plan1 = 6,
        Growth = 7,
        Premium = 8
    }

    public enum ContactsAllowance : long
    {
        Starter = 500,
        Plan1 = 10000,
        Growth = 20000,
        Premium = 50000
    }

    public enum BookingsAllowance : long
    {
        Starter = 10,
        Plan1 = 50,
        Growth = 100,
        Premium = 100000
    }

    public enum UsersAllowance : short
    {
        Starter = 1,
        Plan1 = 3,
        Growth = 5,
        Premium = 10
    }

    public enum ServicesAllowance : short
    {
        Starter = 5,
        Plan1 = 5,
        Growth = 10,
        Premium = 20
    }


    public enum EmailsAllowance : short
    {
        Starter = 500,
        Plan1 = 500,
        Growth = 5000,
        Premium = 10000
    }

    public enum SMSAllowance : short
    {
        Starter = 0,
        Plan1 = 30,
        Growth = 500,
        Premium = 1000
    }

    public enum PaymentsAllowance : long
    {
        Starter = 3,
        Plan1 = 5,
        Growth = 100,
        Premium = 100000
    }



    public enum MailchimpEmailTypes : short
    {
        Transactional = 1,
        Marketing = 2,
    }

    public enum UserRoles : short
    {
        Admin = 1,
        Staff = 2
    }

    public enum ProfileStatuses : short
    {
        Active = 1,
        InActive = 2,
        Pending = 3,
    }
   
    public enum DeliveryTypes : short
    {
        FTP = 1,
        SFTP = 2,
        API = 3,
    }


    public enum UIGridAggregationTypes
    {
        [Description("sum")]
        sum = 2,
        [Description("count")]
        count = 4,
        [Description("avg")]
        avg = 8,
        [Description("min")]
        min = 16,
        [Description("max")]
        max = 32
    }

    public enum UIGridTreeAggregationType
    {
        [Description("sum")]
        sum = 1,

        [Description("count")]
        count = 2,

        [Description("avg")]
        avg = 3,

        [Description("min")]
        min = 4,

        [Description("max")]
        max = 5

    }

    public enum PaymentMethodType
    {
        [Description("CreditCard")]
        CreditCard = 1,
        [Description("PaymentLink")]
        PaymentLink = 2,
        [Description("Invoice")]
        Invoice = 3,
    }

    public enum ContactSources { 
    
        Imported_Contact = 0,
        All_Sources = 1,
        Booking = 2,
        Engagement = 3,
        Messenger = 4,
        Website_Contact = 5,
        Direct = 6,
        Google = 7,
        Outlook = 8,
        Quickbooks = 9,
        Reviews = 10,
        Subscriber = 11,
        Thumbtack = 12,
        Payments = 13
    
    }

    public enum ActivityTypes
    {
        Accounts = 1,
        Business_Management = 2,
        Google = 3,
        Contacts = 4,
        SMS = 5,
        Email = 6,
        Booking = 7,
        Payment = 8,
        Invoice = 9
    }

    public enum PaymentService { 
    
        Authorized_NET = 1,
        Stripe = 2
    
    }

    public enum Module
    {
        [Description("businessDetails")]
        Business_Details = 1,
        [Description("businessAddress")]
        Business_Address = 2,
        [Description("businessServices")]
        Business_Services = 3,
        [Description("businessHours")]
        Business_Hours = 4,
        [Description("businessUsers")]
        Business_Users = 5,
        [Description("businessGroups")]
        Business_Groups = 6,
        [Description("gmb")]
        Business_GMB = 7,
        [Description("interactionsOpen")]
        Interaction_Open = 8,
        [Description("interactionsClosed")]
        Interaction_Closed = 9,
        [Description("bookings")]
        Bookings = 10,
        [Description("bookingCalendar")]
        Booking_Calendar = 11,
        [Description("bookingArchive")]
        Bookings_Archive = 12,
        [Description("viewInvoice")]
        View_Invoice = 13,
        [Description("emailCampaign")]
        Email_Campaign = 14,
        [Description("smsCampaign")]
        SMS_Campaign = 15
    }

    public static class EnumHelper
    {
        public static string GetDescription<T>(this T enumValue)
        where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return null;



            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());



            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }



            return description;
        }
    }
}

