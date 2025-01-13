namespace GerenciadorAutopecas.UI
{
    partial class FormEditar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbPecas = new System.Windows.Forms.ComboBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblFabricante = new System.Windows.Forms.Label();
            this.txtFabricante = new System.Windows.Forms.TextBox();
            this.lblTipoVeiculo = new System.Windows.Forms.Label();
            this.txtTipoVeiculo = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.lblPrecoCompra = new System.Windows.Forms.Label();
            this.txtPrecoCompra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrecoVenda = new System.Windows.Forms.TextBox();
            this.lblDisponivel = new System.Windows.Forms.Label();
            this.cmbDisponivel = new System.Windows.Forms.ComboBox();
            this.lblPecas = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.brnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbPecas
            // 
            this.cmbPecas.FormattingEnabled = true;
            this.cmbPecas.Location = new System.Drawing.Point(321, 124);
            this.cmbPecas.Name = "cmbPecas";
            this.cmbPecas.Size = new System.Drawing.Size(179, 21);
            this.cmbPecas.TabIndex = 0;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(321, 175);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(179, 20);
            this.txtNome.TabIndex = 1;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(318, 159);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome:";
            // 
            // lblFabricante
            // 
            this.lblFabricante.AutoSize = true;
            this.lblFabricante.Location = new System.Drawing.Point(318, 208);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(60, 13);
            this.lblFabricante.TabIndex = 3;
            this.lblFabricante.Text = "Fabricante:";
            // 
            // txtFabricante
            // 
            this.txtFabricante.Location = new System.Drawing.Point(321, 224);
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.Size = new System.Drawing.Size(179, 20);
            this.txtFabricante.TabIndex = 4;
            // 
            // lblTipoVeiculo
            // 
            this.lblTipoVeiculo.AutoSize = true;
            this.lblTipoVeiculo.Location = new System.Drawing.Point(318, 256);
            this.lblTipoVeiculo.Name = "lblTipoVeiculo";
            this.lblTipoVeiculo.Size = new System.Drawing.Size(86, 13);
            this.lblTipoVeiculo.TabIndex = 5;
            this.lblTipoVeiculo.Text = "Tipo de Veículo:";
            // 
            // txtTipoVeiculo
            // 
            this.txtTipoVeiculo.Location = new System.Drawing.Point(321, 272);
            this.txtTipoVeiculo.Name = "txtTipoVeiculo";
            this.txtTipoVeiculo.Size = new System.Drawing.Size(179, 20);
            this.txtTipoVeiculo.TabIndex = 6;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(318, 305);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(55, 13);
            this.lblCategoria.TabIndex = 7;
            this.lblCategoria.Text = "Categoria:";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(321, 321);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(179, 20);
            this.txtCategoria.TabIndex = 8;
            // 
            // lblPrecoCompra
            // 
            this.lblPrecoCompra.AutoSize = true;
            this.lblPrecoCompra.Location = new System.Drawing.Point(318, 354);
            this.lblPrecoCompra.Name = "lblPrecoCompra";
            this.lblPrecoCompra.Size = new System.Drawing.Size(92, 13);
            this.lblPrecoCompra.TabIndex = 9;
            this.lblPrecoCompra.Text = "Preço de Compra:";
            this.lblPrecoCompra.Click += new System.EventHandler(this.lblPrecoCompra_Click);
            // 
            // txtPrecoCompra
            // 
            this.txtPrecoCompra.Location = new System.Drawing.Point(321, 370);
            this.txtPrecoCompra.Name = "txtPrecoCompra";
            this.txtPrecoCompra.Size = new System.Drawing.Size(179, 20);
            this.txtPrecoCompra.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Preço de Venda:";
            // 
            // txtPrecoVenda
            // 
            this.txtPrecoVenda.Location = new System.Drawing.Point(321, 420);
            this.txtPrecoVenda.Name = "txtPrecoVenda";
            this.txtPrecoVenda.Size = new System.Drawing.Size(179, 20);
            this.txtPrecoVenda.TabIndex = 12;
            // 
            // lblDisponivel
            // 
            this.lblDisponivel.AutoSize = true;
            this.lblDisponivel.Location = new System.Drawing.Point(318, 452);
            this.lblDisponivel.Name = "lblDisponivel";
            this.lblDisponivel.Size = new System.Drawing.Size(61, 13);
            this.lblDisponivel.TabIndex = 14;
            this.lblDisponivel.Text = "Disponível:";
            // 
            // cmbDisponivel
            // 
            this.cmbDisponivel.FormattingEnabled = true;
            this.cmbDisponivel.Location = new System.Drawing.Point(321, 469);
            this.cmbDisponivel.Name = "cmbDisponivel";
            this.cmbDisponivel.Size = new System.Drawing.Size(179, 21);
            this.cmbDisponivel.TabIndex = 15;
            // 
            // lblPecas
            // 
            this.lblPecas.AutoSize = true;
            this.lblPecas.Location = new System.Drawing.Point(321, 105);
            this.lblPecas.Name = "lblPecas";
            this.lblPecas.Size = new System.Drawing.Size(107, 13);
            this.lblPecas.TabIndex = 16;
            this.lblPecas.Text = "Selecione uma peça:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(321, 509);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // brnCancel
            // 
            this.brnCancel.Location = new System.Drawing.Point(425, 509);
            this.brnCancel.Name = "brnCancel";
            this.brnCancel.Size = new System.Drawing.Size(75, 23);
            this.brnCancel.TabIndex = 18;
            this.brnCancel.Text = "Cancelar";
            this.brnCancel.UseVisualStyleBackColor = true;
            this.brnCancel.Click += new System.EventHandler(this.brnCancel_Click);
            // 
            // FormEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 645);
            this.Controls.Add(this.brnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPecas);
            this.Controls.Add(this.cmbDisponivel);
            this.Controls.Add(this.lblDisponivel);
            this.Controls.Add(this.txtPrecoVenda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrecoCompra);
            this.Controls.Add(this.lblPrecoCompra);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtTipoVeiculo);
            this.Controls.Add(this.lblTipoVeiculo);
            this.Controls.Add(this.txtFabricante);
            this.Controls.Add(this.lblFabricante);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.cmbPecas);
            this.Name = "FormEditar";
            this.Text = "FormEditar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPecas;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblFabricante;
        private System.Windows.Forms.TextBox txtFabricante;
        private System.Windows.Forms.Label lblTipoVeiculo;
        private System.Windows.Forms.TextBox txtTipoVeiculo;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label lblPrecoCompra;
        private System.Windows.Forms.TextBox txtPrecoCompra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrecoVenda;
        private System.Windows.Forms.Label lblDisponivel;
        private System.Windows.Forms.ComboBox cmbDisponivel;
        private System.Windows.Forms.Label lblPecas;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button brnCancel;
    }
}