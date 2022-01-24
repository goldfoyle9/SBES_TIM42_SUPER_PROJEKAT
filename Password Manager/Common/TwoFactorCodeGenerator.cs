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
        private static Totp totp{ get;  set; }
        private static string GenerateCode() 
        {
            string key = Authenticator.GenerateSalt(16);
            totp = new Totp(Convert.FromBase64String(key), mode: OtpHashMode.Sha512, step: 60, totpSize: 6);
            var TotpCode = totp.ComputeTotp(DateTime.UtcNow);
            return TotpCode;
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

        public static bool VerifyTotpCode(string totpString)
        {
            long timeWindowUsed;
            return totp.VerifyTotp(totpString, out timeWindowUsed);
        }
           

        public static void SendTotpCode(string phoneNumber)
        {
            string accountSid = "AC27454ff55aaa94b60de233df7c1b6d50";
            string authToken = "f9a5cc14110d6a6450ae590e618da5f1";
            TwilioClient.Init(accountSid, authToken);
            var totp = GenerateCode();

            var message = MessageResource.Create(
                body: $"Your MySBES authentication code is: {totp}",
                from: new Twilio.Types.PhoneNumber("+16076008655"),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );
            
        }

    }
}
