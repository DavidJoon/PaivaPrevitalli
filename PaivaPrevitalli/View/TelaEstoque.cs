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
using Microsoft.VisualBasic;
using System.IO;
using System.Drawing.Imaging;
using PaivaPrevitalli.View;

namespace PaivaPrevitalli
{
    public partial class TelaEstoque : Form
    {
        public TelaEstoque()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pichau\source\repos\PaivaPrevitalli\PaivaPrevitalli\bdpp.mdf;Integrated Security=True");
        SqlCommand cmd;
        private void TelaEstoque_Load(object sender, EventArgs e)
        {
            load_data();
            button8.Enabled = true;
            button7.Enabled = false;
            button10.Enabled = false;
        }
       
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void sairToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Selecione a imagem(*.jpg; *.png; *.bmp;) | *.jpg; *.png; *.bmp;";
            if(openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBoxPesCodCli.Text == "")
            {
                MessageBox.Show("Complete todos os campos", "Atenção");

                return;
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Complete todos os campos", "Atenção");

                return;
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Complete todos os campos", "Atenção");

                return;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Complete todos os campos", "Atenção");

                return;
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Complete todos os campos", "Atenção");

                return;
            }

            cmd = new SqlCommand("Insert into tbest(nomeest,categoriaest,corest,quantidadeest,descricaoest,imgest)Values(@nomeest,@categoriaest,@corest,@quantidadeest,@descricaoest,@imgest)", conn);
            cmd.Parameters.AddWithValue("nomeest", textBoxPesCodCli.Text);
            cmd.Parameters.AddWithValue("categoriaest", textBox1.Text);
            cmd.Parameters.AddWithValue("corest", textBox3.Text);
            cmd.Parameters.AddWithValue("quantidadeest", textBox2.Text);
            cmd.Parameters.AddWithValue("descricaoest", textBox4.Text);
            MemoryStream memstr = new MemoryStream();
            pictureBox3.Image.Save(memstr, pictureBox3.Image.RawFormat);
            cmd.Parameters.AddWithValue("imgest", memstr.ToArray());
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Inserido com sucesso!");
            textBoxPesCodCli.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox2.Clear();
            textBox4.Clear();
            pictureBox3.Image = null;
            id1.Text = "";
            load_data();
        }
        private void load_data()
        {
 
            cmd = new SqlCommand("Select * from tbest order by IdEst desc", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.RowTemplate.Height = 75;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderCell.Value = "Código";
            dataGridView1.Columns[1].HeaderCell.Value = "Nome";
            dataGridView1.Columns[2].HeaderCell.Value = "Categoria";
            dataGridView1.Columns[3].HeaderCell.Value = "Cor";
            dataGridView1.Columns[4].HeaderCell.Value = "Quantidade";
            dataGridView1.Columns[5].HeaderCell.Value = "Descrição";
            dataGridView1.Columns[6].HeaderCell.Value = "Imagem";
            DataGridViewImageColumn pic1 = new DataGridViewImageColumn();
            pic1 = (DataGridViewImageColumn)dataGridView1.Columns[6];
            pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            button7.Enabled = true;
            button10.Enabled = true;
            id1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxPesCodCli.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[6].Value);
            pictureBox3.Image = Image.FromStream(ms);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Update tbest Set nomeest = @nomeest, categoriaest = @categoriaest, corest = @corest, quantidadeest = @quantidadeest, descricaoest = @descricaoest, imgest = @imgest Where IdEst = @IdEst", conn);
            cmd.Parameters.AddWithValue("nomeest", textBoxPesCodCli.Text);
            cmd.Parameters.AddWithValue("categoriaest", textBox1.Text);
            cmd.Parameters.AddWithValue("corest", textBox3.Text);
            cmd.Parameters.AddWithValue("quantidadeest", textBox2.Text);
            cmd.Parameters.AddWithValue("descricaoest", textBox4.Text);
            MemoryStream memstr = new MemoryStream();
            pictureBox3.Image.Save(memstr, pictureBox3.Image.RawFormat);
            cmd.Parameters.AddWithValue("imgest", memstr.ToArray());
            cmd.Parameters.AddWithValue("IdEst", id1.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            textBoxPesCodCli.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox2.Clear();
            textBox4.Clear();
            pictureBox3.Image = null;
            id1.Text = "";
            load_data();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Delete from tbest where IdEst=@IdEst", conn);
            cmd.Parameters.AddWithValue("IdEst", id1.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            load_data();
            pictureBox3.Image = null;
            textBoxPesCodCli.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            id1.Text = "";
        }
    }
    }
