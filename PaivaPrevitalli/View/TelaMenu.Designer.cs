
namespace PaivaPrevitalli.View
{
    partial class TelaMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sairToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelTitLogUsu = new System.Windows.Forms.Label();
            this.buttonLogarUsu = new System.Windows.Forms.Button();
            this.labelSenUsu = new System.Windows.Forms.Label();
            this.labelLogUsu = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.labelCadUsu = new System.Windows.Forms.Label();
            this.buttonCadUsu = new System.Windows.Forms.Button();
            this.labelSenCadUsu = new System.Windows.Forms.Label();
            this.labelLogCadUsu = new System.Windows.Forms.Label();
            this.textBoxSenCadUsu = new System.Windows.Forms.TextBox();
            this.textBoxLogCadUsu = new System.Windows.Forms.TextBox();
            this.labelGerenciamento = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(662, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sairToolStripMenuItem1
            // 
            this.sairToolStripMenuItem1.Name = "sairToolStripMenuItem1";
            this.sairToolStripMenuItem1.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem1.Text = "Sair";
            this.sairToolStripMenuItem1.Click += new System.EventHandler(this.sairToolStripMenuItem1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.labelGerenciamento);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 435);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(26, 83);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(581, 334);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelTitLogUsu);
            this.tabPage1.Controls.Add(this.buttonLogarUsu);
            this.tabPage1.Controls.Add(this.labelSenUsu);
            this.tabPage1.Controls.Add(this.labelLogUsu);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(573, 306);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Logar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelTitLogUsu
            // 
            this.labelTitLogUsu.AutoSize = true;
            this.labelTitLogUsu.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitLogUsu.Location = new System.Drawing.Point(188, 51);
            this.labelTitLogUsu.Name = "labelTitLogUsu";
            this.labelTitLogUsu.Size = new System.Drawing.Size(228, 22);
            this.labelTitLogUsu.TabIndex = 2;
            this.labelTitLogUsu.Text = "Digite os dados para logar";
            // 
            // buttonLogarUsu
            // 
            this.buttonLogarUsu.BackColor = System.Drawing.Color.Violet;
            this.buttonLogarUsu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogarUsu.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonLogarUsu.Location = new System.Drawing.Point(403, 195);
            this.buttonLogarUsu.Name = "buttonLogarUsu";
            this.buttonLogarUsu.Size = new System.Drawing.Size(83, 33);
            this.buttonLogarUsu.TabIndex = 2;
            this.buttonLogarUsu.Text = "Logar";
            this.buttonLogarUsu.UseVisualStyleBackColor = false;
            this.buttonLogarUsu.Click += new System.EventHandler(this.buttonLogarUsu_Click);
            // 
            // labelSenUsu
            // 
            this.labelSenUsu.AutoSize = true;
            this.labelSenUsu.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSenUsu.Location = new System.Drawing.Point(80, 158);
            this.labelSenUsu.Name = "labelSenUsu";
            this.labelSenUsu.Size = new System.Drawing.Size(43, 16);
            this.labelSenUsu.TabIndex = 3;
            this.labelSenUsu.Text = "Senha:";
            // 
            // labelLogUsu
            // 
            this.labelLogUsu.AutoSize = true;
            this.labelLogUsu.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLogUsu.Location = new System.Drawing.Point(83, 108);
            this.labelLogUsu.Name = "labelLogUsu";
            this.labelLogUsu.Size = new System.Drawing.Size(40, 16);
            this.labelLogUsu.TabIndex = 2;
            this.labelLogUsu.Text = "Login:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(126, 155);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(360, 23);
            this.textBox2.TabIndex = 1;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(360, 23);
            this.textBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.textBox7);
            this.tabPage2.Controls.Add(this.labelCadUsu);
            this.tabPage2.Controls.Add(this.buttonCadUsu);
            this.tabPage2.Controls.Add(this.labelSenCadUsu);
            this.tabPage2.Controls.Add(this.labelLogCadUsu);
            this.tabPage2.Controls.Add(this.textBoxSenCadUsu);
            this.tabPage2.Controls.Add(this.textBoxLogCadUsu);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(573, 306);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cadastro";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(85, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Nome:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(131, 75);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(360, 23);
            this.textBox7.TabIndex = 0;
            // 
            // labelCadUsu
            // 
            this.labelCadUsu.AutoSize = true;
            this.labelCadUsu.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCadUsu.Location = new System.Drawing.Point(212, 41);
            this.labelCadUsu.Name = "labelCadUsu";
            this.labelCadUsu.Size = new System.Drawing.Size(183, 22);
            this.labelCadUsu.TabIndex = 7;
            this.labelCadUsu.Text = "Cadastro de Usuários";
            // 
            // buttonCadUsu
            // 
            this.buttonCadUsu.BackColor = System.Drawing.Color.Aquamarine;
            this.buttonCadUsu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCadUsu.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCadUsu.Location = new System.Drawing.Point(419, 213);
            this.buttonCadUsu.Name = "buttonCadUsu";
            this.buttonCadUsu.Size = new System.Drawing.Size(72, 23);
            this.buttonCadUsu.TabIndex = 3;
            this.buttonCadUsu.Text = "Cadastrar";
            this.buttonCadUsu.UseVisualStyleBackColor = false;
            this.buttonCadUsu.Click += new System.EventHandler(this.buttonCadUsu_Click);
            // 
            // labelSenCadUsu
            // 
            this.labelSenCadUsu.AutoSize = true;
            this.labelSenCadUsu.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSenCadUsu.Location = new System.Drawing.Point(85, 175);
            this.labelSenCadUsu.Name = "labelSenCadUsu";
            this.labelSenCadUsu.Size = new System.Drawing.Size(43, 16);
            this.labelSenCadUsu.TabIndex = 9;
            this.labelSenCadUsu.Text = "Senha:";
            // 
            // labelLogCadUsu
            // 
            this.labelLogCadUsu.AutoSize = true;
            this.labelLogCadUsu.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLogCadUsu.Location = new System.Drawing.Point(88, 128);
            this.labelLogCadUsu.Name = "labelLogCadUsu";
            this.labelLogCadUsu.Size = new System.Drawing.Size(40, 16);
            this.labelLogCadUsu.TabIndex = 8;
            this.labelLogCadUsu.Text = "Login:";
            // 
            // textBoxSenCadUsu
            // 
            this.textBoxSenCadUsu.Location = new System.Drawing.Point(131, 169);
            this.textBoxSenCadUsu.Name = "textBoxSenCadUsu";
            this.textBoxSenCadUsu.Size = new System.Drawing.Size(360, 23);
            this.textBoxSenCadUsu.TabIndex = 2;
            this.textBoxSenCadUsu.UseSystemPasswordChar = true;
            // 
            // textBoxLogCadUsu
            // 
            this.textBoxLogCadUsu.Location = new System.Drawing.Point(131, 122);
            this.textBoxLogCadUsu.Name = "textBoxLogCadUsu";
            this.textBoxLogCadUsu.Size = new System.Drawing.Size(360, 23);
            this.textBoxLogCadUsu.TabIndex = 1;
            // 
            // labelGerenciamento
            // 
            this.labelGerenciamento.AutoSize = true;
            this.labelGerenciamento.Font = new System.Drawing.Font("Microsoft YaHei", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelGerenciamento.Location = new System.Drawing.Point(220, 38);
            this.labelGerenciamento.Name = "labelGerenciamento";
            this.labelGerenciamento.Size = new System.Drawing.Size(218, 30);
            this.labelGerenciamento.TabIndex = 0;
            this.labelGerenciamento.Text = "PAIVA PREVITALLI";
            // 
            // TelaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 461);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TelaMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paiva Previtalli";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelTitLogUsu;
        private System.Windows.Forms.Button buttonLogarUsu;
        private System.Windows.Forms.Label labelSenUsu;
        private System.Windows.Forms.Label labelLogUsu;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label labelCadUsu;
        private System.Windows.Forms.Button buttonCadUsu;
        private System.Windows.Forms.Label labelSenCadUsu;
        private System.Windows.Forms.Label labelLogCadUsu;
        private System.Windows.Forms.TextBox textBoxSenCadUsu;
        private System.Windows.Forms.TextBox textBoxLogCadUsu;
        private System.Windows.Forms.Label labelGerenciamento;
    }
}