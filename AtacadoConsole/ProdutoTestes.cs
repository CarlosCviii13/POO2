using Atacado.BD.EF.Database;

namespace AtacadoConsole;

public class ProdutoTestes : BaseTestes
{
    public ProdutoTestes(AtacadoContext contexto) : base(contexto)
    {
    }

    public override void Imprimir()
    {
        Console.WriteLine("-----( Exibindo Produtos )-----");
        foreach (Produto item in this.context.Produtos)
        {
            Console.WriteLine($"(Codigo:{item.Codigo}-{item.CodigoSubcategoria})-> Descição: {item.Descricao} \n Valor: $ {item.Valor} \n Data: {item.DataInclusao}\n");
        }
        Console.WriteLine("-----( Finalizando Produtos )-----");
        Console.ReadLine();
    }
}
