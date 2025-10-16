using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Src.Domain.Entities
{
    [Table("TAB_Historico_Alteracao", Schema = "dbo")]
    public class HistoricoAlteracao
    {
        [Key]
        [Column("Idf_Historico_Alteracao")]
        public int IdHistoricoAlteracao { get; set; }

        [Column("Idf_Login")]
        public int IdLogin { get; set; }

        [Column("Dta_Alteracao")]
        public DateTime DataAlteracao { get; set; }

        [Column("Nme_Tabela_Alteracao")]
        public string NomeTabelaAlteracao { get; set; }

        [Column("Nme_Coluna_Alteracao")]
        public string NomeColunaAlteracao { get; set; }

        [Column("Des_Tipo_Alteracao")]
        public string TipoAlteracao { get; set; } 

        [Column("Des_Alteracao")]
        public string DescricaoAlteracao { get; set; }

        [Column("Idf_Categoria_Alteracao")]
        public int? IdCategoriaAlteracao { get; set; }

        [Column("Idf_Centro_Custo_Alteracao")]
        public int? IdCentroCustoAlteracao { get; set; }

        [Column("Idf_Cidade_Alteracao")]
        public int? IdCidadeAlteracao { get; set; }

        [Column("Idf_Empresa_Alteracao")]
        public int? IdEmpresaAlteracao { get; set; }

        [Column("Idf_Endereco_Alteracao")]
        public int? IdEnderecoAlteracao { get; set; }

        [Column("Idf_Estado_Alteracao")]
        public int? IdEstadoAlteracao { get; set; }

        [Column("Idf_Lancamento_Alteracao")]
        public int? IdLancamentoAlteracao { get; set; }

        [Column("Idf_Login_Alteracao")]
        public int? IdLoginAlteracao { get; set; }

        [Column("Idf_Natureza_Juridica_Alteracao")]
        public int? IdNaturezaJuridicaAlteracao { get; set; }

        [Column("Idf_Nivel_Acesso_Alteracao")]
        public int? IdNivelAcessoAlteracao { get; set; }

        [Column("Idf_Pagamento_Alteracao")]
        public int? IdPagamentoAlteracao { get; set; }

        [Column("Idf_Permissao_Alteracao")]
        public int? IdPermissaoAlteracao { get; set; }

        [Column("Idf_Recebimento_Alteracao")]
        public int? IdRecebimentoAlteracao { get; set; }

        [Column("Idf_Recorrencia_Alteracao")]
        public int? IdRecorrenciaAlteracao { get; set; }

        [Column("Idf_Regiao_Alteracao")]
        public int? IdRegiaoAlteracao { get; set; }

        [Column("Idf_Situacao_Lancamento_Alteracao")]
        public int? IdSituacaoLancamentoAlteracao { get; set; }

        [Column("Idf_Tipo_Pagamento_Alteracao")]
        public int? IdTipoPagamentoAlteracao { get; set; }

        [Column("Idf_Tipo_Vinculo_Empresa_Alteracao")]
        public int? IdTipoVinculoEmpresaAlteracao { get; set; }
    }
}
