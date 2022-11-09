USE [DMA-CSD-S211_10407501]
GO
ALTER TABLE [dbo].[Rentals] DROP CONSTRAINT [FK_Rentals_Customers_ownerId]
GO
ALTER TABLE [dbo].[Rentals] DROP CONSTRAINT [FK_Rentals_Customers_loanerId]
GO
ALTER TABLE [dbo].[Rentals] DROP CONSTRAINT [FK_Rentals_Cars_carId]
GO
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Cars_Customers_ownerId]
GO
ALTER TABLE [dbo].[CarImages] DROP CONSTRAINT [FK_CarImages_Cars_CarId]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 09-11-2022 11:27:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rentals]') AND type in (N'U'))
DROP TABLE [dbo].[Rentals]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 09-11-2022 11:27:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
DROP TABLE [dbo].[Customers]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 09-11-2022 11:27:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cars]') AND type in (N'U'))
DROP TABLE [dbo].[Cars]
GO
/****** Object:  Table [dbo].[CarImages]    Script Date: 09-11-2022 11:27:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CarImages]') AND type in (N'U'))
DROP TABLE [dbo].[CarImages]
GO
/****** Object:  Table [dbo].[CarImages]    Script Date: 09-11-2022 11:27:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [varbinary](max) NOT NULL,
	[CarId] [int] NULL,
 CONSTRAINT [PK_CarImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 09-11-2022 11:27:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ownerId] [nvarchar](450) NOT NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Year] [int] NOT NULL,
	[Mileage] [float] NOT NULL,
	[Type] [int] NOT NULL,
	[FuelType] [int] NOT NULL,
	[Doors] [int] NOT NULL,
	[FuelConsumption] [float] NULL,
	[ElectricityConsumption] [float] NULL,
	[HK] [int] NULL,
	[GearType] [int] NOT NULL,
	[RegNumber] [nvarchar](max) NOT NULL,
	[Color] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 09-11-2022 11:27:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](max) NOT NULL,
	[Lastname] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[EMail] [nvarchar](max) NOT NULL,
	[CPR] [nvarchar](max) NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[DriverLicenseNr] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 09-11-2022 11:27:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[carId] [int] NULL,
	[ownerId] [nvarchar](450) NULL,
	[loanerId] [nvarchar](450) NULL,
	[RentalPeriod] [time](7) NOT NULL,
 CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CarImages]  WITH CHECK ADD  CONSTRAINT [FK_CarImages_Cars_CarId] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[CarImages] CHECK CONSTRAINT [FK_CarImages_Cars_CarId]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_AspNetUsers_ownerId] FOREIGN KEY([ownerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_AspNetUsers_ownerId]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_Cars_carId] FOREIGN KEY([carId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_Cars_carId]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_AspNetUsers_loanerId] FOREIGN KEY([loanerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_AspNetUsers_loanerId]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_AspNetUsers_ownerId] FOREIGN KEY([ownerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_AspNetUsers_ownerId]
GO
