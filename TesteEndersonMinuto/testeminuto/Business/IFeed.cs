using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IFeed
    {
        List<Entities.ViewModels.BlogItemViewModel> ResumoConteudo(string urlFeed);
    }
}
