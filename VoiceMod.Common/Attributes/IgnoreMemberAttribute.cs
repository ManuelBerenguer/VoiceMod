using System;
using System.Collections.Generic;
using System.Text;

namespace VoiceMod.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemberAttribute : Attribute
    {
    }
}
