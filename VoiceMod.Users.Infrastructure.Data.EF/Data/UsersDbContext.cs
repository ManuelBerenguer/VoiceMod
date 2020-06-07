using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VoiceMod.Users.Infrastructure.Data.EF.Persistance_Models;

namespace VoiceMod.Users.Infrastructure.Data.EF.Data
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
