using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAWAPI.Application.Abstractions.Storage;
using RAWAPI.Domain.Dtos;
using RAWAPI.Domain.Dtos.Request.Comment;
using RAWAPI.Domain.Dtos.Response.Comment;

namespace RAWAPI.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]


    public class CommentController : ControllerBase {
        readonly IMediator _mediator;
        public CommentController(IMediator mediator, IStorageService storageService) {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<CommandResult<Pagination<CommentListResponse>>> GetContentComment(CommentListRequest request) {
            try {
                return await _mediator.Send(request);
            }
            catch (Exception) {
                return CommandResult<Pagination<CommentListResponse>>.GetFailed("Bir sorun oluştu", null);
            }

        }

    }
}
