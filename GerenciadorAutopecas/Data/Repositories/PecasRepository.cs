using GerenciadorAutopecas.Data.Models;
using System;
using NHibernate;
using System.Linq;


namespace GerenciadorAutopecas.Data.Repositories
{
    public class PecasRepository
    {
        private readonly ISession _session;

        public PecasRepository()
        {
            _session = NHibernateHelper.OpenSession();
        }

        public PecasRepository(ISession session)
        {
            _session = session;
        }

        // Método para obter todas as peças
        public IQueryable<Pecas> GetAll()
        {
            // Retorna uma consulta LINQ para obter todas as peças
            return _session.Query<Pecas>().Where(p => p.Status == null);
        }
        public Pecas GetById(int id)
        {
            return _session.Get<Pecas>(id);
        }

        public IQueryable<Pecas> SearchByNameOrId(string searchTerm)
        {
            // Tenta converter o searchTerm para um número inteiro (caso seja um ID)
            if (int.TryParse(searchTerm, out int id))
            {
                // Se for um ID válido, busca por ID
                return _session.Query<Pecas>().Where(p => p.Id == id && p.Status == null);
            }
            else
            {
                // Se não for um ID, busca pelo nome da peça
                return _session.Query<Pecas>().Where(p => p.Nome.Contains(searchTerm) && p.Status == null);
            }
        }

        // Método para Cadastrar uma peça
        public void Add(Pecas peca)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(peca);
                transaction.Commit();
            }
        }

        //Método para Atualizar uma peça
        public void Update(Pecas peca)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Update(peca);
                transaction.Commit();
            }
        }

        // Método para Deletar uma peça
        public void SoftDelete(int id)
        {
            var peca = _session.Get<Pecas>(id);
            if (peca != null)
            {
                peca.Status = DateTime.Now.ToString("dd-MM-yyyy HH:mm");  // Exibe a data de exclusão no formato ISO
                Update(peca);
            }
        }
    }
}