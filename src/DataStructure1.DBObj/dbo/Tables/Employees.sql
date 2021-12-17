CREATE TABLE [dbo].[Employees]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [WorkUnit] NVARCHAR(50) NOT NULL, 
    [StartDate] VARCHAR(20) NOT NULL, 
    [Salary] INT NOT NULL
)
