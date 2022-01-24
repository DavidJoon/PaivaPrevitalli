using PaivaPrevitalli.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaivaPrevitalli.Controller
{
    class ClienteController
    {
        public void cadastroCliente()
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comando = new SqlCommand("pInserirCliente", conexao);
            comando.CommandType = CommandType.StoredProcedure;


            try
            {

                comando.Parameters.AddWithValue("@nome", Cliente.NomeCliente);
                comando.Parameters.AddWithValue("@email", Cliente.EmailCliente);
                comando.Parameters.AddWithValue("@fone", Cliente.FoneCliente);
                comando.Parameters.AddWithValue("@cel", Cliente.CelCliente);
                comando.Parameters.AddWithValue("@nascimento", Cliente.NascCliente);
                comando.Parameters.AddWithValue("@rua", Cliente.RuaCliente);
                comando.Parameters.AddWithValue("@bairro", Cliente.BairroCliente);
                comando.Parameters.AddWithValue("@cep", Cliente.CepCliente);
                comando.Parameters.AddWithValue("@numero", Cliente.NumCliente);
                comando.Parameters.AddWithValue("@complemento", Cliente.ComplCliente);
                comando.Parameters.AddWithValue("@encontrou", Cliente.EncontrouCliente);

                SqlParameter codigo = comando.Parameters.Add("@codigo", SqlDbType.Int);
                codigo.Direction = ParameterDirection.Output;

                conexao.Open();
                comando.ExecuteNonQuery();

                var resposta = MessageBox.Show("Cliente cadastrado com sucesso! \n" +
                    "Deseja cadastrar outro Cliente ?",
                    "Novo Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (resposta == DialogResult.Yes)
                {
                    Cliente.Retorno = "False";
                    return;
                }
                else
                {
                    Cliente.Retorno = "True";
                    return;
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

        public void visuCodigoCliente()
        {

            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comandos = new SqlCommand("pBuscaCodigoCliente", conexao);
            comandos.CommandType = CommandType.StoredProcedure;

            try
            {

                comandos.Parameters.AddWithValue("@codigo", Cliente.Codigo);
                conexao.Open();

                var tabelaDados = comandos.ExecuteReader();

                if (tabelaDados.Read())
                {
                    Cliente.NomeCliente = tabelaDados["Cliente"].ToString();
                    Cliente.EmailCliente = tabelaDados["Email"].ToString();
                    Cliente.FoneCliente = tabelaDados["Telefone"].ToString();
                    Cliente.CelCliente = tabelaDados["Cel"].ToString();
                    Cliente.NascCliente = tabelaDados["Nascimento"].ToString();
                    Cliente.RuaCliente = tabelaDados["Rua"].ToString();
                    Cliente.BairroCliente = tabelaDados["Bairro"].ToString();
                    Cliente.CepCliente = tabelaDados["CEP"].ToString();
                    Cliente.NumCliente = tabelaDados["Num"].ToString();
                    Cliente.ComplCliente = tabelaDados["Complemento"].ToString();
                    Cliente.EncontrouCliente = tabelaDados["ComoEncontrou"].ToString();
                    Cliente.Retorno = "True";

                }
                else
                {
                    MessageBox.Show("Cliente não localizado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Cliente.Retorno = "False";
                }

            }
            catch
            {
                MessageBox.Show("Não conseguimos localizar os dados", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            finally
            {
                if (conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }

        public static BindingSource visuNomeCliente()
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comandos = new SqlCommand("pBuscaNomeCliente", conexao);
            comandos.CommandType = CommandType.StoredProcedure;

            comandos.Parameters.AddWithValue("@nome", "%" + Cliente.NomeCliente + "%");
            conexao.Open();
            comandos.ExecuteNonQuery();

            SqlDataAdapter sqlData = new SqlDataAdapter(comandos);
            DataTable table = new DataTable();

            sqlData.Fill(table);

            BindingSource dados = new BindingSource();
            dados.DataSource = table;

            return dados;

        }

        public void alterarCliente()
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comandos = new SqlCommand("pAlterarCliente", conexao);
            comandos.CommandType = CommandType.StoredProcedure;

            try
            {
                comandos.Parameters.AddWithValue("@codigo", Cliente.Codigo);
                comandos.Parameters.AddWithValue("@nome", Cliente.NomeCliente);
                comandos.Parameters.AddWithValue("@email", Cliente.EmailCliente);
                comandos.Parameters.AddWithValue("@fone", Cliente.FoneCliente);
                comandos.Parameters.AddWithValue("@cel", Cliente.CelCliente);
                comandos.Parameters.AddWithValue("@nascimento", Cliente.NascCliente);
                comandos.Parameters.AddWithValue("@rua", Cliente.RuaCliente);
                comandos.Parameters.AddWithValue("@bairro", Cliente.BairroCliente);
                comandos.Parameters.AddWithValue("@cep", Cliente.CepCliente);
                comandos.Parameters.AddWithValue("@numero", Cliente.NumCliente);
                comandos.Parameters.AddWithValue("@cpmplemento", Cliente.ComplCliente);
                comandos.Parameters.AddWithValue("@encontrou", Cliente.EncontrouCliente);

                conexao.Open();
                comandos.ExecuteNonQuery();
                MessageBox.Show("Cliente Alterado com sucesso!");
                Cliente.Retorno = "True";
            }
            catch
            {
                MessageBox.Show("Cliente não alterado.");
                Cliente.Retorno = "False";
            }
            finally
            {
                if (conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }

        public void deletarCliente()
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comandos = new SqlCommand("pDeletarCliente", conexao);
            comandos.CommandType = CommandType.StoredProcedure;

            try
            {
                comandos.Parameters.AddWithValue("@codigo", Cliente.Codigo);
                conexao.Open();
                comandos.ExecuteNonQuery();
                Cliente.Retorno = "True";
                MessageBox.Show("Cliente Excluido com sucesso!");

            }
            catch
            {
                MessageBox.Show("Cliente não Excluido.");
                Cliente.Retorno = "False";
            }
            finally
            {
                if (conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }

    }
}
