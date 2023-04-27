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
        throw new NotImplementedException();
    }

    public override CategoriaPoco Excluir(CategoriaPoco chave)
    {
        throw new NotImplementedException();
    }

    public override CategoriaPoco Inserir(CategoriaPoco poco)
    {
        throw new NotImplementedException();
    }

    public override CategoriaPoco Ler(int chave)
    {
        throw new NotImplementedException();
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
