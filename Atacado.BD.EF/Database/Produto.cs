﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.BD.EF.Database;
    [Table("Produto")]
    public class Produto
{
    [Key]
    public int Codigo { get; set; }
    public int CodigoSubCategoria { get; set; }
    [Unicode(false)]
    public string Descricao { get; set; } = null!;
    [Column(TypeName = "decimal(7, 2)")]
    public decimal Valor { get; set; }
    public bool Ativo { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime? DataInclusao { get; set; }
    public int CodigoCategoria { get; set; }
}
