using Atacado.Poco;
using Atacado.Servico;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers;

[ApiController]
[Route("api/atacado;RecursosHumanos/")]
public class ProfissaoController : BaseController
{
    private ProfissaoServico servico;

    public ProfissaoController() : base()
    {
        this.servico = new ProfissaoServico(this.contexto);
    }

    [HttpGet("Profissoes")]
    public ActionResult<List<ProfissaoPoco>> GetAll()
    {
        try
        {
            return Ok(this.servico.Listar());
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
