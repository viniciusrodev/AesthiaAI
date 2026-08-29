using AesthiaAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AesthiaAI.Infrastructure.Configurations
{
    public class AgendaServicoConfiguration : IEntityTypeConfiguration<AgendaServico>
    {
        public void Configure(EntityTypeBuilder<AgendaServico> builder)
        {
            builder.ToTable("AgendaServicos");
            builder.HasKey(i => i.Id);


            builder.HasOne(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Esteticista)
                .WithMany()
                .HasForeignKey(e => e.EsteticistaId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Servico)
                .WithMany()
                .HasForeignKey(s => s.ServicoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


            builder.Property(d => d.DataAgendamento)
                .IsRequired();

            builder.Property(h => h.HoraInicial)
                .IsRequired();

            builder.Property(h => h.HoraTermino)
                .IsRequired();

            builder.Property(o => o.Observacao)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(s => s.Status)
                .IsRequired()
                .HasConversion<string>();
        }
    }
}
