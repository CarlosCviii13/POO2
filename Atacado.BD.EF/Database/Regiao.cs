using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.BD.EF.Database;

[Table ("Regiao")]

public partial class Regiao //"Table" + "public partial" + "public"
{
    public Regiao()
    {}

    [Key] // Chave principal

    // "get" "set"
    public Int64 CodigoRegiao {get; set;} // Codigo "SQL"

    [Unicode(false)] // False "SQL"
    public string Nome {get; set;} = null!; // Nome "SQL"
}
