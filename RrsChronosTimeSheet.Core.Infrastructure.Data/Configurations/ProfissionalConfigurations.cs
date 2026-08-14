using RrsChronosTimeSheet.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class ProfissionalConfigurations : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.ToTable("TbProfissional");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.Rg)
                .IsRequired(false)
                .HasMaxLength(20);

            builder.Property(p => p.DataNascimento)
                .IsRequired();

            builder.Property(p => p.Nacionalidade)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(p => p.Cep)
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(p => p.Logradouro)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Numero)
                .IsRequired(false);

            builder.Property(p => p.Complemento)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(p => p.Cidade)
                .IsRequired(false)
                .HasMaxLength(150);

            builder.Property(p => p.Bairro)
                .IsRequired(false)
                .HasMaxLength(150);

            builder.Property(p => p.ProfissionalTerceirizado)
                .IsRequired();

            builder.Property(p => p.Foto)
                .IsRequired(false);

            builder.HasOne(p => p.UfNaturalidade)
                .WithMany()
                .HasForeignKey("UfNaturalidadeId")
                .IsRequired(false)
                .HasConstraintName("FK_UnidadeFederativaToUfNaturalidade");

            builder.HasOne(p => p.UnidadeFederativa)
                .WithMany()
                .HasForeignKey("UnidadeFederativaId")
                .IsRequired(false)
                .HasConstraintName("FK_UnidadeFederativaToResidencia");

            builder.HasOne(p => p.Funcao)
                .WithMany()
                .HasForeignKey("FuncaoId")
                .IsRequired(false)
                .HasConstraintName("FK_FuncaoToProfissional");

            builder.HasOne(p => p.Fornecedor)
                .WithMany()
                .HasForeignKey("FornecedorId")
                .IsRequired(false)
                .HasConstraintName("FK_FornecedorToProfissional");

            builder.HasMany(p => p.Emails)
                .WithOne(e => e.Profissional)
                .HasForeignKey(e => e.ProfissionalId)
                .HasConstraintName("FK_EmailProfissionalToProfissional")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Telefones)
                .WithOne(t => t.Profissional)
                .HasForeignKey(t => t.ProfissionalId)
                .HasConstraintName("FK_TelefoneProfissionalToProfissional")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
