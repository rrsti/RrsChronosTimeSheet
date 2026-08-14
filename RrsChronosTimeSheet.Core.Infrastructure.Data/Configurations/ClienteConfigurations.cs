using RrsChronosTimeSheet.Core.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class ClienteConfigurations : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TbCliente");

            builder.HasKey(e => e.Id);
            builder.Property(c => c.RazaoSocial)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.NomeFantasia)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(c => c.InscricaoEstadual)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.InscricaoMunicipal)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Cnpj)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Logradouro)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Numero)
                .IsRequired(false);

            builder.Property(c => c.Complemento)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(c => c.Bairro)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(c => c.Cidade)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(x => x.UnidadeFederativa)
                .WithMany()
                .HasForeignKey("UnidadeFederativaId")
                .IsRequired()
                .HasConstraintName("FK_UnidadeFederativaToCliente");

            builder.HasMany(c => c.Telefones)
                .WithOne(t => t.Cliente)
                .HasForeignKey(t => t.ClienteId)
                .HasConstraintName("FK_TelefoneClienteToCliente")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Emails)
                .WithOne(t => t.Cliente)
                .HasForeignKey(t => t.ClienteId)
                .HasConstraintName("FK_EmailClienteToCliente")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
