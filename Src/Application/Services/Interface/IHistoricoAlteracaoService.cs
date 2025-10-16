using System.Threading.Tasks;

namespace ERP.Src.Application.Services.Interfaces
{
    public interface IHistoricoAlteracaoService
    {
        Task RegistrarAsync(int idLogin,string nomeTabela,string nomeColuna,string tipoAlteracao,string descricaoAlteracao,int? idReferencia = null);
    }
}
