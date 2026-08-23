using AesthiaAI.Domain.Exceptions;
using AesthiaAI.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace AesthiaAI.Domain.Entities
{
    public class Servico
    {
        public Servico(string nome, decimal valor, TimeSpan tempo, Cliente cliente, Esteticista esteticista)
        {
            Nome = nome;
            Valor = valor;
            Tempo = tempo;
            Cliente = cliente;
            Esteticista = esteticista;
        }

        public string Nome { get; private set; }

        public decimal Valor { get; private set; }

        public TimeSpan Tempo { get; private set; }

        public Cliente Cliente { get; }

        public Esteticista Esteticista { get; }



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

        public void AlterarHora(TimeSpan tempo)
        {
            ValidarHora(tempo);
            Tempo = Tempo;
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

            Guard.AgainstNull(valor, "Valor não pode ser Nulo");

            if(valor <= 0)
            {
                throw new DomainExceptions("Valor não pode ser 0 ou menor que 0");
            }
        }

        private void ValidarHora(TimeSpan tempo)
        {

            Guard.AgainstNull(tempo, "Tempo de serviço não pode zer nulo");

            if (tempo < TimeSpan.Zero || tempo > TimeSpan.MaxValue)
            {

                throw new DomainExceptions("A Hora deve ser entre 00:00hrs e 23:59hrs.");

            }
        }
    }

}
