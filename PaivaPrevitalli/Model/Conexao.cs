using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaivaPrevitalli.Model
{
    class Conexao
    {
        static public string conectar()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pichau\source\repos\PaivaPrevitalli\PaivaPrevitalli\bdpp.mdf;Integrated Security=True";

        }
    }
}
