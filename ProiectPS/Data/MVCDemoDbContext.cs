using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectPS.Models.Domain;

namespace ProiectPS.Data
{
    public class MVCDemoDbContext : IdentityDbContext
    {
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Packet> Packets { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
