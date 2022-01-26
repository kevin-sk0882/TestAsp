using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAsp.Models;

namespace TestAsp.Data.Entities_Configuration
{
    public class MatiereConfiguration : IEntityTypeConfiguration<Matiere>
    {
        public void Configure(EntityTypeBuilder<Matiere> builder)
        {
            builder.ToTable("Matiere", "dbo");
            builder.HasKey(m => m.CodeMat);
            builder.Property(m => m.CodeMat)
                .HasMaxLength(15)
                .IsRequired()
                .HasColumnType("varchar");
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");
            builder.HasMany(m => m.Notes)
                .WithOne(n => n.Matiere)
                .HasForeignKey(n => n.MatiereId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(m => m.Salle)
                .WithMany(s => s.Matieres)
                .HasForeignKey(m => m.SalleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
