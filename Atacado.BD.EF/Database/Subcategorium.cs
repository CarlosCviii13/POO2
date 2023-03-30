using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.BD.EF.Database
{
    public partial class Subcategorium
    {
        public Subcategorium()
        {
            Produtos = new HashSet<Produto>();
        }

        [Key]
        public int Codigo { get; set; }
        public int CodigoCategoria { get; set; }
        [Unicode(false)]
        public string Descricao { get; set; } = null!;
        public bool Ativo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }

        [ForeignKey("CodigoCategoria")]
        [InverseProperty("Subcategoria")]
        public virtual Categorium CodigoCategoriaNavigation { get; set; } = null!;
        [InverseProperty("CodigoSubcategoriaNavigation")]
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
