using ERP.Src.Api.Dtos;
using ERP.Src.Application.Services.Interfaces;
using ERP.Src.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Src.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class LancamentoController : ControllerBase
    {
        private readonly ILancamentoService _lancamentoService;

        public LancamentoController(ILancamentoService lancamentoService)
        {
            _lancamentoService = lancamentoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lancamento>>> GetAll()
        {
            var lancamentos = await _lancamentoService.GetAllAsync();
            return Ok(lancamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lancamento>> GetById(int id)
        {
            var lancamento = await _lancamentoService.GetByIdAsync(id);
            if (lancamento == null) return NotFound();
            return Ok(lancamento);
        }

        [HttpPost]
        public async Task<ActionResult<Lancamento>> Create([FromBody] CreateLancamentoDto dto)
        {
            var userId = int.Parse(User.Claims.First(c => c.Type == "id").Value);

            var lancamento = await _lancamentoService.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { id = lancamento.IdLancamento }, lancamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateLancamentoDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            //var result = await _lancamentoService.UpdateAsync(id, dto);
            //if (!result) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            //var result = await _lancamentoService.SoftDeleteAsync(id);
            //if (!result) return NotFound();

            return NoContent();
        }
    }
}
