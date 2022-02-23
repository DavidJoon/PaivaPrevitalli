using PaivaPrevitalli.Controller;
using PaivaPrevitalli.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
using System.Drawing.Imaging;
using PaivaPrevitalli.View;

namespace PaivaPrevitalli
{
    public partial class TelaEstoque : Form
    {
        public TelaEstoque()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rafael.onascimento5\Source\Repos\PaivaPrevitalli\PaivaPrevitalli\bdpp.mdf;Integrated Security=True");
        SqlCommand cmd;
        private void TelaEstoque_Load(object sender, EventArgs e)
        {
            button8.Enabled = false;
            button7.Enabled = false;
            button10.Enabled = false;
        }
       

    

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonCliente_Click_1(object sender, EventArgs e)
        {
            TelaCliente telacliente = new TelaCliente();
            telacliente.Show();
            Visible = false;
        }

        private void buttonEstoque_Click_1(object sender, EventArgs e)
        {
            TelaEstoque telaestoque = new TelaEstoque();
            telaestoque.Show();
            Visible = false;
        }

        private void buttonFornecedores_Click_1(object sender, EventArgs e)
        {
            TelaFornecedor telafornecedor = new TelaFornecedor();
            telafornecedor.Show();
            Visible = false;
        }

        private void buttonUsuario_Click(object sender, EventArgs e)
        {
            TelaLogin telalogin = new TelaLogin();
            telalogin.Show();
            Visible = false;
        }

        private void arquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaMenu menu = new TelaMenu();
            this.Hide();
            menu.Show();
        }

        private void sairToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Selecione a imagem(*.jpg; *.png; *.bmp;) | *.jpg; *.png; *.bmp;";
            if(openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cmd = new SqlConnection("Insert into tbest(nomeest,categoriaest,corest,quantidadeest,descricaoest,imgest)Values(@nomeest,@categoriaest,@corest,@quantidadeest,@descricaoest,@imgest)", conn);
            cmd.Parameters.AddWithValue("nomeest", textBoxPesCodCli.Text);
            cmd.Parameters.AddWithValue("categoriaest", textBox1.Text);
            cmd.Parameters.AddWithValue("corest", textBox3.Text);
            cmd.Parameters.AddWithValue("quantidadeest", textBox2.Text);
            cmd.Parameters.AddWithValue("descricaoest", textBox4.Text);
            MemoryStream memstr = new MemoryStream();
            pictureBox3.Image.Save(memstr, pictureBox3.Image.RawFormat);
            cmd.Parameters.AddWithValue("imgest", memstr.ToArray());
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Inserido com sucesso!");
        }
    }
    }
