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
    public partial class TelaEstoque : Form
    {
        public TelaEstoque()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comando = new SqlCommand("pInserirEstoque", conexao);
            comando.CommandType = CommandType.StoredProcedure;

            try
            {
                comando.Parameters.AddWithValue("@nome", textBox2.Text);
                comando.Parameters.AddWithValue("@categoria", comboBox2.Text);
                comando.Parameters.AddWithValue("@cor", textBox9.Text);
                comando.Parameters.AddWithValue("@quantidade", Convert.ToInt32(textBox7.Text));
                comando.Parameters.AddWithValue("@descricao", textBox8.Text);
                comando.Parameters.AddWithValue("@img", pictureBox1.Text);

                SqlParameter codigo = comando.Parameters.Add("@codigo", SqlDbType.Int);
                codigo.Direction = ParameterDirection.Output;

                conexao.Open();
                comando.ExecuteNonQuery();

                var resposta = MessageBox.Show("Produto cadastrado com sucesso., Deseja cadastrar outro produto ou sair?", "Novo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (resposta == DialogResult.Yes)
                {
                    textBox2.Clear();
                    comboBox2.Text = string.Empty;
                    textBox9.Clear();
                    textBox7.Clear();
                    textBox5.Clear();
                    textBox8.Clear();
                    pictureBox1.Text = string.Empty;

                }
                else
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Produto não cadastrado", "Atenção");
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
                textBox3.Focus();
                textBox5.Clear();
                comboBox3.Text = string.Empty;
                textBox4.Clear();
                textBox11.Clear();
                textBox1.Clear();

                return;
            }
            else
            {
                Estoque.Codigo = Convert.ToInt32(textBox6.Text);
                EstoqueController estoque = new EstoqueController();
                estoque.visuCodigoEstoque();
                textBox3.Text = Estoque.Codigo.ToString();
                textBox5.Text = Estoque.NomeEst;
                comboBox3.Text = Estoque.CategoriaEst;
                textBox4.Text = Estoque.CorEst;
                textBox11.Text = Estoque.QuantidadeEst.ToString();
                textBox1.Text = Estoque.DescricaoEst;
                button3.Enabled = true;
                button6.Enabled = true;
            }

            if (Estoque.Retorno == "False")
            {

                limpaTudo();
            }
        }

        private void TelaEstoque_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button6.Enabled = false;
        }
        private void limpaTudo()
        {
            Estoque.Codigo = 0;
            Estoque.NomeEst = "";
            Estoque.CategoriaEst = "";
            Estoque.CorEst = "";
            Estoque.QuantidadeEst = "";
            Estoque.DescricaoEst = "";
            textBox3.Clear();
            textBox5.Clear();
            comboBox3.Text = string.Empty;
            textBox4.Clear();
            textBox11.Clear();
            textBox1.Clear();
            pictureBox2.Text = string.Empty;

            button3.Enabled = false;
            button6.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Estoque.Codigo = Convert.ToInt32(textBox3.Text);
            Estoque.NomeEst = textBox5.Text;
            Estoque.CategoriaEst = comboBox3.Text;
            Estoque.CorEst = textBox4.Text;
            Estoque.QuantidadeEst = textBox11.Text;
            Estoque.DescricaoEst = textBox1.Text;
            Estoque.ImgEst = pictureBox2.Text;
            EstoqueController estoqueController = new EstoqueController();
            estoqueController.alterarEstoque();

            limpaTudo();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Estoque.Codigo = Convert.ToInt32(textBox3.Text);
            EstoqueController estoqueController = new EstoqueController();
            estoqueController.deletarEstoque();

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

            Estoque.NomeEst = textBoxPesCodCli.Text;
            EstoqueController estoque = new();
            dataGridView1.DataSource = EstoqueController.visuNomeEstoque();

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

        private void button1_Click(object sender, EventArgs e)
        {
           
                openFileDialog1.Filter = "Arquivos bmp | *.bmp | Arquivos jpg | *.jpg";



                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = openFileDialog1.FileName;
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Arquivos bmp | *.bmp | Arquivos jpg | *.jpg";



            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }
