using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Application.Exceptions;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Domain;
using LVSA.Security.Domain.Interfaces.Services;

namespace LVSA.Security.Application
{
    public class RecursoAppService : AppServiceBase<RecursoViewModel, Recurso, IRecursoService>, IRecursoAppService
    {
        public RecursoAppService(IRecursoService recursoService)
            : base(recursoService)
        {

        }

        public override IEnumerable<RecursoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public override void Remover(RecursoViewModel model)
        {
            var entity = Service.Find(f => f.Id == model.Id && f.RECDELETEDON == null).SingleOrDefault();
            if (entity == null)
                throw new NoRecordsFoundException("Recurso não encontrado");

            entity.RECDELETEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null;

            Service.Delete(entity);
        }

        private string _export(RecursoViewModel model)
        {
            return string.Format(@"

SET @AplicacaoId = (SELECT TOP 1 Id FROM [Security].[Aplicacao] WHERE Nome = '{0}');
SET @TipoRecursoId = (SELECT TOP 1 Id FROM [Security].[TipoRecurso] WHERE Codigo = '{1}');

SET @Controller = (CASE '{4}' WHEN '' THEN -1 ELSE 1 END);
SET @Action = (CASE '{5}' WHEN '' THEN -1 ELSE 1 END);

SET @RecursoPaiId = ISNULL((	
	SELECT TOP 1
		Id 
	FROM 
		[Security].[Recurso] 
	WHERE 
		[AplicacaoId] = @AplicacaoId AND
		[Nome] = '{2}' AND
		[Exibicao] = '{3}' AND
		([Controller] = '{4}' OR (@Controller = -1 AND [Controller] IS NULL)) AND 
		([Action] = '{5}' OR (@Action = -1 AND [Action] IS NULL)) 
), -1);

SET @Controller = (CASE '{8}' WHEN '' THEN -1 ELSE 1 END);
SET @Action = (CASE '{9}' WHEN '' THEN -1 ELSE 1 END);

BEGIN
    IF NOT EXISTS (	SELECT 1
					FROM 
						[Security].[Recurso] 
					WHERE 
						[AplicacaoId] = @AplicacaoId AND 
						[TipoRecursoId] = @TipoRecursoId  AND 
						[Nome] = '{6}' AND 
						[Exibicao] = '{7}' AND 
						([Controller] = '{8}' OR (@Controller = -1 AND [Controller] IS NULL)) AND 
						([Action] = '{9}' OR (@Action = -1 AND [Action] IS NULL)) AND 
						((@RecursoPaiId = -1 AND [RecursoPaiId] IS NULL ) OR [RecursoPaiId] = @RecursoPaiId)
				    )
BEGIN
	INSERT INTO 
		[Security].[Recurso]  ([AplicacaoId], [TipoRecursoId], [Nome], [Exibicao], [Controller],[Action], [Icone], [Descricao], [Tags], [RecursoPaiId], [Ativo])
		VALUES (@AplicacaoId, @TipoRecursoId, '{6}','{7}','{8}','{9}','{10}','{11}','{12}',CASE @RecursoPaiId WHEN -1 THEN NULL ELSE @RecursoPaiId END,'{13}')
	END
END",
                                             model.Aplicacao != null ? model.Aplicacao.Nome : null,
                                             model.TipoRecurso != null ? model.TipoRecurso.Codigo : null,
                                             model.RecursoPai != null ? model.RecursoPai.Nome : null,
                                             model.RecursoPai != null ? model.RecursoPai.Exibicao : null,
                                             model.RecursoPai != null ? model.RecursoPai.Controller : null,
                                             model.RecursoPai != null ? model.RecursoPai.Action : null,
                                             model.Nome,
                                             model.Exibicao,
                                             model.Controller,
                                             model.Action,
                                             model.Icon,
                                             model.Descricao,
                                             model.Tags,
                                             model.Ativo ? "1" : "0"
                                        );
        }

        public string Export(IEnumerable<RecursoViewModel> model)
        {
            string tsql = @"
/* Atenção! Script gerado automaticamente.*/

DECLARE @AplicacaoId AS INT;
DECLARE @TipoRecursoId AS SMALLINT;
DECLARE @RecursoPaiId AS BIGINT;
DECLARE @Controller AS SMALLINT;
DECLARE @Action AS SMALLINT;";

            foreach (var x in model.OrderBy(o => o.Id))            
                tsql += _export(x);

            return tsql;
        }
    }
}
