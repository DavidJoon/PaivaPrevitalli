using PaivaPrevitalli.Controller;
using PaivaPrevitalli.Model;
using PaivaPrevitalli.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaivaPrevitalli
{
    public partial class TelaLogin : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeft,
                int nTop,
                int nRight,
                int nBottom,
                int nWidthEllipse,
                int nHeightEllipse
            );

        public TelaLogin()
        {
            InitializeComponent();
        }
        
        

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;
            buttonCliente.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, buttonCliente.Width, buttonCliente.Height, 40, 40));
            buttonUsuario.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, buttonUsuario.Width, buttonUsuario.Height, 40, 40));
            buttonFornecedores.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, buttonFornecedores.Width, buttonFornecedores.Height, 40, 40));
            buttonEstoque.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, buttonEstoque.Width, buttonEstoque.Height, 40, 40));
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("Digite um código para a busca", "Atenção");
                textBox6.Focus();
                textBox4.Clear();
                textBox3.Clear();
                textBox5.Clear();

                return;
            }
            else
            {
                Usuario.Codigo = Convert.ToInt32(textBox6.Text);
                UsuarioController usuario = new UsuarioController();
                usuario.visuCodigoUsuario();
                textBox6.Text = Usuario.Codigo.ToString();
                textBox4.Text = Usuario.NomeUsuario;
                textBox3.Text = Usuario.LoginUsuario;
                textBox5.Text = Usuario.SenhaUsuario;
                button1.Enabled = true;
                button3.Enabled = true;
            }

            if (Usuario.Retorno == "False")
            {

                limpaTudo();
            }

        }
        private void limpaTudo()
        {
            Usuario.Codigo = 0;
            Usuario.NomeUsuario = "";
            Usuario.LoginUsuario = "";
            Usuario.SenhaUsuario = "";
            textBox6.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox5.Clear();

            button1.Enabled = false;
            button3.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario.Codigo = Convert.ToInt32(textBox6.Text);
            Usuario.NomeUsuario = textBox4.Text;
            Usuario.LoginUsuario = textBox3.Text;
            Usuario.SenhaUsuario = textBox5.Text;
            UsuarioController usuarioController = new UsuarioController();
            usuarioController.alterarUsuario();

            limpaTudo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Usuario.Codigo = Convert.ToInt32(textBox6.Text);
            UsuarioController usuarioController = new UsuarioController();
            usuarioController.deletarUsuario();

            limpaTudo();
            return;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                MessageBox.Show("Digite um nome para a busca", "Atenção");
                textBox8.Focus();

                return;
            }

            Usuario.NomeUsuario = textBox8.Text;
            UsuarioController usuario = new();
            dataGridView1.DataSource = UsuarioController.visuNomeUsuario();

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[0].HeaderCell.Value = "Código";
            dataGridView1.Columns[1].HeaderCell.Value = "Nome";
            dataGridView1.Columns[2].HeaderCell.Value = "Login";


            textBox8.Clear();
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Não existe este Nome", "Atenção");
            }

        }

        private void buttonCliente_Click(object sender, EventArgs e)
        {
            TelaCliente telacliente = new TelaCliente();
            telacliente.Show();
            Visible = false;
        }

        private void buttonEstoque_Click(object sender, EventArgs e)
        {
            TelaEstoque telaestoque = new TelaEstoque();
            telaestoque.Show();
            Visible = false;
        }

        private void buttonFornecedores_Click(object sender, EventArgs e)
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

        private void terminarSessãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaMenu menu = new TelaMenu();
            this.Hide();
            menu.Show();

        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }
