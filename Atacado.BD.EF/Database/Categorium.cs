using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.BD.EF.Database
{
    public partial class Categorium
    {
        public Categorium()
        {
            Subcategoria = new HashSet<Subcategorium>();
        }

        [Key]
        public int Codigo { get; set; }
        [Unicode(false)]
        public string Descricao { get; set; } = null!;
        public bool Ativo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }

        [InverseProperty("CodigoCategoriaNavigation")]
        public virtual ICollection<Subcategorium> Subcategoria { get; set; }
    }
}
