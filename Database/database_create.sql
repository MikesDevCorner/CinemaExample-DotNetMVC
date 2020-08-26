USE [master]
GO

/****** Object:  Database [movies]    Script Date: 11.04.2019 01:43:16 ******/
CREATE DATABASE [movies]
 CONTAINMENT = NONE
ALTER DATABASE [movies] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [movies].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [movies] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [movies] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [movies] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [movies] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [movies] SET ARITHABORT OFF 
GO

ALTER DATABASE [movies] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [movies] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [movies] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [movies] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [movies] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [movies] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [movies] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [movies] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [movies] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [movies] SET  DISABLE_BROKER 
GO

ALTER DATABASE [movies] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [movies] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [movies] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [movies] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [movies] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [movies] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [movies] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [movies] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [movies] SET  MULTI_USER 
GO

ALTER DATABASE [movies] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [movies] SET DB_CHAINING OFF 
GO

ALTER DATABASE [movies] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [movies] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [movies] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [movies] SET QUERY_STORE = OFF
GO

ALTER DATABASE [movies] SET  READ_WRITE 
GO

