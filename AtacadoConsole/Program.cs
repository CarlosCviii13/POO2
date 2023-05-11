namespace AtacadoConsole;

using Atacado.BD.EF.Database;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        //Criando a string de conexão com o banco de dados SQL Server.
        string connectionString = "Data Source=(Local);Initial Catalog=bdAtacado;User=usrAtacado;Password=senha123;TrustServerCertificate=True;";
        var options = new DbContextOptionsBuilder<AtacadoContext>().UseSqlServer(connectionString).Options;
        var contexto = new AtacadoContext(options);

        BaseTestes teste;
        //teste = new CategoriaTestes(contexto);        // OK
        //teste = new SubcategoriaTestes(contexto);     // OK
        //teste = new ProdutoTestes(contexto);          // OK
        //teste = new RegiaoTestes(contexto);           // OK
        //teste = new EstadoTestes(contexto);           // OK
        //teste = new CidadeTestes(contexto);           // OK
        //teste = new BancoTestes(contexto);            // OK
        teste = new AreaConhecimentoTestes(contexto); // OK
        teste.Imprimir();

        Console.WriteLine("\nFim do Programa...");
        Console.ReadLine();
    }
    // FORMA DE IMPRIMIR TUDO //
    //     public static void Main(string[] args)
    // {
    //     ProvaN1Context ctx = new ProvaN1Context();

    //     Console.WriteLine("Funcionarios:");
    //     foreach (var item in ctx.Funcionarios)
    //     {
    //         Console.WriteLine($"Codigo: {item.Codigo} - Nome Funcionario: {item.Nome}");
    //     }
    //     Console.ReadKey();

    //     Console.Clear();
    //     Console.WriteLine("Pessoas Físicas:");
    //     foreach (var item in ctx.PessoasFisicas)
    //     {
    //         Console.WriteLine($"Codigo: {item.Codigo} - Nome Pessoa Física: {item.Nome}");
    //     }
    //     Console.ReadKey();

    //     Console.Clear();
    //     Console.WriteLine("Pessoas Jurídicas:");
    //     foreach (var item in ctx.PessoasJuridicas)
    //     {
    //         Console.WriteLine($"Codigo: {item.Codigo} - Nome Empresa: {item.Nome}");
    //     }
    // }
}