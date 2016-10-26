using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LVSA.Base.Application.Exceptions;
using LVSA.Base.Presentation.Exceptions;
using LVSA.Base.Presentation.Rest;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Noticia.Application.ViewModels;
using LVSA.Security.Application.Models;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Base.Presentation.Models
{
    public class Contexto
    {
        public static DateTime AtualizadoEm { get; set; }

        private string _token { get; set; }
        private readonly ContextoRest _contextoRest;
        private readonly TokenRest _tokenRest;
        private readonly ColigadaRest _coligadaRest;
        private readonly FilialRest _filialRest;
        private readonly AplicacaoRest _aplicacaoRest;
        private readonly ParametroRest _parametroRest;
        private readonly NoticiaRest _noticiaRest;
        private readonly LogRest _logRest;
        private readonly PasswordRest _passwordRest;

        public string Provider { get { return _token; } }
        public DateTime UltimaAtividade { get; set; }

        private Seguranca _seguranca { get; set; }
        public Seguranca Seguranca
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_token) && _seguranca == null)
                {
                    AtualizadoEm = DateTime.Now;

                    _seguranca = _contextoRest.Get();
                }

                return _seguranca;
            }
        }

        private IEnumerable<NoticiaViewModel> _noticias { get; set; }
        public IEnumerable<NoticiaViewModel> Noticias
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_token) && _noticias == null)
                    _noticias = _noticiaRest.Get();

                return _noticias;
            }
        }

        public Contexto(string token)
        {
            _token = token;

            _contextoRest = new ContextoRest(_token);
            _coligadaRest = new ColigadaRest(_token);
            _filialRest = new FilialRest(_token);
            _aplicacaoRest = new AplicacaoRest(_token);
            _parametroRest = new ParametroRest(_token);
            _noticiaRest = new NoticiaRest(_token);
            _logRest = new LogRest(_token);
            _passwordRest = new PasswordRest(token);
            

            _tokenRest = new TokenRest();

            if (!string.IsNullOrWhiteSpace(_token))
            {
                if (!Seguranca.ColigadaSetIsLoad)
                    Seguranca.SetColigadaSet(_coligadaRest.Get());
                if (!Seguranca.FilialSetIsLoad)
                    Seguranca.SetFilialSet(_filialRest.Get());
                if (!Seguranca.AplicacaoSetIsLoad || AtualizadoEm.AddMinutes(1) <= DateTime.Now)
                    Seguranca.SetAplicacaoSet(_aplicacaoRest.Get());

                if (AtualizadoEm.AddMinutes(1) <= DateTime.Now)
                    AtualizadoEm = DateTime.Now;
            }
        }

        public void SetLog(string log, int style)
        {
            //_logRest.Data = new { Mensagem = log, Style = style };
            //_logRest.Post();
        }

        public ParamViewModel GetParam(string key)
        {
            var param = Seguranca.Aplicacao.ParametroSet.Where(w => w.Codigo == key).SingleOrDefault();
            if (param == null)
                throw new NoRecordsFoundException("Parâmetro não encontrado");
            return new ParamViewModel
            {
                Exibicao = param.Exibicao,
                Multi = param.Multi,
                Collection = _parametroRest.Get(param.Codigo),
                Key = key,
                TSQLAtivo = param.TSQLAtivo,
                Obrigatorio = param.Obrigatorio,
                Mascara = param.Mascara,
                Value = Seguranca.Parametros.ContainsKey(key) ? Seguranca.Parametros[key] : ""
            };
        }

        public void SetParam(string key, string value)
        {
            _parametroRest.Post(key, value);
        }

        public void Reload()
        {
            _seguranca = null;
        }

        public void SignOut()
        {
            _contextoRest.Post<bool>(true);
        }

        public bool IsAuthentication()
        {
            return Seguranca != null && Seguranca.Usuario != null;
        }

        public string Token(string usuario, string senha)
        {
            _tokenRest.Data = new
            {
                
                username = usuario,
                password = senha,
                grant_type = "password"
            };

            dynamic obj = _tokenRest.Post();
            if (obj.error == "WSTBC")
            {
                string msg = (string)obj.error_description;
                throw new WSTBCException(msg.Replace("Server was unable to process request. --->", ""));
            }

            _token = (string)obj.access_token;
            return _token;
        }

        public string Password(string oldPassword, string NewPassword, string ConfirmPassword)
        {
            _passwordRest.Data = new 
            {
                grant_type = "password",
                OldPassword = oldPassword,
                NewPassword = NewPassword,
                ConfirmPassword = ConfirmPassword
            };

            return _passwordRest.Post();
        }

        public void SetColigada(ColigadaViewModel coligada)
        {
            _coligadaRest.Post<short>(coligada.Id);
        }

        public void SetFilial(FilialViewModel filial)
        {
            _filialRest.Post<short>(filial.Id);
        }

        public void SetAplicacao(AplicacaoViewModel aplicacao)
        {
            _aplicacaoRest.Post<int?>(aplicacao != null ? (int?)aplicacao.Id : null);
        }
    }
}