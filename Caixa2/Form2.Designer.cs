namespace Caixa2
{
    partial class Form2
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnSalvarAlt = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txbQuantEstoque = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txbValor = new System.Windows.Forms.TextBox();
            this.txbCod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbConsulta = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(389, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "Nome do Produto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(389, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "Quantidade em ESTOQUE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Valor";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(723, 295);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(211, 23);
            this.button5.TabIndex = 29;
            this.button5.Text = "Adicionar foto";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(841, 54);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(392, 266);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(284, 23);
            this.btnDeletar.TabIndex = 26;
            this.btnDeletar.Text = "Deletar item";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnSalvarAlt
            // 
            this.btnSalvarAlt.Location = new System.Drawing.Point(8, 266);
            this.btnSalvarAlt.Name = "btnSalvarAlt";
            this.btnSalvarAlt.Size = new System.Drawing.Size(284, 23);
            this.btnSalvarAlt.TabIndex = 25;
            this.btnSalvarAlt.Text = "Salvar Alterações";
            this.btnSalvarAlt.UseVisualStyleBackColor = true;
            this.btnSalvarAlt.Click += new System.EventHandler(this.btnSalvarAlt_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(723, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 206);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // txbQuantEstoque
            // 
            this.txbQuantEstoque.Location = new System.Drawing.Point(392, 210);
            this.txbQuantEstoque.Name = "txbQuantEstoque";
            this.txbQuantEstoque.Size = new System.Drawing.Size(284, 20);
            this.txbQuantEstoque.TabIndex = 23;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(392, 99);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(284, 20);
            this.textBox3.TabIndex = 22;
            // 
            // txbValor
            // 
            this.txbValor.Location = new System.Drawing.Point(8, 210);
            this.txbValor.Name = "txbValor";
            this.txbValor.Size = new System.Drawing.Size(284, 20);
            this.txbValor.TabIndex = 21;
            // 
            // txbCod
            // 
            this.txbCod.Location = new System.Drawing.Point(12, 99);
            this.txbCod.Name = "txbCod";
            this.txbCod.Size = new System.Drawing.Size(280, 20);
            this.txbCod.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Cod. Produto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Alterar produtos";
            // 
            // txbConsulta
            // 
            this.txbConsulta.Location = new System.Drawing.Point(174, 9);
            this.txbConsulta.Name = "txbConsulta";
            this.txbConsulta.Size = new System.Drawing.Size(294, 20);
            this.txbConsulta.TabIndex = 33;
            this.txbConsulta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txbConsulta_KeyUp);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 347);
            this.Controls.Add(this.txbConsulta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnSalvarAlt);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txbQuantEstoque);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txbValor);
            this.Controls.Add(this.txbCod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnSalvarAlt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txbQuantEstoque;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txbValor;
        private System.Windows.Forms.TextBox txbCod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbConsulta;
    }
}