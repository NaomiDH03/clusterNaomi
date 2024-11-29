using Microsoft.EntityFrameworkCore;
using clusterNaomi.Shared.Entities;

namespace clusterNaomi.Api
{
    public class DataContext : DbContext
    {
        public DbSet<Icecream> Icecreams { get; set; }
    }
}
