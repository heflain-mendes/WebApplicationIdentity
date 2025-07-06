using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationIdentity.Models;

namespace WebApplicationIdentity.Data
{
    public class WebApplicationIdentityDbContext : IdentityDbContext<User>
    {
        public DbSet<Enterprise> Enterprises { get; set; }
        public WebApplicationIdentityDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(WebApplicationIdentityDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
