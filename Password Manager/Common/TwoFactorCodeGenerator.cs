using MimeKit;
using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using MailKit.Security;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Common
{
    public static class TwoFactorCodeGenerator
    {
        public static string phoneNumber { get; private set; }
        private static Totp totp{ get;  set; }
        private static string GenerateCode() 
        {
            string key = Authenticator.GenerateSalt(16);
            totp = new Totp(Convert.FromBase64String(key), mode: OtpHashMode.Sha512, step: 60, totpSize: 6);
            var TotpCode = totp.ComputeTotp(DateTime.UtcNow);
            return TotpCode;
        }

        public static bool VerifyTotpCode(string totpString)
        {
            long timeWindowUsed;
            return totp.VerifyTotp(totpString, out timeWindowUsed);
        }
           

        public static void SendTotpCode(string phoneNumber)
        {
            string accountSid = Environment.GetEnvironmentVariable("twilioAccountSid", EnvironmentVariableTarget.User);
            string authToken = Environment.GetEnvironmentVariable("twilioAuthToken", EnvironmentVariableTarget.User);
            TwilioClient.Init(accountSid, authToken);
            var totp = GenerateCode();

            var message = MessageResource.Create(
                body: $"Your MySBES authentication code is: {totp}",
                from: new Twilio.Types.PhoneNumber("+16076008655"),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );
            TwoFactorCodeGenerator.phoneNumber = phoneNumber.Trim();
            while(TwoFactorCodeGenerator.phoneNumber.Length < 16)
            {
                TwoFactorCodeGenerator.phoneNumber = TwoFactorCodeGenerator.phoneNumber + "9";
            }
            
        }
        public static string GenerateCode(string thing)
        {
            try
            {
                totp = new Totp(Base32Encoding.ToBytes(thing));
                var TotpCode = totp.ComputeTotp(DateTime.UtcNow);
                return TotpCode;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }
}
