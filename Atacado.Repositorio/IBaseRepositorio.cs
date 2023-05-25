using System.Linq.Expressions;

namespace Atacado.Repositorio;

// Modelo de ID repositorio "não e uma classe abistrata e sim real!" //
public interface IBaseRepositorio<TEntidade> where TEntidade : class
{
    TEntidade Create(TEntidade obj);

    TEntidade Read(int codigo);

    List<TEntidade> Read();

    IQueryable<TEntidade> Read(Expression<Func<TEntidade, bool>> predicado);

    TEntidade Update(TEntidade obj);

    TEntidade Delete(int codigo);
}
