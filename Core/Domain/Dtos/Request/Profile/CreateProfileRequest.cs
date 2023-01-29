using MediatR;
using Microsoft.AspNetCore.Http;
using RAWAPI.Domain.Dtos.Response.Profile;
using RAWAPI.Domain.Entities.File;

namespace RAWAPI.Domain.Dtos.Request.Profile {
    public class CreateProfileRequest : IRequest<CreateProfileResponse> {
        public string UserId { get; set; } = string.Empty;
        public ImageFile profilePhoto { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string Abstract { get; set; } = string.Empty;
    }
}
