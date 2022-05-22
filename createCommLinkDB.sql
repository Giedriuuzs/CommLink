USE [master]
GO

/****** Object:  Database [LabLink]    Script Date: 2022-05-20 11:49:23 ******/
CREATE DATABASE [LabLink]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LabLink', FILENAME = N'C:\Sql\LabLink.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LabLink_log', FILENAME = N'C:\Sql\LabLink_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LabLink].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [LabLink] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [LabLink] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [LabLink] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [LabLink] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [LabLink] SET ARITHABORT OFF 
GO

ALTER DATABASE [LabLink] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [LabLink] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [LabLink] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [LabLink] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [LabLink] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [LabLink] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [LabLink] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [LabLink] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [LabLink] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [LabLink] SET  DISABLE_BROKER 
GO

ALTER DATABASE [LabLink] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [LabLink] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [LabLink] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [LabLink] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [LabLink] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [LabLink] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [LabLink] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [LabLink] SET RECOVERY FULL 
GO

ALTER DATABASE [LabLink] SET  MULTI_USER 
GO

ALTER DATABASE [LabLink] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [LabLink] SET DB_CHAINING OFF 
GO

ALTER DATABASE [LabLink] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [LabLink] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [LabLink] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [LabLink] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [LabLink] SET QUERY_STORE = OFF
GO

ALTER DATABASE [LabLink] SET  READ_WRITE 
GO


USE [LabLink]
GO

/****** Object:  Table [dbo].[Analyzer]    Script Date: 2022-05-20 11:49:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Analyzer](
	[AnalyzerID] [int] IDENTITY(1,1) NOT NULL,
	[AnalyzerCode] [varchar](30) NULL,
	[AnalyzerProtocolName] [varchar](30) NULL,
	[AnalyzerType] [varchar](30) NULL,
	[AnalyzerTCPIP] [varchar](40) NULL,
	[AnalyzerTCPIPPORT] [varchar](10) NULL,
	[ISCode] [varchar](30) NULL,
	[ISProtocolName] [varchar](30) NULL,
	[ISType] [varchar](30) NULL,
	[ISTCPIP] [varchar](40) NULL,
	[ISTCPIPPORT] [varchar](10) NULL,
	[Visible] [bit] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Analyzer] PRIMARY KEY CLUSTERED 
(
	[AnalyzerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [LabLink]
GO

/****** Object:  Table [dbo].[AnalyzerExam]    Script Date: 2022-05-20 11:50:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AnalyzerExam](
	[AnalyzerExamID] [int] IDENTITY(1,1) NOT NULL,
	[AnalyzerID] [int] NOT NULL,
	[ISExamCode] [varchar](30) NULL,
	[ISAnalystCode] [varchar](30) NULL,
	[AnalyzerExamCode] [varchar](30) NULL,
	[SendToAnalyzer] [bit] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_AnalyzerExam] PRIMARY KEY CLUSTERED 
(
	[AnalyzerExamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AnalyzerExam]  WITH CHECK ADD  CONSTRAINT [fk_Analyzer_AnalyzerExam] FOREIGN KEY([AnalyzerID])
REFERENCES [dbo].[Analyzer] ([AnalyzerID])
GO

ALTER TABLE [dbo].[AnalyzerExam] CHECK CONSTRAINT [fk_Analyzer_AnalyzerExam]
GO


USE [master]
GO


/****** Object:  Login [CommLink]    Script Date: 2022-05-20 21:33:18 ******/
CREATE LOGIN [CommLink] WITH PASSWORD=N'123', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

USE [LabLink]
GO

/****** Object:  User [CommLink]    Script Date: 2022-05-20 21:37:11 ******/
CREATE USER [CommLink] FOR LOGIN [CommLink] WITH DEFAULT_SCHEMA=[dbo]
GO

USE [LabLink]
GO
ALTER ROLE db_accessadmin ADD MEMBER [CommLink] ;  
ALTER ROLE db_backupoperator ADD MEMBER [CommLink] ; 
ALTER ROLE db_datareader ADD MEMBER [CommLink] ; 
ALTER ROLE db_datawriter ADD MEMBER [CommLink] ; 
ALTER ROLE db_ddladmin ADD MEMBER [CommLink] ; 
ALTER ROLE db_securityadmin ADD MEMBER [CommLink] ; 
GO

USE [LabLink]
GO
/****** Object:  StoredProcedure [dbo].[addOrEditExams]    Script Date: 2022-05-20 21:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[addOrEditExams]
	-- Add the parameters for the stored procedure here
	@AnalyzerExamID int,
	@AnalyzerID int,
	@ISExamCode varchar(30),
	@ISAnalystCode varchar(30),
	@AnalyzerExamCode varchar(30),
	@SendToAnalyzer bit,
	@Active bit
AS
BEGIN
	IF  @AnalyzerExamID = 0
	INSERT INTO AnalyzerExam(AnalyzerID, ISExamCode, ISAnalystCode, AnalyzerExamCode, SendToAnalyzer, Active)
	VALUES (@AnalyzerID, @ISExamCode, @ISAnalystCode, @AnalyzerExamCode, @SendToAnalyzer, @Active)
	ELSE
	UPDATE AnalyzerExam
	SET
	AnalyzerID = @AnalyzerID,
	ISExamCode = @ISExamCode,
	ISAnalystCode = @ISAnalystCode, 
	AnalyzerExamCode = @AnalyzerExamCode,
	SendToAnalyzer = @SendToAnalyzer,
	Active = @Active
	WHERE AnalyzerExamID = @AnalyzerExamID
END

USE [LabLink]
GO
/****** Object:  StoredProcedure [dbo].[deleteAnalyzerExamByID]    Script Date: 2022-05-20 21:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[deleteAnalyzerExamByID] 
	@AnalyzerExamID int
AS
BEGIN
	DELETE FROM AnalyzerExam
	WHERE AnalyzerExamID = @AnalyzerExamID
END
