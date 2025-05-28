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
-- DROP TABLE [dbo].tbl_versao

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
drop table _Aluno_1
drop table _Cursos_1
drop table _Professores_1
drop table _Disciplina_1
drop table _Processos_Juridicos_11
drop table _Informacoes_de_Clientes_11

-- DROP TABLE _1121_3
-- DROP TABLE Funcionario
-- DROP TABLE Professor
-- DELETE FROM tbl_role
-- DELETE FROM tbl_user

-- DELETE FROM tbl_table
-- DELETE FROM tbl_field
-- DELETE FROM tbl_relationship

-- TRUNCATE TABLE tbl_versao
-- DELETE FROM tbl_user WHERE Id = 8
-- DELETE FROM tbl_two_factor WHERE IdUser = 6
-- DELETE FROM tbl_user_role WHERE UserId = 6

SELECT Email, Code,* FROM tbl_user u INNER JOIN tbl_two_factor ON u.Id = IdUser WHERE u.Id = '5'
SELECT * FROM tbl_two_factor
SELECT * FROM tbl_user
SELECT * FROM tbl_role
SELECT * FROM tbl_user_role
SELECT * FROM tbl_user_claim
SELECT * FROM tbl_user_token

SELECT * FROM tbl_field WHERE TableId = 23
SELECT * FROM tbl_versao



SELECT Id, _Nome_do_Professor FROM _System_of_a_Down_1;

SELECT * FROM _System_of_a_Down_1
SELECT * FROM _Professores_1
SELECT * FROM tbl_table t inner join tbl_field on t.id = TableId
SELECT * FROM tbl_field
SELECT * FROM tbl_relationship r inner join tbl_table t on r.TabelaOrigemId = t.Id
SELECT * FROM _Curso_1
SELECT * FROM _Aluno_1
SELECT * FROM _Disciplina_1;
SELECT * FROM _Campus_1

-- DELETE FROM tbl_field WHERE Id = 70
-- DELETE FROM tbl_relationship WHERE Id = 14

--ALTER TABLE _Aluno_1 DROP COLUMN Id__Campus_1
--ALTER TABLE _Aluno_1 DROP CONSTRAINT FK__Aluno_1_Id__Campus_1_REF__Campus_1_Id

SELECT COUNT(1) FROM _Aluno_1 WHERE Id__Curso_1 = 1;

-- UPDATE tbl_relationship
-- SET CampoParaExibicaoRelacionamento = '_Nome'
-- WHERE Id = 5

--DELETE FROM _Curso_1 WHERE Id = 1;

SELECT COLUMNPROPERTY(OBJECT_ID('Cadastro_de_Aluno_3'), 'Id', 'IsIdentity') AS IsIdentity
SELECT COLUMNPROPERTY(OBJECT_ID('CadastroParaChurrasco_1'), 'Id', 'IsIdentity') AS IsIdentity

CREATE TABLE _1121_3 (Id INT PRIMARY KEY IDENTITY(1,1), _111 VARCHAR(2));

--CREATE TABLE Aluno_1_Nova (
--    Id INT IDENTITY(1,1) PRIMARY KEY,
--    Nome_do_Aluno VARCHAR(255),
--	CPF INT,
--	Data_de_Nascimento DATE,
--	Matriculado BIT
--);
--
---- Copia os dados da tabela antiga para a nova
--INSERT INTO Aluno_1_Nova (Nome_do_Aluno, CPF, Data_de_Nascimento, Matriculado)
--SELECT Nome_do_Aluno, CPF, Data_de_Nascimento, Matriculado FROM Aluno_1;

-- (Opcional) Exclui a tabela antiga
--DROP TABLE Aluno_1;

-- Renomeia a nova tabela para o nome original
--EXEC sp_rename 'Aluno_1_Nova', 'Aluno_1';

--INSERT INTO Aluno (RA,Nome_do_Aluno,CPF_do_Aluno,Data_de_Nascimento_do_Aluno) VALUES ('00348046','Rodrigo Cotting Fontes',46549857864,'30/04/1995');
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



DROP TABLE Aluno_7
DROP TABLE Aluno_42
DROP TABLE So_texto_42
DROP TABLE Aluno_1
DROP TABLE Aluno_45
DROP TABLE Teste_45
DROP TABLE CadastroParaChurrasco_1
DROP TABLE fgdgfd_1
DROP TABLE testecadastro_1
DROP TABLE Opa_1
DROP TABLE System_54

