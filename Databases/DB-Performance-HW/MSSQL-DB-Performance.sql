USE master
GO

CREATE DATABASE DataPerformance

USE DataPerformance
GO

CREATE TABLE Logs (
	LogID int IDENTITY,
	LogDate DateTime,
	LogText ntext,
	CONSTRAINT PK_Logs PRIMARY KEY (LogID),
)
GO

-- Task 1
-- Create a table in SQL Server with 10 000 000 log entries (date + text).
-- Search in the table by date range. Check the speed (without caching).

INSERT INTO Logs(LogDate, LogText) VALUES ('1990-01-01', 'Sample log');

--Insert records in the format Date | SampleLog1, Date | SampleLog2...
DECLARE @counter int = 0
WHILE (SELECT COUNT(*) FROM Logs) < 1000000
BEGIN
  INSERT INTO Logs(LogDate, LogText)
  SELECT DATEADD(MONTH, @counter + 3, LogDate), LogText + CONVERT(varchar, @counter) FROM Logs
  SET @counter = @counter + 1
END

--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;

--Test search by date before adding index
SELECT LogText FROM Logs WHERE LogDate
BETWEEN CONVERT(datetime, '1990-01-01') AND CONVERT(datetime, '1995-01-01'); --you must look at the records and change the date to another value, because you cannot go back in time yet :)


-- Task 2
-- Add an index to speed-up the search by date. Test the search speed (after cleaning the cache).

-- Add a index to the date column
CREATE INDEX IX_Logs_LogDate ON Logs(LogDate);

--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;

--Test search by date after adding index
SELECT LogText FROM Logs WHERE LogDate
BETWEEN CONVERT(datetime, '2013-07-19 11:59:21') AND CONVERT(datetime, '2013-07-19 11:59:25'); --you must look at the records and change the date to another value, because you cannot go back in time yet :)



-- Task 3
-- Add a full text index for the text column. Try to search with and without the full-text index and compare the speed.

CREATE FULLTEXT CATALOG LogsFullTextForLogText
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Logs(LogText)
KEY INDEX PK_Logs
ON LogsFullTextForLogText
WITH CHANGE_TRACKING AUTO

--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;
--Search from full text
SELECT * FROM Logs
WHERE LogText LIKE '% 1256789'

--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;
--Search from full text
SELECT * FROM Logs
WHERE CONTAINS(LogText,'1256789')