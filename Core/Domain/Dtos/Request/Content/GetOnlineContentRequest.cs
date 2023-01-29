using MediatR;
using RAWAPI.Domain.Dtos.Response.Content;

namespace RAWAPI.Domain.Dtos.Request.Content {
    public class GetOnlineContentRequest : CommandBase<CommandResult<GetOnlineContentResponse>> {
        public string Category { get; set; }
    }
}