using MediatR;
using RAWAPI.Domain.Dtos.Response.Profile;

namespace RAWAPI.Domain.Dtos.Request.Profile {
    public class ChangeShowcaseImageCommandRequest : IRequest<ChangeImageCommandResponse>
    {
        public string ImageId { get; set; }
        public string ProductId { get; set; }
    }
}
