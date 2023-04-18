using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SW4BED_3.Models;

namespace SW4BED_3.Data
{
    public class UserDbContext : IdentityDbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

    }
}