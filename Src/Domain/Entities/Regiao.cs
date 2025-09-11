using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Src.Domain.Entities
{
    [Table("TAB_Regiao", Schema = "dbo")]
    public class Regiao
    {
        [Key]
        [Column("Idf_Regiao")]
        public int IdRegiao { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("Nme_Regiao")]
        public string NomeRegiao { get; set; } = null!;

        [Column("Dta_Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("Flg_Inativo")]
        public bool FlgInativo { get; set; }


        //nav
        public ICollection<Estado> Estados { get; set; } = new List<Estado>();
    }
}
