using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RAWAPI.Application.Repositories;
using RAWAPI.Domain;
using RAWAPI.Presistence.Context;

namespace RAWAPI.Presistence.Repositories {
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity {
        private readonly RawDbContext _context;
        public WriteRepository(RawDbContext context) {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model) {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }
        public async Task<bool> AddRangeAsync(List<T> model) {
            await Table.AddRangeAsync(model);
            return true;
        }

        public async Task<bool> Remove(string id) {
            T? model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            if (model is not null ) {
                EntityEntry<T> entityEntry = Table.Remove(model);
                return entityEntry.State == EntityState.Deleted;
            }
            return false;
        }

        public bool Remove(T model) {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public bool Update(T model) {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
