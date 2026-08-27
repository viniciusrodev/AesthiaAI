using AesthiaAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AesthiaAI.Infrastructure.Configurations
{
    public class UsuarioConfiguration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);
                
        }
    }
}
