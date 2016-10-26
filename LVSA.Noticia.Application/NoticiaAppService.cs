using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Noticia.Application.Interfaces;
using LVSA.Noticia.Application.ViewModels;
using LVSA.Noticia.Domain;
using LVSA.Noticia.Domain.Interfaces.Services;

namespace LVSA.Noticia.Application
{
    public class NoticiaAppService : AppServiceBase<NoticiaViewModel, Noticia.Domain.Noticia, INoticiaService>, INoticiaAppService
    {
        private readonly INoticiaAplicacaoService _noticiaAplicacaoService;
        private readonly INoticiaContextoService _noticiaContextoService;
        private readonly IImagemService _imagemService;
        private readonly INoticiaImagemService _noticiaImagemService;
        private readonly INoticiaVisualizadaService _noticiaVisualizadaService;

        public NoticiaAppService(INoticiaService noticiaService, INoticiaAplicacaoService noticiaAplicacaoService, INoticiaContextoService noticiaContextoService, IImagemService imagemService, INoticiaImagemService noticiaImagemService, INoticiaVisualizadaService noticiaVisualizadaService)
            : base(noticiaService)
        {
            _noticiaAplicacaoService = noticiaAplicacaoService;
            _noticiaContextoService = noticiaContextoService;
            _imagemService = imagemService;
            _noticiaImagemService = noticiaImagemService;
            _noticiaVisualizadaService = noticiaVisualizadaService;
        }

        public override IEnumerable<NoticiaViewModel> Filtrar(System.Linq.Expressions.Expression<Func<Domain.Noticia, bool>> predicate)
        {
            var model = base.Filtrar(predicate).ToList();

            foreach (var m in model)
            {
                m.AplicacaoIdSet = _noticiaAplicacaoService.Find(f => f.NoticiaId == m.Id).Select(s => s.AplicacaoId).ToArray();
                m.FilialIdSet = _noticiaContextoService.Find(f => f.NoticiaId == m.Id).Select(s => s.FilialId).ToArray();
                m.UsuarioIdSet = _noticiaVisualizadaService.Find(f => f.NoticiaId == m.Id).Select(s => s.UsuarioId).ToArray();

                var imagens = _noticiaImagemService.Find(f => f.NoticiaId == m.Id).ToList().Select(s => s.Imagem).ToList();
                m.ImagemSet = Mapper.Map<IEnumerable<Imagem>, IEnumerable<ImagemViewModel>>(imagens);

                yield return m;
            }
        }

        public override IEnumerable<NoticiaViewModel> Todos()
        {
            return Filtrar(f => true);
        }
        public NoticiaViewModel ObterPorId(long id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

        public override NoticiaViewModel Incluir(NoticiaViewModel model)
        {
            var AplicacaoIdSet = model.AplicacaoIdSet;
            var ImagemSet = model.ImagemSet;
            model = base.Incluir(model);

            model.ImagemSet = ImagemSet;

            foreach (var i in model.ImagemSet.Where(w => !(w.Id > 0)))
            {
                var entity = new Imagem
                {
                    Valor = i.Valor,
                    ContentType = i.ContentType,

                    RECCREATEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null,
                };
                _imagemService.Add(entity);

                _noticiaImagemService.Add(new NoticiaImagem
                {
                    NoticiaId = model.Id,
                    ImagemId = entity.Id,

                    RECCREATEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null,
                });

                i.Id = entity.Id;
            }

            foreach (var x in AplicacaoIdSet)
                _noticiaAplicacaoService.Add(new NoticiaAplicacao
                {
                    NoticiaId = model.Id,
                    AplicacaoId = x,
                    RECCREATEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null,
                });

            return model;
        }

        public override NoticiaViewModel Atualizar(NoticiaViewModel model)
        {
            var AplicacaoIdSet = model.AplicacaoIdSet ?? new int[] { };
            var ImagemSet = model.ImagemSet.ToList() ?? new List<ImagemViewModel> { };
            model = base.Atualizar(model);

            model.ImagemSet = ImagemSet;

            var inteiros = model.ImagemSet.Select(s => s.Id).ToList();

            var retirar = _noticiaImagemService.Find(f => f.NoticiaId == model.Id && !inteiros.Contains(f.ImagemId)).ToList();
            foreach (var r in retirar)
                _noticiaImagemService.Delete(r);

            foreach (var i in model.ImagemSet.Where(w => !(w.Id > 0) && w.Valor != null))
            {
                var entity = new Imagem
                {
                    Valor = i.Valor,
                    ContentType = i.ContentType,

                    RECCREATEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null,
                };
                _imagemService.Add(entity);

                _noticiaImagemService.Add(new NoticiaImagem
                {
                    NoticiaId = model.Id,
                    ImagemId = entity.Id,

                    RECCREATEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null,
                });

                i.Id = entity.Id;
            }



            var noticiaaplicacao = _noticiaAplicacaoService.Find(f => f.NoticiaId == model.Id).ToList();

            foreach (var d in noticiaaplicacao.Where(w => !AplicacaoIdSet.Contains(w.AplicacaoId)))
                _noticiaAplicacaoService.Delete(d);

            foreach (var i in AplicacaoIdSet.Where(w => !noticiaaplicacao.Select(s => s.AplicacaoId).Contains(w)))
                _noticiaAplicacaoService.Add(new NoticiaAplicacao
                {
                    NoticiaId = model.Id,
                    AplicacaoId = i,
                    RECCREATEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null,
                });

            return model;
        }


        public void Contexto(NoticiaViewModel noticia, IEnumerable<Security.Application.ViewModels.FilialViewModel> niveis)
        {
            var noticiacontexto = _noticiaContextoService.Find(f => f.NoticiaId == noticia.Id).ToList();

            foreach (var d in noticiacontexto.Where(w => !niveis.Select(s => s.Id).Contains(w.FilialId)))
                _noticiaContextoService.Delete(d);

            foreach (var i in niveis.Where(w => !noticiacontexto.Select(s => s.FilialId).Contains(w.Id)))
                _noticiaContextoService.Add(new NoticiaContexto
                {
                    NoticiaId = noticia.Id,
                    ColigadaId = i.ColigadaId,
                    FilialId = i.Id,
                    RECCREATEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null,
                });
        }


        public void Visualiza(NoticiaViewModel noticia, Security.Application.ViewModels.UsuarioViewModel usuario)
        {
            _noticiaVisualizadaService.Add(new NoticiaVisualizada
            {
                NoticiaId = noticia.Id,
                UsuarioId = usuario.Id,

                RECCREATEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null,
            });
        }
    }
}
