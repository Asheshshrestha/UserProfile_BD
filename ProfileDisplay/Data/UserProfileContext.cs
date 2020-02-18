using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProfileDisplay.Data
{
    public class UserProfileContext : DbContext
    {
        public UserProfileContext(DbContextOptions<UserProfileContext> options) : base(options)
        {

        }
        public DbSet<ProfileDisplay.Models.UserProfile> UserProfile { get; set; }
    }
}
