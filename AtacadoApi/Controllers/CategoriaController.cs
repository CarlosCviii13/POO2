using Atacado.BD.EF.Database;
using Atacado.Poco;
using Atacado.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtacadoApi.Controllers;

[ApiController]
[Route("api/Atacado/Estoque/")]
// Controller //
public class CategoriaController : BaseController
{
    private CategoriaServico servico;
    public CategoriaController() : base()
    {
        this.servico = new CategoriaServico(this.contexto);
    }

    [HttpGet("Categorias")] // ver todos "GET ALL"//
    public List<CategoriaPoco> GetAll()
    {
        return this.servico.Listar();
    }

    [HttpGet("[controller]/{id}")] // ver algo especifico //
    public CategoriaPoco getById(int id)
    {
        return this.servico.Ler(id);
    }

    [HttpPost("[controller]")] // add //
    public CategoriaPoco Post([FromBody]CategoriaPoco poco)
    {
        return this.servico.Inserir(poco);
    }

    [HttpPut("[controller]")] // alterar //
    public CategoriaPoco Put([FromBody]CategoriaPoco poco)
    {
        return this.servico.Alterar(poco);
    }

    [HttpDelete("[controller]/{chave}")] // deletar uma chave //
    public CategoriaPoco Delete(int chave)
    {
        return this.servico.Excluir(chave);
    }
}
