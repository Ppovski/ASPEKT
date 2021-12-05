using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.TestConfigurations
{
  public class CompanyConfiguration : IEntityTypeConfiguration<Company>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Company> builder)
    {
      builder.ToTable("Company","Test");

      builder.Property(x => x.CompanyId).HasColumnType("int(255)");
      builder.Property(x => x.CompanyName).HasColumnType("navchar(255)");
      
    }
  }
}