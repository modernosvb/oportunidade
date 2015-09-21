using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using Business;

namespace api.Controllers
{
    public class BlogController : ApiController
    {
        [HttpPost, System.Web.Http.ActionName("ObterReumoConteudo")]
        public List<Entities.ViewModels.BlogItemViewModel> ObterReumoConteudo(string urlFeed)
        {
            IFeed ifeed = new Feed();
            return ifeed.ResumoConteudo(urlFeed);
        }
    }
}
