using Microsoft.EntityFrameworkCore;

namespace Rocket_Rest.Models
{
    public class Rocket_RestContext : DbContext
    {
        public Rocket_RestContext(DbContextOptions<Rocket_RestContext> options)
            : base(options)
        {
        }

        public DbSet<Battery> batteries { get; set; }
    }
}