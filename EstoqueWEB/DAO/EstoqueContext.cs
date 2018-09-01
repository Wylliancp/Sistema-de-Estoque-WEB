using EstoqueWEB.Migrations;
using EstoqueWEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EstoqueWEB.DAO
{
    public class EstoqueContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CategoriaDoProduto> Categorias { get; set; }

        public EstoqueContext() : base("Estoque")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EstoqueContext, Configuration>());
        }
        //public EstoqueContext():base("Loja")
        //{
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<EstoqueContext, Configuration>());
        //}


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}