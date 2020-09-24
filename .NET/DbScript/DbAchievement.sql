USE master;
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name = 'AchievementBase')
BEGIN
	DROP DATABASE AchievementBase;
END

CREATE DATABASE AchievementBase
GO

USE AchievementBase
GO

CREATE TABLE dbo.Client
	(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Age INT NOT NULL,
	DataOfBirth DATETIME2 NOT NULL,
	)
GO


CREATE TABLE dbo.Award
	(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title NVARCHAR(50) NOT NULL,	
	[Image] VARBINARY(MAX) NULL
	)
GO

CREATE TABLE dbo.AwardClient
	(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdClient INT NOT NULL,
	IdAchievement INT NOT NULL,
	)
GO

ALTER TABLE AwardClient
	ADD CONSTRAINT FK_AwardClient_Client_Id FOREIGN KEY (IdClient)
		REFERENCES Client(Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE AwardClient
	ADD CONSTRAINT FK_AwardClient_Award_Id FOREIGN KEY (IdAchievement)
		REFERENCES Award(Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO

CREATE TABLE dbo.MyRole
	(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Login] NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Role] NVARCHAR(50) NOT NULL,
	)
GO
--Storage Procedure CLIENT

CREATE PROCEDURE [dbo].[Sp_GetAllClients]
AS
BEGIN
     SELECT Id, [Name], Age, DataOfBirth
	 FROM Client 
END
GO

CREATE PROCEDURE [dbo].[Sp_InsertClient]
	@Id INT OUTPUT,
    @Name NVARCHAR(50),
	@Age INT,
	@DateOfBirth DATETIME2
AS
BEGIN	

	INSERT INTO Client([Name],Age,DataOfBirth)
	VALUES (@Name,@Age,@DateOfBirth)
	SET @Id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE [dbo].[Sp_UpdateClient]
	@Id INT,
	@Name NVARCHAR(50),
	@Age INT,
	@DataOfBirth DATETIME2
AS
BEGIN
	UPDATE Client SET [Name] = @Name,Age = @Age, DataOfBirth = @DataOfBirth
	FROM Client
	WHERE (@Id = Id)
END
GO

CREATE PROCEDURE [dbo].[Sp_DeleteClient]
	@Id INT
AS	
BEGIN
	SELECT	Id, [Name], Age, DataOfBirth
	FROM Client
	WHERE Id = @Id;

	DELETE FROM Client
	WHERE Id = @Id;
END
GO

CREATE PROCEDURE [dbo].[Sp_GetClientById]
	@Id INT
AS	
BEGIN
	SELECT Id, [Name], Age, DataOfBirth
	FROM Client
	WHERE Id = @Id;
END
GO
--Storage Procedure AWARD

CREATE PROCEDURE [dbo].[Sp_GetAllAward]
AS
BEGIN
     SELECT Id,Title,[Image]
	 FROM Award 
END
GO

CREATE PROCEDURE [dbo].[Sp_InsertAward]
	@Id INT OUTPUT,
    @Title NVARCHAR(50),
	@Image VARBINARY(MAX) = NULL
AS
BEGIN	

	INSERT INTO Award(Title,[Image])
	VALUES (@Title,@Image)
	SET @Id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE [dbo].[Sp_UpdateAward]
    @Id INT,
	@Title NVARCHAR(50),
	@Image VARBINARY(MAX) = NULL
AS
BEGIN
	UPDATE Award SET Title = @Title,[Image] = @Image
	FROM Award
	WHERE (@Id = Id)
END
GO

CREATE PROCEDURE [dbo].[Sp_DeleteAward]
	@Id INT
AS	
BEGIN
	SELECT	Id, Title, [Image]
	FROM Award
	WHERE Id = @Id;

	DELETE FROM Award
	WHERE Id = @Id;
END
GO

CREATE PROCEDURE [dbo].[Sp_GetAwardById]
	@Id INT
AS	
BEGIN
	SELECT Id, Title, [Image]
	FROM Award
	WHERE Id = @Id;
END
GO
--Storage Procedure CLEINTAWARD

CREATE PROCEDURE [dbo].[Sp_GetAllClientAward]
AS
BEGIN
     SELECT Id,IdClient,IdAchievement
	 FROM AwardClient 
END
GO

CREATE PROCEDURE [dbo].[Sp_InsertClientAward]
	@Id INT OUTPUT,
    @IdClient INT,
	@IdAward INT
AS
BEGIN	

	INSERT INTO AwardClient(IdAchievement, IdClient)
	VALUES (@IdAward, @IdClient)
	SET @Id = SCOPE_IDENTITY();
END
GO

--CREATE PROCEDURE [dbo].[Sp_UpdateClientAward_Award]
--    @Id INT,
--	@IdAward INT
--AS
--BEGIN
--	UPDATE AwardClient SET IdAchievement = @IdAward
--	FROM AwardClient
--	WHERE (@Id = Id)
--END
--GO

--CREATE PROCEDURE [dbo].[Sp_UpdateClientAward_Client]
--    @Id INT,
--	@IdClient INT
--AS
--BEGIN
--	UPDATE AwardClient SET IdClient = @IdClient
--	FROM AwardClient
--	WHERE (@Id = Id)
--END
--GO

CREATE PROCEDURE [dbo].[Sp_UpdateClientAward]
	@Id INT,
	@IdClient INT,
	@IdAward INT
AS
BEGIN
	UPDATE AwardClient SET IdClient = @IdClient, IdAchievement = @IdAward
	FROM AwardClient
	WHERE (Id = @Id)
END
GO

CREATE PROCEDURE [dbo].[Sp_DeleteClientAward]
	@Id INT
AS	
BEGIN
	SELECT	Id, IdClient, IdAchievement
	FROM AwardClient
	WHERE Id = @Id;

	DELETE FROM AwardClient
	WHERE Id = @Id;
END
GO

CREATE PROCEDURE [dbo].[Sp_GetAwardClientById]
	@Id INT
AS	
BEGIN
	SELECT Id, IdAchievement,IdClient
	FROM AwardClient
	WHERE Id = @Id;
END
GO

CREATE PROCEDURE [dbo].[Sp_GetRole]
	@Login NVARCHAR(50),
	@Role NVARCHAR(50)

AS	
BEGIN
	SELECT [Role]
	FROM MyRole
	WHERE [Login] = @Login;
END
GO

CREATE PROCEDURE [dbo].[Sp_GetAllRole]
AS	
BEGIN
	SELECT [Role]
	FROM MyRole
END
GO
CREATE PROCEDURE [dbo].[Sp_CheckUser]
	@Login NVARCHAR(50),
	@Password NVARCHAR(50)
AS	
BEGIN
	SELECT [Login],[Password]
	FROM MyRole
	WHERE  @Login = [Login] AND @Password = [Password];
END