using System.Linq.Expressions;
using Atacado.BD.EF.Database;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repositorio;

public class CategoriaRepo : BaseAtacadoContextoRepo<Categoria> // ctrl+ponto para 1-"contrutor" 2-"class" //
{
    public CategoriaRepo(AtacadoContext ctx) : base(ctx)
    {
    }

    public override Categoria Create(Categoria obj)
    { // "SaveChanges" salvar obg add //
        this.contexto.Categorias.Add(obj);
        this.contexto.SaveChanges();
        return obj;
    }

    public override Categoria Delete(int codigo)
    { // "alvo" e o que vai ser apagado //
        Categoria alvo = this.Read(codigo);
        this.contexto.Categorias.Remove(alvo);
        this.contexto.SaveChanges();
        return alvo;
    }

    public override Categoria Read(int codigo)
    { // Isso procura no banco "Para cada 2 eu dou nome de item" //
        return this.contexto.Categorias.SingleOrDefault(item => item.Codigo == codigo);
    }

    public override List<Categoria> Read()
    {
        return this.contexto.Categorias.ToList();
    }

    public override List<Categoria> Read(Expression<Func<Categoria, bool>> predicado)
    {
        return this.contexto.Categorias.Where(predicado).ToList();  
    }

    public override Categoria Update(Categoria obj)
    { // EntityState.Modified -> "using Microsoft.EntityFrameworkCore"//
        this.contexto.Categorias.Attach(obj);
        this.contexto.Entry<Categoria>(obj).State = EntityState.Modified;
        this.contexto.SaveChanges();
        return obj;
    }
}
