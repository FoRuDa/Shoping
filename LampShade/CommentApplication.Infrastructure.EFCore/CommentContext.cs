using CommentApplication.Infrastructure.EFCore.Mapping;
using CommentManagement.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace CommentApplication.Infrastructure.EFCore
{
   public class CommentContext:DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public CommentContext(DbContextOptions<CommentContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CommentMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
