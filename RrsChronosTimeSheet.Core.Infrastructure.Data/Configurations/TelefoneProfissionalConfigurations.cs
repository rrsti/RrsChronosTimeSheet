using RrsChronosTimeSheet.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class TelefoneProfissionalConfigurations : IEntityTypeConfiguration<TelefoneProfissional>
    {
        public void Configure(EntityTypeBuilder<TelefoneProfissional> builder)
        {
            builder.ToTable("TbTelefoneProfissional");

            builder.HasKey(e => e.Id);

            builder.Property(t => t.NumeroTelefone)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(t => t.NomeContato)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.WhatsApp)
                .IsRequired();

            builder.Property(t => t.Telegram)
                .IsRequired();

            builder.Property(t => t.IsPrincipal)
                .IsRequired();

            builder.HasOne(t => t.Profissional)
                .WithMany(p => p.Telefones)
                .HasForeignKey(t => t.ProfissionalId)
                .IsRequired()
                .HasConstraintName("FK_ProfissionalToTelefoneProfissional");

            builder.HasOne(t => t.TipoTelefone)
                .WithMany()
                .HasForeignKey(t => t.TipoTelefoneId)
                .IsRequired(false)
                .HasConstraintName("FK_TipoTelefoneToTelefoneProfissional");
        }
    }
}
