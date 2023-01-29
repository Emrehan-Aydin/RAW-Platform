using RAWAPI.Domain.Dtos;

namespace RAW.Client.Dto {
    public class CommentViewModel {
    }
    public class CommentView{
        public string UserId { get; set; }
        public string ProfilePhoto { get; set; }
        public string Date { get; set; }
        public string UserFullName { get; set; }
        public string Comment { get; set; }
    }
}
