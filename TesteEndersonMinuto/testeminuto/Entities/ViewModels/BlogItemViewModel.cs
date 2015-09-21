using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.ViewModels
{
    public class BlogItemViewModel
    {
        public Models.BlogItemModel Item { get; set; }
        public List<Entities.Models.QuantidadeModel> Top10Palavras { get; set; }
        public int QtdePalavras { get; set; }
    }
}