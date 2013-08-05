USE Bank
GO

-- Task 1
-- Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
-- Insert few records for testing. Write a stored procedure that selects the full names of all persons.
CREATE PROC usp_GetFullNamesOfAllPersons
AS
	SELECT FirstName + ' ' + LastName as [FullName]
	FROM Persons
GO

EXEC usp_GetFullNamesOfAllPersons
GO

-- Task 2
-- Create a stored procedure that accepts a number as a parameter and
-- returns all persons who have more money in their accounts than the supplied number.
CREATE PROC usp_GetPersonsWithHigherBalance (@balance money)
AS
	SELECT *
	FROM Persons p JOIN Accounts a
		ON p.PersonID = a.PersonID
	WHERE a.Balance >= @balance
GO

EXEC usp_GetPersonsWithHigherBalance 2000
GO

-- Task 3
-- Create a function that accepts as parameters – sum, yearly interest rate and number of months.
-- It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
CREATE FUNCTION ufn_AddInterestToBalance(@balance money, @yearlyInterest money, @months int)
	RETURNS money
AS
BEGIN
	DECLARE @currentInterest money
	SET @currentInterest = @yearlyInterest * @months / 12
	DECLARE @result money
	SET @result = @balance + @balance * @currentInterest
	RETURN @result
END
GO

PRINT dbo.ufn_AddInterestToBalance(2000, 0.15, 3)
GO

-- Task 4
-- Create a stored procedure that uses the function from the previous example to give an
-- interest to a person's account for one month. It should take the AccountId and the interest rate as parameters.
CREATE PROC usp_AddInterestToAccountForOneMonth(@accountID int, @interestRate money)
AS
	UPDATE Accounts
	SET Balance = dbo.ufn_AddInterestToBalance(Balance, @interestRate, 1)
	WHERE AccountID = @accountID
GO

EXEC usp_AddInterestToAccountForOneMonth 1, 0.15
GO

-- Task 5
-- Add two more stored procedures WithdrawMoney( AccountId, money) and
-- DepositMoney (AccountId, money) that operate in transactions.
CREATE PROC usp_WithdrawMoney(@accountID int, @amountOfMoney money)
AS
	BEGIN TRAN
		DECLARE @currentBalance money
		SET @currentBalance = (
			SELECT a.Balance
			FROM Accounts a
			WHERE a.AccountID = @accountID)
	
		IF @currentBalance <= @amountOfMoney
			SET @currentBalance = 0
		ELSE
			SET @currentBalance = @currentBalance - @amountOfMoney

		UPDATE Accounts
		SET Balance = @currentBalance
		WHERE AccountID = @accountID
	COMMIT TRAN
GO

EXEC usp_WithdrawMoney 1, 1000
GO

CREATE PROC usp_DepositeMoney(@accountID int, @amountOfMoney money)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance + @amountOfMoney
		WHERE AccountID = @accountID
	COMMIT TRAN
GO

EXEC usp_DepositeMoney 1, 1000
GO

-- Task 6
-- Create another table – Logs(LogID, AccountID, OldSum, NewSum).
-- Add a trigger to the Accounts table that enters a new entry into
-- the Logs table every time the sum on an account changes.
CREATE TRIGGER tr_LogChangeOnAccount ON Accounts FOR UPDATE
AS
	DECLARE @accountID int
	SET @accountID = (SELECT AccountID FROM deleted)

	DECLARE @oldBalance money
	SET @oldBalance = (SELECT Balance FROM deleted)

	DECLARE @newBalance money
	SET @newBalance = (SELECT Balance FROM inserted)

	INSERT INTO Logs(OldBalance, NewBalance, AccountID)
	VALUES (@oldBalance, @newBalance, @accountID)
GO

USE TelerikAcademy
GO

-- Task 7
-- Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name)
-- and all town's names that are comprised of given set of letters.
-- Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
CREATE FUNCTION ufn_GetEmployees()
	RETURNS table
AS
	RETURN (
		SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [FullName] FROM Employees
	)
GO

SELECT * FROM dbo.ufn_GetEmployees()
GO

-- Task 8
-- Using database cursor write a T-SQL script that scans all employees and their
-- addresses and prints all pairs of employees that live in the same town.
CREATE TABLE #tempTable (
	FirstName1 nvarchar(50),
	LastName1 nvarchar(50),
	FirstName2 nvarchar(50),
	LastName2 nvarchar(50),
	TownName nvarchar(50)
)

DECLARE empCursor1 CURSOR READ_ONLY FOR
SELECT e.FirstName, e.LastName, t.Name
FROM Employees e
	JOIN Addresses a
		ON e.AddressID = a.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID

OPEN empCursor1
	DECLARE @firstName1 nvarchar(50), @lastName1 nvarchar(50), @townName1 nvarchar(50)
	FETCH NEXT FROM empCursor1 INTO @firstName1, @lastName1, @townName1

	WHILE @@FETCH_STATUS = 0
	BEGIN
		DECLARE empCursor2 CURSOR READ_ONLY FOR
		SELECT e.FirstName, e.LastName, t.Name
		FROM Employees e
			JOIN Addresses a
				ON e.AddressID = a.AddressID
			JOIN Towns t
				ON a.TownID = t.TownID
		
		OPEN empCursor2
			DECLARE @firstName2 nvarchar(50), @lastName2 nvarchar(50), @townName2 nvarchar(50)
			FETCH NEXT FROM empCursor2 INTO @firstName2, @lastName2, @townName2

			IF (@townName1 = @townName2)
			BEGIN
				INSERT INTO #tempTable (FirstName1, LastName1, FirstName2, LastName2, TownName)
				VALUES (@firstName1, @lastName1, @firstName2, @lastName2, @townName1)
			END

			WHILE @@FETCH_STATUS = 0
			BEGIN
				FETCH NEXT FROM empCursor2 INTO @firstName2, @lastName2, @townName2
				IF (@townName1 = @townName2)
				BEGIN
					INSERT INTO #tempTable (FirstName1, LastName1, FirstName2, LastName2, TownName)
					VALUES (@firstName1, @lastName1, @firstName2, @lastName2, @townName1)
				END
			END
		CLOSE empCursor2
		DEALLOCATE empCursor2

		FETCH NEXT FROM empCursor1 INTO @firstName1, @lastName1, @townName1
	END
CLOSE empCursor1
DEALLOCATE empCursor1

SELECT * FROM #tempTable

DROP TABLE #tempTable
