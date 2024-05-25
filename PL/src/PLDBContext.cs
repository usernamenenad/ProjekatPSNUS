using Microsoft.EntityFrameworkCore;

namespace PL.src
{
    public class PLDBContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        private static PLDBContext? instance;
        private static readonly object locker = new();

        public static PLDBContext Instance
        {
            get
            {
                lock(locker)
                {
                    instance ??= new PLDBContext();
                    return instance;
                }
            }
        }

        private PLDBContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=PL; Username=postgres; Password=0210");
        }
    }
}
