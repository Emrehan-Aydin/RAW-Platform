using RAWAPI.Domain;
using System.Linq.Expressions;

namespace RAWAPI.Application.Repositories {
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity{
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetById(string id, bool tracking = true);
        Task<bool> ValidateDuplicate(Expression<Func<T, bool>> expression);
        Task<bool> CheckAny(Expression<Func<T, bool>> expression);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
    }
}
