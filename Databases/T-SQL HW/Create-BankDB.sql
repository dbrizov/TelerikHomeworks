USE [master]
GO
/****** Object:  Database [Bank]    Script Date: 13.7.2013 г. 16:19:26 ч. ******/
CREATE DATABASE [Bank]
GO

USE [Bank]
GO

ALTER DATABASE [Bank] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bank] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bank] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bank] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bank] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bank] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bank] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bank] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Bank] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bank] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bank] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bank] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bank] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bank] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bank] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bank] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bank] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bank] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bank] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bank] SET RECOVERY FULL 
GO
ALTER DATABASE [Bank] SET  MULTI_USER 
GO
ALTER DATABASE [Bank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bank] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Bank', N'ON'
GO
USE [Bank]
GO
/****** Object:  StoredProcedure [dbo].[usp_AddInterestToAccountForOneMonth]    Script Date: 13.7.2013 г. 16:19:26 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_AddInterestToAccountForOneMonth](@accountID int, @interestRate money)
AS
	UPDATE Accounts
	SET Balance = dbo.ufn_AddInterestToBalance(Balance, @interestRate, 1)
	WHERE AccountID = @accountID

GO
/****** Object:  StoredProcedure [dbo].[usp_DepositeMoney]    Script Date: 13.7.2013 г. 16:19:26 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_DepositeMoney](@accountID int, @amountOfMoney money)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance + @amountOfMoney
		WHERE AccountID = @accountID
	COMMIT TRAN

GO
/****** Object:  StoredProcedure [dbo].[usp_GetFullNamesOfAllPersons]    Script Date: 13.7.2013 г. 16:19:26 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_GetFullNamesOfAllPersons]
AS
	SELECT FirstName + ' ' + LastName as [FullName]
	FROM Persons

GO
/****** Object:  StoredProcedure [dbo].[usp_GetPersonsWithHigherBalance]    Script Date: 13.7.2013 г. 16:19:26 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_GetPersonsWithHigherBalance] (@balance money)
AS
	SELECT *
	FROM Persons p JOIN Accounts a
		ON p.PersonID = a.PersonID
	WHERE a.Balance >= @balance

GO
/****** Object:  StoredProcedure [dbo].[usp_WithdrawMoney]    Script Date: 13.7.2013 г. 16:19:26 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_WithdrawMoney](@accountID int, @amountOfMoney money)
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
/****** Object:  UserDefinedFunction [dbo].[ufn_AddInterestToBalance]    Script Date: 13.7.2013 г. 16:19:26 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufn_AddInterestToBalance](@balance money, @yearlyInterest money, @months int)
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
/****** Object:  Table [dbo].[Accounts]    Script Date: 13.7.2013 г. 16:19:26 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[Balance] [money] NOT NULL,
	[PersonID] [int] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 13.7.2013 г. 16:19:27 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[OldBalance] [money] NOT NULL,
	[NewBalance] [money] NOT NULL,
	[AccountID] [int] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 13.7.2013 г. 16:19:27 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[SSN] [nvarchar](11) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

GO
INSERT [dbo].[Accounts] ([AccountID], [Balance], [PersonID]) VALUES (1, 2063.1270, 1)
GO
INSERT [dbo].[Accounts] ([AccountID], [Balance], [PersonID]) VALUES (6, 2000.0000, 2)
GO
INSERT [dbo].[Accounts] ([AccountID], [Balance], [PersonID]) VALUES (7, 3000.0000, 3)
GO
INSERT [dbo].[Accounts] ([AccountID], [Balance], [PersonID]) VALUES (8, 4050.0000, 4)
GO
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Logs] ON 

GO
INSERT [dbo].[Logs] ([LogID], [OldBalance], [NewBalance], [AccountID]) VALUES (1, 4012.5000, 5012.5000, 1)
GO
INSERT [dbo].[Logs] ([LogID], [OldBalance], [NewBalance], [AccountID]) VALUES (2, 5012.5000, 4012.5000, 1)
GO
INSERT [dbo].[Logs] ([LogID], [OldBalance], [NewBalance], [AccountID]) VALUES (3, 4012.5000, 3012.5000, 1)
GO
INSERT [dbo].[Logs] ([LogID], [OldBalance], [NewBalance], [AccountID]) VALUES (4, 3012.5000, 2012.5000, 1)
GO
INSERT [dbo].[Logs] ([LogID], [OldBalance], [NewBalance], [AccountID]) VALUES (5, 2012.5000, 1012.5000, 1)
GO
INSERT [dbo].[Logs] ([LogID], [OldBalance], [NewBalance], [AccountID]) VALUES (6, 1012.5000, 2012.5000, 1)
GO
INSERT [dbo].[Logs] ([LogID], [OldBalance], [NewBalance], [AccountID]) VALUES (7, 2012.5000, 2037.6563, 1)
GO
INSERT [dbo].[Logs] ([LogID], [OldBalance], [NewBalance], [AccountID]) VALUES (8, 2037.6563, 2063.1270, 1)
GO
INSERT [dbo].[Logs] ([LogID], [OldBalance], [NewBalance], [AccountID]) VALUES (9, 4000.0000, 4050.0000, 8)
GO
SET IDENTITY_INSERT [dbo].[Logs] OFF
GO
SET IDENTITY_INSERT [dbo].[Persons] ON 

GO
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (1, N'Pesho', N'Peshov', N'123-45-6789')
GO
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (2, N'Gosho', N'Goshov', N'123-45-6780')
GO
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (3, N'Elvis', N'Stoyanov', N'123-45-6781')
GO
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (4, N'Mimi', N'Doneva', N'123-45-6782')
GO
SET IDENTITY_INSERT [dbo].[Persons] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UK_Persons_SSN]    Script Date: 13.7.2013 г. 16:19:27 ч. ******/
ALTER TABLE [dbo].[Persons] ADD  CONSTRAINT [UK_Persons_SSN] UNIQUE NONCLUSTERED 
(
	[SSN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Persons] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Persons]
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_Accounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_Accounts]
GO
USE [master]
GO
ALTER DATABASE [Bank] SET  READ_WRITE 
GO
