using Atacado.BD.EF.Database;
using Atacado.Poco;
using Atacado.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtacadoApi.Controllers;

[ApiController]
[Route("api/Atacado/Estoque/")]
// Controller //
public class CategoriaController : BaseController<CategoriaPoco>
{
    private CategoriaServico servico;
    public CategoriaController() : base()
    {
        this.servico = new CategoriaServico(this.contexto);
    }

    [HttpGet("Categorias")] // ver todos "GET ALL"//
    public ActionResult<List<CategoriaPoco>> GetAll()
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
    public ActionResult<CategoriaPoco> Get(int chave)
    {
        try
        {
            CategoriaPoco objPoco = this.servico.Ler(chave);
            return this.ValidarSucessoOuFracasso(objPoco);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("[controller]")] // add //
    public ActionResult<CategoriaPoco> Post([FromBody]CategoriaPoco poco)
    {
        try
        {
            CategoriaPoco novoPoco = this.servico.Inserir(poco);
            return this.ValidarSucessoOuFracasso(novoPoco);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("[controller]")] // Alterer //
    public ActionResult<CategoriaPoco> put([FromBody]CategoriaPoco poco)
    {
        try
        {
            CategoriaPoco altPoco = this.servico.Alterar(poco);
            return this.ValidarSucessoOuFracasso(altPoco);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("[controller]/{chave}")] // Deletar //
    public ActionResult<CategoriaPoco> Delete(int chave)
    {
        try
        {
            CategoriaPoco delPoco = this.servico.Excluir(chave);
            return this.ValidarSucessoOuFracasso(delPoco);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    protected override ActionResult<CategoriaPoco> ValidarSucessoOuFracasso(CategoriaPoco poco)
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
