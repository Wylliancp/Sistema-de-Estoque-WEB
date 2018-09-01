﻿using System.Web.Mvc;
using System.Web.Routing;

namespace EstoqueWEB.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            object usuario = filterContext.HttpContext.Session["usuarioLogado"];
            if (usuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                                            new RouteValueDictionary(
                                                new { action = "Index", controller = "Login" }));
            }
        }

    }
}