using RrsChronosTimeSheet.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class HorasProfissionalConfigurations : IEntityTypeConfiguration<HorasProfissional>
    {
        public void Configure(EntityTypeBuilder<HorasProfissional> builder)
        {
            builder.ToTable("TbHorasProfissional");

            builder.HasKey(e => e.Id);

            builder.Property(h => h.Data)
                .IsRequired();

            builder.Property(h => h.HoraInicio)
                .IsRequired();

            builder.Property(h => h.HoraFim)
                .IsRequired();

            builder.HasOne(h => h.Tarefa)
                .WithMany()
                .HasForeignKey("TarefaId")
                .IsRequired()
                .HasConstraintName("FK_TarefasToHorasProfissional");

            builder.HasOne(h => h.Profissional)
                .WithMany()
                .HasForeignKey("ProfissionalId")
                .IsRequired()
                .HasConstraintName("FK_ProfissionalToHorasProfissional");
        }
    }
}
