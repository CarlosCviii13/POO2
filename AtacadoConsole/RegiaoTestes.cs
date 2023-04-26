using Atacado.BD.EF.Database;

namespace AtacadoConsole;

public class RegiaoTestes : BaseTestes
{
    public RegiaoTestes(AtacadoContext contexto) : base(contexto)
    {
    }

    public override void Imprimir()
    {
        Console.WriteLine("-----( Exibindo Regiões )-----\n");
        foreach (Regiao item in this.context.Regioes)
        {
            Console.WriteLine($"(Codico:{item.CodigoRegiao})-> Região:{item.Nome}\n");
        }
        Console.WriteLine("-----( Finalizando Regiões )-----");
        Console.ReadLine();
    }
}
