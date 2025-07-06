using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationIdentity.Models;

namespace WebApplicationIdentity.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Enterprises)
                .WithOne(e => e.Owner)
                .HasForeignKey(e => e.OwnerId);
        }
    }
}
