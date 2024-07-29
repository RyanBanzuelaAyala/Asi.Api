namespace Asi.Data.V1
{
    using Asi.Domain.Model.V1.AuthorVM;
    using Asi.Domain.Model.V1.BookVM;
    using Microsoft.EntityFrameworkCore;

    public class AsiDbContext : DbContext
    {
        public AsiDbContext(DbContextOptions<AsiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }
    }
}
