using RAWAPI.Application.Repositories.Profile;
using RAWAPI.Presistence.Context;

namespace RAWAPI.Presistence.Repositories.Profile {
    public class ProfileReadRepository : ReadRepository<Domain.Entities.Profile.Profile>, IProfileReadRepository {
        public ProfileReadRepository(RawDbContext context) : base(context) {
        }
    }
}
