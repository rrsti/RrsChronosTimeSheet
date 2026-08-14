using RrsChronosTimeSheet.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class ProjetoConfigurations : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("TbProjeto");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(p => p.DataInicio)
                .IsRequired();

            builder.Property(p => p.DataFim)
                .IsRequired();

            builder.Property(p => p.Orçamento)
                .IsRequired();

            builder.Property(p => p.QtdHorasEstimadas)
                .IsRequired();

            builder.HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey("ClienteId")
                .IsRequired()
                .HasConstraintName("FK_ClienteToProjeto");

            builder.HasOne(p => p.Status)
                .WithMany()
                .HasForeignKey("StatusId")
                .IsRequired()
                .HasConstraintName("FK_StatusProjetoToProjeto");

            builder.HasOne(p => p.Tipo)
                .WithMany()
                .HasForeignKey("TipoId")
                .IsRequired()
                .HasConstraintName("FK_TipoProjetoToProjeto");

            builder.HasOne(p => p.Responsavel)
                .WithMany()
                .HasForeignKey("ResponsavelId")
                .IsRequired()
                .HasConstraintName("FK_ProfissionalToProjeto");
        }
    }
}
