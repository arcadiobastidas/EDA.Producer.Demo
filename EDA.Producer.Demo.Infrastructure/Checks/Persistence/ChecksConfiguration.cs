using EDA.Producer.Demo.Domain.Checks.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDA.Producer.Demo.Infrastructure.Checks.Persistence;

public class ChecksConfiguration : IEntityTypeConfiguration<Check>
{
    
    public void Configure(EntityTypeBuilder<Check> builder)
    {
        builder.ToTable("check");
        builder.Property(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Amount).IsRequired();
        builder.Property(x => x.IsGenerated);

    }
    
}