namespace Atacado.BD.EF.Database;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table ("Regiao")]
public partial class Regiao
{
    [Key]
    public Int64 CodigoRegiao {get; set;}

    [Unicode(false)]
    public string Nome {get; set;} = null!;

    public Regiao()
    {}
}
