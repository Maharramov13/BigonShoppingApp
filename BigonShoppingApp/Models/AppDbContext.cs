using BigonShoppingApp.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;

namespace BigonShoppingApp.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions opt):base(opt) { }

        public DbSet<Category> Categories { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in datas)
            {
                switch (item.State)
                {
                    case EntityState.Deleted:
                        item.Entity.DeletedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        item.Entity.UpdatedAt = DateTime.Now;
                        break;
                    case EntityState.Added:
                        item.Entity.CreatedAt = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
