using Microsoft.EntityFrameworkCore;

namespace Filmes.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BARBARA_ANTUNES;Database=filmesdb;Authentication=Active Directory Integrated;MultipleActiveResultSets=true;TrustServerCertificate=true");
        }
    }
}
