using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using LVSA.Base.Infrastructure.CrossCutting.REST;

namespace LVSA.Base.Presentation.Rest
{
    public class RestBase<TEntity>
    {
        private Dictionary<string, string> _headers { get; set; }
        protected Dictionary<string, string> Headers
        {
            get
            {
                if (_headers == null)
                    _headers = new Dictionary<string, string> { };
                return _headers;
            }
            set { _headers = value; }
        }
        private object _data { get; set; }
        public object Data { get { return _data; } set { _data = value; } }
        private string _uri { get; set; }
        private string _contenttype { get; set; }
        private string _server { get { return WebConfigurationManager.AppSettings["Address_LVSA.Security.Service"]; } }

        protected RestBase(string uri, string contenttype = URequestContentTypes.ApplicationJson, object data = null)
        {
            _uri = uri;
            _contenttype = contenttype;
            _data = data;
        }

        public virtual HttpWebResponse Response(string method, string uri = null, string contenttype = URequestContentTypes.ApplicationJson)
        {
            URequest request = new URequest(_server + (uri ?? _uri));

            foreach (var x in Headers)
                request.Headers.Add(x.Key, x.Value);

            request.ContentType = contenttype ?? _contenttype;
            request.Method = method;

            if (_data != null)
                request.setData<object>(_data);

            return (HttpWebResponse)request.Response();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            HttpWebResponse response = Response(WebRequestMethods.Http.Get);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<IEnumerable<TEntity>>(new StreamReader(response.GetResponseStream()).ReadToEnd());
            else
                throw new HttpResponseException(response.StatusCode);
        }

        public virtual void Post()
        {
            HttpWebResponse response = Response(WebRequestMethods.Http.Post);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new WebException("", null, WebExceptionStatus.UnknownError, (WebResponse)response);
        }

        public void Post<TKey>(TKey id)
        {
            HttpWebResponse response = Response(WebRequestMethods.Http.Post, uri: _uri + "/" + id);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpResponseException(response.StatusCode);
        }
    }
}