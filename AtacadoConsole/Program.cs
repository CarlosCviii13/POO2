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
}