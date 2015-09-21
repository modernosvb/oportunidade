using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Feed
    {
        public static string Get(string urlFeed)
        {
            string retorno = string.Empty;

            HttpWebRequest request = HttpWebRequest.CreateHttp(urlFeed);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    retorno = reader.ReadToEnd();
                }
            }

            return retorno;
        }
    }
}
