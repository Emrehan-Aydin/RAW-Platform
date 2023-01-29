using MediatR;
using Microsoft.Extensions.Configuration;
using RAWAPI.Application.Abstractions.Storage;
using RAWAPI.Application.Repositories.Profile;
using RAWAPI.Domain.Dtos;
using RAWAPI.Domain.Dtos.Request.Profile;
using RAWAPI.Domain.Dtos.Response.Profile;

namespace RAWAPI.Application.Features.Commands.Profile {
    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileRequest, CommandResult<UpdateProfileResponse>> {
        private readonly IConfiguration _configuration;
        private readonly IStorageService _storageService;
        private readonly IProfileWriteRepository _profileWriteRepository;
        private readonly IProfileReadRepository _profileReadRepository;
        public UpdateProfileCommandHandler(IConfiguration configuration, IStorageService storageService, IProfileWriteRepository profileWriteRepository, IProfileReadRepository profileReadRepository) {
            _configuration = configuration;
            _storageService = storageService;
            _profileWriteRepository = profileWriteRepository;
            _profileReadRepository = profileReadRepository;
        }
        public async Task<CommandResult<UpdateProfileResponse>> Handle(UpdateProfileRequest request, CancellationToken cancellationToken) {
            try {
                RAWAPI.Domain.Entities.Profile.Profile profile = await _profileReadRepository.GetSingleAsync(x => x.UserId == request.UserId, true);
                if (profile is not null && request.profilePhoto is not null) {
                    profile.BirthDate = request.BirthDate;
                    profile.Name = request.Name; ;
                    profile.Surname = request.Surname;
                    profile.Email = request.Email;
                    profile.Abstract = request.Abstract;
                    if (request.profilePhoto.FileBytes != null && request.profilePhoto.FileBytes.Count() != 0 && request.profilePhoto.FileName!="default.png") {
                        await _storageService.DeleteAsync("profile-images", profile.ProfilePhotoId);
                        profile.ProfilePhotoId = await new ProfilePhotoUploadHandler(_storageService).HandleUploadProfilePhoto(request.profilePhoto, request.UserId);
                    }
                    await _profileWriteRepository.SaveAsync();
                }
                else { throw new ArgumentNullException(nameof(profile));}
                return CommandResult<UpdateProfileResponse>.GetSucceed("Başarılı", null);
            }
            catch (Exception) {
                return CommandResult<UpdateProfileResponse>.GetFailed("Hata");
            }
        }
    }
}

