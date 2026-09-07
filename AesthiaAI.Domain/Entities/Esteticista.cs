using AesthiaAI.Domain.Enums;
using AesthiaAI.Domain.Exceptions;
using AesthiaAI.Domain.ValueObjects;


namespace AesthiaAI.Domain.Entities
{
    public class Esteticista : Usuario
    {

        protected Esteticista() { }
        public Esteticista(string nome, string sobrenome, Cpf cpf, Email email, Telefone telefone, Endereco endereco) : base(nome, sobrenome, cpf, email, telefone, endereco, Autorizacao.Administrador)
        {
           
        }


    }
}