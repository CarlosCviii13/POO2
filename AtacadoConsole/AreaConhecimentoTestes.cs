using Atacado.BD.EF.Database;

namespace AtacadoConsole;

public class AreaConhecimentoTestes : BaseTestes
{
    public AreaConhecimentoTestes(AtacadoContext contexto) : base(contexto)
    {
    }

    public override void Imprimir()
    {
        Console.WriteLine("-----( Exibindo Area de Conhecimentos )-----\n");
        foreach (AreaConhecimento item in this.context.AreaConhecimentos)
        {
            Console.WriteLine($"(Codigo:{item.CodigoArea})-> Descrição: {item.Descricao} \n Date: {item.DataInclusao} \n");
        }
        Console.WriteLine("-----( Finalizando Area de Conhecimentos )-----");
        Console.ReadLine();
    }
}
