using RrsChronosTimeSheet.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class TelefoneFornecedorConfigurations : IEntityTypeConfiguration<TelefoneFornecedor>
    {
        public void Configure(EntityTypeBuilder<TelefoneFornecedor> builder)
        {
            builder.ToTable("TbTelefoneFornecedor");

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

            builder.HasOne(t => t.Fornecedor)
                .WithMany(f => f.Telefones)
                .HasForeignKey(t => t.FornecedorId)
                .IsRequired()
                .HasConstraintName("FK_FornecedorToTelefoneFornecedor");

            builder.HasOne(t => t.TipoTelefone)
                .WithMany()
                .HasForeignKey(t => t.TipoTelefoneId)
                .IsRequired(false)
                .HasConstraintName("FK_TipoTelefoneToTelefoneFornecedor");
        }
    }
}
