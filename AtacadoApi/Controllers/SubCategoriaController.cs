using Atacado.BD.EF.Database;
using Atacado.Poco;
using Atacado.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtacadoApi.Controllers;

[ApiController]
[Route("api/Atacado/Estoque/")]
// Controller //
public class SubCategoriaController : BaseController
{
    private SubCategoriaServico Servico;
    
    public SubCategoriaController() : base()
    {
        this.Servico = new SubCategoriaServico(this.contexto);
    }

    [HttpGet("SubCategorias")] // ver todos "GET ALL"//
    public List<SubCategoriaPoco> GetAll()
    {
        return this.Servico.Listar();
    }

    [HttpGet("SubCategorias/PorCategoria/{categoriaId}")] // Filtro de Pesquisa //
    public List<SubCategoriaPoco> GetByCategoriaId(int categoriaId)
    {
        return this.Servico.Listar(sub => sub.CodigoCategoria == categoriaId);
    }

    [HttpGet("[controller]/{id}")] // ver algo especifico //
    public SubCategoriaPoco GetById(int id)
    {
        return this.Servico.Ler(id);
    }

    [HttpPost("[controller]")] // add //
    public SubCategoriaPoco Post([FromBody]SubCategoriaPoco poco)
    {
        return this.Servico.Inserir(poco);
    }

    [HttpPut("[controller]")] // alterar //
    public SubCategoriaPoco Put([FromBody]SubCategoriaPoco poco)
    {
        return this.Servico.Alterar(poco);
    }

    [HttpDelete("[controller]/{chave}")] // deletar uma chave //
    public SubCategoriaPoco Delete(int chave)
    {
        return this.Servico.Excluir(chave);
    }
}