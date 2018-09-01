using EstoqueWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstoqueWEB.DAO
{
    public class CategoriasDAO
    {

        public void Adiciona(CategoriaDoProduto categoria)
        {
            using(var context = new EstoqueContext())
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }
        }

        public IList<CategoriaDoProduto> lista()
        {
            using (var context = new EstoqueContext())
            {
                return context.Categorias.ToList();
            }
        }

        public CategoriaDoProduto BuscaPorId(int id)
        {
            using (var context = new EstoqueContext())
            {
                return context.Categorias.Find(id);
            }
        }

        public void Atualiza(CategoriaDoProduto categoria)
        {
            using (var context = new EstoqueContext())
            {
                context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        
        public void Excluir(int id)
        {
            using (var context = new EstoqueContext())
            {
                var categoria = context.Categorias.Find(id);
                context.Categorias.Remove(categoria);
                context.SaveChanges();
            }
        }

    }
}