using AesthiaAI.Domain.Enums;
using AesthiaAI.Domain.ValueObjects;


namespace AesthiaAI.Domain.Entities
{
    public class Esteticista : Usuario
    {
        public Esteticista(string nome, string sobrenome, Cpf cpf, Email email, Telefone telefone, Endereco endereco, Autorizacao acesso) : base(nome, sobrenome, cpf, email, telefone, endereco)
        {
            acesso = Autorizacao.Administrador;
        }


        public Autorizacao Acesso { get; private set; }


        public void AlterarAcesso(Autorizacao acesso)
        {
            Acesso = Acesso;
        }
    }
}
