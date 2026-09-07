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

        protected Cliente() { }
        public Cliente(string nome, string sobrenome, Cpf cpf, Email email, Telefone telefone, Endereco endereco) : base(nome, sobrenome, cpf, email, telefone, endereco, Autorizacao.Cliente)
        {

        }

    }
}
       