using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Common.Handlers;
using VoiceMod.Users.Core.Dtos;
using VoiceMod.Users.Core.Mappers;
using VoiceMod.Users.Core.Messages.Commands;
using VoiceMod.Users.Core.Repositories;

namespace VoiceMod.Users.Core.Handlers
{
    public class AuthenticateUserHandler : ICommandHandler<AuthenticateUser, UserDto>
    {
        private readonly IUsersRepository _usersRepository;

        public AuthenticateUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<UserDto> HandleAsync(AuthenticateUser command)
        {
            var user = await _usersRepository.GetByEmail(command.Email);

            return (user != null && user.Password.VerifyPassword(command.Password)) ? UserMapper.From(user) : null;            
        }
    }
}
