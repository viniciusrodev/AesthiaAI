using System;
using System.Collections.Generic;
using System.Text;

namespace AesthiaAI.Domain.Exceptions
{
   public class DomainExceptions : Exception
    {

        public DomainExceptions(string Mensagem) : base(Mensagem) { }
    }
}
