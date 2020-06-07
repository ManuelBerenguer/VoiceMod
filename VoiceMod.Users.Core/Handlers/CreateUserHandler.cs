using CryptoHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Common.Handlers;
using VoiceMod.Common.ValueObjects;
using VoiceMod.Users.Core.Domain.Entities;
using VoiceMod.Users.Core.Domain.Services.Users;
using VoiceMod.Users.Core.Dtos;
using VoiceMod.Users.Core.Exceptions;
using VoiceMod.Users.Core.Mappers;
using VoiceMod.Users.Core.Messages.Commands;
using VoiceMod.Users.Core.Repositories;

namespace VoiceMod.Users.Core.Handlers
{
    /// <summary>
    /// Class with the responsability to handle create user commands. Not inheritable.
    /// </summary>
    public sealed class CreateUserHandler : ICommandHandler<CreateUser, UserDto>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly CheckEmailAvailability _checkEmailAvailability;

        public CreateUserHandler(IUsersRepository usersRepository, CheckEmailAvailability checkEmailAvailability)
        {
            _usersRepository = usersRepository;
            _checkEmailAvailability = checkEmailAvailability;
        }

        public async Task<UserDto> HandleAsync(CreateUser command)
        {
            if (!(await _checkEmailAvailability.IsAvailable(command.Email)))
                throw new EmailAlreadyInUseException($"The email '{command.Email}' is already in use.");

            User user = new User(new EntityId(command.Id), command.Name, command.Surname, Email.FromString(command.Email),
                Password.FromString(command.Password), command.Country, string.IsNullOrEmpty(command.Phone) ? null : Phone.FromString(command.Phone), 
                string.IsNullOrEmpty(command.PostalCode) ? null : PostalCode.FromString(command.PostalCode));

            await _usersRepository.AddAsync(user);

            return UserMapper.From(user);
        }
    }
}
