using AesthiaAI.Application.DTOs.Clientes;
using AesthiaAI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AesthiaAI.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {

            _clienteService = clienteService;
        }

        [HttpPost]

        public async Task<IActionResult> Criar(
           [FromBody] CriarClienteRequest request)
        {
            var id = await _clienteService.CriarAsync(request);

            return CreatedAtAction(
                nameof(ObterPorId),
                new { id },
                id
                );

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> ObterPorId(Guid id)
        {

            var cliente = await _clienteService.ObterPorIdAsync(id);

            if(cliente == null)
            {

                return NotFound();
            }

            return Ok(cliente);
        }

    }
}
