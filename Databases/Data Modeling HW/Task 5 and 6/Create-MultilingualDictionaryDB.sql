USE [master]
GO
/****** Object:  Database [MultilingualDictionary]    Script Date: 12.7.2013 г. 22:27:35 ч. ******/
CREATE DATABASE [MultilingualDictionary]
GO

USE [MultilingualDictionary]
GO

ALTER DATABASE [MultilingualDictionary] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MultilingualDictionary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ARITHABORT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MultilingualDictionary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MultilingualDictionary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MultilingualDictionary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET RECOVERY FULL 
GO
ALTER DATABASE [MultilingualDictionary] SET  MULTI_USER 
GO
ALTER DATABASE [MultilingualDictionary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MultilingualDictionary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MultilingualDictionary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MultilingualDictionary', N'ON'
GO
USE [MultilingualDictionary]
GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 12.7.2013 г. 22:27:35 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanations](
	[ExplanationID] [int] IDENTITY(1,1) NOT NULL,
	[Explanation] [ntext] NOT NULL,
	[LanguageID] [int] NOT NULL,
 CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED 
(
	[ExplanationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 12.7.2013 г. 22:27:35 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[Language] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SpeechParts]    Script Date: 12.7.2013 г. 22:27:35 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpeechParts](
	[SpeechPartID] [int] IDENTITY(1,1) NOT NULL,
	[SpeechPart] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SpeechParts] PRIMARY KEY CLUSTERED 
(
	[SpeechPartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Synonyms]    Script Date: 12.7.2013 г. 22:27:35 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonyms](
	[SynonymID] [int] IDENTITY(1,1) NOT NULL,
	[Synonym] [nvarchar](50) NOT NULL,
	[LanguageID] [int] NOT NULL,
 CONSTRAINT [PK_Synonyms] PRIMARY KEY CLUSTERED 
(
	[SynonymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Translations]    Script Date: 12.7.2013 г. 22:27:35 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translations](
	[TranslationID] [int] IDENTITY(1,1) NOT NULL,
	[Translation] [nvarchar](50) NOT NULL,
	[LanguageID] [int] NOT NULL,
 CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED 
(
	[TranslationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 12.7.2013 г. 22:27:35 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[WordID] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[Antonym] [nvarchar](50) NULL,
	[LanguageID] [int] NOT NULL,
	[SpeechPartID] [int] NOT NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordsExplanations]    Script Date: 12.7.2013 г. 22:27:35 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordsExplanations](
	[WordID] [int] NOT NULL,
	[ExplanationID] [int] NOT NULL,
 CONSTRAINT [PK_WordsExplanations] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC,
	[ExplanationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordsSynonyms]    Script Date: 12.7.2013 г. 22:27:35 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordsSynonyms](
	[WordID] [int] NOT NULL,
	[SynonymID] [int] NOT NULL,
 CONSTRAINT [PK_WordsSynonyms] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC,
	[SynonymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordsTranslations]    Script Date: 12.7.2013 г. 22:27:35 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordsTranslations](
	[WordID] [int] NOT NULL,
	[TranslationID] [int] NOT NULL,
 CONSTRAINT [PK_WordsTranslations] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC,
	[TranslationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Languages] ON 

GO
INSERT [dbo].[Languages] ([LanguageID], [Language]) VALUES (1, N'English')
GO
INSERT [dbo].[Languages] ([LanguageID], [Language]) VALUES (2, N'Bulgarian')
GO
INSERT [dbo].[Languages] ([LanguageID], [Language]) VALUES (3, N'German')
GO
INSERT [dbo].[Languages] ([LanguageID], [Language]) VALUES (4, N'French')
GO
INSERT [dbo].[Languages] ([LanguageID], [Language]) VALUES (5, N'Spanish')
GO
INSERT [dbo].[Languages] ([LanguageID], [Language]) VALUES (6, N'Italian')
GO
INSERT [dbo].[Languages] ([LanguageID], [Language]) VALUES (7, N'Russian')
GO
SET IDENTITY_INSERT [dbo].[Languages] OFF
GO
SET IDENTITY_INSERT [dbo].[SpeechParts] ON 

GO
INSERT [dbo].[SpeechParts] ([SpeechPartID], [SpeechPart]) VALUES (1, N'Noun')
GO
INSERT [dbo].[SpeechParts] ([SpeechPartID], [SpeechPart]) VALUES (2, N'Verb')
GO
INSERT [dbo].[SpeechParts] ([SpeechPartID], [SpeechPart]) VALUES (3, N'Adjective')
GO
SET IDENTITY_INSERT [dbo].[SpeechParts] OFF
GO
SET IDENTITY_INSERT [dbo].[Words] ON 

GO
INSERT [dbo].[Words] ([WordID], [Word], [Antonym], [LanguageID], [SpeechPartID]) VALUES (1, N'Dog', NULL, 1, 1)
GO
INSERT [dbo].[Words] ([WordID], [Word], [Antonym], [LanguageID], [SpeechPartID]) VALUES (2, N'Cat', NULL, 1, 1)
GO
INSERT [dbo].[Words] ([WordID], [Word], [Antonym], [LanguageID], [SpeechPartID]) VALUES (3, N'Куче', NULL, 2, 1)
GO
INSERT [dbo].[Words] ([WordID], [Word], [Antonym], [LanguageID], [SpeechPartID]) VALUES (4, N'Котка', NULL, 2, 1)
GO
INSERT [dbo].[Words] ([WordID], [Word], [Antonym], [LanguageID], [SpeechPartID]) VALUES (5, N'Hallo', NULL, 3, 1)
GO
SET IDENTITY_INSERT [dbo].[Words] OFF
GO
ALTER TABLE [dbo].[Words] ADD  CONSTRAINT [DF_Words_SpeechPartID]  DEFAULT ((1)) FOR [SpeechPartID]
GO
ALTER TABLE [dbo].[Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Explanations_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Explanations] CHECK CONSTRAINT [FK_Explanations_Languages]
GO
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_Languages]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_SpeechParts] FOREIGN KEY([SpeechPartID])
REFERENCES [dbo].[SpeechParts] ([SpeechPartID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_SpeechParts]
GO
ALTER TABLE [dbo].[WordsExplanations]  WITH CHECK ADD  CONSTRAINT [FK_WordsExplanations_Explanations] FOREIGN KEY([ExplanationID])
REFERENCES [dbo].[Explanations] ([ExplanationID])
GO
ALTER TABLE [dbo].[WordsExplanations] CHECK CONSTRAINT [FK_WordsExplanations_Explanations]
GO
ALTER TABLE [dbo].[WordsExplanations]  WITH CHECK ADD  CONSTRAINT [FK_WordsExplanations_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[WordsExplanations] CHECK CONSTRAINT [FK_WordsExplanations_Words]
GO
ALTER TABLE [dbo].[WordsSynonyms]  WITH CHECK ADD  CONSTRAINT [FK_WordsSynonyms_Synonyms] FOREIGN KEY([SynonymID])
REFERENCES [dbo].[Synonyms] ([SynonymID])
GO
ALTER TABLE [dbo].[WordsSynonyms] CHECK CONSTRAINT [FK_WordsSynonyms_Synonyms]
GO
ALTER TABLE [dbo].[WordsSynonyms]  WITH CHECK ADD  CONSTRAINT [FK_WordsSynonyms_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[WordsSynonyms] CHECK CONSTRAINT [FK_WordsSynonyms_Words]
GO
ALTER TABLE [dbo].[WordsTranslations]  WITH CHECK ADD  CONSTRAINT [FK_WordsTranslations_Translations] FOREIGN KEY([TranslationID])
REFERENCES [dbo].[Translations] ([TranslationID])
GO
ALTER TABLE [dbo].[WordsTranslations] CHECK CONSTRAINT [FK_WordsTranslations_Translations]
GO
ALTER TABLE [dbo].[WordsTranslations]  WITH CHECK ADD  CONSTRAINT [FK_WordsTranslations_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[WordsTranslations] CHECK CONSTRAINT [FK_WordsTranslations_Words]
GO
USE [master]
GO
ALTER DATABASE [MultilingualDictionary] SET  READ_WRITE 
GO
