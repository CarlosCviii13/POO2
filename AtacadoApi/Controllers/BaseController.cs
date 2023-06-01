using Atacado.BD.EF.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtacadoApi.Controllers;

// public abstract class BaseController : ControllerBase
public abstract class BaseController<TPoco> : ControllerBase
{
    protected AtacadoContext contexto;

    public BaseController() : base()
    {
        string connectionString = "Data Source=(Local);Initial Catalog=bdAtacado;User=usrAtacado;Password=senha123;TrustServerCertificate=True;";
        var options = new DbContextOptionsBuilder<AtacadoContext>().UseSqlServer(connectionString).Options;
        this.contexto = new AtacadoContext(options);
    }

    protected abstract ActionResult<TPoco> ValidarSucessoOuFracasso(TPoco poco);
}
