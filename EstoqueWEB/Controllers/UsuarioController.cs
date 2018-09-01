using EstoqueWEB.NetMVC5.DAO;
using EstoqueWEB.Filtros;
using EstoqueWEB.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EstoqueWEB.Controllers
{
    [AutorizacaoFilter]
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            UsuarioDAO dao = new UsuarioDAO();
            IList<Usuario> usuarios = dao.Lista();
            return View(usuarios);
        }

        [Route("Usuarios/{id}",Name = "VisualizaUsuarios")]
        public ActionResult Visualiza(int id)
        {
            UsuarioDAO dao = new UsuarioDAO();
            IList<Usuario> usuarios = dao.Lista();
            return View(usuarios);
        }

        public ActionResult Edit(int id)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario usuario = dao.BuscaPorId(id);
            ViewBag.Usuario = usuario;
            return View();
        }

        public ActionResult Atualiza(Usuario usuario)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.Atualiza(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Form()
        {
            ViewBag.Usuario = new Usuario();
            return View();
        }
        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(Usuario usuario)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.Adiciona(usuario);
            return RedirectToAction("Index");

        }

        public ActionResult Deleta(int id)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.Excluir(id);
            return RedirectToAction("Index");
        }

        public ActionResult Deslogar()
        {
            object usuario = HttpContext.Session["usuarioLogado"];
            if(usuario != null)
            {
                Session["usuarioLogado"] = null;
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }
    }
}