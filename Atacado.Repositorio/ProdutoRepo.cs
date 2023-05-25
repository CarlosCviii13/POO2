using System.Linq.Expressions;
using Atacado.BD.EF.Database;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repositorio;

public class ProdutoRepo : BaseAtacadoContextoRepo<Produto>
{
    public ProdutoRepo(AtacadoContext ctx) : base(ctx)
    {
    }

    public override Produto Create(Produto obj)
    {
        this.contexto.Produtos.Add(obj);
        this.contexto.SaveChanges();
        return obj;
    }

    public override Produto Delete(int codigo)
    {
        Produto alvo = this.Read(codigo);
        this.contexto.Produtos.Remove(alvo);
        this.contexto.SaveChanges();
        return alvo;
    }

    public override Produto Read(int codigo)
    {
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
    {
        this.contexto.Produtos.Attach(obj);
        this.contexto.Entry<Produto>(obj).State 
            = EntityState.Modified;
        this.contexto.SaveChanges();
        return obj;
    }
}
