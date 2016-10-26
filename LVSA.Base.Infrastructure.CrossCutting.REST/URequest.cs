using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace LVSA.Base.Infrastructure.CrossCutting.REST
{
    public static class URequestContentTypes
    {
        public const string XwwwFormUrlEncoded = "application/x-www-form-urlencoded; charset=UTF-8";
        public const string ApplicationJson = "application/json; charset=UTF-8";
    }

    public class URequest
    {
        public URequest()
            : this("default url")
        {
        }

        public URequest(string requestUriString)
        {
            _webrequest = WebRequest.Create(requestUriString);
        }

        private WebRequest _webrequest { get; set; }

        private string _data { get; set; }
        private byte[] _stream { get; set; }
        public string Data
        {
            get { return _data ?? ""; }
        }

        public void setData<TObject>(TObject obj)
        {
            string _d = "";

            switch (this.ContentType)
            {
                case URequestContentTypes.ApplicationJson:

                    _d = JsonConvert.SerializeObject(obj);

                    break;

                case URequestContentTypes.XwwwFormUrlEncoded:

                    foreach (var p in obj.GetType().GetProperties())
                        _d += p.Name + "=" + p.GetValue(obj).ToString() + "&";

                    break;
            }

            setData(_d);
        }
        public void setData(string data)
        {
            _stream = this.Encoding.GetBytes(data);
            _data = data;
        }
        public WebHeaderCollection Headers { get { return _webrequest.Headers; } }

        public int ContentLength { get { return Data.Length; } }
        private Encoding _encoding { get; set; }
        public Encoding Encoding { get { return _encoding ?? Encoding.UTF8; } set { _encoding = value; } }

        private string _contenttype { get; set; }
        public string ContentType { get { return _contenttype ?? URequestContentTypes.XwwwFormUrlEncoded; } set { _contenttype = value; } }

        private string _method { get; set; }
        public string Method { get { return string.IsNullOrEmpty(_method) ? WebRequestMethods.Http.Get : _method; } set { _method = value; } }

        public WebResponse Response()
        {
            _webrequest.Method = this.Method;
            _webrequest.ContentType = this.ContentType;

            if (_webrequest.Method.ToUpper() != WebRequestMethods.Http.Get.ToUpper())
            {
                _webrequest.ContentLength = this.ContentLength;
                if (_stream != null)
                    using (var stream = _webrequest.GetRequestStream())
                        stream.Write(_stream, 0, ContentLength);
            }

            try
            {
                return _webrequest.GetResponse();
            }
            catch (WebException exception)
            {
                return exception.Response;
            }
        }

    }
}
