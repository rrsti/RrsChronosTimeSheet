using RrsChronosTimeSheet.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class EmailProfissionalConfigurations : IEntityTypeConfiguration<EmailProfissional>
    {
        public void Configure(EntityTypeBuilder<EmailProfissional> builder)
        {
            builder.ToTable("TbEmailProfissional");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.ContatoEmail)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(e => e.Profissional)
                .WithMany(p => p.Emails)
                .HasForeignKey(e => e.ProfissionalId)
                .IsRequired()
                .HasConstraintName("FK_ProfissionalToEmailProfissional");
        }
    }
}
