using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationIdentity.Models;

namespace WebApplicationIdentity.Data.Configurations
{
    public class EnterpriseConfiguration : IEntityTypeConfiguration<Enterprise>
    {
        public void Configure(EntityTypeBuilder<Enterprise> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Owner)
                .WithMany(u => u.Enterprises)
                .HasForeignKey(e => e.OwnerId);
        }
    }
}
