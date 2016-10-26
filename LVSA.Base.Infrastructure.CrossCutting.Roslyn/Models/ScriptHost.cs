using Roslyn.Scripting;
using Roslyn.Scripting.CSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Base.Infrastructure.CrossCutting.Roslyn.Models
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
                GetType().Assembly
            }
            .ToList()
            .ForEach(asm => _engine.AddReference(asm));

            //Import common namespaces
            new[]
            {
                "System", 
                "System.Linq",
                "System.Collections",
                "System.Collections.Generic"
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
