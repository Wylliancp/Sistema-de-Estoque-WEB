using System;
using System.Web.Mvc;

namespace EstoqueWEB.Controllers
{
    public class ContadorController : Controller
    {
        // GET: Contador
        public ActionResult Index()
        {
            Object valorNaSession = Session["contador"];
            int contador = Convert.ToInt32(valorNaSession);
            contador++;
            Session["contador"] = contador;
            return View(contador);
        }
    }
}