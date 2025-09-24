using ERP.Src.Api.Dtos;
using ERP.Src.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ERP.Src.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CentroCustoController : ControllerBase
    {
        private readonly ICentroCustoService _centroCustoService;

        public CentroCustoController(ICentroCustoService centroCustoService)
        {
            _centroCustoService = centroCustoService;
        }

        private int GetUserId() =>
            int.Parse(User.Claims.First(c => c.Type == "id").Value);

        [HttpPost("cria-centro-de-custo")]
        public async Task<IActionResult> Create([FromBody] CreateCentroCustoDto dto)
        {
            var result = await _centroCustoService.CreateAsync(dto, GetUserId());
            return Ok(result);
        }

        [HttpGet("busca-centro-de-custo/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _centroCustoService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("lista-centro-de-custo")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _centroCustoService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("atualiza-centro-de-custo/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCentroCustoDto dto)
        {
            var result = await _centroCustoService.UpdateAsync(id, dto, GetUserId());
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("soft-delete-centro-de-custo/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var deleted = await _centroCustoService.SoftDeleteAsync(id, GetUserId());
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
