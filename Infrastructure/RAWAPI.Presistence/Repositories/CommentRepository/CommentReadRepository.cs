using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using RAWAPI.Application.Repositories.Content;
using RAWAPI.Domain.Dtos;
using RAWAPI.Domain.Dtos.Request.Comment;
using RAWAPI.Domain.Dtos.Response.Comment;
using RAWAPI.Presistence.Context;

namespace RAWAPI.Presistence.Repositories.ContentRate {
    public class CommentReadRepository : ReadRepository<Domain.Entities.Comment.Comment>, ICommentReadRepository {
        private readonly RawDbContext _context;
        private IConfiguration _configuration;
        public CommentReadRepository(RawDbContext context, IConfiguration configuration) : base(context) {
            _context = context;
            _configuration = configuration;
        }

        public Pagination<CommentListResponse> GetCommentList(CommentListRequest request) {
            try {

                List<CommentListResponse> result = (from c in _context.Comment
                                                    join p in _context.Profile
                                                    on c.UserId equals p.UserId
                                                    where c.ContentId == request.ContentId
                                                    orderby c.CreatedDate descending
                                                    select new CommentListResponse {
                                                        UserId = p.UserId,
                                                        Comment = c.Message,
                                                        Date = c.CreatedDate.Date.ToString(),
                                                        ProfilePhoto = !string.IsNullOrEmpty(p.ProfilePhotoId) ?
                          $"{_configuration["BaseStorageUrl"]}/profile-images/{p.ProfilePhotoId}" :
                          $"{_configuration["BaseStorageUrl"]}/profile-images/default.png",
                                                        UserFullName = string.Format("{0} {1}", p.Name, p.Surname)
                                                    }).Skip(request.Page*request.Size).Take(request.Size).ToList();

                if (!result.Any()) {
                    return new Pagination<CommentListResponse> {
                        Content = null,
                        Size = request.Size,
                        Page = request.Size,
                        TotalSize = request.Size,
                        StopPaging = true,
                    };
                }
                Pagination<CommentListResponse> comments = new Pagination<CommentListResponse>();
                comments.Content = result;
                comments.TotalSize = result.Count();
                comments.Page = request.Page;
                comments.Size = request.Size;
                return comments;
            }
            catch (Exception) {
                return null;
            }
        }
    }
}
