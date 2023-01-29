using RAWAPI.Application.Repositories.Menu;
using RAWAPI.Domain.Entities;
using RAWAPI.Presistence.Context;
using RAWAPI.Presistence.Repositories;

namespace RAWAPI.Presistence.Repositories.Menu {
    public class MenuReadRepository : ReadRepository<Domain.Entities.Menu>, IMenuReadRepository {
        public MenuReadRepository(RawDbContext context) : base(context) {
        }
    }
}
