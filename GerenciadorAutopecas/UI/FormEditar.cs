using GerenciadorAutopecas.Controllers;
using GerenciadorAutopecas.Data.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GerenciadorAutopecas.UI
{
    public partial class FormEditar : Form
    {
        private readonly PecasController _pecasController;
        public FormEditar()
        {
            InitializeComponent();
            _pecasController = new PecasController();
        }

        private void FormEditar_Load(object sender, EventArgs e)
        {

            // Criar uma lista com as opções "Sim" e "Não" para indicar a disponibilidade da peça
            var opcoesDisponibilidade = new List<string> { "Sim", "Não" };

            // Atribui a lista ao ComboBox
            cmbDisponivel.DataSource = opcoesDisponibilidade;

            // Carregar as peças no ComboBox
            CarregarPecas();
        }

        private void cmbPecas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar se há uma peça selecionada no ComboBox
            if (cmbPecas.SelectedItem != null)
            {
                // Obter a peça selecionada do ComboBox
                var selectedPeca = (Pecas)cmbPecas.SelectedItem;

                // Campos que podem ser editados
                txtNome.Text = selectedPeca.Nome;
                txtFabricante.Text = selectedPeca.Fabricante;
                txtTipoVeiculo.Text = selectedPeca.TipoVeiculo;
                txtCategoria.Text = selectedPeca.Categoria;
                txtPrecoCompra.Text = selectedPeca.PrecoCompra.ToString();
                txtPrecoVenda.Text = selectedPeca.PrecoVenda.ToString();
                cmbDisponivel.Text = selectedPeca.Disponivel;

                cmbDisponivel.SelectedItem = selectedPeca.Disponivel == "Sim" ? "Sim" : "Não";
            }
        }

        private void CarregarPecas()
        {
            // Obter todas as peças do banco de dados
            var pecas = _pecasController.ListarTodas();

            // Preencher o ComboBox com as peças
            cmbPecas.DataSource = pecas;
            cmbPecas.DisplayMember = "Nome";  
            cmbPecas.ValueMember = "Id";     
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Verificar se uma peça foi selecionada
            if (cmbPecas.SelectedItem != null)
            {
                // Obter a peça selecionada
                var selectedPeca = (Pecas)cmbPecas.SelectedItem;

                if (!string.IsNullOrEmpty(txtNome.Text)) selectedPeca.Nome = txtNome.Text;
                if (!string.IsNullOrEmpty(txtFabricante.Text)) selectedPeca.Fabricante = txtFabricante.Text;
                if (!string.IsNullOrEmpty(txtTipoVeiculo.Text)) selectedPeca.TipoVeiculo = txtTipoVeiculo.Text;
                if (!string.IsNullOrEmpty(txtCategoria.Text)) selectedPeca.Categoria = txtCategoria.Text;
                if (decimal.TryParse(txtPrecoCompra.Text, out decimal precoCompra)) selectedPeca.PrecoCompra = precoCompra;
                if (decimal.TryParse(txtPrecoVenda.Text, out decimal precoVenda)) selectedPeca.PrecoVenda = precoVenda;
                if (!string.IsNullOrEmpty(cmbDisponivel.Text)) selectedPeca.Disponivel = cmbDisponivel.Text;

                // Atualizar a peça no banco de dados
                _pecasController.Editar(selectedPeca);

                MessageBox.Show("Peça editada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Selecione uma peça para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void brnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPrecoCompra_Click(object sender, EventArgs e)
        {

        }
    }
}
