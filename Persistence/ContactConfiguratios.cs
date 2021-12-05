using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.TestConfigurations
{
  public class ContactConfiguration : IEntityTypeConfiguration<Contact>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Contact> builder)
    {
      builder.ToTable("Contact","Test");

      builder.Property(x => x.Contact).HasColumnType("int(255)");
      builder.Property(x => x.ContactName).HasColumnType("navchar(255)");
      builder.Property(x => x.CompanyId).HasColumnType("int(255)");
      builder.Property(x => x.CountryId).HasColumnType("int(255)");
    
    }
  }
}