using EstoqueWEB.Filtros;
using System.Web.Mvc;

namespace EstoqueWEB.Controllers
{
    [AutorizacaoFilter]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}