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
    class UsuarioController
    {
        public void cadastroUsuario()
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comando = new SqlCommand("pInserirUsuario", conexao);
            comando.CommandType = CommandType.StoredProcedure;


            try
            {

                comando.Parameters.AddWithValue("@nome", Usuario.NomeUsuario);
                comando.Parameters.AddWithValue("@login", Usuario.LoginUsuario);
                comando.Parameters.AddWithValue("@senha", Usuario.SenhaUsuario);

                SqlParameter codigo = comando.Parameters.Add("@codigo", SqlDbType.Int);
                codigo.Direction = ParameterDirection.Output;

                conexao.Open();
                comando.ExecuteNonQuery();

                var resposta = MessageBox.Show("Usuario cadastrado com sucesso! \n" +
                    "Deseja cadastrar outro Usuario ?",
                    "Novo Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (resposta == DialogResult.Yes)
                {
                    Usuario.Retorno = "False";
                    return;
                }
                else
                {
                    Usuario.Retorno = "True";
                    return;
                }

            }
            catch
            {
                MessageBox.Show("Usuario não cadastrado", "Atenção");
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }


        }

        public void visuCodigoUsuario()
        {

            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comandos = new SqlCommand("pBuscaCodigoUsuario", conexao);
            comandos.CommandType = CommandType.StoredProcedure;

            try
            {

                comandos.Parameters.AddWithValue("@codigo", Usuario.Codigo);
                conexao.Open();

                var tabelaDados = comandos.ExecuteReader();

                if (tabelaDados.Read())
                {
                    Usuario.NomeUsuario = tabelaDados["Nome"].ToString();
                    Usuario.LoginUsuario = tabelaDados["Login"].ToString();
                    Usuario.SenhaUsuario = tabelaDados["Senha"].ToString();
                    Usuario.Retorno = "True";

                }
                else
                {
                    MessageBox.Show("Usuario não localizado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Usuario.Retorno = "False";
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

        public static BindingSource visuNomeUsuario()
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comandos = new SqlCommand("pBuscaNomeUsuario", conexao);
            comandos.CommandType = CommandType.StoredProcedure;

            comandos.Parameters.AddWithValue("@nome", "%" + Usuario.NomeUsuario + "%");
            conexao.Open();
            comandos.ExecuteNonQuery();

            SqlDataAdapter sqlData = new SqlDataAdapter(comandos);
            DataTable table = new DataTable();

            sqlData.Fill(table);

            BindingSource dados = new BindingSource();
            dados.DataSource = table;

            return dados;

        }

        public void alterarUsuario()
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comandos = new SqlCommand("pAlterarUsuario", conexao);
            comandos.CommandType = CommandType.StoredProcedure;

            try
            {
                comandos.Parameters.AddWithValue("@codigo", Usuario.Codigo);
                comandos.Parameters.AddWithValue("@nome", Usuario.NomeUsuario);
                comandos.Parameters.AddWithValue("@login", Usuario.LoginUsuario);
                comandos.Parameters.AddWithValue("@senha", Usuario.SenhaUsuario);

                conexao.Open();
                comandos.ExecuteNonQuery();
                MessageBox.Show("Usuario Alterado com sucesso!");
                Usuario.Retorno = "True";
            }
            catch
            {
                MessageBox.Show("Usuario não alterado.");
                Usuario.Retorno = "False";
            }
            finally
            {
                if (conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }

        public void deletarUsuario()
        {
            SqlConnection conexao = new SqlConnection(Conexao.conectar());
            SqlCommand comandos = new SqlCommand("pDeletarUsuario", conexao);
            comandos.CommandType = CommandType.StoredProcedure;

            try
            {
                comandos.Parameters.AddWithValue("@codigo", Usuario.Codigo);
                conexao.Open();
                comandos.ExecuteNonQuery();
                Usuario.Retorno = "True";
                MessageBox.Show("Usuario Excluido com sucesso!");

            }
            catch
            {
                MessageBox.Show("Usuario não Excluido.");
                Usuario.Retorno = "False";
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
