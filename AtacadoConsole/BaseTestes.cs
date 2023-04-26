using Atacado.BD.EF.Database;

namespace AtacadoConsole;

public abstract class BaseTestes
{
    protected AtacadoContext context;
    public BaseTestes(AtacadoContext contexto)
    {
        this.context = contexto;
    }

    public abstract void Imprimir();
}
