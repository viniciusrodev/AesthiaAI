using AesthiaAI.Domain.Exceptions;
using AesthiaAI.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace AesthiaAI.Domain.ValueObjects
{
    public class Telefone
    {
        protected Telefone() { }
        public Telefone(string numero)
        {
            Validar(numero);
            Numero = numero;
        }

        public string Numero { get; }


        private void Validar(string numero)
        {

            Guard.AgainsNullOrWhiteSpace(numero, "Telefone é Obrigatório!");

            if(numero.Length != 11)
            {

                throw new DomainExceptions("Telefone deve conter 11 Números!");
            }

            if (!numero.All(char.IsDigit))
            {

                throw new DomainExceptions("Telefone deve conter somente Números!");
            }
        }
    }
}
