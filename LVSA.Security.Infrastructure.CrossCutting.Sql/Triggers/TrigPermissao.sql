CREATE TRIGGER [Security].[TrigPermissao]
	ON [Security].[Permissao]
	AFTER DELETE, INSERT, UPDATE
	AS
	BEGIN
		SET NOCOUNT ON;

		DECLARE @Action as char(1);
		SET @Action = (
						CASE WHEN EXISTS(SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
								THEN 'U'  
							WHEN EXISTS(SELECT * FROM inserted)
								THEN 'I'  
							WHEN EXISTS(SELECT * FROM deleted)
								THEN 'D' 
							ELSE NULL    
						END
					  );

		IF @Action = 'U'
		BEGIN
			INSERT INTO [Security].[AudPermissao]
			(
				[Ocorrencia],
				[Horario],
				[PermissaoId],
				[RecursoId],
				[RelatorioId],
				[GrupoId],
				[UsuarioId],
				[Visualizar],
				[Inserir],
				[Alterar],
				[Excluir],
				[RECCREATEDON],
				[RECCREATEDBY],
				[RECMODIFIEDON],
				[RECMODIFIEDBY],
				[RECDELETEDON],
				[RECDELETEDBY]
			)	SELECT 
					CASE @Action WHEN 'U' THEN 'Update' ELSE 'Insert' END,
					GETDATE(),
					Id,
					RecursoId,
					RelatorioId,
					GrupoId,
					UsuarioId,
					Visualizar,
					Inserir,
					Alterar,
					Excluir,
					RECCREATEDON,
					RECCREATEDBY,
					RECMODIFIEDON,
					RECMODIFIEDBY,
					RECDELETEDON,
					RECDELETEDBY
				FROM
					inserted
		END
		
		IF @Action = 'D'
		BEGIN
			INSERT INTO [Security].[AudPermissao]
			(
				[Ocorrencia],
				[Horario],
				[PermissaoId],
				[RecursoId],
				[RelatorioId],
				[GrupoId],
				[UsuarioId],
				[Visualizar],
				[Inserir],
				[Alterar],
				[Excluir],
				[RECCREATEDON],
				[RECCREATEDBY],
				[RECMODIFIEDON],
				[RECMODIFIEDBY],
				[RECDELETEDON],
				[RECDELETEDBY]
			)	SELECT 
					'Delete',
					GETDATE(),
					Id,
					RecursoId,
					RelatorioId,
					GrupoId,
					UsuarioId,
					Visualizar,
					Inserir,
					Alterar,
					Excluir,
					RECCREATEDON,
					RECCREATEDBY,
					RECMODIFIEDON,
					RECMODIFIEDBY,
					RECDELETEDON,
					RECDELETEDBY
				FROM
					deleted
		END
		
	END
