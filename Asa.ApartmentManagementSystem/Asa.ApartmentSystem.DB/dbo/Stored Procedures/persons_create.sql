CREATE PROCEDURE [dbo].[persons_create]
@name nvarchar(50),
@last_name nvarchar(50)
as

INSERT INTO [dbo].[Person]
           ([name]
           ,[last_name])
     VALUES
           (@name
           ,@last_name)
select SCOPE_IDENTITY()
