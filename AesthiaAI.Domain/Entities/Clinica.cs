using AesthiaAI.Domain.Enums;
using AesthiaAI.Domain.Exceptions;
using AesthiaAI.Domain.Shared;
using AesthiaAI.Domain.ValueObjects;

namespace AesthiaAI.Domain.Entities
{
    public class Clinica
    {
        public Clinica(string nomeFantasia, Cnpj cnpj, Telefone telefone, Email email, Status status)
        {
            Id = Guid.NewGuid();

            AlterarCpnj(cnpj);
            AlterarFantasaia(nomeFantasia);
            AlterarEmail(email);
            AlterarTelefone(telefone);
            AlterarStatus(status);

            DataCadastro = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }

        public string NomeFantasia { get; private set; } = string.Empty;

        public Cnpj Cnpj { get; private set; } = null!;

        public Telefone Telefone { get; private set; } = null!;

        public Email Email { get; private set; } = null!;

        public DateTime DataCadastro { get; private set; }

        public Status Status { get; private set; }

        // =========================
        // Métodos de alteração
        // =========================
        public void AlterarFantasaia(string nomeFantasia)
        {
            ValidarFantasia(nomeFantasia);
            NomeFantasia = nomeFantasia;

        }
        public void AlterarCpnj(Cnpj cnpj)
        {
            if (cnpj == null)
                throw new DomainExceptions("CNPJ é obrigatório.");
            Cnpj = cnpj;
        }

        public void AlterarTelefone(Telefone telefone)
        {
            if (telefone == null)
                throw new DomainExceptions("Telefone é obrigatório.");
            Telefone = telefone;
        }

        public void AlterarEmail(Email email)
        {
            if (email == null)
                throw new DomainExceptions("E-mail é obrigatório.");
            Email = email;
        }

        public void AlterarStatus(Status status)
        {
            ValidarStatus(status);
            Status = status;
        }
        // =========================
        // Validações
        // =========================

        private void ValidarFantasia(string nomeFantasia)
        {
            Guard.AgainsNullOrWhiteSpace(nomeFantasia, "Nome fantasia é obrigatório.");

            nomeFantasia = nomeFantasia.Trim();

            if (nomeFantasia.Length < 2)
                throw new DomainExceptions(
                    "Nome fantasia deve possuir pelo menos 2 caracteres."
                );

            if (nomeFantasia.Length > 150)
                throw new DomainExceptions(
                    "Nome fantasia não pode possuir mais de 150 caracteres."
                );
        }

        private void ValidarStatus(Status status)
        {
            if (!Enum.IsDefined(typeof(Status), status))
                throw new DomainExceptions(
                    "Status informado é inválido."
                );
        }
    }
}
