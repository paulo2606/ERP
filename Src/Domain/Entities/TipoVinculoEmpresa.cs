using ERP.Src.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Src.Domain.Entities
{
    [Table("TAB_Tipo_Vinculo_Empresa", Schema = "dbo")]
    public class TipoVinculoEmpresa
    {
        [Key]
        [Column("Idf_Tipo_Vinculo_Empresa")]
        public int IdTipoVinculoEmpresa { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("Nme_Tipo_Vinculo_Empresa")]
        public string NomeTipoVinculoEmpresa { get; set; } = null!;

        [Column("Dta_Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("Flg_Inativo")]
        public bool FlgInativo { get; set; }

        // nav
        public ICollection<Empresas> Empresas { get; set; } = new List<Empresas>();
    }
}
