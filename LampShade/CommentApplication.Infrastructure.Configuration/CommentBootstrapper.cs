using System;
using CommentApplication.Infrastructure.EFCore;
using CommentApplication.Infrastructure.EFCore.Repository;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommentApplication.Infrastructure.Configuration
{
    public class CommentBootstrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<ICommentApplication,CommentManagement.Application.CommentApplication>();
            service.AddTransient<ICommentRepository, CommentRepository>();

            service.AddDbContext<CommentContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
