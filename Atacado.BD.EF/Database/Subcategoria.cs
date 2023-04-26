using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.BD.EF.Database;

[Table("Subcategoria")]

public partial class Subcategoria //"Table" + "public partial" + "public"
{
    public Subcategoria()
    {}

    [Key] // Chave principal

    // "get" "set"
    public int Codigo { get; set; } // Codigo "SQL"
    public int CodigoCategoria { get; set; } // Codigo "SQL"

    [Unicode(false)] // False "SQL"
    public string Descricao { get; set; } = null!; // Descricao "SQL"
    public bool Ativo { get; set; } // Ativo "SQL"


    [Column(TypeName = "datetime")] //DateTime
    public DateTime? DataInclusao { get; set; } // DataInclusao "SQL"
}
