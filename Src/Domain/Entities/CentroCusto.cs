using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Src.Domain.Entities
{
    [Table("TAB_Centro_Custo", Schema = "dbo")]
    public class CentroCusto
    {
        [Key]
        [Column("Idf_Centro_Custo")]
        public int IdCentroCusto { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("Nme_Centro_Custo")]
        public string NomeCentroCusto { get; set; }

        [Column("Des_Centro_Custo")]
        public string? Descricao { get; set; }

        [Column("Cod_Centro_Custo")]
        public string? CodigoCentroCusto { get; set; }

        [Column("Dta_Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("Dta_Alteracao")]
        public DateTime? DataAlteracao { get; set; }

        [Column("Flg_Inativo")]
        public bool FlgInativo { get; set; }
    }
}
