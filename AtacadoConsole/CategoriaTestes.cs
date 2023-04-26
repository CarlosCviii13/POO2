using Atacado.BD.EF.Database;

namespace AtacadoConsole;

public class CategoriaTestes : BaseTestes
{
    public CategoriaTestes(AtacadoContext contexto) : base(contexto)
    {
    }

    public override void Imprimir()
    {
        Console.WriteLine("-----( Exibindo Categorias )-----\n");
        foreach (Categoria item in this.context.Categorias)
        {
            Console.WriteLine($"(Codigo:{item.Codigo})-> Descrição: {item.Descricao} \n Data: {item.DataInclusao}\n");
        }
        Console.WriteLine("-----( Finalizando Categorias )-----");
        Console.ReadLine();
    }
}
