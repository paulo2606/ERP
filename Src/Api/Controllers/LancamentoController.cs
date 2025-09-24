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
    public class LancamentosController : ControllerBase
    {
        private readonly ILancamentoService _lancamentoService;

        public LancamentosController(ILancamentoService lancamentoService)
        {
            _lancamentoService = lancamentoService;
        }

        private int GetUserId() =>
            int.Parse(User.Claims.First(c => c.Type == "id").Value);

        [HttpPost("cria-lancamento")]
        public async Task<IActionResult> Create([FromBody] CreateLancamentoDto dto)
        {
            var result = await _lancamentoService.CreateAsync(dto, GetUserId());
            return Ok(result);
        }

        [HttpGet("buscar-lancamento/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lancamento = await _lancamentoService.GetByIdAsync(id);
            if (lancamento == null) return NotFound();
            return Ok(lancamento);
        }

        [HttpGet("listar_lancamentos")]
        public async Task<IActionResult> GetAll()
        {
            var lancamentos = await _lancamentoService.GetAllAsync();
            return Ok(lancamentos);
        }

        [HttpPut("atualiza-lancamento/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLancamentoDto dto)
        {
            var updated = await _lancamentoService.UpdateAsync(id, dto, GetUserId());
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var deleted = await _lancamentoService.SoftDeleteAsync(id, GetUserId());
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
