using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Security.Application.Models
{
    public class Seguranca
    {
        public Seguranca()
        {

        }

        public Seguranca(UsuarioViewModel usuario)
        {
            this.Usuario = usuario;
        }

        public string Id { get; set; }
        public DateTime UltimaAtividade { get; set; }
        public bool Desconectar { get; set; }

        private IDictionary<string, string> _parametros { get; set; }
        public IDictionary<string, string> Parametros
        {
            get
            {
                if (_parametros == null)
                    _parametros = new Dictionary<string, string> { };

                return _parametros;
            }
            set { _parametros = value; }
        }

        public static Ambiente Ambiente { get; set; }

        public static void SetIContexto(IContextoAppService contextoAppService)
        {
            if (contextoAppService != null)
            {
                _coligadaset = contextoAppService.ObterTodasColigada();
                _filialset = contextoAppService.ObterTodasFilial();
            }
        }
        public static void SetIAplicacao(IAplicacaoAppService aplicacaoAppService)
        {
            if (aplicacaoAppService != null)
                _aplicacaoset = aplicacaoAppService.Filtrar(f => f.Ativo).OrderBy(o => o.Nome).ToList();
        }

        public static void SetColigadaSet(IEnumerable<ColigadaViewModel> coligadaset) { _coligadaset = coligadaset; }
        public static void SetFilialSet(IEnumerable<FilialViewModel> filialset) { _filialset = filialset; }
        public static void SetAplicacaoSet(IEnumerable<AplicacaoViewModel> aplicacaoset) { _aplicacaoset = aplicacaoset; }
        private static IEnumerable<AplicacaoViewModel> _aplicacaoset { get; set; }
        public static bool AplicacaoSetIsLoad { get { return _aplicacaoset != null && _aplicacaoset.Count() > 0; } }




        /// <summary>
        /// Todas coligadas existentes
        /// </summary>
        private static IEnumerable<ColigadaViewModel> _coligadaset { get; set; }
        public static bool ColigadaSetIsLoad { get { return _coligadaset != null; } }
        /// <summary>
        /// Todas filiais existentes
        /// </summary>
        private static IEnumerable<FilialViewModel> _filialset { get; set; }
        public static bool FilialSetIsLoad { get { return _filialset != null; } }

        /// <summary>
        /// Usuário que é gerenciado pelo objeto
        /// </summary>
        private UsuarioViewModel _usuario { get; set; }
        /// <summary>
        /// Usuário que é gerenciado pelo objeto
        /// </summary>
        public UsuarioViewModel Usuario
        {
            get { return _usuario; }
            set
            {
                _usuario = value;



                if (_usuario != null && _usuario.UsuarioFilialSet != null)
                {
                    if (_usuario.UsuarioFilialSet.Select(w => w.ColigadaId).Distinct().Count() == 1)
                        Coligada = _coligadaset.Where(w => w.Id == _usuario.UsuarioFilialSet.Select(s => s.ColigadaId).First()).Single();

                    if (_usuario.UsuarioFilialSet.Select(s => s.FilialId).Distinct().Count() == 1)
                        Filial = _filialset.Where(w => w.Id == _usuario.UsuarioFilialSet.Select(s => s.FilialId).First()).Single();

                }


            }
        }
        /// <summary>
        /// Grupos do usuário gerenciado
        /// </summary>
        public IEnumerable<GrupoViewModel> GrupoSet
        {
            get
            {
                if (Usuario != null && Usuario.GrupoSet != null)
                    return Usuario.GrupoSet.Where(w =>
                        w.Ativo &&
                        w.ColigadaId == ColigadaId &&
                        w.FilialId == FilialId
                    );
                return null;
            }
        }
        /// <summary>
        /// Recursos disponíveis para o usuário
        /// </summary>
        public IEnumerable<RecursoViewModel> RecursoSet
        {
            get
            {
                if (Aplicacao != null && Aplicacao.RecursoSet != null && Usuario != null && Usuario.PermissaoSet != null)
                    return Aplicacao.RecursoSet.Where(w => Usuario.PermissaoSet.Select(s => s.RecursoId).Contains(w.Id)).GroupBy(g => g.Id).Select(s => s.First());
                return null;
            }
        }
        /// <summary>
        /// Aplicações disponíveis para o usuário
        /// </summary>
        public IEnumerable<AplicacaoViewModel> AplicacaoSet
        {
            get
            {
                if (_aplicacaoset != null && Usuario != null && GrupoSet != null)
                    return _aplicacaoset.Where(w => w.Ativo && GrupoSet.Select(s => s.AplicacaoId).Distinct().Contains(w.Id));// Usuario.PermissaoSet.Where(w => w.Grupo != null && w.Grupo.ColigadaId == ColigadaId && w.Grupo.FilialId == FilialId && w.Grupo.CODTIPOCURSO == CODTIPOCURSO).Select(s => s.Recurso.Aplicacao).Where(w => w.Ativo).Distinct();
                return null;
            }
        }
        /// <summary>
        /// Coligadas disponíveis para o usuário
        /// </summary>
        public IEnumerable<ColigadaViewModel> ColigadaSet
        {
            get
            {
                if (Usuario != null && Usuario.UsuarioFilialSet != null && Usuario.UsuarioFilialSet.Count() > 0)
                {
                    var ColigadaIdset = Usuario.UsuarioFilialSet.Select(s => s.ColigadaId).Distinct();
                    return _coligadaset.Where(w => ColigadaIdset.Contains(w.Id));
                }

                return null;
            }
        }
        /// <summary>
        /// Filiais disponíveis para o usuário
        /// </summary>
        public IEnumerable<FilialViewModel> FilialSet
        {
            get
            {
                if (Usuario != null && Usuario.UsuarioFilialSet != null && Usuario.UsuarioFilialSet.Count() > 0)
                {
                    var FilialIdset = Usuario.UsuarioFilialSet.Select(s => s.FilialId).Distinct();
                    var m = _filialset.Where(w => FilialIdset.Contains(w.Id)).ToList();

                    m.ForEach(f =>
                    {
                        f.Coligada = Usuario.UsuarioFilialSet.Where(w => w.FilialId == f.Id).Select(s => ColigadaSet.Where(w => w.Id == s.ColigadaId).Single()).FirstOrDefault();
                    });

                    return m;
                }

                return null;
            }
        }

        /// <summary>
        /// Coligada selecionada para o contexto
        /// </summary>
        private ColigadaViewModel _coligada { get; set; }
        /// <summary>
        /// Filial selecionada para o contexto
        /// </summary>
        private FilialViewModel _filial { get; set; }



        /// <summary>
        /// Coligada selecionada para o contexto
        /// </summary>
        public ColigadaViewModel Coligada
        {
            get { return _coligada; }
            set
            {
                if (value != null && !ColigadaSet.Select(s => s.Id).Contains(value.Id))
                    throw new Exception("Usuário sem acesso a coligada selecionada");

                if (value == null)
                {
                    ColigadaId = null;

                    Parametros.Remove("Coligada");
                }
                else
                {
                    ColigadaId = value.Id;
                    if (!Parametros.ContainsKey("Coligada"))
                        Parametros.Add("Coligada", value.Id.ToString());
                    else
                        Parametros["Coligada"] = value.Id.ToString();

                }
                _coligada = value;
            }
        }
        /// <summary>
        /// Filial selecionada para o contexto
        /// </summary>
        public FilialViewModel Filial
        {
            get
            {
                if (Usuario.UsuarioFilialSet.Where(w => _coligada != null && _filial != null && w.ColigadaId == _coligada.Id && w.FilialId == _filial.Id).Count() > 0)
                    return _filial;
                return null;
            }
            set
            {
                if (value != null)
                {
                    if (!FilialSet.Select(s => s.Id).Contains(value.Id))
                        throw new Exception("Usuário sem acesso a filial selecionada");

                    FilialId = value.Id;

                    if (!Parametros.ContainsKey("Filial"))
                        Parametros.Add("Filial", value.Id.ToString());
                    else
                        Parametros["Filial"] = value.Id.ToString();
                }
                else
                {
                    FilialId = null;
                    Parametros.Remove("Filial");
                }

                //if (value != null && !FilialSet.Select(s => s.FilialId).Contains(value.FilialId))
                //    throw new Exception("Usuário sem acesso a filial selecionada");

                //if (value == null)
                //    FilialId = null;
                //else
                //    FilialId = value.FilialId;
                _filial = value;
            }
        }

        /// <summary>
        /// Atalho para chave da aplicação selecionada
        /// </summary>
        public int? AplicacaoId { get; set; }
        /// <summary>
        /// Atalho para o código da coligada selecionada
        /// </summary>
        public short? ColigadaId { get; set; }
        /// <summary>
        /// Atalho para o código da filial selecionada
        /// </summary>
        public short? FilialId { get; set; }

        /// <summary>
        /// Atalho para o código do usuário selecionado
        /// </summary>
        public string CODUSUARIO
        {
            get
            {
                if (Usuario == null)
                    return "undefined";
                return Usuario.Id.ToString();
            }
        }

        public AplicacaoViewModel _aplicacao { get; set; }

        /// <summary>
        /// Aplicacao selecionada para o contexto
        /// </summary>
        public AplicacaoViewModel Aplicacao
        {
            get
            {
                return AplicacaoSet.Where(w => w.Id == AplicacaoId).Select(s =>
                {
                    if (s.ParametroSet != null)
                        foreach (var p in s.ParametroSet)
                            p.Value = Parametros.Where(w => w.Key == p.Codigo).Select(s1 => s1.Value).SingleOrDefault();
                    return s;
                }).SingleOrDefault();
            }
            set
            {
                if (value != null && AplicacaoSet.Select(s => s.Id).Contains(value.Id))
                    this.AplicacaoId = value.Id;
            }
        }
    }

    public enum Ambiente
    {
        Desenvolvimento = 1,
        Homologacao = 2,
        Producao = 3
    }
}
