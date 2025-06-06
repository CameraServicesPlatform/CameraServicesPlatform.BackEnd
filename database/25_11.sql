USE [master]
GO
/****** Object:  Database [CameraCapstone]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11/25/2024 9:37:01 PM ******/
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
	[AccountBalance] [float] NULL,
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[Categories]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[Contracts]    Script Date: 11/25/2024 9:37:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contracts](
	[ContractID] [uniqueidentifier] NOT NULL,
	[OrderID] [uniqueidentifier] NOT NULL,
	[ContractTemplateId] [uniqueidentifier] NOT NULL,
	[ContractTerms] [nvarchar](max) NOT NULL,
	[TemplateDetails] [nvarchar](max) NOT NULL,
	[PenaltyPolicy] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Contracts] PRIMARY KEY CLUSTERED 
(
	[ContractID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractTemplates]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[DeliveriesMethod]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[HistoryTransactions]    Script Date: 11/25/2024 9:37:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryTransactions](
	[HistoryTransactionId] [uniqueidentifier] NOT NULL,
	[AccountID] [nvarchar](max) NOT NULL,
	[Price] [float] NOT NULL,
	[TransactionDescription] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[StaffID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_HistoryTransactions] PRIMARY KEY CLUSTERED 
(
	[HistoryTransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 11/25/2024 9:37:01 PM ******/
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
	[PeriodRental] [datetime2](7) NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/25/2024 9:37:01 PM ******/
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
	[Deposit] [float] NULL,
	[AccountId] [nvarchar](450) NULL,
	[OrderDetailID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[Policies]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[ProductImages]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[ProductReports]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 11/25/2024 9:37:01 PM ******/
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
	[DepositProduct] [float] NULL,
	[Brand] [int] NULL,
	[Quality] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[Rating] [float] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSpecifications]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[ProductVouchers]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[Ratings]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[RentalPrices]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[Reports]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[Requests]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[ReturnDetails]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[Staffs]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[SupplierReports]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[SupplierRequests]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[Suppliers]    Script Date: 11/25/2024 9:37:01 PM ******/
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
	[Img] [nvarchar](max) NULL,
	[IsDisable] [bit] NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[Vourchers]    Script Date: 11/25/2024 9:37:01 PM ******/
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
/****** Object:  Table [dbo].[Wishlists]    Script Date: 11/25/2024 9:37:01 PM ******/
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241118180401_[updateHistoryTr]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241118201905_[update-OrderDetailPeriodRental]', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241120130851_[updateHistoryTra]', N'8.0.8')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'086b7a13-79af-4610-851d-204d9d84b865', N'STAFF', N'staff', N'086b7a13-79af-4610-851d-204d9d84b865')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1cf2de31-b0d8-4447-8f2f-c41df905a3a5', N'ADMIN', N'admin', N'1cf2de31-b0d8-4447-8f2f-c41df905a3a5')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'74bd6d3a-1119-449b-9743-3956d74e7575', N'SUPPLIER', N'supplier', N'74bd6d3a-1119-449b-9743-3956d74e7575')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9', N'MEMBER', N'member', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'46599f4a-abfc-452b-a93a-1cf43b73d1da', N'086b7a13-79af-4610-851d-204d9d84b865')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5f6a230e-10a9-4bfd-834a-63a5ab1348b1', N'086b7a13-79af-4610-851d-204d9d84b865')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'812cc63a-465b-43f5-a7cd-cc3dc893b45e', N'086b7a13-79af-4610-851d-204d9d84b865')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d', N'1cf2de31-b0d8-4447-8f2f-c41df905a3a5')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'43cc4051-949e-4c52-bec6-bda4bba42b75', N'1cf2de31-b0d8-4447-8f2f-c41df905a3a5')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5aa7ee73-acf3-4110-8f5f-b296738b102e', N'74bd6d3a-1119-449b-9743-3956d74e7575')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5dc31c52-da51-46cf-87a1-7dbd4c9887ae', N'74bd6d3a-1119-449b-9743-3956d74e7575')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8be335d3-1fd1-4cc6-8835-138dbee72ef5', N'74bd6d3a-1119-449b-9743-3956d74e7575')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7866acb7-545c-42f4-b825-429d75a5779d', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b2e9498d-1c18-4706-b9f9-7ccf2b07a11a', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b66da413-3ca0-4b25-b47b-f07491ebabe4', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b90c7621-f60f-4476-9bac-c340b07cd1f8', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e932e8a4-ec5d-4004-90c5-f4dff359c76d', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2763dcc8-0b30-4c4a-b088-f7ee028b6443', 0, N'0862448677', N'Duy', N'Phạm Nhật', 0, NULL, 0, 0, 0, NULL, N'ac2418', NULL, NULL, NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/cards%2F029681a6-86cf-4168-b1be-14ffe791b9c5_front.jpg.png?alt=media&token=0799b0a6-a25d-45d4-9292-9f84a97f86d0', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/cards%2F1d467e5b-8f34-453c-ab89-b080f97271b9_back.jpg.png?alt=media&token=992267b1-5094-47c1-8d3c-7e4b21425ce8', NULL, NULL, NULL, 8000000, N'duypnse173520@fpt.edu.vn', N'DUYPNSE173520@FPT.EDU.VN', N'duypnse173520@fpt.edu.vn', N'DUYPNSE173520@FPT.EDU.VN', N'AQAAAAIAAYagAAAAEA0PDcnOc+Vbl4T2SQzxvezeS32D+vXuPKWMrDTf01hJatrudcJPeKboHf6Q/+l7tA==', N'33ASIQHUMGOZE7EPF7T64KFYNY2XCQKA', N'21bc6143-0596-4328-8c36-a1402d2ffd05', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d', 1, N'0817363768', N'Dương', N'An', 2, 0, 1, 0, 1, NULL, NULL, N'vivqC8YbgsW+C6BznujiKeTQIbfBdTPZqYRKi92DWvvFFqbBP/X6BzEag3/rvF4mqe6xORmb62uy9/pappZZRA==', CAST(N'2024-11-26T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d.jpg.png?alt=media&token=23945841-cdd8-4749-b182-226ad0719ec6', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d.jpg.png?alt=media&token=2cbeec4c-de25-4d12-aa90-7573b92dd334', N'TPBANK', N'0999447788', N'Duong Binh An', 353000000, N'andbse161205@fpt.edu.vn', N'ANDBSE161205@FPT.EDU.VN', N'andbse161205@fpt.edu.vn', N'ANDBSE161205@FPT.EDU.VN', N'AQAAAAIAAYagAAAAEAiGgaTeN1Pard3vBXzBQb9+okXC3eWP352mc/IJ/88PLkA2on7wXiZD0c7z/CzZMw==', N'ZVCENTNELDO3EXYRJRMXD6IUGIDCJLIV', N'b8f3c4ac-9c0d-48c6-acae-a0bfcffe1b8d', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'43cc4051-949e-4c52-bec6-bda4bba42b75', 1, N'0901234565', N'Đinh', N'Hoài Linh', 1, 2, 1, 0, 1, NULL, NULL, N'FiUdT2rk9zr33zz8q4OZpTDJRZw0GPZ3fNtGhoKgpVKyZKOKuVJkkiZETdcHxppETy2xqWlyL0uCwWjJrtfdWg==', CAST(N'2024-11-26T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F43cc4051-949e-4c52-bec6-bda4bba42b75.jpg.png?alt=media&token=e12d1f97-441b-47b0-b403-fd845cbb8128', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F43cc4051-949e-4c52-bec6-bda4bba42b75.jpg.png?alt=media&token=ba71fd93-64ef-4859-894d-928601bfbe1f', N'TP BANK', N'074415588952', N'Dinh Hoai Linh', NULL, N'dinhhoailinh@gmail.com', N'DINHHOAILINH@GMAIL.COM', N'dinhhoailinh@gmail.com', N'DINHHOAILINH@GMAIL.COM', N'AQAAAAIAAYagAAAAEBM94Wv9+CHuWBytY9TOELYkRAaWnow+ISHBLl2Ngj5bDNLwOLHQdKCiNKBwm8feqw==', N'2FNARJ34AANKJ2PF5NMJ4YTDOUURDEA6', N'ca4517f5-f4bc-4ec8-b2fc-3a4915b4d71a', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'46599f4a-abfc-452b-a93a-1cf43b73d1da', 0, N'0901234568', N'Lê', N'Thị Kim Anh', 1, 1, 2, 0, 1, NULL, NULL, N'2F70N7IqXhbtSodB7QQARDgq4skd5zh93JC/m11ylwRwv05ngqagUyw9Ic0HwkSONX0pn27TCHVIQPGW+zYAjw==', CAST(N'2024-11-26T00:00:00.0000000' AS DateTime2), NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/staff%2F46599f4a-abfc-452b-a93a-1cf43b73d1da.jpg.png?alt=media&token=557b29a8-5291-4ecb-82bb-99117e659ebd', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F46599f4a-abfc-452b-a93a-1cf43b73d1da.jpg.png?alt=media&token=aa1eb2fb-4456-405c-bf93-2f6f60084c56', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F46599f4a-abfc-452b-a93a-1cf43b73d1da.jpg.png?alt=media&token=0ab3c4c1-d08d-4b4b-89e3-33beb6b69cca', NULL, NULL, NULL, NULL, N'lethikimanh@gmail.com', N'LETHIKIMANH@GMAIL.COM', N'lethikimanh@gmail.com', N'LETHIKIMANH@GMAIL.COM', N'AQAAAAIAAYagAAAAELilRwukxU3CUDSGBvSB4PUd4dp0J4ad+hprRh4QTMQLg1D7+DSbK6X41RTNOL+few==', N'WZUZOMM34TB75NXB2GXWUTKJ2XOMGGMB', N'ce919b59-eed6-431a-9a5b-e81f024b191f', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4ca7c186-8c45-4d88-a3e0-865ce8e7e653', 1, N'0901234567', N'Đỗ', N'Đức Mạnh', NULL, NULL, 1, 0, 1, NULL, N'218a84', N'CoVfIZntgYIsZPB6kXIH91i71ACy0HyDyyQQjUW7royUgd4VEi0x5vRvBrjCDGQtNVdlrA0LVFj2z9xGSFmnHDg==', CAST(N'2024-10-19T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'doducmanh@gmail.com', N'DODUCMANH@GMAIL.COM', N'doducmanh@gmail.com', N'DODUCMANH@GMAIL.COM', N'AQAAAAIAAYagAAAAEAYFe+aN4yyPNdDlG+FhjZzqa3RDwUTLL7VtPYynFsZUmCmlPz7ZRMX27YHP3/9e9g==', N'SH3EWSUP2Z7ZOFGQRXWQEZSRU52KRLVK', N'12e78545-73d8-41ab-bb76-7e50ef8b7af9', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5aa7ee73-acf3-4110-8f5f-b296738b102e', 1, N'0977445511', N'Nikon', N'VietNam', 2, 2, 1, 0, 1, NULL, NULL, N'iSH3IvPawO0kXMSsGu/QqXhK/CwfCwuZzsJN9PGx77jDbtK00sYd0wLlAerCCOq7oRTXApWiK4HwIuS25SaYjQ==', CAST(N'2024-11-26T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F5aa7ee73-acf3-4110-8f5f-b296738b102e.jpg.png?alt=media&token=b2a31793-979f-40c3-b040-79d894515262', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F5aa7ee73-acf3-4110-8f5f-b296738b102e.jpg.png?alt=media&token=84ef6a67-c30c-4b2f-8681-f476e85fbc92', N'Ngân hàng TMCP Công thương Việt Nam', N'0914758856', N'Nguyen Van A', 879899800, N'nguyenvana@gmail.com', N'NGUYENVANA@GMAIL.COM', N'nguyenvana@gmail.com', N'NGUYENVANA@GMAIL.COM', N'AQAAAAIAAYagAAAAEMS8jV6m1b4U0hN5lWuyH4NF8WpAW5VSvEZdiiHpSVs/TZaig5zyL9YlapmF3E2FyA==', N'24VLUS2XUKJE5OAZOLMUZOSZZAECNKI2', N'c6675108-c3f4-48b8-98a8-c63ef8a5a3f5', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5dc31c52-da51-46cf-87a1-7dbd4c9887ae', 1, N'07864842', N'lbacojq', N'Doris', NULL, NULL, 0, 0, 1, NULL, NULL, N'gUr20QBuWvyc1IYbreYNhSaLjhb9tyB4PKopQnWn0Wz17xXc7OlxBWLOG+sBAYezyJcjWXx9RkYIta9oB/Q4FQ==', CAST(N'2024-11-02T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2Fbada24a5-dd25-4a2a-af6a-2698751f6126_front.jpg.png?alt=media&token=b2e23f01-af8a-4596-afb2-73e78e97c2d0', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F06b4b5a4-623d-4625-867b-2b640f7b4b42_back.jpg.png?alt=media&token=e4d819df-88c1-4597-abf6-111323e2332e', N'Ngân hàng TMCP Phương Đông', N'0914758856', N'Nguyen Van A', NULL, N'lbacojq091@tmail3.com', N'LBACOJQ091@TMAIL3.COM', N'lbacojq091@tmail3.com', N'LBACOJQ091@TMAIL3.COM', N'AQAAAAIAAYagAAAAEJnZ2aBMXftpXaiYaMUCXz3KklZSBh25N/MKpLKswwypAK91bk4zdg49JucPZjUuxg==', N'C4HWE22NWYGIC7RWRCRMK5HNAT2HNR3P', N'cc4ebd0e-370e-4d5e-906a-f08caead4868', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5f6a230e-10a9-4bfd-834a-63a5ab1348b1', 0, N'08875498', N'Duy', N'Phạm', NULL, NULL, 0, 0, 1, NULL, NULL, N'nXgUnsyXUnsyhxUd7pI1eExrfEAYXa2pMAGWapV8ulDeehpvgL8FDGptg6fr6Uvsc1b83B1Rlb6ismgofvIPBg==', CAST(N'2024-11-26T00:00:00.0000000' AS DateTime2), NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/staff%2F5f6a230e-10a9-4bfd-834a-63a5ab1348b1.jpg.png?alt=media&token=ef1e5fef-f5b2-4076-bdc4-91c2bcf0f45d', NULL, NULL, NULL, NULL, NULL, NULL, N'riyevim925@gitated.com', N'RIYEVIM925@GITATED.COM', N'riyevim925@gitated.com', N'RIYEVIM925@GITATED.COM', N'AQAAAAIAAYagAAAAEBE38MlztW1fxwzP2eJpJSb9QR+VX71jFsY+h0WM+HFOWIKe7AJ12p0DnCU05VUT7Q==', N'ELLQ3JZTCHQ7Z72P4ZAN2BR4UX4KDLDW', N'91eabb32-8506-4ad5-859d-52b9e9702a81', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7866acb7-545c-42f4-b825-429d75a5779d', 1, N'0987654321', N'Hau', N'Do Kim', NULL, NULL, 0, 0, 1, NULL, NULL, N'ZNDbf/Sa36TwReRlUhQJE35q2Zf2CZ2ZSPrIWBeXwOCA41/D7yot72KrAtaIXbRP+IDzOu4a9J2ABxkXYn/T3w==', CAST(N'2024-11-26T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2Fc1c8d965-bc92-4559-879f-268679b8dc17_front.jpg.png?alt=media&token=fcdf1a00-fa07-4d4f-a5cd-6e4d1cf48712', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F9fc39917-c0b8-4eb3-835f-694b32a441c5_back.jpg.png?alt=media&token=6dab91fc-3257-46f6-8b84-11910d78e492', NULL, NULL, NULL, NULL, N'dokimhau476@gmail.com', N'DOKIMHAU476@GMAIL.COM', N'dokimhau476@gmail.com', N'DOKIMHAU476@GMAIL.COM', N'AQAAAAIAAYagAAAAEGdNuimE7wrtIxvJihLZJ/TFjYqFAEXKBxCPAoxoT9c2XLmHhAZY0Nw+iL3cci3QZA==', N'OTMTEVAXRZYM5SNDEEXXWBBOCMKIANI3', N'd3bb661e-f951-49ce-bc24-a1c422fc3740', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'812cc63a-465b-43f5-a7cd-cc3dc893b45e', 0, N'0944557741', N'Staff1', N' new', NULL, NULL, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/staff%2F812cc63a-465b-43f5-a7cd-cc3dc893b45e.png?alt=media&token=0060a735-ae14-4ca7-88ea-6614724aa6b6', NULL, NULL, NULL, NULL, NULL, NULL, N'xorak17929@aqqor.com', N'XORAK17929@AQQOR.COM', N'xorak17929@aqqor.com', N'XORAK17929@AQQOR.COM', N'AQAAAAIAAYagAAAAEHLF0/RBv8HT2bqjPt9vVdcHkw3kPrEWdlTVTYu6jBGU/l24UKYBTIkZD3mXGNl98g==', N'6675HO7CS5SLJMMR3J6U6VMO3AHEPJ6A', N'f21cebd9-1c86-4c5b-8df2-efe5128f7077', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8b6c5937-00ed-4d95-96d3-1d83c0599dc8', 0, N'0999999999', N'Perdita', N'Googe', NULL, NULL, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/staff%2F8b6c5937-00ed-4d95-96d3-1d83c0599dc8.png?alt=media&token=f2b2edf3-f8c4-4619-8d10-5c1f3f298586', NULL, NULL, NULL, NULL, NULL, NULL, N'teledon801@aleitar.com', N'TELEDON801@ALEITAR.COM', N'teledon801@aleitar.com', N'TELEDON801@ALEITAR.COM', N'AQAAAAIAAYagAAAAEAOubtxEZKH+hM5adye+/L9IsMOdQP9m0laRyf1itxM3Ca7/cp1cNeljnIs8SGU2YQ==', N'YZ5KT6TF2BSH45J7AAXHS2FROCPO5S3U', N'44781689-b9c2-415c-8dc0-3b3a97698f07', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8be335d3-1fd1-4cc6-8835-138dbee72ef5', 1, N'085745557799', N'Canon', N'VietNam', 1, 0, 1, 0, 1, NULL, NULL, N'+BfQhwSaAMuVuQnfsIoTxzOQNqWXh4MZ/0EXgZieSICOacyWW/fWIyRkLbnDc/FHc5mp41ehgdmW60IQWu4VTw==', CAST(N'2024-11-26T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F8be335d3-1fd1-4cc6-8835-138dbee72ef5.jpg.png?alt=media&token=302cc3d0-521b-4c0b-be5b-401a1215e6ce', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F8be335d3-1fd1-4cc6-8835-138dbee72ef5.jpg.png?alt=media&token=804f1b96-e975-405c-9a1a-29c1e08ef6e8', N'Ngân hàng TMCP Phương Đông', N'0914758856', N'N8574555779B', NULL, N'nguyenvanb@gmail.com', N'NGUYENVANB@GMAIL.COM', N'nguyenvanb@gmail.com', N'NGUYENVANB@GMAIL.COM', N'AQAAAAIAAYagAAAAEPaYLtCeXVls8jDQjNaQX6P+4U8oU4LyTx3UEUbwJtWIlBxMSusv8sk5rK33PhH0CA==', N'P345SJO5R4ZIILRAMRSHEDERD2ZCCF62', N'98788936-9fa0-4167-902b-17578596d1c7', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'94e03446-55bb-4774-8335-edd00fcb3d02', 0, N'0901234569', N'Nguyễn', N'Tiến Đạt', NULL, NULL, 0, 0, 0, NULL, NULL, N'vC0I2+M7XXGZkH38ACwLgl40WGeSPT3cF8D7eVvZ1V52EwFRXVP6DcuRW6OM4k7Gk5SKX8rZAC+An2qCkh04og==', CAST(N'2024-10-19T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'ntdat117@gmail.com', N'NTDAT117@GMAIL.COM', N'ntdat117@gmail.com', N'NTDAT117@GMAIL.COM', N'AQAAAAIAAYagAAAAEJ6g+szEZp73wf9Z8O3lA7n5ydD7kPRD1P9qTDl3ZKkShG9oNeZkjH6SPN9kFY/mS4A==', N'X7SQCPAGFEMGUMPK4JW4YYBWZZYAYX2X', N'b10a3b18-5860-43a9-baba-efb4f41b7d03', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b2e9498d-1c18-4706-b9f9-7ccf2b07a11a', 1, N'0865447899', N'Di', N'Di', NULL, NULL, 0, 0, 1, NULL, NULL, N'RpwwqQazne48UFtnRqLp9bUAl5kkiPjmqHJ8PJt/3eiXE483ug0CPZiGwGCI7BV0PODJN7hXAqh6U8tSes6eIw==', CAST(N'2024-11-26T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2Fb8a55c32-e2c3-4b51-924f-4b93c97dc9c2_front.jpg.png?alt=media&token=6b8b7de0-df10-4e7e-89e7-88718b06c7d5', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F8c2dc3d3-8007-4f03-880e-5d7ae9b50a67_back.jpg.png?alt=media&token=b1cdcd34-7db7-475f-9d6d-843f798e0848', NULL, NULL, NULL, NULL, N'biloyid842@cpaurl.com', N'BILOYID842@CPAURL.COM', N'biloyid842@cpaurl.com', N'BILOYID842@CPAURL.COM', N'AQAAAAIAAYagAAAAEP1N9HQZMLUVjFsYHIQlWzzFKJHXCbJA7r9fFbD+H97/psbIXam64+JOyjxoMEauyg==', N'REIKUA3ZIKQFIVLCPMGLKYNP2QGRZV7H', N'5c373b0c-ccfc-4ed7-a12a-5ca5348d3c61', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b66da413-3ca0-4b25-b47b-f07491ebabe4', 0, N'0874551236', N'Di', N'Di', NULL, NULL, 1, 0, 0, NULL, N'3e426a', NULL, NULL, NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F6e73b724-b68d-4f7a-a83a-2bf2cde4a8bf_front.jpg.png?alt=media&token=693cdb64-cf42-4c65-a66a-f1754b53d3ea', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F1c694443-c9ac-4212-9199-b333a61a7042_back.jpg.png?alt=media&token=4a924235-634d-4433-aad8-9c2677a72166', NULL, NULL, NULL, NULL, N'nejaco9750@cpaurl.com', N'NEJACO9750@CPAURL.COM', N'nejaco9750@cpaurl.com', N'NEJACO9750@CPAURL.COM', N'AQAAAAIAAYagAAAAECamR5ONyMVuufk6iPWa9Y20d/FP2eH3HKM4vPyeMK7WSOWKQAeurjn+xZWYi+8CRA==', N'LPZCVFUGCFLVF4Z5RU6VAKBSMMTAG23T', N'94f57b74-8442-4144-bb2d-138e0a880fd5', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b90c7621-f60f-4476-9bac-c340b07cd1f8', 1, N'0817114455', N'Duong ', N'Hoang Anh', 1, 1, 2, 0, 1, NULL, NULL, N'KIT933ExeStFfrW1NYs/YMY3K1WElCARz4150DA850mGheYRCXNEskITb/OBL7yezjgTgrg7z2kAkfH3Voph0A==', CAST(N'2024-11-26T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F5901a76e-21ca-4208-bcb8-7d981df0a901_front.jpg.png?alt=media&token=4cc9d60d-2101-4c1c-89db-c02565a290e9', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2Fe0403132-6e92-4728-85a7-4b123a24f3d1_back.jpg.png?alt=media&token=5bbd0727-3efe-4532-b138-f03cb2cf864f', N'TPBANK', N'0944517899', N'Duong Hoang Anh', NULL, N'fideve8291@exoular.com', N'FIDEVE8291@EXOULAR.COM', N'fideve8291@exoular.com', N'FIDEVE8291@EXOULAR.COM', N'AQAAAAIAAYagAAAAEPj4XSbyAVlGTbYOjEsgPBf4DQgWs0IVa3pIjUZYAO/KznKzV+3fe05QhhKJy559Fw==', N'MH6XYOVP7QHI3SX54YBWATI52J2SME3G', N'bc1fb318-d147-476f-92e7-86f80ffc5536', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [AccountBalance], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e932e8a4-ec5d-4004-90c5-f4dff359c76d', 1, N'0862447511', N'Trúc', N'Nguyễn Thị Anh', NULL, NULL, 1, 0, 1, NULL, NULL, N'kwBH+MbU/oVZL1abTzn30p+mYdbumeXiFUoOL3/mAr0ukte/9xKq6wygfGlnDcsUUbngkx+grg9W+stO4se7Ag==', CAST(N'2024-11-25T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F0198084a-89a3-4c69-8f8d-fb689d900467_front.jpg.png?alt=media&token=30a2db09-a948-4834-92bf-0180c42f2e7e', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F1d65f29d-b917-4546-b30a-bd4b65a80d63_back.jpg.png?alt=media&token=9c930f12-fa56-40ed-be9e-cb2dcd0a1767', NULL, NULL, NULL, NULL, N'trucntase160078@fpt.edu.vn', N'TRUCNTASE160078@FPT.EDU.VN', N'trucntase160078@fpt.edu.vn', N'TRUCNTASE160078@FPT.EDU.VN', N'AQAAAAIAAYagAAAAEPo7q87ru/lm3foFvCerp7E6iL6TorKHDfp0bDGUHd9HXNKnQpkWD37Snl9uExOW9g==', N'E5SMDYWZRVHIBZ5TLXPOZXNZSKSLM26H', N'5fc45f2a-916d-47d1-aba1-2089145de84a', 0, 0, NULL, 1, 0)
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
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt]) VALUES (N'3d585c1a-e582-493f-85e2-08dd0d01e546', N'daf987ba-be3b-43d5-890f-639d804ba2b1', N'024b406b-6e57-4953-916e-08dd0cf5483e', N'Quy định về thanh toán chi phí thuê và chính sách hoàn trả.', N'Bên thuê cần thanh toán đầy đủ trước khi nhận thiết bị. Nếu trả sớm hơn thời hạn, sẽ không được hoàn lại tiền.', N'Nếu không thanh toán đúng hạn, hợp đồng sẽ bị hủy mà không hoàn lại tiền.', CAST(N'2024-11-25T10:33:14.9167253' AS DateTime2), CAST(N'2024-11-25T10:33:14.9167698' AS DateTime2))
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt]) VALUES (N'f52cb7f4-5991-4bc8-85e3-08dd0d01e546', N'daf987ba-be3b-43d5-890f-639d804ba2b1', N'03c1317a-ff68-40e3-916f-08dd0cf5483e', N'Thông tin cá nhân của khách hàng sẽ được bảo mật tuyệt đối.', N'Bên cho thuê cam kết không tiết lộ bất kỳ thông tin cá nhân nào của khách hàng cho bên thứ ba nếu không có sự đồng ý.', N'Nếu bên cho thuê tiết lộ thông tin, sẽ chịu trách nhiệm theo pháp luật.', CAST(N'2024-11-25T10:33:14.9379345' AS DateTime2), CAST(N'2024-11-25T10:33:14.9379460' AS DateTime2))
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt]) VALUES (N'53d4ad82-15bc-4791-85e4-08dd0d01e546', N'daf987ba-be3b-43d5-890f-639d804ba2b1', N'753e72fa-f5b1-4b7d-9170-08dd0cf5483e', N'Bên thuê có thể hủy hợp đồng trước thời hạn nhưng phải báo trước ít nhất 24 giờ.', N'Nếu bên thuê hủy hợp đồng mà không báo trước hoặc báo quá trễ, sẽ phải chịu phí bồi thường theo quy định.', N'Phí hủy hợp đồng là 10% giá trị thuê nếu không báo trước 24 giờ.', CAST(N'2024-11-25T10:33:14.9388224' AS DateTime2), CAST(N'2024-11-25T10:33:14.9388257' AS DateTime2))
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt]) VALUES (N'61c96ec3-c44a-4364-85e5-08dd0d01e546', N'daf987ba-be3b-43d5-890f-639d804ba2b1', N'a0626be9-fbde-4daf-9171-08dd0cf5483e', N'Thời gian thuê máy ảnh được quy định rõ ràng và cam kết trả đúng hạn.', N'Thời gian thuê bắt đầu từ thời điểm nhận máy đến thời điểm trả máy đã thỏa thuận trước. Bên thuê chịu trách nhiệm trả máy đúng hạn, nếu không sẽ bị xử phạt theo quy định.', N'Phạt 5% giá trị hợp đồng mỗi giờ trả muộn.', CAST(N'2024-11-25T10:33:14.9389025' AS DateTime2), CAST(N'2024-11-25T10:33:14.9389037' AS DateTime2))
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt]) VALUES (N'3afef120-682c-441d-85e6-08dd0d01e546', N'daf987ba-be3b-43d5-890f-639d804ba2b1', N'1a6e2732-1db0-45db-9172-08dd0cf5483e', N'Bên thuê có trách nhiệm bảo quản máy ảnh trong suốt thời gian thuê.', N'Trong suốt thời gian thuê, bên thuê phải bảo quản thiết bị tránh các tác động vật lý, nước, và các yếu tố gây hư hại khác.', N'Nếu máy ảnh bị hỏng, bên thuê phải chịu chi phí sửa chữa hoặc bồi thường theo giá trị thiết bị.', CAST(N'2024-11-25T10:33:14.9390205' AS DateTime2), CAST(N'2024-11-25T10:33:14.9390221' AS DateTime2))
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt]) VALUES (N'5ef49d7c-979e-43ad-85e7-08dd0d01e546', N'6006f504-63e5-467b-a106-5f254b116e81', N'a8ff0e7f-ef7c-4373-0137-08dd033c8059', N'string', N'string', N'string', CAST(N'2024-11-25T13:25:07.1768854' AS DateTime2), CAST(N'2024-11-25T13:25:07.1768936' AS DateTime2))
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt]) VALUES (N'0cd68340-ed11-4f91-85e8-08dd0d01e546', N'6006f504-63e5-467b-a106-5f254b116e81', N'6dc96be6-62fb-4c5b-6d59-08dd0404aaae', N'Thời gian thuê máy ảnh được quy định rõ ràng và cam kết trả đúng hạn.', N'Thời gian thuê bắt đầu từ thời điểm nhận máy đến thời điểm trả máy đã thỏa thuận trước. Bên thuê chịu trách nhiệm trả máy đúng hạn, nếu không sẽ bị xử phạt theo quy định.', N'Phạt 5% giá trị hợp đồng mỗi giờ trả muộn.', CAST(N'2024-11-25T13:25:07.1774625' AS DateTime2), CAST(N'2024-11-25T13:25:07.1774649' AS DateTime2))
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt]) VALUES (N'c2500736-8083-4fe2-85e9-08dd0d01e546', N'6006f504-63e5-467b-a106-5f254b116e81', N'5e1ffd65-a604-4328-6d5a-08dd0404aaae', N'Bên thuê có trách nhiệm bảo quản máy ảnh trong suốt thời gian thuê.', N'Trong suốt thời gian thuê, bên thuê phải bảo quản thiết bị tránh các tác động vật lý, nước, và các yếu tố gây hư hại khác.', N'Nếu máy ảnh bị hỏng, bên thuê phải chịu chi phí sửa chữa hoặc bồi thường theo giá trị thiết bị.', CAST(N'2024-11-25T13:25:07.1777342' AS DateTime2), CAST(N'2024-11-25T13:25:07.1777362' AS DateTime2))
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt]) VALUES (N'5797dcd0-9b2f-46ea-85ea-08dd0d01e546', N'6006f504-63e5-467b-a106-5f254b116e81', N'c0f285af-41cd-4647-6d5b-08dd0404aaae', N'Thiết bị chỉ được sử dụng cho mục đích ghi hình và không được sử dụng vào các mục đích khác ngoài hợp đồng.', N'Bên thuê cam kết chỉ sử dụng thiết bị cho các mục đích ghi hình, không cho bên thứ ba thuê lại hoặc sử dụng vào mục đích trái phép.', N'Nếu bên thuê sử dụng không đúng mục đích, sẽ bị phạt 15% giá trị hợp đồng.', CAST(N'2024-11-25T13:25:07.1778318' AS DateTime2), CAST(N'2024-11-25T13:25:07.1778335' AS DateTime2))
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt]) VALUES (N'0e3ee996-b0fd-4c5b-85eb-08dd0d01e546', N'6006f504-63e5-467b-a106-5f254b116e81', N'a9aed02c-c76b-43fa-6d5c-08dd0404aaae', N'Bên thuê có thể hủy hợp đồng trước thời hạn nhưng phải báo trước ít nhất 24 giờ.', N'Nếu bên thuê hủy hợp đồng mà không báo trước hoặc báo quá trễ, sẽ phải chịu phí bồi thường theo quy định.', N'Phí hủy hợp đồng là 10% giá trị thuê nếu không báo trước 24 giờ.', CAST(N'2024-11-25T13:25:07.1780086' AS DateTime2), CAST(N'2024-11-25T13:25:07.1780104' AS DateTime2))
INSERT [dbo].[Contracts] ([ContractID], [OrderID], [ContractTemplateId], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt]) VALUES (N'8cbaf560-3251-4acb-85ec-08dd0d01e546', N'6006f504-63e5-467b-a106-5f254b116e81', N'907734ce-b948-4d9e-6d5d-08dd0404aaae', N'Bên cho thuê cam kết bảo hành thiết bị trong điều kiện bình thường.', N'Trong trường hợp thiết bị gặp lỗi do bên cho thuê, sẽ có chính sách hỗ trợ đổi máy hoặc sửa chữa.', N'Không áp dụng phạt đối với các lỗi kỹ thuật từ phía bên cho thuê.', CAST(N'2024-11-25T13:25:07.1780775' AS DateTime2), CAST(N'2024-11-25T13:25:07.1780787' AS DateTime2))
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
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'e8fbbcad-7b43-4ae5-6d89-08dd0404aaae', N'Hợp đồng thuê theo ngày 1', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'1', N'a', N'a', CAST(N'2024-11-13T22:35:46.4732895' AS DateTime2), CAST(N'2024-11-13T22:35:46.4732896' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'4cf8f043-d082-4773-65bd-08dd0c9c0748', N'Hợp đồng thuê theo ngày', N'45dc7060-6b22-420b-b4a4-1329e420e3bd', N'Thuê theo ngày với thời gian tối thiểu 1 ngày và tối đa 3 ngày.', N'Dịch vụ thuê theo ngày. Khách hàng có trách nhiệm hoàn trả dịch vụ đúng thời hạn.', N'Phạt 15% giá thuê nếu trả quá hạn, tối đa 1 ngày thêm.', CAST(N'2024-11-24T15:24:03.3070086' AS DateTime2), CAST(N'2024-11-24T15:24:03.3070087' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'd2ea4f26-8782-4799-65be-08dd0c9c0748', N'Thời hạn thuê', N'45dc7060-6b22-420b-b4a4-1329e420e3bd', N'Thời gian thuê máy ảnh được quy định rõ ràng và cam kết trả đúng hạn.', N'Thời gian thuê bắt đầu từ thời điểm nhận máy đến thời điểm trả máy đã thỏa thuận trước. Bên thuê chịu trách nhiệm trả máy đúng hạn, nếu không sẽ bị xử phạt theo quy định.', N'Phạt 5% giá trị hợp đồng mỗi giờ trả muộn.', CAST(N'2024-11-24T15:24:51.0203805' AS DateTime2), CAST(N'2024-11-24T15:24:51.0203808' AS DateTime2), N'5aa7ee73-acf3-4110-8f5f-b296738b102e')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'fb135a79-c1bf-48bc-65bf-08dd0c9c0748', N'Hợp đồng thuê theo giờ', N'45dc7060-6b22-420b-b4a4-1329e420e3bd', N'Thuê theo giờ với tối thiểu 2 giờ và tối đa 4 giờ.', N'Dịch vụ cho thuê theo giờ. Mức giá cố định mỗi giờ. Khách hàng phải tuân thủ thời gian đã ký kết.', N'Phạt 10% giá thuê nếu trả quá giờ đã ký. Thời gian quá giờ tối đa 1 giờ.', CAST(N'2024-11-24T15:25:00.8215497' AS DateTime2), CAST(N'2024-11-24T15:25:00.8215499' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'f27d44e0-ce5f-47ff-65c0-08dd0c9c0748', N'Hợp đồng thuê theo tháng', N'45dc7060-6b22-420b-b4a4-1329e420e3bd', N'Thuê theo tháng, áp dụng thuê tối đa 1 tháng.', N'Dịch vụ thuê theo tháng với chi phí cố định. Khách hàng phải đảm bảo dịch vụ không bị gián đoạn.', N'Phạt 25% giá thuê nếu vi phạm thời hạn trả hợp đồng.', CAST(N'2024-11-24T15:25:12.4983102' AS DateTime2), CAST(N'2024-11-24T15:25:12.4983107' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'd75ff4c4-ed4f-4c2e-915d-08dd0cf5483e', N'Thỏa thuận về bảo mật thông tin', N'3778b7a9-e3a2-4a6d-9033-64bc8d94860d', N'Thông tin cá nhân của khách hàng sẽ được bảo mật tuyệt đối.', N'Bên cho thuê cam kết không tiết lộ bất kỳ thông tin cá nhân nào của khách hàng cho bên thứ ba nếu không có sự đồng ý.', N'Nếu bên cho thuê tiết lộ thông tin, sẽ chịu trách nhiệm theo pháp luật.', CAST(N'2024-11-25T02:02:57.5007371' AS DateTime2), CAST(N'2024-11-25T02:02:57.5007372' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'94131bbf-3c6b-4816-915e-08dd0cf5483e', N'Cam kết về bảo dưỡng thiết bị', N'3778b7a9-e3a2-4a6d-9033-64bc8d94860d', N'Thiết bị sẽ được bảo dưỡng định kỳ trước khi cho thuê.', N'Bên cho thuê cam kết kiểm tra và bảo dưỡng thiết bị định kỳ, đảm bảo chất lượng sử dụng.', N'Nếu thiết bị gặp lỗi do không bảo dưỡng, bên cho thuê sẽ hỗ trợ thay thế không tính phí.', CAST(N'2024-11-25T02:03:11.2813946' AS DateTime2), CAST(N'2024-11-25T02:03:11.2813947' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'ca5c604c-ea04-4d21-915f-08dd0cf5483e', N'Thanh toán và hoàn trả', N'3778b7a9-e3a2-4a6d-9033-64bc8d94860d', N'Quy định về thanh toán chi phí thuê và chính sách hoàn trả.', N'Bên thuê cần thanh toán đầy đủ trước khi nhận thiết bị. Nếu trả sớm hơn thời hạn, sẽ không được hoàn lại tiền.', N'Nếu không thanh toán đúng hạn, hợp đồng sẽ bị hủy mà không hoàn lại tiền.', CAST(N'2024-11-25T02:03:17.3326768' AS DateTime2), CAST(N'2024-11-25T02:03:17.3326769' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'1cb57eb8-44ab-4fc8-9160-08dd0cf5483e', N'Quy định về sử dụng ngoài phạm vi', N'3778b7a9-e3a2-4a6d-9033-64bc8d94860d', N'Thiết bị chỉ được sử dụng trong phạm vi địa lý đã thỏa thuận.', N'Bên thuê không được mang thiết bị ra khỏi phạm vi đã thỏa thuận mà không được sự đồng ý của bên cho thuê.', N'Vi phạm phạm vi sử dụng sẽ bị phạt 20% giá trị hợp đồng.', CAST(N'2024-11-25T02:03:23.6960216' AS DateTime2), CAST(N'2024-11-25T02:03:23.6960217' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'8b1f1b85-8e49-492a-9161-08dd0cf5483e', N'Cam kết về bản quyền hình ảnh', N'3778b7a9-e3a2-4a6d-9033-64bc8d94860d', N'Bên thuê cam kết không vi phạm bản quyền khi sử dụng thiết bị.', N'Mọi nội dung ghi hình phải tuân thủ luật pháp về bản quyền. Bên thuê chịu trách nhiệm trước pháp luật nếu vi phạm.', N'Nếu có khiếu nại về bản quyền, bên thuê chịu trách nhiệm pháp lý hoàn toàn.', CAST(N'2024-11-25T02:03:36.4345256' AS DateTime2), CAST(N'2024-11-25T02:03:36.4345257' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'ab93bf4f-55c2-4a22-9162-08dd0cf5483e', N'Quy định về kiểm tra và bàn giao thiết bị', N'3778b7a9-e3a2-4a6d-9033-64bc8d94860d', N'Bên thuê có trách nhiệm kiểm tra thiết bị trước khi nhận.', N'Trước khi bàn giao, bên thuê cần xác nhận tình trạng thiết bị và ký xác nhận. Nếu có hỏng hóc phải thông báo ngay để được hỗ trợ.', N'Nếu bên thuê không kiểm tra và ký xác nhận, mọi hỏng hóc sau đó sẽ chịu trách nhiệm.', CAST(N'2024-11-25T02:03:45.9510480' AS DateTime2), CAST(N'2024-11-25T02:03:45.9510481' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'bbc99f7a-5267-4ebb-9163-08dd0cf5483e', N'Chính sách bảo hành và hỗ trợ', N'3778b7a9-e3a2-4a6d-9033-64bc8d94860d', N'Bên cho thuê cam kết bảo hành thiết bị trong điều kiện bình thường.', N'Trong trường hợp thiết bị gặp lỗi do bên cho thuê, sẽ có chính sách hỗ trợ đổi máy hoặc sửa chữa.', N'Không áp dụng phạt đối với các lỗi kỹ thuật từ phía bên cho thuê.', CAST(N'2024-11-25T02:03:54.7311038' AS DateTime2), CAST(N'2024-11-25T02:03:54.7311039' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'21311a8d-6264-4a85-9164-08dd0cf5483e', N'Quy định về hủy hợp đồng', N'3778b7a9-e3a2-4a6d-9033-64bc8d94860d', N'Bên thuê có thể hủy hợp đồng trước thời hạn nhưng phải báo trước ít nhất 24 giờ.', N'Nếu bên thuê hủy hợp đồng mà không báo trước hoặc báo quá trễ, sẽ phải chịu phí bồi thường theo quy định.', N'Phí hủy hợp đồng là 10% giá trị thuê nếu không báo trước 24 giờ.', CAST(N'2024-11-25T02:04:03.4459977' AS DateTime2), CAST(N'2024-11-25T02:04:03.4459978' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'7e8d94f8-8535-443f-9165-08dd0cf5483e', N'Thời hạn thuê', N'3778b7a9-e3a2-4a6d-9033-64bc8d94860d', N'Thời gian thuê máy ảnh được quy định rõ ràng và cam kết trả đúng hạn.', N'Thời gian thuê bắt đầu từ thời điểm nhận máy đến thời điểm trả máy đã thỏa thuận trước. Bên thuê chịu trách nhiệm trả máy đúng hạn, nếu không sẽ bị xử phạt theo quy định.', N'Phạt 5% giá trị hợp đồng mỗi giờ trả muộn.', CAST(N'2024-11-25T02:04:14.8824530' AS DateTime2), CAST(N'2024-11-25T02:04:14.8824531' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'040b7acf-e6ef-4eac-9166-08dd0cf5483e', N'Trách nhiệm bảo quản', N'3778b7a9-e3a2-4a6d-9033-64bc8d94860d', N'Bên thuê có trách nhiệm bảo quản máy ảnh trong suốt thời gian thuê.', N'Trong suốt thời gian thuê, bên thuê phải bảo quản thiết bị tránh các tác động vật lý, nước, và các yếu tố gây hư hại khác.', N'Nếu máy ảnh bị hỏng, bên thuê phải chịu chi phí sửa chữa hoặc bồi thường theo giá trị thiết bị.', CAST(N'2024-11-25T02:04:23.5338970' AS DateTime2), CAST(N'2024-11-25T02:04:23.5338971' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'c47579b5-604e-4e3e-9167-08dd0cf5483e', N'Trách nhiệm bảo quản', N'f3705778-aec9-4d92-8e8a-9944500e8854', N'Bên thuê có trách nhiệm bảo quản máy ảnh trong suốt thời gian thuê.', N'Trong suốt thời gian thuê, bên thuê phải bảo quản thiết bị tránh các tác động vật lý, nước, và các yếu tố gây hư hại khác.', N'Nếu máy ảnh bị hỏng, bên thuê phải chịu chi phí sửa chữa hoặc bồi thường theo giá trị thiết bị.', CAST(N'2024-11-25T02:04:41.4411763' AS DateTime2), CAST(N'2024-11-25T02:04:41.4411764' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'46297dc3-4287-4c3d-9168-08dd0cf5483e', N'Thời hạn thuê', N'f3705778-aec9-4d92-8e8a-9944500e8854', N'Thời gian thuê máy ảnh được quy định rõ ràng và cam kết trả đúng hạn.', N'Thời gian thuê bắt đầu từ thời điểm nhận máy đến thời điểm trả máy đã thỏa thuận trước. Bên thuê chịu trách nhiệm trả máy đúng hạn, nếu không sẽ bị xử phạt theo quy định.', N'Phạt 5% giá trị hợp đồng mỗi giờ trả muộn.', CAST(N'2024-11-25T02:04:50.9499270' AS DateTime2), CAST(N'2024-11-25T02:04:50.9499271' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'6edc7a56-f387-47fe-9169-08dd0cf5483e', N'Sử dụng thiết bị đúng mục đích', N'f3705778-aec9-4d92-8e8a-9944500e8854', N'Thiết bị chỉ được sử dụng cho mục đích ghi hình và không được sử dụng vào các mục đích khác ngoài hợp đồng.', N'Bên thuê cam kết chỉ sử dụng thiết bị cho các mục đích ghi hình, không cho bên thứ ba thuê lại hoặc sử dụng vào mục đích trái phép.', N'Nếu bên thuê sử dụng không đúng mục đích, sẽ bị phạt 15% giá trị hợp đồng.', CAST(N'2024-11-25T02:04:57.4225077' AS DateTime2), CAST(N'2024-11-25T02:04:57.4225079' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'd40f9ef9-d2b6-4845-916a-08dd0cf5483e', N'Quy định về hủy hợp đồng', N'f3705778-aec9-4d92-8e8a-9944500e8854', N'Bên thuê có thể hủy hợp đồng trước thời hạn nhưng phải báo trước ít nhất 24 giờ.', N'Nếu bên thuê hủy hợp đồng mà không báo trước hoặc báo quá trễ, sẽ phải chịu phí bồi thường theo quy định.', N'Phí hủy hợp đồng là 10% giá trị thuê nếu không báo trước 24 giờ.', CAST(N'2024-11-25T02:05:08.4394700' AS DateTime2), CAST(N'2024-11-25T02:05:08.4394701' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'c9d00da4-661d-41fb-916b-08dd0cf5483e', N'Thỏa thuận về bảo mật thông tin', N'f3705778-aec9-4d92-8e8a-9944500e8854', N'Thông tin cá nhân của khách hàng sẽ được bảo mật tuyệt đối.', N'Bên cho thuê cam kết không tiết lộ bất kỳ thông tin cá nhân nào của khách hàng cho bên thứ ba nếu không có sự đồng ý.', N'Nếu bên cho thuê tiết lộ thông tin, sẽ chịu trách nhiệm theo pháp luật.', CAST(N'2024-11-25T02:05:13.7146547' AS DateTime2), CAST(N'2024-11-25T02:05:13.7146548' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'aee40a7b-ef37-402a-916c-08dd0cf5483e', N'Cam kết về bảo dưỡng thiết bị', N'f3705778-aec9-4d92-8e8a-9944500e8854', N'Thiết bị sẽ được bảo dưỡng định kỳ trước khi cho thuê.', N'Bên cho thuê cam kết kiểm tra và bảo dưỡng thiết bị định kỳ, đảm bảo chất lượng sử dụng.', N'Nếu thiết bị gặp lỗi do không bảo dưỡng, bên cho thuê sẽ hỗ trợ thay thế không tính phí.', CAST(N'2024-11-25T02:05:19.0945179' AS DateTime2), CAST(N'2024-11-25T02:05:19.0945180' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'0ee87325-0a86-4350-916d-08dd0cf5483e', N'Thanh toán và hoàn trả', N'f3705778-aec9-4d92-8e8a-9944500e8854', N'Quy định về thanh toán chi phí thuê và chính sách hoàn trả.', N'Bên thuê cần thanh toán đầy đủ trước khi nhận thiết bị. Nếu trả sớm hơn thời hạn, sẽ không được hoàn lại tiền.', N'Nếu không thanh toán đúng hạn, hợp đồng sẽ bị hủy mà không hoàn lại tiền.', CAST(N'2024-11-25T02:05:33.0788057' AS DateTime2), CAST(N'2024-11-25T02:05:33.0788058' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'024b406b-6e57-4953-916e-08dd0cf5483e', N'Thanh toán và hoàn trả', N'30872065-d5c3-4abd-9f98-a52574d99fd0', N'Quy định về thanh toán chi phí thuê và chính sách hoàn trả.', N'Bên thuê cần thanh toán đầy đủ trước khi nhận thiết bị. Nếu trả sớm hơn thời hạn, sẽ không được hoàn lại tiền.', N'Nếu không thanh toán đúng hạn, hợp đồng sẽ bị hủy mà không hoàn lại tiền.', CAST(N'2024-11-25T02:05:52.4828689' AS DateTime2), CAST(N'2024-11-25T02:05:52.4828690' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'03c1317a-ff68-40e3-916f-08dd0cf5483e', N'Thỏa thuận về bảo mật thông tin', N'30872065-d5c3-4abd-9f98-a52574d99fd0', N'Thông tin cá nhân của khách hàng sẽ được bảo mật tuyệt đối.', N'Bên cho thuê cam kết không tiết lộ bất kỳ thông tin cá nhân nào của khách hàng cho bên thứ ba nếu không có sự đồng ý.', N'Nếu bên cho thuê tiết lộ thông tin, sẽ chịu trách nhiệm theo pháp luật.', CAST(N'2024-11-25T02:06:00.9450335' AS DateTime2), CAST(N'2024-11-25T02:06:00.9450336' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'753e72fa-f5b1-4b7d-9170-08dd0cf5483e', N'Quy định về hủy hợp đồng', N'30872065-d5c3-4abd-9f98-a52574d99fd0', N'Bên thuê có thể hủy hợp đồng trước thời hạn nhưng phải báo trước ít nhất 24 giờ.', N'Nếu bên thuê hủy hợp đồng mà không báo trước hoặc báo quá trễ, sẽ phải chịu phí bồi thường theo quy định.', N'Phí hủy hợp đồng là 10% giá trị thuê nếu không báo trước 24 giờ.', CAST(N'2024-11-25T02:06:11.7302760' AS DateTime2), CAST(N'2024-11-25T02:06:11.7302761' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'a0626be9-fbde-4daf-9171-08dd0cf5483e', N'Thời hạn thuê', N'30872065-d5c3-4abd-9f98-a52574d99fd0', N'Thời gian thuê máy ảnh được quy định rõ ràng và cam kết trả đúng hạn.', N'Thời gian thuê bắt đầu từ thời điểm nhận máy đến thời điểm trả máy đã thỏa thuận trước. Bên thuê chịu trách nhiệm trả máy đúng hạn, nếu không sẽ bị xử phạt theo quy định.', N'Phạt 5% giá trị hợp đồng mỗi giờ trả muộn.', CAST(N'2024-11-25T02:06:21.0651347' AS DateTime2), CAST(N'2024-11-25T02:06:21.0651348' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'1a6e2732-1db0-45db-9172-08dd0cf5483e', N'Trách nhiệm bảo quản', N'30872065-d5c3-4abd-9f98-a52574d99fd0', N'Bên thuê có trách nhiệm bảo quản máy ảnh trong suốt thời gian thuê.', N'Trong suốt thời gian thuê, bên thuê phải bảo quản thiết bị tránh các tác động vật lý, nước, và các yếu tố gây hư hại khác.', N'Nếu máy ảnh bị hỏng, bên thuê phải chịu chi phí sửa chữa hoặc bồi thường theo giá trị thiết bị.', CAST(N'2024-11-25T02:06:28.7227064' AS DateTime2), CAST(N'2024-11-25T02:06:28.7227065' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'62812223-7d40-49b8-9173-08dd0cf5483e', N'Thỏa thuận về bảo mật thông tin', N'ca414592-719d-41d7-8136-b059f0a108b1', N'Thông tin cá nhân của khách hàng sẽ được bảo mật tuyệt đối.', N'Bên cho thuê cam kết không tiết lộ bất kỳ thông tin cá nhân nào của khách hàng cho bên thứ ba nếu không có sự đồng ý.', N'Nếu bên cho thuê tiết lộ thông tin, sẽ chịu trách nhiệm theo pháp luật.', CAST(N'2024-11-25T02:08:04.8362245' AS DateTime2), CAST(N'2024-11-25T02:08:04.8362247' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'5b913920-f50d-4ab0-9174-08dd0cf5483e', N'Cam kết về bảo dưỡng thiết bị', N'ca414592-719d-41d7-8136-b059f0a108b1', N'Thiết bị sẽ được bảo dưỡng định kỳ trước khi cho thuê.', N'Bên cho thuê cam kết kiểm tra và bảo dưỡng thiết bị định kỳ, đảm bảo chất lượng sử dụng.', N'Nếu thiết bị gặp lỗi do không bảo dưỡng, bên cho thuê sẽ hỗ trợ thay thế không tính phí.', CAST(N'2024-11-25T02:08:22.7482188' AS DateTime2), CAST(N'2024-11-25T02:08:22.7482189' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'080488c2-4ac6-4dac-9175-08dd0cf5483e', N'Thanh toán và hoàn trả', N'ca414592-719d-41d7-8136-b059f0a108b1', N'Quy định về thanh toán chi phí thuê và chính sách hoàn trả.', N'Bên thuê cần thanh toán đầy đủ trước khi nhận thiết bị. Nếu trả sớm hơn thời hạn, sẽ không được hoàn lại tiền.', N'Nếu không thanh toán đúng hạn, hợp đồng sẽ bị hủy mà không hoàn lại tiền.', CAST(N'2024-11-25T02:08:30.8558731' AS DateTime2), CAST(N'2024-11-25T02:08:30.8558732' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'dc69ff71-bea2-42d2-9176-08dd0cf5483e', N'Thời hạn thuê', N'ca414592-719d-41d7-8136-b059f0a108b1', N'Thời gian thuê máy ảnh được quy định rõ ràng và cam kết trả đúng hạn.', N'Thời gian thuê bắt đầu từ thời điểm nhận máy đến thời điểm trả máy đã thỏa thuận trước. Bên thuê chịu trách nhiệm trả máy đúng hạn, nếu không sẽ bị xử phạt theo quy định.', N'Phạt 5% giá trị hợp đồng mỗi giờ trả muộn.', CAST(N'2024-11-25T02:08:40.0548901' AS DateTime2), CAST(N'2024-11-25T02:08:40.0548903' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'76f447b8-c64f-4f31-9177-08dd0cf5483e', N'Quy định về hủy hợp đồng', N'ca414592-719d-41d7-8136-b059f0a108b1', N'Bên thuê có thể hủy hợp đồng trước thời hạn nhưng phải báo trước ít nhất 24 giờ.', N'Nếu bên thuê hủy hợp đồng mà không báo trước hoặc báo quá trễ, sẽ phải chịu phí bồi thường theo quy định.', N'Phí hủy hợp đồng là 10% giá trị thuê nếu không báo trước 24 giờ.', CAST(N'2024-11-25T02:08:50.4437869' AS DateTime2), CAST(N'2024-11-25T02:08:50.4437870' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'1f6fc36c-faf0-4052-9178-08dd0cf5483e', N'Thỏa thuận về bảo mật thông tin', N'41770a28-69b3-4e15-b3da-bced9f09fea0', N'Thông tin cá nhân của khách hàng sẽ được bảo mật tuyệt đối.', N'Bên cho thuê cam kết không tiết lộ bất kỳ thông tin cá nhân nào của khách hàng cho bên thứ ba nếu không có sự đồng ý.', N'Nếu bên cho thuê tiết lộ thông tin, sẽ chịu trách nhiệm theo pháp luật.', CAST(N'2024-11-25T02:10:08.9135838' AS DateTime2), CAST(N'2024-11-25T02:10:08.9135839' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'b3fb633b-134f-41bd-9179-08dd0cf5483e', N'Cam kết về bảo dưỡng thiết bị', N'41770a28-69b3-4e15-b3da-bced9f09fea0', N'Thiết bị sẽ được bảo dưỡng định kỳ trước khi cho thuê.', N'Bên cho thuê cam kết kiểm tra và bảo dưỡng thiết bị định kỳ, đảm bảo chất lượng sử dụng.', N'Nếu thiết bị gặp lỗi do không bảo dưỡng, bên cho thuê sẽ hỗ trợ thay thế không tính phí.', CAST(N'2024-11-25T02:10:35.8043961' AS DateTime2), CAST(N'2024-11-25T02:10:35.8043962' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'4dd7ddda-a3ab-4a6f-917a-08dd0cf5483e', N'Thanh toán và hoàn trả', N'41770a28-69b3-4e15-b3da-bced9f09fea0', N'Quy định về thanh toán chi phí thuê và chính sách hoàn trả.', N'Bên thuê cần thanh toán đầy đủ trước khi nhận thiết bị. Nếu trả sớm hơn thời hạn, sẽ không được hoàn lại tiền.', N'Nếu không thanh toán đúng hạn, hợp đồng sẽ bị hủy mà không hoàn lại tiền.', CAST(N'2024-11-25T02:10:44.5279961' AS DateTime2), CAST(N'2024-11-25T02:10:44.5279962' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'9a1b8241-1dab-4d87-917b-08dd0cf5483e', N'Quy định về sử dụng ngoài phạm vi', N'41770a28-69b3-4e15-b3da-bced9f09fea0', N'Thiết bị chỉ được sử dụng trong phạm vi địa lý đã thỏa thuận.', N'Bên thuê không được mang thiết bị ra khỏi phạm vi đã thỏa thuận mà không được sự đồng ý của bên cho thuê.', N'Vi phạm phạm vi sử dụng sẽ bị phạt 20% giá trị hợp đồng.', CAST(N'2024-11-25T02:10:52.0186731' AS DateTime2), CAST(N'2024-11-25T02:10:52.0186732' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'b9f9fbd6-5117-4207-917c-08dd0cf5483e', N'Thời hạn thuê', N'41770a28-69b3-4e15-b3da-bced9f09fea0', N'Thời gian thuê máy ảnh được quy định rõ ràng và cam kết trả đúng hạn.', N'Thời gian thuê bắt đầu từ thời điểm nhận máy đến thời điểm trả máy đã thỏa thuận trước. Bên thuê chịu trách nhiệm trả máy đúng hạn, nếu không sẽ bị xử phạt theo quy định.', N'Phạt 5% giá trị hợp đồng mỗi giờ trả muộn.', CAST(N'2024-11-25T02:10:59.0091517' AS DateTime2), CAST(N'2024-11-25T02:10:59.0091519' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'2c2af291-c25a-454e-917d-08dd0cf5483e', N'Trách nhiệm bảo quản', N'41770a28-69b3-4e15-b3da-bced9f09fea0', N'Bên thuê có trách nhiệm bảo quản máy ảnh trong suốt thời gian thuê.', N'Trong suốt thời gian thuê, bên thuê phải bảo quản thiết bị tránh các tác động vật lý, nước, và các yếu tố gây hư hại khác.', N'Nếu máy ảnh bị hỏng, bên thuê phải chịu chi phí sửa chữa hoặc bồi thường theo giá trị thiết bị.', CAST(N'2024-11-25T02:11:10.2850048' AS DateTime2), CAST(N'2024-11-25T02:11:10.2850049' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'6d2ca6ac-c0a0-4c00-917e-08dd0cf5483e', N'Trách nhiệm bảo quản', N'f984ee20-570d-4305-aac3-e22f57ae7faa', N'Bên thuê có trách nhiệm bảo quản máy ảnh trong suốt thời gian thuê.', N'Trong suốt thời gian thuê, bên thuê phải bảo quản thiết bị tránh các tác động vật lý, nước, và các yếu tố gây hư hại khác.', N'Nếu máy ảnh bị hỏng, bên thuê phải chịu chi phí sửa chữa hoặc bồi thường theo giá trị thiết bị.', CAST(N'2024-11-25T02:11:28.1140383' AS DateTime2), CAST(N'2024-11-25T02:11:28.1140385' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'20fec990-8e67-4dfd-917f-08dd0cf5483e', N'Thời hạn thuê', N'f984ee20-570d-4305-aac3-e22f57ae7faa', N'Thời gian thuê máy ảnh được quy định rõ ràng và cam kết trả đúng hạn.', N'Thời gian thuê bắt đầu từ thời điểm nhận máy đến thời điểm trả máy đã thỏa thuận trước. Bên thuê chịu trách nhiệm trả máy đúng hạn, nếu không sẽ bị xử phạt theo quy định.', N'Phạt 5% giá trị hợp đồng mỗi giờ trả muộn.', CAST(N'2024-11-25T02:11:36.7151597' AS DateTime2), CAST(N'2024-11-25T02:11:36.7151598' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'36ee6887-d181-4d1b-9180-08dd0cf5483e', N'Quy định về hủy hợp đồng', N'f984ee20-570d-4305-aac3-e22f57ae7faa', N'Bên thuê có thể hủy hợp đồng trước thời hạn nhưng phải báo trước ít nhất 24 giờ.', N'Nếu bên thuê hủy hợp đồng mà không báo trước hoặc báo quá trễ, sẽ phải chịu phí bồi thường theo quy định.', N'Phí hủy hợp đồng là 10% giá trị thuê nếu không báo trước 24 giờ.', CAST(N'2024-11-25T02:11:45.8706621' AS DateTime2), CAST(N'2024-11-25T02:11:45.8706622' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'0123dff9-f555-406f-9181-08dd0cf5483e', N'Thanh toán và hoàn trả', N'f984ee20-570d-4305-aac3-e22f57ae7faa', N'Quy định về thanh toán chi phí thuê và chính sách hoàn trả.', N'Bên thuê cần thanh toán đầy đủ trước khi nhận thiết bị. Nếu trả sớm hơn thời hạn, sẽ không được hoàn lại tiền.', N'Nếu không thanh toán đúng hạn, hợp đồng sẽ bị hủy mà không hoàn lại tiền.', CAST(N'2024-11-25T02:11:52.2994888' AS DateTime2), CAST(N'2024-11-25T02:11:52.2994889' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
INSERT [dbo].[ContractTemplates] ([ContractTemplateId], [TemplateName], [ProductID], [ContractTerms], [TemplateDetails], [PenaltyPolicy], [CreatedAt], [UpdatedAt], [AccountID]) VALUES (N'7eda7318-6dbe-4318-9182-08dd0cf5483e', N'Thỏa thuận về bảo mật thông tin', N'f984ee20-570d-4305-aac3-e22f57ae7faa', N'Thông tin cá nhân của khách hàng sẽ được bảo mật tuyệt đối.', N'Bên cho thuê cam kết không tiết lộ bất kỳ thông tin cá nhân nào của khách hàng cho bên thứ ba nếu không có sự đồng ý.', N'Nếu bên cho thuê tiết lộ thông tin, sẽ chịu trách nhiệm theo pháp luật.', CAST(N'2024-11-25T02:11:57.0116941' AS DateTime2), CAST(N'2024-11-25T02:11:57.0116942' AS DateTime2), N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d')
GO
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [AccountID], [Price], [TransactionDescription], [Status], [CreatedAt], [StaffID]) VALUES (N'3f3833f6-9f1d-4d96-b3d1-03019dbab4ca', N'10974a6b-e639-4d24-b073-970321bb21ea', 25000000, N'don hang 3f3833f6-9f1d-4d96-b3d1-03019dbab4ca da duoc hoan tien', 0, CAST(N'2024-11-21T23:10:13.6520916' AS DateTime2), N'b61312e0-288f-44b0-96d3-08dd0a7ffc22')
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [AccountID], [Price], [TransactionDescription], [Status], [CreatedAt], [StaffID]) VALUES (N'1330fd99-2718-48e8-b404-2c7ce5479e74', N'2763dcc8-0b30-4c4a-b088-f7ee028b6443', 8000000, N'Khach hang: da nap tien 80000 VND', 0, CAST(N'2024-11-22T05:15:28.9852586' AS DateTime2), NULL)
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [AccountID], [Price], [TransactionDescription], [Status], [CreatedAt], [StaffID]) VALUES (N'bccee667-cd5c-4a85-b694-32e26ad1782e', N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d', 353000000, N'don hang bccee667-cd5c-4a85-b694-32e26ad1782e da duoc hoan tien', 0, CAST(N'2024-11-22T03:22:57.5545750' AS DateTime2), N'b61312e0-288f-44b0-96d3-08dd0a7ffc22')
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [AccountID], [Price], [TransactionDescription], [Status], [CreatedAt], [StaffID]) VALUES (N'35c98c04-d5d3-4bde-b03a-4e6b71e6d289', N'5aa7ee73-acf3-4110-8f5f-b296738b102e', 88888800, N'Khach hang: da nap tien 888888 VND', 0, CAST(N'2024-11-19T02:28:24.1391927' AS DateTime2), NULL)
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [AccountID], [Price], [TransactionDescription], [Status], [CreatedAt], [StaffID]) VALUES (N'3f0eb0a6-a8ed-48b1-8c42-69b31599b01d', N'0bab8444-ad59-4fe8-b1a4-559bc34275b0', 555555, N'Description of the transaction', 0, CAST(N'2024-11-20T20:47:09.0966667' AS DateTime2), N'5d0e0c59-074c-44e2-0f33-08dcf9537099')
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [AccountID], [Price], [TransactionDescription], [Status], [CreatedAt], [StaffID]) VALUES (N'cc0dd7ea-3971-45b3-b338-b9ca9b3f3381', N'10974a6b-e639-4d24-b073-970321bb21ea', 8500000, N'don hang CC0DD7EA-3971-45B3-B338-B9CA9B3F3381 da duoc hoan tien', 0, CAST(N'2024-11-21T20:51:46.5066031' AS DateTime2), N'5d0e0c59-074c-44e2-0f33-08dcf9537099')
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [AccountID], [Price], [TransactionDescription], [Status], [CreatedAt], [StaffID]) VALUES (N'133e32e5-0c77-4e79-ae61-bc9afc695f2c', N'10974a6b-e639-4d24-b073-970321bb21ea', 777777700, N'Đơn hàng 133E32E5-0C77-4E79-AE61-BC9AFC695F2C đã được hoàn tiền', 0, CAST(N'2024-11-21T09:49:51.6422600' AS DateTime2), N'5d0e0c59-074c-44e2-0f33-08dcf9537099')
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [AccountID], [Price], [TransactionDescription], [Status], [CreatedAt], [StaffID]) VALUES (N'0d355951-aff5-4e09-a339-bd5546930e32', N'5aa7ee73-acf3-4110-8f5f-b296738b102e', 56566600, N'Khach hang: da nap tien 565666 VND', 0, CAST(N'2024-11-22T15:49:11.0443016' AS DateTime2), NULL)
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [AccountID], [Price], [TransactionDescription], [Status], [CreatedAt], [StaffID]) VALUES (N'696bdb85-9941-48fd-b07d-c12e6b6f2ff2', N'10974a6b-e639-4d24-b073-970321bb21ea', 777777700, N'Đơn hàng 696BDB85-9941-48FD-B07D-C12E6B6F2FF2 đã được hoàn tiền', 0, CAST(N'2024-11-21T04:44:54.1737303' AS DateTime2), N'5d0e0c59-074c-44e2-0f33-08dcf9537099')
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [AccountID], [Price], [TransactionDescription], [Status], [CreatedAt], [StaffID]) VALUES (N'50542967-6f46-4dac-8749-cc49e625ba2e', N'10974a6b-e639-4d24-b073-970321bb21ea', 888888800, N'Đơn hàng 50542967-6F46-4DAC-8749-CC49E625BA2E đã được hoàn tiền', 0, CAST(N'2024-11-20T23:37:08.7647762' AS DateTime2), N'5d0e0c59-074c-44e2-0f33-08dcf9537099')
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [AccountID], [Price], [TransactionDescription], [Status], [CreatedAt], [StaffID]) VALUES (N'384d305e-8594-4403-8c37-ccff3629266c', N'5aa7ee73-acf3-4110-8f5f-b296738b102e', 151515100, N'Khach hang: da nap tien 1515151 VND', 0, CAST(N'2024-11-18T19:16:21.5961098' AS DateTime2), NULL)
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [AccountID], [Price], [TransactionDescription], [Status], [CreatedAt], [StaffID]) VALUES (N'10bc27ab-6c48-4c0d-a6c3-cda5efe05091', N'10974a6b-e639-4d24-b073-970321bb21ea', 55555500, N'Đơn hàng 10BC27AB-6C48-4C0D-A6C3-CDA5EFE05091 đã được hoàn tiền', 0, CAST(N'2024-11-21T19:36:54.1763138' AS DateTime2), N'5d0e0c59-074c-44e2-0f33-08dcf9537099')
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [AccountID], [Price], [TransactionDescription], [Status], [CreatedAt], [StaffID]) VALUES (N'6dce7d98-c50c-48f5-93bf-dd9efc0e7b76', N'10974a6b-e639-4d24-b073-970321bb21ea', 888888800, N'Đơn hàng 6DCE7D98-C50C-48F5-93BF-DD9EFC0E7B76 đã được hoàn tiền', 0, CAST(N'2024-11-20T23:35:02.4888992' AS DateTime2), N'5d0e0c59-074c-44e2-0f33-08dcf9537099')
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [AccountID], [Price], [TransactionDescription], [Status], [CreatedAt], [StaffID]) VALUES (N'4a4b954d-a7c1-4c2d-a510-e78093ba4eee', N'10974a6b-e639-4d24-b073-970321bb21ea', 89898900, N'Đơn hàng 4A4B954D-A7C1-4C2D-A510-E78093BA4EEE đã được hoàn tiền', 0, CAST(N'2024-11-21T09:08:27.7929949' AS DateTime2), N'5d0e0c59-074c-44e2-0f33-08dcf9537099')
INSERT [dbo].[HistoryTransactions] ([HistoryTransactionId], [AccountID], [Price], [TransactionDescription], [Status], [CreatedAt], [StaffID]) VALUES (N'da719076-9ed1-4232-b072-efd44c52d00e', N'5aa7ee73-acf3-4110-8f5f-b296738b102e', 367222200, N'Đơn hàng DA719076-9ED1-4232-B072-EFD44C52D00E đã được hoàn tiền', 0, CAST(N'2024-11-21T20:34:58.6381229' AS DateTime2), N'5d0e0c59-074c-44e2-0f33-08dcf9537099')
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [PeriodRental]) VALUES (N'd23375a0-e379-471e-a627-08dd0cee6d9b', N'41569bc8-c2bf-4cb3-8473-8c16bf2c8d7b', N'd7bd0251-127a-4f8c-b129-31835bb521a0', 1560000, N'mới', 0, 1560000, NULL)
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [PeriodRental]) VALUES (N'e09a361b-aeca-47e1-920b-08dd0d01e520', N'daf987ba-be3b-43d5-890f-639d804ba2b1', N'30872065-d5c3-4abd-9f98-a52574d99fd0', 40000, N'mới', 0, 290000, CAST(N'2024-11-26T16:00:00.0000000' AS DateTime2))
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [PeriodRental]) VALUES (N'9f49544d-0004-470f-920c-08dd0d01e520', N'6006f504-63e5-467b-a106-5f254b116e81', N'b29a096b-5f7f-43c8-b737-120ab897cd75', 80000, N'mới', 0, 380000, CAST(N'2024-11-27T07:00:00.0000000' AS DateTime2))
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [PeriodRental]) VALUES (N'7458a602-2606-44ae-920d-08dd0d01e520', N'a96a824b-355a-4275-83d8-ee5e8043199c', N'c5c22a5c-b417-4423-977e-1510549fcfc2', 5187000, N'mới', 0, 5187000, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [Id], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveriesMethod], [CreatedAt], [UpdatedAt], [Deposit], [AccountId], [OrderDetailID]) VALUES (N'6006f504-63e5-467b-a106-5f254b116e81', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'b90c7621-f60f-4476-9bac-c340b07cd1f8', CAST(N'2024-11-25T13:25:06.7548266' AS DateTime2), 11, 380000, 1, CAST(N'2024-11-26T07:00:00.0000000' AS DateTime2), CAST(N'2024-11-27T07:00:00.0000000' AS DateTime2), 1, 1, CAST(N'2024-11-27T07:00:00.0000000' AS DateTime2), N'', 0, CAST(N'2024-11-25T13:25:06.7548876' AS DateTime2), CAST(N'2024-11-25T13:25:06.7548882' AS DateTime2), 350000, NULL, NULL)
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [Id], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveriesMethod], [CreatedAt], [UpdatedAt], [Deposit], [AccountId], [OrderDetailID]) VALUES (N'daf987ba-be3b-43d5-890f-639d804ba2b1', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'46599f4a-abfc-452b-a93a-1cf43b73d1da', CAST(N'2024-11-25T10:33:14.3672953' AS DateTime2), 1, 290000, 1, CAST(N'2024-11-26T14:00:00.0000000' AS DateTime2), CAST(N'2024-11-26T16:00:00.0000000' AS DateTime2), 0, 2, CAST(N'2024-11-26T16:00:00.0000000' AS DateTime2), N'', 0, CAST(N'2024-11-25T10:33:14.3676170' AS DateTime2), CAST(N'2024-11-25T10:33:14.3676436' AS DateTime2), 250000, NULL, NULL)
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [Id], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveriesMethod], [CreatedAt], [UpdatedAt], [Deposit], [AccountId], [OrderDetailID]) VALUES (N'41569bc8-c2bf-4cb3-8473-8c16bf2c8d7b', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'43cc4051-949e-4c52-bec6-bda4bba42b75', CAST(N'2024-11-25T08:13:53.4038763' AS DateTime2), 10, 1560000, 0, NULL, NULL, 0, 0, NULL, N'', 0, CAST(N'2024-11-25T08:13:53.4039348' AS DateTime2), CAST(N'2024-11-25T08:13:53.4039617' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [Id], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveriesMethod], [CreatedAt], [UpdatedAt], [Deposit], [AccountId], [OrderDetailID]) VALUES (N'a96a824b-355a-4275-83d8-ee5e8043199c', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'b90c7621-f60f-4476-9bac-c340b07cd1f8', CAST(N'2024-11-25T13:39:01.9927063' AS DateTime2), 8, 5187000, 0, NULL, NULL, 0, 0, NULL, N'', 1, CAST(N'2024-11-25T13:39:01.9927491' AS DateTime2), CAST(N'2024-11-25T13:39:01.9927791' AS DateTime2), NULL, NULL, NULL)
GO
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [SupplierID], [AccountID], [PaymentDate], [PaymentAmount], [PaymentType], [PaymentStatus], [PaymentMethod], [PaymentDetails], [CreatedAt], [Image], [IsDisable]) VALUES (N'c2873609-cea6-4f2e-b9c7-3259a02c3ed4', N'a96a824b-355a-4275-83d8-ee5e8043199c', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'b90c7621-f60f-4476-9bac-c340b07cd1f8', CAST(N'2024-11-25T06:39:50.6116361' AS DateTime2), 518700000, 0, 1, 0, N'Payment for Order a96a824b-355a-4275-83d8-ee5e8043199c', CAST(N'2024-11-25T06:39:50.6116453' AS DateTime2), N'a', 1)
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [SupplierID], [AccountID], [PaymentDate], [PaymentAmount], [PaymentType], [PaymentStatus], [PaymentMethod], [PaymentDetails], [CreatedAt], [Image], [IsDisable]) VALUES (N'f60516cd-5e81-4eac-a22d-5122bd3101b2', N'daf987ba-be3b-43d5-890f-639d804ba2b1', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'46599f4a-abfc-452b-a93a-1cf43b73d1da', CAST(N'2024-11-25T03:33:50.0713341' AS DateTime2), 29000000, 0, 1, 0, N'Payment for Order daf987ba-be3b-43d5-890f-639d804ba2b1', CAST(N'2024-11-25T03:33:50.0714805' AS DateTime2), N'a', 1)
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [SupplierID], [AccountID], [PaymentDate], [PaymentAmount], [PaymentType], [PaymentStatus], [PaymentMethod], [PaymentDetails], [CreatedAt], [Image], [IsDisable]) VALUES (N'cd300fdc-ef5d-4b2a-8391-9fd53842c362', N'41569bc8-c2bf-4cb3-8473-8c16bf2c8d7b', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'43cc4051-949e-4c52-bec6-bda4bba42b75', CAST(N'2024-11-25T01:14:18.5519132' AS DateTime2), 156000000, 0, 1, 0, N'Payment for Order 41569bc8-c2bf-4cb3-8473-8c16bf2c8d7b', CAST(N'2024-11-25T01:14:18.5521242' AS DateTime2), N'a', 1)
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [SupplierID], [AccountID], [PaymentDate], [PaymentAmount], [PaymentType], [PaymentStatus], [PaymentMethod], [PaymentDetails], [CreatedAt], [Image], [IsDisable]) VALUES (N'6d0fca8a-0996-403c-a1c1-d391ddfe61d6', N'6006f504-63e5-467b-a106-5f254b116e81', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'b90c7621-f60f-4476-9bac-c340b07cd1f8', CAST(N'2024-11-25T06:26:14.7929144' AS DateTime2), 38000000, 0, 1, 0, N'Payment for Order 6006f504-63e5-467b-a106-5f254b116e81', CAST(N'2024-11-25T06:26:14.7929463' AS DateTime2), N'a', 1)
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
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'98210d81-db09-40f0-9e42-1d64b947f866', N'3778b7a9-e3a2-4a6d-9033-64bc8d94860d', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F3778b7a9-e3a2-4a6d-9033-64bc8d94860d_9409e730-028c-4af0-a935-5c3c84b922ca.jpg.png?alt=media&token=518c022b-501b-4cdc-9f16-aae6810066ec')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'0ec691f1-a720-49d2-af45-219855b735c3', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fb29a096b-5f7f-43c8-b737-120ab897cd75_35c0056a-01e4-440d-8c74-bc258c3e567b.jpg.png?alt=media&token=a2515f7b-2e60-4102-a6b4-22d48f78ad77')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'0d41cd03-cc60-4925-8914-24d455d02d59', N'f0b3d4b5-4b30-47f4-bddf-652651e039b5', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Ff0b3d4b5-4b30-47f4-bddf-652651e039b5_3abd1265-b0ac-43ee-8264-1f9ba52a097e.jpg.png?alt=media&token=3ceb9664-b1f9-46ed-b283-da99a081722c')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'39c371e1-83fb-411d-9fdd-25c6e70618da', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F9f7cf8ee-56b8-4d64-8aeb-40364831c377_b0d21774-bc87-47fb-8e45-8a0fb2220530.jpg.png?alt=media&token=5f68279c-6e66-46ad-bd44-7fbe34b049ea')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'a13f6180-a14c-4b6d-b7c0-2644d9ec5be0', N'41770a28-69b3-4e15-b3da-bced9f09fea0', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F41770a28-69b3-4e15-b3da-bced9f09fea0_45debc18-38a4-4dbd-aff8-84a535d1d9d7.jpg.png?alt=media&token=f866115b-104b-4148-b32c-4a61f2b37506')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'a88f5cfe-22d1-44e7-9ca3-30df5c4ba392', N'6554cc54-3fad-4784-8594-fe23199cbef2', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F6554cc54-3fad-4784-8594-fe23199cbef2_c22240c1-eb0b-4160-b3f2-e09da3cb0d6d.jpg.png?alt=media&token=c87f83e0-fd6b-46fe-af5c-87e2eaccf988')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'93e91d2c-bee3-444a-9592-359f1c034d2c', N'30872065-d5c3-4abd-9f98-a52574d99fd0', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F30872065-d5c3-4abd-9f98-a52574d99fd0_a2349dea-1b5c-4f15-a413-84e6c1beee80.jpg.png?alt=media&token=f6f21185-1909-44bd-91d5-a600e55a594f')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'4dcda9d2-e364-47b1-b4b6-386f5373fa7f', N'8b14a5de-c57b-42ae-809d-73a2fe97d7d7', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F8b14a5de-c57b-42ae-809d-73a2fe97d7d7_a93e659f-c57a-4d0b-b5d2-b2556d8c6b7f.jpg.png?alt=media&token=33a1abc7-de38-4a1c-abcb-e9d04ed7b3ed')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'5722ea83-37b7-4683-8024-3f7a6cab38d1', N'7fc1f33b-aee1-4f21-beee-d754572a4f52', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F7fc1f33b-aee1-4f21-beee-d754572a4f52_3635a4c1-9991-4201-8124-b66da5534e6d.jpg.png?alt=media&token=3c2324be-c37a-4708-8384-87b197996b90')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'afff5903-8e9d-420f-8612-4d338466dfaf', N'cde28b02-6181-4e0f-8dff-564618122b6c', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fcde28b02-6181-4e0f-8dff-564618122b6c_89628973-0676-4b18-916f-f52b9623f53e.jpg.png?alt=media&token=027332b5-abe5-4a84-83c9-bed9c92223ad')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'3c69067d-5a9e-4fb0-85a8-4d9ffd447408', N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Feb6466fb-8ec4-4534-82e6-0dae17dc73a6_3f27c1d8-397d-4ba0-9a10-773dc6e2e196.jpg.png?alt=media&token=c46d49c0-4128-4681-804b-05d04e426dab')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'e338f1a4-de26-4a2d-a0a8-6730543a2246', N'f984ee20-570d-4305-aac3-e22f57ae7faa', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Ff984ee20-570d-4305-aac3-e22f57ae7faa_03d002dc-9743-40e9-8ae9-d973d2b88a68.jpg.png?alt=media&token=a250f060-cb72-435e-996b-cd863cd6bee7')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'9a4f77d3-0382-406c-a3cf-6f7bcbfda55f', N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fa3dc3f4d-9d1d-44e2-b005-ea2054ac99ae_6c80406f-d482-4474-8081-4bf053e14b99.jpg.png?alt=media&token=d5371ca4-7159-4801-a76e-9e543c5bbd40')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'ae57ed65-e5a4-4f6a-90e1-75c251f9870e', N'e1153c25-8e58-47ac-8146-5c54bb0df4a3', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fe1153c25-8e58-47ac-8146-5c54bb0df4a3_cc9be74c-2845-4f8a-aa09-283a9a289bd4.jpg.png?alt=media&token=ae9b13fa-095e-4e6b-ad65-b68048556f3f')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'8cf673fe-d51e-4bc9-94b2-805a70c323c2', N'f3705778-aec9-4d92-8e8a-9944500e8854', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Ff3705778-aec9-4d92-8e8a-9944500e8854_7364b724-34bd-4d01-8084-e7418603e667.jpg.png?alt=media&token=aab153bf-efe0-419d-907b-ff0a14a30497')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'c55ab422-874c-4745-9511-85290bb5e8ad', N'8e7b5c0e-c1c4-4be0-ae48-dba3a77beb72', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F8e7b5c0e-c1c4-4be0-ae48-dba3a77beb72_cf631c16-77a5-4263-b466-bd33fdae853b.jpg.png?alt=media&token=096dc44f-fb35-4e4b-99e2-9f1096fa7755')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'98f63bef-c511-4dc1-a43d-8ae0ebd84039', N'8cba35ef-91a4-440e-94b4-1ef099f85222', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F8cba35ef-91a4-440e-94b4-1ef099f85222_9aeb44a5-417a-45c5-8643-82b158920a88.jpg.png?alt=media&token=04c2eee9-1a02-4de6-b203-db1acdb43746')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'894c7880-5927-4e61-a767-a28c13091c3b', N'db30b319-a22a-4fbb-bef2-8d2207270e9e', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fdb30b319-a22a-4fbb-bef2-8d2207270e9e_483281e4-0eb2-4aa8-8e1e-4c00675cad74.jpg.png?alt=media&token=fb392bbd-bd62-4508-9b2b-9ddb91963d25')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'c19bca90-2e39-47f4-b964-b227a62264cd', N'e6ce7419-57e9-43d9-9993-ebf18201addb', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fe6ce7419-57e9-43d9-9993-ebf18201addb_0cc9b69e-ff2c-48f8-aa4a-e792f818fc16.jpg.png?alt=media&token=9f3f0e5d-f200-413e-afa6-544aac7c117a')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'958bc85d-6ec5-423a-a1cb-b372a4336565', N'ca414592-719d-41d7-8136-b059f0a108b1', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fca414592-719d-41d7-8136-b059f0a108b1_8a44c17b-3c4f-4c8f-a629-68b1d85dcb12.jpg.png?alt=media&token=d7300393-523a-4fd1-ad42-8651a22384a8')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'b756180a-fcc4-4ba3-9484-b99d30a2b168', N'45dc7060-6b22-420b-b4a4-1329e420e3bd', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F45dc7060-6b22-420b-b4a4-1329e420e3bd_82d8cd68-cdc0-4949-959b-61207874794f.jpg.png?alt=media&token=279028f4-0091-4553-b4b4-3a9a124baf17')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'a60b7508-9bd2-474b-82f6-ba0579c8da76', N'4a4c1796-07ce-4ae9-bf13-1fc20d35e4bc', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F4a4c1796-07ce-4ae9-bf13-1fc20d35e4bc_65deb11c-dade-4b09-a6be-7541fd33739d.jpg.png?alt=media&token=ed74a7d9-2dbf-4941-88fa-ac4609b5f405')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'84a9680b-4160-4bc4-bdd6-c965a209adf3', N'd7bd0251-127a-4f8c-b129-31835bb521a0', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fd7bd0251-127a-4f8c-b129-31835bb521a0_a43e53b0-e6ea-4d55-b5f6-304d351d124c.jpg.png?alt=media&token=803b0e85-046e-4441-8084-490c76fde88b')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'ea55fb50-73cc-4bc6-90d0-cc475ecab267', N'63af74bd-02d8-4a18-9f90-6a3c7a5f0bb0', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F63af74bd-02d8-4a18-9f90-6a3c7a5f0bb0_c0815566-7893-4ff0-a1a3-42b4e1c5fb20.jpg.png?alt=media&token=34a91a6c-ecd2-47b0-970a-a7a1cc69142b')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'bbd03199-ae8d-4c82-9ce0-dc74a219f6c5', N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fc5c22a5c-b417-4423-977e-1510549fcfc2_f35be710-0a7a-48c1-b9f8-5463b37a89a5.jpg.png?alt=media&token=802ea97a-adec-4a81-a02f-ca187ad9a169')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'4cc21337-9b17-408d-94f6-e30ffd0e91f7', N'693066d2-fc74-4bba-bae1-21914762d76e', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F693066d2-fc74-4bba-bae1-21914762d76e_d9639c80-fc7f-4f01-8c8c-9dadcfbb6bae.jpg.png?alt=media&token=7ceee266-2aba-45c1-b126-07a8f9e012fd')
GO
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'eb6466fb-8ec4-4534-82e6-0dae17dc73a6', N'NikonCOOLPIX_P1000', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'máy ảnh Nikon COOLPIX P1000', N'Là một chiếc máy ảnh chụp siêu xa, Nikon COOLPIX P1000 mang đến khả năng zoom quang học đáng kinh ngạc 125x, kết hợp với khẩu độ tối đa f/2.8-8 cho phép người dùng ghi lại những khung hình ấn tượng và độc đáo nhất, lý tưởng để chụp các thể loại nhiếp ảnh như thiên văn, thể thao và động vật hoang dã.', NULL, 2345000, NULL, 1, N'mới', 0, 5, CAST(N'2024-10-28T22:12:10.4813914' AS DateTime2), CAST(N'2024-11-24T23:09:10.2567802' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'FUJIFILM Instax Mini Evo Hybrid', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'65d75b62-2173-4167-b289-9568167dbe54', N'Máy ảnh lấy liền FUJIFILM Instax Mini Evo Hybrid - Hàng chính hãng', N'Instax Mini Evo Hybrid có thiết kế giống Instax Mini 90 Neo với thân máy được bọc da PU kết hợp cùng khung viền chrome tạo điểm nhấn mang lại vẻ đẹp cổ điển nhưng vẫn không mất đi nét thời thượng.Mặt sau của máy là các nút điều hướng menu và màn hình LCD 3 inch hỗ trợ việc chụp ảnh, điều chỉnh chế độ và xem ảnh, lựa chọn ảnh để in. Đặc biệt, máy còn có cần gạt “Film Advance” như một chiếc máy ảnh film, đây là điểm nhấn hoài cổ thú vị của Instax Mini Evo.', NULL, NULL, 350000, 3, N'mới', 1, 0, CAST(N'2024-10-26T23:50:20.4721751' AS DateTime2), CAST(N'2024-11-07T08:23:53.9712585' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'45dc7060-6b22-420b-b4a4-1329e420e3bd', N'A010', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Panasonic Lumix DMC-FZ300', N'Máy ảnh với zoom 24x và khẩu độ f/2.8, phù hợp cho chụp ảnh ngoài trời và trong nhà.', NULL, NULL, 750000, 5, N'mới', 1, 0, CAST(N'2024-11-13T18:35:32.4673181' AS DateTime2), CAST(N'2024-11-13T18:35:32.4673184' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'c5c22a5c-b417-4423-977e-1510549fcfc2', N'NikonZfbody', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Máy ảnh Nikon Zf body', N'Máy ảnh Nikon Zf được trang bị cảm biến BSI CMOS định dạng FX 24,5MP. Với kích thước định dạng FX, cảm biến này tương đương với kích thước khung hình phim 35mm, giúp nắm bắt một lượng ánh sáng lớn hơn và tạo ra hình ảnh với độ sâu trường sâu hơn. Hơn nữa, cảm biến còn có độ phân giải 24,5, đảm bảo hình ảnh chi tiết khi in ấn lớn hoặc thực hiện chỉnh sửa ảnh mà không mất đi chất lượng.', NULL, 5187000, NULL, 1, N'mới', 3, 0, CAST(N'2024-10-31T07:13:13.7998901' AS DateTime2), CAST(N'2024-11-07T15:35:43.5201028' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'8cba35ef-91a4-440e-94b4-1ef099f85222', N'SonyCybershortHX-7V', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Máy ảnh Sony Cybershort HX-7V - Có Mịn Da - Tiếng Việt - Nhiều hiệu ứng cảnh thú vị', N'Máy ảnh Nikon Zf được trang bị cảm biến BSI CMOS định dạng FX 24,5MP. Với kích thước định dạng FX, cảm biến này tương đương với kích thước khung hình phim 35mm, giúp nắm bắt một lượng ánh sáng lớn hơn và tạo ra hình ảnh với độ sâu trường sâu hơn. Hơn nữa, cảm biến còn có độ phân giải 24,5, đảm bảo hình ảnh chi tiết khi in ấn lớn hoặc thực hiện chỉnh sửa ảnh mà không mất đi chất lượng.', NULL, 2890000, NULL, 2, N'mới', 0, 0, CAST(N'2024-10-28T01:28:24.8393210' AS DateTime2), CAST(N'2024-11-07T15:49:15.5507760' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'4a4c1796-07ce-4ae9-bf13-1fc20d35e4bc', N'A008', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'e9819628-bdf7-4883-ae21-4b83fd1a5193', N'Sony Alpha A6400', N'Máy ảnh mirrorless gọn nhẹ với cảm biến APS-C 24.2MP, phù hợp cho quay vlog và chụp ảnh đa năng.', 0, 2450000, NULL, 2, N'cũ', 0, 0, CAST(N'2024-11-13T17:48:47.6145414' AS DateTime2), CAST(N'2024-11-13T17:48:47.6145468' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'693066d2-fc74-4bba-bae1-21914762d76e', N'Canon3000D', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Máy ảnh Canon 3000D + Lens 18-55mm Chính hãng LBM - Mới 99% Likenew', N'Máy ảnh Canon 3000D + Lens 18-55mm. Máy rất đẹp, Máy nhỏ gọn, phù hợp cho các bạn mới chơi, đi du lịch. Đặc biệt máy có chức năng wifi, chụp xong bắn qua Đt ngay Máy  combo đầy đủ phụ kiện kèm théo máy', NULL, 3350000, NULL, 0, N'cũ', 0, 0, CAST(N'2024-10-28T01:49:51.0363127' AS DateTime2), CAST(N'2024-11-07T15:53:24.4326766' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'd7bd0251-127a-4f8c-b129-31835bb521a0', N'A01000253', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Máy ảnh Canon EOS 250D Kit EF-S18-55mm F3.5-5.6 III', N'Máy ảnh Canon EOS 250D Kit EF-S18-55mm F3.5-5.6 III thuộc dòng máy ảnh DSLR phổ thông của Canon, với thiết kế nhỏ gọn, trọng lượng nhẹ. Nhờ đó, máy tạo cảm giác thoải mái, tiện lợi khi sử dụng cũng như mang theo để sáng tạo những bức ảnh chất lượng.', NULL, 1560000, NULL, 0, N'mới', 0, 0, CAST(N'2024-10-28T01:38:29.7645531' AS DateTime2), CAST(N'2024-11-07T15:59:35.6053942' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'A04000228', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Máy ảnh Fujifilm X- T50 Body Xám', N'Máy ảnh Fujifilm X- T50 Body Xám mới là sự kết hợp thú vị giữa cấu trúc di động với chất lượng hình ảnh hàng đầu. Nó có hình thức nhỏ gọn giúp dễ dàng mang theo, trong khi được trang bị loạt tính năng đa năng sẽ cho bạn trải nghiệm tuyệt vời.', NULL, 1500000, NULL, 3, N'mới', 0, 0, CAST(N'2024-11-06T21:48:29.4546887' AS DateTime2), CAST(N'2024-11-07T09:06:44.7928038' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'cde28b02-6181-4e0f-8dff-564618122b6c', N'A114', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Camera IP Wifi quay quét thông minh EZVIZ TY1', N'Với cảm biến APS-C 24,2 MP và bộ xử lý hình ảnh DIGIC X, mang lại chất lượng hình ảnh tuyệt vời, với khả năng ghi lại chi tiết và màu sắc trung thực.', NULL, 750000, NULL, 2, N'mới', 0, 0, CAST(N'2024-11-24T22:29:27.1034079' AS DateTime2), CAST(N'2024-11-25T00:07:30.7091831' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'e1153c25-8e58-47ac-8146-5c54bb0df4a3', N'A009', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'e9819628-bdf7-4883-ae21-4b83fd1a5193', N'Fujifilm X-T30', N'Máy ảnh mirrorless nhỏ gọn, phù hợp cho nhiếp ảnh đường phố và cảnh quan.', NULL, 1500000, NULL, 3, N'mới', 0, 0, CAST(N'2024-11-13T18:31:36.3949803' AS DateTime2), CAST(N'2024-11-13T18:31:36.3949805' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'3778b7a9-e3a2-4a6d-9033-64bc8d94860d', N'A223', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Máy Ảnh Fujifilm Instax Mini 99 Instant Film', N'Máy ảnh Fujifilm Instax Mini 99 Instant Film là dòng máy ảnh film nhỏ gọn in ảnh tức thì mọi lúc mọi nơi những bức ảnh kích thước 2x3 inch. Với năm chế độ chụp và chức năng tự động điều chỉnh sáng, người dùng có thể dễ dàng chụp theo ý muốn. Chế độ cảnh và chế độ marco cho phép tạo ra các bức ảnh đa dạng và sắc nét. Điều khiển đèn flash tích hợp và sáu cài đặt hiệu ứng màu sắc giúp tạo ra những bức ảnh độc đáo và nghệ thuật.', NULL, NULL, 350000, 3, N'mới', 1, 0, CAST(N'2024-11-24T15:36:40.9271293' AS DateTime2), CAST(N'2024-11-24T16:39:37.0891899' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'f0b3d4b5-4b30-47f4-bddf-652651e039b5', N'SN001', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'3ed49ca1-fc18-4d3c-ac86-0b04f1d57f35', N'Canon EOS 90D', N'Máy ảnh DSLR chuyên nghiệp cho nhiếp ảnh gia', NULL, 1200000, NULL, 0, N'moi', 0, 0, CAST(N'2024-10-26T18:35:31.1080560' AS DateTime2), CAST(N'2024-10-26T18:35:31.1081036' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'63af74bd-02d8-4a18-9f90-6a3c7a5f0bb0', N'A011', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Nikon D7500', N'Máy ảnh DSLR APS-C 20.9MP, lý tưởng cho người mới và chụp ảnh gia đình.', NULL, NULL, 450000, 1, N'cũ', 0, 0, CAST(N'2024-11-13T18:39:57.6943085' AS DateTime2), CAST(N'2024-11-13T18:39:57.6943087' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'31c67538-334a-4d67-9f94-6ab96439b4c1', N'CAM008', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Olympus OM-D E-M1 Mark III', N'Máy ảnh MFT với khả năng ổn định hình ảnh', NULL, 2800000, NULL, 4, N'moi', 0, 0, CAST(N'2024-10-31T20:09:57.5795579' AS DateTime2), CAST(N'2024-10-31T20:09:57.5795956' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'8b14a5de-c57b-42ae-809d-73a2fe97d7d7', N'A113', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Máy ảnh Canon EOS R10 (Body)', N'Với cảm biến APS-C 24,2 MP và bộ xử lý hình ảnh DIGIC X, mang lại chất lượng hình ảnh tuyệt vời, với khả năng ghi lại chi tiết và màu sắc trung thực.', NULL, 750000, NULL, 2, N'mới', 0, 0, CAST(N'2024-11-24T21:36:55.9041114' AS DateTime2), CAST(N'2024-11-25T00:11:52.1527050' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'db30b319-a22a-4fbb-bef2-8d2207270e9e', N'FujifilmX-s10', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Máy Ảnh Fujifilm X-s10 18-55m F2.8-4 Ois', N' Máy Ảnh Fujifilm X-s10 18-55m F2.8-4 Ois có thiết kế nhỏ gọn, bộ tính năng lớn, FUJIFILM X-S10 là một chiếc máy ảnh không gương lật kiểu dáng đẹp và linh hoạt, rất phù hợp để sử dụng khi di chuyển. Cung cấp các tính năng hình ảnh và video có khả năng, X-S10 kết hợp yếu tố hình thức di động với các công cụ cần thiết để tạo nội dung hàng ngày.', NULL, 9966000, NULL, 3, N'mới', 0, 0, CAST(N'2024-10-28T01:09:32.0890208' AS DateTime2), CAST(N'2024-11-07T16:33:01.0735444' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'f3705778-aec9-4d92-8e8a-9944500e8854', N'A006', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Canon PowerShot SX740 HS', N'Máy ảnh nhỏ gọn với zoom quang học 40x, phù hợp cho du lịch và chụp ảnh hàng ngày.', NULL, NULL, 500000, 0, N'cũ', 1, 0, CAST(N'2024-11-13T18:27:42.2821012' AS DateTime2), CAST(N'2024-11-13T18:27:42.2821014' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'30872065-d5c3-4abd-9f98-a52574d99fd0', N'A222', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Máy Ảnh Sony a6700 + Lens 18-135mm', N'Lắp camera giám sát là điều cần thiết để đảm bảo an ninh cho tài sản hay sự an toàn cho người thân, gia đình và nhân viên của các bạn. Vậy thì làm thế nào để biết được loại camera nào phù hợp với chúng ta? Camera không dây hay camera có dây, nên lắp đặt loại nào?', NULL, NULL, 250000, 2, N'mới', 2, 0, CAST(N'2024-11-24T15:34:59.7730611' AS DateTime2), CAST(N'2024-11-24T15:34:59.7730614' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'dde6ce8a-13a5-434f-a1ed-b03d1ca05043', N'CAM001', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Canon EOS R5', N'Máy ảnh mirrorless full-frame, quay video 8K', NULL, 800000, NULL, 0, N'moi', 0, 0, CAST(N'2024-10-31T17:30:05.4184495' AS DateTime2), CAST(N'2024-10-31T17:30:05.4184974' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'ca414592-719d-41d7-8136-b059f0a108b1', N'A007', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'e9819628-bdf7-4883-ae21-4b83fd1a5193', N'Sony Alpha A7 III', N'Máy quay hành động có khả năng quay 5.3K, chống nước tốt, lý tưởng cho thể thao mạo hiểm.', NULL, NULL, 650000, 2, N'cũ', 1, 0, CAST(N'2024-11-13T18:00:04.2570549' AS DateTime2), CAST(N'2024-11-13T18:00:04.2570550' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'd2aa771b-fa01-4b9b-a411-b20c26da1561', N'A01122', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Canon EOS 5D Mark IV', N'Canon EOS 5D Mark IV', 0, 6500000, NULL, 0, N'Moi', 0, 0, CAST(N'2024-11-13T17:19:23.0919841' AS DateTime2), CAST(N'2024-11-13T17:19:23.0920204' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'41770a28-69b3-4e15-b3da-bced9f09fea0', N'A005', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'65d75b62-2173-4167-b289-9568167dbe54', N'Fujifilm Instax Mini 11', N'Máy ảnh in liền, nhỏ gọn và dễ sử dụng, phù hợp cho buổi tụ họp và du lịch.', NULL, NULL, 400000, 3, N'cũ', 1, 0, CAST(N'2024-11-13T18:23:25.4824369' AS DateTime2), CAST(N'2024-11-13T18:23:25.4824370' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'7fc1f33b-aee1-4f21-beee-d754572a4f52', N'Canon30Dlens28', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Máy ảnh Canon 30D lens 28-80, đầy đủ phụ kiện ', N'Đầy đủ phụ kiện che flash, pin, sạc pin, thẻ nhớ, đầu đọc thẻ nhớ để cắm vào máy tính( bạn nào ko có máy tính thì ra tiệm đưa thẻ nhớ nhờ người ta cop vào google drive để chỉnh trên điện thoại cũng được) ', NULL, NULL, 250000, 0, N'cũ', 1, 0, CAST(N'2024-10-26T22:58:20.0103969' AS DateTime2), CAST(N'2024-11-07T09:38:59.9408498' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'8e7b5c0e-c1c4-4be0-ae48-dba3a77beb72', N'A224', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Máy ảnh Sony ZV-E10 (Black, Body Only) | Chính hãng', N'Được thiết kế để phù hợp các vlogger, máy ảnh Sony ZV-E10 kết hợp cảm biến lớn và tính linh hoạt của máy ảnh không gương lật đem đến hình ảnh chất lượng. Máy ảnh Sony ZV-E10 có thiết kế tay cầm với màn hình LCD có thể thay đổi góc, thích hợp làm việc từ những góc nhìn trực diện.', NULL, NULL, 500000, 3, N'mới', 0, 0, CAST(N'2024-11-24T15:37:29.0620977' AS DateTime2), CAST(N'2024-11-24T17:20:58.4959621' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'f984ee20-570d-4305-aac3-e22f57ae7faa', N'A116', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Camera Wifi IMOU IPC-A42P-B - 4MP', N'Lắp camera giám sát là điều cần thiết để đảm bảo an ninh cho tài sản hay sự an toàn cho người thân, gia đình và nhân viên của các bạn. Vậy thì làm thế nào để biết được loại camera nào phù hợp với chúng ta? Camera không dây hay camera có dây, nên lắp đặt loại nào?', NULL, NULL, 250000, 2, N'mới', 1, 0, CAST(N'2024-11-24T15:32:40.5199696' AS DateTime2), CAST(N'2024-11-24T15:32:40.5199707' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', N'NikonD7200', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Máy Ảnh Nikon D7200 - Chính Hãng', NULL, NULL, NULL, 650000, 1, N'mới', 1, 0, CAST(N'2024-10-26T23:19:55.3766577' AS DateTime2), CAST(N'2024-11-07T09:51:37.9255668' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'e6ce7419-57e9-43d9-9993-ebf18201addb', N'A112', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Máy ảnh Canon EOS R100', N'Canon EOS R100 là máy ảnh nhỏ gọn và nhẹ nhất* trong hệ thống R. Với tốc độ chụp liên tục lên đến 6,5 khung hình mỗi giây và độ phân giải 24,1 megapixel, bạn có thể chụp được những bức ảnh đẹp. Khả năng quay video ở 4K 25p hoặc HD 120p của EOS R100 cho phép tự do hơn để thể hiện sự sáng tạo. ', NULL, 8990000, NULL, 3, N'mới', 0, 0, CAST(N'2024-11-24T21:32:20.4134900' AS DateTime2), CAST(N'2024-11-24T23:59:27.9056232' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [DepositProduct], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'6554cc54-3fad-4784-8594-fe23199cbef2', N'A111', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'Máy ảnh Canon 60D 100-300mm f/4.5-5.6 USM', N'Tính năng: Timelapse recording, Face detection, In-camera raw conversion, EyeFi, Quay phim Full HD', NULL, 7485000, NULL, 3, N'mới', 0, 0, CAST(N'2024-11-24T21:29:14.5872552' AS DateTime2), CAST(N'2024-11-24T23:52:59.8142558' AS DateTime2))
GO
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'af16a1e8-d674-43ea-8410-028f90f4972d', N'693066d2-fc74-4bba-bae1-21914762d76e', N'Phụ kiện máy ảnh đi kèm ', N' Pin, sạc pin, dây đeo, phiếu bảo hành')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'5f06e67a-def3-433c-ae20-0e317f37071b', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'Kích thước', N' 87x123x36 mm')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'3cb71a3e-b3d0-447b-a937-1b1e051f21a5', N'f0b3d4b5-4b30-47f4-bddf-652651e039b5', N'Độ phân giải tối đa ', N' 6960 x 4640')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'71737ec3-5143-4a37-9650-1d76af4a9583', N'9f7cf8ee-56b8-4d64-8aeb-40364831c377', N'Bù phơi sáng', N' -5 đến +5 EV (1/3 EV bước)')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'21a072b7-c454-461a-9bde-1f43795cf8de', N'30872065-d5c3-4abd-9f98-a52574d99fd0', N'Độ phân giải chuẩn nén', N' H.265')
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
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'1cf11348-7367-498f-8870-606db75da451', N'd7bd0251-127a-4f8c-b129-31835bb521a0', N'Độ nhạy sáng', N' ISO 100-25600 (mở rộng 51200)')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'dfcf2db9-6feb-44f5-87bf-679d65890e5e', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'Độ phân giải', N' 2560x1920 px')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'39d72af3-ddf7-49f9-b4fa-6aece4078b33', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'ISO', N' 100–1600')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'ad68d788-a2d1-4be3-9f50-6e7952dc3fb0', N'd7bd0251-127a-4f8c-b129-31835bb521a0', N'Màn hình	LCD', N' 3.0 inch (cảm ứng)')
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
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'f37e138d-9c80-4128-8753-cee8d104c47c', N'f984ee20-570d-4305-aac3-e22f57ae7faa', N'Độ phân giải chuẩn nén', N' H.265')
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
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'18d35801-bfad-4d6e-bd75-08952c424873', N'f3705778-aec9-4d92-8e8a-9944500e8854', 60000, 0, 0, 0, CAST(N'2024-11-13T18:27:42.2821042' AS DateTime2), CAST(N'2024-11-13T18:27:42.2821044' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'11d9df8a-edf6-4d95-a550-0a5776dd0a71', N'8e7b5c0e-c1c4-4be0-ae48-dba3a77beb72', 60000, 250000, 900000, 2500000, CAST(N'2024-11-24T15:37:29.0621043' AS DateTime2), CAST(N'2024-11-24T15:37:29.0621044' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'9aa08b36-0695-4f72-a889-2d02ce820949', N'41770a28-69b3-4e15-b3da-bced9f09fea0', 30000, 0, 0, 0, CAST(N'2024-11-13T18:23:25.4824450' AS DateTime2), CAST(N'2024-11-13T18:23:25.4824453' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'f1bba992-64b9-428b-904b-38b8a315fc8c', N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', 100000, 500000, 2000000, NULL, CAST(N'2024-10-26T23:19:55.3771997' AS DateTime2), CAST(N'2024-10-26T23:19:55.3772592' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'572a17ef-a5cb-4682-bce6-4ea011b6ee57', N'b29a096b-5f7f-43c8-b737-120ab897cd75', 30000, 80000, 300000, 800000, CAST(N'2024-10-26T23:50:20.4727211' AS DateTime2), CAST(N'2024-10-26T23:50:20.4727725' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'0b93677d-58b3-4384-94cb-64d7c3ea4fa0', N'63af74bd-02d8-4a18-9f90-6a3c7a5f0bb0', 130000, 1000000, 6000000, 0, CAST(N'2024-11-13T18:39:57.6943112' AS DateTime2), CAST(N'2024-11-13T18:39:57.6943114' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'75c86eed-bb79-4eaf-92c9-68acac3b7969', N'7fc1f33b-aee1-4f21-beee-d754572a4f52', 20000, 60000, 160000, 5000000, CAST(N'2024-10-26T22:58:22.5292565' AS DateTime2), CAST(N'2024-10-26T22:58:22.5293273' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'cbd4155a-ccf8-43b3-a4e5-77525679728e', N'f984ee20-570d-4305-aac3-e22f57ae7faa', 20000, 60000, 100000, 20000, CAST(N'2024-11-24T15:32:40.5211234' AS DateTime2), CAST(N'2024-11-24T15:32:40.5211957' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'2b46abb5-446f-4356-b6ef-9b3c92686d6a', N'30872065-d5c3-4abd-9f98-a52574d99fd0', 20000, 60000, 100000, 20000, CAST(N'2024-11-24T15:34:59.7730674' AS DateTime2), CAST(N'2024-11-24T15:34:59.7730675' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'4428ed1f-c6b7-4ba4-8394-c4fd68795f0a', N'ca414592-719d-41d7-8136-b059f0a108b1', 180000, 1500000, 0, 0, CAST(N'2024-11-13T18:00:04.2570615' AS DateTime2), CAST(N'2024-11-13T18:00:04.2570617' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'6155ab09-de83-473e-92f6-e105c617d5d6', N'3778b7a9-e3a2-4a6d-9033-64bc8d94860d', 20000, 30000, 80000, 200000, CAST(N'2024-11-24T15:36:40.9271338' AS DateTime2), CAST(N'2024-11-24T15:36:40.9271339' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'adef9c82-4153-48b7-84ed-e477c914d1f7', N'45dc7060-6b22-420b-b4a4-1329e420e3bd', 80000, 500000, 0, 0, CAST(N'2024-11-13T18:35:32.4673210' AS DateTime2), CAST(N'2024-11-13T18:35:32.4673213' AS DateTime2))
GO
INSERT [dbo].[ReturnDetails] ([ReturnID], [OrderID], [ReturnDate], [Condition], [PenaltyApplied], [CreatedAt], [UpdatedAt], [IsDisable]) VALUES (N'd68de4ef-a0dd-4ef0-e829-08dd0d1b34d1', N'6006f504-63e5-467b-a106-5f254b116e81', CAST(N'2024-11-25T06:34:25.7880769' AS DateTime2), N'Khong Hu hong', 0, CAST(N'2024-11-25T06:34:25.7878758' AS DateTime2), CAST(N'2024-11-25T06:34:25.7878759' AS DateTime2), 0)
GO
INSERT [dbo].[Staffs] ([StaffID], [Name], [AccountID], [JobTitle], [Department], [StaffStatus], [HireDate], [CreatedAt], [UpdatedAt], [IsAdmin], [Img], [IsDisable]) VALUES (N'5d0e0c59-074c-44e2-0f33-08dcf9537099', N'Perdita', N'8b6c5937-00ed-4d95-96d3-1d83c0599dc8', N'IT', N'IT', N'active', CAST(N'2024-10-30T17:00:00.0000000' AS DateTime2), CAST(N'2024-10-31T02:26:34.6378635' AS DateTime2), CAST(N'2024-10-31T02:26:34.6378636' AS DateTime2), 0, N'Microsoft.AspNetCore.Http.FormFile', 0)
INSERT [dbo].[Staffs] ([StaffID], [Name], [AccountID], [JobTitle], [Department], [StaffStatus], [HireDate], [CreatedAt], [UpdatedAt], [IsAdmin], [Img], [IsDisable]) VALUES (N'8f5d51d8-e01f-4926-4d0d-08dcfa187630', N'Staff1', N'812cc63a-465b-43f5-a7cd-cc3dc893b45e', N'IT', N'IT', N'active', CAST(N'2024-10-31T17:00:00.0000000' AS DateTime2), CAST(N'2024-11-01T01:56:54.8762436' AS DateTime2), CAST(N'2024-11-01T01:56:54.8762437' AS DateTime2), 0, N'Microsoft.AspNetCore.Http.FormFile', 0)
INSERT [dbo].[Staffs] ([StaffID], [Name], [AccountID], [JobTitle], [Department], [StaffStatus], [HireDate], [CreatedAt], [UpdatedAt], [IsAdmin], [Img], [IsDisable]) VALUES (N'b61312e0-288f-44b0-96d3-08dd0a7ffc22', N'Lê', N'46599f4a-abfc-452b-a93a-1cf43b73d1da', N'student', N'student', N'0', CAST(N'2002-11-11T00:00:00.0000000' AS DateTime2), CAST(N'2024-11-21T22:58:16.3544276' AS DateTime2), CAST(N'2024-11-21T22:58:16.3544277' AS DateTime2), 0, N'Microsoft.AspNetCore.Http.FormFile', 0)
INSERT [dbo].[Staffs] ([StaffID], [Name], [AccountID], [JobTitle], [Department], [StaffStatus], [HireDate], [CreatedAt], [UpdatedAt], [IsAdmin], [Img], [IsDisable]) VALUES (N'b7179f64-8a2b-4b3e-c3d9-08dd0cc0f2d5', N'Duy', N'5f6a230e-10a9-4bfd-834a-63a5ab1348b1', N'Sales', N'Sales', N'active', CAST(N'2024-11-27T17:00:00.0000000' AS DateTime2), CAST(N'2024-11-24T19:48:20.3791508' AS DateTime2), CAST(N'2024-11-24T19:48:20.3791509' AS DateTime2), 0, N'Microsoft.AspNetCore.Http.FormFile', 0)
GO
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [Img], [IsDisable]) VALUES (N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'5aa7ee73-acf3-4110-8f5f-b296738b102e', N'Nikon', N'đem đến trải nghiệm rất tốt', N'188 Trần Bá Giao , P5, GV, TPHCM', N'07989999999', NULL, NULL, NULL, CAST(N'2024-10-26T17:40:07.8301292' AS DateTime2), CAST(N'2024-10-26T17:40:07.8301707' AS DateTime2), NULL, 0)
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [Img], [IsDisable]) VALUES (N'ffb0ae5f-10f2-48d7-329f-08dcf5e53bbf', N'8be335d3-1fd1-4cc6-8835-138dbee72ef5', N'Nikon', N'Dịch vụ máy ảnh từ nhà cung cấp Canon đem đến cho bạn những trai nghiệm tuyệt vời ', N'188 Nguyễn Xiển, Thành phố Thủ Đức, TP HCM', N'07989878787', NULL, NULL, NULL, CAST(N'2024-10-26T17:56:00.4345177' AS DateTime2), CAST(N'2024-10-26T17:56:00.4345179' AS DateTime2), NULL, 0)
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [Img], [IsDisable]) VALUES (N'67958e38-0ca0-43a2-0887-08dcfa0f9cda', N'5dc31c52-da51-46cf-87a1-7dbd4c9887ae', N'lbacojq', N'Không gì tuyẹt hon', N'Q9 TP HCM', N'0999744747', NULL, NULL, NULL, CAST(N'2024-11-01T00:53:34.2726968' AS DateTime2), CAST(N'2024-11-01T00:53:34.2727361' AS DateTime2), NULL, 0)
GO
INSERT [dbo].[Transactions] ([TransactionID], [OrderID], [TransactionDate], [Amount], [TransactionType], [PaymentStatus], [PaymentMethod], [VNPAYTransactionID], [VNPAYTransactionStatus], [VNPAYTransactionTime]) VALUES (N'56c13eab-74c3-4c3c-9374-0c8bd632b805', N'daf987ba-be3b-43d5-890f-639d804ba2b1', CAST(N'2024-11-25T03:33:50.1049016' AS DateTime2), 29000000, 1, 1, 0, N'14695797', 0, CAST(N'2024-11-25T03:33:50.1051798' AS DateTime2))
INSERT [dbo].[Transactions] ([TransactionID], [OrderID], [TransactionDate], [Amount], [TransactionType], [PaymentStatus], [PaymentMethod], [VNPAYTransactionID], [VNPAYTransactionStatus], [VNPAYTransactionTime]) VALUES (N'b620a19e-33c8-4f3f-8a29-11279341cb6b', N'a96a824b-355a-4275-83d8-ee5e8043199c', CAST(N'2024-11-25T06:39:50.6121020' AS DateTime2), 518700000, 0, 1, 0, N'14696178', 0, CAST(N'2024-11-25T06:39:50.6121048' AS DateTime2))
INSERT [dbo].[Transactions] ([TransactionID], [OrderID], [TransactionDate], [Amount], [TransactionType], [PaymentStatus], [PaymentMethod], [VNPAYTransactionID], [VNPAYTransactionStatus], [VNPAYTransactionTime]) VALUES (N'50974ce8-ac27-4d0b-a826-1c5aa296464d', N'41569bc8-c2bf-4cb3-8473-8c16bf2c8d7b', CAST(N'2024-11-25T01:14:18.5853873' AS DateTime2), 156000000, 0, 1, 0, N'14695570', 0, CAST(N'2024-11-25T01:14:18.5857402' AS DateTime2))
INSERT [dbo].[Transactions] ([TransactionID], [OrderID], [TransactionDate], [Amount], [TransactionType], [PaymentStatus], [PaymentMethod], [VNPAYTransactionID], [VNPAYTransactionStatus], [VNPAYTransactionTime]) VALUES (N'83fb7e4e-9967-48df-a33d-97241415b9c6', N'6006f504-63e5-467b-a106-5f254b116e81', CAST(N'2024-11-25T06:26:14.7936536' AS DateTime2), 38000000, 0, 1, 0, N'14696144', 0, CAST(N'2024-11-25T06:26:14.7936561' AS DateTime2))
GO
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'2a669ff3-7e51-4053-87cc-179edaa306ba', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'50K', N'Giam 50 000 cho san pham', 50000, CAST(N'2024-10-23T17:00:00.0000000' AS DateTime2), CAST(N'2024-11-28T17:00:00.0000000' AS DateTime2), 1, CAST(N'2024-10-30T18:54:08.0021495' AS DateTime2), CAST(N'2024-10-30T18:54:08.0021496' AS DateTime2))
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'a15bbace-e32a-4290-adb3-18447999ffa9', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'Giảm 30.000', N'Giảm 30000 ', 30000, CAST(N'2024-10-31T17:00:00.0000000' AS DateTime2), CAST(N'2024-11-01T17:00:00.0000000' AS DateTime2), 1, CAST(N'2024-11-01T02:14:18.5581536' AS DateTime2), CAST(N'2024-11-01T02:14:18.5581537' AS DateTime2))
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'7cafdef1-4f7c-4709-af47-514d3c230d93', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'20K', N'Giam 50000 cho san pham', 50000, CAST(N'2024-10-23T17:00:00.0000000' AS DateTime2), CAST(N'2024-11-28T10:00:00.0000000' AS DateTime2), 1, CAST(N'2024-10-30T18:55:15.1355111' AS DateTime2), CAST(N'2024-10-30T19:27:01.9525220' AS DateTime2))
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'b786f857-8d40-4acf-ab45-6af4c94b3532', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'Nikon50', N'Nikon giảm 50.000 cho các sản phẩm ', 50000, CAST(N'2024-11-05T17:00:00.0000000' AS DateTime2), CAST(N'2024-11-06T17:00:00.0000000' AS DateTime2), 1, CAST(N'2024-11-06T06:46:15.2795072' AS DateTime2), CAST(N'2024-11-06T06:46:15.2795072' AS DateTime2))
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'2c488120-fce6-4818-833f-81dd55619241', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'DISC2024', N'Giảm giá 100d cho đơn hàng đầu tiên', 100, CAST(N'2024-10-27T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-31T02:59:59.0000000' AS DateTime2), 1, CAST(N'2024-10-27T02:17:54.1912484' AS DateTime2), CAST(N'2024-11-14T19:28:17.6099927' AS DateTime2))
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'd571e7f3-f030-415c-ae99-931e23a3fe96', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'Giảm 150.000', N'Giảm 150.000 ', 15, CAST(N'2024-11-05T17:00:00.0000000' AS DateTime2), CAST(N'2024-11-06T10:00:00.0000000' AS DateTime2), 0, CAST(N'2024-11-06T06:44:21.8230525' AS DateTime2), CAST(N'2024-11-06T06:45:34.3972628' AS DateTime2))
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'b5e357fe-4afb-4153-a13d-ab81d901e2b9', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'DISC2024', N'Giảm giá 100k cho đơn hàng đầu tiên', 100, CAST(N'2024-10-27T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-31T23:59:59.0000000' AS DateTime2), 1, CAST(N'2024-10-27T02:17:54.1912484' AS DateTime2), CAST(N'2024-10-27T02:17:54.1912485' AS DateTime2))
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'6779add7-2426-4fed-ab79-b3b8c25b42a9', N'2a435c48-c6e2-4689-146d-08dd0cb0316c', N'10K', N'Giảm 10.000 đ', 10000, CAST(N'2024-11-25T17:00:00.0000000' AS DateTime2), CAST(N'2024-11-27T17:00:00.0000000' AS DateTime2), 1, CAST(N'2024-11-24T19:44:36.9146589' AS DateTime2), CAST(N'2024-11-24T19:44:36.9146590' AS DateTime2))
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'2a05b9ab-b51d-4547-a7cd-b77dda5bcdab', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'1.000', N'Giam 1 000 cho san pham', 1000, CAST(N'2024-10-30T17:00:00.0000000' AS DateTime2), CAST(N'2024-10-31T10:00:00.0000000' AS DateTime2), 1, CAST(N'2024-10-30T19:27:43.5119256' AS DateTime2), CAST(N'2024-10-30T19:28:07.6140337' AS DateTime2))
GO
INSERT [dbo].[Wishlists] ([WishlistID], [AccountID], [ProductID], [CreatedAt], [IsDisable]) VALUES (N'3cbd4c1a-4525-4038-aae6-08dd0d151e6d', N'b2e9498d-1c18-4706-b9f9-7ccf2b07a11a', N'8b14a5de-c57b-42ae-809d-73a2fe97d7d7', CAST(N'2024-11-25T05:50:51.2408651' AS DateTime2), 0)
INSERT [dbo].[Wishlists] ([WishlistID], [AccountID], [ProductID], [CreatedAt], [IsDisable]) VALUES (N'6df12268-6fe5-4cda-aae7-08dd0d151e6d', N'b2e9498d-1c18-4706-b9f9-7ccf2b07a11a', N'e6ce7419-57e9-43d9-9993-ebf18201addb', CAST(N'2024-11-25T05:51:27.3673564' AS DateTime2), 0)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contracts_ContractTemplateId]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Contracts_ContractTemplateId] ON [dbo].[Contracts]
(
	[ContractTemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contracts_OrderID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Contracts_OrderID] ON [dbo].[Contracts]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ContractTemplates_AccountID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_ContractTemplates_AccountID] ON [dbo].[ContractTemplates]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ContractTemplates_ProductID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_ContractTemplates_ProductID] ON [dbo].[ContractTemplates]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_OrderID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderID] ON [dbo].[OrderDetails]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_ProductID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductID] ON [dbo].[OrderDetails]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Orders_AccountId]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_AccountId] ON [dbo].[Orders]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_SupplierID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_SupplierID] ON [dbo].[Orders]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Payments_AccountID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_AccountID] ON [dbo].[Payments]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_OrderID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_OrderID] ON [dbo].[Payments]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_SupplierID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_SupplierID] ON [dbo].[Payments]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductImages_ProductID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductImages_ProductID] ON [dbo].[ProductImages]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ProductReports_Account]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductReports_Account] ON [dbo].[ProductReports]
(
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductReports_ProductID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductReports_ProductID] ON [dbo].[ProductReports]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductReports_SupplierID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductReports_SupplierID] ON [dbo].[ProductReports]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryID] ON [dbo].[Products]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_SupplierID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_SupplierID] ON [dbo].[Products]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductSpecifications_ProductID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductSpecifications_ProductID] ON [dbo].[ProductSpecifications]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductVouchers_ProductID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductVouchers_ProductID] ON [dbo].[ProductVouchers]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductVouchers_VourcherID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductVouchers_VourcherID] ON [dbo].[ProductVouchers]
(
	[VourcherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Ratings_AccountID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Ratings_AccountID] ON [dbo].[Ratings]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Ratings_ProductID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Ratings_ProductID] ON [dbo].[Ratings]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RentalPrices_ProductID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_RentalPrices_ProductID] ON [dbo].[RentalPrices]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Reports_AccountId]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reports_AccountId] ON [dbo].[Reports]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Requests_AccountID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Requests_AccountID] ON [dbo].[Requests]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ReturnDetails_OrderID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_ReturnDetails_OrderID] ON [dbo].[ReturnDetails]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Staffs_AccountID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Staffs_AccountID] ON [dbo].[Staffs]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SupplierReports_AccountID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierReports_AccountID] ON [dbo].[SupplierReports]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierReports_StaffID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierReports_StaffID] ON [dbo].[SupplierReports]
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierReports_SupplierID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierReports_SupplierID] ON [dbo].[SupplierReports]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierRequests_SupplierID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierRequests_SupplierID] ON [dbo].[SupplierRequests]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Suppliers_AccountID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Suppliers_AccountID] ON [dbo].[Suppliers]
(
	[AccountID] ASC
)
WHERE ([AccountID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_OrderID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Transactions_OrderID] ON [dbo].[Transactions]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Wishlists_AccountID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Wishlists_AccountID] ON [dbo].[Wishlists]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Wishlists_ProductID]    Script Date: 11/25/2024 9:37:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Wishlists_ProductID] ON [dbo].[Wishlists]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
