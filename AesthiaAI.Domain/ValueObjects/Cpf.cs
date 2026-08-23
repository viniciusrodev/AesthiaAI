using AesthiaAI.Domain.Exceptions;
using AesthiaAI.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace AesthiaAI.Domain.ValueObjects
{
    public class Cpf
    {
        public Cpf(string numero)
        {
            Validar(numero);
            Numero = numero;
        }

        public string Numero { get; }


        


        private void Validar(string numero)
        {
            Guard.AgainsNullOrWhiteSpace(numero, "CPF deve ser preenchido!");

            if(numero.Length != 11)
            {

                throw new DomainExceptions("CPF Deve conter 11 Números");
            }

            if (!numero.All(char.IsDigit))
            {

                throw new DomainExceptions("CPF deve conter apenas Numeros.");            }
            
        }
    }
}
