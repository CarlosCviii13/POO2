using Atacado.BD.EF.Database;
using Atacado.Poco;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtacadoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private AtacadoContext contexto;
    public CategoriaController() : base()
    {
        string connectionString = "Data Source=(Local);Initial Catalog=bdAtacado;User=usrAtacado;Password=senha123;TrustServerCertificate=True;";
        var options = new DbContextOptionsBuilder<AtacadoContext>().UseSqlServer(connectionString).Options;
        this.contexto = new AtacadoContext(options);
    }

    [HttpGet]
    public List<CategoriaPoco> GetAll()
    {
        List<CategoriaPoco> lista = new List<CategoriaPoco>();
        
        foreach (var item in this.contexto.Categorias)
        {
           CategoriaPoco poco = new CategoriaPoco();
           poco.Codigo = item.Codigo;
           poco.Descricao = item.Descricao;
           poco.Ativo = item.Ativo;
           poco.DataInclusao = item.DataInclusao;
           lista.Add(poco); 
        }
        return lista;
    }
}
