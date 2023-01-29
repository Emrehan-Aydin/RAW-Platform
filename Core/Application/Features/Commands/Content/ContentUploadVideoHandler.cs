using MediatR;
using Microsoft.AspNetCore.Http;
using RAWAPI.Application.Abstractions.Storage;
using RAWAPI.Application.Repositories.Content;
using RAWAPI.Domain.Dtos;
using RAWAPI.Domain.Dtos.Request.Content;
using RAWAPI.Domain.Dtos.Response.Content;

namespace RAWAPI.Application.Features.Commands.Content {
    public class ContentUploadVideoHandler : IRequestHandler<UploadVideoContent, CommandResult<UploadContentResponse>> {
        private readonly IContentReadRepository _contentReadService;
        private readonly IContentWriteRepository _contentWriteService;
        private readonly IStorageService _storageService;
        public ContentUploadVideoHandler(IContentReadRepository contentReadService, IContentWriteRepository contentWriteService, IStorageService storageService) {
            _contentReadService = contentReadService;
            _contentWriteService = contentWriteService;
            _storageService = storageService;
        }

        public async Task<CommandResult<UploadContentResponse>> Handle(UploadVideoContent request, CancellationToken cancellationToken) {
            try {
                if (_contentReadService.GetWhere(x => x.UserId == request.UserId && x.ContentCategory == request.Category && x.CreatedDate.AddDays(30) > DateTime.Now).Any()) {
                    return CommandResult<UploadContentResponse>.GetFailed("30 Gün içinde sadece 1 kez yükleme yapabilirsiniz", null);
                }
                if (string.IsNullOrEmpty(request.ContentLink)) {
                    // link validasyonu eklenebilir.
                    return CommandResult<UploadContentResponse>.GetFailed("İçerik linki sorunlu", null);
                }


                _ = await _contentWriteService.AddAsync(new Domain.Entities.Contents.Content() {
                    UserId = request.UserId,
                    ContentCategory = request.Category,
                    ContentAbstract = request.Abstract,
                    Context = request.ContentLink,
                    IsAnoAnonymousny = (bool)request.Anonymous,
                    IsOnline = false,
                    IsShowed = false,
                    RecordStatus = true
                });

                _ = await _contentWriteService.SaveAsync();
                return CommandResult<UploadContentResponse>.GetSucceed("Başarılı", new());
            } catch (Exception ex) when (ex!=null){
                return CommandResult<UploadContentResponse>.GetFailed("İçerik yüklenirken sorun oluştu!", null);
            }

        }
    }
}
