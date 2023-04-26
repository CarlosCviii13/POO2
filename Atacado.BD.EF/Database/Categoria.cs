using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.BD.EF.Database
{
    [Table("Categoria")]
    public partial class Categoria
    {
        public Categoria()
        {}

        [Key]
        public int Codigo { get; set; }
        [Unicode(false)]
        public string Descricao { get; set; } = null!;
        public bool Ativo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
    }
}
