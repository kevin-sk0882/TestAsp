using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAsp.Models;

namespace TestAsp.Data.Entities_Configuration
{
    public class SalleConfiguration : IEntityTypeConfiguration<Salle>
    {
        public void Configure(EntityTypeBuilder<Salle> builder)
        {
            builder.ToTable("Salle", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(s => s.Id)
                .IsRequired()
                .UseIdentityColumn(1000,1);
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");
        }
    }
}
