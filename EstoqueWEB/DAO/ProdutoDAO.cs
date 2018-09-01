using EstoqueWEB.DAO;
using EstoqueWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstoqueWEB.NetMVC5.DAO
{
    public class ProdutoDAO
    {

        public void Adiciona(Produto produto)
        {
            using (var context = new EstoqueContext())
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
        }

        public IList<Produto> Lista()
        {
            using (var context = new EstoqueContext())
            {
                return context.Produtos.Include("Categoria").ToList();
            }
        }

        public Produto BuscaPorId(int id)
        {
            using (var context = new EstoqueContext())
            {
                return context.Produtos.Include("Categoria").
                        Where(x => x.Id == id).
                        FirstOrDefault();
            }
        }

        public void Atualiza(Produto produto)
        {
            using (var context = new EstoqueContext())
            {
                context.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using (var context = new EstoqueContext())
            {
                var produto = context.Produtos.Find(id);
                context.Produtos.Remove(produto);
                context.SaveChanges();
            }
        }
    }
}