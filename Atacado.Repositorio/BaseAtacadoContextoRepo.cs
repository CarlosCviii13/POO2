using Atacado.BD.EF.Database;

namespace Atacado.Repositorio;
// T-Qual.quer.nome //
public abstract class BaseAtacadoContextoRepo<TRopo> : BaseRepositorio<TRopo> where TRopo : class
{ // "ctx" pode ser qualquer nome
    protected AtacadoContext contexto;

    public BaseAtacadoContextoRepo(AtacadoContext ctx) : base()
    {
        this.contexto = ctx;
    }
}
