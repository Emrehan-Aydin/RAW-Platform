using RAWAPI.Application.Repositories.Endpoint;
using RAWAPI.Presistence.Context;

namespace RAWAPI.Presistence.Repositories.Endpoint {
    public class EndpointReadRepository : ReadRepository<Domain.Entities.Endpoint>, IEndpointReadRepository {
        public EndpointReadRepository(RawDbContext context) : base(context) {
        }
    }
}
