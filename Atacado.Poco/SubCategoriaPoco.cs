namespace Atacado.Poco;

public class SubCategoriaPoco
{
    public int Codigo { get; set; }

    public int CodigoCategoria { get; set; }
    public string Descricao { get; set; }

    public bool Ativo { get; set; }
    public DateTime? DataInclusao { get; set; }

}
