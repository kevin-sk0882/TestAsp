using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAsp.Models;

namespace TestAsp.Data.Entities_Configuration
{
    public class DepartementConfiguration : IEntityTypeConfiguration<Departement>
    {
        public void Configure(EntityTypeBuilder<Departement> builder)
        {
            builder.ToTable("Departement", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(d => d.Id)
                .IsRequired()
                .UseIdentityColumn(1,1);
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();
            builder.HasMany(d => d.Enseignants)
                .WithOne(e => e.Departement)
                .HasForeignKey(e => e.DepartementId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
