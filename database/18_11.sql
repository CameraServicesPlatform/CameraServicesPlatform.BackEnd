USE [master]
GO
/****** Object:  Database [CameraCapstone]    Script Date: 11/18/2024 11:24:33 PM ******/
CREATE DATABASE [CameraCapstone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CameraCapstone', FILENAME = N'/var/opt/mssql/data/CameraCapstone.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CameraCapstone_log', FILENAME = N'/var/opt/mssql/data/CameraCapstone_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CameraCapstone] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CameraCapstone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CameraCapstone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CameraCapstone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CameraCapstone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CameraCapstone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CameraCapstone] SET ARITHABORT OFF 
GO
ALTER DATABASE [CameraCapstone] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CameraCapstone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CameraCapstone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CameraCapstone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CameraCapstone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CameraCapstone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CameraCapstone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CameraCapstone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CameraCapstone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CameraCapstone] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CameraCapstone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CameraCapstone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CameraCapstone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CameraCapstone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CameraCapstone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CameraCapstone] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CameraCapstone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CameraCapstone] SET RECOVERY FULL 
GO
ALTER DATABASE [CameraCapstone] SET  MULTI_USER 
GO
ALTER DATABASE [CameraCapstone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CameraCapstone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CameraCapstone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CameraCapstone] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CameraCapstone] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CameraCapstone] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CameraCapstone', N'ON'
GO
ALTER DATABASE [CameraCapstone] SET QUERY_STORE = ON
GO
ALTER DATABASE [CameraCapstone] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CameraCapstone]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/18/2024 11:24:34 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Job] [int] NULL,
	[Hobby] [int] NULL,
	[Gender] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsVerified] [bit] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[VerifyCode] [nvarchar](max) NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[RefreshTokenExpiryTime] [datetime2](7) NULL,
	[SupplierID] [nvarchar](max) NULL,
	[StaffID] [nvarchar](max) NULL,
	[Img] [nvarchar](max) NULL,
	[FrontOfCitizenIdentificationCard] [nvarchar](max) NULL,
	[BackOfCitizenIdentificationCard] [nvarchar](max) NULL,
	[BankName] [nvarchar](max) NULL,
	[AccountNumber] [nvarchar](max) NULL,
	[AccountHolder] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [uniqueidentifier] NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
	[CategoryDescription] [nvarchar](max) NULL,
	[StatusCategory] [bit] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contracts]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contracts](
	[ContractID] [uniqueidentifier] NOT NULL,
	[OrderID] [uniqueidentifier] NOT NULL,
	[ContractTemplateId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[ContractTerms] [nvarchar](max) NOT NULL,
	[PenaltyPolicy] [nvarchar](max) NOT NULL,
	[TemplateDetails] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Contracts] PRIMARY KEY CLUSTERED 
(
	[ContractID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractTemplates]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractTemplates](
	[ContractTemplateId] [uniqueidentifier] NOT NULL,
	[TemplateName] [nvarchar](255) NOT NULL,
	[ProductID] [uniqueidentifier] NOT NULL,
	[ContractTerms] [nvarchar](max) NOT NULL,
	[TemplateDetails] [nvarchar](max) NOT NULL,
	[PenaltyPolicy] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[AccountID] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_ContractTemplates] PRIMARY KEY CLUSTERED 
(
	[ContractTemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveriesMethod]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveriesMethod](
	[DeliveriesMethodID] [uniqueidentifier] NOT NULL,
	[MethodName] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_DeliveriesMethod] PRIMARY KEY CLUSTERED 
(
	[DeliveriesMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistoryTransactions]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryTransactions](
	[HistoryTransactionId] [uniqueidentifier] NOT NULL,
	[SupplierID] [uniqueidentifier] NOT NULL,
	[Price] [float] NOT NULL,
	[TransactionDescription] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_HistoryTransactions] PRIMARY KEY CLUSTERED 
(
	[HistoryTransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailsID] [uniqueidentifier] NOT NULL,
	[OrderID] [uniqueidentifier] NOT NULL,
	[ProductID] [uniqueidentifier] NOT NULL,
	[ProductPrice] [float] NOT NULL,
	[ProductQuality] [nvarchar](max) NOT NULL,
	[Discount] [float] NOT NULL,
	[ProductPriceTotal] [float] NOT NULL,
	[RentalPeriod] [int] NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [uniqueidentifier] NOT NULL,
	[SupplierID] [uniqueidentifier] NOT NULL,
	[Id] [nvarchar](max) NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[OrderStatus] [int] NOT NULL,
	[TotalAmount] [float] NULL,
	[OrderType] [int] NOT NULL,
	[RentalStartDate] [datetime2](7) NULL,
	[RentalEndDate] [datetime2](7) NULL,
	[DurationUnit] [int] NOT NULL,
	[DurationValue] [int] NOT NULL,
	[ReturnDate] [datetime2](7) NULL,
	[ShippingAddress] [nvarchar](max) NULL,
	[DeliveriesMethod] [int] NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[AccountId] [nvarchar](450) NULL,
	[OrderDetailID] [uniqueidentifier] NULL,
	[Deposit] [float] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [uniqueidentifier] NOT NULL,
	[OrderID] [uniqueidentifier] NULL,
	[SupplierID] [uniqueidentifier] NOT NULL,
	[AccountID] [nvarchar](450) NOT NULL,
	[PaymentDate] [datetime2](7) NOT NULL,
	[PaymentAmount] [float] NOT NULL,
	[PaymentType] [int] NOT NULL,
	[PaymentStatus] [int] NOT NULL,
	[PaymentMethod] [int] NOT NULL,
	[PaymentDetails] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[IsDisable] [bit] NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Policies]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Policies](
	[PolicyID] [uniqueidentifier] NOT NULL,
	[PolicyType] [int] NOT NULL,
	[PolicyContent] [nvarchar](max) NOT NULL,
	[ApplicableObject] [int] NOT NULL,
	[EffectiveDate] [datetime2](7) NOT NULL,
	[Value] [datetime2](7) NOT NULL,
	[IsDisable] [bit] NOT NULL,
 CONSTRAINT [PK_Policies] PRIMARY KEY CLUSTERED 
(
	[PolicyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImages](
	[ProductImagesID] [uniqueidentifier] NOT NULL,
	[ProductID] [uniqueidentifier] NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED 
(
	[ProductImagesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductReports]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductReports](
	[ProductReportID] [uniqueidentifier] NOT NULL,
	[SupplierID] [uniqueidentifier] NOT NULL,
	[ProductID] [uniqueidentifier] NOT NULL,
	[StatusType] [int] NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NULL,
	[Reason] [nvarchar](max) NULL,
	[AccountID] [nvarchar](max) NULL,
	[Account] [nvarchar](450) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ProductReports] PRIMARY KEY CLUSTERED 
(
	[ProductReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [uniqueidentifier] NOT NULL,
	[SerialNumber] [nvarchar](max) NOT NULL,
	[SupplierID] [uniqueidentifier] NULL,
	[CategoryID] [uniqueidentifier] NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[ProductDescription] [nvarchar](max) NULL,
	[PriceRent] [float] NULL,
	[PriceBuy] [float] NULL,
	[Brand] [int] NULL,
	[Quality] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[Rating] [float] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[DepositProduct] [float] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSpecifications]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSpecifications](
	[ProductSpecificationID] [uniqueidentifier] NOT NULL,
	[ProductID] [uniqueidentifier] NOT NULL,
	[Specification] [nvarchar](max) NOT NULL,
	[Details] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductSpecifications] PRIMARY KEY CLUSTERED 
(
	[ProductSpecificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductVouchers]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductVouchers](
	[ProductVoucherID] [uniqueidentifier] NOT NULL,
	[ProductID] [uniqueidentifier] NOT NULL,
	[VourcherID] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[IsDisable] [bit] NOT NULL,
 CONSTRAINT [PK_ProductVouchers] PRIMARY KEY CLUSTERED 
(
	[ProductVoucherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[RatingID] [uniqueidentifier] NOT NULL,
	[ProductID] [uniqueidentifier] NOT NULL,
	[AccountID] [nvarchar](450) NOT NULL,
	[RatingValue] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ReviewComment] [nvarchar](max) NOT NULL,
	[IsDisable] [bit] NOT NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[RatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalPrices]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalPrices](
	[RentalPriceID] [uniqueidentifier] NOT NULL,
	[ProductID] [uniqueidentifier] NOT NULL,
	[PricePerHour] [float] NULL,
	[PricePerDay] [float] NULL,
	[PricePerWeek] [float] NULL,
	[PricePerMonth] [float] NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_RentalPrices] PRIMARY KEY CLUSTERED 
(
	[RentalPriceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[ReportID] [uniqueidentifier] NOT NULL,
	[AccountId] [nvarchar](450) NULL,
	[ReportType] [int] NOT NULL,
	[ReportDetails] [nvarchar](max) NOT NULL,
	[ReportDate] [datetime2](7) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requests]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests](
	[SupplierRequestID] [uniqueidentifier] NOT NULL,
	[AccountID] [nvarchar](450) NULL,
	[RoleRequestID] [uniqueidentifier] NOT NULL,
	[RequestStatus] [int] NOT NULL,
	[RequestDate] [datetime2](7) NOT NULL,
	[ReviewedBy] [uniqueidentifier] NULL,
	[ReviewDate] [datetime2](7) NULL,
	[ReviewNotes] [nvarchar](max) NOT NULL,
	[IsDisable] [bit] NOT NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
	[SupplierRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReturnDetails]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnDetails](
	[ReturnID] [uniqueidentifier] NOT NULL,
	[OrderID] [uniqueidentifier] NOT NULL,
	[ReturnDate] [datetime2](7) NOT NULL,
	[Condition] [nvarchar](max) NOT NULL,
	[PenaltyApplied] [float] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[IsDisable] [bit] NOT NULL,
 CONSTRAINT [PK_ReturnDetails] PRIMARY KEY CLUSTERED 
(
	[ReturnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[StaffID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[AccountID] [nvarchar](450) NOT NULL,
	[JobTitle] [nvarchar](max) NOT NULL,
	[Department] [nvarchar](max) NOT NULL,
	[StaffStatus] [nvarchar](max) NOT NULL,
	[HireDate] [datetime2](7) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[Img] [nvarchar](max) NOT NULL,
	[IsDisable] [bit] NOT NULL,
 CONSTRAINT [PK_Staffs] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierReports]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierReports](
	[SupplierReportID] [uniqueidentifier] NOT NULL,
	[SupplierID] [uniqueidentifier] NOT NULL,
	[StatusType] [int] NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NULL,
	[Reason] [nvarchar](max) NULL,
	[AccountID] [nvarchar](450) NULL,
	[StaffID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SupplierReports] PRIMARY KEY CLUSTERED 
(
	[SupplierReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierRequests]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierRequests](
	[SupplierRequestID] [uniqueidentifier] NOT NULL,
	[SupplierID] [uniqueidentifier] NOT NULL,
	[RequestType] [int] NOT NULL,
	[RequestDetails] [nvarchar](max) NOT NULL,
	[RequestDate] [datetime2](7) NOT NULL,
	[RequestStatus] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_SupplierRequests] PRIMARY KEY CLUSTERED 
(
	[SupplierRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierID] [uniqueidentifier] NOT NULL,
	[AccountID] [nvarchar](450) NULL,
	[SupplierName] [nvarchar](max) NOT NULL,
	[SupplierDescription] [nvarchar](max) NULL,
	[SupplierAddress] [nvarchar](max) NULL,
	[ContactNumber] [nvarchar](max) NULL,
	[SupplierLogo] [nvarchar](max) NULL,
	[BlockReason] [nvarchar](max) NULL,
	[BlockedAt] [datetime2](7) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[AccountBalance] [float] NOT NULL,
	[Img] [nvarchar](max) NULL,
	[IsDisable] [bit] NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionID] [uniqueidentifier] NOT NULL,
	[OrderID] [uniqueidentifier] NOT NULL,
	[TransactionDate] [datetime2](7) NOT NULL,
	[Amount] [float] NOT NULL,
	[TransactionType] [int] NOT NULL,
	[PaymentStatus] [int] NOT NULL,
	[PaymentMethod] [int] NOT NULL,
	[VNPAYTransactionID] [nvarchar](max) NULL,
	[VNPAYTransactionStatus] [int] NULL,
	[VNPAYTransactionTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vourchers]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vourchers](
	[VourcherID] [uniqueidentifier] NOT NULL,
	[SupplierID] [uniqueidentifier] NULL,
	[VourcherCode] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[DiscountAmount] [float] NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ExpirationDate] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Vourchers] PRIMARY KEY CLUSTERED 
(
	[VourcherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wishlists]    Script Date: 11/18/2024 11:24:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wishlists](
	[WishlistID] [uniqueidentifier] NOT NULL,
	[AccountID] [nvarchar](450) NOT NULL,
	[ProductID] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsDisable] [bit] NOT NULL,
 CONSTRAINT [PK_Wishlists] PRIMARY KEY CLUSTERED 
(
	[WishlistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240918072721_InitTable', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240919213243_RemoveWarmmingForgeinKey', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240920161058_VPS', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240922072935_UpdateMembertable', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240922075350_ChangeTyleDecimalToDouble', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240922075504_ChangeTyleDecimalToDouble2nd', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240922083744_fixReportForgienKeyAccount', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240922223534_UpdateCategoryIDType', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240925071144_FixCategoryIDType', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240925072542_productfix', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240929095133_Update', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240929111359_UpdateRole', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241005161133_[UpdateAccountField]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241005162644_[UpdateProdcutReport]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241005191431_[vourcher]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241006050945_[updateProduct]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241006052157_[updateProduct]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241006054901_[addProductVoucher]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241006081905_[UpdateProduct]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241007172642_[account]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241007212254_[accountupdate]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241008142953_[rolename]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241009135028_[fiximgnullSupplier]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014124723_[UpdateAccountContractBankInformationWishlist]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014131558_[UpdateAccountContractBankInformationWishlist]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014132942_[UpdateAccountContractBankInformationWishlist]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014144046_[bankinfo]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014153044_[UpdateAccountContractBankInformationWishlist]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014154347_[acouunt]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014171426_[UpdateAccount]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014174100_[UpdateAccountCitizenIdentificationCard1]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014174256_[UpdateAccountCitizenIdentificationCard2]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014174556_[UpdateBankInformation]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014183039_[UpdateContractForeignKey]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014184956_[AddContractTemplate]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014185207_[AddWishlistTable]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014191138_[UpdateContractTable]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014203519_[categorynameunique]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241017193922_[UpdateBankingInformatinTable]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241017194342_[UpdateContractTable1]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241017213102_[UpdateOrderTable1]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241021073214_[uodateDeliver]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241024000020_[updatePolicies]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241025192050_[update2610]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241026115754_addnew', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241026162532_updatecategory', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241026162806_updatebool', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241026170421_[update-account-bank]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241028100849_[deleteVoucherIdInSupplier]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241028103425_[updateDB]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241028193804_[update-agianvourcher]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241104100256_[update_tableTransaction]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241108122204_[updateContract]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241108123932_[update-Database]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241108130947_[updateContract]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241109094701_[UpdateTableContract]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241114153224_[update-contract-iteam]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241114153259_[updateDeliverMethod]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241114161332_[update-order-deposit]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241114162050_[update-product-deposit]', N'8.0.8')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'086b7a13-79af-4610-851d-204d9d84b865', N'STAFF', N'staff', N'086b7a13-79af-4610-851d-204d9d84b865')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1cf2de31-b0d8-4447-8f2f-c41df905a3a5', N'ADMIN', N'admin', N'1cf2de31-b0d8-4447-8f2f-c41df905a3a5')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'74bd6d3a-1119-449b-9743-3956d74e7575', N'SUPPLIER', N'supplier', N'74bd6d3a-1119-449b-9743-3956d74e7575')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9', N'MEMBER', N'member', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3f720222-e872-40f7-b578-57413e13955e', N'086b7a13-79af-4610-851d-204d9d84b865')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'812cc63a-465b-43f5-a7cd-cc3dc893b45e', N'086b7a13-79af-4610-851d-204d9d84b865')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd8c5456e-df60-4c62-8bf5-0cc4b14f0d86', N'086b7a13-79af-4610-851d-204d9d84b865')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d', N'1cf2de31-b0d8-4447-8f2f-c41df905a3a5')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'43cc4051-949e-4c52-bec6-bda4bba42b75', N'1cf2de31-b0d8-4447-8f2f-c41df905a3a5')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5aa7ee73-acf3-4110-8f5f-b296738b102e', N'74bd6d3a-1119-449b-9743-3956d74e7575')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5dc31c52-da51-46cf-87a1-7dbd4c9887ae', N'74bd6d3a-1119-449b-9743-3956d74e7575')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8be335d3-1fd1-4cc6-8835-138dbee72ef5', N'74bd6d3a-1119-449b-9743-3956d74e7575')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'10974a6b-e639-4d24-b073-970321bb21ea', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9741b37d-e075-4e13-800b-2bc792d79ced', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a495f2bd-28c0-4da5-87e7-9f25d8382e7f', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ed7ecc98-e26e-46bc-864b-4eb742ed300e', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0bab8444-ad59-4fe8-b1a4-559bc34275b0', 0, N'01447856963', N'An', N'An', 1, NULL, 0, 0, 1, NULL, NULL, N'cf3VebDG7vQjwZ7HbKiMewwAjOVQLmUv8tkNUg9YwmVxxRZI07v1ItbGS5NtQqWysco+NoWUbDgNgIydShF/gg==', CAST(N'2024-10-19T00:00:00.0000000' AS DateTime2), N'F5B5F748-898E-4A91-AC47-08DCE8900678', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'supplier1@gmail.com', N'SUPPLIER1@GMAIL.COM', N'supplier1@gmail.com', N'SUPPLIER1@GMAIL.COM', N'AQAAAAIAAYagAAAAECJ1Ji9P04cJ3ftpVnynDXo51iFpbEPJ1j8r+gWysyWoTWsC0iC0r+bukD+HKYxUjg==', N'QBDEMHUSDRAECOUN5JMEESBAA3XBXX6U', N'0a4774cf-dd7c-4de3-b5b9-24e3f4016431', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'10974a6b-e639-4d24-b073-970321bb21ea', 1, N'0865479566', N'Thái Duy', N'Phạm', NULL, NULL, 0, 0, 1, NULL, NULL, N'h49F/m10zjoxyfYIjh5W5AOECv2aFQgU9ITI2wsYZSDm3F/+a2eLDjiW2zhVKZLgGl8xt117SRHgVVu3G0ZWhQ==', CAST(N'2024-11-13T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2Ffd917c5b-f302-474d-adc1-53f9788d62e6_front.jpg.png?alt=media&token=b0645fce-ed6a-4c02-8f0a-986f9603d793', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F16c8b465-4b49-4f35-994a-89281e7ea562_back.jpg.png?alt=media&token=90e26b37-4f62-4d4c-95a2-9b54c01d517e', N'Agribank', N'074896123877', N'PHAM THAI DUY', N'duyptse161913@fpt.edu.vn', N'DUYPTSE161913@FPT.EDU.VN', N'duyptse161913@fpt.edu.vn', N'DUYPTSE161913@FPT.EDU.VN', N'AQAAAAIAAYagAAAAEKHeJw86ZxANfxcqSze+FyEkMTxPsly8Pwz5arB9mkD7xX0JnU9i4eOQZkpDmJh+zg==', N'3NMZQGFA5C2T6TG6K3FEU3HMGFZA7OSG', N'f66c1e46-874b-4f1b-be65-b571a81062cb', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2763dcc8-0b30-4c4a-b088-f7ee028b6443', 0, N'0862448677', N'Duy', N'Phạm Nhật', 0, NULL, 0, 0, 0, NULL, N'ac2418', NULL, NULL, NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/cards%2F029681a6-86cf-4168-b1be-14ffe791b9c5_front.jpg.png?alt=media&token=0799b0a6-a25d-45d4-9292-9f84a97f86d0', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/cards%2F1d467e5b-8f34-453c-ab89-b080f97271b9_back.jpg.png?alt=media&token=992267b1-5094-47c1-8d3c-7e4b21425ce8', NULL, NULL, NULL, N'duypnse173520@fpt.edu.vn', N'DUYPNSE173520@FPT.EDU.VN', N'duypnse173520@fpt.edu.vn', N'DUYPNSE173520@FPT.EDU.VN', N'AQAAAAIAAYagAAAAEA0PDcnOc+Vbl4T2SQzxvezeS32D+vXuPKWMrDTf01hJatrudcJPeKboHf6Q/+l7tA==', N'33ASIQHUMGOZE7EPF7T64KFYNY2XCQKA', N'21bc6143-0596-4328-8c36-a1402d2ffd05', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d', 1, N'0817363768', N'Dương', N'An', 2, NULL, 0, 0, 1, NULL, NULL, N'6xzwC9BhCqROB61p/VSseY8Xf+kAdkLF0oewnVgzx83jk5CRgzYYpwHqIUl7Q+Ib8wvypfuggulKuhHCQXf79A==', CAST(N'2024-11-15T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, N'TPBANK', N'0999447788', N'Duong Binh An', N'andbse161205@fpt.edu.vn', N'ANDBSE161205@FPT.EDU.VN', N'andbse161205@fpt.edu.vn', N'ANDBSE161205@FPT.EDU.VN', N'AQAAAAIAAYagAAAAEAiGgaTeN1Pard3vBXzBQb9+okXC3eWP352mc/IJ/88PLkA2on7wXiZD0c7z/CzZMw==', N'ZVCENTNELDO3EXYRJRMXD6IUGIDCJLIV', N'b8f3c4ac-9c0d-48c6-acae-a0bfcffe1b8d', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2eedc0f8-4273-44ed-aaf5-2987e3563f86', 0, N'0944557777', N'test1', N'test2', NULL, NULL, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/staff%2F2eedc0f8-4273-44ed-aaf5-2987e3563f86.png?alt=media&token=47d1da7a-0362-4c6b-8b83-c8bdf914165c', NULL, NULL, NULL, NULL, NULL, N'rcjajwv415@tmail9.com', N'RCJAJWV415@TMAIL9.COM', N'rcjajwv415@tmail9.com', N'RCJAJWV415@TMAIL9.COM', N'AQAAAAIAAYagAAAAEGDl7HP1oWwH/vBhdlgzqX7hsr0icgNRJUVPneTtJgREV5/F11l8NqrMZQ94hLbkqA==', N'7NFSADS5CCJP6KJJ7ADEYQ62DC2YVXAP', N'4ae1746d-7145-40d5-b79c-76ec2bd169cc', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3d2ca765-ab6d-4772-8a7c-32aa8c7ed4d0', 0, N'1234567890', N'John', N'Doe', 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'abc@gmail.com', N'ABC@GMAIL.COM', N'abc@gmail.com', N'ABC@GMAIL.COM', N'AQAAAAIAAYagAAAAEDz0s2qqnsNlZcfQ9cvY57ZlusxYIdjFv1D+iRTvyqhEPJlguv+TIDTaHqCjs6O8Zg==', N'XTDXZBEKRXSQ2GAKWXEL7U34DTGUVT6M', N'2132bb20-df44-447c-9fa6-ee4a8ccc8186', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3f720222-e872-40f7-b578-57413e13955e', 1, N'0901234568', N'Lê', N'Thị Kim Anh', NULL, NULL, 0, 0, 1, NULL, N'', N'ufkiCAjhtVnJUzXHBvt8zHdh4D/zLeeBGzjLNU0Hyvr5cUfYLgomEtJJ0GLvFeKKOWy+T/3iMXYg70MpyM124Q==', CAST(N'2024-11-02T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'lethikimanh@gmail.com', N'LETHIKIMANH@GMAIL.COM', N'lethikimanh@gmail.com', N'LETHIKIMANH@GMAIL.COM', N'AQAAAAIAAYagAAAAEOazn8gTMpIRPWhA2kEs4NyQulNYOCxoCiNsA67hdbPT+cvxzSlNDkP+QbcxwPWilw==', N'3JLXRDO7NNDZJ6ZZIXHSLEMFQAZL453J', N'0b19e780-ee14-408c-bc92-80bd77054474', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'43cc4051-949e-4c52-bec6-bda4bba42b75', 1, N'0901234565', N'Đinh', N'Hoài Linh', NULL, NULL, 0, 0, 1, NULL, NULL, N'U8i44qowejOV7SryRHQQxExdvQemR63JMbyo9xy6Z0W+SRJEzi9wo/DvNAx7aZwEo4IC+XryUoo+QAKTV7YIxQ==', CAST(N'2024-11-02T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'dinhhoailinh@gmail.com', N'DINHHOAILINH@GMAIL.COM', N'dinhhoailinh@gmail.com', N'DINHHOAILINH@GMAIL.COM', N'AQAAAAIAAYagAAAAEBM94Wv9+CHuWBytY9TOELYkRAaWnow+ISHBLl2Ngj5bDNLwOLHQdKCiNKBwm8feqw==', N'2FNARJ34AANKJ2PF5NMJ4YTDOUURDEA6', N'ca4517f5-f4bc-4ec8-b2fc-3a4915b4d71a', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4ca7c186-8c45-4d88-a3e0-865ce8e7e653', 1, N'0901234567', N'Đỗ', N'Đức Mạnh', NULL, NULL, 1, 0, 1, NULL, N'218a84', N'CoVfIZntgYIsZPB6kXIH91i71ACy0HyDyyQQjUW7royUgd4VEi0x5vRvBrjCDGQtNVdlrA0LVFj2z9xGSFmnHDg==', CAST(N'2024-10-19T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'doducmanh@gmail.com', N'DODUCMANH@GMAIL.COM', N'doducmanh@gmail.com', N'DODUCMANH@GMAIL.COM', N'AQAAAAIAAYagAAAAEAYFe+aN4yyPNdDlG+FhjZzqa3RDwUTLL7VtPYynFsZUmCmlPz7ZRMX27YHP3/9e9g==', N'SH3EWSUP2Z7ZOFGQRXWQEZSRU52KRLVK', N'12e78545-73d8-41ab-bb76-7e50ef8b7af9', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5aa7ee73-acf3-4110-8f5f-b296738b102e', 1, N'0977445511', N'Nikon', N'VietNam', 2, 2, 1, 0, 1, NULL, NULL, N'SzW10RpigUDqbI93A9M+z+e5aJAaaXU5CjUIzp0G4QMvZzCXp0PO/gn+RPW6GZY4vI6b2+qwcnP+VQimqsEtlg==', CAST(N'2024-11-16T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F5aa7ee73-acf3-4110-8f5f-b296738b102e.jpg.png?alt=media&token=b2a31793-979f-40c3-b040-79d894515262', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F5aa7ee73-acf3-4110-8f5f-b296738b102e.jpg.png?alt=media&token=84ef6a67-c30c-4b2f-8681-f476e85fbc92', N'Ngân hàng TMCP Công thương Việt Nam', N'0914758856', N'Nguyen Van A', N'nguyenvana@gmail.com', N'NGUYENVANA@GMAIL.COM', N'nguyenvana@gmail.com', N'NGUYENVANA@GMAIL.COM', N'AQAAAAIAAYagAAAAEMS8jV6m1b4U0hN5lWuyH4NF8WpAW5VSvEZdiiHpSVs/TZaig5zyL9YlapmF3E2FyA==', N'24VLUS2XUKJE5OAZOLMUZOSZZAECNKI2', N'c6675108-c3f4-48b8-98a8-c63ef8a5a3f5', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5dc31c52-da51-46cf-87a1-7dbd4c9887ae', 1, N'07864842', N'lbacojq', N'Doris', NULL, NULL, 0, 0, 1, NULL, NULL, N'gUr20QBuWvyc1IYbreYNhSaLjhb9tyB4PKopQnWn0Wz17xXc7OlxBWLOG+sBAYezyJcjWXx9RkYIta9oB/Q4FQ==', CAST(N'2024-11-02T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2Fbada24a5-dd25-4a2a-af6a-2698751f6126_front.jpg.png?alt=media&token=b2e23f01-af8a-4596-afb2-73e78e97c2d0', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F06b4b5a4-623d-4625-867b-2b640f7b4b42_back.jpg.png?alt=media&token=e4d819df-88c1-4597-abf6-111323e2332e', N'Ngân hàng TMCP Phương Đông', N'0914758856', N'Nguyen Van A', N'lbacojq091@tmail3.com', N'LBACOJQ091@TMAIL3.COM', N'lbacojq091@tmail3.com', N'LBACOJQ091@TMAIL3.COM', N'AQAAAAIAAYagAAAAEJnZ2aBMXftpXaiYaMUCXz3KklZSBh25N/MKpLKswwypAK91bk4zdg49JucPZjUuxg==', N'C4HWE22NWYGIC7RWRCRMK5HNAT2HNR3P', N'cc4ebd0e-370e-4d5e-906a-f08caead4868', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'812cc63a-465b-43f5-a7cd-cc3dc893b45e', 0, N'0944557741', N'Staff1', N' new', NULL, NULL, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/staff%2F812cc63a-465b-43f5-a7cd-cc3dc893b45e.png?alt=media&token=0060a735-ae14-4ca7-88ea-6614724aa6b6', NULL, NULL, NULL, NULL, NULL, N'xorak17929@aqqor.com', N'XORAK17929@AQQOR.COM', N'xorak17929@aqqor.com', N'XORAK17929@AQQOR.COM', N'AQAAAAIAAYagAAAAEHLF0/RBv8HT2bqjPt9vVdcHkw3kPrEWdlTVTYu6jBGU/l24UKYBTIkZD3mXGNl98g==', N'6675HO7CS5SLJMMR3J6U6VMO3AHEPJ6A', N'f21cebd9-1c86-4c5b-8df2-efe5128f7077', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8b6c5937-00ed-4d95-96d3-1d83c0599dc8', 0, N'0999999999', N'Perdita', N'Googe', NULL, NULL, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/staff%2F8b6c5937-00ed-4d95-96d3-1d83c0599dc8.png?alt=media&token=f2b2edf3-f8c4-4619-8d10-5c1f3f298586', NULL, NULL, NULL, NULL, NULL, N'teledon801@aleitar.com', N'TELEDON801@ALEITAR.COM', N'teledon801@aleitar.com', N'TELEDON801@ALEITAR.COM', N'AQAAAAIAAYagAAAAEAOubtxEZKH+hM5adye+/L9IsMOdQP9m0laRyf1itxM3Ca7/cp1cNeljnIs8SGU2YQ==', N'YZ5KT6TF2BSH45J7AAXHS2FROCPO5S3U', N'44781689-b9c2-415c-8dc0-3b3a97698f07', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8be335d3-1fd1-4cc6-8835-138dbee72ef5', 1, N'085745557799', N'Canon', N'VietNam', NULL, NULL, 0, 0, 1, NULL, NULL, N'v7bRufAg8s6mqzrstk+weViDiIK7VlMof9PvSCrsZtC4xy5cMOHEk9f5CFmAb+cUvEieDcoTi4lVtHjQE7iMcg==', CAST(N'2024-10-30T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2Ffb5424be-80cc-4ffe-9230-99b337c7564c_front.jpg.png?alt=media&token=8cc3c710-c742-4fb0-b623-30df1d7ef3fd', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2Ff3c7a90a-468d-4014-b7c9-55ba478e75e2_back.jpg.png?alt=media&token=674ff88d-2c36-4fbd-bff9-015a8af7669e', N'Ngân hàng TMCP Phương Đông', N'0914758856', N'N8574555779B', N'nguyenvanb@gmail.com', N'NGUYENVANB@GMAIL.COM', N'nguyenvanb@gmail.com', N'NGUYENVANB@GMAIL.COM', N'AQAAAAIAAYagAAAAEPaYLtCeXVls8jDQjNaQX6P+4U8oU4LyTx3UEUbwJtWIlBxMSusv8sk5rK33PhH0CA==', N'P345SJO5R4ZIILRAMRSHEDERD2ZCCF62', N'98788936-9fa0-4167-902b-17578596d1c7', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'94e03446-55bb-4774-8335-edd00fcb3d02', 0, N'0901234569', N'Nguyễn', N'Tiến Đạt', NULL, NULL, 0, 0, 0, NULL, NULL, N'vC0I2+M7XXGZkH38ACwLgl40WGeSPT3cF8D7eVvZ1V52EwFRXVP6DcuRW6OM4k7Gk5SKX8rZAC+An2qCkh04og==', CAST(N'2024-10-19T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'ntdat117@gmail.com', N'NTDAT117@GMAIL.COM', N'ntdat117@gmail.com', N'NTDAT117@GMAIL.COM', N'AQAAAAIAAYagAAAAEJ6g+szEZp73wf9Z8O3lA7n5ydD7kPRD1P9qTDl3ZKkShG9oNeZkjH6SPN9kFY/mS4A==', N'X7SQCPAGFEMGUMPK4JW4YYBWZZYAYX2X', N'b10a3b18-5860-43a9-baba-efb4f41b7d03', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9741b37d-e075-4e13-800b-2bc792d79ced', 0, N'', N'Do Thi Kim Hau (K16 HCM)', N'', NULL, NULL, 0, 0, 1, NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'haudtkse161983@fpt.edu.vn', N'HAUDTKSE161983@FPT.EDU.VN', N'haudtkse161983@fpt.edu.vn', N'HAUDTKSE161983@FPT.EDU.VN', N'AQAAAAIAAYagAAAAED7BRM9QOqPckPiiJWl0XBwtycy1Ly1UYjyC7KyWgLSWc+iLdVGzOEUjDpwMhybpPQ==', N'COCZFZBNDAVDMC462VIGKAJH5JNLJ7EN', N'731ba6d7-c2a9-4615-90e2-b083649ab898', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a495f2bd-28c0-4da5-87e7-9f25d8382e7f', 0, N'0874596698', N'Di', N'Di', NULL, NULL, 0, 0, 0, NULL, N'f6f335', NULL, NULL, NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F1b17a12b-96ca-43f2-8bbb-b7147732c387_front.jpg.png?alt=media&token=847ee0ca-ccbf-4b73-804f-a697b8ccd8ab', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F6822e378-67db-4bea-a1f9-7f39068bb039_back.jpg.png?alt=media&token=69065318-b411-4682-89ff-f92a6cd0e0ae', N'Agribank', N'0765489123477', N'PHAM THAI DUY', N'ginaled724@cironex.com', N'GINALED724@CIRONEX.COM', N'ginaled724@cironex.com', N'GINALED724@CIRONEX.COM', N'AQAAAAIAAYagAAAAEIJu6mXnxBPZeIq1i8kA/EPKzZ5BHNVtl+CR+UiAVr2DRqs8ml2zgNc8lGQRR7OoaA==', N'G3SSK2CGGLBX72D5FZOQMT4BFPCH2MBH', N'42d55627-3299-4602-aa84-c0e16f44d6c1', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ae32e359-256b-4609-9da7-c45a7327c5c9', 0, N'1', N'An', N'An', NULL, NULL, 0, 0, 0, NULL, N'83e537', NULL, NULL, NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F2ca421e6-2730-4493-8759-5ab9065fffee_front.jpg.png?alt=media&token=a7883985-6e81-48be-a5d3-b4a10f1b475e', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2Fcf5cd11e-57bf-4ca4-bd2b-ffb3ffb5981d_back.jpg.png?alt=media&token=b89fea79-7f65-48fc-95bf-a93d6c4cf78a', N'1', N'1', N'1', N'abcd@gmail.com', N'ABCD@GMAIL.COM', N'abcd@gmail.com', N'ABCD@GMAIL.COM', N'AQAAAAIAAYagAAAAEMz/pY/dKxtvHeN4lNLjnaZiyFGGstoMNZ+UqchAUgBz7EyBlNIsYXNnYxU+bEwiIg==', N'JMETVGLIYVH5I62PJRZ3Z7US6YPEYJR6', N'c2227557-b3e0-4a1a-aff0-2b1853a7c408', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd8c5456e-df60-4c62-8bf5-0cc4b14f0d86', 0, N'0862778644', N'a', N'aaaaaaa', NULL, NULL, 0, 0, 1, NULL, NULL, N'XJF2u8g2SfW5YRNamlZOC7xZh84RRxWxcty0aAD3AQr22Jl7wM++ibvBUD5qZsKwe61Od6D6sH0CrWncZZnN1Q==', CAST(N'2024-11-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/staff%2Fd8c5456e-df60-4c62-8bf5-0cc4b14f0d86.png?alt=media&token=5e992c70-bdd9-44e6-afc7-55b325b26bb4', NULL, NULL, NULL, NULL, NULL, N'fayapo4374@regishub.com', N'FAYAPO4374@REGISHUB.COM', N'fayapo4374@regishub.com', N'FAYAPO4374@REGISHUB.COM', N'AQAAAAIAAYagAAAAEBQDcnXreg34vbkoC6cC+1j7tsEfDI1tsWbnjiWzGwexkxDKaOmDayKx+n7HJnbkpw==', N'NXTXLWIGLZQS454JLAWDRXMSC7QQJOVR', N'625ee707-eb13-4002-bd2f-25fc8a119893', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ed7ecc98-e26e-46bc-864b-4eb742ed300e', 0, N'', N'Anh Vương Thiên', N'', NULL, NULL, 0, 0, 1, NULL, N'', N'hHlcjyjF9tyHYQCUby+qi3UHtI24d3QTCmNcd8YmDiO4r606+wLcgGSf5iA5MxBXxm1PFP5KkwW1f/92fJqtqA==', CAST(N'2024-11-16T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'binhanduong1703@gmail.com', N'BINHANDUONG1703@GMAIL.COM', N'binhanduong1703@gmail.com', N'BINHANDUONG1703@GMAIL.COM', N'AQAAAAIAAYagAAAAEIVL2AqTqnqgwHv+JxuYUmlebLyOQQEh7bGioke08M/uLHsSoVgmwLfjzIX0rKPpbg==', N'PNQVR3OQ2KRTUMOGKC3AHGPPYVUIZ2NH', N'39452d02-b4e1-49ae-9ffa-d2512fa030c5', 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [StatusCategory]) VALUES (N'3ed49ca1-fc18-4d3c-ac86-0b04f1d57f35', N'Ống kính máy ảnh', N'Nhiều loại ống kính cho các phong cách chụp ảnh khác nhau, từ chân dung đến phong cảnh.', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [StatusCategory]) VALUES (N'f300bbc9-9960-4543-8b91-0caf450a8e43', N'Máy quay hành động', N'Máy quay bền bỉ, chống nước dành cho việc quay các môn thể thao mạo hiểm và phiêu lưu.', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [StatusCategory]) VALUES (N'81c021f2-8301-42f7-a4ba-3ce6492d2367', N'Phụ kiện máy ảnh', N'Chân máy, túi và các phụ kiện khác hỗ trợ cho việc sử dụng và bảo dưỡng máy ảnh.', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [StatusCategory]) VALUES (N'e9819628-bdf7-4883-ae21-4b83fd1a5193', N'Máy ảnh không gương lật', N'Máy ảnh không gương lật nhỏ gọn và nhẹ, cho hình ảnh có độ phân giải cao.', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [StatusCategory]) VALUES (N'649ede6e-0b8d-40d9-8d72-60f0c84fa9a1', N'Drone camera', N'Drone tích hợp camera HD cho nhiếp ảnh và quay video từ trên không.', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [StatusCategory]) VALUES (N'65d75b62-2173-4167-b289-9568167dbe54', N'Máy ảnh in liền', N'Máy ảnh in ảnh ngay lập tức, phổ biến cho chụp ảnh vui nhộn và bình thường.', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [StatusCategory]) VALUES (N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Máy ảnh DSLR', N'Máy ảnh DSLR chuyên nghiệp với ống kính thay đổi được, phù hợp cho nhiếp ảnh nâng cao.', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [StatusCategory]) VALUES (N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Máy ảnh kỹ thuật số', N'Máy ảnh kỹ thuật số chất lượng cao để chụp ảnh và quay video.', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [StatusCategory]) VALUES (N'7c1a857d-6b49-4553-98ba-e1f46a142324', N'Thẻ nhớ máy ảnh', N'Giải pháp lưu trữ cho máy ảnh, bao gồm thẻ SD và microSD với dung lượng cao.', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [StatusCategory]) VALUES (N'76e15479-4217-4436-b250-ef3027f1768e', N'Camera an ninh', N'Camera giám sát cho mục đích an ninh gia đình và doanh nghiệp.', 1)
GO
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'0540875c-7e4b-47d9-908c-08dd06ffca95', N'93b19815-fe23-49bb-8a01-675e606d1016', N'a8ff0e7f-ef7c-4373-0137-08dd033c8059', CAST(N'2024-11-17T12:23:09.4684397' AS DateTime2), CAST(N'2024-11-17T12:23:09.4684398' AS DateTime2), N'string', N'string', N'string')
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'073e1655-b31f-456a-908d-08dd06ffca95', N'93b19815-fe23-49bb-8a01-675e606d1016', N'6dc96be6-62fb-4c5b-6d59-08dd0404aaae', CAST(N'2024-11-17T12:23:09.4687177' AS DateTime2), CAST(N'2024-11-17T12:23:09.4687177' AS DateTime2), N'Thời gian thuê máy ảnh được quy định rõ ràng và cam kết trả đúng hạn.', N'Phạt 5% giá trị hợp đồng mỗi giờ trả muộn.', N'Thời gian thuê bắt đầu từ thời điểm nhận máy đến thời điểm trả máy đã thỏa thuận trước. Bên thuê chịu trách nhiệm trả máy đúng hạn, nếu không sẽ bị xử phạt theo quy định.')
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'22eeff36-fe7c-42b4-908e-08dd06ffca95', N'93b19815-fe23-49bb-8a01-675e606d1016', N'5e1ffd65-a604-4328-6d5a-08dd0404aaae', CAST(N'2024-11-17T12:23:09.4687655' AS DateTime2), CAST(N'2024-11-17T12:23:09.4687655' AS DateTime2), N'Bên thuê có trách nhiệm bảo quản máy ảnh trong suốt thời gian thuê.', N'Nếu máy ảnh bị hỏng, bên thuê phải chịu chi phí sửa chữa hoặc bồi thường theo giá trị thiết bị.', N'Trong suốt thời gian thuê, bên thuê phải bảo quản thiết bị tránh các tác động vật lý, nước, và các yếu tố gây hư hại khác.')
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'7d41e49e-49f5-4481-908f-08dd06ffca95', N'93b19815-fe23-49bb-8a01-675e606d1016', N'c0f285af-41cd-4647-6d5b-08dd0404aaae', CAST(N'2024-11-17T12:23:09.4688213' AS DateTime2), CAST(N'2024-11-17T12:23:09.4688213' AS DateTime2), N'Thiết bị chỉ được sử dụng cho mục đích ghi hình và không được sử dụng vào các mục đích khác ngoài hợp đồng.', N'Nếu bên thuê sử dụng không đúng mục đích, sẽ bị phạt 15% giá trị hợp đồng.', N'Bên thuê cam kết chỉ sử dụng thiết bị cho các mục đích ghi hình, không cho bên thứ ba thuê lại hoặc sử dụng vào mục đích trái phép.')
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'57930b7c-ebf0-44a3-9090-08dd06ffca95', N'93b19815-fe23-49bb-8a01-675e606d1016', N'a9aed02c-c76b-43fa-6d5c-08dd0404aaae', CAST(N'2024-11-17T12:23:09.4688677' AS DateTime2), CAST(N'2024-11-17T12:23:09.4688677' AS DateTime2), N'Bên thuê có thể hủy hợp đồng trước thời hạn nhưng phải báo trước ít nhất 24 giờ.', N'Phí hủy hợp đồng là 10% giá trị thuê nếu không báo trước 24 giờ.', N'Nếu bên thuê hủy hợp đồng mà không báo trước hoặc báo quá trễ, sẽ phải chịu phí bồi thường theo quy định.')
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'1db760fa-4963-4ad6-9091-08dd06ffca95', N'93b19815-fe23-49bb-8a01-675e606d1016', N'907734ce-b948-4d9e-6d5d-08dd0404aaae', CAST(N'2024-11-17T12:23:09.4689062' AS DateTime2), CAST(N'2024-11-17T12:23:09.4689062' AS DateTime2), N'Bên cho thuê cam kết bảo hành thiết bị trong điều kiện bình thường.', N'Không áp dụng phạt đối với các lỗi kỹ thuật từ phía bên cho thuê.', N'Trong trường hợp thiết bị gặp lỗi do bên cho thuê, sẽ có chính sách hỗ trợ đổi máy hoặc sửa chữa.')
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'fce07bab-1330-4cd8-a9d8-08dd0720dac9', N'e247118d-cbe4-44c0-afc3-a54582173597', N'e3fc43aa-61c3-4034-b4b4-08dcf9eea55a', CAST(N'2024-11-17T15:59:44.7449777' AS DateTime2), CAST(N'2024-11-17T15:59:44.7450280' AS DateTime2), N'Thuê theo ngày với thời gian tối thiểu 1 ngày và tối đa 3 ngày.', N'Phạt 15% giá thuê nếu trả quá hạn, tối đa 1 ngày thêm.', N'Dịch vụ thuê theo ngày. Khách hàng có trách nhiệm hoàn trả dịch vụ đúng thời hạn.')
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'1ff3e674-cfcb-4e5c-a9d9-08dd0720dac9', N'e247118d-cbe4-44c0-afc3-a54582173597', N'f48a60f9-f11f-4e94-b4b5-08dcf9eea55a', CAST(N'2024-11-17T15:59:44.7569623' AS DateTime2), CAST(N'2024-11-17T15:59:44.7569623' AS DateTime2), N'Thuê theo tuần với thời gian tối thiểu 1 tuần và tối đa 2 tuần.', N'Phạt 20% giá thuê nếu không trả đúng hạn, tối đa 1 tuần thêm.', N'Dịch vụ thuê theo tuần. Khách hàng chịu trách nhiệm bảo quản tài sản trong thời gian thuê.')
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'77357d09-2a39-4569-a9da-08dd0720dac9', N'e247118d-cbe4-44c0-afc3-a54582173597', N'cbf2ab52-1aa4-4a80-b4b6-08dcf9eea55a', CAST(N'2024-11-17T15:59:44.7574911' AS DateTime2), CAST(N'2024-11-17T15:59:44.7574912' AS DateTime2), N'Thuê theo tháng, áp dụng thuê tối đa 1 tháng.', N'Phạt 25% giá thuê nếu vi phạm thời hạn trả hợp đồng.', N'Dịch vụ thuê theo tháng với chi phí cố định. Khách hàng phải đảm bảo dịch vụ không bị gián đoạn.')
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'087418c0-7a6f-4707-a9db-08dd0720dac9', N'e247118d-cbe4-44c0-afc3-a54582173597', N'd3888a13-8a77-41c6-6d58-08dd0404aaae', CAST(N'2024-11-17T15:59:44.7575408' AS DateTime2), CAST(N'2024-11-17T15:59:44.7575409' AS DateTime2), N'Thuê theo giờ với tối thiểu 2 giờ và tối đa 4 giờ.', N'Phạt 10% giá thuê nếu trả quá giờ đã ký. Thời gian quá giờ tối đa 1 giờ.', N'Dịch vụ cho thuê theo giờ. Mức giá cố định mỗi giờ. Khách hàng phải tuân thủ thời gian đã ký kết.')
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'9b6d1594-3dc2-4e78-a9dc-08dd0720dac9', N'e247118d-cbe4-44c0-afc3-a54582173597', N'8ff59c67-9d03-43b5-6d66-08dd0404aaae', CAST(N'2024-11-17T15:59:44.7576170' AS DateTime2), CAST(N'2024-11-17T15:59:44.7576171' AS DateTime2), N'Thiết bị chỉ được sử dụng trong phạm vi địa lý đã thỏa thuận.', N'Vi phạm phạm vi sử dụng sẽ bị phạt 20% giá trị hợp đồng.', N'Bên thuê không được mang thiết bị ra khỏi phạm vi đã thỏa thuận mà không được sự đồng ý của bên cho thuê.')
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'03a6fad4-1ef1-4666-a9dd-08dd0720dac9', N'e247118d-cbe4-44c0-afc3-a54582173597', N'4886d18e-3009-4bbd-6d67-08dd0404aaae', CAST(N'2024-11-17T15:59:44.7576506' AS DateTime2), CAST(N'2024-11-17T15:59:44.7576507' AS DateTime2), N'Bên thuê cam kết không vi phạm bản quyền khi sử dụng thiết bị.', N'Nếu có khiếu nại về bản quyền, bên thuê chịu trách nhiệm pháp lý hoàn toàn.', N'Mọi nội dung ghi hình phải tuân thủ luật pháp về bản quyền. Bên thuê chịu trách nhiệm trước pháp luật nếu vi phạm.')
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'04a5e124-85e1-4a30-a9de-08dd0720dac9', N'e247118d-cbe4-44c0-afc3-a54582173597', N'671b8b9a-c999-463a-6d68-08dd0404aaae', CAST(N'2024-11-17T15:59:44.7576805' AS DateTime2), CAST(N'2024-11-17T15:59:44.7576806' AS DateTime2), N'Bên thuê có trách nhiệm kiểm tra thiết bị trước khi nhận.', N'Nếu bên thuê không kiểm tra và ký xác nhận, mọi hỏng hóc sau đó sẽ chịu trách nhiệm.', N'Trước khi bàn giao, bên thuê cần xác nhận tình trạng thiết bị và ký xác nhận. Nếu có hỏng hóc phải thông báo ngay để được hỗ trợ.')
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'b826980f-b637-40b0-a9df-08dd0720dac9', N'e247118d-cbe4-44c0-afc3-a54582173597', N'07f78532-1765-41df-6d69-08dd0404aaae', CAST(N'2024-11-17T15:59:44.7577100' AS DateTime2), CAST(N'2024-11-17T15:59:44.7577100' AS DateTime2), N'Bên thuê có thể hủy hợp đồng trước thời hạn nhưng phải báo trước ít nhất 24 giờ.', N'Phí hủy hợp đồng là 10% giá trị thuê nếu không báo trước 24 giờ.', N'Nếu bên thuê hủy hợp đồng mà không báo trước hoặc báo quá trễ, sẽ phải chịu phí bồi thường theo quy định.')
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'd2b63a77-38d7-43cb-a9e0-08dd0720dac9', N'e247118d-cbe4-44c0-afc3-a54582173597', N'1d059b7b-2a10-45a4-6d6a-08dd0404aaae', CAST(N'2024-11-17T15:59:44.7577494' AS DateTime2), CAST(N'2024-11-17T15:59:44.7577495' AS DateTime2), N'Quy định về thanh toán chi phí thuê và chính sách hoàn trả.', N'Nếu không thanh toán đúng hạn, hợp đồng sẽ bị hủy mà không hoàn lại tiền.', N'Bên thuê cần thanh toán đầy đủ trước khi nhận thiết bị. Nếu trả sớm hơn thời hạn, sẽ không được hoàn lại tiền.')
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'b7d0afc2-8bd9-49d6-a9e1-08dd0720dac9', N'e247118d-cbe4-44c0-afc3-a54582173597', N'88567edf-f8e7-4682-6d6b-08dd0404aaae', CAST(N'2024-11-17T15:59:44.7577798' AS DateTime2), CAST(N'2024-11-17T15:59:44.7577798' AS DateTime2), N'Thông tin cá nhân của khách hàng sẽ được bảo mật tuyệt đối.', N'Nếu bên cho thuê tiết lộ thông tin, sẽ chịu trách nhiệm theo pháp luật.', N'Bên cho thuê cam kết không tiết lộ bất kỳ thông tin cá nhân nào của khách hàng cho bên thứ ba nếu không có sự đồng ý.')
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [CreatedAt], [UpdatedAt], [ContractTerms], [PenaltyPolicy], [TemplateDetails]) VALUES (N'78853c52-3d83-4191-a9e2-08dd0720dac9', N'e247118d-cbe4-44c0-afc3-a54582173597', N'3cb0b5c7-1301-47df-6d6c-08dd0404aaae', CAST(N'2024-11-17T15:59:44.7578096' AS DateTime2), CAST(N'2024-11-17T15:59:44.7578096' AS DateTime2), N'Thiết bị sẽ được bảo dưỡng định kỳ trước khi cho thuê.', N'Nếu thiết bị gặp lỗi do không bảo dưỡng, bên cho thuê sẽ hỗ trợ thay thế không tính phí.', N'Bên cho thuê cam kết kiểm tra và bảo dưỡng thiết bị định kỳ, đảm bảo chất lượng sử dụng.')
GO
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'e3fc43aa-61c3-4034-b4b4-08dcf9eea55a', N'Hợp đồng thuê theo ngày', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'Thuê theo ngày với thời gian tối thiểu 1 ngày và tối đa 3 ngày.', N'Dịch vụ thuê theo ngày. Khách hàng có trách nhiệm hoàn trả dịch vụ đúng thời hạn.', N'Phạt 15% giá thuê nếu trả quá hạn, tối đa 1 ngày thêm.', CAST(N'2024-10-31T20:57:51.9157903' AS DateTime2), CAST(N'2024-11-13T22:09:59.4053807' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'f48a60f9-f11f-4e94-b4b5-08dcf9eea55a', N'Hợp đồng thuê theo tuần', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'Thuê theo tuần với thời gian tối thiểu 1 tuần và tối đa 2 tuần.', N'Dịch vụ thuê theo tuần. Khách hàng chịu trách nhiệm bảo quản tài sản trong thời gian thuê.', N'Phạt 20% giá thuê nếu không trả đúng hạn, tối đa 1 tuần thêm.', CAST(N'2024-10-31T20:58:07.1414038' AS DateTime2), CAST(N'2024-10-31T20:58:07.1414039' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'cbf2ab52-1aa4-4a80-b4b6-08dcf9eea55a', N'Hợp đồng thuê theo tháng', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'Thuê theo tháng, áp dụng thuê tối đa 1 tháng.', N'Dịch vụ thuê theo tháng với chi phí cố định. Khách hàng phải đảm bảo dịch vụ không bị gián đoạn.', N'Phạt 25% giá thuê nếu vi phạm thời hạn trả hợp đồng.', CAST(N'2024-10-31T20:58:23.5958551' AS DateTime2), CAST(N'2024-10-31T20:58:23.5958552' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'a8ff0e7f-ef7c-4373-0137-08dd033c8059', N'string', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'string', N'string', N'string', CAST(N'2024-11-12T17:07:34.2522181' AS DateTime2), CAST(N'2024-11-12T17:07:34.2522183' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'd3888a13-8a77-41c6-6d58-08dd0404aaae', N'Hợp đồng thuê theo giờ', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'Thuê theo giờ với tối thiểu 2 giờ và tối đa 4 giờ.', N'Dịch vụ cho thuê theo giờ. Mức giá cố định mỗi giờ. Khách hàng phải tuân thủ thời gian đã ký kết.', N'Phạt 10% giá thuê nếu trả quá giờ đã ký. Thời gian quá giờ tối đa 1 giờ.', CAST(N'2024-11-13T17:00:24.6225544' AS DateTime2), CAST(N'2024-11-13T17:00:57.9148890' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'6dc96be6-62fb-4c5b-6d59-08dd0404aaae', N'Thời hạn thuê', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'Thời gian thuê máy ảnh được quy định rõ ràng và cam kết trả đúng hạn.', N'Thời gian thuê bắt đầu từ thời điểm nhận máy đến thời điểm trả máy đã thỏa thuận trước. Bên thuê chịu trách nhiệm trả máy đúng hạn, nếu không sẽ bị xử phạt theo quy định.', N'Phạt 5% giá trị hợp đồng mỗi giờ trả muộn.', CAST(N'2024-11-13T17:10:40.7671456' AS DateTime2), CAST(N'2024-11-13T17:10:40.7671457' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'5e1ffd65-a604-4328-6d5a-08dd0404aaae', N'Trách nhiệm bảo quản', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'Bên thuê có trách nhiệm bảo quản máy ảnh trong suốt thời gian thuê.', N'Trong suốt thời gian thuê, bên thuê phải bảo quản thiết bị tránh các tác động vật lý, nước, và các yếu tố gây hư hại khác.', N'Nếu máy ảnh bị hỏng, bên thuê phải chịu chi phí sửa chữa hoặc bồi thường theo giá trị thiết bị.', CAST(N'2024-11-13T17:11:06.0876391' AS DateTime2), CAST(N'2024-11-13T17:11:06.0876392' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'c0f285af-41cd-4647-6d5b-08dd0404aaae', N'Sử dụng thiết bị đúng mục đích', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'Thiết bị chỉ được sử dụng cho mục đích ghi hình và không được sử dụng vào các mục đích khác ngoài hợp đồng.', N'Bên thuê cam kết chỉ sử dụng thiết bị cho các mục đích ghi hình, không cho bên thứ ba thuê lại hoặc sử dụng vào mục đích trái phép.', N'Nếu bên thuê sử dụng không đúng mục đích, sẽ bị phạt 15% giá trị hợp đồng.', CAST(N'2024-11-13T17:11:25.7020871' AS DateTime2), CAST(N'2024-11-13T17:11:25.7020872' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'a9aed02c-c76b-43fa-6d5c-08dd0404aaae', N'Quy định về hủy hợp đồng', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'Bên thuê có thể hủy hợp đồng trước thời hạn nhưng phải báo trước ít nhất 24 giờ.', N'Nếu bên thuê hủy hợp đồng mà không báo trước hoặc báo quá trễ, sẽ phải chịu phí bồi thường theo quy định.', N'Phí hủy hợp đồng là 10% giá trị thuê nếu không báo trước 24 giờ.', CAST(N'2024-11-13T17:11:42.6285804' AS DateTime2), CAST(N'2024-11-13T17:11:42.6285805' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'907734ce-b948-4d9e-6d5d-08dd0404aaae', N'Chính sách bảo hành và hỗ trợ', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'Bên cho thuê cam kết bảo hành thiết bị trong điều kiện bình thường.', N'Trong trường hợp thiết bị gặp lỗi do bên cho thuê, sẽ có chính sách hỗ trợ đổi máy hoặc sửa chữa.', N'Không áp dụng phạt đối với các lỗi kỹ thuật từ phía bên cho thuê.', CAST(N'2024-11-13T17:11:58.8696272' AS DateTime2), CAST(N'2024-11-13T17:11:58.8696273' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'a8880372-c947-42f4-6d5e-08dd0404aaae', N'Thời hạn thuê', N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', N'Thời gian thuê máy ảnh được quy định rõ ràng và cam kết trả đúng hạn.', N'Thời gian thuê bắt đầu từ thời điểm nhận máy đến thời điểm trả máy đã thỏa thuận trước. Bên thuê chịu trách nhiệm trả máy đúng hạn, nếu không sẽ bị xử phạt theo quy định.', N'Phạt 5% giá trị hợp đồng mỗi giờ trả muộn.', CAST(N'2024-11-13T17:13:54.3780495' AS DateTime2), CAST(N'2024-11-13T17:13:54.3780497' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'837cf325-f422-425a-6d5f-08dd0404aaae', N'Trách nhiệm bảo quản', N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', N'Bên thuê có trách nhiệm bảo quản máy ảnh trong suốt thời gian thuê.', N'Trong suốt thời gian thuê, bên thuê phải bảo quản thiết bị tránh các tác động vật lý, nước, và các yếu tố gây hư hại khác.', N'Nếu máy ảnh bị hỏng, bên thuê phải chịu chi phí sửa chữa hoặc bồi thường theo giá trị thiết bị.', CAST(N'2024-11-13T17:14:13.1042042' AS DateTime2), CAST(N'2024-11-13T17:14:13.1042044' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'9ee4e509-e561-4c1f-6d60-08dd0404aaae', N'Sử dụng thiết bị đúng mục đích', N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', N'Thiết bị chỉ được sử dụng cho mục đích ghi hình và không được sử dụng vào các mục đích khác ngoài hợp đồng.', N'Bên thuê cam kết chỉ sử dụng thiết bị cho các mục đích ghi hình, không cho bên thứ ba thuê lại hoặc sử dụng vào mục đích trái phép.', N'Nếu bên thuê sử dụng không đúng mục đích, sẽ bị phạt 15% giá trị hợp đồng.', CAST(N'2024-11-13T17:15:53.7144323' AS DateTime2), CAST(N'2024-11-13T17:15:53.7144324' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'03b8c248-af99-432d-6d61-08dd0404aaae', N'Quy định về hủy hợp đồng', N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', N'Bên thuê có thể hủy hợp đồng trước thời hạn nhưng phải báo trước ít nhất 24 giờ.', N'Nếu bên thuê hủy hợp đồng mà không báo trước hoặc báo quá trễ, sẽ phải chịu phí bồi thường theo quy định.', N'Phí hủy hợp đồng là 10% giá trị thuê nếu không báo trước 24 giờ.', CAST(N'2024-11-13T17:16:24.8363131' AS DateTime2), CAST(N'2024-11-13T17:16:24.8363132' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'b6abef87-4f19-47ef-6d62-08dd0404aaae', N'Chính sách bảo hành và hỗ trợ', N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', N'Bên cho thuê cam kết bảo hành thiết bị trong điều kiện bình thường.', N'Trong trường hợp thiết bị gặp lỗi do bên cho thuê, sẽ có chính sách hỗ trợ đổi máy hoặc sửa chữa.', N'Không áp dụng phạt đối với các lỗi kỹ thuật từ phía bên cho thuê.', CAST(N'2024-11-13T17:16:39.0036243' AS DateTime2), CAST(N'2024-11-13T17:16:39.0036244' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'147a2f36-19f0-48b0-6d63-08dd0404aaae', N'Quy định về kiểm tra và bàn giao thiết bị', N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', N'Bên thuê có trách nhiệm kiểm tra thiết bị trước khi nhận.', N'Trước khi bàn giao, bên thuê cần xác nhận tình trạng thiết bị và ký xác nhận. Nếu có hỏng hóc phải thông báo ngay để được hỗ trợ.', N'Nếu bên thuê không kiểm tra và ký xác nhận, mọi hỏng hóc sau đó sẽ chịu trách nhiệm.', CAST(N'2024-11-13T17:16:58.0041264' AS DateTime2), CAST(N'2024-11-13T17:16:58.0041266' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'eccd4962-38b7-4ed5-6d64-08dd0404aaae', N'Cam kết về bản quyền hình ảnh', N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', N'Bên thuê cam kết không vi phạm bản quyền khi sử dụng thiết bị.', N'Mọi nội dung ghi hình phải tuân thủ luật pháp về bản quyền. Bên thuê chịu trách nhiệm trước pháp luật nếu vi phạm.', N'Nếu có khiếu nại về bản quyền, bên thuê chịu trách nhiệm pháp lý hoàn toàn.', CAST(N'2024-11-13T17:17:11.5958353' AS DateTime2), CAST(N'2024-11-13T17:17:11.5958354' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'a78065bc-132a-47d3-6d65-08dd0404aaae', N'Quy định về sử dụng ngoài phạm vi', N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', N'Thiết bị chỉ được sử dụng trong phạm vi địa lý đã thỏa thuận.', N'Bên thuê không được mang thiết bị ra khỏi phạm vi đã thỏa thuận mà không được sự đồng ý của bên cho thuê.', N'Vi phạm phạm vi sử dụng sẽ bị phạt 20% giá trị hợp đồng.', CAST(N'2024-11-13T17:17:23.8217393' AS DateTime2), CAST(N'2024-11-13T17:17:23.8217395' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'8ff59c67-9d03-43b5-6d66-08dd0404aaae', N'Quy định về sử dụng ngoài phạm vi', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'Thiết bị chỉ được sử dụng trong phạm vi địa lý đã thỏa thuận.', N'Bên thuê không được mang thiết bị ra khỏi phạm vi đã thỏa thuận mà không được sự đồng ý của bên cho thuê.', N'Vi phạm phạm vi sử dụng sẽ bị phạt 20% giá trị hợp đồng.', CAST(N'2024-11-13T17:17:45.3795769' AS DateTime2), CAST(N'2024-11-13T17:17:45.3795770' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'4886d18e-3009-4bbd-6d67-08dd0404aaae', N'Cam kết về bản quyền hình ảnh', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'Bên thuê cam kết không vi phạm bản quyền khi sử dụng thiết bị.', N'Mọi nội dung ghi hình phải tuân thủ luật pháp về bản quyền. Bên thuê chịu trách nhiệm trước pháp luật nếu vi phạm.', N'Nếu có khiếu nại về bản quyền, bên thuê chịu trách nhiệm pháp lý hoàn toàn.', CAST(N'2024-11-13T17:17:53.4820029' AS DateTime2), CAST(N'2024-11-13T17:17:53.4820030' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'671b8b9a-c999-463a-6d68-08dd0404aaae', N'Quy định về kiểm tra và bàn giao thiết bị', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'Bên thuê có trách nhiệm kiểm tra thiết bị trước khi nhận.', N'Trước khi bàn giao, bên thuê cần xác nhận tình trạng thiết bị và ký xác nhận. Nếu có hỏng hóc phải thông báo ngay để được hỗ trợ.', N'Nếu bên thuê không kiểm tra và ký xác nhận, mọi hỏng hóc sau đó sẽ chịu trách nhiệm.', CAST(N'2024-11-13T17:18:04.0148101' AS DateTime2), CAST(N'2024-11-13T17:18:04.0148102' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'07f78532-1765-41df-6d69-08dd0404aaae', N'Quy định về hủy hợp đồng', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'Bên thuê có thể hủy hợp đồng trước thời hạn nhưng phải báo trước ít nhất 24 giờ.', N'Nếu bên thuê hủy hợp đồng mà không báo trước hoặc báo quá trễ, sẽ phải chịu phí bồi thường theo quy định.', N'Phí hủy hợp đồng là 10% giá trị thuê nếu không báo trước 24 giờ.', CAST(N'2024-11-13T17:18:19.0792256' AS DateTime2), CAST(N'2024-11-13T17:18:19.0792257' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'1d059b7b-2a10-45a4-6d6a-08dd0404aaae', N'Thanh toán và hoàn trả', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'Quy định về thanh toán chi phí thuê và chính sách hoàn trả.', N'Bên thuê cần thanh toán đầy đủ trước khi nhận thiết bị. Nếu trả sớm hơn thời hạn, sẽ không được hoàn lại tiền.', N'Nếu không thanh toán đúng hạn, hợp đồng sẽ bị hủy mà không hoàn lại tiền.', CAST(N'2024-11-13T17:18:36.5520229' AS DateTime2), CAST(N'2024-11-13T17:18:36.5520230' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'88567edf-f8e7-4682-6d6b-08dd0404aaae', N'Thỏa thuận về bảo mật thông tin', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'Thông tin cá nhân của khách hàng sẽ được bảo mật tuyệt đối.', N'Bên cho thuê cam kết không tiết lộ bất kỳ thông tin cá nhân nào của khách hàng cho bên thứ ba nếu không có sự đồng ý.', N'Nếu bên cho thuê tiết lộ thông tin, sẽ chịu trách nhiệm theo pháp luật.', CAST(N'2024-11-13T17:18:49.0013819' AS DateTime2), CAST(N'2024-11-13T17:18:49.0013820' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'3cb0b5c7-1301-47df-6d6c-08dd0404aaae', N'Cam kết về bảo dưỡng thiết bị', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'Thiết bị sẽ được bảo dưỡng định kỳ trước khi cho thuê.', N'Bên cho thuê cam kết kiểm tra và bảo dưỡng thiết bị định kỳ, đảm bảo chất lượng sử dụng.', N'Nếu thiết bị gặp lỗi do không bảo dưỡng, bên cho thuê sẽ hỗ trợ thay thế không tính phí.', CAST(N'2024-11-13T17:19:05.3398606' AS DateTime2), CAST(N'2024-11-13T17:19:05.3398607' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'be91a8e5-44a1-49e3-6d6d-08dd0404aaae', N'Cam kết về bảo dưỡng thiết bị', N'693066d2-fc74-4bba-bae1-21914762d76e', N'Thiết bị sẽ được bảo dưỡng định kỳ trước khi cho thuê.', N'Bên cho thuê cam kết kiểm tra và bảo dưỡng thiết bị định kỳ, đảm bảo chất lượng sử dụng.', N'Nếu thiết bị gặp lỗi do không bảo dưỡng, bên cho thuê sẽ hỗ trợ thay thế không tính phí.', CAST(N'2024-11-13T17:19:20.4051695' AS DateTime2), CAST(N'2024-11-13T17:19:20.4051696' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'abf070b6-344a-4f52-6d6e-08dd0404aaae', N'Thỏa thuận về bảo mật thông tin', N'693066d2-fc74-4bba-bae1-21914762d76e', N'Thông tin cá nhân của khách hàng sẽ được bảo mật tuyệt đối.', N'Bên cho thuê cam kết không tiết lộ bất kỳ thông tin cá nhân nào của khách hàng cho bên thứ ba nếu không có sự đồng ý.', N'Nếu bên cho thuê tiết lộ thông tin, sẽ chịu trách nhiệm theo pháp luật.', CAST(N'2024-11-13T17:19:28.2963446' AS DateTime2), CAST(N'2024-11-13T17:19:28.2963447' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'1b520e0d-6114-4453-6d6f-08dd0404aaae', N'Thanh toán và hoàn trả', N'693066d2-fc74-4bba-bae1-21914762d76e', N'Quy định về thanh toán chi phí thuê và chính sách hoàn trả.', N'Bên thuê cần thanh toán đầy đủ trước khi nhận thiết bị. Nếu trả sớm hơn thời hạn, sẽ không được hoàn lại tiền.', N'Nếu không thanh toán đúng hạn, hợp đồng sẽ bị hủy mà không hoàn lại tiền.', CAST(N'2024-11-13T17:19:40.0934786' AS DateTime2), CAST(N'2024-11-13T17:19:40.0934788' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'90f3a5eb-dde8-472c-6d70-08dd0404aaae', N'Quy định về hủy hợp đồng', N'693066d2-fc74-4bba-bae1-21914762d76e', N'Bên thuê có thể hủy hợp đồng trước thời hạn nhưng phải báo trước ít nhất 24 giờ.', N'Nếu bên thuê hủy hợp đồng mà không báo trước hoặc báo quá trễ, sẽ phải chịu phí bồi thường theo quy định.', N'Phí hủy hợp đồng là 10% giá trị thuê nếu không báo trước 24 giờ.', CAST(N'2024-11-13T17:19:55.8484712' AS DateTime2), CAST(N'2024-11-13T17:19:55.8484713' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'3ababa05-4542-4ac0-6d71-08dd0404aaae', N'Trách nhiệm bảo quản', N'693066d2-fc74-4bba-bae1-21914762d76e', N'Bên thuê có trách nhiệm bảo quản máy ảnh trong suốt thời gian thuê.', N'Trong suốt thời gian thuê, bên thuê phải bảo quản thiết bị tránh các tác động vật lý, nước, và các yếu tố gây hư hại khác.', N'Nếu máy ảnh bị hỏng, bên thuê phải chịu chi phí sửa chữa hoặc bồi thường theo giá trị thiết bị.', CAST(N'2024-11-13T17:20:14.0516508' AS DateTime2), CAST(N'2024-11-13T17:20:14.0516509' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'32416a64-0006-4844-6d72-08dd0404aaae', N'Trách nhiệm bảo quản', N'693066d2-fc74-4bba-bae1-21914762d76e', N'Bên thuê có trách nhiệm bảo quản máy ảnh trong suốt thời gian thuê.', N'Trong suốt thời gian thuê, bên thuê phải bảo quản thiết bị tránh các tác động vật lý, nước, và các yếu tố gây hư hại khác.', N'Nếu máy ảnh bị hỏng, bên thuê phải chịu chi phí sửa chữa hoặc bồi thường theo giá trị thiết bị.', CAST(N'2024-11-13T17:20:28.3941336' AS DateTime2), CAST(N'2024-11-13T17:20:28.3941338' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'226b0211-92c6-4b0c-6d73-08dd0404aaae', N'Trách nhiệm bảo quản', N'7fc1f33b-aee1-4f21-beee-d754572a4f52', N'Bên thuê có trách nhiệm bảo quản máy ảnh trong suốt thời gian thuê.', N'Trong suốt thời gian thuê, bên thuê phải bảo quản thiết bị tránh các tác động vật lý, nước, và các yếu tố gây hư hại khác.', N'Nếu máy ảnh bị hỏng, bên thuê phải chịu chi phí sửa chữa hoặc bồi thường theo giá trị thiết bị.', CAST(N'2024-11-13T17:20:49.2888442' AS DateTime2), CAST(N'2024-11-13T17:20:49.2888442' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'e3ba0cb8-d7c5-4232-6d74-08dd0404aaae', N'Thời hạn thuê', N'7fc1f33b-aee1-4f21-beee-d754572a4f52', N'Thời gian thuê máy ảnh được quy định rõ ràng và cam kết trả đúng hạn.', N'Thời gian thuê bắt đầu từ thời điểm nhận máy đến thời điểm trả máy đã thỏa thuận trước. Bên thuê chịu trách nhiệm trả máy đúng hạn, nếu không sẽ bị xử phạt theo quy định.', N'Phạt 5% giá trị hợp đồng mỗi giờ trả muộn.', CAST(N'2024-11-13T17:21:01.7980547' AS DateTime2), CAST(N'2024-11-13T17:21:01.7980548' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'd8bc67ea-d835-4d96-6d75-08dd0404aaae', N'Cam kết về bảo dưỡng thiết bị', N'7fc1f33b-aee1-4f21-beee-d754572a4f52', N'Thiết bị sẽ được bảo dưỡng định kỳ trước khi cho thuê.', N'Bên cho thuê cam kết kiểm tra và bảo dưỡng thiết bị định kỳ, đảm bảo chất lượng sử dụng.', N'Nếu thiết bị gặp lỗi do không bảo dưỡng, bên cho thuê sẽ hỗ trợ thay thế không tính phí.', CAST(N'2024-11-13T17:21:09.9703812' AS DateTime2), CAST(N'2024-11-13T17:21:09.9703813' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'8ecbf14a-e963-4614-6d76-08dd0404aaae', N'Thanh toán và hoàn trả', N'7fc1f33b-aee1-4f21-beee-d754572a4f52', N'Quy định về thanh toán chi phí thuê và chính sách hoàn trả.', N'Bên thuê cần thanh toán đầy đủ trước khi nhận thiết bị. Nếu trả sớm hơn thời hạn, sẽ không được hoàn lại tiền.', N'Nếu không thanh toán đúng hạn, hợp đồng sẽ bị hủy mà không hoàn lại tiền.', CAST(N'2024-11-13T17:21:22.4922050' AS DateTime2), CAST(N'2024-11-13T17:21:22.4922052' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'd9b1e42a-10f0-4634-6d77-08dd0404aaae', N'Quy định về hủy hợp đồng', N'7fc1f33b-aee1-4f21-beee-d754572a4f52', N'Bên thuê có thể hủy hợp đồng trước thời hạn nhưng phải báo trước ít nhất 24 giờ.', N'Nếu bên thuê hủy hợp đồng mà không báo trước hoặc báo quá trễ, sẽ phải chịu phí bồi thường theo quy định.', N'Phí hủy hợp đồng là 10% giá trị thuê nếu không báo trước 24 giờ.', CAST(N'2024-11-13T17:21:43.1014153' AS DateTime2), CAST(N'2024-11-13T17:21:43.1014154' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'0974ada6-acb3-4cf1-6d78-08dd0404aaae', N'Thời hạn thuê', N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'Thời gian thuê máy ảnh được quy định rõ ràng và cam kết trả đúng hạn.', N'Thời gian thuê bắt đầu từ thời điểm nhận máy đến thời điểm trả máy đã thỏa thuận trước. Bên thuê chịu trách nhiệm trả máy đúng hạn, nếu không sẽ bị xử phạt theo quy định.', N'Phạt 5% giá trị hợp đồng mỗi giờ trả muộn.', CAST(N'2024-11-13T17:23:06.9109059' AS DateTime2), CAST(N'2024-11-13T17:23:06.9109060' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'4df168c0-a471-42ae-6d79-08dd0404aaae', N'Trách nhiệm bảo quản', N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'Bên thuê có trách nhiệm bảo quản máy ảnh trong suốt thời gian thuê.', N'Trong suốt thời gian thuê, bên thuê phải bảo quản thiết bị tránh các tác động vật lý, nước, và các yếu tố gây hư hại khác.', N'Nếu máy ảnh bị hỏng, bên thuê phải chịu chi phí sửa chữa hoặc bồi thường theo giá trị thiết bị.', CAST(N'2024-11-13T17:23:25.0724739' AS DateTime2), CAST(N'2024-11-13T17:23:25.0724741' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'6e80f33a-baed-4c34-6d7a-08dd0404aaae', N'Sử dụng thiết bị đúng mục đích', N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'Thiết bị chỉ được sử dụng cho mục đích ghi hình và không được sử dụng vào các mục đích khác ngoài hợp đồng.', N'Bên thuê cam kết chỉ sử dụng thiết bị cho các mục đích ghi hình, không cho bên thứ ba thuê lại hoặc sử dụng vào mục đích trái phép.', N'Nếu bên thuê sử dụng không đúng mục đích, sẽ bị phạt 15% giá trị hợp đồng.', CAST(N'2024-11-13T17:25:44.1900973' AS DateTime2), CAST(N'2024-11-13T17:25:44.1900974' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'91256109-3326-4aeb-6d7b-08dd0404aaae', N'Quy định về hủy hợp đồng', N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'Bên thuê có thể hủy hợp đồng trước thời hạn nhưng phải báo trước ít nhất 24 giờ.', N'Nếu bên thuê hủy hợp đồng mà không báo trước hoặc báo quá trễ, sẽ phải chịu phí bồi thường theo quy định.', N'Phí hủy hợp đồng là 10% giá trị thuê nếu không báo trước 24 giờ.', CAST(N'2024-11-13T17:25:57.7990061' AS DateTime2), CAST(N'2024-11-13T17:25:57.7990062' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'0a9a2d5a-8c72-4c7a-6d7c-08dd0404aaae', N'Cam kết không thay đổi cấu hình', N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'Bên thuê không được thay đổi bất kỳ cấu hình nào của thiết bị.', N'Bên thuê không được cài đặt phần mềm hoặc thay đổi cấu hình mặc định của máy ảnh. Nếu có nhu cầu, phải thông báo và được sự đồng ý của bên cho thuê.', N'Vi phạm sẽ bị phạt 10% giá trị hợp đồng.', CAST(N'2024-11-13T17:26:24.7860341' AS DateTime2), CAST(N'2024-11-13T17:26:24.7860342' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'eba9d5a0-6686-4322-6d7d-08dd0404aaae', N'Hướng dẫn sử dụng an toàn', N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'Bên thuê cam kết tuân thủ các quy tắc an toàn khi sử dụng thiết bị.', N'Bên thuê sẽ được hướng dẫn cách sử dụng an toàn cho thiết bị và cam kết làm theo. Sử dụng không đúng cách dẫn đến hỏng thiết bị sẽ bị phạt.', N'Bên thuê chịu trách nhiệm chi phí sửa chữa nếu sử dụng sai cách.', CAST(N'2024-11-13T17:26:50.7274849' AS DateTime2), CAST(N'2024-11-13T17:26:50.7274850' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'20521045-3980-47fc-6d7e-08dd0404aaae', N'Quy định về thiết bị phụ kiện', N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'Bên thuê chịu trách nhiệm với các phụ kiện đi kèm máy ảnh.', N'Các phụ kiện như pin, sạc, ống kính phải được bảo quản và trả lại trong tình trạng ban đầu.', N'Nếu mất hoặc hỏng phụ kiện, bên thuê chịu toàn bộ chi phí thay thế.', CAST(N'2024-11-13T17:27:18.8140033' AS DateTime2), CAST(N'2024-11-13T17:27:18.8140034' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'c02bd3c0-5362-4804-6d7f-08dd0404aaae', N'Quy định về thời gian sử dụng', N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'Thiết bị chỉ được sử dụng trong khung giờ đã thỏa thuận.', N'Bên thuê cam kết sử dụng thiết bị trong khoảng thời gian đã định rõ. Nếu sử dụng ngoài giờ sẽ bị phạt.', N'Phạt 5% giá trị hợp đồng mỗi giờ sử dụng ngoài giờ quy định.', CAST(N'2024-11-13T17:27:36.7361564' AS DateTime2), CAST(N'2024-11-13T17:27:36.7361565' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'c7adcf6b-762a-4a51-6d80-08dd0404aaae', N'Quy định về thời gian sử dụng', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Thiết bị chỉ được sử dụng trong khung giờ đã thỏa thuận.', N'Bên thuê cam kết sử dụng thiết bị trong khoảng thời gian đã định rõ. Nếu sử dụng ngoài giờ sẽ bị phạt.', N'Phạt 5% giá trị hợp đồng mỗi giờ sử dụng ngoài giờ quy định.', CAST(N'2024-11-13T17:28:01.9694413' AS DateTime2), CAST(N'2024-11-13T17:28:01.9694414' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'7a6ac698-60e3-44e9-6d81-08dd0404aaae', N'Thời hạn thuê', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Thời gian thuê máy ảnh được quy định rõ ràng và cam kết trả đúng hạn.', N'Thời gian thuê bắt đầu từ thời điểm nhận máy đến thời điểm trả máy đã thỏa thuận trước. Bên thuê chịu trách nhiệm trả máy đúng hạn, nếu không sẽ bị xử phạt theo quy định.', N'Phạt 5% giá trị hợp đồng mỗi giờ trả muộn.', CAST(N'2024-11-13T17:28:21.4203956' AS DateTime2), CAST(N'2024-11-13T17:28:21.4203957' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'b9819431-fef0-405f-6d82-08dd0404aaae', N'Trách nhiệm bảo quản', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Bên thuê có trách nhiệm bảo quản máy ảnh trong suốt thời gian thuê.', N'Trong suốt thời gian thuê, bên thuê phải bảo quản thiết bị tránh các tác động vật lý, nước, và các yếu tố gây hư hại khác.', N'Nếu máy ảnh bị hỏng, bên thuê phải chịu chi phí sửa chữa hoặc bồi thường theo giá trị thiết bị.', CAST(N'2024-11-13T17:28:36.0314056' AS DateTime2), CAST(N'2024-11-13T17:28:36.0314057' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'318d05a4-36f2-4f7c-6d83-08dd0404aaae', N'Sử dụng thiết bị đúng mục đích', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Thiết bị chỉ được sử dụng cho mục đích ghi hình và không được sử dụng vào các mục đích khác ngoài hợp đồng.', N'Bên thuê cam kết chỉ sử dụng thiết bị cho các mục đích ghi hình, không cho bên thứ ba thuê lại hoặc sử dụng vào mục đích trái phép.', N'Nếu bên thuê sử dụng không đúng mục đích, sẽ bị phạt 15% giá trị hợp đồng.', CAST(N'2024-11-13T17:28:52.9909777' AS DateTime2), CAST(N'2024-11-13T17:28:52.9909778' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'510f62a5-226a-48b6-6d84-08dd0404aaae', N'Quy định về hủy hợp đồng', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Bên thuê có thể hủy hợp đồng trước thời hạn nhưng phải báo trước ít nhất 24 giờ.', N'Nếu bên thuê hủy hợp đồng mà không báo trước hoặc báo quá trễ, sẽ phải chịu phí bồi thường theo quy định.', N'Phí hủy hợp đồng là 10% giá trị thuê nếu không báo trước 24 giờ.', CAST(N'2024-11-13T17:29:11.6651190' AS DateTime2), CAST(N'2024-11-13T17:29:11.6651191' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'861c1647-791f-48d6-6d85-08dd0404aaae', N'Quy định về kiểm tra và bàn giao thiết bị', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Bên thuê có trách nhiệm kiểm tra thiết bị trước khi nhận.', N'Trước khi bàn giao, bên thuê cần xác nhận tình trạng thiết bị và ký xác nhận. Nếu có hỏng hóc phải thông báo ngay để được hỗ trợ.', N'Nếu bên thuê không kiểm tra và ký xác nhận, mọi hỏng hóc sau đó sẽ chịu trách nhiệm.', CAST(N'2024-11-13T17:29:26.2553275' AS DateTime2), CAST(N'2024-11-13T17:29:26.2553276' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'72a65b8f-8df9-464f-6d86-08dd0404aaae', N'Cam kết về bản quyền hình ảnh', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Bên thuê cam kết không vi phạm bản quyền khi sử dụng thiết bị.', N'Mọi nội dung ghi hình phải tuân thủ luật pháp về bản quyền. Bên thuê chịu trách nhiệm trước pháp luật nếu vi phạm.', N'Nếu có khiếu nại về bản quyền, bên thuê chịu trách nhiệm pháp lý hoàn toàn.', CAST(N'2024-11-13T17:29:44.5833143' AS DateTime2), CAST(N'2024-11-13T17:29:44.5833144' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'b93532c3-88b9-4950-6d87-08dd0404aaae', N'Thanh toán và hoàn trả', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Quy định về thanh toán chi phí thuê và chính sách hoàn trả.', N'Bên thuê cần thanh toán đầy đủ trước khi nhận thiết bị. Nếu trả sớm hơn thời hạn, sẽ không được hoàn lại tiền.', N'Nếu không thanh toán đúng hạn, hợp đồng sẽ bị hủy mà không hoàn lại tiền.', CAST(N'2024-11-13T17:29:59.4563898' AS DateTime2), CAST(N'2024-11-13T17:29:59.4563899' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'6876dc74-b44b-432b-6d88-08dd0404aaae', N'Hợp đồng thuê theo ngày 1', N'45dc7060-6b22-420b-b4a4-1329e420e3bd', N'1', N'1', N'1', CAST(N'2024-11-13T22:35:07.8843849' AS DateTime2), CAST(N'2024-11-13T22:35:07.8843850' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'e8fbbcad-7b43-4ae5-6d89-08dd0404aaae', N'Hợp đồng thuê theo ngày 1', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'1', N'a', N'a', CAST(N'2024-11-13T22:35:46.4732895' AS DateTime2), CAST(N'2024-11-13T22:35:46.4732896' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
GO
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [SupplierID], [Price], [TransactionDescription], [Status], [CreatedAt]) VALUES (N'7c67ea19-8e65-4f70-988a-1df2b3e8fb82', N'980936d8-bb35-4432-329d-08dcf5e53bbf', 16000000, N'Khach hang: da nap tien 160000 VND', 0, CAST(N'2024-11-16T19:36:10.3322440' AS DateTime2))
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [SupplierID], [Price], [TransactionDescription], [Status], [CreatedAt]) VALUES (N'5d304e12-2780-4d11-85bc-362d5091d337', N'980936d8-bb35-4432-329d-08dcf5e53bbf', 15000000, N'Khach hang: da nap tien 150000 VND', 0, CAST(N'2024-11-16T19:32:11.6297059' AS DateTime2))
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [SupplierID], [Price], [TransactionDescription], [Status], [CreatedAt]) VALUES (N'675dab42-a7f6-48b8-bb8a-3d4c14199e54', N'980936d8-bb35-4432-329d-08dcf5e53bbf', 15515100, N'Khach hang: da nap tien 155151 VND', 0, CAST(N'2024-11-16T11:49:33.1842218' AS DateTime2))
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [SupplierID], [Price], [TransactionDescription], [Status], [CreatedAt]) VALUES (N'415084d0-8a34-4795-bf32-57b16fb2422a', N'ffb0ae5f-10f2-48d7-329f-08dcf5e53bbf', 15550000, N'Khach hang: da nap tien 155500 VND', 0, CAST(N'2024-11-16T18:56:37.3759108' AS DateTime2))
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [SupplierID], [Price], [TransactionDescription], [Status], [CreatedAt]) VALUES (N'551bf8fd-0e53-4c6e-93ed-5edcbbc5a9cc', N'980936d8-bb35-4432-329d-08dcf5e53bbf', 15990000, N'Khach hang: da nap tien 159900 VND', 0, CAST(N'2024-11-16T13:44:31.7640164' AS DateTime2))
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [SupplierID], [Price], [TransactionDescription], [Status], [CreatedAt]) VALUES (N'c1c229dc-7c72-4b41-ab1b-60a4186d64c4', N'980936d8-bb35-4432-329d-08dcf5e53bbf', 150000000, N'Khach hang: da nap tien 1500000 VND', 0, CAST(N'2024-11-16T12:05:02.4352182' AS DateTime2))
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [SupplierID], [Price], [TransactionDescription], [Status], [CreatedAt]) VALUES (N'557443a9-8b40-4772-96de-735d4782d70b', N'980936d8-bb35-4432-329d-08dcf5e53bbf', 152525000, N'Khach hang: da nap tien 1525250 VND', 0, CAST(N'2024-11-16T12:06:23.8347421' AS DateTime2))
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [SupplierID], [Price], [TransactionDescription], [Status], [CreatedAt]) VALUES (N'a8af6953-e7e7-4ce6-a8d1-92aa93140986', N'980936d8-bb35-4432-329d-08dcf5e53bbf', 20000000, N'Khach hang: da nap tien 200000 VND', 0, CAST(N'2024-11-16T11:27:08.1338609' AS DateTime2))
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [SupplierID], [Price], [TransactionDescription], [Status], [CreatedAt]) VALUES (N'3316036e-ec35-4091-b2d6-9b92dea2bdc1', N'980936d8-bb35-4432-329d-08dcf5e53bbf', 215850000, N'Khach hang: da nap tien 2158500 VND', 0, CAST(N'2024-11-16T13:04:53.6262651' AS DateTime2))
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [SupplierID], [Price], [TransactionDescription], [Status], [CreatedAt]) VALUES (N'066d7beb-3ba5-4c30-9b15-b721f54dc1d6', N'980936d8-bb35-4432-329d-08dcf5e53bbf', 20000000, N'Khach hang: da nap tien 200000 VND', 0, CAST(N'2024-11-16T11:34:46.3981581' AS DateTime2))
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [SupplierID], [Price], [TransactionDescription], [Status], [CreatedAt]) VALUES (N'a4d18b85-2f07-450b-aa2c-b75937c9dd83', N'980936d8-bb35-4432-329d-08dcf5e53bbf', 12121200, N'Khach hang: da nap tien 121212 VND', 0, CAST(N'2024-11-16T11:43:26.1996335' AS DateTime2))
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [SupplierID], [Price], [TransactionDescription], [Status], [CreatedAt]) VALUES (N'75db0543-bbef-46d3-8324-bce6d7713b67', N'980936d8-bb35-4432-329d-08dcf5e53bbf', 15600000, N'Khach hang: da nap tien 156000 VND', 0, CAST(N'2024-11-16T20:28:32.3972041' AS DateTime2))
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [SupplierID], [Price], [TransactionDescription], [Status], [CreatedAt]) VALUES (N'85210cdb-12b5-42f5-929f-bdafdf6fdb93', N'980936d8-bb35-4432-329d-08dcf5e53bbf', 20000000, N'Khach hang: da nap tien 200000 VND', 0, CAST(N'2024-11-16T11:39:14.9026012' AS DateTime2))
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [SupplierID], [Price], [TransactionDescription], [Status], [CreatedAt]) VALUES (N'632861cc-8662-4304-9d57-c0f717b7731b', N'ffb0ae5f-10f2-48d7-329f-08dcf5e53bbf', 1500000, N'Khach hang: da nap tien 15000 VND', 0, CAST(N'2024-11-16T19:25:29.2918079' AS DateTime2))
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [SupplierID], [Price], [TransactionDescription], [Status], [CreatedAt]) VALUES (N'36c09380-539a-49e0-94fb-cf7fcc8c07a0', N'980936d8-bb35-4432-329d-08dcf5e53bbf', 11111100, N'Khach hang: da nap tien 111111 VND', 0, CAST(N'2024-11-16T12:21:14.0851370' AS DateTime2))
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [RentalPeriod]) VALUES (N'e56c9909-7029-4235-aaa8-08dd06ffca6c', N'93b19815-fe23-49bb-8a01-675e606d1016', N'b29a096b-5f7f-43c8-b737-120ab897cd75', 80000, N'mới', 0, 4030000, NULL)
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [RentalPeriod]) VALUES (N'822e27c3-7ca9-4c50-6545-08dd0720da9c', N'e247118d-cbe4-44c0-afc3-a54582173597', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', 0, N'mới', 0, 111111, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [Id], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveriesMethod], [CreatedAt], [UpdatedAt], [AccountId], [OrderDetailID], [Deposit]) VALUES (N'93b19815-fe23-49bb-8a01-675e606d1016', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'5aa7ee73-acf3-4110-8f5f-b296738b102e', CAST(N'2024-11-17T12:23:09.0518103' AS DateTime2), 8, 4030000, 1, NULL, NULL, 0, 0, NULL, NULL, 1, CAST(N'2024-11-17T12:23:09.0518104' AS DateTime2), CAST(N'2024-11-17T12:23:09.0518104' AS DateTime2), NULL, NULL, 4000000)
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [Id], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveriesMethod], [CreatedAt], [UpdatedAt], [AccountId], [OrderDetailID], [Deposit]) VALUES (N'e247118d-cbe4-44c0-afc3-a54582173597', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'10974a6b-e639-4d24-b073-970321bb21ea', CAST(N'2024-11-17T15:59:18.9143139' AS DateTime2), 8, 111111, 1, CAST(N'2024-11-17T15:53:15.3870000' AS DateTime2), CAST(N'2024-11-17T17:53:15.3870000' AS DateTime2), 0, 2, CAST(N'2024-11-17T17:53:15.3870000' AS DateTime2), N'string', 0, CAST(N'2024-11-17T15:59:18.9143140' AS DateTime2), CAST(N'2024-11-17T15:59:18.9143140' AS DateTime2), NULL, NULL, 3500000)
GO
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [SupplierID], [AccountID], [PaymentDate], [PaymentAmount], [PaymentType], [PaymentStatus], [PaymentMethod], [PaymentDetails], [CreatedAt], [Image], [IsDisable]) VALUES (N'bf10e8a3-da0d-4161-8607-3bd555575731', N'93b19815-fe23-49bb-8a01-675e606d1016', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'5aa7ee73-acf3-4110-8f5f-b296738b102e', CAST(N'2024-11-17T12:24:03.1438731' AS DateTime2), 403000000, 0, 1, 0, N'Payment for Order 93b19815-fe23-49bb-8a01-675e606d1016', CAST(N'2024-11-17T12:24:03.1438829' AS DateTime2), N'a', 1)
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [SupplierID], [AccountID], [PaymentDate], [PaymentAmount], [PaymentType], [PaymentStatus], [PaymentMethod], [PaymentDetails], [CreatedAt], [Image], [IsDisable]) VALUES (N'30b7a9f3-b0ad-4981-b26f-812c17f935c7', N'e247118d-cbe4-44c0-afc3-a54582173597', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'10974a6b-e639-4d24-b073-970321bb21ea', CAST(N'2024-11-17T16:01:45.3984240' AS DateTime2), 11111100, 0, 1, 0, N'Payment for Order e247118d-cbe4-44c0-afc3-a54582173597', CAST(N'2024-11-17T16:01:45.3984447' AS DateTime2), N'a', 1)
GO
INSERT [dbo].[Policies] ([PolicyID], [PolicyType], [PolicyContent], [ApplicableObject], [EffectiveDate], [Value], [IsDisable]) VALUES (N'2d080ff5-dd57-426f-17f0-08dcfa111b74', 1, N'Người cho thuê và người bán có thể hủy giao dịch nếu có lý do chính đáng nhưng phải thông báo kịp thời cho bên đối tác.', 1, CAST(N'2024-11-01T01:04:01.7720000' AS DateTime2), CAST(N'2024-11-01T01:04:01.7720000' AS DateTime2), 0)
INSERT [dbo].[Policies] ([PolicyID], [PolicyType], [PolicyContent], [ApplicableObject], [EffectiveDate], [Value], [IsDisable]) VALUES (N'de103e79-fe2c-45aa-17f1-08dcfa111b74', 1, N'Người thuê có quyền hủy giao dịch trong các trường hợp được quy định bởi nền tảng, bao gồm thời gian hủy và điều kiện hủy.', 1, CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), 0)
INSERT [dbo].[Policies] ([PolicyID], [PolicyType], [PolicyContent], [ApplicableObject], [EffectiveDate], [Value], [IsDisable]) VALUES (N'55dd3700-c4a8-454f-17f2-08dcfa111b74', 2, N'Người mua có quyền hủy giao dịch trong các trường hợp được quy định bởi nền tảng, bao gồm thời gian hủy và điều kiện hủy.', 2, CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), 0)
INSERT [dbo].[Policies] ([PolicyID], [PolicyType], [PolicyContent], [ApplicableObject], [EffectiveDate], [Value], [IsDisable]) VALUES (N'84af32e6-8c32-4c2a-17f3-08dcfa111b74', 0, N'Nền tảng có quyền tạm ngừng hoặc chấm dứt tài khoản của người dùng nếu phát hiện hành vi lừa đảo, vi phạm chính sách hoặc gây thiệt hại cho các bên khác.', 0, CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), 0)
INSERT [dbo].[Policies] ([PolicyID], [PolicyType], [PolicyContent], [ApplicableObject], [EffectiveDate], [Value], [IsDisable]) VALUES (N'ee3f4112-b929-431b-17f4-08dcfa111b74', 0, N'Các hành vi lừa đảo, sử dụng thiết bị không đúng mục đích hoặc bán sản phẩm giả mạo sẽ bị xử lý nghiêm theo quy định pháp luật.', 0, CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), 0)
INSERT [dbo].[Policies] ([PolicyID], [PolicyType], [PolicyContent], [ApplicableObject], [EffectiveDate], [Value], [IsDisable]) VALUES (N'311538b9-8ec8-4ff8-17f5-08dcfa111b74', 0, N'Nền tảng cam kết bảo mật thông tin cá nhân của người dùng và chỉ sử dụng thông tin cho các mục đích giao dịch.', 0, CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), 0)
INSERT [dbo].[Policies] ([PolicyID], [PolicyType], [PolicyContent], [ApplicableObject], [EffectiveDate], [Value], [IsDisable]) VALUES (N'4f21a107-faa0-416c-17f6-08dcfa111b74', 0, N'Thông tin cá nhân sẽ không được chia sẻ cho bên thứ ba nếu không có sự đồng ý của người dùng, trừ trường hợp yêu cầu pháp lý.', 0, CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), 0)
INSERT [dbo].[Policies] ([PolicyID], [PolicyType], [PolicyContent], [ApplicableObject], [EffectiveDate], [Value], [IsDisable]) VALUES (N'6cc3d1e4-fdb9-48cd-17f7-08dcfa111b74', 0, N'Nền tảng có quyền điều chỉnh và cập nhật các chính sách sử dụng khi cần thiết. Người dùng có trách nhiệm theo dõi và tuân thủ các thay đổi mới nhất của chính sách này.', 0, CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), 0)
INSERT [dbo].[Policies] ([PolicyID], [PolicyType], [PolicyContent], [ApplicableObject], [EffectiveDate], [Value], [IsDisable]) VALUES (N'7fc843a2-8d10-4b2b-17f8-08dcfa111b74', 2, N'Người thuê phải chịu trách nhiệm bồi thường cho người cho thuê nếu thiết bị bị hỏng hóc hoặc mất mát trong quá trình sử dụng theo thỏa thuận của người cho thuê và người thuê', 2, CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), 0)
INSERT [dbo].[Policies] ([PolicyID], [PolicyType], [PolicyContent], [ApplicableObject], [EffectiveDate], [Value], [IsDisable]) VALUES (N'c2a2a52f-a259-441f-17f9-08dcfa111b74', 1, N'Người mua cần đọc kỹ mô tả sản phẩm trước khi đặt mua và chịu trách nhiệm về quyết định mua của mình, ngoại trừ trường hợp sản phẩm có lỗi hoặc không đúng mô tả.', 1, CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), 0)
INSERT [dbo].[Policies] ([PolicyID], [PolicyType], [PolicyContent], [ApplicableObject], [EffectiveDate], [Value], [IsDisable]) VALUES (N'f155e7f7-b87b-4943-17fa-08dcfa111b74', 1, N'Người bán phải chấp nhận hoàn tiền theo chính sách của nền tảng nếu phát hiện sản phẩm có lỗi.', 1, CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), 0)
INSERT [dbo].[Policies] ([PolicyID], [PolicyType], [PolicyContent], [ApplicableObject], [EffectiveDate], [Value], [IsDisable]) VALUES (N'c62b4e76-90c1-4413-17fb-08dcfa111b74', 2, N'Người mua có quyền yêu cầu đổi trả hoặc hoàn tiền nếu sản phẩm không đúng mô tả, hỏng hóc hoặc lỗi kỹ thuật trong thời gian quy định của nền tảng.', 2, CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), 0)
INSERT [dbo].[Policies] ([PolicyID], [PolicyType], [PolicyContent], [ApplicableObject], [EffectiveDate], [Value], [IsDisable]) VALUES (N'1d9cc787-ac35-4e2a-17fc-08dcfa111b74', 2, N'Người thuê có thể hủy thuê sản phẩm mà không mất phí.', 2, CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), 0)
INSERT [dbo].[Policies] ([PolicyID], [PolicyType], [PolicyContent], [ApplicableObject], [EffectiveDate], [Value], [IsDisable]) VALUES (N'94352cba-d950-48f8-17fd-08dcfa111b74', 2, N'Sau khi kết thúc thời gian thuê, khách hàng trả máy tại địa điểm đã thoả thuận với bên Cho Thuê.', 2, CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), 0)
INSERT [dbo].[Policies] ([PolicyID], [PolicyType], [PolicyContent], [ApplicableObject], [EffectiveDate], [Value], [IsDisable]) VALUES (N'd45afbec-a91d-44fb-17fe-08dcfa111b74', 1, N'Sau khi hoàn tất thủ tục trả máy, trong vòng 24h, người cho thuê sẽ kiểm tra tình trạng máy và yêu cầu bồi thường nếu có.', 1, CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), CAST(N'2024-10-17T21:50:47.2900000' AS DateTime2), 0)
GO
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'2bc9d8db-a43d-4ab9-b2bc-02232d14029e', N'd2aa771b-fa01-4b9b-a411-b20c26da1561', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fd2aa771b-fa01-4b9b-a411-b20c26da1561_9aa8def5-8d49-484c-b898-e6cb0b970861.jpg.png?alt=media&token=66cca32d-e4ab-4365-b86d-09592c519dd7')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'0ec691f1-a720-49d2-af45-219855b735c3', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fb29a096b-5f7f-43c8-b737-120ab897cd75_35c0056a-01e4-440d-8c74-bc258c3e567b.jpg.png?alt=media&token=a2515f7b-2e60-4102-a6b4-22d48f78ad77')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'0d41cd03-cc60-4925-8914-24d455d02d59', N'f0b3d4b5-4b30-47f4-bddf-652651e039b5', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Ff0b3d4b5-4b30-47f4-bddf-652651e039b5_3abd1265-b0ac-43ee-8264-1f9ba52a097e.jpg.png?alt=media&token=3ceb9664-b1f9-46ed-b283-da99a081722c')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'39c371e1-83fb-411d-9fdd-25c6e70618da', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F9f7cf8ee-56b8-4d64-8aeb-40364831c377_b0d21774-bc87-47fb-8e45-8a0fb2220530.jpg.png?alt=media&token=5f68279c-6e66-46ad-bd44-7fbe34b049ea')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'a13f6180-a14c-4b6d-b7c0-2644d9ec5be0', N'41770a28-69b3-4e15-b3da-bced9f09fea0', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F41770a28-69b3-4e15-b3da-bced9f09fea0_45debc18-38a4-4dbd-aff8-84a535d1d9d7.jpg.png?alt=media&token=f866115b-104b-4148-b32c-4a61f2b37506')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'5722ea83-37b7-4683-8024-3f7a6cab38d1', N'7fc1f33b-aee1-4f21-beee-d754572a4f52', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F7fc1f33b-aee1-4f21-beee-d754572a4f52_3635a4c1-9991-4201-8124-b66da5534e6d.jpg.png?alt=media&token=3c2324be-c37a-4708-8384-87b197996b90')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'4efe198b-ef04-4ee0-8c9d-3fb3d544a098', N'9b702de0-be3d-454a-80e9-ecb614f9de15', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F9b702de0-be3d-454a-80e9-ecb614f9de15_0379e707-430d-4605-8778-0ff9f79d57d6.jpg.png?alt=media&token=15042d21-4906-4dca-baae-b15f26e7d092')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'3c69067d-5a9e-4fb0-85a8-4d9ffd447408', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Feb6466fb-8ec4-4534-82e6-0dae17dc73a6_1944663b-b575-4faf-ad6e-01acba4edcf2.jpg.png?alt=media&token=d282f5e0-b054-450c-9788-9c271ab0d321')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'9a4f77d3-0382-406c-a3cf-6f7bcbfda55f', N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fa3dc3f4d-9d1d-44e2-b005-ea2054ac99ae_6c80406f-d482-4474-8081-4bf053e14b99.jpg.png?alt=media&token=d5371ca4-7159-4801-a76e-9e543c5bbd40')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'ae57ed65-e5a4-4f6a-90e1-75c251f9870e', N'e1153c25-8e58-47ac-8146-5c54bb0df4a3', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fe1153c25-8e58-47ac-8146-5c54bb0df4a3_cc9be74c-2845-4f8a-aa09-283a9a289bd4.jpg.png?alt=media&token=ae9b13fa-095e-4e6b-ad65-b68048556f3f')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'8cf673fe-d51e-4bc9-94b2-805a70c323c2', N'f3705778-aec9-4d92-8e8a-9944500e8854', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Ff3705778-aec9-4d92-8e8a-9944500e8854_7364b724-34bd-4d01-8084-e7418603e667.jpg.png?alt=media&token=aab153bf-efe0-419d-907b-ff0a14a30497')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'98f63bef-c511-4dc1-a43d-8ae0ebd84039', N'8cba35ef-91a4-440e-94b4-1ef099f85222', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F8cba35ef-91a4-440e-94b4-1ef099f85222_9aeb44a5-417a-45c5-8643-82b158920a88.jpg.png?alt=media&token=04c2eee9-1a02-4de6-b203-db1acdb43746')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'894c7880-5927-4e61-a767-a28c13091c3b', N'db30b319-a22a-4fbb-bef2-8d2207270e9e', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fdb30b319-a22a-4fbb-bef2-8d2207270e9e_483281e4-0eb2-4aa8-8e1e-4c00675cad74.jpg.png?alt=media&token=fb392bbd-bd62-4508-9b2b-9ddb91963d25')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'958bc85d-6ec5-423a-a1cb-b372a4336565', N'ca414592-719d-41d7-8136-b059f0a108b1', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fca414592-719d-41d7-8136-b059f0a108b1_8a44c17b-3c4f-4c8f-a629-68b1d85dcb12.jpg.png?alt=media&token=d7300393-523a-4fd1-ad42-8651a22384a8')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'b756180a-fcc4-4ba3-9484-b99d30a2b168', N'45dc7060-6b22-420b-b4a4-1329e420e3bd', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F45dc7060-6b22-420b-b4a4-1329e420e3bd_82d8cd68-cdc0-4949-959b-61207874794f.jpg.png?alt=media&token=279028f4-0091-4553-b4b4-3a9a124baf17')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'a60b7508-9bd2-474b-82f6-ba0579c8da76', N'4a4c1796-07ce-4ae9-bf13-1fc20d35e4bc', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F4a4c1796-07ce-4ae9-bf13-1fc20d35e4bc_65deb11c-dade-4b09-a6be-7541fd33739d.jpg.png?alt=media&token=ed74a7d9-2dbf-4941-88fa-ac4609b5f405')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'84a9680b-4160-4bc4-bdd6-c965a209adf3', N'd7bd0251-127a-4f8c-b129-31835bb521a0', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fd7bd0251-127a-4f8c-b129-31835bb521a0_a43e53b0-e6ea-4d55-b5f6-304d351d124c.jpg.png?alt=media&token=803b0e85-046e-4441-8084-490c76fde88b')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'ea55fb50-73cc-4bc6-90d0-cc475ecab267', N'63af74bd-02d8-4a18-9f90-6a3c7a5f0bb0', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F63af74bd-02d8-4a18-9f90-6a3c7a5f0bb0_c0815566-7893-4ff0-a1a3-42b4e1c5fb20.jpg.png?alt=media&token=34a91a6c-ecd2-47b0-970a-a7a1cc69142b')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'bbd03199-ae8d-4c82-9ce0-dc74a219f6c5', N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fc5c22a5c-b417-4423-977e-1510549fcfc2_f35be710-0a7a-48c1-b9f8-5463b37a89a5.jpg.png?alt=media&token=802ea97a-adec-4a81-a02f-ca187ad9a169')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'4cc21337-9b17-408d-94f6-e30ffd0e91f7', N'693066d2-fc74-4bba-bae1-21914762d76e', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F693066d2-fc74-4bba-bae1-21914762d76e_d9639c80-fc7f-4f01-8c8c-9dadcfbb6bae.jpg.png?alt=media&token=7ceee266-2aba-45c1-b126-07a8f9e012fd')
GO
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'NikonCOOLPIX_P1000', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'máy ảnh Nikon COOLPIX P1000', N'Là một chiếc máy ảnh chụp siêu xa, Nikon COOLPIX P1000 mang đến khả năng zoom quang học đáng kinh ngạc 125x, kết hợp với khẩu độ tối đa f/2.8-8 cho phép người dùng ghi lại những khung hình ấn tượng và độc đáo nhất, lý tưởng để chụp các thể loại nhiếp ảnh như thiên văn, thể thao và động vật hoang dã.', NULL, 23450000, 1, N'mới', 2, 0, CAST(N'2024-10-28T22:12:10.4813914' AS DateTime2), CAST(N'2024-11-07T14:27:59.8164998' AS DateTime2), 3500000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'FUJIFILM Instax Mini Evo Hybrid', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'65d75b62-2173-4167-b289-9568167dbe54', N'Máy ảnh lấy liền FUJIFILM Instax Mini Evo Hybrid - Hàng chính hãng', N'Instax Mini Evo Hybrid có thiết kế giống Instax Mini 90 Neo với thân máy được bọc da PU kết hợp cùng khung viền chrome tạo điểm nhấn mang lại vẻ đẹp cổ điển nhưng vẫn không mất đi nét thời thượng.Mặt sau của máy là các nút điều hướng menu và màn hình LCD 3 inch hỗ trợ việc chụp ảnh, điều chỉnh chế độ và xem ảnh, lựa chọn ảnh để in. Đặc biệt, máy còn có cần gạt “Film Advance” như một chiếc máy ảnh film, đây là điểm nhấn hoài cổ thú vị của Instax Mini Evo.', NULL, NULL, 3, N'mới', 2, 0, CAST(N'2024-10-26T23:50:20.4721751' AS DateTime2), CAST(N'2024-11-07T08:23:53.9712585' AS DateTime2), 4000000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'45dc7060-6b22-420b-b4a4-1329e420e3bd', N'A010', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Panasonic Lumix DMC-FZ300', N'Máy ảnh với zoom 24x và khẩu độ f/2.8, phù hợp cho chụp ảnh ngoài trời và trong nhà.', NULL, NULL, 5, N'0', 1, 0, CAST(N'2024-11-13T18:35:32.4673181' AS DateTime2), CAST(N'2024-11-13T18:35:32.4673184' AS DateTime2), 500000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'NikonZfbody', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Máy ảnh Nikon Zf body', N'Máy ảnh Nikon Zf được trang bị cảm biến BSI CMOS định dạng FX 24,5MP. Với kích thước định dạng FX, cảm biến này tương đương với kích thước khung hình phim 35mm, giúp nắm bắt một lượng ánh sáng lớn hơn và tạo ra hình ảnh với độ sâu trường sâu hơn. Hơn nữa, cảm biến còn có độ phân giải 24,5, đảm bảo hình ảnh chi tiết khi in ấn lớn hoặc thực hiện chỉnh sửa ảnh mà không mất đi chất lượng.', NULL, 51870000, 1, N'mới', 0, 0, CAST(N'2024-10-31T07:13:13.7998901' AS DateTime2), CAST(N'2024-11-07T15:35:43.5201028' AS DateTime2), 3500000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'8cba35ef-91a4-440e-94b4-1ef099f85222', N'SonyCybershortHX-7V', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Máy ảnh Sony Cybershort HX-7V - Có Mịn Da - Tiếng Việt - Nhiều hiệu ứng cảnh thú vị', N'Máy ảnh Nikon Zf được trang bị cảm biến BSI CMOS định dạng FX 24,5MP. Với kích thước định dạng FX, cảm biến này tương đương với kích thước khung hình phim 35mm, giúp nắm bắt một lượng ánh sáng lớn hơn và tạo ra hình ảnh với độ sâu trường sâu hơn. Hơn nữa, cảm biến còn có độ phân giải 24,5, đảm bảo hình ảnh chi tiết khi in ấn lớn hoặc thực hiện chỉnh sửa ảnh mà không mất đi chất lượng.', NULL, 2890000, 2, N'mới', 0, 0, CAST(N'2024-10-28T01:28:24.8393210' AS DateTime2), CAST(N'2024-11-07T15:49:15.5507760' AS DateTime2), 4500000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'4a4c1796-07ce-4ae9-bf13-1fc20d35e4bc', N'A008', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'e9819628-bdf7-4883-ae21-4b83fd1a5193', N'Sony Alpha A6400', N'Máy ảnh mirrorless gọn nhẹ với cảm biến APS-C 24.2MP, phù hợp cho quay vlog và chụp ảnh đa năng.', 0, 2450000, 2, N'0', 0, 0, CAST(N'2024-11-13T17:48:47.6145414' AS DateTime2), CAST(N'2024-11-13T17:48:47.6145468' AS DateTime2), 4500000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'693066d2-fc74-4bba-bae1-21914762d76e', N'Canon3000D', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Máy ảnh Canon 3000D + Lens 18-55mm Chính hãng LBM - Mới 99% Likenew', N'Máy ảnh Canon 3000D + Lens 18-55mm. Máy rất đẹp, Máy nhỏ gọn, phù hợp cho các bạn mới chơi, đi du lịch. Đặc biệt máy có chức năng wifi, chụp xong bắn qua Đt ngay Máy  combo đầy đủ phụ kiện kèm théo máy', NULL, 3350000, 0, N'cũ', 0, 0, CAST(N'2024-10-28T01:49:51.0363127' AS DateTime2), CAST(N'2024-11-07T15:53:24.4326766' AS DateTime2), 4550000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'd7bd0251-127a-4f8c-b129-31835bb521a0', N'A01000253', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Máy ảnh Canon EOS 250D Kit EF-S18-55mm F3.5-5.6 III', N'Máy ảnh Canon EOS 250D Kit EF-S18-55mm F3.5-5.6 III thuộc dòng máy ảnh DSLR phổ thông của Canon, với thiết kế nhỏ gọn, trọng lượng nhẹ. Nhờ đó, máy tạo cảm giác thoải mái, tiện lợi khi sử dụng cũng như mang theo để sáng tạo những bức ảnh chất lượng.', NULL, 15600000, 0, N'mới', 0, 0, CAST(N'2024-10-28T01:38:29.7645531' AS DateTime2), CAST(N'2024-11-07T15:59:35.6053942' AS DateTime2), 4550000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'A04000228', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Máy ảnh Fujifilm X- T50 Body Xám', N'Máy ảnh Fujifilm X- T50 Body Xám mới là sự kết hợp thú vị giữa cấu trúc di động với chất lượng hình ảnh hàng đầu. Nó có hình thức nhỏ gọn giúp dễ dàng mang theo, trong khi được trang bị loạt tính năng đa năng sẽ cho bạn trải nghiệm tuyệt vời.', NULL, NULL, 3, N'mới', 1, 0, CAST(N'2024-11-06T21:48:29.4546887' AS DateTime2), CAST(N'2024-11-07T09:06:44.7928038' AS DateTime2), 4000000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'e1153c25-8e58-47ac-8146-5c54bb0df4a3', N'A009', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'e9819628-bdf7-4883-ae21-4b83fd1a5193', N'Fujifilm X-T30', N'Máy ảnh mirrorless nhỏ gọn, phù hợp cho nhiếp ảnh đường phố và cảnh quan.', NULL, NULL, 3, N'0', 1, 0, CAST(N'2024-11-13T18:31:36.3949803' AS DateTime2), CAST(N'2024-11-13T18:31:36.3949805' AS DateTime2), 4000000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'f0b3d4b5-4b30-47f4-bddf-652651e039b5', N'SN001', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'3ed49ca1-fc18-4d3c-ac86-0b04f1d57f35', N'Canon EOS 90D', N'Máy ảnh DSLR chuyên nghiệp cho nhiếp ảnh gia', NULL, 12000000, 0, N'moi', 0, 0, CAST(N'2024-10-26T18:35:31.1080560' AS DateTime2), CAST(N'2024-10-26T18:35:31.1081036' AS DateTime2), 4550000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'63af74bd-02d8-4a18-9f90-6a3c7a5f0bb0', N'A011', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Nikon D7500', N'Máy ảnh DSLR APS-C 20.9MP, lý tưởng cho người mới và chụp ảnh gia đình.', NULL, NULL, 1, N'0', 2, 0, CAST(N'2024-11-13T18:39:57.6943085' AS DateTime2), CAST(N'2024-11-13T18:39:57.6943087' AS DateTime2), 3500000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'31c67538-334a-4d67-9f94-6ab96439b4c1', N'CAM008', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Olympus OM-D E-M1 Mark III', N'Máy ảnh MFT với khả năng ổn định hình ảnh', NULL, 2800000, 4, N'moi', 0, 0, CAST(N'2024-10-31T20:09:57.5795579' AS DateTime2), CAST(N'2024-10-31T20:09:57.5795956' AS DateTime2), 5000000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'db30b319-a22a-4fbb-bef2-8d2207270e9e', N'FujifilmX-s10', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Máy Ảnh Fujifilm X-s10 18-55m F2.8-4 Ois', N' Máy Ảnh Fujifilm X-s10 18-55m F2.8-4 Ois có thiết kế nhỏ gọn, bộ tính năng lớn, FUJIFILM X-S10 là một chiếc máy ảnh không gương lật kiểu dáng đẹp và linh hoạt, rất phù hợp để sử dụng khi di chuyển. Cung cấp các tính năng hình ảnh và video có khả năng, X-S10 kết hợp yếu tố hình thức di động với các công cụ cần thiết để tạo nội dung hàng ngày.', NULL, 10966000, 3, N'mới', 0, 0, CAST(N'2024-10-28T01:09:32.0890208' AS DateTime2), CAST(N'2024-11-07T16:33:01.0735444' AS DateTime2), 4000000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'f3705778-aec9-4d92-8e8a-9944500e8854', N'A006', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Canon PowerShot SX740 HS', N'Máy ảnh nhỏ gọn với zoom quang học 40x, phù hợp cho du lịch và chụp ảnh hàng ngày.', NULL, NULL, 0, N'0', 1, 0, CAST(N'2024-11-13T18:27:42.2821012' AS DateTime2), CAST(N'2024-11-13T18:27:42.2821014' AS DateTime2), 4550000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'dde6ce8a-13a5-434f-a1ed-b03d1ca05043', N'CAM001', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Canon EOS R5', N'Máy ảnh mirrorless full-frame, quay video 8K', NULL, 800000, 0, N'moi', 0, 0, CAST(N'2024-10-31T17:30:05.4184495' AS DateTime2), CAST(N'2024-10-31T17:30:05.4184974' AS DateTime2), 4550000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'ca414592-719d-41d7-8136-b059f0a108b1', N'A007', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'e9819628-bdf7-4883-ae21-4b83fd1a5193', N'Sony Alpha A7 III', N'Máy quay hành động có khả năng quay 5.3K, chống nước tốt, lý tưởng cho thể thao mạo hiểm.', NULL, NULL, 2, N'0', 1, 0, CAST(N'2024-11-13T18:00:04.2570549' AS DateTime2), CAST(N'2024-11-13T18:00:04.2570550' AS DateTime2), 4500000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'd2aa771b-fa01-4b9b-a411-b20c26da1561', N'A01122', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Canon EOS 5D Mark IV', N'Canon EOS 5D Mark IV', 0, 65000000, 0, N'Moi', 0, 0, CAST(N'2024-11-13T17:19:23.0919841' AS DateTime2), CAST(N'2024-11-13T17:19:23.0920204' AS DateTime2), 4550000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'41770a28-69b3-4e15-b3da-bced9f09fea0', N'A005', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'65d75b62-2173-4167-b289-9568167dbe54', N'Fujifilm Instax Mini 11', N'Máy ảnh in liền, nhỏ gọn và dễ sử dụng, phù hợp cho buổi tụ họp và du lịch.', NULL, NULL, 3, N'1', 1, 0, CAST(N'2024-11-13T18:23:25.4824369' AS DateTime2), CAST(N'2024-11-13T18:23:25.4824370' AS DateTime2), 4000000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'7fc1f33b-aee1-4f21-beee-d754572a4f52', N'Canon30Dlens28', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Máy ảnh Canon 30D lens 28-80, đầy đủ phụ kiện ', N'Đầy đủ phụ kiện che flash, pin, sạc pin, thẻ nhớ, đầu đọc thẻ nhớ để cắm vào máy tính( bạn nào ko có máy tính thì ra tiệm đưa thẻ nhớ nhờ người ta cop vào google drive để chỉnh trên điện thoại cũng được) ', NULL, NULL, 0, N'cũ', 1, 0, CAST(N'2024-10-26T22:58:20.0103969' AS DateTime2), CAST(N'2024-11-07T09:38:59.9408498' AS DateTime2), 4550000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', N'NikonD7200', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Máy Ảnh Nikon D7200 - Chính Hãng', NULL, NULL, NULL, 1, N'mới', 1, 0, CAST(N'2024-10-26T23:19:55.3766577' AS DateTime2), CAST(N'2024-11-07T09:51:37.9255668' AS DateTime2), 3500000)
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt], [DepositProduct]) VALUES (N'9b702de0-be3d-454a-80e9-ecb614f9de15', N'THUE123', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'e9819628-bdf7-4883-ae21-4b83fd1a5193', N'Olympus OM-D E-M1 23', N'Olympus OM-D E-M1 23', NULL, NULL, 4, N'Mới ', 1, 0, CAST(N'2024-11-13T17:16:41.3577295' AS DateTime2), CAST(N'2024-11-13T17:16:41.3577544' AS DateTime2), 5000000)
GO
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'af16a1e8-d674-43ea-8410-028f90f4972d', N'693066d2-fc74-4bba-bae1-21914762d76e', N'Phụ kiện máy ảnh đi kèm ', N' Pin, sạc pin, dây đeo, phiếu bảo hành')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'5f06e67a-def3-433c-ae20-0e317f37071b', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'Kích thước', N' 87x123x36 mm')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'3cb71a3e-b3d0-447b-a937-1b1e051f21a5', N'f0b3d4b5-4b30-47f4-bddf-652651e039b5', N'Độ phân giải tối đa ', N' 6960 x 4640')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'71737ec3-5143-4a37-9650-1d76af4a9583', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Bù phơi sáng', N' -5 đến +5 EV (1/3 EV bước)')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'072e2a2b-3f91-443e-8be4-23c9ce4db747', N'693066d2-fc74-4bba-bae1-21914762d76e', N'Màn hình', N' LCD 3.0inch ')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'f341ff77-9ba8-4662-82f1-2a387e645305', N'db30b319-a22a-4fbb-bef2-8d2207270e9e', N'Quay video', N' 4K/30p 4:2:2 10-bit - full-HD 240fps')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'ac833018-626d-456a-bbd4-2a851f95a887', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Kích thước', N'3.0')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'e37dd597-cb05-4940-a4c0-2e04a70afcde', N'd7bd0251-127a-4f8c-b129-31835bb521a0', N'Cảm biến kép', N'	CMOS 24.1 megapixels')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'f62bf65c-cdb3-4c9a-81af-324c1a8d1e0f', N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'Loại thẻ nhớ', N'SDXC')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'fb943b71-270b-4f01-9cea-38121df59d6d', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'Pin', N' Lithium Ion, cổng sạc Micro USB / Tyce C (2023)')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'551eace8-e142-4c1b-84a6-430e1fcf0796', N'd7bd0251-127a-4f8c-b129-31835bb521a0', N'Tốc độ màn trập', N' 30 1/4000 giây')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'a32b48a7-aa16-4466-b8b7-495d5dc05590', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Độ sâu bit', N'14-Bit')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'e9af5638-c33d-4028-8de4-4e5f238c2b8f', N'db30b319-a22a-4fbb-bef2-8d2207270e9e', N'Chống rung thân máy', N' 5 trục IBIS - 6 stop')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'f34666bb-c524-4d2d-ae16-56189e2a6682', N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'ISO', N' 100-64000 (mở rộng 50-204800)')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'7bce9e72-a892-45c2-b611-5ea552bb111b', N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'Mode chụp', N' B&W riêng biệt')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'ae307a63-3499-4527-8a7d-601a552b16c2', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'Kích thước màn hình', N'3.2 inch')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'1cf11348-7367-498f-8870-606db75da451', N'd7bd0251-127a-4f8c-b129-31835bb521a0', N'Độ nhạy sáng', N' ISO 100-25600 (mở rộng 51200)')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'dfcf2db9-6feb-44f5-87bf-679d65890e5e', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'Độ phân giải', N' 2560x1920 px')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'39d72af3-ddf7-49f9-b4fa-6aece4078b33', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'ISO', N' 100–1600')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'ad68d788-a2d1-4be3-9f50-6e7952dc3fb0', N'd7bd0251-127a-4f8c-b129-31835bb521a0', N'Màn hình	LCD', N' 3.0 inch (cảm ứng)')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'e3e0b452-6938-4ee5-be1c-726a5a05f08a', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'độ phân giải ', N'40 px')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'719a76d2-bdca-405a-bb2d-7490e8cf5590', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'Trọng lượng', N' 285g')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'bbcf3ce3-0c06-41d4-873a-7537ebceb7a7', N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'Cảm biến', N' FX BSI CMOS 24.5MP')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'f3a1bd39-3a7e-49c8-8a36-82a30b6b6bb9', N'693066d2-fc74-4bba-bae1-21914762d76e', N'ISO', N' 100-6400 (mở rộng 12800)')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'24d60b70-e7d0-4053-abd2-8a2bf134848c', N'db30b319-a22a-4fbb-bef2-8d2207270e9e', N'Sử dụng bộ xử lý hình ảnh', N' X-Processor 4')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'7d9fdfda-058c-4f4b-b987-8e2a0302166c', N'693066d2-fc74-4bba-bae1-21914762d76e', N'Cảm biến', N' CMOS 18.0 megapixel')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'cf3208d8-8dce-4029-b546-8f86a17c877e', N'db30b319-a22a-4fbb-bef2-8d2207270e9e', N'LCD quay lật', N' 180 độ, cảm ứng')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'f23967a9-bb0b-4150-bda6-9b3f0e0270eb', N'693066d2-fc74-4bba-bae1-21914762d76e', N'Pin tương thích', N' LP-E10')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'c7ef6764-bc98-4246-91af-a146b672b3e1', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Độ ẩm hoạt động', N'10 đến 80%')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'4b9a9f6c-c50e-4fd8-8a28-b1035aa993cf', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'Film', N' Instax Mini')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'33a9250e-b8f5-4042-8476-bbe1dd212156', N'db30b319-a22a-4fbb-bef2-8d2207270e9e', N'ISO', N' 160 - 12800 / mở rộng 80-51200')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'54ce6d54-5e53-4582-a882-c426bb93c1e7', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Loại cảm biến', N' CMOS')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'c5ad04ed-2827-4d0b-bb27-ca5dd5bf3514', N'd7bd0251-127a-4f8c-b129-31835bb521a0', N'Bộ xử lý hình ảnh', N' DIGIC 8')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'772ac16b-f4c7-42cf-867f-caf5a7672168', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Tỷ lệ khung hình', N'1')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'e81b5bc6-8850-47a3-a054-cc36d7694015', N'd7bd0251-127a-4f8c-b129-31835bb521a0', N'Tốc độ chụp', N' 6.0 ảnh/ giây')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'8a88c4c1-c229-4457-ad99-d3a4c148e40b', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'Đóng gói', N' 1 máy Instax Mini Evo, Sách hướng dẫn sử dụng, Dây sạc, Dây đeo cổ')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'895f7d24-5a05-470b-bfe1-dcd23463a696', N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'Tốc độ khung hình', N' 30fps')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'53b0668e-a4b2-448c-9420-df44157697f1', N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'Màn hình cảm ứng', N' LCD 3.2" lật 2.1 triệu điểm')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'463e1eff-2425-4c8e-91f4-e2889e1f953f', N'693066d2-fc74-4bba-bae1-21914762d76e', N'Kết nối', N' Wifi / NFC')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'ceffe1c0-312d-4938-a2a7-ebcb24161daa', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Kích thước kính ngắm', N'0,39')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'61508b04-d462-4070-9eb3-ec8b5cca49f7', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Cân nặng', N' 378 g (Thân máy có pin và bộ nhớ)')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'fdbc3687-b4ae-4322-85e0-ee8783c3d00e', N'db30b319-a22a-4fbb-bef2-8d2207270e9e', N'Cảm biến ảnh', N' 26.1MP X-TransTM CMOS 4')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'e2f723f7-806e-4539-bebb-fe1a6d8ab937', N'693066d2-fc74-4bba-bae1-21914762d76e', N'Bộ xử lý hình ảnh', N' DIGIC 4+')
GO
INSERT [dbo].[ProductVouchers] ([ProductVoucherID], [ProductID], [VourcherID], [CreatedAt], [UpdatedAt], [IsDisable]) VALUES (N'8eb375cc-a6d2-438d-8478-07a71bfebf72', N'4a4c1796-07ce-4ae9-bf13-1fc20d35e4bc', N'2a669ff3-7e51-4053-87cc-179edaa306ba', CAST(N'2024-11-14T19:27:55.3052209' AS DateTime2), CAST(N'2024-11-14T19:27:55.3052210' AS DateTime2), 0)
INSERT [dbo].[ProductVouchers] ([ProductVoucherID], [ProductID], [VourcherID], [CreatedAt], [UpdatedAt], [IsDisable]) VALUES (N'b82ac0b4-dd90-4865-b9b6-280545cf8533', N'693066d2-fc74-4bba-bae1-21914762d76e', N'7cafdef1-4f7c-4709-af47-514d3c230d93', CAST(N'2024-11-14T04:41:26.8673502' AS DateTime2), CAST(N'2024-11-14T04:41:26.8673503' AS DateTime2), 0)
INSERT [dbo].[ProductVouchers] ([ProductVoucherID], [ProductID], [VourcherID], [CreatedAt], [UpdatedAt], [IsDisable]) VALUES (N'81ea68d6-e160-46f8-a5a1-30080204c96a', N'693066d2-fc74-4bba-bae1-21914762d76e', N'2a669ff3-7e51-4053-87cc-179edaa306ba', CAST(N'2024-11-14T04:41:18.3110386' AS DateTime2), CAST(N'2024-11-14T04:41:18.3110387' AS DateTime2), 0)
INSERT [dbo].[ProductVouchers] ([ProductVoucherID], [ProductID], [VourcherID], [CreatedAt], [UpdatedAt], [IsDisable]) VALUES (N'b42dea17-7c00-485f-a8b0-334813d6a8ec', N'db30b319-a22a-4fbb-bef2-8d2207270e9e', N'2a669ff3-7e51-4053-87cc-179edaa306ba', CAST(N'2024-11-14T21:24:30.1494387' AS DateTime2), CAST(N'2024-11-14T21:24:30.1494388' AS DateTime2), 0)
INSERT [dbo].[ProductVouchers] ([ProductVoucherID], [ProductID], [VourcherID], [CreatedAt], [UpdatedAt], [IsDisable]) VALUES (N'6cca611c-cafe-4a0b-9ccd-414fb1979847', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'2a669ff3-7e51-4053-87cc-179edaa306ba', CAST(N'2024-11-14T04:23:01.2690924' AS DateTime2), CAST(N'2024-11-14T04:23:01.2690925' AS DateTime2), 0)
INSERT [dbo].[ProductVouchers] ([ProductVoucherID], [ProductID], [VourcherID], [CreatedAt], [UpdatedAt], [IsDisable]) VALUES (N'9171dd0b-cdd7-47e6-b10f-49e3d89f65d8', N'db30b319-a22a-4fbb-bef2-8d2207270e9e', N'2a669ff3-7e51-4053-87cc-179edaa306ba', CAST(N'2024-11-14T21:24:15.5120343' AS DateTime2), CAST(N'2024-11-14T21:24:15.5120344' AS DateTime2), 0)
INSERT [dbo].[ProductVouchers] ([ProductVoucherID], [ProductID], [VourcherID], [CreatedAt], [UpdatedAt], [IsDisable]) VALUES (N'd13ca6ed-cdff-44a4-b6bd-51a067afe5c0', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'2a669ff3-7e51-4053-87cc-179edaa306ba', CAST(N'2024-11-14T06:29:19.7888976' AS DateTime2), CAST(N'2024-11-14T06:29:19.7888977' AS DateTime2), 0)
INSERT [dbo].[ProductVouchers] ([ProductVoucherID], [ProductID], [VourcherID], [CreatedAt], [UpdatedAt], [IsDisable]) VALUES (N'12b1c0d9-a845-4fa4-8564-7dcfd1914b88', N'4a4c1796-07ce-4ae9-bf13-1fc20d35e4bc', N'2c488120-fce6-4818-833f-81dd55619241', CAST(N'2024-11-14T19:29:29.0302941' AS DateTime2), CAST(N'2024-11-14T19:29:29.0302942' AS DateTime2), 0)
INSERT [dbo].[ProductVouchers] ([ProductVoucherID], [ProductID], [VourcherID], [CreatedAt], [UpdatedAt], [IsDisable]) VALUES (N'44443ae1-1d39-439c-85ff-dce5a89199d4', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'7cafdef1-4f7c-4709-af47-514d3c230d93', CAST(N'2024-11-14T04:23:07.8273411' AS DateTime2), CAST(N'2024-11-14T04:23:07.8273411' AS DateTime2), 0)
INSERT [dbo].[ProductVouchers] ([ProductVoucherID], [ProductID], [VourcherID], [CreatedAt], [UpdatedAt], [IsDisable]) VALUES (N'6df8b57e-92f4-4e25-b3a1-f2db1a0cb9ec', N'45dc7060-6b22-420b-b4a4-1329e420e3bd', N'2a669ff3-7e51-4053-87cc-179edaa306ba', CAST(N'2024-11-14T04:40:31.0167444' AS DateTime2), CAST(N'2024-11-14T04:40:31.0167445' AS DateTime2), 0)
GO
INSERT [dbo].[Ratings] ([RatingID], [ProductID], [AccountID], [RatingValue], [CreatedAt], [ReviewComment], [IsDisable]) VALUES (N'9acbb560-3b51-45bd-9a8c-fff7fcbfad63', N'dde6ce8a-13a5-434f-a1ed-b03d1ca05043', N'10974a6b-e639-4d24-b073-970321bb21ea', 4, CAST(N'2024-11-09T03:46:28.4319177' AS DateTime2), N'sản phẩm tốt', 1)
GO
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'18d35801-bfad-4d6e-bd75-08952c424873', N'f3705778-aec9-4d92-8e8a-9944500e8854', 60000, 0, 0, 0, CAST(N'2024-11-13T18:27:42.2821042' AS DateTime2), CAST(N'2024-11-13T18:27:42.2821044' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'694b5c4f-398a-4a79-aaad-15059fc75bea', N'e1153c25-8e58-47ac-8146-5c54bb0df4a3', 140000, 1100000, 0, 0, CAST(N'2024-11-13T18:31:36.3949875' AS DateTime2), CAST(N'2024-11-13T18:31:36.3949880' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'9aa08b36-0695-4f72-a889-2d02ce820949', N'41770a28-69b3-4e15-b3da-bced9f09fea0', 30000, 0, 0, 0, CAST(N'2024-11-13T18:23:25.4824450' AS DateTime2), CAST(N'2024-11-13T18:23:25.4824453' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'57e4039d-6bc0-46b8-a681-322e2a1c29c3', N'9b702de0-be3d-454a-80e9-ecb614f9de15', 1500000, 600000, 0, 0, CAST(N'2024-11-13T17:16:41.3580191' AS DateTime2), CAST(N'2024-11-13T17:16:41.3580398' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'f1bba992-64b9-428b-904b-38b8a315fc8c', N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', 100000, 500000, 2000000, NULL, CAST(N'2024-10-26T23:19:55.3771997' AS DateTime2), CAST(N'2024-10-26T23:19:55.3772592' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'060f0a6c-15f3-42d9-af4d-46826d0f9fd7', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', 111111, 0, 0, 0, CAST(N'2024-10-28T22:12:10.4813992' AS DateTime2), CAST(N'2024-10-28T22:12:10.4813994' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'572a17ef-a5cb-4682-bce6-4ea011b6ee57', N'b29a096b-5f7f-43c8-b737-120ab897cd75', 30000, 80000, 300000, 800000, CAST(N'2024-10-26T23:50:20.4727211' AS DateTime2), CAST(N'2024-10-26T23:50:20.4727725' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'1795e900-1a7a-4346-aadc-4ecb0b9d8bfd', N'693066d2-fc74-4bba-bae1-21914762d76e', 10, 0, 0, 0, CAST(N'2024-10-28T01:49:51.0367720' AS DateTime2), CAST(N'2024-10-28T01:49:51.0368538' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'0b93677d-58b3-4384-94cb-64d7c3ea4fa0', N'63af74bd-02d8-4a18-9f90-6a3c7a5f0bb0', 130000, 1000000, 6000000, 0, CAST(N'2024-11-13T18:39:57.6943112' AS DateTime2), CAST(N'2024-11-13T18:39:57.6943114' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'75c86eed-bb79-4eaf-92c9-68acac3b7969', N'7fc1f33b-aee1-4f21-beee-d754572a4f52', 20000, 60000, 160000, 5000000, CAST(N'2024-10-26T22:58:22.5292565' AS DateTime2), CAST(N'2024-10-26T22:58:22.5293273' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'38c439e5-71fd-4167-afec-7b37c24cda42', N'c5c22a5c-b417-4423-977e-1510549fcfc2', 0, 200000, 0, 0, CAST(N'2024-10-31T07:13:13.8002749' AS DateTime2), CAST(N'2024-10-31T07:13:13.8002975' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'4428ed1f-c6b7-4ba4-8394-c4fd68795f0a', N'ca414592-719d-41d7-8136-b059f0a108b1', 180000, 1500000, 0, 0, CAST(N'2024-11-13T18:00:04.2570615' AS DateTime2), CAST(N'2024-11-13T18:00:04.2570617' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'adef9c82-4153-48b7-84ed-e477c914d1f7', N'45dc7060-6b22-420b-b4a4-1329e420e3bd', 80000, 500000, 0, 0, CAST(N'2024-11-13T18:35:32.4673210' AS DateTime2), CAST(N'2024-11-13T18:35:32.4673213' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'5a701bd7-d001-4a78-95e8-fff6159f75b0', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', 100000, 500000, 1300000, 4000000, CAST(N'2024-11-06T21:48:29.4550472' AS DateTime2), CAST(N'2024-11-06T21:48:29.4550697' AS DateTime2))
GO
INSERT [dbo].[Staffs] ([StaffID], [Name], [AccountID], [JobTitle], [Department], [StaffStatus], [HireDate], [CreatedAt], [UpdatedAt], [IsAdmin], [Img], [IsDisable]) VALUES (N'5d0e0c59-074c-44e2-0f33-08dcf9537099', N'Perdita', N'8b6c5937-00ed-4d95-96d3-1d83c0599dc8', N'IT', N'IT', N'active', CAST(N'2024-10-30T17:00:00.0000000' AS DateTime2), CAST(N'2024-10-31T02:26:34.6378635' AS DateTime2), CAST(N'2024-10-31T02:26:34.6378636' AS DateTime2), 0, N'Microsoft.AspNetCore.Http.FormFile', 0)
INSERT [dbo].[Staffs] ([StaffID], [Name], [AccountID], [JobTitle], [Department], [StaffStatus], [HireDate], [CreatedAt], [UpdatedAt], [IsAdmin], [Img], [IsDisable]) VALUES (N'dc072fce-1157-42a1-0f34-08dcf9537099', N'test1', N'2eedc0f8-4273-44ed-aaf5-2987e3563f86', N'IT', N'IT', N'active', CAST(N'2024-10-30T17:00:00.0000000' AS DateTime2), CAST(N'2024-10-31T05:54:11.2262380' AS DateTime2), CAST(N'2024-10-31T05:54:11.2262381' AS DateTime2), 0, N'Microsoft.AspNetCore.Http.FormFile', 0)
INSERT [dbo].[Staffs] ([StaffID], [Name], [AccountID], [JobTitle], [Department], [StaffStatus], [HireDate], [CreatedAt], [UpdatedAt], [IsAdmin], [Img], [IsDisable]) VALUES (N'c85307d4-af14-44ee-8b70-08dcf97db3c1', N'a', N'd8c5456e-df60-4c62-8bf5-0cc4b14f0d86', N'a', N'a', N'0', CAST(N'2002-11-11T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-31T07:29:06.1635641' AS DateTime2), CAST(N'2024-10-31T07:29:06.1635642' AS DateTime2), 0, N'Microsoft.AspNetCore.Http.FormFile', 0)
INSERT [dbo].[Staffs] ([StaffID], [Name], [AccountID], [JobTitle], [Department], [StaffStatus], [HireDate], [CreatedAt], [UpdatedAt], [IsAdmin], [Img], [IsDisable]) VALUES (N'8f5d51d8-e01f-4926-4d0d-08dcfa187630', N'Staff1', N'812cc63a-465b-43f5-a7cd-cc3dc893b45e', N'IT', N'IT', N'active', CAST(N'2024-10-31T17:00:00.0000000' AS DateTime2), CAST(N'2024-11-01T01:56:54.8762436' AS DateTime2), CAST(N'2024-11-01T01:56:54.8762437' AS DateTime2), 0, N'Microsoft.AspNetCore.Http.FormFile', 0)
GO
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [Img], [IsDisable]) VALUES (N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'5aa7ee73-acf3-4110-8f5f-b296738b102e', N'Nikon', N'đem đến trải nghiệm rất tốt', N'188 Trần Bá Giao , P5, GV, TPHCM', N'07989999999', NULL, NULL, NULL, CAST(N'2024-10-26T17:40:07.8301292' AS DateTime2), CAST(N'2024-10-26T17:40:07.8301707' AS DateTime2), NULL, 0)
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [Img], [IsDisable]) VALUES (N'ffb0ae5f-10f2-48d7-329f-08dcf5e53bbf', N'8be335d3-1fd1-4cc6-8835-138dbee72ef5', N'Nikon', N'Dịch vụ máy ảnh từ nhà cung cấp Canon đem đến cho bạn những trai nghiệm tuyệt vời ', N'188 Nguyễn Xiển, Thành phố Thủ Đức, TP HCM', N'07989878787', NULL, NULL, NULL, CAST(N'2024-10-26T17:56:00.4345177' AS DateTime2), CAST(N'2024-10-26T17:56:00.4345179' AS DateTime2), NULL, 0)
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [Img], [IsDisable]) VALUES (N'67958e38-0ca0-43a2-0887-08dcfa0f9cda', N'5dc31c52-da51-46cf-87a1-7dbd4c9887ae', N'lbacojq', N'Không gì tuyẹt hon', N'Q9 TP HCM', N'0999744747', NULL, NULL, NULL, CAST(N'2024-11-01T00:53:34.2726968' AS DateTime2), CAST(N'2024-11-01T00:53:34.2727361' AS DateTime2), NULL, 0)
GO
INSERT [dbo].[Transactions] ([TransactionID], [OrderID], [TransactionDate], [Amount], [TransactionType], [PaymentStatus], [PaymentMethod], [VNPAYTransactionID], [VNPAYTransactionStatus], [VNPAYTransactionTime]) VALUES (N'da446b06-96f8-4004-bf66-4c1dfb8b3670', N'93b19815-fe23-49bb-8a01-675e606d1016', CAST(N'2024-11-17T12:24:03.1441332' AS DateTime2), 403000000, 0, 1, 0, N'14678060', 0, CAST(N'2024-11-17T12:24:03.1441405' AS DateTime2))
INSERT [dbo].[Transactions] ([TransactionID], [OrderID], [TransactionDate], [Amount], [TransactionType], [PaymentStatus], [PaymentMethod], [VNPAYTransactionID], [VNPAYTransactionStatus], [VNPAYTransactionTime]) VALUES (N'f2edaa6e-195f-4797-ba81-d7c43fc9ef24', N'e247118d-cbe4-44c0-afc3-a54582173597', CAST(N'2024-11-17T16:01:45.3991145' AS DateTime2), 11111100, 0, 1, 0, N'14678398', 0, CAST(N'2024-11-17T16:01:45.3991245' AS DateTime2))
GO
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'2a669ff3-7e51-4053-87cc-179edaa306ba', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'50K', N'Giam 50 000 cho san pham', 50000, CAST(N'2024-10-23T17:00:00.0000000' AS DateTime2), CAST(N'2024-11-28T17:00:00.0000000' AS DateTime2), 1, CAST(N'2024-10-30T18:54:08.0021495' AS DateTime2), CAST(N'2024-10-30T18:54:08.0021496' AS DateTime2))
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'a15bbace-e32a-4290-adb3-18447999ffa9', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'Giảm 30.000', N'Giảm 30000 ', 30000, CAST(N'2024-10-31T17:00:00.0000000' AS DateTime2), CAST(N'2024-11-01T17:00:00.0000000' AS DateTime2), 1, CAST(N'2024-11-01T02:14:18.5581536' AS DateTime2), CAST(N'2024-11-01T02:14:18.5581537' AS DateTime2))
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'7cafdef1-4f7c-4709-af47-514d3c230d93', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'20K', N'Giam 50000 cho san pham', 50000, CAST(N'2024-10-23T17:00:00.0000000' AS DateTime2), CAST(N'2024-11-28T10:00:00.0000000' AS DateTime2), 1, CAST(N'2024-10-30T18:55:15.1355111' AS DateTime2), CAST(N'2024-10-30T19:27:01.9525220' AS DateTime2))
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'b786f857-8d40-4acf-ab45-6af4c94b3532', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'Nikon50', N'Nikon giảm 50.000 cho các sản phẩm ', 50000, CAST(N'2024-11-05T17:00:00.0000000' AS DateTime2), CAST(N'2024-11-06T17:00:00.0000000' AS DateTime2), 1, CAST(N'2024-11-06T06:46:15.2795072' AS DateTime2), CAST(N'2024-11-06T06:46:15.2795072' AS DateTime2))
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'2c488120-fce6-4818-833f-81dd55619241', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'DISC2024', N'Giảm giá 100d cho đơn hàng đầu tiên', 100, CAST(N'2024-10-27T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-31T02:59:59.0000000' AS DateTime2), 1, CAST(N'2024-10-27T02:17:54.1912484' AS DateTime2), CAST(N'2024-11-14T19:28:17.6099927' AS DateTime2))
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'd571e7f3-f030-415c-ae99-931e23a3fe96', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'Giảm 150.000', N'Giảm 150.000 ', 15, CAST(N'2024-11-05T17:00:00.0000000' AS DateTime2), CAST(N'2024-11-06T10:00:00.0000000' AS DateTime2), 0, CAST(N'2024-11-06T06:44:21.8230525' AS DateTime2), CAST(N'2024-11-06T06:45:34.3972628' AS DateTime2))
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'b5e357fe-4afb-4153-a13d-ab81d901e2b9', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'DISC2024', N'Giảm giá 100k cho đơn hàng đầu tiên', 100, CAST(N'2024-10-27T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-31T23:59:59.0000000' AS DateTime2), 1, CAST(N'2024-10-27T02:17:54.1912484' AS DateTime2), CAST(N'2024-10-27T02:17:54.1912485' AS DateTime2))
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'2a05b9ab-b51d-4547-a7cd-b77dda5bcdab', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'1.000', N'Giam 1 000 cho san pham', 1000, CAST(N'2024-10-30T17:00:00.0000000' AS DateTime2), CAST(N'2024-10-31T10:00:00.0000000' AS DateTime2), 1, CAST(N'2024-10-30T19:27:43.5119256' AS DateTime2), CAST(N'2024-10-30T19:28:07.6140337' AS DateTime2))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contracts_ContractTemplateId]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Contracts_ContractTemplateId] ON [dbo].[Contracts]
(
	[ContractTemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contracts_OrderID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Contracts_OrderID] ON [dbo].[Contracts]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ContractTemplates_AccountID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_ContractTemplates_AccountID] ON [dbo].[ContractTemplates]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ContractTemplates_ProductID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_ContractTemplates_ProductID] ON [dbo].[ContractTemplates]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HistoryTransactions_SupplierID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_HistoryTransactions_SupplierID] ON [dbo].[HistoryTransactions]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_OrderID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderID] ON [dbo].[OrderDetails]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_ProductID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductID] ON [dbo].[OrderDetails]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Orders_AccountId]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_AccountId] ON [dbo].[Orders]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_SupplierID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_SupplierID] ON [dbo].[Orders]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Payments_AccountID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_AccountID] ON [dbo].[Payments]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_OrderID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_OrderID] ON [dbo].[Payments]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_SupplierID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_SupplierID] ON [dbo].[Payments]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductImages_ProductID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductImages_ProductID] ON [dbo].[ProductImages]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ProductReports_Account]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductReports_Account] ON [dbo].[ProductReports]
(
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductReports_ProductID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductReports_ProductID] ON [dbo].[ProductReports]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductReports_SupplierID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductReports_SupplierID] ON [dbo].[ProductReports]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryID] ON [dbo].[Products]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_SupplierID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_SupplierID] ON [dbo].[Products]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductSpecifications_ProductID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductSpecifications_ProductID] ON [dbo].[ProductSpecifications]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductVouchers_ProductID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductVouchers_ProductID] ON [dbo].[ProductVouchers]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductVouchers_VourcherID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductVouchers_VourcherID] ON [dbo].[ProductVouchers]
(
	[VourcherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Ratings_AccountID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Ratings_AccountID] ON [dbo].[Ratings]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Ratings_ProductID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Ratings_ProductID] ON [dbo].[Ratings]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RentalPrices_ProductID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_RentalPrices_ProductID] ON [dbo].[RentalPrices]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Reports_AccountId]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reports_AccountId] ON [dbo].[Reports]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Requests_AccountID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Requests_AccountID] ON [dbo].[Requests]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ReturnDetails_OrderID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_ReturnDetails_OrderID] ON [dbo].[ReturnDetails]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Staffs_AccountID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Staffs_AccountID] ON [dbo].[Staffs]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SupplierReports_AccountID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierReports_AccountID] ON [dbo].[SupplierReports]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierReports_StaffID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierReports_StaffID] ON [dbo].[SupplierReports]
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierReports_SupplierID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierReports_SupplierID] ON [dbo].[SupplierReports]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierRequests_SupplierID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierRequests_SupplierID] ON [dbo].[SupplierRequests]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Suppliers_AccountID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Suppliers_AccountID] ON [dbo].[Suppliers]
(
	[AccountID] ASC
)
WHERE ([AccountID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_OrderID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Transactions_OrderID] ON [dbo].[Transactions]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Wishlists_AccountID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Wishlists_AccountID] ON [dbo].[Wishlists]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Wishlists_ProductID]    Script Date: 11/18/2024 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Wishlists_ProductID] ON [dbo].[Wishlists]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contracts] ADD  DEFAULT (N'') FOR [ContractTerms]
GO
ALTER TABLE [dbo].[Contracts] ADD  DEFAULT (N'') FOR [PenaltyPolicy]
GO
ALTER TABLE [dbo].[Contracts] ADD  DEFAULT (N'') FOR [TemplateDetails]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_Contracts_ContractTemplates_ContractTemplateId] FOREIGN KEY([ContractTemplateId])
REFERENCES [dbo].[ContractTemplates] ([ContractTemplateId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_Contracts_ContractTemplates_ContractTemplateId]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_Contracts_Orders_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_Contracts_Orders_OrderID]
GO
ALTER TABLE [dbo].[ContractTemplates]  WITH CHECK ADD  CONSTRAINT [FK_ContractTemplates_AspNetUsers_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContractTemplates] CHECK CONSTRAINT [FK_ContractTemplates_AspNetUsers_AccountID]
GO
ALTER TABLE [dbo].[ContractTemplates]  WITH CHECK ADD  CONSTRAINT [FK_ContractTemplates_Products_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContractTemplates] CHECK CONSTRAINT [FK_ContractTemplates_Products_ProductID]
GO
ALTER TABLE [dbo].[HistoryTransactions]  WITH CHECK ADD  CONSTRAINT [FK_HistoryTransactions_Suppliers_SupplierID] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HistoryTransactions] CHECK CONSTRAINT [FK_HistoryTransactions_Suppliers_SupplierID]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderID]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products_ProductID]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_AspNetUsers_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_AspNetUsers_AccountId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Suppliers_SupplierID] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Suppliers_SupplierID]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_AspNetUsers_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_AspNetUsers_AccountID]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Orders_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Orders_OrderID]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Suppliers_SupplierID] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Suppliers_SupplierID]
GO
ALTER TABLE [dbo].[ProductImages]  WITH CHECK ADD  CONSTRAINT [FK_ProductImages_Products_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductImages] CHECK CONSTRAINT [FK_ProductImages_Products_ProductID]
GO
ALTER TABLE [dbo].[ProductReports]  WITH CHECK ADD  CONSTRAINT [FK_ProductReports_AspNetUsers_Account] FOREIGN KEY([Account])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ProductReports] CHECK CONSTRAINT [FK_ProductReports_AspNetUsers_Account]
GO
ALTER TABLE [dbo].[ProductReports]  WITH CHECK ADD  CONSTRAINT [FK_ProductReports_Products_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductReports] CHECK CONSTRAINT [FK_ProductReports_Products_ProductID]
GO
ALTER TABLE [dbo].[ProductReports]  WITH CHECK ADD  CONSTRAINT [FK_ProductReports_Suppliers_SupplierID] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductReports] CHECK CONSTRAINT [FK_ProductReports_Suppliers_SupplierID]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryID]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Suppliers_SupplierID] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Suppliers_SupplierID]
GO
ALTER TABLE [dbo].[ProductSpecifications]  WITH CHECK ADD  CONSTRAINT [FK_ProductSpecifications_Products_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductSpecifications] CHECK CONSTRAINT [FK_ProductSpecifications_Products_ProductID]
GO
ALTER TABLE [dbo].[ProductVouchers]  WITH CHECK ADD  CONSTRAINT [FK_ProductVouchers_Products_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductVouchers] CHECK CONSTRAINT [FK_ProductVouchers_Products_ProductID]
GO
ALTER TABLE [dbo].[ProductVouchers]  WITH CHECK ADD  CONSTRAINT [FK_ProductVouchers_Vourchers_VourcherID] FOREIGN KEY([VourcherID])
REFERENCES [dbo].[Vourchers] ([VourcherID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductVouchers] CHECK CONSTRAINT [FK_ProductVouchers_Vourchers_VourcherID]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_AspNetUsers_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_AspNetUsers_AccountID]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Products_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Products_ProductID]
GO
ALTER TABLE [dbo].[RentalPrices]  WITH CHECK ADD  CONSTRAINT [FK_RentalPrices_Products_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RentalPrices] CHECK CONSTRAINT [FK_RentalPrices_Products_ProductID]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_AspNetUsers_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_AspNetUsers_AccountId]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_AspNetUsers_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_AspNetUsers_AccountID]
GO
ALTER TABLE [dbo].[ReturnDetails]  WITH CHECK ADD  CONSTRAINT [FK_ReturnDetails_Orders_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReturnDetails] CHECK CONSTRAINT [FK_ReturnDetails_Orders_OrderID]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_AspNetUsers_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_AspNetUsers_AccountID]
GO
ALTER TABLE [dbo].[SupplierReports]  WITH CHECK ADD  CONSTRAINT [FK_SupplierReports_AspNetUsers_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[SupplierReports] CHECK CONSTRAINT [FK_SupplierReports_AspNetUsers_AccountID]
GO
ALTER TABLE [dbo].[SupplierReports]  WITH CHECK ADD  CONSTRAINT [FK_SupplierReports_Staffs_StaffID] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staffs] ([StaffID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SupplierReports] CHECK CONSTRAINT [FK_SupplierReports_Staffs_StaffID]
GO
ALTER TABLE [dbo].[SupplierReports]  WITH CHECK ADD  CONSTRAINT [FK_SupplierReports_Suppliers_SupplierID] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SupplierReports] CHECK CONSTRAINT [FK_SupplierReports_Suppliers_SupplierID]
GO
ALTER TABLE [dbo].[SupplierRequests]  WITH CHECK ADD  CONSTRAINT [FK_SupplierRequests_Suppliers_SupplierID] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SupplierRequests] CHECK CONSTRAINT [FK_SupplierRequests_Suppliers_SupplierID]
GO
ALTER TABLE [dbo].[Suppliers]  WITH CHECK ADD  CONSTRAINT [FK_Suppliers_AspNetUsers_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Suppliers] CHECK CONSTRAINT [FK_Suppliers_AspNetUsers_AccountID]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Orders_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Orders_OrderID]
GO
ALTER TABLE [dbo].[Wishlists]  WITH CHECK ADD  CONSTRAINT [FK_Wishlists_AspNetUsers_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Wishlists] CHECK CONSTRAINT [FK_Wishlists_AspNetUsers_AccountID]
GO
ALTER TABLE [dbo].[Wishlists]  WITH CHECK ADD  CONSTRAINT [FK_Wishlists_Products_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Wishlists] CHECK CONSTRAINT [FK_Wishlists_Products_ProductID]
GO
USE [master]
GO
ALTER DATABASE [CameraCapstone] SET  READ_WRITE 
GO
