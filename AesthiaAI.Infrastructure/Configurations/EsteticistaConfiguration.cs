using AesthiaAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace AesthiaAI.Infrastructure.Configurations
{
    public class EsteticistaConfiguration : IEntityTypeConfiguration<Esteticista>
    {
        public void Configure(EntityTypeBuilder<Esteticista> builder)
        {

            builder.Property(a => a.Acesso)
                .IsRequired()
                .HasConversion<string>();

        }
    }
}
