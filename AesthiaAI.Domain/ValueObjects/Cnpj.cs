using AesthiaAI.Domain.Exceptions;
using AesthiaAI.Domain.Shared;

namespace AesthiaAI.Domain.ValueObjects
{
    public class Cnpj
    {
        public Cnpj(string numero)
        {
            Numero = numero;
        }

        public string Numero { get; }

        private void Validar(string numero)
        {
            Guard.AgainsNullOrWhiteSpace( numero,"CNPJ é obrigatório!");

            string cnpj = Normalizar(numero);

            if (cnpj.Length != 14)
                throw new DomainExceptions("O CNPJ deve possuir 14 números.");

            if (!cnpj.All(char.IsDigit))
                throw new DomainExceptions("O CNPJ deve conter apenas números.");

            if (TodosDigitosIguais(cnpj))
                throw new DomainExceptions("O CNPJ informado é inválido.");

            if (!ValidarDigitosVerificadores(cnpj))
                throw new DomainExceptions("O CNPJ informado é inválido.");
        }

        private static string Normalizar(string numero)
        {
            return numero
                .Replace(".", "")
                .Replace("/", "")
                .Replace("-", "")
                .Trim();
        }

        private static bool TodosDigitosIguais(string cnpj)
        {
            return cnpj.All(c => c == cnpj[0]);
        }

        private static bool ValidarDigitosVerificadores(string cnpj)
        {
            int primeiroDigito = CalcularDigito(
                cnpj.Substring(0, 12),
                new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 }
            );

            if (primeiroDigito != int.Parse(cnpj[12].ToString()))
                return false;

            int segundoDigito = CalcularDigito(
                cnpj.Substring(0, 12) + primeiroDigito,
                new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 }
            );

            return segundoDigito == int.Parse(cnpj[13].ToString());
        }

        private static int CalcularDigito(
            string numero,
            int[] pesos)
        {
            int soma = 0;

            for (int i = 0; i < pesos.Length; i++)
            {
                soma += int.Parse(numero[i].ToString()) * pesos[i];
            }

            int resto = soma % 11;

            return resto < 2 ? 0 : 11 - resto;
        }
    }
}
  