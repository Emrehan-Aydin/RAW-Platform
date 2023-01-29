using Microsoft.AspNetCore.Http;
using RAWAPI.Application.Abstractions.Storage;
using RAWAPI.Domain.Entities.File;

namespace RAWAPI.Application.Features.Commands.Profile {
    public class ProfilePhotoUploadHandler {
        IStorageService _storageService;
        public ProfilePhotoUploadHandler(IStorageService storageService) {
            _storageService = storageService;
        }

        public async Task<string> HandleUploadProfilePhoto(ImageFile photo, string userId) {
            if (photo.FileBytes.Length != 0 && photo.FileName != "0000") {
                using var stream = new MemoryStream(photo.FileBytes);
                var formFile = new FormFile(stream, 0, stream.Length, "streamFile", string.Format("profile~{0}~{1}.{2}", userId, photo.FileName, photo.FileExtension));
                await _storageService.UploadAsync("profile-images", new FormFileCollection { formFile });
                return formFile.FileName;
            }
            else {
                return "default.png";
            }
        }
    }
}
