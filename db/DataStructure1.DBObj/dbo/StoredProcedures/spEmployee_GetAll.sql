CREATE PROCEDURE [dbo].[spEmployee_GetAll]
AS
BEGIN
	SELECT [Id], [FirstName], [LastName], [WorkUnit], [StartDate], [Salary] 
	FROM dbo.Employees
END