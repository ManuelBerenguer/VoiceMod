using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Common.Exceptions;
using VoiceMod.Common.Handlers;
using VoiceMod.Users.Core.Exceptions;
using VoiceMod.Users.Core.Messages.Commands;
using VoiceMod.Users.Core.Repositories;

namespace VoiceMod.Users.Core.Handlers
{
    public class DeleteUserHandler : ICommandHandler<DeleteUser>
    {
        private readonly IUsersRepository _usersRepository;

        public DeleteUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task HandleAsync(DeleteUser command)
        {
            var user = await _usersRepository.GetById(command.Id);

            if(user == null)
                throw new UserNotFoundException($"The user with id: '{command.Id}' was not found.");

            await _usersRepository.DeleteAsync(user);
        }
    }
}
