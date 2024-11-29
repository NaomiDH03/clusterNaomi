using Microsoft.EntityFrameworkCore;
using clusterNaomi.Shared.Entities;

namespace clusterNaomi.Api
{
    public class DataContext : DbContext
    {
        public DbSet<Icecream> Icecreams { get; set; }
        public DbSet<Store> Stores { get; set; }

        public DataContext(DbContextOptions<DataContext> dbContext) : base(dbContext)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Índices únicos
            modelBuilder.Entity<Icecream>().HasIndex(x => x.Flavour).IsUnique(); // Para sabores únicos
            modelBuilder.Entity<Store>().HasIndex(x => x.Name).IsUnique();       // Para nombres de tienda únicos

            //Esto es para que se elimina en cascada
            modelBuilder.Entity<Store>()
                .HasMany(s => s.Icecreams)
                .WithOne()
                .HasForeignKey(i => i.StoreId)
                .OnDelete(DeleteBehavior.Cascade); // Con esto los helados se eliminan cuando se quita una tienda
        }

    }
}
