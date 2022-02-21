using PaivaPrevitalli.Controller;
using PaivaPrevitalli.Model;
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
            buttonCliente.Enabled = false;
            buttonEstoque.Enabled = false;
            buttonFornecedores.Enabled = false;
            buttonCliente.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, buttonCliente.Width, buttonCliente.Height, 40, 40));
            buttonUsuario.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, buttonUsuario.Width, buttonUsuario.Height, 40, 40));
            buttonFornecedores.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, buttonFornecedores.Width, buttonFornecedores.Height, 40, 40));
            buttonEstoque.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, buttonEstoque.Width, buttonEstoque.Height, 40, 40));
        }



        private void buttonLogarUsu_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pichau\source\repos\PaivaPrevitalli\PaivaPrevitalli\bdpp.mdf;Integrated Security=True");
            string query = "SELECT * FROM tbusuario WHERE loginUsuario = '"+textBox1.Text.Trim()+"' AND senhaUsuario = '"+textBox2.Text.Trim()+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                button1.Enabled = true;
                button3.Enabled = true;
                buttonCliente.Enabled = true;
                buttonEstoque.Enabled = true;
                buttonFornecedores.Enabled = true;
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("Bem Vindo");
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Select();
            }
        }

        private void buttonCadUsu_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comando = new SqlCommand("pInserirUsuario", conexao);
            comando.CommandType = CommandType.StoredProcedure;

            try
            {
                comando.Parameters.AddWithValue("@nome", textBox7.Text);
                comando.Parameters.AddWithValue("@login", textBoxLogCadUsu.Text);
                comando.Parameters.AddWithValue("@senha", textBoxSenCadUsu.Text);

                SqlParameter codigo = comando.Parameters.Add("@codigo", SqlDbType.Int);
                codigo.Direction = ParameterDirection.Output;

                conexao.Open();
                comando.ExecuteNonQuery();

                var resposta = MessageBox.Show("Usuário cadastrado com sucesso., Deseja cadastrar outro usuário ou sair?", "Novo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (resposta == DialogResult.Yes)
                {
                    textBox7.Clear();
                    textBoxLogCadUsu.Clear();
                    textBoxSenCadUsu.Clear();
                }
                else
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Usuário não cadastrado", "Atenção");
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
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

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderCell.Value = "Código";



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
            TelaLogin login = new TelaLogin();
            this.Hide();
            login.Show();
            button1.Enabled = false;
            button3.Enabled = false;
            buttonCliente.Enabled = false;
            buttonEstoque.Enabled = false;
            buttonFornecedores.Enabled = false;
        }
    }
    }
