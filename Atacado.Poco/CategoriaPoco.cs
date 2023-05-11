namespace Atacado.Poco;
// Em poco o que importa e ter os public(s) de "get e set" //
public class CategoriaPoco
{
    public int Codigo { get; set; }

    public string Descricao { get; set; } = null!; // Ta como "Descrição null" = "Atacado.BD.EF -> Categoria" //

    public bool Ativo { get; set; }
    
    public DateTime? DataInclusao { get; set; }

}
