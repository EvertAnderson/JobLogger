USE [master]
GO
/****** Object:  Database [JobLoggerDB]    Script Date: 31/03/2016 12:20:49 a.m. ******/
CREATE DATABASE [JobLoggerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JobLoggerDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\JobLoggerDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'JobLoggerDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\JobLoggerDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [JobLoggerDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JobLoggerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JobLoggerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JobLoggerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JobLoggerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JobLoggerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JobLoggerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [JobLoggerDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JobLoggerDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [JobLoggerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JobLoggerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JobLoggerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JobLoggerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JobLoggerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JobLoggerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JobLoggerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JobLoggerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JobLoggerDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JobLoggerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JobLoggerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JobLoggerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JobLoggerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JobLoggerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JobLoggerDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JobLoggerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JobLoggerDB] SET RECOVERY FULL 
GO
ALTER DATABASE [JobLoggerDB] SET  MULTI_USER 
GO
ALTER DATABASE [JobLoggerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JobLoggerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JobLoggerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JobLoggerDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'JobLoggerDB', N'ON'
GO
USE [JobLoggerDB]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 31/03/2016 12:20:49 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[message] [nvarchar](1000) NOT NULL,
	[type] [int] NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [JobLoggerDB] SET  READ_WRITE 
GO
