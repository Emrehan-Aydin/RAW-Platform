using RAWAPI.Application.Repositories.Menu;
using RAWAPI.Domain.Entities;
using RAWAPI.Presistence.Context;
using RAWAPI.Presistence.Repositories;

namespace RAWAPI.Presistence.Repositories.Menu {
    public class MenuWriteRepository : WriteRepository<Domain.Entities.Menu>, IMenuWriteRepository {
        public MenuWriteRepository(RawDbContext context) : base(context) {
        }
    }
}
