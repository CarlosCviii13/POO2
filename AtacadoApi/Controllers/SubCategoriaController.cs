using Atacado.BD.EF.Database;
using Atacado.Poco;
using Atacado.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtacadoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubCategoriaController : BaseController
{
    private SubCategoriaServico servico;
    public SubCategoriaController() : base()
    {
        this.servico = new SubCategoriaServico(this.contexto);
    }

    [HttpGet]
    public List<SubCategoriaPoco> GetAll()
    {
        return this.servico.Listar();
    }

    [HttpGet("{id}")]
    public SubCategoriaPoco getById(int id)
    {
        return this.servico.Ler(id);
    }

    [HttpPost]
    public SubCategoriaPoco Post([FromBody]SubCategoriaPoco poco)
    {
        return this.servico.Inserir(poco);
    }

    [HttpPut]
    public SubCategoriaPoco Put([FromBody]SubCategoriaPoco poco)
    {
        return this.servico.Alterar(poco);
    }

    [HttpDelete]
    public SubCategoriaPoco Delete(int chave)
    {
        return this.servico.Excluir(chave);
    }
}