using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using VoiceMod.Common.ValueObjects.Base;

namespace VoiceMod.Common.ValueObjects
{
    public class Phone : ValueObject
    {
        private readonly string _value;

        private Phone(string phoneNumber)
        {
            _value = phoneNumber;
        }

        // Factory method
        public static Phone FromString(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                throw new ArgumentException("The phone number cannot be null or empty", nameof(phoneNumber));

            if (Regex.Match(phoneNumber, @"^([0-9]{9})$").Success)
                return new Phone(phoneNumber);
            else
                throw new FormatException("The phone number is not valid");
        }

        public string Value() => _value;
    }
}
