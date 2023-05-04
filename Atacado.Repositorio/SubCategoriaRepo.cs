using Atacado.BD.EF.Database;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repositorio;

public class SubCategoriaRepo : BaseAtacadoContextoRepo<SubCategoria> // ctrl+ponto para 1-"contrutor" 2-"class" //
{
    public SubCategoriaRepo(AtacadoContext ctx) : base(ctx)
    {
    }

    public override SubCategoria Create(SubCategoria obj)
    { // "SaveChanges" salvar obg add //
        this.contexto.SubCategorias.Add(obj);
        this.contexto.SaveChanges();
        return obj;
    }

    public override SubCategoria Delete(int codigo)
    { // "alvo" e o que vai ser apagado //
        SubCategoria alvo = this.Read(codigo);
        this.contexto.SubCategorias.Remove(alvo);
        this.contexto.SaveChanges();
        return alvo;
    }

    public override SubCategoria Read(int codigo)
    { // Isso procura no banco "Para cada 2 eu dou nome de item" //
        return this.contexto.SubCategorias.SingleOrDefault(item => item.Codigo == codigo);
    }

    public override List<SubCategoria> Read()
    {
        return this.contexto.SubCategorias.ToList();
    }

    public override SubCategoria Update(SubCategoria obj)
    { // EntityState.Modified -> "using Microsoft.EntityFrameworkCore"//
        this.contexto.SubCategorias.Attach(obj);
        this.contexto.Entry<SubCategoria>(obj).State = EntityState.Modified;
        this.contexto.SaveChanges();
        return obj;
    }
}
