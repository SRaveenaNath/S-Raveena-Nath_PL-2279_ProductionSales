using Camp6AssignmentProductionSales.Model;
using Microsoft.EntityFrameworkCore;

namespace Camp6AssignmentProductionSales.Repository
{
    public class StoreRepository : IRepository<Store>
    {
        private readonly SalesProductionDbContext _context;

        public StoreRepository(SalesProductionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Store>> GetAllAsync()
        {
            return await _context.Stores.ToListAsync();
        }

        public async Task<Store?> GetByIdAsync(int id)
        {
            return await _context.Stores.FindAsync(id);
        }

        public async Task AddAsync(Store store)
        {
            await _context.Stores.AddAsync(store);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Store store)
        {
            _context.Stores.Update(store);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var store = await _context.Stores.FindAsync(id);
            if (store != null)
            {
                _context.Stores.Remove(store);
                await _context.SaveChangesAsync();
            }
        }
    }
}
