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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaivaPrevitalli
{
    public partial class TelaCliente : Form
    {
        public TelaCliente()
        {
            InitializeComponent();
        }
       
        private void buttonCadCli_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comando = new SqlCommand("pInserirCliente", conexao);
            comando.CommandType = CommandType.StoredProcedure;

            try
            {
                comando.Parameters.AddWithValue("@nome", textBox1.Text);
                comando.Parameters.AddWithValue("@email", textBox2.Text);
                comando.Parameters.AddWithValue("@fone", textBox3.Text);
                comando.Parameters.AddWithValue("@cel", textBox4.Text);
                comando.Parameters.AddWithValue("@nascimento", textBox20.Text);
                comando.Parameters.AddWithValue("@rua", textBox5.Text);
                comando.Parameters.AddWithValue("@bairro", textBox7.Text);
                comando.Parameters.AddWithValue("@cep", textBox6.Text);
                comando.Parameters.AddWithValue("@numero", Convert.ToInt32(textBox9.Text));
                comando.Parameters.AddWithValue("@complemento", textBox8.Text);
                comando.Parameters.AddWithValue("@encontrou", comboBox1.Text);

                SqlParameter codigo = comando.Parameters.Add("@codigo", SqlDbType.Int);
                codigo.Direction = ParameterDirection.Output;

                conexao.Open();
                comando.ExecuteNonQuery();

                var resposta = MessageBox.Show("Cliente cadastrado com sucesso., Deseja cadastrar outro cliente ou sair?", "Novo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (resposta == DialogResult.Yes)
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox20.Clear();
                    textBox5.Clear();
                    textBox7.Clear();
                    textBox6.Clear();
                    textBox9.Clear();
                    textBox8.Clear();
                    comboBox1.Text = string.Empty;
                }
                else
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Cliente não cadastrado", "Atenção");
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
    }
        private void TelaCliente_Load(object sender, EventArgs e)
        {
            buttonExCli.Enabled = false;
            buttonAltCli.Enabled = false;
        }
        private void limpaTudo()
        {
            Cliente.Codigo = 0;
            Cliente.NomeCliente = "";
            Cliente.EmailCliente = "";
            Cliente.FoneCliente = "";
            Cliente.CelCliente = "";
            Cliente.NascCliente = "";
            Cliente.RuaCliente = "";
            Cliente.BairroCliente = "";
            Cliente.CepCliente = "";
            Cliente.NumCliente = "";
            Cliente.ComplCliente = "";
            Cliente.EncontrouCliente = "";
            textBox16.Clear();
            textBox34.Clear();
            textBox32.Clear();
            textBox31.Clear();
            textBox30.Clear();
            textBox29.Clear();
            textBox35.Clear();
            textBox28.Clear();
            textBox27.Clear();
            textBox26.Clear();
            textBox25.Clear();
            textBox24.Clear();
            comboBox2.Text = string.Empty;

            button3.Enabled = false;
            button4.Enabled = false;

        }

        private void buttonCliente_Click(object sender, EventArgs e)
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

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TelaCliente_Load_1(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox16.Text == "")
            {
                MessageBox.Show("Digite um código para a busca", "Atenção");
                textBox16.Focus();
                textBox34.Clear();
                textBox32.Clear();
                textBox31.Clear();
                textBox30.Clear();
                textBox29.Clear();
                textBox35.Clear();
                textBox28.Clear();
                textBox27.Clear();
                textBox26.Clear();
                textBox25.Clear();
                textBox24.Clear();
                comboBox2.Text = string.Empty;

                return;
            }
            else
            {
                Cliente.Codigo = Convert.ToInt32(textBox16.Text);
                ClienteController cliente = new ClienteController();
                cliente.visuCodigoCliente();
                textBox34.Text = Cliente.Codigo.ToString();
                textBox32.Text = Cliente.NomeCliente;
                textBox31.Text = Cliente.EmailCliente;
                textBox30.Text = Cliente.FoneCliente;
                textBox29.Text = Cliente.CelCliente;
                textBox35.Text = Cliente.NascCliente;
                textBox28.Text = Cliente.RuaCliente;
                textBox27.Text = Cliente.BairroCliente;
                textBox26.Text = Cliente.CepCliente;
                textBox25.Text = Cliente.NumCliente;
                textBox24.Text = Cliente.ComplCliente;
                comboBox2.Text = Cliente.EncontrouCliente;
                button3.Enabled = true;
                button4.Enabled = true;
            }

            if (Cliente.Retorno == "False")
            {

                limpaTudo();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cliente.Codigo = Convert.ToInt32(textBox34.Text);
            Cliente.NomeCliente = textBox32.Text;
            Cliente.EmailCliente = textBox31.Text;
            Cliente.FoneCliente = textBox30.Text;
            Cliente.CelCliente = textBox29.Text;
            Cliente.NascCliente = textBox35.Text;
            Cliente.RuaCliente = textBox28.Text;
            Cliente.BairroCliente = textBox27.Text;
            Cliente.CepCliente = textBox26.Text;
            Cliente.NumCliente = textBox25.Text;
            Cliente.ComplCliente = textBox24.Text;
            Cliente.EncontrouCliente = comboBox2.Text;
            ClienteController clienteController = new ClienteController();
            clienteController.alterarCliente();

            limpaTudo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cliente.Codigo = Convert.ToInt32(textBox34.Text);
            ClienteController clienteController = new ClienteController();
            clienteController.deletarCliente();

            limpaTudo();
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox23.Text == "")
            {
                MessageBox.Show("Digite um nome para a busca", "Atenção");
                textBox23.Focus();

                return;
            }

            Cliente.NomeCliente = textBox23.Text;
            ClienteController cliente = new();
            dataGridView2.DataSource = ClienteController.visuNomeCliente();

            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].Visible = false;
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[3].Visible = false;
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[6].HeaderCell.Value = "Código";



            if (dataGridView2.Rows.Count == 1)
            {
                MessageBox.Show("Não existe este Nome", "Atenção");
            }
        }
    }
}
