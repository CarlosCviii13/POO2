using Atacado.BD.EF.Database;

namespace AtacadoConsole;

public class EstadoTestes : BaseTestes
{
    public EstadoTestes(AtacadoContext contexto) : base(contexto)
    {
    }

    public override void Imprimir()
    {
        Console.WriteLine("-----( Exibindo Estados )-----\n");
        foreach (Estado item in this.context.Estados)
        {
            Console.WriteLine($"(Codigo:{item.CodigoEstado})-> Estado: {item.Nome} ({item.UF}) \n");
        }
        Console.WriteLine("-----( Finalizando Estados )-----");
        Console.ReadLine();
    }
}
