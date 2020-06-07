using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using VoiceMod.Common.ValueObjects.Base;

namespace VoiceMod.Common.ValueObjects
{
    public class Email : ValueObject
    {
        private readonly string _value;

        private Email(string emailAddress) 
        {
            _value = emailAddress;
        }
        
        // Factory method
        public static Email FromString(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
                throw new ArgumentException("The email address cannot be null or empty", nameof(emailAddress));

            try
            {
                // We use system library to validate email
                MailAddress mailAdress = new MailAddress(emailAddress);

                return new Email(emailAddress);
            }
            catch (Exception)
            {
                throw new FormatException("The email provided is not valid.");
            }
        }

        public string Value() => _value;
    }
}
