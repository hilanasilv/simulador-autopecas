using GerenciadorAutopecas.Data;
using GerenciadorAutopecas.Data.Models;
using GerenciadorAutopecas.Data.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GerenciadorAutopecas.Controllers
{
    public class VendaController
    {
        private readonly VendaRepository _vendaRepository;
        private readonly PecasRepository _pecasRepository;
        private readonly ISession _session;

        public VendaController(ISession session)
        {
            _session = session;
            _vendaRepository = new VendaRepository(_session);
            _pecasRepository = new PecasRepository(_session);
        }

        public void SimularVenda(int pecaId, decimal? desconto)
        {
            try
            {
                Pecas peca = _pecasRepository.GetById(pecaId);
                if (peca == null)
                {
                    MessageBox.Show("Peça não encontrada.");
                    return;
                }

                if (peca.Status != null)
                {
                    MessageBox.Show("Peça já foi vendida ou está indisponível.");
                    return;
                }

                decimal valorVenda = peca.PrecoVenda;
                if (desconto.HasValue)
                {
                    valorVenda -= valorVenda * (desconto.Value / 100);
                }

                var venda = new Venda
                {
                    IdPeca = peca.Id,
                    ValorVenda = valorVenda,
                    DataVenda = DateTime.Now
                };

                _vendaRepository.Add(venda);

                peca.Status = "Vendida - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm");
                _pecasRepository.Update(peca);

                MessageBox.Show("Venda realizada com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar a venda: " + ex.Message);
            }
        }

        public List<Pecas> ListarPecasDisponiveis()
        {
            try
            {
                // Filtra peças que estão disponíveis (Disponivel == "sim" e Status == null)
                var pecasDisponiveis = _pecasRepository.GetAll()
                    .Where(p => p.Disponivel == "sim" && p.Status == null)
                    .ToList();

                return pecasDisponiveis;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar peças disponíveis: " + ex.Message);
                return new List<Pecas>();
            }
        }

    }
}
