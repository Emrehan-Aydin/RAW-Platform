using MediatR;
using RAWAPI.Application.Repositories.Content;
using RAWAPI.Application.Repositories.ContentRate;
using RAWAPI.Domain.Dtos;
using RAWAPI.Domain.Dtos.Request.ContentRate;
using RAWAPI.Domain.Dtos.Response.ContentRate;

namespace RAWAPI.Application.Features.Commands.ContentRate {
    public class ContentRateUpdateHandler : IRequestHandler<ContentRateRequest, CommandResult<ContentRateResponse>> {
        readonly IContentRateWriteRepository _contentRateWriteService;
        readonly IContentRateReadRepository _contentRateReadService;
        public ContentRateUpdateHandler(IContentRateWriteRepository contentRateWriteService, IContentRateReadRepository contentRateReadService) {
            _contentRateWriteService = contentRateWriteService;
            _contentRateReadService = contentRateReadService;
        }

        public async Task<CommandResult<ContentRateResponse>> Handle(ContentRateRequest request, CancellationToken cancellationToken) {
            try {

                if (request == null
                    || request.UserId == null
                    || request.ContentId == null) {
                    throw new ArgumentNullException(nameof(request));
                }
                var content = await _contentRateReadService.GetSingleAsync(x => x.UserId == request.UserId && x.ContentId == request.ContentId, true);
                if (content == null) {
                    await _contentRateWriteService.AddAsync(new Domain.Entities.ContentRates.ContentRate {
                        ContentId = request.ContentId,
                        UserId = request.UserId,
                        Rate = request.Rate
                    });
                }
                else {
                    content.Rate = request.Rate;
                    _contentRateWriteService.Update(content);
                }
                await _contentRateWriteService.SaveAsync();
                return CommandResult<ContentRateResponse>.GetSucceed($"İçeriği {request.Rate} olarak oyladınız ",null);
            }
            catch (Exception) {
                return CommandResult<ContentRateResponse>.GetFailed("Bir sorun oluştu");
            }
        }
    }
}

