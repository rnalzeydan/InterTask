USE [master]
GO
/****** Object:  Database [InterTaskDb]    Script Date: 16/02/22 12:10:48 م ******/
CREATE DATABASE [InterTaskDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InterTaskDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\InterTaskDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InterTaskDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\InterTaskDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [InterTaskDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InterTaskDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InterTaskDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InterTaskDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InterTaskDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InterTaskDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InterTaskDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [InterTaskDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InterTaskDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InterTaskDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InterTaskDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InterTaskDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InterTaskDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InterTaskDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InterTaskDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InterTaskDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InterTaskDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InterTaskDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InterTaskDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InterTaskDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InterTaskDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InterTaskDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InterTaskDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InterTaskDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InterTaskDb] SET RECOVERY FULL 
GO
ALTER DATABASE [InterTaskDb] SET  MULTI_USER 
GO
ALTER DATABASE [InterTaskDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InterTaskDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InterTaskDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InterTaskDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InterTaskDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InterTaskDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'InterTaskDb', N'ON'
GO
ALTER DATABASE [InterTaskDb] SET QUERY_STORE = OFF
GO
USE [InterTaskDb]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 16/02/22 12:10:48 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[searchResults]    Script Date: 16/02/22 12:10:48 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[searchResults](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[city] [nvarchar](50) NULL,
	[humidity] [nvarchar](10) NULL,
	[temperatureMax] [nvarchar](10) NULL,
	[temperatureMin] [nvarchar](10) NULL,
	[account_id] [int] NULL,
	[date] [datetime] NULL,
	[deleted] [bit] NULL,
	[deletedAt] [datetime] NULL,
	[deletedBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_searchResults] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[searchResults]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[accounts] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[spGetSearchResultByUsername]    Script Date: 16/02/22 12:10:48 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetSearchResultByUsername] 
	@Username nvarchar(150)
AS
BEGIN
	SELECT * FROM searchResults
	JOIN accounts a ON account_id = a.Id
	WHERE Username = @Username
END
GO
/****** Object:  StoredProcedure [dbo].[spSaveSearchResult]    Script Date: 16/02/22 12:10:48 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spSaveSearchResult] 
	-- Add the parameters for the stored procedure here
	@Humidity nvarchar(10), 
	@TempMax nvarchar(10), 
	@TempMin nvarchar(10), 
	@Username nvarchar(150), 
	@City nvarchar(50)
AS
BEGIN
	INSERT INTO [dbo].[searchResults]
           ([city]
           ,[humidity]
           ,[temperatureMax]
           ,[temperatureMin]
           ,[account_id]
           ,[date])
     VALUES
           (@City
           ,@Humidity
           ,@TempMax
           ,@TempMin
           ,(SELECT id FROM accounts WHERE Username = @Username)
           ,GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[spVerifyAccount]    Script Date: 16/02/22 12:10:48 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spVerifyAccount] 
	@Username nvarchar(150),
	@Password nvarchar(250)
AS
BEGIN
	
	IF EXISTS(SELECT * FROM accounts WHERE username = @username AND password = @password)
		SELECT username FROM accounts WHERE username = @username AND password = @password
	ELSE
		SELECT null as 'username'
END
GO
USE [master]
GO
ALTER DATABASE [InterTaskDb] SET  READ_WRITE 
GO
