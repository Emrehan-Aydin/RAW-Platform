using Microsoft.EntityFrameworkCore;
using RAWAPI.Application.Repositories;
using RAWAPI.Domain;
using RAWAPI.Presistence.Context;
using System.Linq.Expressions;

namespace RAWAPI.Presistence.Repositories {

    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity {
        private readonly RawDbContext _context;

        public ReadRepository(RawDbContext context) {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> CheckAny(Expression<Func<T, bool>> expression) {
            return await Table.AnyAsync(expression);
        }

        public async Task<int> CountAsync() {
            return await Table.CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression) {
            return await Table.Where(expression).CountAsync();
        }

        public async Task<T> GetById(string id, bool tracking = true) {
            var query = Table.AsQueryable();
            if (!tracking) {
                query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true) {
            var query = Table.AsQueryable();
            if (!tracking) {
                query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true) {
            var query = Table.Where(method);
            if (!tracking) {
                query.AsNoTracking();
            }
            return query;
        }

        public Task<bool> ValidateDuplicate(Expression<Func<T, bool>> expression) {
            throw new NotImplementedException();
        }

        IQueryable<T> IReadRepository<T>.GetAll(bool tracking = true) {
            var query = Table.AsQueryable();
            if (!tracking) {
                query.AsNoTracking();
            }
            return query;
        }
    }
}
