using System.Linq.Expressions;
using Atacado.BD.EF.Database;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repositorio;

public class ProdutoRepo : BaseAtacadoContextoRepo<Produto> // ctrl+ponto para 1-"contrutor" 2-"class" //
{
    public ProdutoRepo(AtacadoContext ctx) : base(ctx)
    {
    }

    public override Produto Create(Produto obj)
    { // "SaveChanges" salvar obg add //
        this.contexto.Produtos.Add(obj);
        this.contexto.SaveChanges();
        return obj;
    }

    public override Produto Delete(int codigo)
    { // "alvo" e o que vai ser apagado //
        Produto alvo = this.Read(codigo);
        this.contexto.Produtos.Remove(alvo);
        this.contexto.SaveChanges();
        return alvo;
    }

    public override Produto Read(int codigo)
    { // Isso procura no banco "Para cada 2 eu dou nome de item" //
        return this.contexto.Produtos.SingleOrDefault(item => item.Codigo == codigo);
    }

    public override List<Produto> Read()
    {
        return this.contexto.Produtos.ToList();
    }

    public override List<Produto> Read(Expression<Func<Produto, bool>> predicado)
    {
        return this.contexto.Produtos.Where(predicado).ToList();  
    }

    public override Produto Update(Produto obj)
    { // EntityState.Modified -> "using Microsoft.EntityFrameworkCore"//
        this.contexto.Produtos.Attach(obj);
        this.contexto.Entry<Produto>(obj).State 
            = EntityState.Modified;
        this.contexto.SaveChanges();
        return obj;
    }
}
