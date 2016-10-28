using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;
using LVSA.Housing.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections;
using LVSA.Global.Application.Interfaces;
using LVSA.Security.Application.Models;

namespace LVSA.Housing.Application
{
    public class ReuniaoAppService : AppServiceBase<ReuniaoViewModel, Reuniao, IReuniaoService>, IReuniaoAppService
    {
        private readonly IPresencaService _presencaService;
        private readonly IPessoaFisicaAppService _pessoaFisicaAppService;
        private readonly IMoradorAppService _moradorAppService;
        public ReuniaoAppService(IReuniaoService reuniaoService, IPresencaService presencaService, IPessoaFisicaAppService pessoaFisicaAppService, IMoradorAppService moradorAppService)
            : base(reuniaoService)
        {
            _presencaService = presencaService;
            _pessoaFisicaAppService = pessoaFisicaAppService;
            _moradorAppService = moradorAppService;
        }

        public override void SetSeguranca(Seguranca seguranca, bool filter = true)
        {
            base.SetSeguranca(seguranca, filter);
            _pessoaFisicaAppService.SetSeguranca(seguranca, filter);
            _moradorAppService.SetSeguranca(seguranca, filter);
        }

        public ReuniaoViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

        public override IEnumerable<ReuniaoViewModel> Filtrar(Expression<Func<Reuniao, bool>> predicate)
        {
            var model = base.Filtrar(predicate);

            foreach (var x in model)
                x.PresencaSet = _presencaService.Find(f => f.ReuniaoId == x.Id).Select(s => s.MoradorId).ToArray();


            return model;
        }

        public void Presenca(ReuniaoViewModel model)
        {
            var todos = _presencaService.Find(f => f.ReuniaoId == model.Id).ToList();
            var deletar = todos.Where(w => !model.PresencaSet.Contains(w.MoradorId));
            var incluir = model.PresencaSet.Where(w => !todos.Select(s => s.MoradorId).Contains(w));

            foreach (var x in deletar)
                _presencaService.Delete(x);
            foreach (var x in incluir)
                _presencaService.Add(new Domain.Presenca
                {
                    ColigadaId = (short)Seguranca.ColigadaId,
                    FilialId = (short)Seguranca.FilialId,
                    MoradorId = x,
                    ReuniaoId = model.Id,
                    RECCREATEDBY = Seguranca.CODUSUARIO,
                });
        }

        public override IEnumerable<ReuniaoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public void Ata(ReuniaoViewModel model)
        {
            var reuniao = Service.Find(f => f.Id == model.Id).Single();
            reuniao.Ata = model.Ata;
            Service.Update(reuniao);
        }

        public IEnumerable<ReuniaoViewModel> Reunioes()
        {
            var pessoa = _pessoaFisicaAppService.Filtrar(f => f.PessoaComplemento.UsuarioId == Seguranca.Usuario.Id).SingleOrDefault();
            if (pessoa == null)
                return null;
            else
            {

                var morador = _moradorAppService.Filtrar(f => f.PessoaId == pessoa.Id).SingleOrDefault();
                var model = Filtrar(f => true).ToList();

                return model.Where(w => w.SindicoId == pessoa.Id || w.Sindico.Blocos.SelectMany(sm => sm.Moradias).SelectMany(sm => sm.Moradores).Select(s => s.PessoaId).Contains(morador.Id)).ToList(); //.SelectMany(sm2 => sm2.Moradores).Select(s => s.PessoaId).Contains(pessoa.Id)).Count() > 0).ToList();

            }



            return null;
        }
    }
}
