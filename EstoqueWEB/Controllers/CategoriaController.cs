using EstoqueWEB.DAO;
using EstoqueWEB.Filtros;
using EstoqueWEB.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EstoqueWEB.Controllers
{
    [AutorizacaoFilter]
    public class CategoriaController : Controller
    {
        // GET: Categoria
        [Route("Categorias", Name = "ListaDeCategorias")]
        public ActionResult Index()
        {
            CategoriasDAO dao = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = dao.lista();
            ViewBag.Categorias = new CategoriaDoProduto();
            return View(categorias);
        }

        public ActionResult Form()
        {
            ViewBag.Categorias = new CategoriaDoProduto();
            return View();
        }
        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(CategoriaDoProduto categoria)
        {
            if (ModelState.IsValid)
            {
                CategoriasDAO dao = new CategoriasDAO();
                dao.Adiciona(categoria);
                return RedirectToAction("Index", "Categoria");
            }
            else
            {
                ViewBag.Categorias = categoria;
                return View("Form");
            }
        }

        [Route("categorias/{id}", Name = "VisualizaCategorias")]
        public ActionResult Visualiza(int id)
        {
            CategoriasDAO dao = new CategoriasDAO();
            CategoriaDoProduto categorias = dao.BuscaPorId(id);
            ViewBag.Categorias = categorias;
            return View();

        }

        public ActionResult Edit(int id)
        {
            CategoriasDAO dao = new CategoriasDAO();
            CategoriaDoProduto categoria = dao.BuscaPorId(id);
            ViewBag.Categorias = categoria;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualiza(CategoriaDoProduto categoria)
        {
            if (ModelState.IsValid)
            {
                CategoriasDAO dao = new CategoriasDAO();
                dao.Atualiza(categoria);
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.Categoria = categoria;
                return View("Edit");
            }
        }

        public ActionResult Delete(int id)
        {
            CategoriasDAO dao = new CategoriasDAO();
            dao.Excluir(id);
            return RedirectToAction("Index");
        }

    }


}