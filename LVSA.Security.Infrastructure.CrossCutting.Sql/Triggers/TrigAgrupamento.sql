CREATE TRIGGER [Security].[TrigAgrupamento]
	ON [Security].[Agrupamento]
	FOR DELETE, INSERT, UPDATE
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

		IF @Action = 'U' OR @Action = 'I'
		BEGIN
			INSERT INTO [Security].[AudAgrupamento]
			(
				[Ocorrencia],
				[Horario],
				[UsuarioId],
				[GrupoId],
				[RECCREATEDON],
				[RECCREATEDBY],
				[RECMODIFIEDON],
				[RECMODIFIEDBY]
			)	SELECT 
					CASE @Action WHEN 'U' THEN 'Update' ELSE 'Insert' END,
					GETDATE(),
					UsuarioId,
					GrupoId,
					RECCREATEDON,
					RECCREATEDBY,
					RECMODIFIEDON,
					RECMODIFIEDBY
				FROM
					inserted
		END

		IF @Action = 'D'
		BEGIN
			INSERT INTO [Security].[AudAgrupamento]
			(
				[Ocorrencia],
				[Horario],
				[UsuarioId],
				[GrupoId],
				[RECCREATEDON],
				[RECCREATEDBY],
				[RECMODIFIEDON],
				[RECMODIFIEDBY]
			)	SELECT 
					'Delete',
					GETDATE(),
					UsuarioId,
					GrupoId,
					RECCREATEDON,
					RECCREATEDBY,
					RECMODIFIEDON,
					RECMODIFIEDBY
				FROM
					deleted
		END



	END
