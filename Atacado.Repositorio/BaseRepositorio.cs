using System.Linq.Expressions;
namespace Atacado.Repositorio;
// T-Qual.quer.nome //
public abstract class BaseRepositorio<TEntidade> where TEntidade : class
{
    // Base "CRUD" em repositorio //
    public abstract TEntidade Create(TEntidade obj);

    public abstract TEntidade Read(int codigo);

    public abstract List<TEntidade> Read();

    public abstract List<TEntidade> Read(Expression<Func<TEntidade, bool>> predicado);

    public abstract TEntidade Update(TEntidade obj);

    public abstract TEntidade Delete(int codigo);
}
