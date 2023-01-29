using Microsoft.EntityFrameworkCore;
using RAWAPI.Domain;
using RAWAPI.Domain.Interface;

namespace RAWAPI.Application.Repositories {
    public interface IRepository<T> where T : BaseEntity {
        DbSet<T> Table { get; }
    }
}
