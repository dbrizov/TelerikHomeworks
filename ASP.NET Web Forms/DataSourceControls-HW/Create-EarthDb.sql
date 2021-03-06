USE [master]
GO
/****** Object:  Database [EarthDb]    Script Date: 11.09.2013 г. 12:28:17 ******/
CREATE DATABASE [EarthDb]
GO
ALTER DATABASE [EarthDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EarthDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EarthDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EarthDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EarthDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EarthDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EarthDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [EarthDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EarthDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [EarthDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EarthDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EarthDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EarthDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EarthDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EarthDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EarthDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EarthDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EarthDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EarthDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EarthDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EarthDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EarthDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EarthDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EarthDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EarthDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EarthDb] SET RECOVERY FULL 
GO
ALTER DATABASE [EarthDb] SET  MULTI_USER 
GO
ALTER DATABASE [EarthDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EarthDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EarthDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EarthDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [EarthDb]
GO
/****** Object:  Table [dbo].[Continents]    Script Date: 11.09.2013 г. 12:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContinentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 11.09.2013 г. 12:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Language] [varchar](20) NOT NULL,
	[Flag] [image] NULL,
	[Population] [int] NOT NULL,
	[ContinentId] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Towns]    Script Date: 11.09.2013 г. 12:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Towns](
	[TownId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Population] [varchar](20) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Continents] ON 

GO
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (8, N'Europe')
GO
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (9, N'Asia')
GO
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (10, N'North America')
GO
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (11, N'South America')
GO
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (12, N'Australia')
GO
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (13, N'Africa')
GO
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (14, N'Antarctica')
GO
SET IDENTITY_INSERT [dbo].[Continents] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

GO
INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Flag], [Population], [ContinentId]) VALUES (6, N'Bulgaria', N'bulgarian', NULL, 7000000, 8)
GO
INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Flag], [Population], [ContinentId]) VALUES (7, N'Russia', N'russian', NULL, 200000000, 9)
GO
INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Flag], [Population], [ContinentId]) VALUES (8, N'USA', N'english', NULL, 250000000, 10)
GO
INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Flag], [Population], [ContinentId]) VALUES (9, N'Germany', N'german', NULL, 70000000, 8)
GO
INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Flag], [Population], [ContinentId]) VALUES (10, N'Japan', N'japanese', NULL, 100000000, 9)
GO
INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Flag], [Population], [ContinentId]) VALUES (11, N'Serbia', N'serbian', NULL, 8000000, 8)
GO
INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Flag], [Population], [ContinentId]) VALUES (12, N'China', N'chinese', NULL, 1000000000, 9)
GO
INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Flag], [Population], [ContinentId]) VALUES (13, N'India', N'indian', NULL, 1500000000, 9)
GO
INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Flag], [Population], [ContinentId]) VALUES (14, N'Canada', N'english', NULL, 150000000, 10)
GO
INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Flag], [Population], [ContinentId]) VALUES (15, N'Mexico', N'spanish', NULL, 150000000, 11)
GO
INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Flag], [Population], [ContinentId]) VALUES (16, N'Argentina', N'portogues', NULL, 100000000, 11)
GO
INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Flag], [Population], [ContinentId]) VALUES (17, N'Australia', N'english', NULL, 90000000, 12)
GO
INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Flag], [Population], [ContinentId]) VALUES (18, N'Egypt', N'egyptian', NULL, 100000000, 13)
GO
INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Flag], [Population], [ContinentId]) VALUES (19, N'Nigeria', N'nigerian', NULL, 80000000, 13)
GO
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Towns] ON 

GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (1, N'Sofia', N'2500000', 6)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (2, N'Moscow', N'11000000', 7)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (3, N'New York', N'18000000', 8)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (4, N'Berlin', N'10000000', 9)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (5, N'Tokyo', N'25000000', 10)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (6, N'Burgas', N'300000', 6)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (7, N'Pleven', N'200000', 6)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (8, N'Plovdiv', N'350000', 6)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (9, N'Lenin Grad', N'1000000', 7)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (10, N'Stalin Grad', N'1500000', 7)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (11, N'Las Vegas', N'15000000', 8)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (12, N'Los Angeles', N'10000000', 8)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (13, N'Washington', N'9000000', 8)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (14, N'Amberg', N'8000000', 9)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (15, N'Amorbach', N'3000000', 9)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (16, N'Coburg', N'2000000', 9)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (17, N'Hidaka', N'4000000', 10)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (18, N'Hiroshima', N'5000000', 10)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (19, N'Iburi', N'6000000', 10)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (20, N'Belgrad', N'2000000', 11)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (21, N'Novi Sad', N'500000', 11)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (22, N'Novi Pazar', N'400000', 11)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (23, N'Pekin', N'30000000', 12)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (26, N'Beijing', N'25000000', 12)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (27, N'Honk Kong', N'40000000', 12)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (28, N'Baddi', N'25000000', 13)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (29, N'Badaun', N'40000000', 13)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (30, N'Agra', N'50000000', 13)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (31, N'Nova Scotia', N'10000000', 14)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (32, N'Ontario', N'9000000', 14)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (33, N'Niagara', N'7000000', 14)
GO
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (34, N'Mexico', N'6000000', 15)
GO
SET IDENTITY_INSERT [dbo].[Towns] OFF
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continents] ([ContinentId])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [EarthDb] SET  READ_WRITE 
GO
