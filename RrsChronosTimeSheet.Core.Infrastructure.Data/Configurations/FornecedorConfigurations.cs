using RrsChronosTimeSheet.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class FornecedorConfigurations : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("TbFornecedor");

            builder.HasKey(e => e.Id);

            builder.Property(f => f.RazaoSocial)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(f => f.NomeFantasia)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(f => f.Cnpj)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(f => f.InscricaoEstadual)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(f => f.InscricaoMunicipal)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(f => f.Logradouro)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(f => f.Numero)
                .IsRequired(false);

            builder.Property(f => f.Complemento)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(f => f.Bairro)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(f => f.Cidade)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.Cep)
                .IsRequired()
                .HasMaxLength(8);

            builder.HasOne(f => f.UnidadeFederativa)
                .WithMany()
                .HasForeignKey("UnidadeFederativaId")
                .IsRequired(false)
                .HasConstraintName("FK_UnidadeFederativaToFornecedor");

            builder.HasMany(f => f.Emails)
                .WithOne(e => e.Fornecedor)
                .HasForeignKey(e => e.FornecedorId)
                .HasConstraintName("FK_EmailFornecedorToFornecedor")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(f => f.Telefones)
                .WithOne(t => t.Fornecedor)
                .HasForeignKey(t => t.FornecedorId)
                .HasConstraintName("FK_TelefoneFornecedorToFornecedor")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
