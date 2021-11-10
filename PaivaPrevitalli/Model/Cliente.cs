using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaivaPrevitalli.Model
{
    class Cliente
    {
        private static int codigo;
        private static string nomeCliente;
        private static string emailCliente;
        private static string foneCliente;
        private static string celCliente;
        private static string nascCliente;
        private static string ruaCliente;
        private static string bairroCliente;
        private static string cepCliente;
        private static string numCliente;
        private static string complCliente;
        private static string encontrouCliente;
        private static string retorno;

        public static int Codigo { get => codigo; set => codigo = value; }
        public static string NomeCliente { get => nomeCliente; set => nomeCliente = value; }
        public static string EmailCliente { get => emailCliente; set => emailCliente = value; }
        public static string FoneCliente { get => foneCliente; set => foneCliente = value; }
        public static string CelCliente { get => celCliente; set => celCliente = value; }
        public static string NascCliente { get => nascCliente; set => nascCliente = value; }
        public static string RuaCliente { get => ruaCliente; set => ruaCliente = value; }
        public static string BairroCliente { get => bairroCliente; set => bairroCliente = value; }
        public static string CepCliente { get => cepCliente; set => cepCliente = value; }
        public static string NumCliente { get => numCliente; set => numCliente = value; }
        public static string ComplCliente { get => complCliente; set => complCliente = value; }
        public static string EncontrouCliente { get => encontrouCliente; set => encontrouCliente = value; }
        public static string Retorno { get => retorno; set => retorno = value; }
    }
}
