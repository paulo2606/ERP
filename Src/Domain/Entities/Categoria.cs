using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Src.Domain.Entities
{
    [Table("TAB_Categoria", Schema = "dbo")]
    public class Categoria
    {
        [Key]
        [Column("Idf_Categoria")]
        public int IdCategoria { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("Nme_Categoria")]
        public string NomeCategoria { get; set; }

        [Column("Tpo_Categoria")]
        public string? TipoCategoria { get; set; }

        [Column("Dta_Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("Dta_Alteracao")]
        public DateTime? DataAlteracao { get; set; }

        [Column("Flg_Inativo")]
        public bool FlagInativo { get; set; }
    }
}
