using BooksApi.Infrastructure.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ReviewDto> Reviews { get; set; }

    }
}
