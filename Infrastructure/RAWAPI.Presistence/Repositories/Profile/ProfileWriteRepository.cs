using RAWAPI.Application.Repositories.Profile;
using RAWAPI.Presistence.Context;

namespace RAWAPI.Presistence.Repositories.Profile {
    public class ProfileWriteRepository : WriteRepository<Domain.Entities.Profile.Profile>, IProfileWriteRepository {
        public ProfileWriteRepository(RawDbContext context) : base(context) {
        }
    }
}
