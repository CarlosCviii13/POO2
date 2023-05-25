using Atacado.BD.EF.Database;
using Atacado.Poco;
using Atacado.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtacadoApi.Controllers;

[ApiController]
[Route("api/Atacado/Estoque/")]
public class ProdutoController : BaseController
{
    private ProdutoServico servico;
    
    public ProdutoController() : base()
    {
        this.servico = new ProdutoServico(this.contexto);
    }

    [HttpGet("Produtos")]
    public List<ProdutoPoco> GetAll()
    {
        return this.servico.Listar();
    }

    [HttpGet("Produtos/PorCategoria/{categoriaId}")]
    public List<ProdutoPoco> GetByCategoriaId(int CategoriaId)
    {
        return this.servico.Listar(prod => prod.CodigoCategoria == CategoriaId);
    }

    [HttpGet("Produtos/PorSubcategoria/{subcategoriaId}")]
    public List<ProdutoPoco> GetBySubcategoriaId(int SubCategoriaId)
    {
        return this.servico.Listar(prod => prod.CodigoSubCategoria == SubCategoriaId);
    }

    [HttpGet("[controller]/{id}")]
    public ProdutoPoco GetById(int id)
    {
        return this.servico.Ler(id);
    }

    [HttpPost("[controller]")]
    public ProdutoPoco Post([FromBody]ProdutoPoco poco)
    {
        return this.servico.Inserir(poco);
    }

    [HttpPut("[controller]")]
    public ProdutoPoco Put([FromBody]ProdutoPoco poco)
    {
        return this.servico.Alterar(poco);
    }

    [HttpDelete("[controller]/{chave}")]
    public ProdutoPoco Delete(int chave)
    {
        return this.servico.Excluir(chave);
    }
}

