namespace Atacado.Poco
{
    // Em poco o que importa e ter os public(s) de "get e set" da class criadas //
    public class SubCategoriaPoco
    {
        public SubCategoriaPoco()
        { }

        public int Codigo { get; set; }

        public int CodigoCategoria { get; set; }

        public string Descricao { get; set; } = null!;

        public bool Ativo { get; set; }

        public DateTime? DataInclusao { get; set; }
    }
}
