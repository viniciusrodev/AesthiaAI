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

            builder.HasDiscriminator<string>("TipoUsuario")
              .HasValue<Cliente>("Cliente")
              .HasValue<Esteticista>("Esteticista");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Sobrenome)
                .IsRequired()
                .HasMaxLength(100);


            builder.OwnsOne(u => u.Cpf, cpf =>
            {
                cpf.Property(c => c.Numero)
                .HasColumnName("Cpf")
                .IsRequired()
                .HasMaxLength(11);
            });

            builder.OwnsOne(u => u.Email, email =>
            {
                 email.Property(e => e.Endereco)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(100);

            });
              

            builder.OwnsOne(u => u.Telefone, telefone =>
            {
                telefone.Property(t => t.Numero)
                .HasColumnName("Telefone")
                .IsRequired()
                .HasMaxLength(11);
            });


            builder.OwnsOne(u => u.Endereco, endereco =>
            {

                endereco.Property(c => c.Cep)
                .HasColumnName("Cep")
                .IsRequired()
                .HasMaxLength(9);

                endereco.Property(e => e.Estado)
                .HasColumnName("UF")
                .IsRequired()
                .HasMaxLength(2);

                endereco.Property(c => c.Cidade)
                .HasColumnName("Cidade")
                .IsRequired()
                .HasMaxLength(50);

                endereco.Property(b => b.Bairro)
                .HasColumnName("Bairro")
                .IsRequired()
                .HasMaxLength(50);

                endereco.Property(r => r.Rua)
                .HasColumnName("Rua")
                .IsRequired()
                .HasMaxLength(50);

                endereco.Property(n => n.Numero)
                .HasColumnName("Numero")
                .IsRequired()
                .HasMaxLength(10);

                endereco.Property(c => c.Complemento)
                .HasColumnName("Complemento")
                .HasMaxLength(50);

                builder.Property(u => u.DataCadastro)
                .HasColumnName("DataCadastro")
                .IsRequired();

                builder.Property(u => u.DataNascimento)
                    .IsRequired(false);
            });


          
        }
    }
}
