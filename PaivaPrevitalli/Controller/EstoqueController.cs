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
    class EstoqueController
    {
        public void cadastroEstoque()
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comando = new SqlCommand("pInserirEstoque", conexao);
            comando.CommandType = CommandType.StoredProcedure;


            try
            {

                comando.Parameters.AddWithValue("@nome", Estoque.NomeEst);
                comando.Parameters.AddWithValue("@categoria", Estoque.CategoriaEst);
                comando.Parameters.AddWithValue("@cor", Estoque.CorEst);
                comando.Parameters.AddWithValue("@quantidade", Estoque.QuantidadeEst);
                comando.Parameters.AddWithValue("@descricao", Estoque.DescricaoEst);
                comando.Parameters.AddWithValue("@img", Estoque.ImgEst);

                SqlParameter codigo = comando.Parameters.Add("@codigo", SqlDbType.Int);
                codigo.Direction = ParameterDirection.Output;

                conexao.Open();
                comando.ExecuteNonQuery();

                var resposta = MessageBox.Show("Estoque cadastrado com sucesso! \n" +
                    "Deseja cadastrar outro Estoque ?",
                    "Novo Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (resposta == DialogResult.Yes)
                {
                    Estoque.Retorno = "False";
                    return;
                }
                else
                {
                    Estoque.Retorno = "True";
                    return;
                }

            }
            catch
            {
                MessageBox.Show("Estoque não cadastrado", "Atenção");
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }


        }

        public void visuCodigoEstoque()
        {

            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comandos = new SqlCommand("pBuscaCodigoEstoque", conexao);
            comandos.CommandType = CommandType.StoredProcedure;

            try
            {

                comandos.Parameters.AddWithValue("@codigo", Estoque.Codigo);
                conexao.Open();

                var tabelaDados = comandos.ExecuteReader();

                if (tabelaDados.Read())
                {
                    Estoque.NomeEst = tabelaDados["Nome"].ToString();
                    Estoque.CategoriaEst = tabelaDados["Categoria"].ToString();
                    Estoque.CorEst = tabelaDados["Cor"].ToString();
                    Estoque.QuantidadeEst = tabelaDados["Quantidade"].ToString();
                    Estoque.DescricaoEst = tabelaDados["Descrição"].ToString();
                    Estoque.Retorno = "True";

                }
                else
                {
                    MessageBox.Show("Estoque não localizado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Estoque.Retorno = "False";
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

        public static BindingSource visuNomeEstoque()
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comandos = new SqlCommand("pBuscaNomeEstoque", conexao);
            comandos.CommandType = CommandType.StoredProcedure;

            comandos.Parameters.AddWithValue("@nome", "%" + Estoque.NomeEst + "%");
            conexao.Open();
            comandos.ExecuteNonQuery();

            SqlDataAdapter sqlData = new SqlDataAdapter(comandos);
            DataTable table = new DataTable();

            sqlData.Fill(table);

            BindingSource dados = new BindingSource();
            dados.DataSource = table;

            return dados;

        }

        public void alterarEstoque()
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comandos = new SqlCommand("pAlterarEstoque", conexao);
            comandos.CommandType = CommandType.StoredProcedure;

            try
            {
                comandos.Parameters.AddWithValue("@codigo", Estoque.Codigo);
                comandos.Parameters.AddWithValue("@nome", Estoque.NomeEst);
                comandos.Parameters.AddWithValue("@categoria", Estoque.CategoriaEst);
                comandos.Parameters.AddWithValue("@cor", Estoque.CorEst);
                comandos.Parameters.AddWithValue("@quantidade", Estoque.QuantidadeEst);
                comandos.Parameters.AddWithValue("@descricao", Estoque.DescricaoEst);
                comandos.Parameters.AddWithValue("@img", Estoque.ImgEst);

                conexao.Open();
                comandos.ExecuteNonQuery();
                MessageBox.Show("Estoque Alterado com sucesso!");
                Estoque.Retorno = "True";
            }
            catch
            {
                MessageBox.Show("Estoque não alterado.");
                Estoque.Retorno = "False";
            }
            finally
            {
                if (conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }

        public void deletarEstoque()
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comandos = new SqlCommand("pDeletarEstoque", conexao);
            comandos.CommandType = CommandType.StoredProcedure;

            try
            {
                comandos.Parameters.AddWithValue("@codigo", Cliente.Codigo);
                conexao.Open();
                comandos.ExecuteNonQuery();
                Estoque.Retorno = "True";
                MessageBox.Show("Estoque Excluido com sucesso!");

            }
            catch
            {
                MessageBox.Show("Estoque não Excluido.");
                Estoque.Retorno = "False";
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
