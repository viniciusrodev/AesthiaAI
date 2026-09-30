using AesthiaAI.Application.DTOs.Clientes;
using AesthiaAI.Application.Interfaces.Repositories;
using AesthiaAI.Domain.Entities;

namespace AesthiaAI.Application.Interfaces
{
    public interface IClienteService
    {

        Task<Guid> CriarAsync(CriarClienteRequest request);

        Task<ClienteResponseDto?> ObterPorIdAsync(Guid id);

        Task<List<ClienteResponseDto>> ObterTodosAsync();

        Task<bool> AtualizarAsync(Guid id, AtualizarClienteRequest request);

        Task<bool> RemoverAsync(Guid id);
    }
}
