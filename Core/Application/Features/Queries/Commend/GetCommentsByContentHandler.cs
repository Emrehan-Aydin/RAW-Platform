using MediatR;
using RAWAPI.Domain.Dtos.Request.Content;
using RAWAPI.Domain.Dtos.Response.Content;
using RAWAPI.Domain.Dtos;
using RAWAPI.Application.Repositories.Content;
using RAWAPI.Application.Repositories.Profile;
using RAWAPI.Application.Abstractions.Storage;
using RAWAPI.Application.Abstractions.Services;
using RAWAPI.Domain.Dtos.Request.Commend;
using RAWAPI.Domain.Dtos.Response.Commend;
using System.Collections.Generic;
using RAWAPI.Domain.Dtos.Request.Comment;
using Microsoft.Extensions.Configuration;
using RAWAPI.Domain.Dtos.Response.Comment;

namespace RAWAPI.Application.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoint {
    public class GetCommentsByContentHandler : IRequestHandler<CommentListRequest, CommandResult<Pagination<CommentListResponse>>> {
        ICommentReadRepository _commentReadService;


        public GetCommentsByContentHandler(ICommentReadRepository commentReadRepository) {
            _commentReadService = commentReadRepository;
        }

        public Task<CommandResult<Pagination<CommentListResponse>>> Handle(CommentListRequest request, CancellationToken cancellationToken) {
            try {
                var result = _commentReadService.GetCommentList(request);
                if(result == null) {
                    throw new ArgumentNullException(nameof(result));
                }
                return Task.FromResult(CommandResult<Pagination<CommentListResponse>>.GetSucceed(result));
            }
            catch (Exception) {
                return Task.FromResult(CommandResult<Pagination<CommentListResponse>>.GetFailed("Bir Sorun Oluştu"));

            }
        }
    }
}
