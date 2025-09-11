using ERP.Src.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Src.Domain.Entities
{
    [Table("TAB_Permissao", Schema = "dbo")]
    public class Permissao
    {
        [Key]
        [Column("Idf_Permissao")]
        public int IdPermissao { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Nme_Permissao")]
        public string NomePermissao { get; set; } = null!;

        [MaxLength(255)]
        [Column("Des_Permissao")]
        public string? DescricaoPermissao { get; set; }

        [Required]
        [Column("Dta_Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Required]
        [Column("Dta_Alteracao")]
        public DateTime DataAlteracao { get; set; }

        [Required]
        [Column("Flg_Inativo")]
        public bool FlgInativo { get; set; }

        // nav
        public ICollection<Login> Logins { get; set; } = new List<Login>();
    }
}
