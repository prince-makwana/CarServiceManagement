USE [master]
GO
/****** Object:  Database [AutomotiveDB]    Script Date: 3/2/2021 11:01:04 AM ******/
CREATE DATABASE [AutomotiveDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AutomotiveDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQL2017\MSSQL\DATA\AutomotiveDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AutomotiveDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQL2017\MSSQL\DATA\AutomotiveDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AutomotiveDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AutomotiveDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AutomotiveDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AutomotiveDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AutomotiveDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AutomotiveDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AutomotiveDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AutomotiveDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AutomotiveDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AutomotiveDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AutomotiveDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AutomotiveDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AutomotiveDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AutomotiveDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AutomotiveDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AutomotiveDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AutomotiveDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AutomotiveDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AutomotiveDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AutomotiveDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AutomotiveDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AutomotiveDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AutomotiveDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AutomotiveDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AutomotiveDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AutomotiveDB] SET  MULTI_USER 
GO
ALTER DATABASE [AutomotiveDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AutomotiveDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AutomotiveDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AutomotiveDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AutomotiveDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AutomotiveDB] SET QUERY_STORE = OFF
GO
USE [AutomotiveDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [AutomotiveDB]
GO
/****** Object:  Table [dbo].[tblAppointments]    Script Date: 3/2/2021 11:01:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAppointments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[LicencePlate] [nvarchar](20) NOT NULL,
	[FName] [nvarchar](50) NOT NULL,
	[LName] [nvarchar](50) NOT NULL,
	[MobileNo] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Brand] [nvarchar](50) NOT NULL,
	[DealerId] [int] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[TotalPrice] [real] NOT NULL,
	[TotalTime] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tblAppointments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAppointmentServices]    Script Date: 3/2/2021 11:01:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAppointmentServices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppointmentId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[CostType] [nvarchar](50) NOT NULL,
	[SalesPart] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](400) NULL,
	[Quantity] [int] NOT NULL,
	[PricePerUnit] [real] NOT NULL,
	[Price] [real] NOT NULL,
	[Discount] [real] NOT NULL,
	[FixPrice] [real] NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateBy] [nvarchar](100) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tblServices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCustomers]    Script Date: 3/2/2021 11:01:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](100) NOT NULL,
	[FName] [nvarchar](50) NULL,
	[LName] [nvarchar](50) NULL,
	[Address] [nvarchar](400) NOT NULL,
	[ZipCode] [nvarchar](10) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[CustomerNo] [nvarchar](20) NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tblCustomers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDealers]    Script Date: 3/2/2021 11:01:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDealers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DealerName] [nvarchar](100) NOT NULL,
	[DealerNo] [nvarchar](20) NOT NULL,
	[isActive] [bit] NULL,
	[isOnline] [bit] NULL,
	[Website] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PhoneNo] [nvarchar](15) NOT NULL,
	[Address] [nvarchar](400) NOT NULL,
	[Latitude] [real] NOT NULL,
	[Longitude] [real] NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tblDealers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDealersMechanics]    Script Date: 3/2/2021 11:01:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDealersMechanics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DealerId] [int] NOT NULL,
	[MechanicId] [int] NOT NULL,
 CONSTRAINT [PK_tblDealersMechanics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMechanics]    Script Date: 3/2/2021 11:01:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMechanics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MechanicName] [nvarchar](100) NOT NULL,
	[EmployeeNo] [nvarchar](20) NOT NULL,
	[MobileNo] [nvarchar](15) NOT NULL,
	[EmailId] [nvarchar](100) NOT NULL,
	[isActive] [bit] NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[DealerId] [int] NOT NULL,
 CONSTRAINT [PK_tblMechanics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPlannings]    Script Date: 3/2/2021 11:01:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPlannings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppointmentId] [int] NOT NULL,
	[MechanicId] [int] NOT NULL,
	[AppointmentServiceId] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Duration] [datetime] NULL,
 CONSTRAINT [PK_tblPlannings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblServices]    Script Date: 3/2/2021 11:01:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblServices](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Price] [real] NOT NULL,
	[FixPrice] [real] NOT NULL,
	[Discount] [real] NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedDate] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblServices_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVehicles]    Script Date: 3/2/2021 11:01:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVehicles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[Brand] [nvarchar](50) NOT NULL,
	[LicencePlate] [nvarchar](20) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[MeterValue] [int] NULL,
	[RegDate] [date] NOT NULL,
	[Weight] [real] NULL,
	[MCHCode] [nvarchar](50) NULL,
	[Vin] [nvarchar](30) NOT NULL,
	[EngNo] [nvarchar](50) NULL,
	[Colour] [nvarchar](20) NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedDate] [datetime] NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_tblVehicles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_tblVehicles]    Script Date: 3/2/2021 11:01:05 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tblVehicles] ON [dbo].[tblVehicles]
(
	[LicencePlate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblDealers] ADD  CONSTRAINT [DF_tblDealers_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tblDealers] ADD  CONSTRAINT [DF_tblDealers_isOnline]  DEFAULT ((1)) FOR [isOnline]
GO
ALTER TABLE [dbo].[tblMechanics] ADD  CONSTRAINT [DF_tblMechanics_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tblAppointments]  WITH CHECK ADD  CONSTRAINT [FK_tblAppointments_tblCustomers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[tblCustomers] ([Id])
GO
ALTER TABLE [dbo].[tblAppointments] CHECK CONSTRAINT [FK_tblAppointments_tblCustomers]
GO
ALTER TABLE [dbo].[tblAppointments]  WITH CHECK ADD  CONSTRAINT [FK_tblAppointments_tblDealers] FOREIGN KEY([DealerId])
REFERENCES [dbo].[tblDealers] ([Id])
GO
ALTER TABLE [dbo].[tblAppointments] CHECK CONSTRAINT [FK_tblAppointments_tblDealers]
GO
ALTER TABLE [dbo].[tblAppointmentServices]  WITH CHECK ADD  CONSTRAINT [FK_tblAppointmentServices_tblAppointments] FOREIGN KEY([AppointmentId])
REFERENCES [dbo].[tblAppointments] ([Id])
GO
ALTER TABLE [dbo].[tblAppointmentServices] CHECK CONSTRAINT [FK_tblAppointmentServices_tblAppointments]
GO
ALTER TABLE [dbo].[tblAppointmentServices]  WITH CHECK ADD  CONSTRAINT [FK_tblAppointmentServices_tblServices] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[tblServices] ([Id])
GO
ALTER TABLE [dbo].[tblAppointmentServices] CHECK CONSTRAINT [FK_tblAppointmentServices_tblServices]
GO
ALTER TABLE [dbo].[tblDealersMechanics]  WITH CHECK ADD  CONSTRAINT [FK_tblDealersMechanics_tblDealers] FOREIGN KEY([DealerId])
REFERENCES [dbo].[tblDealers] ([Id])
GO
ALTER TABLE [dbo].[tblDealersMechanics] CHECK CONSTRAINT [FK_tblDealersMechanics_tblDealers]
GO
ALTER TABLE [dbo].[tblDealersMechanics]  WITH CHECK ADD  CONSTRAINT [FK_tblDealersMechanics_tblMechanics] FOREIGN KEY([MechanicId])
REFERENCES [dbo].[tblMechanics] ([Id])
GO
ALTER TABLE [dbo].[tblDealersMechanics] CHECK CONSTRAINT [FK_tblDealersMechanics_tblMechanics]
GO
ALTER TABLE [dbo].[tblMechanics]  WITH CHECK ADD  CONSTRAINT [FK_tblMechanics_tblDealers] FOREIGN KEY([DealerId])
REFERENCES [dbo].[tblDealers] ([Id])
GO
ALTER TABLE [dbo].[tblMechanics] CHECK CONSTRAINT [FK_tblMechanics_tblDealers]
GO
ALTER TABLE [dbo].[tblPlannings]  WITH CHECK ADD  CONSTRAINT [FK_tblPlannings_tblAppointments] FOREIGN KEY([AppointmentId])
REFERENCES [dbo].[tblAppointments] ([Id])
GO
ALTER TABLE [dbo].[tblPlannings] CHECK CONSTRAINT [FK_tblPlannings_tblAppointments]
GO
ALTER TABLE [dbo].[tblPlannings]  WITH CHECK ADD  CONSTRAINT [FK_tblPlannings_tblAppointmentServices] FOREIGN KEY([AppointmentServiceId])
REFERENCES [dbo].[tblAppointmentServices] ([Id])
GO
ALTER TABLE [dbo].[tblPlannings] CHECK CONSTRAINT [FK_tblPlannings_tblAppointmentServices]
GO
ALTER TABLE [dbo].[tblPlannings]  WITH CHECK ADD  CONSTRAINT [FK_tblPlannings_tblMechanics] FOREIGN KEY([MechanicId])
REFERENCES [dbo].[tblMechanics] ([Id])
GO
ALTER TABLE [dbo].[tblPlannings] CHECK CONSTRAINT [FK_tblPlannings_tblMechanics]
GO
ALTER TABLE [dbo].[tblVehicles]  WITH CHECK ADD  CONSTRAINT [FK_tblVehicles_tblCustomers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[tblCustomers] ([Id])
GO
ALTER TABLE [dbo].[tblVehicles] CHECK CONSTRAINT [FK_tblVehicles_tblCustomers]
GO
USE [master]
GO
ALTER DATABASE [AutomotiveDB] SET  READ_WRITE 
GO
