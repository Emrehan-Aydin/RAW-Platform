using MediatR;
using Microsoft.EntityFrameworkCore;
using RAWAPI.Application.Repositories.Content;
using RAWAPI.Application.Repositories.ContentRate;
using RAWAPI.Domain.Dtos;
using RAWAPI.Domain.Dtos.Request.Commend;
using RAWAPI.Domain.Dtos.Response.Commend;

namespace RAWAPI.Application.Features.Commands.Commend {
    public class CommendContentUpdateHandler : IRequestHandler<CommentRequest, CommandResult<CommentResponse>> {
        readonly ICommentWriteRepository _commentWriteService;
        readonly ICommentReadRepository _commentReadService;
        readonly IContentReadRepository _contentReadRepository;
        public CommendContentUpdateHandler(ICommentWriteRepository contentRateWriteService, ICommentReadRepository contentRateReadService, IContentReadRepository contentReadRepository) {
            _commentWriteService = contentRateWriteService;
            _commentReadService = contentRateReadService;
            _contentReadRepository = contentReadRepository;
        }

        public async Task<CommandResult<CommentResponse>> Handle(CommentRequest request, CancellationToken cancellationToken) {
            try {

                if (request == null
                    || request.UserId == null
                    || request.ContentId == null
                    || request.Message == null) {
                    throw new ArgumentNullException(nameof(request));
                }
                var content = await _contentReadRepository.GetById(request.ContentId);
                if (content == null) {
                    throw new InvalidOperationException("Bir sorun oluştu!");
                }

                var lastComment = await _commentReadService.GetWhere(x => x.UserId == request.UserId && x.ContentId == request.ContentId,false).ToListAsync();
                if (lastComment != null && 
                    lastComment.Any(x=>(DateTime.Now - x.CreatedDate).TotalSeconds < 30)) {
                    throw new TimeoutException("30 saniyede bir yorum yapabilirsiniz");
                }

                await _commentWriteService.AddAsync(new Domain.Entities.Comment.Comment {
                    ContentId = request.ContentId,
                    UserId = request.UserId,
                    Message = request.Message
                });

                await _commentWriteService.SaveAsync();

                return CommandResult<CommentResponse>.GetSucceed("Yorum gönderildi", null);
            }
            catch (TimeoutException ex) {
                return CommandResult<CommentResponse>.GetFailed(ex.Message, null);
            }
            catch (Exception ex) {
                return CommandResult<CommentResponse>.GetFailed("Bir sorun meydana geldi!", null);
            }
        }
    }
}

