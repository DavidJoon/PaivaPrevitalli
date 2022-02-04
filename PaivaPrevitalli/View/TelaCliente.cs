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

        private void buttonPesNomCli_Click(object sender, EventArgs e)
        {

            if (textPesNomCli.Text == "")
            {
                MessageBox.Show("Digite um código para a busca", "Atenção");
                textBox19.Focus();
                textBox18.Clear();
                textBox17.Clear();
                textBox16.Clear();
                textBox15.Clear();
                textBox14.Clear();
                textBox13.Clear();
                textBox12.Clear();
                textBox11.Clear();
                textBox10.Clear();
                textBox21.Clear();
                comboBox1.Text = string.Empty;

                return;
            }
            else
            {
                Cliente.Codigo = Convert.ToInt32(textPesNomCli.Text);
                ClienteController cliente = new ClienteController();
                cliente.visuCodigoCliente();
                textBox19.Text = Cliente.Codigo.ToString();
                textBox18.Text = Cliente.NomeCliente;
                textBox17.Text = Cliente.EmailCliente;
                textBox16.Text = Cliente.FoneCliente;
                textBox15.Text = Cliente.CelCliente;
                textBox21.Text = Cliente.NascCliente;
                textBox14.Text = Cliente.RuaCliente;
                textBox13.Text = Cliente.BairroCliente;
                textBox12.Text = Cliente.CepCliente;
                textBox11.Text = Cliente.NumCliente;
                textBox10.Text = Cliente.ComplCliente;
                buttonAltCli.Enabled = true;
                buttonExCli.Enabled = true;
            }

            if (Cliente.Retorno == "False")
            {

                limpaTudo();
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
            textBox21.Clear();
            textBox19.Clear();
            textBox18.Clear();
            textBox17.Clear();
            textBox16.Clear();
            textBox15.Clear();
            textBox14.Clear();
            textBox13.Clear();
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
            comboBox1.Text = string.Empty;

            buttonAltCli.Enabled = false;
            buttonExCli.Enabled = false;

        }

        private void buttonAltCli_Click(object sender, EventArgs e)
        {
            Cliente.Codigo = Convert.ToInt32(textBox19.Text);
            Cliente.NomeCliente = textBox18.Text;
            Cliente.EmailCliente = textBox17.Text;
            Cliente.FoneCliente = textBox16.Text;
            Cliente.CelCliente = textBox15.Text;
            Cliente.NascCliente = textBox21.Text;
            Cliente.RuaCliente = textBox14.Text;
            Cliente.BairroCliente = textBox13.Text;
            Cliente.CepCliente = textBox12.Text;
            Cliente.NumCliente = textBox11.Text;
            Cliente.ComplCliente = textBox10.Text;
            ClienteController clienteController = new ClienteController();
            clienteController.alterarCliente();

            limpaTudo();

        }

        private void buttonExCli_Click(object sender, EventArgs e)
        {
            Cliente.Codigo = Convert.ToInt32(textBox19.Text);
            ClienteController clienteController = new ClienteController();
            clienteController.deletarCliente();

            limpaTudo();
            return;
        }

        private void buttonOkCodCli_Click(object sender, EventArgs e)
        {
             if (textBoxPesCodCli.Text == "")
            {
                MessageBox.Show("Digite um nome para a busca", "Atenção");
                textBoxPesCodCli.Focus();

                return;
            }

            Cliente.NomeCliente = textBoxPesCodCli.Text;
            ClienteController cliente = new();
            dataGridView1.DataSource = ClienteController.visuNomeCliente();

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderCell.Value = "Código";



            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Não existe este Nome", "Atenção");
            }

        }
    }
}
