

using AesthiaAI.Domain.Exceptions;
using AesthiaAI.Domain.Shared;
using System.Net.Mail;

namespace AesthiaAI.Domain.ValueObjects
{
    public class Email
    {
        public Email(string endereco)
        {
            Validar(endereco);
            Endereco = endereco;
        }

        public string Endereco { get; }



        private void Validar(string endereco)
        {
            Guard.AgainsNullOrWhiteSpace(
                endereco,
                "Endereço é obrigatório!"
            );

            endereco = endereco.Trim();

            if (endereco.Length > 254)
                throw new DomainExceptions(
                    "O e-mail não pode possuir mais de 254 caracteres."
                );

            try
            {
                var email = new MailAddress(endereco);

                if (email.Address != endereco)
                    throw new DomainExceptions(
                        "O formato do e-mail é inválido."
                    );
            }
            catch (FormatException)
            {
                throw new DomainExceptions(
                    "O formato do e-mail é inválido."
                );
            }
        }
    }
}