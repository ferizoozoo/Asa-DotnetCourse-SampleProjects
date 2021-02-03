CREATE PROCEDURE [dbo].[join_persons_with_units]
@name nvarchar(50),
@last_name nvarchar(50)
as


select SCOPE_IDENTITY()
