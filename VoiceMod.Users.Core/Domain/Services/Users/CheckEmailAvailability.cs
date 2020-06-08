using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Users.Core.Repositories;

namespace VoiceMod.Users.Core.Domain.Services.Users
{
    public class CheckEmailAvailability : ICheckEmailAvailability
    {
        private readonly IUsersRepository _usersRepository;

        public CheckEmailAvailability(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<bool> IsAvailable(string email)
        {
            var user = await _usersRepository.GetByEmail(email);

            return user == null ? true : false;
        }
    }
}
