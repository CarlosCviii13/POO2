namespace Atacado.Poco;

public class ProfissaoPoco
{
    public int ProfissaoID { get; set; }

    public string Descricao { get; set; } = null!; // Ta como "Descrição null" = "Atacado.BD.EF -> Categoria" //

    public bool Ativo { get; set; }
    
    public DateTime? DataInsert { get; set; }

}

