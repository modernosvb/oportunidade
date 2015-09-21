using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library
{
    public static class Texto
    {
        public static string getTextoLimpo(this string str, bool consulta = false)
        {
            //Eliminar tags HTML
            str = Regex.Replace(str, "<[^>]*>", string.Empty);

            str = RemoveAcentos(str.ToUpperInvariant());

            str = RemovePalavrasEspecificas(str);

            str = SomenteLetras(str);

            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            //Eliminar preposições
            var preposicoes = new[] { " DE ", " DA ", " DO ", " AS ", " OS ", " AO ", " NA ", " NO ", " DOS ", " DAS ", " AOS ", " NAS ", " NOS ", " COM " };
            str = preposicoes.Aggregate(str, (current, preposicao) => current.Replace(preposicao, " "));

            //Converte algarismos romanos para números
            var algRomanos = new[] { " V ", " I ", " IX ", " VI ", " IV ", " II ", " VII ", " III ", " X ", " VIII " };
            var numeros = new[] { " 5 ", " 1 ", " 9 ", " 6 ", " 4 ", " 2 ", " 7 ", " 3 ", " 10 ", " 8 " };
            for (int i = 0; i < algRomanos.Length; i++)
            {
                str = str.Replace(algRomanos[i], numeros[i]);
            }

            //Converte numeros para literais
            var algarismosExtenso = new[] { "ZERO", "UM", "DOIS", "TRES", "QUATRO", "CINCO", "SEIS", "SETE", "OITO", "NOVE" };
            for (int i = 0; i < 10; i++)
            {
                str = str.Replace(i.ToString(), algarismosExtenso[i]);
            }

            //Elimina artigos
            var letras = new[] { " A ", " B ", " C ", " D ", " E ", " F ", " G ", " H ", " I ", " J ", " K ", " L ", " M ", " N ", " O ", " P ", " Q ", " R ", " S ", " T ", " U ", " V ", " X ", " Z ", " W ", " Y " };
            str = letras.Aggregate(str, (current, letra) => current.Replace(letra, " "));

            str = str.Trim();

            return str;
        }

        private static string SomenteLetras(string texto)
        {
            const string letras = "ABCDEFGHIJKLMNOPQRSTUVXZWY ";
            var resultado = string.Empty;
            var letraAnt = texto[0];
            foreach (var letraT in texto)
            {
                foreach (var letraC in letras.Where(letraC => letraC == letraT).TakeWhile(letraC => letraAnt != ' ' || letraT != ' '))
                {
                    resultado += letraC;
                    letraAnt = letraT;
                    break;
                }
            }

            return resultado.ToUpperInvariant();
        }

        private static string RemoveAcentos(string texto)
        {
            const string comAcento = "áÁàÀâÂãÃéÉèÈêÊíÍìÌîÎóÓòÒôÔõÕúÚùÙûÛüÜçÇñÑ";
            const string semAcento = "AAAAAAAAEEEEEEIIIIIIOOOOOOOOUUUUUUUUCCNN";

            for (var i = 0; i < comAcento.Length; i++)
            {
                texto = texto.Replace(comAcento[i], semAcento[i]);
            }
            return texto;
        }

        private static string RemovePalavrasEspecificas(string texto)
        {
            texto = texto.Replace(" UM ", "");
            texto = texto.Replace(" PARA ", "");
            texto = texto.Replace(" EM ", "");
            texto = texto.Replace(" QUE ", "");

            return texto;
        }
    }
}
