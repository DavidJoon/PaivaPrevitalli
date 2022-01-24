using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PaivaPrevitalli.Model;
using System.Windows.Forms;


namespace PaivaPrevitalli.Controller
{
    class FornecedorController
    {
        public void cadastroFornecedor()
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comando = new SqlCommand("pInserirFornecedor", conexao);
            comando.CommandType = CommandType.StoredProcedure;


            try
            {

                comando.Parameters.AddWithValue("@nome", Fornecedor.NomeFor);
                comando.Parameters.AddWithValue("@cnpj", Fornecedor.CnpjFor);
                comando.Parameters.AddWithValue("@categoria", Fornecedor.CategoriaFor);
                comando.Parameters.AddWithValue("@cidade", Fornecedor.CidadeFor);
                comando.Parameters.AddWithValue("@estado", Fornecedor.EstadoFor);
                comando.Parameters.AddWithValue("@obs", Fornecedor.ObsFor);

                SqlParameter codigo = comando.Parameters.Add("@codigo", SqlDbType.Int);
                codigo.Direction = ParameterDirection.Output;

                conexao.Open();
                comando.ExecuteNonQuery();

                var resposta = MessageBox.Show("Fornecedor cadastrado com sucesso! \n" +
                    "Deseja cadastrar outro Fornecedor ?",
                    "Novo Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (resposta == DialogResult.Yes)
                {
                    Fornecedor.Retorno = "False";
                    return;
                }
                else
                {
                    Fornecedor.Retorno = "True";
                    return;
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

        public void visuCodigoFornecedor()
        {

            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comandos = new SqlCommand("pBuscaCodigoFornecedor", conexao);
            comandos.CommandType = CommandType.StoredProcedure;

            try
            {

                comandos.Parameters.AddWithValue("@codigo", Fornecedor.Codigo);
                conexao.Open();

                var tabelaDados = comandos.ExecuteReader();

                if (tabelaDados.Read())
                {
                    Fornecedor.NomeFor = tabelaDados["Nome"].ToString();
                    Fornecedor.CnpjFor = tabelaDados["CNPJ"].ToString();
                    Fornecedor.CategoriaFor = tabelaDados["Categoria"].ToString();
                    Fornecedor.CidadeFor = tabelaDados["Cidade"].ToString();
                    Fornecedor.EstadoFor = tabelaDados["Estado"].ToString();
                    Fornecedor.ObsFor = tabelaDados["Obs"].ToString();
                    Fornecedor.Retorno = "True";

                }
                else
                {
                    MessageBox.Show("Fornecedor não localizado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Fornecedor.Retorno = "False";
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

        public BindingSource visuNomeFornecedor()
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comandos = new SqlCommand("pBuscaNomeFornecedor", conexao);
            comandos.CommandType = CommandType.StoredProcedure;

            comandos.Parameters.AddWithValue("@nome", "%" + Fornecedor.NomeFor + "%");
            conexao.Open();
            comandos.ExecuteNonQuery();

            SqlDataAdapter sqlData = new SqlDataAdapter(comandos);
            DataTable table = new DataTable();

            sqlData.Fill(table);

            BindingSource dados = new BindingSource();
            dados.DataSource = table;

            return dados;

        }

        public void alterarFornecedor()
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comandos = new SqlCommand("pAlterarFornecedor", conexao);
            comandos.CommandType = CommandType.StoredProcedure;

            try
            {
                comandos.Parameters.AddWithValue("@codigo", Fornecedor.Codigo);
                comandos.Parameters.AddWithValue("@nome", Fornecedor.NomeFor);
                comandos.Parameters.AddWithValue("@cnpj", Fornecedor.CnpjFor);
                comandos.Parameters.AddWithValue("@categoria", Fornecedor.CategoriaFor);
                comandos.Parameters.AddWithValue("@cidade", Fornecedor.CidadeFor);
                comandos.Parameters.AddWithValue("@estado", Fornecedor.EstadoFor);
                comandos.Parameters.AddWithValue("@obs", Fornecedor.ObsFor);

                conexao.Open();
                comandos.ExecuteNonQuery();
                MessageBox.Show("Fornecedor Alterado com sucesso!");
                Fornecedor.Retorno = "True";
            }
            catch
            {
                MessageBox.Show("Fornecedor não alterado.");
                Fornecedor.Retorno = "False";
            }
            finally
            {
                if (conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }

        public void deletarFornecedor()
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comandos = new SqlCommand("pDeletarFornecedor", conexao);
            comandos.CommandType = CommandType.StoredProcedure;

            try
            {
                comandos.Parameters.AddWithValue("@codigo", Cliente.Codigo);
                conexao.Open();
                comandos.ExecuteNonQuery();
                Fornecedor.Retorno = "True";
                MessageBox.Show("Fornecedor Excluido com sucesso!");

            }
            catch
            {
                MessageBox.Show("Fornecedor não Excluido.");
                Fornecedor.Retorno = "False";
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
