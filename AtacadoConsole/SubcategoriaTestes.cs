using Atacado.BD.EF.Database;

namespace AtacadoConsole;

public class SubcategoriaTestes : BaseTestes
{
    public SubcategoriaTestes(AtacadoContext contexto) : base(contexto)
    {
    }

    public override void Imprimir()
    {
        Console.WriteLine("-----( Exibindo SubCategorias )-----\n");
        foreach (Subcategoria item in this.context.Subcategorias)
        {
            Console.WriteLine($"(Codigo:{item.Codigo}-{item.CodigoCategoria})-> Descrição: {item.Descricao} \n Data: {item.DataInclusao}\n");
        }
        Console.WriteLine("-----( Finalizando SubCategorias )-----");
    }
}
