using GerenciadorAutopecas.Controllers;
using GerenciadorAutopecas.Data;
using GerenciadorAutopecas.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorAutopecas.UI
{
    public partial class FormVender : Form
    {

        private readonly VendaController _vendaController;
        public FormVender()
        {
            InitializeComponent();
            _vendaController = new VendaController(NHibernateHelper.OpenSession());
        }

        private void FormVender_Load(object sender, EventArgs e)
        {
            try
            {
                // Carregar as peças disponíveis para venda
                var pecasDisponiveis = _vendaController.ListarPecasDisponiveis();

                cmbPecas.DisplayMember = "Nome"; // Nome da peça exibido no ComboBox
                cmbPecas.ValueMember = "Id"; // ID da peça como valor selecionado

                cmbPecas.DataSource = pecasDisponiveis;

                if (pecasDisponiveis.Count == 0)
                {
                    MessageBox.Show("Nenhuma peça disponível para venda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar as peças disponíveis: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar se uma peça foi selecionada e se o preço de venda foi preenchido
                if (cmbPecas.SelectedItem == null)
                {
                    MessageBox.Show("Selecione uma peça para vender.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(txtPrecoVenda.Text) || !decimal.TryParse(txtPrecoVenda.Text, out decimal precoVenda))
                {
                    MessageBox.Show("Insira um valor válido para o preço de venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obter a peça selecionada
                var pecaSelecionada = (Pecas)cmbPecas.SelectedItem;
                int idPeca = pecaSelecionada.Id;

                // Aplica o desconto se houver
                decimal? desconto = string.IsNullOrEmpty(txtDesconto.Text) ? (decimal?)null : decimal.Parse(txtDesconto.Text);

                // Chama o método para simular e registrar a venda
                _vendaController.SimularVenda(idPeca, desconto);

                // Atualiza a interface
                FormVender_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar a venda: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
