USE [master]
GO
/****** Object:  Database [SimpleWebChat]    Script Date: 14.9.2013 г. 15:09:08 ******/
CREATE DATABASE [SimpleWebChat]
GO
ALTER DATABASE [SimpleWebChat] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SimpleWebChat].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SimpleWebChat] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SimpleWebChat] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SimpleWebChat] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SimpleWebChat] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SimpleWebChat] SET ARITHABORT OFF 
GO
ALTER DATABASE [SimpleWebChat] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SimpleWebChat] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SimpleWebChat] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SimpleWebChat] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SimpleWebChat] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SimpleWebChat] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SimpleWebChat] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SimpleWebChat] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SimpleWebChat] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SimpleWebChat] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SimpleWebChat] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SimpleWebChat] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SimpleWebChat] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SimpleWebChat] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SimpleWebChat] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SimpleWebChat] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SimpleWebChat] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SimpleWebChat] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SimpleWebChat] SET RECOVERY FULL 
GO
ALTER DATABASE [SimpleWebChat] SET  MULTI_USER 
GO
ALTER DATABASE [SimpleWebChat] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SimpleWebChat] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SimpleWebChat] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SimpleWebChat] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SimpleWebChat', N'ON'
GO
USE [SimpleWebChat]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 14.9.2013 г. 15:09:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [SimpleWebChat] SET  READ_WRITE 
GO
