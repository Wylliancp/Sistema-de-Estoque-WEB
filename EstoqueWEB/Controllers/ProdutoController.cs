using EstoqueWEB.NetMVC5.DAO;
using EstoqueWEB.Filtros;
using EstoqueWEB.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using EstoqueWEB.DAO;

namespace EstoqueWEB.Controllers
{
    [AutorizacaoFilter]
    //se anotação estiver na controller a classe verificará para todos os metodos desta controller.
    public class ProdutoController : Controller
    {


        // GET: Produto
        [Route("Produtos", Name = "ListaProdutos")]
        //Anotação que verificara somente para este metodo que o usuario está logado
        //[AutorizacaoFilter]
        public ActionResult Index()
        {
            ProdutoDAO dao = new ProdutoDAO();
            IList<Produto> produtos = dao.Lista();
            //ViewBag.Produtos = produtos;
            return View(produtos);

        }

        public ActionResult Form()
        {
            CategoriasDAO dao = new CategoriasDAO();
            ViewBag.Categorias = dao.lista();
            ViewBag.Produto = new Produto();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(Produto produto)
        {
            int idDaInformatica = 1;
            //como contem uma regra na classe, ele prevalesse porque será a ultima a ser executada no IsValid!!!
            if (produto.CategoriaId.Equals(idDaInformatica) && produto.Preco < 100)
            {
                ModelState.AddModelError("produto.InformaticaComPrecoInvalido", "Produtos da categoria informática devem ter preço maior do que 100");
                ModelState.AddModelError("produto.Preco", "Informe o preço maior do que 100");
            }

            if (ModelState.IsValid)
            {
                ProdutoDAO dao = new ProdutoDAO();
                dao.Adiciona(produto);
                return RedirectToAction("Index");/*("Index", "Produto");*/
            }
            else
            {
                ViewBag.Produto = produto;
                CategoriasDAO categoriasDAO = new CategoriasDAO();
                ViewBag.Categorias = categoriasDAO.lista();
                return View("Form");
            }
        }
        [Route("Produtos/{id}", Name = "VisualizaProduto")]
        public ActionResult Visualiza(int id)
        {
            ProdutoDAO dao = new ProdutoDAO();
            var produto = dao.BuscaPorId(id);
            ViewBag.Produtos = produto;
            return View();
        }

        public ActionResult Edit(int id)
        {
            ProdutoDAO dao = new ProdutoDAO();
            Produto produto = dao.BuscaPorId(id);
            CategoriasDAO daoc = new CategoriasDAO();
            IList<CategoriaDoProduto> categoria = daoc.lista();
            ViewBag.Categorias = categoria;
            ViewBag.Produto = produto;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualiza(Produto produto)
        {
            if (ModelState.IsValid)
            {
                ProdutoDAO dao = new ProdutoDAO();
                dao.Atualiza(produto);
                return RedirectToAction("Index");
            }
            else
            {
                CategoriasDAO dao = new CategoriasDAO();
                var categoria = dao.lista();
                ViewBag.Produto = produto;
                ViewBag.Categorias = categoria;
                return View("Edit");
            }
        }

        public ActionResult Deleta(int id)
        {
            ProdutoDAO dao = new ProdutoDAO();
            dao.Excluir(id);
            return RedirectToAction("Index");
        }

        public ActionResult DecrementaQtd(int id)
        {
            ProdutoDAO dao = new ProdutoDAO();
            Produto produto = dao.BuscaPorId(id);
            produto.Quantidade--;
            dao.Atualiza(produto);
            return Json(produto);
        }

        public ActionResult IncrementaQtd(int id)
        {
            ProdutoDAO dao = new ProdutoDAO();
            Produto produto = dao.BuscaPorId(id);
            produto.Quantidade++;
            dao.Atualiza(produto);
            return Json(produto);
        }
    }
}


//exemplo 1 de filtro de usuarios logado
//// GET: Produto
//[Route("Produtos", Name="ListaProdutos")]
//public ActionResult Index()
//{
//    //Veridifca se usuario está logado e senão redireciona para a pagina login. mas isso tera que ser feito para todos os metodos então isso se tornara dificil de dar manutenção.
//    object usuario = Session["usuarioLogado"];
//    if(usuario != null)
//    {
//        ProdutoDAO dao = new ProdutoDAO();
//        IList<Produto> produtos = dao.Lista();
//        //ViewBag.Produtos = produtos;
//        return View(produtos);
//    }
//    else
//    {
//        return RedirectToAction("Index", "Login");
//    }
//}

//exemplo 2 de filtro de usuarios logado
////Anotação que verificara somente para este metodo que o usuario está logado
//[AutorizacaoFilter]
//public ActionResult Index()
//{
//    ProdutoDAO dao = new ProdutoDAO();
//    IList<Produto> produtos = dao.Lista();
//    //ViewBag.Produtos = produtos;
//    return View(produtos);

//}

//Exemplo do toukforgery
//Cross Site Request Forgery

//public ActionResult RecuperaSenha(String email)
//{
//    UsuarioDao dao = new UsuarioDao();
//    Usuario usuario = dao.BuscaPorEmail(email);
//    GeraNovaSenha(usuario);
//    dao.Atualiza(usuario);
//    EnviaNovaSenhaParaOEmailDoUsuario(usuario);
//    return View();
//}
////view
//  <form action = "seu_site/Usuario/AtualizaEmail" method="post">
//        <input name = "novoEmail" />
//        < input type="submit" />
//    </form>
////Exemplo de uma pessoa malisiosa
//<form action="seu_site/Usuario/AtualizaEmail" method="post">
//        <input name = "novoEmail" value="email.hacker@hackers.com"/>
//    </form>