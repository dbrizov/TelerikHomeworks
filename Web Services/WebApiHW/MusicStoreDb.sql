USE [master]
GO
/****** Object:  Database [MusicStoreDb]    Script Date: 08/06/2013 14:12:57 ******/
CREATE DATABASE [MusicStoreDb]
GO

USE [MusicStoreDb]
GO

ALTER DATABASE [MusicStoreDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MusicStoreDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MusicStoreDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MusicStoreDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MusicStoreDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MusicStoreDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MusicStoreDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [MusicStoreDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MusicStoreDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MusicStoreDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MusicStoreDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MusicStoreDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MusicStoreDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MusicStoreDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MusicStoreDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MusicStoreDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MusicStoreDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MusicStoreDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MusicStoreDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MusicStoreDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MusicStoreDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MusicStoreDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MusicStoreDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MusicStoreDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MusicStoreDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MusicStoreDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MusicStoreDb] SET  MULTI_USER 
GO
ALTER DATABASE [MusicStoreDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MusicStoreDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MusicStoreDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MusicStoreDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [MusicStoreDb]
GO
/****** Object:  User [student]    Script Date: 08/06/2013 14:12:57 ******/
CREATE USER [student] FOR LOGIN [student] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [student]
GO
/****** Object:  Table [dbo].[Albums]    Script Date: 08/06/2013 14:12:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[AlbumId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Year] [int] NOT NULL,
	[Producer] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Artists]    Script Date: 08/06/2013 14:12:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
	[ArtistsId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[AlbumId] [int] NOT NULL,
 CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED 
(
	[ArtistsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Artists_Albums]    Script Date: 08/06/2013 14:12:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists_Albums](
	[ArtistId] [int] NOT NULL,
	[AlbumId] [int] NOT NULL,
 CONSTRAINT [PK_Artists_Albums] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC,
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Songs]    Script Date: 08/06/2013 14:12:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Songs](
	[SongId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Year] [int] NOT NULL,
	[Genre] [nvarchar](50) NOT NULL,
	[ArtistId] [int] NOT NULL,
	[AlbumId] [int] NOT NULL,
 CONSTRAINT [PK_Songs] PRIMARY KEY CLUSTERED 
(
	[SongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Albums] ON 

GO
INSERT [dbo].[Albums] ([AlbumId], [Title], [Year], [Producer]) VALUES (4, N'Title1', 1900, N'Producer1')
GO
INSERT [dbo].[Albums] ([AlbumId], [Title], [Year], [Producer]) VALUES (5, N'Title2', 1995, N'Producer2')
GO
INSERT [dbo].[Albums] ([AlbumId], [Title], [Year], [Producer]) VALUES (6, N'Title3', 2000, N'Producer3')
GO
SET IDENTITY_INSERT [dbo].[Albums] OFF
GO
SET IDENTITY_INSERT [dbo].[Artists] ON 

GO
INSERT [dbo].[Artists] ([ArtistsId], [Name], [Country], [DateOfBirth], [AlbumId]) VALUES (4, N'Name1', N'Country1', CAST(0x0000000000000000 AS DateTime), 4)
GO
INSERT [dbo].[Artists] ([ArtistsId], [Name], [Country], [DateOfBirth], [AlbumId]) VALUES (5, N'Name2', N'Country2', CAST(0x0000878A00000000 AS DateTime), 5)
GO
INSERT [dbo].[Artists] ([ArtistsId], [Name], [Country], [DateOfBirth], [AlbumId]) VALUES (6, N'Name3', N'Country3', CAST(0x00008EAC00000000 AS DateTime), 6)
GO
SET IDENTITY_INSERT [dbo].[Artists] OFF
GO
INSERT [dbo].[Artists_Albums] ([ArtistId], [AlbumId]) VALUES (4, 4)
GO
INSERT [dbo].[Artists_Albums] ([ArtistId], [AlbumId]) VALUES (5, 5)
GO
INSERT [dbo].[Artists_Albums] ([ArtistId], [AlbumId]) VALUES (6, 6)
GO
SET IDENTITY_INSERT [dbo].[Songs] ON 

GO
INSERT [dbo].[Songs] ([SongId], [Title], [Year], [Genre], [ArtistId], [AlbumId]) VALUES (4, N'Song1', 1990, N'Hard Rock', 4, 4)
GO
INSERT [dbo].[Songs] ([SongId], [Title], [Year], [Genre], [ArtistId], [AlbumId]) VALUES (5, N'Song2', 1995, N'Rock', 5, 5)
GO
INSERT [dbo].[Songs] ([SongId], [Title], [Year], [Genre], [ArtistId], [AlbumId]) VALUES (6, N'Song3', 2000, N'Metal', 6, 6)
GO
SET IDENTITY_INSERT [dbo].[Songs] OFF
GO
ALTER TABLE [dbo].[Artists_Albums]  WITH CHECK ADD  CONSTRAINT [FK_Artists_Albums_Albums] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Albums] ([AlbumId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Artists_Albums] CHECK CONSTRAINT [FK_Artists_Albums_Albums]
GO
ALTER TABLE [dbo].[Artists_Albums]  WITH CHECK ADD  CONSTRAINT [FK_Artists_Albums_Artists] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artists] ([ArtistsId])
GO
ALTER TABLE [dbo].[Artists_Albums] CHECK CONSTRAINT [FK_Artists_Albums_Artists]
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD  CONSTRAINT [FK_Songs_Albums] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Albums] ([AlbumId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Songs] CHECK CONSTRAINT [FK_Songs_Albums]
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD  CONSTRAINT [FK_Songs_Artists] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artists] ([ArtistsId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Songs] CHECK CONSTRAINT [FK_Songs_Artists]
GO
USE [master]
GO
ALTER DATABASE [MusicStoreDb] SET  READ_WRITE 
GO
