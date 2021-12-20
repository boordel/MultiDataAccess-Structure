IF NOT EXISTS (SELECT 1 FROM dbo.Employees)
BEGIN
	INSERT INTO dbo.Employees (FirstName, LastName, WorkUnit, StartDate, Salary)
	VALUES ('Mahmood', 'Sabzehi', 'Management', '2021/12/13', 85000)
END