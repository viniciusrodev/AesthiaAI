using AesthiaAI.Domain.Exceptions;

namespace AesthiaAI.Domain.ValueObjects
{
    public class Endereco
    {

    protected Endereco() { }
        public Endereco(string cep, string estado, string cidade, string bairro, string rua, string numero, string? complemento)
        {
            ValidarEndereco(cep, estado, cidade, bairro, rua, numero);


            Cep = cep;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
        }

        public string Cep { get; }
        public string Estado { get; }
        public string Cidade { get; }
        public string Bairro { get; }
        public string Rua { get; }
        public string Numero { get; }
        public string? Complemento { get; }



        private void ValidarEndereco(string cep, string estado, string cidade, string bairro, string rua, string numero)
        {

            ValidarCep(cep);
            ValidarEstado(estado);
            ValidarCidade(cidade);
            ValidarBairro(bairro);
            ValidarRua(rua);
            ValidarNumero(numero);
           
        }

        private void ValidarCep(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
                throw new DomainExceptions("CEP é obrigatório.");

            cep = cep.Replace("-", "").Replace(".", "");

            if (cep.Length != 8 || !cep.All(char.IsDigit))
                throw new DomainExceptions("CEP inválido. Informe 8 números.");
        }

        private void ValidarEstado(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado))
                throw new DomainExceptions("Estado é obrigatório.");

            if (estado.Length != 2)
                throw new DomainExceptions(
                    $"Estado inválido. Valor recebido: '{estado}'. Tamanho: {estado.Length}"
                );

            if (!estado.All(char.IsLetter))
                throw new DomainExceptions("Estado deve conter apenas letras.");
        }

        private void ValidarCidade(string cidade)
        {
            if (string.IsNullOrWhiteSpace(cidade))
                throw new DomainExceptions("Cidade é obrigatória.");

            if (cidade.Length < 2)
                throw new DomainExceptions("Cidade deve possuir pelo menos 2 caracteres.");
        }

        private void ValidarBairro(string bairro)
        {
            if (string.IsNullOrWhiteSpace(bairro))
                throw new DomainExceptions("Bairro é obrigatório.");

            if (bairro.Length < 2)
                throw new DomainExceptions("Bairro deve possuir pelo menos 2 caracteres.");
        }

        private void ValidarRua(string rua)
        {
            if (string.IsNullOrWhiteSpace(rua))
                throw new DomainExceptions("Rua é obrigatória.");

            if (rua.Length < 2)
                throw new DomainExceptions("Rua deve possuir pelo menos 2 caracteres.");
        }

        private void ValidarNumero(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new DomainExceptions("Número é obrigatório.");

            if (!numero.All(char.IsDigit))
                throw new DomainExceptions("Número do endereço deve conter apenas números.");
        }
    }




}

