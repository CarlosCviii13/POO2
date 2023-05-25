using System.Linq.Expressions;
using Atacado.BD.EF.Database;
using Atacado.Poco;
using Atacado.Repositorio;

namespace Atacado.Servico;

public class ProdutoServico
    : BaseAtacadoContextoServico<ProdutoPoco, Produto>
{
    private ProdutoRepo repositorio;

    public ProdutoServico(AtacadoContext ctx) : base(ctx)
    {
        this.repositorio = new ProdutoRepo(ctx);
    }

    public override ProdutoPoco Alterar(ProdutoPoco poco)
    {
        Produto tupla = this.Converter(poco);
        Produto alterado = this.repositorio.Update(tupla);
        ProdutoPoco alteradoPoco = this.Converter(alterado);
        return alteradoPoco;
    }

    public override ProdutoPoco Excluir(int chave)
    {
        Produto tupla = this.repositorio.Delete(chave);
        ProdutoPoco apagado = this.Converter(tupla);
        return apagado;
    }

    public override ProdutoPoco Inserir(ProdutoPoco poco)
    {
        Produto dom = this.Converter(poco);
        Produto novo = this.repositorio.Create(dom);
        ProdutoPoco novoPoco = this.Converter(novo);
        return novoPoco;
    }

    public override ProdutoPoco Ler(int chave)
    {
        Produto tupla = this.repositorio.Read(chave);
        if (tupla == null)
        {
            return null;
        }
        else
        {
            ProdutoPoco poco = this.Converter(tupla);
            return poco;
        }
    }

    public override List<ProdutoPoco> Listar()
    {
        return this.repositorio.Read()
            .Select(tupla => this.Converter(tupla))
            .ToList<ProdutoPoco>();
    }

    public override ProdutoPoco Converter(Produto dom)
    {
        return new ProdutoPoco()
        {
            Codigo = dom.Codigo,
            CodigoSubCategoria = dom.CodigoSubCategoria,
            Valor = dom.Valor,
            Descricao = dom.Descricao,
            Ativo = dom.Ativo,
            DataInclusao = dom.DataInclusao,
            CodigoCategoria = dom.CodigoSubCategoria
        };
    }

    public override Produto Converter(ProdutoPoco poco)
    {
        return new Produto()
        {
            Codigo = poco.Codigo,
            CodigoSubCategoria = poco.CodigoSubCategoria,
            Valor = poco.Valor,
            Descricao = poco.Descricao,
            Ativo = poco.Ativo,
            DataInclusao = poco.DataInclusao,
            CodigoCategoria = poco.CodigoCategoria
        };
    }

    public override List<ProdutoPoco> Listar(Expression<Func<Produto, bool>> predicado)
    {
        return this.repositorio.Read(predicado)
            .Select(tupla => this.Converter(tupla))
            .ToList<ProdutoPoco>();
    }
}


