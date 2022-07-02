using ExpedienteMedico.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpedienteMedico.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Physician> Physics { get; set; }

    }
}
