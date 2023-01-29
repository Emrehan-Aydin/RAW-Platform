using RAWAPI.Application.Repositories.Endpoint;
using RAWAPI.Presistence.Context;

namespace RAWAPI.Presistence.Repositories.Endpoint {
    public class EndpointWriteRepository : WriteRepository<Domain.Entities.Endpoint>, IEndpointWriteRepository {
        public EndpointWriteRepository(RawDbContext context) : base(context) {
        }
    }
}
