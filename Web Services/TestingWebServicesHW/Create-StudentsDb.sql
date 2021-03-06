USE [master]
GO

CREATE DATABASE [StudentsDb]
GO

USE [StudentsDb]
GO

ALTER DATABASE [StudentsDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentsDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentsDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentsDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentsDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentsDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentsDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentsDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentsDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [StudentsDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentsDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentsDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentsDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentsDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentsDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentsDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentsDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentsDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentsDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentsDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentsDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentsDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentsDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentsDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentsDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentsDb] SET RECOVERY FULL 
GO
ALTER DATABASE [StudentsDb] SET  MULTI_USER 
GO
ALTER DATABASE [StudentsDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentsDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentsDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentsDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'StudentsDb', N'ON'
GO
USE [StudentsDb]
GO
/****** Object:  User [deniskaska]    Script Date: 13.8.2013 г. 20:59:55 ч. ******/
CREATE USER [deniskaska] FOR LOGIN [deniskaska] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [deniskaska]
GO
/****** Object:  Table [dbo].[Marks]    Script Date: 13.8.2013 г. 20:59:55 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marks](
	[MarkId] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](100) NOT NULL,
	[Value] [float] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_Marks] PRIMARY KEY CLUSTERED 
(
	[MarkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Schools]    Script Date: 13.8.2013 г. 20:59:55 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schools](
	[SchoolId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Location] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Schools] PRIMARY KEY CLUSTERED 
(
	[SchoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 13.8.2013 г. 20:59:55 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Grade] [float] NULL,
	[SchoolId] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Marks] ON 

GO
INSERT [dbo].[Marks] ([MarkId], [Subject], [Value], [StudentId]) VALUES (1, N'Math', 3, 1)
GO
INSERT [dbo].[Marks] ([MarkId], [Subject], [Value], [StudentId]) VALUES (2, N'Biology', 4, 2)
GO
INSERT [dbo].[Marks] ([MarkId], [Subject], [Value], [StudentId]) VALUES (3, N'History', 6, 3)
GO
INSERT [dbo].[Marks] ([MarkId], [Subject], [Value], [StudentId]) VALUES (4, N'Physics', 5, 4)
GO
SET IDENTITY_INSERT [dbo].[Marks] OFF
GO
SET IDENTITY_INSERT [dbo].[Schools] ON 

GO
INSERT [dbo].[Schools] ([SchoolId], [Name], [Location]) VALUES (1, N'School1', N'Location1')
GO
INSERT [dbo].[Schools] ([SchoolId], [Name], [Location]) VALUES (2, N'School2', N'Location2')
GO
SET IDENTITY_INSERT [dbo].[Schools] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

GO
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Grade], [SchoolId]) VALUES (1, N'Pesho', N'Peshov', 5, 1)
GO
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Grade], [SchoolId]) VALUES (2, N'Gosho', N'Goshov', 3, 1)
GO
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Grade], [SchoolId]) VALUES (3, N'Niki', N'Nikolov', 6, 2)
GO
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Grade], [SchoolId]) VALUES (4, N'Valq', N'Valentinova', 4, 2)
GO
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_Marks_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_Students]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Schools] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[Schools] ([SchoolId])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Schools]
GO
USE [master]
GO
ALTER DATABASE [StudentsDb] SET  READ_WRITE 
GO
