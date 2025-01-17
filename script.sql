USE [master]
GO
/****** Object:  Database [NetChallangeDB]    Script Date: 16.01.2025 21:54:27 ******/
CREATE DATABASE [NetChallangeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NetChallangeDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\NetChallangeDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NetChallangeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\NetChallangeDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [NetChallangeDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NetChallangeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NetChallangeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NetChallangeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NetChallangeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NetChallangeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NetChallangeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [NetChallangeDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [NetChallangeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NetChallangeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NetChallangeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NetChallangeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NetChallangeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NetChallangeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NetChallangeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NetChallangeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NetChallangeDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NetChallangeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NetChallangeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NetChallangeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NetChallangeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NetChallangeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NetChallangeDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [NetChallangeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NetChallangeDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NetChallangeDB] SET  MULTI_USER 
GO
ALTER DATABASE [NetChallangeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NetChallangeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NetChallangeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NetChallangeDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NetChallangeDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NetChallangeDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [NetChallangeDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [NetChallangeDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [NetChallangeDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 16.01.2025 21:54:27 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarrierConfigurations]    Script Date: 16.01.2025 21:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarrierConfigurations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarrierId] [int] NOT NULL,
	[CarrierMaxDesi] [int] NOT NULL,
	[CarrierMinDesi] [int] NOT NULL,
	[CarrierCost] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_CarrierConfigurations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carriers]    Script Date: 16.01.2025 21:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carriers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarrierName] [nvarchar](max) NOT NULL,
	[CarrierIsActive] [bit] NOT NULL,
	[CarrierPlusDesiCost] [int] NOT NULL,
	[CarrierConfigurationId] [int] NOT NULL,
 CONSTRAINT [PK_Carriers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 16.01.2025 21:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDesi] [int] NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[OrderCarrierCost] [decimal](18, 2) NOT NULL,
	[CarrierId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250114182600_NetChallangeDBDesign', N'6.0.36')
GO
SET IDENTITY_INSERT [dbo].[CarrierConfigurations] ON 

INSERT [dbo].[CarrierConfigurations] ([Id], [CarrierId], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost]) VALUES (4, 11, 10, 1, CAST(32.00 AS Decimal(18, 2)))
INSERT [dbo].[CarrierConfigurations] ([Id], [CarrierId], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost]) VALUES (5, 12, 10, 5, CAST(25.00 AS Decimal(18, 2)))
INSERT [dbo].[CarrierConfigurations] ([Id], [CarrierId], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost]) VALUES (6, 14, 20, 10, CAST(44.00 AS Decimal(18, 2)))
INSERT [dbo].[CarrierConfigurations] ([Id], [CarrierId], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost]) VALUES (7, 16, 50, 100, CAST(50.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[CarrierConfigurations] OFF
GO
SET IDENTITY_INSERT [dbo].[Carriers] ON 

INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CarrierConfigurationId]) VALUES (11, N'HızJet', 1, 4, 4)
INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CarrierConfigurationId]) VALUES (12, N'ABC', 1, 3, 5)
INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CarrierConfigurationId]) VALUES (14, N'Express', 1, 2, 6)
INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CarrierConfigurationId]) VALUES (16, N'Hayat', 1, 8, 7)
SET IDENTITY_INSERT [dbo].[Carriers] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId]) VALUES (8, 13, CAST(N'2025-01-16T21:47:54.7745508' AS DateTime2), CAST(44.00 AS Decimal(18, 2)), 11)
INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId]) VALUES (9, 25, CAST(N'2025-01-16T21:51:43.1566341' AS DateTime2), CAST(54.00 AS Decimal(18, 2)), 14)
INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId]) VALUES (10, 70, CAST(N'2025-01-16T21:51:49.3513560' AS DateTime2), CAST(210.00 AS Decimal(18, 2)), 16)
INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId]) VALUES (11, 18, CAST(N'2025-01-16T21:51:59.0311889' AS DateTime2), CAST(44.00 AS Decimal(18, 2)), 14)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
/****** Object:  Index [IX_Carriers_CarrierConfigurationId]    Script Date: 16.01.2025 21:54:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Carriers_CarrierConfigurationId] ON [dbo].[Carriers]
(
	[CarrierConfigurationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_CarrierId]    Script Date: 16.01.2025 21:54:27 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_CarrierId] ON [dbo].[Orders]
(
	[CarrierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carriers]  WITH CHECK ADD  CONSTRAINT [FK_Carriers_CarrierConfigurations_CarrierConfigurationId] FOREIGN KEY([CarrierConfigurationId])
REFERENCES [dbo].[CarrierConfigurations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carriers] CHECK CONSTRAINT [FK_Carriers_CarrierConfigurations_CarrierConfigurationId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Carriers_CarrierId] FOREIGN KEY([CarrierId])
REFERENCES [dbo].[Carriers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Carriers_CarrierId]
GO
USE [master]
GO
ALTER DATABASE [NetChallangeDB] SET  READ_WRITE 
GO
