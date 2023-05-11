using Atacado.BD.EF.Database;
using Atacado.Poco;
using Atacado.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtacadoApi.Controllers;

[ApiController]
[Route("api/Atacado/Produto/")]
// Controller //
public class ProdutoController : BaseController
{
    private ProdutoServico servico;
    
    public ProdutoController() : base()
    {
        this.servico = new ProdutoServico(this.contexto);
    }

    [HttpGet("Produtos")] // ver todos "GET ALL"//
    public List<ProdutoPoco> GetAll()
    {
        return this.servico.Listar();
    }

    [HttpGet("[controller]/{id}")] // ver algo especifico //
    public ProdutoPoco GetById(int id)
    {
        return this.servico.Ler(id);
    }

    [HttpPost("[controller]")] // add //
    public ProdutoPoco Post([FromBody]ProdutoPoco poco)
    {
        return this.servico.Inserir(poco);
    }

    [HttpPut("[controller]")] // alterar //
    public ProdutoPoco Put([FromBody]ProdutoPoco poco)
    {
        return this.servico.Alterar(poco);
    }

    [HttpDelete("[controller]/{chave}")] // deletar uma chave //
    public ProdutoPoco Delete(int chave)
    {
        return this.servico.Excluir(chave);
    }
}

