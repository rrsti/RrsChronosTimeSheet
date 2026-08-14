using RrsChronosTimeSheet.Core.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class EmailClienteConfigurations: IEntityTypeConfiguration<EmailCliente>
    {
        public void Configure(EntityTypeBuilder<EmailCliente> builder)
        {
            builder.ToTable("TbEmailCliente");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ContatoEmail)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(e => e.Cliente)
                .WithMany(c => c.Emails)
                .HasConstraintName("FK_EmailClienteToCliente")
                .HasForeignKey(e => e.ClienteId);
        }
    }
}
