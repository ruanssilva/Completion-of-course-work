using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Security.Service.Controllers
{
    public class AplicacaoController : AutenticaController
    {
        // GET: api/Aplicacao
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Seguranca.AplicacaoSet.Where(w => w.Ativo).GroupBy(g => g.Id).Select(s => new AplicacaoViewModel
                {
                    Id = s.First().Id,
                    Nome = s.First().Nome,
                    Abstrata = s.First().Abstrata,
                    Blank = s.First().Blank,
                    Exibicao = s.First().Exibicao,
                    RecursoSet = s.First().RecursoSet,
                    Ativo = s.First().Ativo,
                    Descricao = s.First().Descricao,
                    Icon = s.First().Icon,
                    Link = s.First().Link,
                    Sigla = s.First().Sigla,
                    ParametroSet = s.First().ParametroSet,
                    ParametroIdSet = s.First().ParametroIdSet,
                    AplicacaoSet = s.First().AplicacaoSet,
                    Desktop = s.First().Desktop
                }).OrderBy(o => o.Nome));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/Aplicacao/5
        public HttpResponseMessage Get(short id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _contextoAppService.Acessos(f => f.FilialId == id && f.Ativo).GroupBy(g => g.Id).Select(s => new AplicacaoViewModel
                {
                    Id = s.First().Id,
                    Nome = s.First().Nome,
                    Exibicao = s.First().Exibicao,
                    Blank = s.First().Blank,
                    Icon = s.First().Icon,
                    Sigla = s.First().Sigla,
                    Ativo = s.First().Ativo,
                    Descricao = s.First().Descricao,
                    Link = s.First().Link,
                    Desktop = s.First().Desktop
                }).OrderBy(o => o.Nome));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST: api/Aplicacao
        public HttpResponseMessage Post(int? id = null)
        {
            try
            {
                if (id != null)
                {
                    var aplicacao = Seguranca.AplicacaoSet.Where(w => w.Id == id).SingleOrDefault();
                    if (aplicacao == null)
                        throw new Exception("Registro não encontrado");

                    Seguranca.Aplicacao = aplicacao;
                    Seguranca._aplicacao = aplicacao;
                }
                else
                    Seguranca.Aplicacao = null;

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
