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
    using LVSA.Base.Presentation;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Erro/500.cshtml")]
    public partial class _Views_Erro_500_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Erro_500_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Views\Erro\500.cshtml"
  
    string serverCDN = System.Web.Configuration.WebConfigurationManager.AppSettings["Address_LVSA.CDN.Presentation"];    
    
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout2.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<br /><br />\r\n\r\n<div");

WriteLiteral(" class=\"center\"");

WriteLiteral(">\r\n    <img");

WriteLiteral(" class=\"img-responsive\"");

WriteLiteral(" style=\"width: 400px; height:auto; margin:0 auto;\"");

WriteAttribute("src", Tuple.Create(" src=\"", 337), Tuple.Create("\"", 384)
            
            #line 12 "..\..\Views\Erro\500.cshtml"
         , Tuple.Create(Tuple.Create("", 343), Tuple.Create<System.Object, System.Int32>(serverCDN
            
            #line default
            #line hidden
, 343), false)
, Tuple.Create(Tuple.Create("", 355), Tuple.Create("/Content/Images/logo_LVSA.png", 355), true)
);

WriteLiteral(" border=\"0\"");

WriteLiteral(">\r\n</div>\r\n\r\n<br/>\r\n<div");

WriteLiteral(" class=\"col-xs-12\"");

WriteLiteral(">\r\n    <!-- PAGE CONTENT BEGINS -->\r\n    <!-- #section:pages/error -->\r\n    <div");

WriteLiteral(" class=\"\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"\"");

WriteLiteral(">\r\n            <h1");

WriteLiteral(" class=\"white lighter smaller\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" class=\"white bigger-125\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"ace-icon fa fa-random\"");

WriteLiteral("></i>\r\n                    500\r\n                </span>\r\n                Algo deu" +
" errado\r\n            </h1>\r\n\r\n            <hr>\r\n            <h3");

WriteLiteral(" class=\"lighter smaller white\"");

WriteLiteral(">\r\n                Mas já estamos trabalhando\r\n                <i");

WriteLiteral(" class=\"ace-icon fa fa-wrench icon-animated-wrench bigger-125\"");

WriteLiteral("></i>\r\n                nisto!\r\n            </h3>\r\n\r\n            <div");

WriteLiteral(" class=\"space\"");

WriteLiteral("></div>\r\n\r\n            <div>\r\n                <h4");

WriteLiteral(" class=\"lighter smaller white\"");

WriteLiteral(">Enquanto isso, tente um dos seguintes procedimentos:</h4>\r\n\r\n                <ul" +
"");

WriteLiteral(" class=\"list-unstyled spaced inline bigger-110 margin-15 white\"");

WriteLiteral(">\r\n                    <li>\r\n                        <i");

WriteLiteral(" class=\"ace-icon fa fa-hand-o-right white\"");

WriteLiteral("></i>\r\n                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1439), Tuple.Create("\"", 1475)
            
            #line 44 "..\..\Views\Erro\500.cshtml"
, Tuple.Create(Tuple.Create("", 1446), Tuple.Create<System.Object, System.Int32>(Url.Action("Logout","Login")
            
            #line default
            #line hidden
, 1446), false)
);

WriteLiteral(">Sair</a> e entrar na aplicação novamente pode resolver\r\n                    </li" +
">\r\n                </ul>\r\n            </div>\r\n\r\n            <hr>\r\n            <d" +
"iv");

WriteLiteral(" class=\"space\"");

WriteLiteral("></div>\r\n\r\n            <div");

WriteLiteral(" class=\"center\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" href=\"javascript:history.back()\"");

WriteLiteral(" class=\"btn btn-bold btn-white btn-grey\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"ace-icon fa fa-arrow-left\"");

WriteLiteral("></i>\r\n                    Voltar\r\n                </a>\r\n\r\n                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1925), Tuple.Create("\"", 1960)
            
            #line 58 "..\..\Views\Erro\500.cshtml"
, Tuple.Create(Tuple.Create("", 1932), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "Home")
            
            #line default
            #line hidden
, 1932), false)
);

WriteLiteral(" class=\"btn btn-white btn-bold btn-primary\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"ace-icon fa fa-home\"");

WriteLiteral("></i>\r\n                    Página inicial\r\n                </a>\r\n            </di" +
"v>\r\n        </div>\r\n    </div>\r\n\r\n    <!-- /section:pages/error -->\r\n    <!-- PA" +
"GE CONTENT ENDS -->\r\n</div>\r\n\r\n");

DefineSection("footer", () => {

WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"footer\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"footer-inner\"");

WriteLiteral(">\r\n            <!-- #section:basics/footer -->\r\n            <div");

WriteLiteral(" class=\"footer-content\"");

WriteLiteral(" style=\"border:none!important; color:#ffffff!important;\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" class=\"smaller-90\"");

WriteLiteral(">\r\n                    © ");

            
            #line 76 "..\..\Views\Erro\500.cshtml"
                 Write(DateTime.Now.Year);

            
            #line default
            #line hidden
WriteLiteral(" - UBEC - União Brasiliense de Educação e Cultura\r\n                </span>\r\n     " +
"       </div>\r\n\r\n            <!-- /section:basics/footer -->\r\n        </div>\r\n  " +
"  </div>\r\n");

});

WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
