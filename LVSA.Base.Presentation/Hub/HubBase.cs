using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LVSA.Base.Presentation.Models;
using System.Web.Configuration;

namespace LVSA.Base.Presentation.Hub
{
    public class HubBase : Microsoft.AspNet.SignalR.Hub
    {
        private int _caching
        {
            get
            {
                int result = 5;
                if (!string.IsNullOrWhiteSpace(WebConfigurationManager.AppSettings["Caching"]))
                    int.TryParse(WebConfigurationManager.AppSettings["Caching"], out result);

                return result;
            }
        }

        public void SetCache<TObject>(TObject obj, string key)
            where TObject : class
        {
            if (obj != null)
                HttpRuntime.Cache[key] = obj;
            else
                HttpRuntime.Cache.Remove(key);
        }

        public TObject GetCache<TObject>(string key)
            where TObject : class
        {
            if (HttpRuntime.Cache[key] != null)
                return (TObject)HttpRuntime.Cache[key];
            return default(TObject);
        }

        private IEnumerable<Contexto> _contextos
        {
            get
            {
                return GetCache<IEnumerable<Contexto>>("_contexto");
            }
            set
            {
                SetCache<IEnumerable<Contexto>>(value, "_contexto");
            }
        }
        protected IEnumerable<Contexto> Contextos
        {
            get
            {
                return _contextos ?? new List<Contexto> { };
            }
            set
            {
                _contextos = value;
            }
        }
        private Contexto _contexto
        {
            get
            {

                if (!string.IsNullOrWhiteSpace(Context.QueryString["token"]))
                    return Contextos.Where(w => w.Provider == Context.QueryString["token"] && w.UltimaAtividade > DateTime.Now.AddMinutes(-this._caching)).FirstOrDefault();
                return null;
            }
            set
            {
                if (value != null)
                    Contextos = Contextos.Where(w => w.Provider != value.Provider && w.UltimaAtividade > DateTime.Now.AddMinutes(-this._caching));

                if (value != null && !string.IsNullOrWhiteSpace(value.Provider))
                {
                    value.UltimaAtividade = DateTime.Now;

                    Contextos = Contextos.Concat(new List<Contexto> { value });
                }
            }
        }
        public Contexto Contexto
        {
            get
            {
                if (_contexto == null && Context.QueryString["token"] != null)
                    _contexto = new Contexto(Context.QueryString["token"]);
                return _contexto ?? new Contexto(Context.QueryString["token"]) { };
            }
            set
            {
                _contexto = value;
            }
        }

        /// <summary>
        /// Informação de conexões por Id
        /// </summary>
        protected static Dictionary<string, List<string>> Users { get; set; }
        /// <summary>
        /// Conexões ativas
        /// </summary>
        protected static List<string> Connections { get; set; }
        /// <summary>
        /// Obter conexões ativas de um determinado cliente
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <returns></returns>
        protected IEnumerable<string> Connection(string id)
        {
            var x = Users.Where(w => w.Key == id).Select(s => s.Value).FirstOrDefault();
            if (x != null)
                foreach (var j in x.Where(w => Connections.Contains(w)))
                    yield return j;
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            Connections = Connections ?? new List<string> { };
            Users = Users ?? new Dictionary<string, List<string>>();

            Connections.Add(Context.ConnectionId);
            try
            {
                if (Users.ContainsKey(Contexto.Seguranca.Usuario.Id.ToString()))
                {
                    List<string> _out;
                    if (Users.TryGetValue(Contexto.Seguranca.Usuario.Id.ToString(), out  _out))
                    {
                        _out = _out ?? new List<string> { };
                        _out = _out.Where(w => Connections.Contains(w)).ToList();
                        _out.Add(Context.ConnectionId);
                        Users.Remove(Contexto.Seguranca.Usuario.Id.ToString());
                        Users.Add(Contexto.Seguranca.Usuario.Id.ToString(), _out);
                    }
                    else
                        Users[Contexto.Seguranca.Usuario.Id.ToString()] = new List<string> { Context.ConnectionId };
                }
                else
                    Users.Add(Contexto.Seguranca.Usuario.Id.ToString(), new List<string> { Context.ConnectionId });
            }
            catch { }

            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            Connections = Connections ?? new List<string> { };
            Connections = Connections.Where(w => w != Context.ConnectionId).ToList();

            return base.OnDisconnected(stopCalled);
        }
    }
}