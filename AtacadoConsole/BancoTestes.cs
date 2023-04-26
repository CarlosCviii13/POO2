using Atacado.BD.EF.Database;

namespace AtacadoConsole; //REFAZER

public class BancoTestes : BaseTestes
{
    public BancoTestes(AtacadoContext contexto) : base(contexto)
    {
    }

    public override void Imprimir()
    {
        Console.WriteLine("-----( Exibindo Rede de Bancos )-----\n");
        foreach (Banco item in this.context.Bancos)
        {
            Console.WriteLine($"(Codigo:{item.CodigoBanco}-{item.CodigoBacen})-> Banco: {item.Descricao} \n Site: {item.SiteBanco} \n Situação: {item.Situacao} \n Data: {item.DataInclusao} \n");
        }
        Console.WriteLine("-----( Finalizando Rede de Bancos )-----");
        Console.ReadLine();
    }
}
