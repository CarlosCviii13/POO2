using Atacado.BD.EF.Database;

namespace Atacado.Servico;

public abstract class BaseAtacadoContextoServico<TPoco, TDominioEF> : BaseServico<TPoco, TDominioEF>
where TPoco : class
where TDominioEF : class
{
    protected AtacadoContext context;
    public BaseAtacadoContextoServico(AtacadoContext ctx) : base()
    {
        this.context = ctx;
    }
}
