using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GerenciadorAutopecas.Data.Models;
using GerenciadorAutopecas.Data.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace GerenciadorAutopecas.Controllers
{
    public class PecasController
    {
        private readonly PecasRepository _pecasRepository;
        private readonly ISession _session;

        public PecasController()
        {
        }

        public PecasController(ISession session)
        {
            _session = session;
            _pecasRepository = new PecasRepository(_session);
        }

        // Cadastro de peças
        public void Cadastrar(Pecas peca)
        {
            try
            {
                if (peca != null)
                {
                    _pecasRepository.Add(peca);
                    MessageBox.Show("Peça cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Os dados da peça são inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar a peça: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Consulta de peças
        public List<Pecas> Consultar(string nome = "", int? id = null)
        {
            try
            {
                var pecasQuery = _pecasRepository.GetAll();

                if (!string.IsNullOrEmpty(nome))
                {
                    pecasQuery = pecasQuery.Where(p => p.Nome.Contains(nome));
                }

                if (id.HasValue)
                {
                    pecasQuery = pecasQuery.Where(p => p.Id == id);
                }

                return pecasQuery.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar as peças: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Pecas>();
            }
        }

        // Edição de peças
        public void Editar(Pecas peca)
        {
            try
            {
                if (peca != null)
                {
                    _pecasRepository.Update(peca);
                    MessageBox.Show("Peça atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Peça não encontrada para edição.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar a peça: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Exclusão de peças com Soft delete
        public void Excluir(int id)
        {
            try
            {
                Pecas peca = _pecasRepository.GetById(id);
                if (peca == null)
                {
                    MessageBox.Show("Peça não encontrada para exclusão.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                peca.Status = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
                _pecasRepository.Update(peca);
                MessageBox.Show("Peça excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir a peça: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Exibição de todas as peças
        public List<Pecas> ListarTodas()
        {
            try
            {
                return _pecasRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar as peças: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Pecas>();
            }
        }
    }
}