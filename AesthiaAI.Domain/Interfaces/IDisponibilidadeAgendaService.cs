using System;
using System.Collections.Generic;
using System.Text;

namespace AesthiaAI.Domain.Interfaces
{
    public interface IDisponibilidadeAgendaService
    {

        Task<bool> VerificarDisponibilidadeAsync(
            Guid esteticistaId,
            DateTime data,
            TimeSpan HoraInicial,
            TimeSpan HoraTermino
            );
    }
}
