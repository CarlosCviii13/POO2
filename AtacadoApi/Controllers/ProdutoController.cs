using Atacado.BD.EF.Database;
using Atacado.Poco;
using Atacado.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtacadoApi.Controllers;

[ApiController]
[Route("api/Atacado/Estoque/")]
public class ProdutoController : BaseController<ProdutoPoco>
{
    private ProdutoServico servico;
    
    public ProdutoController() : base()
    {
        this.servico = new ProdutoServico(this.contexto);
    }

    [HttpGet("Produtos")]
    public ActionResult<List<ProdutoPoco>> GetAll()
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

    [HttpGet("Produtos/PorCategoria/{categoriaId}")]
    public ActionResult<List<ProdutoPoco>> GetByCategoriaId(int produtoId)
    {
        List<ProdutoPoco> lista = this.servico.Listar(prod => prod.CodigoCategoria == produtoId);
        if(lista == null)
        {
            return BadRequest("O recurso solicitado não foi encontrado.. :/");
        }
        else
        {
            return lista;
        }
    }

    [HttpGet("Produtos/PorSubcategoria/{subcategoriaId}")]
    public ActionResult<List<ProdutoPoco>> GetBySubCategoriaId(int subcategoriaId)
    {
        List<ProdutoPoco> lista = this.servico.Listar(prod => prod.CodigoSubCategoria == subcategoriaId);
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
    public ActionResult<ProdutoPoco> Get(int chave)
    {
        try
        {
            ProdutoPoco objPoco = this.servico.Ler(chave);
            return this.ValidarSucessoOuFracasso(objPoco);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("[controller]")] // add //
    public ActionResult<ProdutoPoco> Post([FromBody]ProdutoPoco poco)
    {
        try
        {
            ProdutoPoco novoPoco = this.servico.Inserir(poco);
            return this.ValidarSucessoOuFracasso(novoPoco);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("[controller]")] // Alterer //
    public ActionResult<ProdutoPoco> put([FromBody]ProdutoPoco poco)
    {
        try
        {
            ProdutoPoco altPoco = this.servico.Alterar(poco);
            return this.ValidarSucessoOuFracasso(altPoco);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("[controller]/{chave}")] // Deletar //
    public ActionResult<ProdutoPoco> Delete(int chave)
    {
        try
        {
            ProdutoPoco delPoco = this.servico.Excluir(chave);
            return this.ValidarSucessoOuFracasso(delPoco);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    protected override ActionResult<ProdutoPoco> ValidarSucessoOuFracasso(ProdutoPoco poco)
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

