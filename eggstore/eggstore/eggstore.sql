USE [master]
GO
/****** Object:  Database [eggstore]    Script Date: 3/9/2023 10:52:51 PM ******/
CREATE DATABASE [eggstore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'eggstore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\eggstore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'eggstore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\eggstore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [eggstore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eggstore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eggstore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eggstore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eggstore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eggstore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eggstore] SET ARITHABORT OFF 
GO
ALTER DATABASE [eggstore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [eggstore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eggstore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eggstore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eggstore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eggstore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eggstore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eggstore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eggstore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eggstore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [eggstore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eggstore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eggstore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eggstore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eggstore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eggstore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [eggstore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [eggstore] SET RECOVERY FULL 
GO
ALTER DATABASE [eggstore] SET  MULTI_USER 
GO
ALTER DATABASE [eggstore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eggstore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [eggstore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [eggstore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [eggstore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [eggstore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'eggstore', N'ON'
GO
ALTER DATABASE [eggstore] SET QUERY_STORE = OFF
GO
USE [eggstore]
GO
/****** Object:  Table [dbo].[Privilegios]    Script Date: 3/9/2023 10:52:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Privilegios](
	[IdPrivilegio] [int] IDENTITY(1,1) NOT NULL,
	[NombrePrivilegio] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 3/9/2023 10:52:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[Telefono] [float] NULL,
	[Identificacion] [float] NULL,
	[Correo] [varchar](100) NULL,
	[Sector] [varchar](50) NULL,
	[Privilegio] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Privilegios] ON 

INSERT [dbo].[Privilegios] ([IdPrivilegio], [NombrePrivilegio]) VALUES (1, N'Administrador')
INSERT [dbo].[Privilegios] ([IdPrivilegio], [NombrePrivilegio]) VALUES (2, N'Proveedor')
SET IDENTITY_INSERT [dbo].[Privilegios] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Nombres], [Apellidos], [Telefono], [Identificacion], [Correo], [Sector], [Privilegio]) VALUES (1, N'Ramses', N'Martinez', 8091234567, 40233365150, N'uncorreo@gmail.com', N'El Almirante', 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
USE [master]
GO
ALTER DATABASE [eggstore] SET  READ_WRITE 
GO
