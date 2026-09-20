using AesthiaAI.Application.DTOs.Clientes;
using AesthiaAI.Application.Interfaces.Repositories;

namespace AesthiaAI.Application.Interfaces
{
    public interface IClienteService
    {

        Task<Guid> CriarAsync(CriarClienteRequest request);

        Task<ClienteResponseDto?> ObterPorIdAsync(Guid id);
    }
}
