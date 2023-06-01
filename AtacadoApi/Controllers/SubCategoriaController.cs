using Atacado.BD.EF.Database;
using Atacado.Poco;
using Atacado.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtacadoApi.Controllers;

[ApiController]
[Route("api/Atacado/Estoque/")]
// Controller //
public class SubCategoriaController : BaseController<SubCategoriaPoco>
{
    private SubCategoriaServico servico;
    
    public SubCategoriaController() : base()
    {
        this.servico = new SubCategoriaServico(this.contexto);
    }

    [HttpGet("SubCategorias")] // ver todos "GET ALL"//
    public ActionResult<List<SubCategoriaPoco>> GetAll()
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

    [HttpGet("Subcategorias/PorCategoria/{categoraId}")]
    public ActionResult<List<SubCategoriaPoco>> GetByCategoriaId(int categoriaId)
    {
        List<SubCategoriaPoco> lista = this.servico.Listar(sub => sub.CodigoCategoria == categoriaId);
        if(lista == null)
        {
            return BadRequest("O recurso solicitado não foi encontrado.. :/");
        }
        else
        {
            return lista;
        }
    }

    [HttpGet("[controller]/{chave}")] // ver algo especifico //
    public ActionResult<SubCategoriaPoco> Get(int chave)
    {
        try
        {
            SubCategoriaPoco objPoco = this.servico.Ler(chave);
            return this.ValidarSucessoOuFracasso(objPoco);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("[controller]")] // add //
    public ActionResult<SubCategoriaPoco> Post([FromBody]SubCategoriaPoco poco)
    {
        try
        {
            SubCategoriaPoco novoPoco = this.servico.Inserir(poco);
            return this.ValidarSucessoOuFracasso(novoPoco);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("[controller]")] // Alterer //
    public ActionResult<SubCategoriaPoco> put([FromBody]SubCategoriaPoco poco)
    {
        try
        {
            SubCategoriaPoco altPoco = this.servico.Alterar(poco);
            return this.ValidarSucessoOuFracasso(altPoco);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("[controller]/{chave}")] // Deletar //
    public ActionResult<SubCategoriaPoco> Delete(int chave)
    {
        try
        {
            SubCategoriaPoco delPoco = this.servico.Excluir(chave);
            return this.ValidarSucessoOuFracasso(delPoco);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    protected override ActionResult<SubCategoriaPoco> ValidarSucessoOuFracasso(SubCategoriaPoco poco)
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