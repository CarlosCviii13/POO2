using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.BD.EF.Database; 

    [Table("Banco")]
    public class Banco
{
    [Key]
    public int CodigoBanco { get; set; }
    public int? CodigoBacen { get; set; }
    [Unicode(false)]
    public string? Descricao { get; set; }
    [Unicode(false)]
     public string? SiteBanco { get; set; }
    public bool Situacao { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime? DataInclusao { get; set; }
}
