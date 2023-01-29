using MediatR;

namespace RAWAPI.Domain.Dtos.Request.Content {
    public class ProcessOnlineContentRequest : CommandBase<CommandResult<ProcessOnlineContentResponse>> {
        public string Category { get; set; }
    }
}
