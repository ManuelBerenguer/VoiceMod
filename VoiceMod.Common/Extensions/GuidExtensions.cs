using System;
using System.Collections.Generic;
using System.Text;

namespace VoiceMod.Common.Extensions
{
    public static class GuidExtensions
    {
        public static bool isValidForEntity(this Guid id)
        {
            if (id == null || id == Guid.Empty)
                return false;

            return true;
        }
    }
}
