using MediatR;
using RAWAPI.Application.Abstractions.Storage;
using RAWAPI.Application.Repositories.Profile;
using RAWAPI.Domain.Dtos.Request.Profile;
using RAWAPI.Domain.Dtos.Response.Profile;

namespace RAWAPI.Application.Features.Commands.Profile {
    public class CreateProfileCommand : IRequestHandler<CreateProfileRequest,CreateProfileResponse> {
        private readonly IProfileWriteRepository _profileWriteRepository;
        private readonly IStorageService _storageService; 
        public CreateProfileCommand(IProfileWriteRepository profileWriteRepository, IStorageService storageService) {
            _profileWriteRepository = profileWriteRepository;
            _storageService = storageService;
        }

        public async Task<CreateProfileResponse> Handle(CreateProfileRequest request, CancellationToken cancellationToken) {
            Domain.Entities.Profile.Profile profile = new Domain.Entities.Profile.Profile {
                Abstract = request.Abstract,
                Name = request.Name,
                Surname = request.Surname,
                BirthDate = request.BirthDate,
                UserId = request.UserId,
            };
            profile.ProfilePhotoId = await new ProfilePhotoUploadHandler(_storageService).HandleUploadProfilePhoto(request.profilePhoto, request.UserId);
            _profileWriteRepository.Table.Add(profile);
            await _profileWriteRepository.SaveAsync();
            return new();
        }      
    }
}
