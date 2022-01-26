using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAsp.Models;

namespace TestAsp.Data.Entities_Configuration
{
    public class EnseignantConfiguration : IEntityTypeConfiguration<Enseignant>
    {
        public void Configure(EntityTypeBuilder<Enseignant> builder)
        {
            builder.ToTable("Enseignant", "dbo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .IsRequired()
                .UseIdentityColumn(1,1);
            builder.Property(e => e.Nom)
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();
            builder.Property(e => e.Prenom)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(e => e.Adresse)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(e => e.DatePriseFonct)
                .IsRequired();
            builder.Property(e => e.Email)
                .HasColumnType("varchar")
                .HasMaxLength(255);
            builder.Property(e => e.Telephone)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder.HasOne(e => e.Matiere)
                .WithMany(m => m.Enseignants)
                .HasForeignKey(e => e.MatiereId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
