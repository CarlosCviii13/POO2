using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.BD.EF.Database
{
    [Table("Profissao")]
    public partial class Profissao
    {
    public Profissao()
    {}

    [Key]
    public int ProfissaoID { get; set; }
    [Unicode(false)]
    public string Descricao { get; set; } = null!;
    public bool Ativo { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime? DataInsert { get; set; }
    }
}