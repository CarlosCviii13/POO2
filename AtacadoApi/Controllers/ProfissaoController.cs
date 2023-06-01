using Atacado.Poco;
using Atacado.Servico;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers;

[ApiController]
[Route("api/atacado;RecursosHumanos/")]
// Controller //
public class ProfissaoController : BaseController<ProfissaoPoco>
{
    private ProfissaoServico servico;

    public ProfissaoController() : base()
    {
        this.servico = new ProfissaoServico(this.contexto);
    }

    [HttpGet("Profissoes")] // ver todos "GET ALL"//
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

    [HttpGet("[controller]/{chave}")] // ver algo especifico //
    public ActionResult<ProfissaoPoco> Get(int chave)
    {
        try
        {
            ProfissaoPoco objPoco = this.servico.Ler(chave);
            return this.ValidarSucessoOuFracasso(objPoco);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("[controller]")] // add //
    public ActionResult<ProfissaoPoco> Post([FromBody]ProfissaoPoco poco)
    {
        try
        {
            ProfissaoPoco novoPoco = this.servico.Inserir(poco);
            return this.ValidarSucessoOuFracasso(novoPoco);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("[controller]")] // Alterer //
    public ActionResult<ProfissaoPoco> put([FromBody]ProfissaoPoco poco)
    {
        try
        {
            ProfissaoPoco altPoco = this.servico.Alterar(poco);
            return this.ValidarSucessoOuFracasso(altPoco);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("[controller]/{chave}")] // Deletar //
    public ActionResult<ProfissaoPoco> Delete(int chave)
    {
        try
        {
            ProfissaoPoco delPoco = this.servico.Excluir(chave);
            return this.ValidarSucessoOuFracasso(delPoco);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    protected override ActionResult<ProfissaoPoco> ValidarSucessoOuFracasso(ProfissaoPoco poco)
    { // "O pior cenario sempre vem primeiro" //
        if (poco == null)
        {
            return BadRequest("O recurso solicitado não foi encontrado.. :/");
        }
        else
        {
            return Ok(poco);
        }
    }
}