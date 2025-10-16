using ERP.Src.Application.Services.Interfaces;
using ERP.Src.Domain.Entities;
using ERP.Src.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Src.Application.Services
{
    public class HistoricoAlteracaoService : IHistoricoAlteracaoService
    {
        private readonly AppDbContext _context;

        public HistoricoAlteracaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task RegistrarAsync(
            int idLogin,
            string nomeTabela,
            string nomeColuna,
            string tipoAlteracao,
            string descricaoAlteracao,
            int? idReferencia = null
        )
        {
            var historico = new HistoricoAlteracao
            {
                IdLogin = idLogin,
                NomeTabelaAlteracao = nomeTabela,
                NomeColunaAlteracao = nomeColuna,
                TipoAlteracao = tipoAlteracao,
                DescricaoAlteracao = descricaoAlteracao,
                DataAlteracao = DateTime.Now,
                IdEmpresaAlteracao = nomeTabela == "TAB_Empresa" ? idReferencia : null,
                IdLancamentoAlteracao = nomeTabela == "TAB_Lancamento" ? idReferencia : null,
                IdCategoriaAlteracao = nomeTabela == "TAB_Categoria" ? idReferencia : null,
                IdCentroCustoAlteracao = nomeTabela == "TAB_Centro_Custo" ? idReferencia : null
            };

            _context.HistoricoAlteracao.Add(historico);
            await _context.SaveChangesAsync();
        }
    }
}
