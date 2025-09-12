using ERP.Src.Api.Dtos;
using ERP.Src.Application.Services.Interface;
using ERP.Src.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Src.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpPost("criar-empresa")]
        public async Task<IActionResult> Create(EmpresaCreateDto dto)
        {
            var empresa = await _empresaService.CreateAsync(dto);
            return Ok(empresa);
        }

        [HttpGet("listar-empresa")]
        public async Task<IActionResult> GetAll()
        {
            var empresas = await _empresaService.GetAllAsync();
            return Ok(empresas);
        }

        [HttpGet("buscar-empresa/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empresa = await _empresaService.GetEmpresaByIdAsync(id);

            if (empresa == null)
                return NotFound(new { message = "Empresa não encontrada" });

            return Ok(empresa);
        }

        [HttpPut("atualiza-empresa/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmpresaUpdateDto empresaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _empresaService.UpdateEmpresaAsync(id, empresaDto);

            if (!updated)
                return NotFound(new { message = "Empresa não encontrada" });

            return Ok("Empresa Atualizada!");
        }

        [HttpDelete("soft-delete{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _empresaService.DeleteAsync(id);
            if (!result) return NotFound( new { mensage = "Empresa não encontrada " });

            return Ok("Empresa Deletada!");
        }
    }
}
