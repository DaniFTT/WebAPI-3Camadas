using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("TB_Produto")]
    public class ProdutoModel
    {
        [Column("PRD_Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("PRD_Nome")]
        [Display(Name = "Nome")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Column("PRD_Valor")]
        [Display(Name = "Valor")]
        public double Valor { get; set; }

        [Column("PRD_QuantidadeVendida")]
        [Display(Name = "Quantidade Vendida")]
        public int QuantidadeVendida { get; set; }

        [Column("PRD_Ativo")]
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        [Column("PRD_DataDeCriacao")]
        [Display(Name = "Data de Criação")]
        public DateTime DataDeCriacao { get; set; }

        [Column("PRD_DataDeAlteracao")]
        [Display(Name = "Data de Alteração")]
        public DateTime DataDeAlteracao { get; set; }

    }
}
