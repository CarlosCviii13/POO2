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

    [HttpGet("{id}")]
    public CategoriaPoco getById(int id)
    {
        return this.servico.Ler(id);
    }

    [HttpPost]
    public CategoriaPoco Post([FromBody]CategoriaPoco poco)
    {
        return this.servico.Inserir(poco);
    }

    [HttpPut]
    public CategoriaPoco Put([FromBody]CategoriaPoco poco)
    {
        return this.servico.Alterar(poco);
    }

    [HttpDelete]
    public CategoriaPoco Delete(int chave)
    {
        return this.servico.Excluir(chave);
    }
}
