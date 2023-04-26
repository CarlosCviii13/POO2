using Atacado.BD.EF.Database;

namespace AtacadoConsole;

public class CidadeTestes : BaseTestes
{
    public CidadeTestes(AtacadoContext contexto) : base(contexto)
    {
    }

    public override void Imprimir()
    {
        Console.WriteLine("-----( Exibindo Cidades )-----\n");
        foreach (Cidade item in this.context.Cidades)
        {
            Console.WriteLine($"(Codigo:{item.CodigoCidade})-> Cidade: {item.Nome} ({item.UF}) \n");
        }
        Console.WriteLine("-----( Finalizando Cidades )-----");
        Console.ReadLine();
    }
}
