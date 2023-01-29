using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RAWAPI.Presistence.Context;

namespace RAWAPI.Presistence {
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RawDbContext> {
        public RawDbContext CreateDbContext(string[] args) {
            DbContextOptionsBuilder<RawDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.getConnectionString());
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
