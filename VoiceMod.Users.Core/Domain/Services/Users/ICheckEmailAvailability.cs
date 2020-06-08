using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VoiceMod.Users.Core.Domain.Services.Users
{
    public interface ICheckEmailAvailability
    {
        Task<bool> IsAvailable(string email);
    }
}
