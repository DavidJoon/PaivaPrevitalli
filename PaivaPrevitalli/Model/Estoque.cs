using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaivaPrevitalli.Model
{
    class Estoque
    {
        private static int codigo;
        private static string nomeEst;
        private static string categoriaEst;
        private static string corEst;
        private static string quantidadeEst;
        private static string descricaoEst;
        private static string imgEst;
        private static string retorno;

        public static int Codigo { get => codigo; set => codigo = value; }
        public static string NomeEst { get => nomeEst; set => nomeEst = value; }
        public static string CategoriaEst { get => categoriaEst; set => categoriaEst = value; }
        public static string CorEst { get => corEst; set => corEst = value; }
        public static string QuantidadeEst { get => quantidadeEst; set => quantidadeEst = value; }
        public static string DescricaoEst { get => descricaoEst; set => descricaoEst = value; }
        public static string ImgEst { get => imgEst; set => imgEst = value; }
        public static string Retorno { get => retorno; set => retorno = value; }
    }
}
