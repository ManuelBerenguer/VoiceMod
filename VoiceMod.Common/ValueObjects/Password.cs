using CryptoHelper;
using System;
using System.Collections.Generic;
using System.Text;
using VoiceMod.Common.ValueObjects.Base;

namespace VoiceMod.Common.ValueObjects
{
    public class Password : ValueObject
    {
        private readonly string _value;

        /// <summary>
        /// private constructor. Use the factory methods instead.
        /// </summary>
        /// <param name="password"></param>
        private Password(string password)
        {
            _value = password;
        }

        // Factory method
        public static Password FromString(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("The password cannot be null or empty", nameof(password));

            return new Password(Crypto.HashPassword(password));
        }

        // Factory method
        public static Password FromHash(string hash)
        {
            if (string.IsNullOrEmpty(hash))
                throw new ArgumentException("The hash cannot be null or empty", nameof(hash));

            return new Password(hash);
        }

        public bool VerifyPassword(string password)
            => Crypto.VerifyHashedPassword(_value, password);

        public string Value() => _value;
    }
}
