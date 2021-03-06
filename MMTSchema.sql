USE [master]
GO
/****** Object:  Database [MMTShop]    Script Date: 6/15/2021 2:09:56 PM ******/
CREATE DATABASE [MMTShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MMTShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MMTShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MMTShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MMTShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MMTShop] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MMTShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MMTShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MMTShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MMTShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MMTShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MMTShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [MMTShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MMTShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MMTShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MMTShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MMTShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MMTShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MMTShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MMTShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MMTShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MMTShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MMTShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MMTShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MMTShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MMTShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MMTShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MMTShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MMTShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MMTShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MMTShop] SET  MULTI_USER 
GO
ALTER DATABASE [MMTShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MMTShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MMTShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MMTShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MMTShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MMTShop] SET QUERY_STORE = OFF
GO
USE [MMTShop]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/15/2021 2:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/15/2021 2:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 6/15/2021 2:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SKU] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK__Products__Catego__3E52440B] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK__Products__Catego__3E52440B]
GO
/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 6/15/2021 2:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Patrick Imobioh
-- Create date: June 2021
-- Description:	Query to get all categories
-- =============================================
CREATE PROCEDURE [dbo].[GetCategories]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Categories
END
GO
/****** Object:  StoredProcedure [dbo].[GetFeaturedProducts]    Script Date: 6/15/2021 2:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Patrick Imobioh
-- Create date: June 2021
-- Description:	Query to get all products
-- =============================================
CREATE PROCEDURE [dbo].[GetFeaturedProducts]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Products where SKU like '[123]%';
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductsByCategory]    Script Date: 6/15/2021 2:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Patrick Imobioh
-- Create date: June 2021
-- Description:	Query to get all products by category
-- =============================================
CREATE PROCEDURE [dbo].[GetProductsByCategory] 
	-- Add the parameters for the stored procedure here
	@CategoryId int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Products where CategoryId = @CategoryId
END
GO
USE [master]
GO
ALTER DATABASE [MMTShop] SET  READ_WRITE 
GO
