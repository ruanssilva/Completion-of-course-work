using LVSA.Base.Presentation.Controllers;
using Roslyn.Scripting;
using Roslyn.Scripting.CSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace LVSA.Report.Presentation.Models
{
    public class ScriptHost
    {
        private readonly Session _session;
        private readonly ScriptEngine _engine;


        public ScriptHost()
            : this(null)
        {
            //Just fall back to the below constructor
        }


        public ScriptHost(dynamic context)
        {

            if (context == null)
                context = this;

            //Create the script engine
            _engine = new ScriptEngine();

            //Let us use engine's Addreference for adding some common
            //assemblies
            new[]
            {
                typeof (Type).Assembly,
                typeof (ICollection).Assembly,
                typeof (ListDictionary).Assembly,
                typeof (System.Console).Assembly,
                typeof (ScriptHost).Assembly,
                typeof (IEnumerable<>).Assembly,
                typeof (IQueryable).Assembly,
                typeof (WebGrid).Assembly,
                typeof (ActionResult).Assembly,
                typeof (LVSA.Base.Presentation.Controllers.ControllerBase).Assembly,
                typeof (LVSA.Report.Presentation.Controllers.ControllerBase).Assembly,
                typeof (System.ComponentModel.DataAnnotations.DisplayAttribute).Assembly,
                GetType().Assembly
            }
            .ToList()
            .ForEach(asm => _engine.AddReference(asm));

            //Import common namespaces
            new[]
            {
                "System", "System.Linq",
                "System.Collections",
                "System.Collections.Generic",
                "System.ComponentModel.DataAnnotations",
                "System.Web.Mvc",
                "System.Web.Helpers",
                "LVSA.Base.Presentation.Controllers",
                "LVSA.Base.Presentation.ViewModels",
            }
            .ToList()
            .ForEach(ns => _engine.ImportNamespace(ns));

            _session = _engine.CreateSession(context);
        }

        public object Execute(string code)
        {
            return _session.Execute(code);
        }

        public void ImportNamespace(string ns)
        {
            _session.ImportNamespace(ns);
        }

        public void AddReference(Assembly asm)
        {
            _session.AddReference(asm);
        }
    }
}