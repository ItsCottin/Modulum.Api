DECLARE @sql NVARCHAR(MAX) = '';

-- Gera os comandos de DROP TABLE para todas as tabelas no schema [Identity]
SELECT @sql += 'DROP TABLE [HangFire].[' + TABLE_NAME + '];' + CHAR(13)
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_SCHEMA = 'HangFire'
  AND TABLE_TYPE = 'BASE TABLE';

-- Verifica se algum comando foi gerado e executa
IF @sql <> ''
BEGIN
    PRINT @sql;  -- Para visualizar o script gerado antes de executar
    --EXEC sp_executesql @sql;
END
ELSE
BEGIN
    PRINT 'Nenhuma tabela encontrada no schema [Identity].';
END


-- DROP TABLE [HangFire].[Schema];
-- 
-- DROP TABLE [HangFire].[State];
-- DROP TABLE [HangFire].[JobParameter];
-- DROP TABLE [HangFire].[JobQueue];
-- DROP TABLE [HangFire].[Job];
-- DROP TABLE [HangFire].[Server];
-- DROP TABLE [HangFire].[List];
-- DROP TABLE [HangFire].[Set];
-- DROP TABLE [HangFire].[Counter];
-- DROP TABLE [HangFire].[Hash];
-- DROP TABLE [HangFire].[AggregatedCounter];
-- DROP TABLE [dbo].[__EFMigrationsHistory];
-- DROP TABLE [dbo].[tbl_field];
-- DROP TABLE [dbo].[tbl_table];
-- DROP TABLE [dbo].[tbl_two_factor];
-- DROP TABLE [dbo].[tbl_role_claim];
-- DROP TABLE [dbo].[tbl_user_role];
-- DROP TABLE [dbo].[tbl_role];
-- DROP TABLE [dbo].[tbl_user_login];
-- DROP TABLE [dbo].[tbl_user_token];
-- DROP TABLE [dbo].[tbl_user_claim];
-- DROP TABLE [dbo].[tbl_user];

-- DECLARE @ID VARCHAR(100) = '9111805e-c943-43b2-97b5-8f6917b125aa'
-- DELETE FROM tbl_user WHERE Id = @ID
-- DELETE FROM tbl_user_role WHERE UserId = @ID

--DELETE FROM tbl_user
--UPDATE tbl_user SET IsCadastroFinalizado = 1

-- DELETE FROM tbl_role

--UPDATE tbl_two_factor SET IsUsed = 0
--WHERE IdUser = '5'

--UPDATE tbl_user SET NomeCompleto = 'Administrador Teste'
--WHERE Id = '6'

-- DELETE FROM tbl_table
-- DELETE FROM tbl_field
-- DROP TABLE Teste
-- DROP TABLE Aluno

-- TRUNCATE TABLE tbl_versao
-- DELETE FROM tbl_user WHERE Id = 6
-- DELETE FROM tbl_two_factor WHERE IdUser = 6
-- DELETE FROM tbl_user_role WHERE UserId = 6

SELECT Email, Code,* FROM tbl_user u INNER JOIN tbl_two_factor ON u.Id = IdUser WHERE u.Id = '5'
SELECT * FROM tbl_two_factor
SELECT * FROM tbl_user
SELECT * FROM tbl_role
SELECT * FROM tbl_user_role
SELECT * FROM tbl_user_claim
SELECT * FROM tbl_user_token
SELECT * FROM tbl_table
SELECT * FROM tbl_field
SELECT * FROM tbl_versao
SELECT * FROM Teste

INSERT INTO Aluno (RA,Nome_do_Aluno,CPF_do_Aluno,Data_de_Nascimento_do_Aluno) VALUES ('00348046','Rodrigo Cotting Fontes',46549857864,'30/04/1995');
-- SP_HELP Aluno

INSERT INTO Aluno (RA,Nome_do_Aluno,CPF_do_Aluno,Data_de_Nascimento_do_Aluno) VALUES ('00348046','Rodrigo Cotting Fontes',46549857864,'30/04/1995');

SELECT * FROM __EFMigrationsHistory

SELECT * FROM [dbo].[tbl_role];

SELECT
    fk.name AS ForeignKeyName,
    tp.name AS TableName,
    cp.name AS ColumnName,
    ref.name AS ReferencedTableName,
    refc.name AS ReferencedColumnName
FROM
    sys.foreign_keys AS fk
INNER JOIN sys.tables AS tp ON fk.parent_object_id = tp.object_id
INNER JOIN sys.columns AS cp ON fk.parent_object_id = cp.object_id AND fk.key_index_id = cp.column_id
INNER JOIN sys.tables AS ref ON fk.referenced_object_id = ref.object_id
INNER JOIN sys.columns AS refc ON fk.referenced_object_id = refc.object_id AND fk.key_index_id = refc.column_id
WHERE
    tp.name = 'tbl_user_role';




