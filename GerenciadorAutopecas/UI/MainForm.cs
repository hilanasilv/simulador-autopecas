using GerenciadorAutopecas.Data.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GerenciadorAutopecas.UI
{
    public partial class MainForm : Form
    {
        private readonly PecasRepository _pecasRepository;
        public MainForm()
        {
            InitializeComponent();
            _pecasRepository = new PecasRepository();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtBusca.Text.Trim();

                // Se o campo de busca estiver vazio, retorna todas as peças
                var pecas = string.IsNullOrEmpty(searchTerm)
                    ? _pecasRepository.GetAll().ToList()
                    : _pecasRepository.SearchByNameOrId(searchTerm).ToList();

                // Configuração das colunas do DataGridView
                dgvResultados.AutoGenerateColumns = false;
                dgvResultados.Columns.Clear();

                dgvResultados.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Id",
                    HeaderText = "ID",
                    DataPropertyName = "Id"
                });
                dgvResultados.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Nome",
                    HeaderText = "Nome",
                    DataPropertyName = "Nome"
                });
                dgvResultados.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Fabricante",
                    HeaderText = "Fabricante",
                    DataPropertyName = "Fabricante"
                });

                dgvResultados.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TipoVeiculo",
                    HeaderText = "Tipo de Veículo",
                    DataPropertyName = "TipoVeiculo"
                });

                dgvResultados.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Categoria",
                    HeaderText = "Categoria",
                    DataPropertyName = "Categoria"
                });

                dgvResultados.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "PrecoCompra",
                    HeaderText = "Preço de Compra",
                    DataPropertyName = "PrecoCompra"
                });

                dgvResultados.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "PrecoVenda",
                    HeaderText = "Preço de Venda",
                    DataPropertyName = "PrecoVenda"
                });

                dgvResultados.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Disponivel",
                    HeaderText = "Disponível",
                    DataPropertyName = "Disponivel"
                });

                // Exibe os resultados no DataGridView
                dgvResultados.DataSource = pecas.Select(p => new
                {
                    p.Id,
                    p.Nome,
                    p.Fabricante,
                    p.TipoVeiculo,
                    p.Categoria,
                    PrecoCompra = p.PrecoCompra.ToString("C"),
                    PrecoVenda = p.PrecoVenda.ToString("C"),
                    Disponivel = p.Disponivel == "S" ? "Sim" : "Não"
                }).ToList();

                // Limpa o campo de busca
                txtBusca.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar peças: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        // Exibe os formulários quando os botões são clicados
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormCadastro formCadastro = new FormCadastro();
            formCadastro.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormEditar formEditar = new FormEditar();
            formEditar.ShowDialog();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            FormExcluir formExcluir = new FormExcluir();
            formExcluir.ShowDialog();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            FormVender formVender = new FormVender();
            formVender.ShowDialog();
        }
    }
}
