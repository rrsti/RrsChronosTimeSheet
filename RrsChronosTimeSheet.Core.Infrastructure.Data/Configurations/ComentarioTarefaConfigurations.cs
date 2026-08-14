using RrsChronosTimeSheet.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class ComentarioTarefaConfigurations : IEntityTypeConfiguration<ComentarioTarefa>
    {
        public void Configure(EntityTypeBuilder<ComentarioTarefa> builder)
        {
            builder.ToTable("TbComentarioTarefa");

            builder.HasKey(e => e.Id);

            builder.Property(c => c.Comentario)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasOne(c => c.Tarefa)
                .WithMany()
                .HasForeignKey("TarefaId")
                .IsRequired()
                .HasConstraintName("FK_TarefasToComentarioTarefa")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Profissional)
                .WithMany()
                .HasForeignKey("ProfissionalId")
                .IsRequired()
                .HasConstraintName("FK_ProfissionalToComentarioTarefa")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
