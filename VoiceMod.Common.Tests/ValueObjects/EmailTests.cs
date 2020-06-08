using System;
using System.Collections.Generic;
using System.Text;
using VoiceMod.Common.ValueObjects;
using Xunit;

namespace VoiceMod.Common.Tests.ValueObjects
{
    public class EmailTests
    {
        [Fact]
        public void EmptyEmailThrowsException()
        {
            Action email = () => Email.FromString(string.Empty);

            Assert.Throws<ArgumentException>(email);
        }

        [Fact]
        public void EmailWithInvalidFormatThrowsException()
        {
            Action email = () => Email.FromString("manuel.berenguer");

            Assert.Throws<FormatException>(email);
        }

        [Fact]
        public void ValidEmailIsCreatedSuccessfully()
        {
            var email = Email.FromString("manuel.berenguer.valero@gmail.com");

            Assert.Equal("manuel.berenguer.valero@gmail.com", email.Value());
        }
    }
}
