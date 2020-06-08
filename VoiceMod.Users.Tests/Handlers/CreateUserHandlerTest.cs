using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Users.Core.Domain.Services.Users;
using VoiceMod.Users.Core.Exceptions;
using VoiceMod.Users.Core.Handlers;
using VoiceMod.Users.Core.Messages.Commands;
using VoiceMod.Users.Core.Repositories;
using Xunit;

namespace VoiceMod.Users.Tests.Handlers
{
    public class CreateUserHandlerTest
    {
        private readonly Mock<IUsersRepository> _usersRepository = new Mock<IUsersRepository>();
        private readonly Mock<ICheckEmailAvailability> _checkEmailAvailability = new Mock<ICheckEmailAvailability>();
        private readonly CreateUserHandler _createUserHandler;

        public CreateUserHandlerTest()
        {
            _createUserHandler = new CreateUserHandler(_usersRepository.Object, _checkEmailAvailability.Object);
        }

        [Fact]
        public async Task CreatingUserWithDuplicatedEmailThrowsException()
        {
            CreateUser createUserCommand = new CreateUser(Guid.NewGuid(), "Manuel", "Berenguer Valero", "manuel.berenguer.valero@gmail.com", "loquesea", "España", "639903816", "03160");

            // We mock to consider the email as duplicated
            _checkEmailAvailability.Setup(x => x.IsAvailable(It.IsAny<string>()))
                .Returns(Task.FromResult<bool>(false));

            await Assert.ThrowsAsync<EmailAlreadyInUseException>(
                () => _createUserHandler.HandleAsync(createUserCommand)
            );
        }
    }
}
