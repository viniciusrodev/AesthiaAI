using AesthiaAI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AesthiaAI.Domain.Shared
{
    public class Guard
    {


        public static void AgainstNull(object objeto, string mensagem)
        {

            if(objeto == null)
            {
                throw new DomainExceptions(mensagem);
            }
        }


        public static void AgainsNullOrWhiteSpace(string texto, string mensagem)
        {

            if (string.IsNullOrWhiteSpace(texto))
            {
                throw new DomainExceptions(mensagem);
            }
        }
    }
}
