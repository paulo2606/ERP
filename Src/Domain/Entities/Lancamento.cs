using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Src.Domain.Entities
{
    [Table("TAB_Lancamento", Schema = "dbo")]
    public class Lancamento
    {
        [Key]
        [Column("Idf_Lancamento")]
        public int IdLancamento { get; set; }

        [MaxLength(255)]
        [Column("Des_Lancamento")]
        public string DescricaoLancamento { get; set; }

        [Column("Vlr_Lancamento_Previsto")]
        public decimal ValorLancamentoPrevisto { get; set; }

        [Column("Dta_Lancamento")]
        public DateTime DataLancamento { get; set; }

        [Column("Idf_Situacao_Lancamento")]
        public int IdSituacaoLancamento { get; set; }

        [Column("Idf_Empresa")]
        public int? IdEmpresa { get; set; }

        [Column("Idf_Categoria")]
        public int IdCategoria { get; set; }

        [Column("Idf_Centro_Custo")]
        public int IdCentroCusto { get; set; }

        [Column("Idf_Responsavel_Criacao")]
        public int IdResponsavelCriacao { get; set; }

        [Column("Idf_Responsavel_Alteracao")]
        public int? IdResponsavelAlteracao { get; set; }

        [Column("Dta_Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("Dta_Alteracao")]
        public DateTime? DataAlteracao { get; set; }

        [Column("Flg_Inativo")]
        public bool FlagInativo { get; set; }
    }
}