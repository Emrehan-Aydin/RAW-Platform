using RAWAPI.Domain.Dtos.Response.ContentRate;

namespace RAWAPI.Domain.Dtos.Request.ContentRate {
    public class ContentRateRequest : CommandBase<CommandResult<ContentRateResponse>>{
        public short Rate { get; set; }
        public string UserId { get; set; }
        public string ContentId { get; set; }
    }
}
