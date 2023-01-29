using MediatR;
using RAWAPI.Domain.Entities.File;

namespace RAW.Client.Helpers {
    public static class RequestFileHelper {
        public static ImageFile ReadPhotoInfo(HttpRequest request) {
            if (!request.Form.Files.Any()) {
                return new ImageFile {
                    FileBytes = new byte[0],
                    FileExtension = "jpg",
                    FileName = "default"
                };
            }
            else {
                IFormFile photo = request.Form.Files[0];
                ImageFile uploadedPhoto = new ImageFile();
                using (MemoryStream ms = new MemoryStream()) {
                    photo.CopyTo(ms);
                    uploadedPhoto.FileBytes = ms.ToArray();
                }
                uploadedPhoto.FileName= photo.FileName.Split('.').First();
                uploadedPhoto.FileExtension = photo.FileName.Split('.').Last();
                return uploadedPhoto;
            }
        }
    }
}

