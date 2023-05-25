using System.Linq.Expressions;
using Atacado.BD.EF.Database;
using Atacado.Poco;
using Atacado.Repositorio;

namespace Atacado.Servico;

public class ProfissaoServico : BaseAtacadoContextoServico<ProfissaoPoco, Profissao>
{
    private GenericoRepositorio<Profissao> repositorio;

    public ProfissaoServico(AtacadoContext ctx) : base(ctx)
    {
        this.repositorio = new GenericoRepositorio<Profissao>(ctx);
    }

    public override ProfissaoPoco Alterar(ProfissaoPoco poco)
    {
        Profissao tupla = this.Converter(poco);
        Profissao alterado = this.repositorio.Update(tupla);
        //ProfissaoPoco alteradoPoco = this.Converter(alterado);
        ProfissaoPoco alteradoPoco = this.Converter(alterado);
        return alteradoPoco;
    }

    public override ProfissaoPoco Converter(Profissao dom)
    {
        return new ProfissaoPoco()
        {
            Ativo = dom.Ativo,
            DataInsert = dom.DataInsert,
            Descricao = dom.Descricao,
            ProfissaoID = dom.ProfissaoID
        };
    }

    public override Profissao Converter(ProfissaoPoco poco)
    {
        return new Profissao()
        {
            Ativo = poco.Ativo,
            DataInsert = poco.DataInsert,
            Descricao = poco.Descricao,
            ProfissaoID = poco.ProfissaoID
        };
    }

    public override ProfissaoPoco Excluir(int chave)
    {
        Profissao tupla = this.repositorio.Delete(chave);
        ProfissaoPoco apagado = this.Converter(tupla);
        return apagado;
    }

    public override ProfissaoPoco Inserir(ProfissaoPoco poco)
    {
        Profissao dom = this.Converter(poco);
        Profissao novo = this.repositorio.Create(dom);
        ProfissaoPoco novoPoco = this.Converter(novo);
        return novoPoco;
    }

    public override ProfissaoPoco Ler(int chave)
    {
        Profissao tupla = this.repositorio.Read(chave);
        if (tupla == null)
        {
            return null;
        }
        else
        {
            ProfissaoPoco poco = this.Converter(tupla);
            return poco;
        }
    }

    public override List<ProfissaoPoco> Listar()
    {
        return this.repositorio.Read().Select(tupla => this.Converter(tupla)).ToList<ProfissaoPoco>();
    }
    
    public override List<ProfissaoPoco> Listar(Expression<Func<Profissao, bool>> predicado)
    {
        return this.repositorio.Read(predicado).Select(tupla => this.Converter(tupla)).ToList<ProfissaoPoco>();
    }
}
