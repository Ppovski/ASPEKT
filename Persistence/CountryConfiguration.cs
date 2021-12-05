using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.TestConfigurations
{
  public class CountryConfiguration : IEntityTypeConfiguration<Country>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Country> builder)
    {
      builder.ToTable("Country","Test");

      builder.Property(x => x.CountryId).HasColumnType("int(255)");
      builder.Property(x => x.CountryName).HasColumnType("navchar(255)");
      
    }
  }
}