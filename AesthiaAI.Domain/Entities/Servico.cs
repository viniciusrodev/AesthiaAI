using AesthiaAI.Domain.Exceptions;
using AesthiaAI.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace AesthiaAI.Domain.Entities
{
    public class Servico
    {
        public Servico(string nome, decimal valor, TimeSpan duracao)
        {

            Id = Guid.NewGuid();

            AlterarNome(nome);
            AlterarValor(valor);
            AlterarDuracao(duracao);
        
        }
        
        public Guid Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;

        public decimal Valor { get; private set; }

        public TimeSpan Duracao { get; private set; }

   

        public void AlterarNome(string nome)
        {
            ValidarNome(nome);
            Nome = nome;
        }

        public void AlterarValor(decimal valor)
        {
            ValidarValor(valor);
            Valor = valor;
        }

        public void AlterarDuracao(TimeSpan duracao)
        {
            ValidarHora(duracao);
            Duracao = duracao;
        }

        private void ValidarNome(string nome)
        {
            Guard.AgainsNullOrWhiteSpace(nome, "Nome do Serviço é Obrigatório");

            if(nome.Length < 3)
            {

                throw new DomainExceptions("Servico deverá conter mais de 3 caracteres");

            }

        }

        private void ValidarValor(decimal valor)
        {
            if (valor <= 0)
            {
                throw new DomainExceptions(
                    "Valor deve ser maior que zero."
                );
            }
        }

        private void ValidarHora(TimeSpan tempo)
        {
            if (tempo <= TimeSpan.Zero)
            {
                throw new DomainExceptions(
                    "A duração do serviço deve ser maior que zero."
                );
            }
        }
    }

}
