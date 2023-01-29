using RAWAPI.Domain;

namespace RAWAPI.Application.Repositories {
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity{
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model);
        Task<bool> Remove(string id);
        bool Remove(T model);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}

