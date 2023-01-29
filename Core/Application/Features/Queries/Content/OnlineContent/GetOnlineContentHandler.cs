using MediatR;
using RAWAPI.Domain.Dtos.Request.Content;
using RAWAPI.Domain.Dtos.Response.Content;
using RAWAPI.Domain.Dtos;
using RAWAPI.Application.Repositories.Content;
using RAWAPI.Application.Repositories.Profile;
using RAWAPI.Application.Abstractions.Storage;
using RAWAPI.Application.Abstractions.Services;

namespace RAWAPI.Application.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoint {
    public class GetOnlineContentHandler : IRequestHandler<GetOnlineContentRequest, CommandResult<GetOnlineContentResponse>> {
        IContentReadRepository _contentReadService;
        IProfileReadRepository _profileReadService;
        IUserService _userService;


        public GetOnlineContentHandler(IContentReadRepository contentReadService, IProfileReadRepository profileReadService, IUserService userService) {
            _contentReadService = contentReadService;
            _profileReadService = profileReadService;
            _userService = userService;
        }

        public async Task<CommandResult<GetOnlineContentResponse>> Handle(GetOnlineContentRequest request, CancellationToken cancellationToken) {
            try {


                GetOnlineContentResponse onlineContent = new GetOnlineContentResponse();
                var onlineContentResponse = _contentReadService.GetOnlineContent(request.Category);
                if (onlineContentResponse == null) {
                    return CommandResult<GetOnlineContentResponse>.GetFailed("Şu anda görüntülenecek bir içerik yok");
                }
                if (!string.IsNullOrEmpty(onlineContentResponse.UserId) && onlineContentResponse.UserId != "Anonymousny") {
                    var onlineContentProfileResponse = await _profileReadService.GetSingleAsync(p => p.UserId == onlineContentResponse.UserId);
                    if (onlineContentProfileResponse != null) {
                        onlineContent.UserFullName = string.Format("{0} {1}", onlineContentProfileResponse.Name, onlineContentProfileResponse.Surname);
                        onlineContent.ProfilePhoto = await _userService.GetUserProfilePhoto(onlineContentProfileResponse.ProfilePhotoId);
                    }
                }
                else {
                    onlineContent.UserFullName = "Bu profil gizlidir";
                    onlineContent.ProfilePhoto = await _userService.GetUserProfilePhoto("");

                }

                if (onlineContentResponse == null) {
                    return CommandResult<GetOnlineContentResponse>.GetFailed("Şu anda görüntülenecek bir içerik yok");
                };
                onlineContent.Id = onlineContentResponse.Id.ToString();
                onlineContent.Link = onlineContentResponse.Link;
                onlineContent.Abstract = onlineContentResponse.Abstract;
                onlineContent.CreatedDate = onlineContentResponse.CreatedDate;
                return CommandResult<GetOnlineContentResponse>.GetSucceed("Başarılı",onlineContent);
            }
            catch(ArgumentNullException ex) {
                return CommandResult<GetOnlineContentResponse>.GetFailed("Bugün için gösterilecek bir içerik yok");
            }

            catch (Exception ex) {
                return CommandResult<GetOnlineContentResponse>.GetFailed("İçerik yüklenirken sorun oluştu!");
            }
        }
    }
}
