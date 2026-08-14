using RrsChronosTimeSheet.Core.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class TelefoneClienteConfigurations : IEntityTypeConfiguration<TelefoneCliente>
    {
        public void Configure(EntityTypeBuilder<TelefoneCliente> builder)
        {
            builder.ToTable("TbTelefoneCliente");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.NumeroTelefone)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.NomeContato)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.WhatsApp)
                .IsRequired();

            builder.Property(e => e.Telegram)
                .IsRequired();

            builder.Property(e => e.IsPrincipal)
                .IsRequired();

            builder.HasOne(x => x.TipoTelefone)
                .WithMany()
                .HasForeignKey(t => t.TipoTelefoneId)
                .IsRequired(false)
                .HasConstraintName("FK_TipoTelefoneToTelefoneCliente");

            builder.HasOne(e => e.Cliente)
                .WithMany(c => c.Telefones)
                .HasForeignKey(e => e.ClienteId)
                .IsRequired()
                .HasConstraintName("FK_ClienteToTelefoneCliente");

        }
    }
}
