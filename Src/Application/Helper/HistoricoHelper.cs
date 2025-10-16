using ERP.Src.Application.Services.Interfaces;

namespace ERP.Src.Application.Helper
{
    public static class HistoricoHelper
    {
        public static async Task RegistrarAsync(
            IHistoricoAlteracaoService historicoService,
            int userId,
            string tabela,
            string coluna,
            string tipo,
            string descricao,
            int? idReferencia = null)       
        {
            await historicoService.RegistrarAsync(
                idLogin: userId,
                nomeTabela: tabela,
                nomeColuna: coluna,
                tipoAlteracao: tipo,
                descricaoAlteracao: descricao,
                idReferencia: idReferencia
            );
        }
    }
}