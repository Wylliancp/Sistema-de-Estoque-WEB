using EstoqueWEB.DAO;
using EstoqueWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstoqueWEB.NetMVC5.DAO
{
    public class UsuarioDAO
    {

        public void Adiciona(Usuario usuario)
        {
            using (var context = new EstoqueContext())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
        }

        public IList<Usuario> Lista()
        {
            using (var context = new EstoqueContext())
            {
                return context.Usuarios.ToList();
            }
        }

        public Usuario Busca(string login, string senha)
        {
            using (var context = new EstoqueContext())
            {
                var usuario = context.Usuarios.Where(x => x.Nome == login && x.Senha == senha).FirstOrDefault();
                if (usuario != null)
                {
                    return usuario;
                }
                else
                {
                    return null;
                }
                
            }
        }

        public Usuario BuscaPorId(int id)
        {
            using (var context = new EstoqueContext())
            {
                var usuario = context.Usuarios.Where(x => x.Id == id).FirstOrDefault();
                if (usuario != null)
                {
                    return usuario;
                }
                else
                {
                    return null;
                }

            }
        }


        public void Atualiza(Usuario usuario)
        {
            using (var context = new EstoqueContext())
            {
                context.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using (var context = new EstoqueContext())
            {
                var usuario = context.Usuarios.Find(id);
                context.Usuarios.Remove(usuario);
                context.SaveChanges();
            }
        }
    }
}