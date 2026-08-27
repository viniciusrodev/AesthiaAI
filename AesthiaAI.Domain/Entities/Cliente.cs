using AesthiaAI.Domain.Enums;
using AesthiaAI.Domain.Exceptions;
using AesthiaAI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AesthiaAI.Domain.Entities
{
    public class Cliente : Usuario
    {
        public Cliente(string nome, string sobrenome, Cpf cpf, Email email, Telefone telefone, Endereco endereco, Autorizacao acesso) : base(nome, sobrenome, cpf, email, telefone, endereco)
        {
            Acesso = Autorizacao.Cliente;
        }


        public Autorizacao Acesso { get; private set; }


        public void AlterarAcesso(Autorizacao acesso)
        {

            if (acesso != Autorizacao.Cliente)
            {
                throw new DomainExceptions(
                    "Cliente não pode possuir outro nível de acesso."
                );
            }
      
            Acesso = acesso;
        }
    }
}
