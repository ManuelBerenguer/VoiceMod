using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Common.Handlers;
using VoiceMod.Common.ValueObjects;
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
    public sealed class UpdateUserHandler : ICommandHandler<UpdateUser, UserDto>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly CheckEmailAvailability _checkEmailAvailability;

        public UpdateUserHandler(IUsersRepository usersRepository, CheckEmailAvailability checkEmailAvailability)
        {
            _usersRepository = usersRepository;
            _checkEmailAvailability = checkEmailAvailability;
        }

        public async Task<UserDto> HandleAsync(UpdateUser command)
        {
            var user = await _usersRepository.GetById(command.Id);

            if (user == null)
                throw new UserNotFoundException($"The user with id: '{command.Id}' was not found.");

            if ((command.Email != user.Email.Value()) && !(await _checkEmailAvailability.IsAvailable(command.Email)))
                throw new EmailAlreadyInUseException($"The email '{command.Email}' is already in use.");
                        
            user.SetName(command.Name);
            user.SetSurname(command.Surname);
            user.SetEmail(Email.FromString(command.Email));
            if (user.Password.VerifyPassword(command.Password))
                user.SetPassword(Password.FromString(command.NewPassword));
            else
                throw new WrongPasswordException("The password provided is wrong.");
            user.SetCountry(command.Country);
            user.SetPhone(Phone.FromString(command.Phone));
            user.SetPostalCode(PostalCode.FromString(command.PostalCode));

            await _usersRepository.UpdateAsync(user);

            return UserMapper.From(user);
        }
    }
}
