using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repositorio;

// Ctrol + ponto em "Ibase" criar modelo de class real //
// Contexto? "atacado-contx" //
// Classe geral qualquer contexto //
public class GenericoRepositorio<TDominio> : IBaseRepositorio<TDominio> where TDominio : class
{
    // Qualquer ponte pra Qualquer banco //
    private DbContext contexto;

    // representa qualquer tabela //
    private DbSet<TDominio> tabela;

    public GenericoRepositorio(DbContext ctx)
    {
        this.contexto = ctx;
        this.tabela = this.contexto.Set<TDominio>();
    }

    // Base "CRUD" em repositorio //
    public TDominio Create(TDominio obj)
    {
        this.tabela.Add(obj);
        this.contexto.SaveChanges();
        return obj;
    }

    public TDominio Delete(int codigo)
    {
        TDominio alvo = this.Read(codigo);
        this.tabela.Remove(alvo);
        this.contexto.SaveChanges();
        return alvo;
    }

    public TDominio Read(int codigo)
    {
        return this.tabela.Find(codigo);
    }

    public List<TDominio> Read()
    {
        return this.tabela.ToList();
    }

    public IQueryable<TDominio> Read(Expression<Func<TDominio, bool>> predicado)
    {
        return this.tabela.Where(predicado);
    }

    public TDominio Update(TDominio obj)
    {
        this.tabela.Attach(obj);
        this.contexto.Entry(obj).State = EntityState.Modified;
        this.contexto.SaveChanges();
        return obj;
    }
}
