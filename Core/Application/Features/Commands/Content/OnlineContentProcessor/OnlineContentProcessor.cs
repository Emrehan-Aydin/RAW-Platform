using MediatR;
using RAWAPI.Application.Repositories.Content;
using RAWAPI.Domain.Dtos;
using RAWAPI.Domain.Dtos.Request.Content;

namespace RAWAPI.Application.Features.Commands.Content {
    public class OnlineContentProcessor : IRequestHandler<ProcessOnlineContentRequest, CommandResult<ProcessOnlineContentResponse>> {
        private readonly IContentWriteRepository _contentWriteService;
        public OnlineContentProcessor(IContentWriteRepository contentWriteService) {
            _contentWriteService = contentWriteService;
        }


        async Task<CommandResult<ProcessOnlineContentResponse>> IRequestHandler<ProcessOnlineContentRequest, CommandResult<ProcessOnlineContentResponse>>.Handle(ProcessOnlineContentRequest request, CancellationToken cancellationToken) {
            try {
                if (request != null && request.Category != string.Empty) {
                    _contentWriteService.ContentRefreshProcessor(request.Category);
                    return CommandResult<ProcessOnlineContentResponse>.GetSucceed(request.Category + " İçerik işlendi",null);
                }
                else {
                    throw new InvalidOperationException(nameof(request));
                }
            }
            catch (Exception ex) {
                return CommandResult<ProcessOnlineContentResponse>.GetFailed(ex.Message);
            }
        }
    }
}
