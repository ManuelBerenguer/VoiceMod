using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Common.Handlers;
using VoiceMod.Users.Core.Dtos;
using VoiceMod.Users.Core.Exceptions;
using VoiceMod.Users.Core.Mappers;
using VoiceMod.Users.Core.Queries;
using VoiceMod.Users.Core.Repositories;

namespace VoiceMod.Users.Core.Handlers
{
    /// <summary>
    /// Class with the responsability to handle get user queries. Not inheritable.
    /// </summary>
    public sealed class GetUserHandler : IQueryHandler<GetUser, UserDto>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<UserDto> HandleAsync(GetUser query)
        {
            var user = await _usersRepository.GetById(query.Id);

            return user == null ? null : UserMapper.From(user);
        }
    }
}
