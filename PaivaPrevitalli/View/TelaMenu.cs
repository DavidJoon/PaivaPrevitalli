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

namespace PaivaPrevitalli.View
{
    public partial class TelaMenu : Form
    {
        public TelaMenu()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogarUsu_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Digite login e senha", "Atenção");

                return;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Digite login e senha", "Atenção");

                return;
            }
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pichau\source\repos\PaivaPrevitalli\PaivaPrevitalli\bdpp.mdf;Integrated Security=True");
            string query = "SELECT * FROM tbusuario WHERE loginUsuario = '" + textBox1.Text.Trim() + "' AND senhaUsuario = '" + textBox2.Text.Trim() + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                TelaLogin telalogin = new TelaLogin();
                telalogin.Show();
                Visible = false;
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
                if (textBox7.Text == "")
                {
                    MessageBox.Show("Complete todos os campos", "Atenção");

                    return;
                }
                else if (textBoxLogCadUsu.Text == "")
                {
                    MessageBox.Show("Complete todos os campos", "Atenção");

                    return;
                }
                else if (textBoxSenCadUsu.Text == "")
                {
                    MessageBox.Show("Complete todos os campos", "Atenção");

                    return;
                }

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
    }
}
