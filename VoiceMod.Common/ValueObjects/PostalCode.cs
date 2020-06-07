using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using VoiceMod.Common.ValueObjects.Base;

namespace VoiceMod.Common.ValueObjects
{
    public class PostalCode : ValueObject
    {
        private readonly string _value;

        private PostalCode(string postalCode)
        {
            _value = postalCode;
        }

        // Factory method
        public static PostalCode FromString(string postalCode)
        {
            if (string.IsNullOrEmpty(postalCode))
                throw new ArgumentException("The postal code cannot be null or empty", nameof(postalCode));

            if (Regex.Match(postalCode, @"^([0-9]{5})$").Success)
                return new PostalCode(postalCode);
            else
                throw new FormatException("The postal code is not valid");
        }

        public string Value() => _value;
    }
}
