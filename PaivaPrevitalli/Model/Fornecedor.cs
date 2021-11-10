using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaivaPrevitalli.Model
{
    class Fornecedor
    {
        private static int codigo;
        private static string nomeFor;
        private static string cnpjFor;
        private static string categoriaFor;
        private static string cidadeFor;
        private static string estadoFor;
        private static string obsFor;
        private static string retorno;

        public static int Codigo { get => codigo; set => codigo = value; }
        public static string NomeFor { get => nomeFor; set => nomeFor = value; }
        public static string CnpjFor { get => cnpjFor; set => cnpjFor = value; }
        public static string CategoriaFor { get => categoriaFor; set => categoriaFor = value; }
        public static string CidadeFor { get => cidadeFor; set => cidadeFor = value; }
        public static string EstadoFor { get => estadoFor; set => estadoFor = value; }
        public static string ObsFor { get => obsFor; set => obsFor = value; }
        public static string Retorno { get => retorno; set => retorno = value; }
    }
}
