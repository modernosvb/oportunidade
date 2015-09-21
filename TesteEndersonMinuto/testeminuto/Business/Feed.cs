using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Business
{
    public class Feed : IFeed
    {
        public List<Entities.ViewModels.BlogItemViewModel> ResumoConteudo(string urlFeed)
        {
            var retorno = new List<Entities.ViewModels.BlogItemViewModel>();

            try
            {
                foreach (var item in GetItens(urlFeed))
                {
                    retorno.Add(new Entities.ViewModels.BlogItemViewModel
                    {
                        Item = item,
                        QtdePalavras = Library.Blog.getQtdePalavras(item.content),
                        Top10Palavras = Library.Blog.getTop10Palavras(item.content)
                    });
                }
            }
            catch (Exception err)
            {
                retorno.Add(new Entities.ViewModels.BlogItemViewModel
                {
                    Item = new Entities.Models.BlogItemModel
                    {
                        title = string.Format("Erro: {0}", err.Message)
                    },
                    QtdePalavras = 0,
                    Top10Palavras = new List<Entities.Models.QuantidadeModel>()
                });
            }

            return retorno;
        }

        private List<Entities.Models.BlogItemModel> GetItens(string urlFeed)
        {
            var retorno = new List<Entities.Models.BlogItemModel>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Library.Feed.Get(urlFeed));

            XmlNode channelNode = doc.SelectSingleNode("rss/channel");
            if (channelNode != null)
            {
                XmlNamespaceManager nameSpace = new XmlNamespaceManager(doc.NameTable);
                nameSpace.AddNamespace("content", "http://purl.org/rss/1.0/modules/content/");
                nameSpace.AddNamespace("slash", "http://purl.org/rss/1.0/modules/slash/");
                nameSpace.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");

                foreach (XmlNode item in channelNode.SelectNodes("item"))
                {
                    var newItem = new Entities.Models.BlogItemModel();
                    newItem.title = item.SelectSingleNode("title").InnerText;
                    newItem.slash = item.SelectSingleNode("slash:comments", nameSpace).InnerText;
                    newItem.pubDate = item.SelectSingleNode("pubDate").InnerText;
                    newItem.link = item.SelectSingleNode("link").InnerText;
                    newItem.guid = item.SelectSingleNode("guid").InnerText;
                    newItem.description = item.SelectSingleNode("description").InnerText;
                    newItem.creator = item.SelectSingleNode("dc:creator", nameSpace).InnerText;
                    newItem.content = item.SelectSingleNode("content:encoded", nameSpace).InnerText;
                    newItem.comments = item.SelectSingleNode("comments").InnerText;
                    newItem.category = item.SelectSingleNode("category").InnerText;
                    retorno.Add(newItem);
                }
            }
            return retorno;
        }

    }
}
