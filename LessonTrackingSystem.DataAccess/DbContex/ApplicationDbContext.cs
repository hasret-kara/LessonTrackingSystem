using LessonTrackingSystem.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Claims;

namespace LessonTrackingSystem.DataAccess.DbContex
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }

        public override int SaveChanges()
        {
            ApplyAuditInfo();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInfo()
        {
            string? userIdStr = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid? userId = Guid.TryParse(userIdStr, out var parsed) ? parsed : null;

            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is IBaseEntity && (
                    e.State == EntityState.Added ||
                    e.State == EntityState.Modified ||
                    e.State == EntityState.Deleted));

            foreach (var entry in entries)
            {
                var entity = (IBaseEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = DateTime.UtcNow;
                    entity.CreatorUserId = userId;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.LastModificationDate = DateTime.UtcNow;
                    entity.LastModifierUserId = userId;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entity.DeletionDate = DateTime.UtcNow;
                    entity.DeletorUserId = userId;

                    var softDeleteProp = entry.Properties.FirstOrDefault(p => p.Metadata.Name == "IsDeleted");
                    if (softDeleteProp != null)
                    {
                        softDeleteProp.CurrentValue = true;
                    }
                }
            }
        }
    }
}
