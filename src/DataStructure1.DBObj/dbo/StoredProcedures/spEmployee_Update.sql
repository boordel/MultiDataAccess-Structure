CREATE PROCEDURE [dbo].[spEmployee_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@WorkUnit nvarchar(50),
	@StartDate varchar(20),
	@Salary int,
	@Mode varchar(10)
AS
BEGIN
	IF @Mode = 'insert'
		INSERT INTO dbo.Employees (FirstName, LastName, WorkUnit, StartDate, Salary)
		VALUES (@FirstName, @LastName, @WorkUnit, @StartDate, @Salary)
	ELSE
		UPDATE dbo.Employees
		SET FirstName = @FirstName, LastName = @LastName, WorkUnit = @WorkUnit,
			StartDate = @StartDate, Salary = @Salary
		WHERE Id = @Id
END