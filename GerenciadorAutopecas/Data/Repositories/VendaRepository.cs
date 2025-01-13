using NHibernate;
using System.Collections.Generic;
using System.Linq;
using GerenciadorAutopecas.Data.Models;

namespace GerenciadorAutopecas.Data.Repositories
{
    public class VendaRepository
    {
        private readonly ISession _session;
        public VendaRepository()
        {
            _session = NHibernateHelper.OpenSession();
        }

        public VendaRepository(ISession session)
        {
            _session = session;
        }

        // Adiciona uma venda ao banco de dados e atualiza a disponibilidade da peça
        public void Add(Venda venda)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    // Salva a venda
                    _session.Save(venda);

                    // Busca a peça correspondente à venda
                    var peca = _session.Get<Pecas>(venda.IdPeca);
                    if (peca != null)
                    {
                        // Atualiza a disponibilidade da peça para "não"
                        peca.Disponivel = "não";
                        _session.Update(peca);
                    }

                    // Confirma a transação
                    transaction.Commit();
                }
                catch
                {
                    // Em caso de erro, desfaz a transação
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // Método para listar todas as vendas
        public IList<Venda> GetAll()
        {
            return _session.Query<Venda>().ToList();
        }
    }
}
