using AesthiaAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AesthiaAI.Infrastructure.Configurations
{
    public class ClinicaConfiguration : IEntityTypeConfiguration<Clinica>
    {
        public void Configure(EntityTypeBuilder<Clinica> builder)
        {
            builder.ToTable("Clinicas");


        builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeFantasia)
                .IsRequired()
                .HasMaxLength(150);

            builder.OwnsOne(c => c.Cnpj, cnpj =>
            {
                cnpj.Property(c => c.Numero)
                    .HasColumnName("Cnpj")
                    .IsRequired()
                    .HasMaxLength(14);
            });

            builder.OwnsOne(c => c.Telefone, telefone =>
            {
                telefone.Property(t => t.Numero)
                    .HasColumnName("Telefone")
                    .IsRequired()
                    .HasMaxLength(11);
            });

            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(e => e.Endereco)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(100);
            });

            builder.Property(c => c.DataCadastro)
                .IsRequired();

            builder.Property(c => c.Status)
                .IsRequired()
                .HasConversion<string>();
        }
    }

}
