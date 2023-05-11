namespace Atacado.Poco
{
    // Em poco o que importa e ter os public(s) de "get e set" //
    public class ProdutoPoco
    {
        public int Codigo { get; set; }

        public int CodigoSubcategoria { get; set; }

        public string Descricao { get; set; } = null!;

        public decimal Valor { get; set; }

        public bool Ativo { get; set; }

        public DateTime? DataInclusao { get; set; }
    }
}
