using Atacado.BD.EF.Database;
using Atacado.Poco;
using Atacado.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtacadoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : BaseController
{
    private CategoriaServico servico;
    public CategoriaController() : base()
    {
        this.servico = new CategoriaServico(this.contexto);
    }

    [HttpGet]
    public List<CategoriaPoco> GetAll()
    {
        return this.servico.Listar();
    }
}
