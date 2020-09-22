USE [master]
GO
/****** Object:  Database [ReceptionClinicDB]    Script Date: 9/22/2020 4:44:48 PM ******/
CREATE DATABASE [ReceptionClinicDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ReceptionClinicDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ReceptionClinicDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ReceptionClinicDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ReceptionClinicDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ReceptionClinicDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ReceptionClinicDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ReceptionClinicDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ReceptionClinicDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ReceptionClinicDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ReceptionClinicDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ReceptionClinicDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ReceptionClinicDB] SET  MULTI_USER 
GO
ALTER DATABASE [ReceptionClinicDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ReceptionClinicDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ReceptionClinicDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ReceptionClinicDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ReceptionClinicDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ReceptionClinicDB', N'ON'
GO
ALTER DATABASE [ReceptionClinicDB] SET QUERY_STORE = OFF
GO
USE [ReceptionClinicDB]
GO
/****** Object:  Table [dbo].[Specialty]    Script Date: 9/22/2020 4:44:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialty](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Specialty] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Specialty] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 9/22/2020 4:44:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[FastName] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NOT NULL,
	[DateOfBirthday] [date] NOT NULL,
	[Specialty_id] [int] NOT NULL,
	[FixedPercentage] [float] NOT NULL,
	[AdmissionСost] [money] NOT NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewDoctor]    Script Date: 9/22/2020 4:44:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewDoctor] AS
	SELECT FirstName, FastName, Patronymic, Specialty
	FROM dbo.Doctor AS doct
		INNER JOIN dbo.Specialty AS spec ON doct.Specialty_id = spec.id
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 9/22/2020 4:44:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[FastName] [varchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NOT NULL,
	[DateOfBirthday] [date] NOT NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 9/22/2020 4:44:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[Patient_id] [int] NOT NULL,
	[Doctor_id] [int] NOT NULL,
	[DateOfReceipt] [date] NOT NULL,
 CONSTRAINT [IX_PatientDoctor] PRIMARY KEY CLUSTERED 
(
	[Patient_id] ASC,
	[Doctor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Specialty] FOREIGN KEY([Specialty_id])
REFERENCES [dbo].[Specialty] ([id])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Specialty]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Doctor] FOREIGN KEY([Doctor_id])
REFERENCES [dbo].[Doctor] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Doctor]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Patient1] FOREIGN KEY([Patient_id])
REFERENCES [dbo].[Patient] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Patient1]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [CK_Doctor_DateOfBirthday] CHECK  (([DateOfBirthday]<getdate() AND datediff(year,[DateOfBirthday],getdate())<=(100)))
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [CK_Doctor_DateOfBirthday]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [CK_DateOfBirthday] CHECK  (([DateOfBirthday]<getdate() AND datediff(year,[DateOfBirthday],getdate())<=(100)))
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [CK_DateOfBirthday]
GO
USE [master]
GO
ALTER DATABASE [ReceptionClinicDB] SET  READ_WRITE 
GO
