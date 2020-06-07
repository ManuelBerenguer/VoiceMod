using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Users.Core.Domain.Entities;
using VoiceMod.Users.Core.Repositories;
using VoiceMod.Users.Infrastructure.Data.EF.Data;
using VoiceMod.Users.Infrastructure.Data.EF.Mappers;

namespace VoiceMod.Users.Infrastructure.Data.EF.Repositories
{
    public class EfUsersRepository : IUsersRepository
    {
        protected readonly UsersDbContext _dbContext;
        public EfUsersRepository(UsersDbContext usersDbContext)
        {
            _dbContext = usersDbContext;
        }

        public async Task AddAsync(User user)
        {
            var dbUser = UserMapper.MapFrom(user);
            await _dbContext.AddAsync(dbUser);
            await _dbContext.SaveChangesAsync(); // We save with transaction because is an aggregate root
        }
                
        public async Task<User> GetById(Guid id)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            return user != null ? UserMapper.MapTo(user) : null;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);

            return user != null ? UserMapper.MapTo(user) : null;
        }

        public async Task UpdateAsync(User user)
        {
            var dbUser = UserMapper.MapFrom(user);
            _dbContext.Users.Update(dbUser);
            await _dbContext.SaveChangesAsync(); // We save with transaction because is an aggregate root
        }

        public async Task DeleteAsync(User user)
        {
            var dbUser = UserMapper.MapFrom(user);
            _dbContext.Users.Remove(dbUser);
            await _dbContext.SaveChangesAsync();
        }
    }
}
