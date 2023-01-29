using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAWAPI.Application.Abstractions.Storage;
using RAWAPI.Application.Features.Commands.Content;
using RAWAPI.Domain.ApiRequest.Content;
using RAWAPI.Domain.Common;
using RAWAPI.Domain.Dtos;
using RAWAPI.Domain.Dtos.Request.Commend;
using RAWAPI.Domain.Dtos.Request.Content;
using RAWAPI.Domain.Dtos.Request.ContentRate;
using RAWAPI.Domain.Dtos.Response.Commend;
using RAWAPI.Domain.Dtos.Response.Content;
using RAWAPI.Domain.Dtos.Response.ContentRate;
using RAWAPI.Domain.Dtos.Response.Profile;

namespace RAWAPI.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase {
        readonly IMediator _mediator;
        public ContentController(IMediator mediator, IStorageService storageService) {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<CommandResult<UploadContentResponse>> Upload(UploadContentDto request) {
            try {
                switch (request.Category) {
                    case "Video":
                        return await _mediator.Send(JSON.Map<UploadContentDto, UploadVideoContent>(request));
                    case "Draw":
                        return await _mediator.Send(JSON.Map<UploadContentDto, UploadImageContent>(request));
                    case "Music":
                        return await _mediator.Send(JSON.Map<UploadContentDto, UploadVideoContent>(request));
                    case "Document":
                        if (string.IsNullOrEmpty(request.Abstract) || request.Abstract.Trim() == string.Empty) {
                            throw new InvalidOperationException("Boş Bir içerik yükleyemezsiniz'");
                        }
                        return await _mediator.Send(JSON.Map<UploadContentDto, UploadTextContent>(request));
                    default:
                        if (string.IsNullOrEmpty(request.Abstract) || request.Abstract.Trim() == string.Empty) {
                            throw new InvalidOperationException("Boş Bir içerik yükleyemezsiniz'");
                        }
                        return await _mediator.Send(JSON.Map<UploadContentDto, UploadTextContent>(request));
                }
            }
            catch (Exception error) {
                return CommandResult<UploadContentResponse>.GetFailed(error.Message);
            }
        }

        [HttpGet("GetDailyContent/{category}")]
        public async Task<CommandResult<GetOnlineContentResponse>> GetDailyContent(string category) {
            try {
                return await _mediator.Send(new GetOnlineContentRequest { Category = category });
            }
            catch (Exception) {
                return CommandResult<GetOnlineContentResponse>.GetFailed("Şu anda hizmet veremiyoruz. Özür Dileriz");
            }

        }

        [HttpGet("ProcessDailyContent/{category}")]
        public async Task<string> ProcessDailyContent(string category) {
            try {
                var result = await _mediator.Send(new ProcessOnlineContentRequest { Category = category});

                return result.Message;
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        [HttpPost("RateContent")]
        public async Task<CommandResult<ContentRateResponse>> RateContent(ContentRateRequest request) {
            try {
                return await _mediator.Send(request);
            }
            catch (Exception ex) {
                return CommandResult<ContentRateResponse>.GetFailed("Şu anda hizmet veremiyoruz. Özür Dileriz");
            }
        }

        [HttpPost("CommentContent")]
        public async Task<CommandResult<CommentResponse>> CommentContent(CommentRequest request) {
            try {
                return await _mediator.Send(request);
            }
            catch (Exception ex) {
                return CommandResult<CommentResponse>.GetFailed("Şu anda hizmet veremiyoruz. Özür Dileriz");
            }
        }
    }
}
