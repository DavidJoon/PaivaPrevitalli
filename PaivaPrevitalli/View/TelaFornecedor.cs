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

                var resposta = MessageBox.Show("Fornecedor cadastrado com sucesso., Deseja cadastrar outro fornecedor ou sair?", "Novo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
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
                    this.Close();
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
    }
}
