using Microsoft.EntityFrameworkCore;
using RAWAPI.Application.Repositories.Content;
using RAWAPI.Domain.Entities.Contents;
using RAWAPI.Presistence.Context;

namespace RAWAPI.Presistence.Repositories.ContentRepository {
    public class ContentWriteRepository : WriteRepository<Content>, IContentWriteRepository {
        private readonly RawDbContext _context;
        public ContentWriteRepository(RawDbContext context) : base(context) {
            _context = context;
        }

        public void ContentRefreshProcessor(string category) {
            var order = _context.Content.Where(x => x.ContentCategory == category && !x.IsShowed && !x.IsOnline).ToList();
            if (order.Any()) {
                var onlineContent = _context.Content.FirstOrDefault(x => x.ContentCategory == category && x.IsOnline);
                if (onlineContent != null) {
                    onlineContent.IsShowed = true;
                    onlineContent.IsOnline = false;
                }
                Random random = new();
                order[random.Next(0, order.Count)].IsOnline = true;
                _context.SaveChanges();
            }
        }
    }
}
