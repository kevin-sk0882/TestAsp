using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAsp.Models;

namespace TestAsp.Data.Entities_Configuration
{
    public class FiliereConfiguration : IEntityTypeConfiguration<Filiere>
    {
        public void Configure(EntityTypeBuilder<Filiere> builder)
        {
            builder.ToTable("Filiere", "dbo");
            builder.HasKey(f => f.CodeFil);
            builder.Property(f=> f.CodeFil)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar");
            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar");
        }
    }
}
