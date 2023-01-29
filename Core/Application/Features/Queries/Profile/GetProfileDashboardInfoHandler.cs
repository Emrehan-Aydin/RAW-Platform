using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RAWAPI.Application.Repositories.Profile;
using RAWAPI.Domain.Dtos;
using RAWAPI.Domain.Dtos.Request.Profile;
using RAWAPI.Domain.Dtos.Response.Profile;

public class GetProfileDashboardInfoHandler : IRequestHandler<GetUserProfileRequest, CommandResult<GetUserProfileResponse>> {
    private readonly IProfileReadRepository _profileService;
    private readonly IConfiguration _configuration;

    public GetProfileDashboardInfoHandler(IProfileReadRepository profileService, IConfiguration configuration) {
        _profileService = profileService;
        _configuration = configuration;
    }

    public async Task<CommandResult<GetUserProfileResponse>> Handle(GetUserProfileRequest request, CancellationToken cancellationToken) {
        try {
            RAWAPI.Domain.Entities.Profile.Profile profile = await _profileService.GetSingleAsync(p => p.UserId == request.UserId);
            if(profile is null) { throw new ArgumentNullException(nameof(profile)); }
            GetUserProfileResponse profileResult = JsonConvert.DeserializeObject<GetUserProfileResponse>(JsonConvert.SerializeObject(profile));
            string containerName = "profile-images";
            profileResult.PhotoUrl = $"{_configuration["BaseStorageUrl"]}/{containerName}/{profile.ProfilePhotoId}";
            return CommandResult<GetUserProfileResponse>.GetSucceed(profileResult);
        }
        catch (Exception ex) when(ex!=null) {
            return CommandResult<GetUserProfileResponse>.GetFailed("Profil Bulunamadı!");

        }
    }
}