using EstoqueWEB.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstoqueWEB.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //autorização do usuario global em todos os metodos da aplicação
            //filters.Add(new AutorizacaoFilterAttribute());
        }
    }
}