using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LVSA.Security.Presentation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Parametros da aplicação",
                url: "Aplicacao/Parametro/param/{aplicacao}/{parametro}",
                defaults: new { controller = "Aplicacao", action = "Parametro", parametro = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Permissao grupo",
                url: "{controller}/grupo/{grupo}/aplicacao/{aplicacao}",
                defaults: new { controller = "Permissao", action = "Grupo", aplicacao = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Permissao usuario",
                url: "{controller}/usuario/{usuario}/aplicacao/{aplicacao}",
                defaults: new { controller = "Permissao", action = "Usuario", aplicacao = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Gerenciar recursos",
                url: "{controller}/{action}/aplicacao/{idaplicacao}/{idrecurso}",
                defaults: new { controller = "Recurso", action = "Index", idrecurso = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Pesquisa usuários",
                url: "{controller}/{action}/pesquisa/{codigo}/{id}",
                defaults: new { controller = "Usuario", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
