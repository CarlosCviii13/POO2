using Atacado.BD.EF.Database;
using Atacado.Poco;
using Atacado.Repositorio;

namespace Atacado.Servico;

public class SubCategoriaServico : BaseAtacadoContextoServico<SubCategoriaPoco, SubCategoria> // ctrl+ponto para 1-"contrutor" 2-"class" //
{
    private SubCategoriaRepo repositorio;
    public SubCategoriaServico(AtacadoContext ctx) : base(ctx)
    {
        this.repositorio = new SubCategoriaRepo(ctx);
    }

    public override SubCategoriaPoco Alterar(SubCategoriaPoco poco)
    {
        SubCategoria tupla = this.Converter(poco);
        SubCategoria alterado = this.repositorio.Update(tupla);
        SubCategoriaPoco alteradoPoco = this.Converter(alterado);
        return alteradoPoco;
    }

    public override SubCategoriaPoco Excluir(int chave)
    {
        SubCategoria tupla = this.repositorio.Delete(chave);
        SubCategoriaPoco apagado = this.Converter(tupla);
        return apagado;
    }

    public override SubCategoriaPoco Inserir(SubCategoriaPoco poco)
    {
        SubCategoria dom = this.Converter(poco);
        SubCategoria novo = this.repositorio.Create(dom);
        SubCategoriaPoco novoPoco = this.Converter(novo);
        return novoPoco;
    }

    public override SubCategoriaPoco Ler(int chave)
    {
        SubCategoria tupla = this.repositorio.Read(chave);
        if (tupla == null)
        {
            return null;
        }
        else
        {
            SubCategoriaPoco poco = this.Converter(tupla);
            return poco;
        }
    }

    public override List<SubCategoriaPoco> Listar()
    {
        return this.repositorio.Read().Select(tupla => this.Converter(tupla)).ToList<SubCategoriaPoco>();
    }

        public override SubCategoriaPoco Converter(SubCategoria dom)
    {
        return new SubCategoriaPoco()
        {
            Codigo = dom.Codigo, CodigoCategoria = dom.CodigoCategoria, Descricao = dom.Descricao, Ativo = dom.Ativo, DataInclusao = dom.DataInclusao
        };
    }

    public override SubCategoria Converter(SubCategoriaPoco poco)
    {
        return new SubCategoria()
        {
            Codigo = poco.Codigo, CodigoCategoria = poco.CodigoCategoria, Descricao = poco.Descricao, Ativo = poco.Ativo, DataInclusao = poco.DataInclusao
        };
    }
}
