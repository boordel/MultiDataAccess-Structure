CREATE PROCEDURE [dbo].[spEmployee_Delete]
	@Id int
AS
BEGIN
	DELETE dbo.Employees
	WHERE [Id] = @Id
END