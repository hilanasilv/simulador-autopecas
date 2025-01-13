using GerenciadorAutopecas.Controllers;
using GerenciadorAutopecas.Data;
using GerenciadorAutopecas.Data.Models;
using System;
using System.Windows.Forms;

namespace GerenciadorAutopecas.UI
{
    public partial class FormCadastro : Form
    {
        private PecasController _pecasController;
        public FormCadastro()
        {
            InitializeComponent();
            var session = NHibernateHelper.OpenSession();
            _pecasController = new PecasController(session);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se todos os campos obrigatórios estão preenchidos
                if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtFabricante.Text) ||
                    string.IsNullOrEmpty(txtTipoVeiculo.Text) || string.IsNullOrEmpty(txtCategoria.Text) ||
                    string.IsNullOrEmpty(txtPrecoCompra.Text) || string.IsNullOrEmpty(txtPrecoVenda.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Pecas novaPeca = new Pecas
                {
                    Nome = txtNome.Text,
                    Fabricante = txtFabricante.Text,
                    TipoVeiculo = txtTipoVeiculo.Text,
                    Categoria = txtCategoria.Text,
                    PrecoCompra = decimal.Parse(txtPrecoCompra.Text),
                    PrecoVenda = decimal.Parse(txtPrecoVenda.Text),

                    // Define o Status como "ativa" e Disponivel como "sim" por padrão
                    Status = "ativa", 
                    Disponivel = "Sim"
                };

                // Chama o controller para adicionar a peça
                _pecasController.Cadastrar(novaPeca);

                MessageBox.Show("Peça cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpa os campos após o cadastro
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar a peça: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtFabricante.Clear();
            txtTipoVeiculo.Clear();
            txtCategoria.Clear();
            txtPrecoCompra.Clear();
            txtPrecoVenda.Clear();
        }
    }
}
