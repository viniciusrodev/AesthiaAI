using AesthiaAI.Domain.Enums;
using AesthiaAI.Domain.Exceptions;
using AesthiaAI.Domain.ValueObjects;


namespace AesthiaAI.Domain.Entities
{
    public class Esteticista : Usuario
    {
        public Esteticista(string nome, string sobrenome, Cpf cpf, Email email, Telefone telefone, Endereco endereco) : base(nome, sobrenome, cpf, email, telefone, endereco)
        {
            Acesso = Autorizacao.Administrador;
        }


        public Autorizacao Acesso { get; private set; }


        public void AlterarAcesso(Autorizacao acesso)
        {
            if (!Enum.IsDefined(typeof(Autorizacao), acesso))
            {
                throw new DomainExceptions(
                    "Acesso inválido."
                );
            }

            Acesso = acesso;
        }
    }
}
