using ERP.Src.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Src.Domain.Entities
{
    [Table("TAB_Natureza_Juridica", Schema = "dbo")]
    public class NaturezaJuridica
    {
        [Key]
        [Column("Idf_Natureza_Juridica")]
        public int IdNaturezaJuridica { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("Nme_Natureza_Juridica")]
        public string NomeNaturezaJuridica { get; set; } = null!;

        [Column("Dta_Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("Flg_Inativo")]
        public bool FlgInativo { get; set; }

        // nav
        public ICollection<Empresas> Empresas { get; set; } = new List<Empresas>();
    }
}
