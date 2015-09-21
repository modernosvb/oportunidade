using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Library
{
    public static class Blog
    {
        /// <summary>
        /// Avaliar quais as dez principais palavras abordadas nesses tópicos
        /// e qual o número de vezes que elas aparecem
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static List<Entities.Models.QuantidadeModel> getTop10Palavras(string texto)
        {
            var retorno = new List<Entities.Models.QuantidadeModel>();
            var textoLimpo = Texto.getTextoLimpo(texto);
            var arrPalavras = textoLimpo.Split(' ');

            var resultado = (from p in arrPalavras group p by p into g 
                            orderby g.Count() descending
                            select new { palavra = g.Key, contador = g.Count() }).Take(10).ToList();

            foreach (var registo in resultado){
                retorno.Add(new Entities.Models.QuantidadeModel
                {
                    item = registo.palavra,
                    valor = registo.contador
                });
            }

            return retorno;
        }

        /// <summary>
        /// Também deverá exibir a quantidade de palavras por tópico
        /// Além disso, deverão ser removidos os artigos e preposições nessa análise
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static int getQtdePalavras(string texto)
        {
            var textoLimpo = Texto.getTextoLimpo(texto);
            var arrPalavras = textoLimpo.Split(' ');

            return arrPalavras.Length;
        }

    }
}
