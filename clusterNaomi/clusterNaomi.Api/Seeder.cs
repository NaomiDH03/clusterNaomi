

using clusterNaomi.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace clusterNaomi.Api
{
    public class Seeder
    {
        private readonly DataContext dataContext;
        public Seeder(DataContext dataContext) 
        { 
            this.dataContext = dataContext;
        }
        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await CheckStoresAsync();
            await CheckIcecreamsAsync();
        }

        private async Task CheckIcecreamsAsync()
        {
            if(!dataContext.Icecreams.Any())
            {
                var store = await dataContext.Stores.FirstOrDefaultAsync(x => x.Name == "Mega");
                if (store != null)
                {
                    dataContext.Icecreams.Add(new Icecream { Flavour = "pay", Price = 10, StoreId = store.Id });
                    dataContext.Icecreams.Add(new Icecream { Flavour = "Chocolate", Price = 15, StoreId = store.Id });
                    dataContext.Icecreams.Add(new Icecream { Flavour = "Fresa", Price = 20, StoreId = store.Id });
                  
                }
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckStoresAsync()
        {
            if(!dataContext.Stores.Any())
            {
                dataContext.Stores.Add(new Store { Name = "Mega", Address = "Carril a santa catarina", Location = "Puebla" });
                await dataContext.SaveChangesAsync();

            }
        }
    }
}
