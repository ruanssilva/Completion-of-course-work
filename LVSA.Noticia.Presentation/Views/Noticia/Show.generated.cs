﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using LVSA.Noticia.Presentation;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Noticia/Show.cshtml")]
    public partial class _Views_Noticia_Show_cshtml : System.Web.Mvc.WebViewPage<IEnumerable<LVSA.Noticia.Application.ViewModels.NoticiaViewModel>>
    {
        public _Views_Noticia_Show_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Noticia\Show.cshtml"
  
    ViewBag.Title = "Notícia";
    ViewBag.Description = "Notícias publicadas";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 9 "..\..\Views\Noticia\Show.cshtml"
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Views\Noticia\Show.cshtml"
     foreach (var x in Model)
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"col-md-2\"");

WriteLiteral(">\r\n\r\n            <ul");

WriteLiteral(" class=\"ace-thumbnails clearfix pull-right\"");

WriteLiteral(">\r\n\r\n                <li>\r\n                    <a");

WriteLiteral(" class=\"cboxElement not-show-loading\"");

WriteAttribute("href", Tuple.Create(" href=\"", 402), Tuple.Create("\"", 507)
, Tuple.Create(Tuple.Create("", 409), Tuple.Create("data:image;base64,", 409), true)
            
            #line 16 "..\..\Views\Noticia\Show.cshtml"
     , Tuple.Create(Tuple.Create("", 427), Tuple.Create<System.Object, System.Int32>(System.Convert.ToBase64String(x.ImagemSet.Select(s=> s.Valor).FirstOrDefault())
            
            #line default
            #line hidden
, 427), false)
);

WriteLiteral(" data-rel=\"colorbox\"");

WriteLiteral(">\r\n                        <img");

WriteAttribute("src", Tuple.Create(" src=\"", 559), Tuple.Create("\"", 663)
, Tuple.Create(Tuple.Create("", 565), Tuple.Create("data:image;base64,", 565), true)
            
            #line 17 "..\..\Views\Noticia\Show.cshtml"
, Tuple.Create(Tuple.Create("", 583), Tuple.Create<System.Object, System.Int32>(System.Convert.ToBase64String(x.ImagemSet.Select(s=> s.Valor).FirstOrDefault())
            
            #line default
            #line hidden
, 583), false)
);

WriteLiteral(" width=\"150\"");

WriteLiteral(" height=\"150\"");

WriteLiteral(" />\r\n                        <div");

WriteLiteral(" class=\"tags\"");

WriteLiteral(">\r\n                            <!-- #section:pages/gallery.tags -->\r\n            " +
"                ");

WriteLiteral("\r\n\r\n                            <!-- /section:pages/gallery.tags -->\r\n           " +
"             </div>\r\n                    </a>\r\n                </li>\r\n\r\n\r\n      " +
"      </ul>\r\n\r\n\r\n\r\n\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n            <h3");

WriteLiteral(" style=\"margin:0;\"");

WriteLiteral("><a");

WriteAttribute("href", Tuple.Create(" href=\"", 1257), Tuple.Create("\"", 1319)
            
            #line 37 "..\..\Views\Noticia\Show.cshtml"
, Tuple.Create(Tuple.Create("", 1264), Tuple.Create<System.Object, System.Int32>(Url.Action("Visualizar", "Noticia", new { id = x.Id })
            
            #line default
            #line hidden
, 1264), false)
);

WriteLiteral(">");

            
            #line 37 "..\..\Views\Noticia\Show.cshtml"
                                                                                               Write(x.Titulo);

            
            #line default
            #line hidden
WriteLiteral(" </a></h3>\r\n            <h4>");

            
            #line 38 "..\..\Views\Noticia\Show.cshtml"
           Write(x.Subtitulo);

            
            #line default
            #line hidden
WriteLiteral(" </h4>\r\n\r\n            \r\n\r\n");

WriteLiteral("            ");

            
            #line 42 "..\..\Views\Noticia\Show.cshtml"
        Write(new HtmlString(x.Texto));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n            <br />\r\n            <br />\r\n            \r\n            \r\n\r\n");

            
            #line 49 "..\..\Views\Noticia\Show.cshtml"
            
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\Noticia\Show.cshtml"
             if (x.ImagemSet != null && x.ImagemSet.Count() > 0)
            {

            
            #line default
            #line hidden
WriteLiteral("                <ul");

WriteLiteral(" class=\"ace-thumbnails clearfix \"");

WriteLiteral(">\r\n");

            
            #line 52 "..\..\Views\Noticia\Show.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\Noticia\Show.cshtml"
                     foreach (var y in x.ImagemSet)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <li>\r\n                            <a");

WriteLiteral(" class=\"cboxElement not-show-loading\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1817), Tuple.Create("\"", 1881)
, Tuple.Create(Tuple.Create("", 1824), Tuple.Create("data:image;base64,", 1824), true)
            
            #line 55 "..\..\Views\Noticia\Show.cshtml"
            , Tuple.Create(Tuple.Create("", 1842), Tuple.Create<System.Object, System.Int32>(System.Convert.ToBase64String(y.Valor)
            
            #line default
            #line hidden
, 1842), false)
);

WriteLiteral(" data-rel=\"colorbox\"");

WriteLiteral(">\r\n                                <img");

WriteAttribute("src", Tuple.Create(" src=\"", 1941), Tuple.Create("\"", 2004)
, Tuple.Create(Tuple.Create("", 1947), Tuple.Create("data:image;base64,", 1947), true)
            
            #line 56 "..\..\Views\Noticia\Show.cshtml"
, Tuple.Create(Tuple.Create("", 1965), Tuple.Create<System.Object, System.Int32>(System.Convert.ToBase64String(y.Valor)
            
            #line default
            #line hidden
, 1965), false)
);

WriteLiteral(" width=\"35\"");

WriteLiteral(" height=\"35\"");

WriteLiteral(" />\r\n                                <div");

WriteLiteral(" class=\"tags\"");

WriteLiteral(">\r\n                                    <!-- #section:pages/gallery.tags -->\r\n    " +
"                                ");

WriteLiteral("\r\n\r\n                                    <!-- /section:pages/gallery.tags -->\r\n   " +
"                             </div>\r\n                            </a>\r\n         " +
"               </li>\r\n");

            
            #line 67 "..\..\Views\Noticia\Show.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("\r\n                </ul>\r\n");

            
            #line 70 "..\..\Views\Noticia\Show.cshtml"

            }

            
            #line default
            #line hidden
WriteLiteral("            \r\n            <br />\r\n            \r\n            <span");

WriteLiteral(" class=\"\"");

WriteLiteral("><small>publicado em ");

            
            #line 75 "..\..\Views\Noticia\Show.cshtml"
                                          Write(x.PublicadoEm);

            
            #line default
            #line hidden
WriteLiteral(" por <b>");

            
            #line 75 "..\..\Views\Noticia\Show.cshtml"
                                                                Write(x.Autor);

            
            #line default
            #line hidden
WriteLiteral("</b></small></span>\r\n\r\n\r\n\r\n\r\n        </div>\r\n");

            
            #line 81 "..\..\Views\Noticia\Show.cshtml"
        

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"space-20\"");

WriteLiteral("></div>\r\n");

            
            #line 83 "..\..\Views\Noticia\Show.cshtml"

    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
