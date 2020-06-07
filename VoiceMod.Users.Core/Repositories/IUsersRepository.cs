using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Users.Core.Domain.Entities;

namespace VoiceMod.Users.Core.Repositories
{
    public interface IUsersRepository
    {
        Task<User> GetById(Guid id);
        Task<User> GetByEmail(string email);
        Task AddAsync(User user);

        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
