using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaivaPrevitalli.Model
{
    class Usuario
    {
        private static int codigo;
        private static string nomeUsuario;
        private static string loginUsuario;
        private static string senhaUsuario;
        private static string retorno;

        public static int Codigo { get => codigo; set => codigo = value; }
        public static string NomeUsuario { get => nomeUsuario; set => nomeUsuario = value; }
        public static string LoginUsuario { get => loginUsuario; set => loginUsuario = value; }
        public static string SenhaUsuario { get => senhaUsuario; set => senhaUsuario = value; }
        public static string Retorno { get => retorno; set => retorno = value; }
    }
}
