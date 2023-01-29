using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RAWAPI.Domain;
using RAWAPI.Domain.Entities;
using RAWAPI.Domain.Entities.Comment;
using RAWAPI.Domain.Entities.ContentRates;
using RAWAPI.Domain.Entities.Contents;
using RAWAPI.Domain.Entities.Identity;
using RAWAPI.Domain.Entities.Message;
using RAWAPI.Domain.Entities.Profile;

namespace RAWAPI.Presistence.Context {
    public class RawDbContext : IdentityDbContext<AppUser, AppRole, string> { 
        public RawDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Content> Content{ get; set; }
        public DbSet<ContentRate> ContentRate{ get; set; }
        public DbSet<Comment> Comment{ get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
            var entities = ChangeTracker.Entries<BaseEntity>();
            foreach (var entity in entities) {
                _ = entity.State switch {
                    EntityState.Added => entity.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => entity.Entity.ModifiedDate = DateTime.UtcNow,
                    _ => entity.Entity.ModifiedDate = DateTime.UtcNow,
                };
                entity.Entity.ModifiedDate = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
