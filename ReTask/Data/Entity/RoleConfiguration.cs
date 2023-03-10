using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ReTask.Data.Entity
{
    public class RoleConfiguration
    : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                { Name = "user", NormalizedName = "USER" },
                new IdentityRole
                { Name = "administrator", NormalizedName = "ADMINISTRATOR" });

        }
    }
}
