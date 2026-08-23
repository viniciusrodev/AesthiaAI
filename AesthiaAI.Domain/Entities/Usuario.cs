using AesthiaAI.Domain.Exceptions;
using AesthiaAI.Domain.Shared;
using AesthiaAI.Domain.ValueObjects;


namespace AesthiaAI.Domain.Entities
{
    public class Usuario
    {
        public Usuario(string nome, string sobrenome, Cpf cpf, Email email, Telefone telefone, Endereco endereco)
        {
            Id = Guid.NewGuid();

            AlterarNome(nome);
            AlterarSobrenome(sobrenome);
            AlterarCpf(cpf);
            AlterarEmail(email);
            AlterarTelefone(telefone);
            AlterarEndereco(endereco);

            DataCadastro = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public Cpf Cpf { get; private set; }

        public Email Email { get; private set; }

        public Telefone Telefone { get; private set; }

        public Endereco Endereco { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public DateTime DataNascimento { get; private set; }



        // ============================================================
        // ALTERAÇÕES
        // ============================================================

        public void AlterarNome(string nome)
        {
            ValidarNome(nome);

            Nome = nome.Trim();
        }

        public void AlterarSobrenome(string sobrenome)
        {
            ValidarSobrenome(sobrenome);

            Sobrenome = sobrenome.Trim();
        }

        public void AlterarCpf(Cpf cpf)
        {
            Guard.AgainstNull(cpf, "O CPF do usuário é obrigatório.");

            Cpf = cpf;
        }

        public void AlterarEmail(Email email)
        {
            Guard.AgainstNull(email, "O e-mail do usuário é obrigatório.");

            Email = email;
        }

        public void AlterarTelefone(Telefone telefone)
        {
            Guard.AgainstNull(telefone, "O telefone do usuário é obrigatório.");

            Telefone = telefone;
        }

        public void AlterarEndereco(Endereco endereco)
        {
            Guard.AgainstNull(endereco, "O endereço do usuário é obrigatório.");

            Endereco = endereco;
        }

        public void AlterarDataNascimento(DateTime dataNascimento)
        {
            ValidarDataNascimento(dataNascimento);

            DataNascimento = dataNascimento.Date;
        }


        // ============================================================
        // VALIDAÇÕES
        // ============================================================



        private static void ValidarNome(string nome)
        {
            Guard.AgainsNullOrWhiteSpace(nome, "O nome do usuário é obrigatório.");


            nome = nome.Trim();

            if (nome.Length < 2)
            {
                throw new DomainExceptions(
                    "O nome deve possuir pelo menos 2 caracteres.");

            }

            if (nome.Length > 100)
            {
                throw new DomainExceptions(
                    "O nome não pode possuir mais de 100 caracteres.");
            }
        }

        private static void ValidarSobrenome(string sobrenome)
        {
            if (string.IsNullOrWhiteSpace(sobrenome))
            {
                Guard.AgainsNullOrWhiteSpace(sobrenome, "O sobrenome do usuário é obrigatório.");


                sobrenome = sobrenome.Trim();

                if (sobrenome.Length < 2)
                {
                    throw new DomainExceptions(
                        "O sobrenome deve possuir pelo menos 2 caracteres.");

                }

                if (sobrenome.Length > 100)
                {
                    throw new DomainExceptions(
                        "O sobrenome não pode possuir mais de 100 caracteres.");

                }
            }
        }


        private static void ValidarDataCadastro(DateTime dataCadastro)
        {
            if (dataCadastro == default)
            {
                throw new DomainExceptions(
                    "A data de cadastro é obrigatória.");

            }

            if (dataCadastro > DateTime.Now)
            {
                throw new DomainExceptions(
                    "A data de cadastro não pode estar no futuro.");

            }
        }

        private static void ValidarDataNascimento(DateTime dataNascimento)
        {
            if (dataNascimento == default)
            {
                throw new DomainExceptions(
                    "A data de nascimento é obrigatória.");
            }

            if (dataNascimento.Date > DateTime.Today)
            {
                throw new DomainExceptions(
                    "A data de nascimento não pode estar no futuro.");
            }

            DateTime dataMinima = DateTime.Today.AddYears(-150);

            if (dataNascimento.Date < dataMinima)
            {
                throw new DomainExceptions(
                    "A data de nascimento informada é inválida.");
            }
        }
    }
}