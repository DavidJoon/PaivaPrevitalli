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
    public partial class TelaFornecedor : Form
    {
        public TelaFornecedor()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comando = new SqlCommand("pInserirFornecedor", conexao);
            comando.CommandType = CommandType.StoredProcedure;

            try
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Complete todos os campos", "Atenção");

                    return;
                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("Complete todos os campos", "Atenção");

                    return;
                }
                else if (comboBox2.Text == "")
                {
                    MessageBox.Show("Complete todos os campos", "Atenção");

                    return;
                }
                else if (comboBox5.Text == "")
                {
                    MessageBox.Show("Complete todos os campos", "Atenção");

                    return;
                }
                else if (comboBox6.Text == "")
                {
                    MessageBox.Show("Complete todos os campos", "Atenção");

                    return;
                }
                else if (textBox7.Text == "")
                {
                    MessageBox.Show("Complete todos os campos", "Atenção");

                    return;
                }

                comando.Parameters.AddWithValue("@nome", textBox2.Text);
                comando.Parameters.AddWithValue("@cnpj", textBox9.Text);
                comando.Parameters.AddWithValue("@categoria", comboBox2.Text);
                comando.Parameters.AddWithValue("@cidade", comboBox5.Text);
                comando.Parameters.AddWithValue("@estado", comboBox6.Text);
                comando.Parameters.AddWithValue("@obs", textBox7.Text);

                SqlParameter codigo = comando.Parameters.Add("@codigo", SqlDbType.Int);
                codigo.Direction = ParameterDirection.Output;

                conexao.Open();
                comando.ExecuteNonQuery();

                var resposta = MessageBox.Show("Fornecedor cadastrado com sucesso., Deseja cadastrar outro fornecedor?", "Novo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (resposta == DialogResult.Yes)
                {
                    textBox2.Clear();
                    textBox9.Clear();
                    comboBox2.Text = string.Empty;
                    comboBox5.Text = string.Empty;
                    comboBox6.Text = string.Empty;
                    textBox7.Clear();
                }
                else
                {
                    textBox2.Clear();
                    textBox9.Clear();
                    comboBox2.Text = string.Empty;
                    comboBox5.Text = string.Empty;
                    comboBox6.Text = string.Empty;
                    textBox7.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Fornecedor não cadastrado", "Atenção");
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
                textBox5.Focus();
                textBox3.Clear();
                textBox4.Clear();
                comboBox4.Text = string.Empty;
                comboBox3.Text = string.Empty;
                comboBox1.Text = string.Empty;
                textBox1.Clear();
              
                return;
            }
            else
            {
                Fornecedor.Codigo = Convert.ToInt32(textBox6.Text);
                FornecedorController fornecedor = new FornecedorController();
                fornecedor.visuCodigoFornecedor();
                textBox5.Text = Fornecedor.Codigo.ToString();
                textBox4.Text = Fornecedor.NomeFor;
                textBox3.Text = Fornecedor.CnpjFor;
                comboBox4.Text = Fornecedor.CategoriaFor;
                comboBox3.Text = Fornecedor.CidadeFor;
                comboBox1.Text = Fornecedor.EstadoFor;
                textBox1.Text = Fornecedor.ObsFor;
                button3.Enabled = true;
                button6.Enabled = true;
            }

            if (Fornecedor.Retorno == "False")
            {

                limpaTudo();
            }
        }

        private void TelaFornecedor_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button6.Enabled = false;
        }
        private void limpaTudo()
        {
            Fornecedor.Codigo = 0;
            Fornecedor.NomeFor = "";
            Fornecedor.CnpjFor = "";
            Fornecedor.CategoriaFor = "";
            Fornecedor.CidadeFor = "";
            Fornecedor.EstadoFor = "";
            Fornecedor.ObsFor = "";
            textBox4.Clear();
            textBox3.Clear();
            comboBox4.Text = string.Empty;
            comboBox3.Text = string.Empty;
            comboBox1.Text = string.Empty;
            textBox1.Clear();

            button3.Enabled = false;
            button6.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fornecedor.Codigo = Convert.ToInt32(textBox5.Text);
            Fornecedor.NomeFor = textBox4.Text;
            Fornecedor.CnpjFor = textBox3.Text;
            Fornecedor.CategoriaFor = comboBox4.Text;
            Fornecedor.CidadeFor = comboBox3.Text;
            Fornecedor.EstadoFor = comboBox1.Text;
            Fornecedor.ObsFor = textBox1.Text;
            FornecedorController fornecedorController = new FornecedorController();
            fornecedorController.alterarFornecedor();

            limpaTudo();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Fornecedor.Codigo = Convert.ToInt32(textBox5.Text);
            FornecedorController fornecedorController = new FornecedorController();
            fornecedorController.deletarFornecedor();

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

            Fornecedor.NomeFor = textBoxPesCodCli.Text;
            FornecedorController fornecedor = new();
            dataGridView1.DataSource = FornecedorController.visuNomeFornecedor();

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderCell.Value = "Código";
            textBoxPesCodCli.Clear();


            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Não existe este Nome", "Atenção");
            }
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

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }

