CREATE PROCEDURE [dbo].[spEmployee_Get]
	@Id int
AS
BEGIN
	SELECT [Id], [FirstName], [LastName], [WorkUnit], [StartDate], [Salary] 
	FROM dbo.Employees
	WHERE [Id] = @Id
END
