using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaivaPrevitalli
{
    public partial class TelaLogin : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeft,
                int nTop,
                int nRight,
                int nBottom,
                int nWidthEllipse,
                int nHeightEllipse
            );

        public TelaLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonCliente.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, buttonCliente.Width, buttonCliente.Height, 40, 40));
            buttonUsuario.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, buttonUsuario.Width, buttonUsuario.Height, 40, 40));
            buttonFornecedores.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, buttonFornecedores.Width, buttonFornecedores.Height, 40, 40));
            buttonEstoque.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, buttonEstoque.Width, buttonEstoque.Height, 40, 40));
        }
    }
}
