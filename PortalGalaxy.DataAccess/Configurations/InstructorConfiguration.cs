using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalGalaxy.Entities;

namespace PortalGalaxy.DataAccess.Configurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.Property(p => p.NroDocumento)
            .HasMaxLength(12);

        builder.HasIndex(p => p.NroDocumento);
    }
}