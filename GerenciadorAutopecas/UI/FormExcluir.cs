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
    public partial class FormExcluir : Form
    {
        private PecasController _pecasController;
        public FormExcluir()
        {
            InitializeComponent();
            var session = NHibernateHelper.OpenSession();
            _pecasController = new PecasController(session);
        }

        private void FormExcluir_Load(object sender, EventArgs e)
        {
            try
            {
                // Carrega todas as peças ativas no ComboBox
                var pecas = _pecasController.ListarTodas();
                cmbPecas.DisplayMember = "Nome";
                cmbPecas.ValueMember = "Id";
                cmbPecas.DataSource = pecas;

                if (pecas.Count == 0)
                {
                    MessageBox.Show("Nenhuma peça disponível para exclusão.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar as peças: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se uma peça foi selecionada
                if (cmbPecas.SelectedItem == null)
                {
                    MessageBox.Show("Selecione uma peça para excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obter o ID da peça selecionada
                var pecaSelecionada = (Pecas)cmbPecas.SelectedItem;
                int idPeca = pecaSelecionada.Id;

                // Confirma a exclusão
                var confirmacao = MessageBox.Show("Tem certeza que deseja excluir esta peça?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmacao == DialogResult.Yes)
                {
                    // Chamar o método de exclusão no controlador
                    _pecasController.Excluir(idPeca);

                    MessageBox.Show("Peça excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Atualiza o ComboBox
                    FormExcluir_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir a peça: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
