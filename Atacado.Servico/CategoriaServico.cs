using Atacado.BD.EF.Database;
using Atacado.Poco;
using Atacado.Repositorio;

namespace Atacado.Servico;

public class CategoriaServico : BaseAtacadoContextoServico<CategoriaPoco, Categoria> // ctrl+ponto para 1-"contrutor" 2-"class" //
{
    private CategoriaRepo repositorio;
    public CategoriaServico(AtacadoContext ctx) : base(ctx)
    {
        this.repositorio = new CategoriaRepo(ctx);
    }

    public override CategoriaPoco Alterar(CategoriaPoco poco)
    {
        Categoria tupla = this.Converter(poco);
        Categoria alterado = this.repositorio.Update(tupla);
        CategoriaPoco alteradoPoco = this.Converter(alterado);
        return alteradoPoco;
    }

    public override CategoriaPoco Excluir(int chave)
    {
        Categoria tupla = this.repositorio.Delete(chave);
        CategoriaPoco apagado = this.Converter(tupla);
        return apagado;
    }

    public override CategoriaPoco Inserir(CategoriaPoco poco)
    {
        Categoria dom = this.Converter(poco);
        Categoria novo = this.repositorio.Create(dom);
        CategoriaPoco novoPoco = this.Converter(novo);
        return novoPoco;
    }

    public override CategoriaPoco Ler(int chave)
    {
        Categoria tupla = this.repositorio.Read(chave);
        if (tupla == null)
        {
            return null;
        }
        else
        {
            CategoriaPoco poco = this.Converter(tupla);
            return poco;
        }
    }

    public override List<CategoriaPoco> Listar()
    {
        return this.repositorio.Read().Select(tupla => this.Converter(tupla)).ToList<CategoriaPoco>();
    }

        public override CategoriaPoco Converter(Categoria dom)
    {
        return new CategoriaPoco()
        {
            Codigo = dom.Codigo, Descricao = dom.Descricao, Ativo = dom.Ativo, DataInclusao = dom.DataInclusao
        };
    }

    public override Categoria Converter(CategoriaPoco poco)
    {
        return new Categoria()
        {
            Codigo = poco.Codigo, Descricao = poco.Descricao, Ativo = poco.Ativo, DataInclusao = poco.DataInclusao
        };
    }
}
