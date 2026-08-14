using RrsChronosTimeSheet.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class EmailFornecedorConfigurations : IEntityTypeConfiguration<EmailFornecedor>
    {
        public void Configure(EntityTypeBuilder<EmailFornecedor> builder)
        {
            builder.ToTable("TbEmailFornecedor");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.ContatoEmail)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(e => e.Fornecedor)
                .WithMany(f => f.Emails)
                .HasForeignKey(e => e.FornecedorId)
                .IsRequired()
                .HasConstraintName("FK_FornecedorToEmailFornecedor");
        }
    }
}
