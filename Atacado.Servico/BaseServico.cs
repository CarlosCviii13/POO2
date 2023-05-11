using System.Linq.Expressions;
namespace Atacado.Servico;
// Em serviço tem dois "<T, T>"
public abstract class BaseServico<TPoco, TDominioEF> where TPoco : class where TDominioEF : class
{
    public abstract List<TPoco> Listar(); // Listar //

    public abstract List<TPoco> Listar(Expression<Func<TDominioEF, bool>> predicado);

    public abstract TPoco Ler(int chave); // Ler //

    public abstract TPoco Inserir(TPoco poco); // Inserir //

    public abstract TPoco Alterar(TPoco poco); // Alterar //

    public abstract TPoco Excluir(int chave); // Excluir //

    public abstract TPoco Converter(TDominioEF dom); // Converter EF //

    public abstract TDominioEF Converter(TPoco poco); // Converter Poco //
}
