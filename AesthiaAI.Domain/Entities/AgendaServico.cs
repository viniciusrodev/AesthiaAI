    using AesthiaAI.Domain.Enums;
    using AesthiaAI.Domain.Exceptions;
    using AesthiaAI.Domain.Shared;
    using System.Runtime.CompilerServices;

namespace AesthiaAI.Domain.Entities
{
    public class AgendaServico
    {
        public AgendaServico(Esteticista esteticista, Cliente cliente, Servico servico, DateTime dataAgendamento, TimeSpan horaInicial, TimeSpan horaTermino, string observacao)
        {

            Id = Guid.NewGuid();


            Esteticista = esteticista;
            Cliente = cliente;
            Servico = servico;

            EsteticistaId = esteticista.Id;
            ClienteId = cliente.Id;
            ServicoId = servico.Id;

            AlterarData(dataAgendamento);
            AlterarHoraInicial(horaInicial);
            AlterarHoraTermino(horaTermino);
            AlterarObservacao(observacao);
            Status = StatusAgenda.Agendado;


        }


        public Guid Id { get; private set; }

        public Esteticista Esteticista { get; private set; }

        public Cliente Cliente { get; private set; }

        public Servico Servico { get; private set; }

        public Guid ClienteId { get; private set; }

        public Guid EsteticistaId { get; private set; }

        public Guid ServicoId { get; private set; }

        public DateTime DataAgendamento { get; private set; }

        public TimeSpan HoraInicial { get; private set; }

        public TimeSpan HoraTermino { get; private set; }

        public string? Observacao { get; private set; }

        public StatusAgenda Status { get; private set; }



        // ==================================
        //             ALTERAÇÕES
        // ==================================

        public void AlterarData(DateTime dataAgendamento)
        {
            ValidarData(dataAgendamento);
            DataAgendamento = dataAgendamento;
        }

        public void AlterarHoraInicial(TimeSpan horaInicial)
        {
            ValidarHoraInicial(horaInicial);

            var horaAnterior = HoraInicial;

            HoraInicial = horaInicial;

           
            try
            {
                ValidarDuracao();
            }
            catch
            {
                HoraInicial = horaAnterior;
                throw;
            }

        }

        public void AlterarHoraTermino(TimeSpan horaTermino)
        {

            {
                ValidarHoraTermino(horaTermino);

                var horaAnterior = HoraTermino;

                HoraTermino = horaTermino;

                try
                {
                    ValidarDuracao();
                }
                catch
                {
                    HoraTermino = horaAnterior;
                    throw;
                }
            }
        }

        public void AlterarObservacao(string? observacao)
        {
            Observacao = observacao;
        }

    


        // ==================================
        //            VALIDAÇÕES
        // ==================================
        private void ValidarData(DateTime dataAgendamento)
        {

            if (dataAgendamento < DateTime.UtcNow)
            {

                throw new DomainExceptions("Não é possivel agendar uma data passada.");
            }

        }

        private void ValidarHoraInicial(TimeSpan horaInicial)
        {
            if (horaInicial == TimeSpan.Zero)
            {
                throw new DomainExceptions(
                    "Horário inicial obrigatório."
                );
            }

            if (horaInicial < TimeSpan.Zero)
            {
                throw new DomainExceptions(
                    "Horário inválido."
                );
            }
        }

        private void ValidarHoraTermino(TimeSpan horaTermino)
        {

            if (horaTermino == TimeSpan.Zero)
            {
                throw new DomainExceptions("Horario termino não pode estar zerado");

            }
            if (horaTermino <= HoraInicial)
            {
                throw new DomainExceptions("Horario do término do serviço não pode ser menor que a Hora inicial");

            }

        }

        private void ValidarDuracao()
        {
            var duracao = HoraTermino - HoraInicial;

            if (duracao < Servico.Duracao)
            {
                throw new DomainExceptions(
                  "O horário informado é menor que a duração do serviço."
                );
            }
        }

 

        public void Confirmar()
        {
            if (Status != StatusAgenda.Agendado)
                throw new DomainExceptions(
                  "Não é possível confirmar esse agendamento."
                );

            Status = StatusAgenda.Confirmado;
        }

        public void Cancelar()
        {
            if (Status == StatusAgenda.Realizado ||
               Status == StatusAgenda.Cancelado)
            {
                throw new DomainExceptions(
                  "Esse agendamento não pode ser cancelado."
                );
            }

            Status = StatusAgenda.Cancelado;
        }

        public void Realizar()
        {
            if (Status != StatusAgenda.Confirmado)
            {
                throw new DomainExceptions(
                    "Somente agendamentos confirmados podem ser realizados."
                );
            }

            Status = StatusAgenda.Realizado;
        }

    }
}
