using RrsChronosTimeSheet.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class TarefasConfigurations : IEntityTypeConfiguration<Tarefas>
    {
        public void Configure(EntityTypeBuilder<Tarefas> builder)
        {
            builder.ToTable("TbTarefas");

            builder.HasKey(e => e.Id);

            builder.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(t => t.DataInicio)
                .IsRequired();

            builder.Property(t => t.DataFim)
                .IsRequired(false);

            builder.Property(t => t.QtdHorasEstimadas)
                .IsRequired();

            builder.HasOne(t => t.Responsavel)
                .WithMany()
                .HasForeignKey("ResponsavelId")
                .IsRequired(false)
                .HasConstraintName("FK_ProfissionalToTarefas");

            builder.HasOne(t => t.Status)
                .WithMany()
                .HasForeignKey("StatusId")
                .IsRequired(false)
                .HasConstraintName("FK_StatusTarefaToTarefas");

            builder.HasOne(t => t.Projeto)
                .WithMany()
                .HasForeignKey("ProjetoId")
                .IsRequired()
                .HasConstraintName("FK_ProjetoToTarefas");
        }
    }
}
