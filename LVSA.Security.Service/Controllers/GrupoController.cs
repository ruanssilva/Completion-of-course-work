using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Security.Service.Controllers
{
    public class GrupoController : AutenticaController
    {
        private readonly IGrupoAppService _grupoAppService;

        public GrupoController(IGrupoAppService grupoAppService)
        {
            _grupoAppService = grupoAppService;
        }

        // GET: api/Grupo
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _grupoAppService.Filtrar(f => f.Ativo, false).Select(s => new GrupoViewModel
                {
                    Id = s.Id,
                    Nome = s.Nome
                }).OrderBy(o => o.Nome));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/Grupo/5
        public HttpResponseMessage Get(int id, short filial)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _grupoAppService.Filtrar(f =>
                    f.AplicacaoId == id &&
                    f.FilialId == filial, false
                ).Select(s => new GrupoViewModel
                {
                    Id = s.Id,
                    Nome = s.Nome
                }).OrderBy(o => o.Nome));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
