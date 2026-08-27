using AesthiaAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;    
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AesthiaAI.Infrastructure.Configurations
{
    public class ServicoConfiguration : IEntityTypeConfiguration<Servico>
    {

        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("Servicos");

            builder.HasKey(s => s.Id);


            builder.Property(s => s.Nome)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(s => s.Valor)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(s => s.Duracao)
                .IsRequired();
                
        }
        
    }
}
