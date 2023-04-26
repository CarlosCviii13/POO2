using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.BD.EF.Database;
[Table ("Estado")]

public class Estado
{
    [Key]
    public Int64 CodigoEstado {get; set;}

    [Unicode(false)]
    public string Nome {get; set;} = null!;

    [Unicode(false)]
    public string UF {get; set;} = null!;

    public Int64 CodigoRegiao {get; set;}

    public Estado()
    {}
}
