USE [master]
GO
/****** Object:  Database [CameraCapstone]    Script Date: 10/28/2024 5:17:05 PM ******/
CREATE DATABASE [CameraCapstone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CameraCapstone', FILENAME = N'/var/opt/mssql/data/CameraCapstone.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CameraCapstone_log', FILENAME = N'/var/opt/mssql/data/CameraCapstone_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[Categories]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[Contracts]    Script Date: 10/28/2024 5:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contracts](
	[ContractID] [uniqueidentifier] NOT NULL,
	[OrderID] [uniqueidentifier] NOT NULL,
	[ContractTemplateId] [uniqueidentifier] NOT NULL,
	[ContractTerms] [nvarchar](max) NOT NULL,
	[PenaltyPolicy] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Contracts] PRIMARY KEY CLUSTERED 
(
	[ContractID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractTemplates]    Script Date: 10/28/2024 5:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractTemplates](
	[ContractTemplateId] [uniqueidentifier] NOT NULL,
	[TemplateName] [nvarchar](255) NOT NULL,
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
/****** Object:  Table [dbo].[DeliveriesMethod]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[HistoryTransactions]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[Orders]    Script Date: 10/28/2024 5:17:05 PM ******/
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
	[DeliveryMethod] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[AccountId] [nvarchar](450) NULL,
	[OrderDetailID] [uniqueidentifier] NULL,
	[DeliveriesMethodID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[Policies]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[ProductImages]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[ProductReports]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 10/28/2024 5:17:05 PM ******/
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
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSpecifications]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[ProductVouchers]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[Ratings]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[RentalPrices]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[Reports]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[Requests]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[ReturnDetails]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[Staffs]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[SupplierReports]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[SupplierRequests]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[Suppliers]    Script Date: 10/28/2024 5:17:05 PM ******/
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
	[VourcherID] [uniqueidentifier] NULL,
	[IsDisable] [bit] NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 10/28/2024 5:17:05 PM ******/
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
	[AccountID] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vourchers]    Script Date: 10/28/2024 5:17:05 PM ******/
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
/****** Object:  Table [dbo].[Wishlists]    Script Date: 10/28/2024 5:17:05 PM ******/
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
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'086b7a13-79af-4610-851d-204d9d84b865', N'STAFF', N'staff', N'086b7a13-79af-4610-851d-204d9d84b865')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1cf2de31-b0d8-4447-8f2f-c41df905a3a5', N'ADMIN', N'admin', N'1cf2de31-b0d8-4447-8f2f-c41df905a3a5')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'74bd6d3a-1119-449b-9743-3956d74e7575', N'SUPPLIER', N'supplier', N'74bd6d3a-1119-449b-9743-3956d74e7575')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9', N'MEMBER', N'member', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d', N'1cf2de31-b0d8-4447-8f2f-c41df905a3a5')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5aa7ee73-acf3-4110-8f5f-b296738b102e', N'74bd6d3a-1119-449b-9743-3956d74e7575')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8be335d3-1fd1-4cc6-8835-138dbee72ef5', N'74bd6d3a-1119-449b-9743-3956d74e7575')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ae32e359-256b-4609-9da7-c45a7327c5c9', N'74bd6d3a-1119-449b-9743-3956d74e7575')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0bab8444-ad59-4fe8-b1a4-559bc34275b0', 0, N'01447856963', N'An', N'An', NULL, NULL, 0, 0, 1, NULL, NULL, N'cf3VebDG7vQjwZ7HbKiMewwAjOVQLmUv8tkNUg9YwmVxxRZI07v1ItbGS5NtQqWysco+NoWUbDgNgIydShF/gg==', CAST(N'2024-10-19T00:00:00.0000000' AS DateTime2), N'F5B5F748-898E-4A91-AC47-08DCE8900678', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'supplier1@gmail.com', N'SUPPLIER1@GMAIL.COM', N'supplier1@gmail.com', N'SUPPLIER1@GMAIL.COM', N'AQAAAAIAAYagAAAAECJ1Ji9P04cJ3ftpVnynDXo51iFpbEPJ1j8r+gWysyWoTWsC0iC0r+bukD+HKYxUjg==', N'QBDEMHUSDRAECOUN5JMEESBAA3XBXX6U', N'0a4774cf-dd7c-4de3-b5b9-24e3f4016431', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2763dcc8-0b30-4c4a-b088-f7ee028b6443', 0, N'0862448677', N'Duy', N'Phạm Nhật', NULL, NULL, 0, 0, 0, NULL, N'ac2418', NULL, NULL, NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/cards%2F029681a6-86cf-4168-b1be-14ffe791b9c5_front.jpg.png?alt=media&token=0799b0a6-a25d-45d4-9292-9f84a97f86d0', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/cards%2F1d467e5b-8f34-453c-ab89-b080f97271b9_back.jpg.png?alt=media&token=992267b1-5094-47c1-8d3c-7e4b21425ce8', NULL, NULL, NULL, N'duypnse173520@fpt.edu.vn', N'DUYPNSE173520@FPT.EDU.VN', N'duypnse173520@fpt.edu.vn', N'DUYPNSE173520@FPT.EDU.VN', N'AQAAAAIAAYagAAAAEA0PDcnOc+Vbl4T2SQzxvezeS32D+vXuPKWMrDTf01hJatrudcJPeKboHf6Q/+l7tA==', N'33ASIQHUMGOZE7EPF7T64KFYNY2XCQKA', N'21bc6143-0596-4328-8c36-a1402d2ffd05', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d', 0, N'0817363768', N'Dương', N'An', NULL, NULL, 0, 0, 0, NULL, N'123041', N'DDT5j6odIUVzds69mn952LTg2UtCjwnpubZ/5HlbQv3afAK2vNeHtCKi11Kk4kaU3GFt22wqXOSbZp76FREy+Q==', CAST(N'2024-10-29T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, N'TPBANK', N'0999447788', N'Duong Binh An', N'andbse161205@fpt.edu.vn', N'ANDBSE161205@FPT.EDU.VN', N'andbse161205@fpt.edu.vn', N'ANDBSE161205@FPT.EDU.VN', N'AQAAAAIAAYagAAAAEAiGgaTeN1Pard3vBXzBQb9+okXC3eWP352mc/IJ/88PLkA2on7wXiZD0c7z/CzZMw==', N'ZVCENTNELDO3EXYRJRMXD6IUGIDCJLIV', N'8d22d809-1690-4243-a16d-64023df361dc', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3d2ca765-ab6d-4772-8a7c-32aa8c7ed4d0', 0, N'1234567890', N'John', N'Doe', NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'abc@gmail.com', N'ABC@GMAIL.COM', N'abc@gmail.com', N'ABC@GMAIL.COM', N'AQAAAAIAAYagAAAAEDz0s2qqnsNlZcfQ9cvY57ZlusxYIdjFv1D+iRTvyqhEPJlguv+TIDTaHqCjs6O8Zg==', N'XTDXZBEKRXSQ2GAKWXEL7U34DTGUVT6M', N'2132bb20-df44-447c-9fa6-ee4a8ccc8186', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3f720222-e872-40f7-b578-57413e13955e', 1, N'0901234568', N'Lê', N'Thị Kim Anh', NULL, NULL, 0, 0, 1, NULL, N'', N'Gy+/oYe+Dp+xVz50KPOvKSgimOdYQHCQbods+SoBJZfC1nLJTOhHKcSlMepyR2W1A1ppyqzq19QFuiuBETFqcQ==', CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'lethikimanh@gmail.com', N'LETHIKIMANH@GMAIL.COM', N'lethikimanh@gmail.com', N'LETHIKIMANH@GMAIL.COM', N'AQAAAAIAAYagAAAAEOazn8gTMpIRPWhA2kEs4NyQulNYOCxoCiNsA67hdbPT+cvxzSlNDkP+QbcxwPWilw==', N'3JLXRDO7NNDZJ6ZZIXHSLEMFQAZL453J', N'0b19e780-ee14-408c-bc92-80bd77054474', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'43cc4051-949e-4c52-bec6-bda4bba42b75', 1, N'0901234565', N'Đinh', N'Hoài Linh', NULL, NULL, 0, 0, 1, NULL, NULL, N'l8a+XffSaNXxnRq58BxdVVMwXOCZXDdnpjtNgqwS6Y9YzMluKTkNg7VfeZ1dzPSvBfal0fp9myP6NAI7qDe0DQ==', CAST(N'2024-10-19T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'dinhhoailinh@gmail.com', N'DINHHOAILINH@GMAIL.COM', N'dinhhoailinh@gmail.com', N'DINHHOAILINH@GMAIL.COM', N'AQAAAAIAAYagAAAAEBM94Wv9+CHuWBytY9TOELYkRAaWnow+ISHBLl2Ngj5bDNLwOLHQdKCiNKBwm8feqw==', N'2FNARJ34AANKJ2PF5NMJ4YTDOUURDEA6', N'ca4517f5-f4bc-4ec8-b2fc-3a4915b4d71a', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4ca7c186-8c45-4d88-a3e0-865ce8e7e653', 1, N'0901234567', N'Đỗ', N'Đức Mạnh', NULL, NULL, 1, 0, 1, NULL, N'218a84', N'CoVfIZntgYIsZPB6kXIH91i71ACy0HyDyyQQjUW7royUgd4VEi0x5vRvBrjCDGQtNVdlrA0LVFj2z9xGSFmnHDg==', CAST(N'2024-10-19T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'doducmanh@gmail.com', N'DODUCMANH@GMAIL.COM', N'doducmanh@gmail.com', N'DODUCMANH@GMAIL.COM', N'AQAAAAIAAYagAAAAEAYFe+aN4yyPNdDlG+FhjZzqa3RDwUTLL7VtPYynFsZUmCmlPz7ZRMX27YHP3/9e9g==', N'SH3EWSUP2Z7ZOFGQRXWQEZSRU52KRLVK', N'12e78545-73d8-41ab-bb76-7e50ef8b7af9', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5aa7ee73-acf3-4110-8f5f-b296738b102e', 1, N'0977445511', N'Nikon', N'VietNam', NULL, NULL, 0, 0, 1, NULL, NULL, N'5Lv3AfxzHETHK2kecdF859EV12cb8IKMTMHISlQxeE9zecnQbC8PKLqFJtW45CtHf54FPt91eHP3tguRNNJYmA==', CAST(N'2024-10-29T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F82f5bfbd-a851-4eb9-893b-5c1870329dad_front.jpg.png?alt=media&token=14e13eaa-67c9-479e-a75e-23c12b681335', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F682f03a6-f8de-4103-9f6d-1b53e52c7900_back.jpg.png?alt=media&token=ebdc0117-0ba7-49ff-b242-2e5689165dee', N'Ngân hàng TMCP Công thương Việt Nam', N'0914758856', N'Nguyen Van A', N'nguyenvana@gmail.com', N'NGUYENVANA@GMAIL.COM', N'nguyenvana@gmail.com', N'NGUYENVANA@GMAIL.COM', N'AQAAAAIAAYagAAAAEMS8jV6m1b4U0hN5lWuyH4NF8WpAW5VSvEZdiiHpSVs/TZaig5zyL9YlapmF3E2FyA==', N'24VLUS2XUKJE5OAZOLMUZOSZZAECNKI2', N'c6675108-c3f4-48b8-98a8-c63ef8a5a3f5', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8be335d3-1fd1-4cc6-8835-138dbee72ef5', 1, N'085745557799', N'Canon', N'VietNam', NULL, NULL, 0, 0, 1, NULL, NULL, N'DRDjxLRbnjIkFC/4e7mM3C5UiQiw3R9VrtKJKHLt27hjY8JnMAN1oHnTDPkFBcTLx/Kg0JI0HrouMPqDihPoUQ==', CAST(N'2024-10-28T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2Ffb5424be-80cc-4ffe-9230-99b337c7564c_front.jpg.png?alt=media&token=8cc3c710-c742-4fb0-b623-30df1d7ef3fd', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2Ff3c7a90a-468d-4014-b7c9-55ba478e75e2_back.jpg.png?alt=media&token=674ff88d-2c36-4fbd-bff9-015a8af7669e', N'Ngân hàng TMCP Phương Đông', N'0914758856', N'N8574555779B', N'nguyenvanb@gmail.com', N'NGUYENVANB@GMAIL.COM', N'nguyenvanb@gmail.com', N'NGUYENVANB@GMAIL.COM', N'AQAAAAIAAYagAAAAEPaYLtCeXVls8jDQjNaQX6P+4U8oU4LyTx3UEUbwJtWIlBxMSusv8sk5rK33PhH0CA==', N'P345SJO5R4ZIILRAMRSHEDERD2ZCCF62', N'98788936-9fa0-4167-902b-17578596d1c7', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'94e03446-55bb-4774-8335-edd00fcb3d02', 0, N'0901234569', N'Nguyễn', N'Tiến Đạt', NULL, NULL, 0, 0, 0, NULL, NULL, N'vC0I2+M7XXGZkH38ACwLgl40WGeSPT3cF8D7eVvZ1V52EwFRXVP6DcuRW6OM4k7Gk5SKX8rZAC+An2qCkh04og==', CAST(N'2024-10-19T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'ntdat117@gmail.com', N'NTDAT117@GMAIL.COM', N'ntdat117@gmail.com', N'NTDAT117@GMAIL.COM', N'AQAAAAIAAYagAAAAEJ6g+szEZp73wf9Z8O3lA7n5ydD7kPRD1P9qTDl3ZKkShG9oNeZkjH6SPN9kFY/mS4A==', N'X7SQCPAGFEMGUMPK4JW4YYBWZZYAYX2X', N'b10a3b18-5860-43a9-baba-efb4f41b7d03', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [SupplierID], [StaffID], [Img], [FrontOfCitizenIdentificationCard], [BackOfCitizenIdentificationCard], [BankName], [AccountNumber], [AccountHolder], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ae32e359-256b-4609-9da7-c45a7327c5c9', 0, N'1', N'An', N'An', NULL, NULL, 0, 0, 0, NULL, N'83e537', NULL, NULL, NULL, NULL, NULL, N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2F2ca421e6-2730-4493-8759-5ab9065fffee_front.jpg.png?alt=media&token=a7883985-6e81-48be-a5d3-b4a10f1b475e', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/account-citizen-identification-cards%2Fcf5cd11e-57bf-4ca4-bd2b-ffb3ffb5981d_back.jpg.png?alt=media&token=b89fea79-7f65-48fc-95bf-a93d6c4cf78a', N'1', N'1', N'1', N'abcd@gmail.com', N'ABCD@GMAIL.COM', N'abcd@gmail.com', N'ABCD@GMAIL.COM', N'AQAAAAIAAYagAAAAEMz/pY/dKxtvHeN4lNLjnaZiyFGGstoMNZ+UqchAUgBz7EyBlNIsYXNnYxU+bEwiIg==', N'JMETVGLIYVH5I62PJRZ3Z7US6YPEYJR6', N'c2227557-b3e0-4a1a-aff0-2b1853a7c408', 0, 0, NULL, 1, 0)
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
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [RentalPeriod]) VALUES (N'ceb88f45-d39f-485c-1382-08dcf6dfa17c', N'67a74e32-3728-4613-5a3e-08dcf6dfa137', N'f0b3d4b5-4b30-47f4-bddf-652651e039b5', 12000000, N'moi', 100, 11999900, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [Id], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [AccountId], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'67a74e32-3728-4613-5a3e-08dcf6dfa137', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'2e5c8fdc-ac5e-45ec-9c81-b6df24a7929d', CAST(N'2024-10-27T23:46:00.1229020' AS DateTime2), 0, 0, 0, NULL, NULL, 0, 0, NULL, N'1111111111111', 0, CAST(N'2024-10-27T23:46:00.1229057' AS DateTime2), CAST(N'2024-10-27T23:46:00.1229059' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [Id], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [AccountId], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'c89fce05-74e2-4ab2-8acc-08dcf6e36edb', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'2763dcc8-0b30-4c4a-b088-f7ee028b6443', CAST(N'2024-10-27T23:59:45.7431606' AS DateTime2), 0, 0, 0, NULL, NULL, 0, 0, NULL, N'string', 0, CAST(N'2024-10-27T23:59:45.7431608' AS DateTime2), CAST(N'2024-10-27T23:59:45.7431608' AS DateTime2), NULL, NULL, NULL)
GO
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'0d41cd03-cc60-4925-8914-24d455d02d59', N'f0b3d4b5-4b30-47f4-bddf-652651e039b5', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Ff0b3d4b5-4b30-47f4-bddf-652651e039b5_3abd1265-b0ac-43ee-8264-1f9ba52a097e.jpg.png?alt=media&token=3ceb9664-b1f9-46ed-b283-da99a081722c')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'98f63bef-c511-4dc1-a43d-8ae0ebd84039', N'8cba35ef-91a4-440e-94b4-1ef099f85222', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2F8cba35ef-91a4-440e-94b4-1ef099f85222_5eb6d7d7-9f64-45bb-8114-634f6c7d74b6.jpg.png?alt=media&token=a723aeff-967d-4f4c-b198-3bc9659406e6')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'84a9680b-4160-4bc4-bdd6-c965a209adf3', N'd7bd0251-127a-4f8c-b129-31835bb521a0', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/product-image%2Fd7bd0251-127a-4f8c-b129-31835bb521a0_bd1b3398-54e1-4158-956a-d6b8e658ef13.jpg.png?alt=media&token=5bdc4cd2-2dc3-4fec-bc5d-58b8c2732260')
GO
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'Canon99', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'3ed49ca1-fc18-4d3c-ac86-0b04f1d57f35', N'Canon99', N'a', NULL, NULL, 1, N'cũ', 1, 0, CAST(N'2024-10-26T23:50:20.4721751' AS DateTime2), CAST(N'2024-10-26T23:50:20.4722130' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'8cba35ef-91a4-440e-94b4-1ef099f85222', N'S!2222222222', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'649ede6e-0b8d-40d9-8d72-60f0c84fa9a1', N'MAy Anh Drone', N'Tốt', 0, 1500000, 6, N'moi', 0, 0, CAST(N'2024-10-28T01:28:24.8393210' AS DateTime2), CAST(N'2024-10-28T01:28:24.8393372' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'693066d2-fc74-4bba-bae1-21914762d76e', N'Canon19', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'ac5cf81c-3667-43fc-add0-cc2ee9c23a72', N'Canon199', N'string', NULL, NULL, 1, N'moi', 0, 0, CAST(N'2024-10-28T01:49:51.0363127' AS DateTime2), CAST(N'2024-10-28T04:30:24.0893120' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'd7bd0251-127a-4f8c-b129-31835bb521a0', N'test', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'f300bbc9-9960-4543-8b91-0caf450a8e43', N'MAy Anh', N's', 0, 10000000, 1, N'moi', 0, 0, CAST(N'2024-10-28T01:38:29.7645531' AS DateTime2), CAST(N'2024-10-28T01:38:29.7645816' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'f0b3d4b5-4b30-47f4-bddf-652651e039b5', N'SN001', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'3ed49ca1-fc18-4d3c-ac86-0b04f1d57f35', N'Canon EOS 90D', N'Máy ảnh DSLR chuyên nghiệp cho nhiếp ảnh gia', NULL, 12000000, 0, N'moi', 3, 0, CAST(N'2024-10-26T18:35:31.1080560' AS DateTime2), CAST(N'2024-10-26T18:35:31.1081036' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'db30b319-a22a-4fbb-bef2-8d2207270e9e', N'SN123456789', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'aade6136-80a9-4348-b079-cbbd0edfd3b0', N'MAy Anh1', N'qqqqqqqqqqq', 50000, 5000, 0, N'moi', 0, 0, CAST(N'2024-10-28T01:09:32.0890208' AS DateTime2), CAST(N'2024-10-28T01:09:32.0890637' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'7fc1f33b-aee1-4f21-beee-d754572a4f52', N'SNCanon1990', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'3ed49ca1-fc18-4d3c-ac86-0b04f1d57f35', N'Máy ảnh canon SN35', N'dành cho người chụp chân dung', NULL, NULL, 1, N'mới', 1, 0, CAST(N'2024-10-26T22:58:20.0103969' AS DateTime2), CAST(N'2024-10-26T22:58:20.0104513' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', N'MN0909', N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'3ed49ca1-fc18-4d3c-ac86-0b04f1d57f35', N'Máy anh canonMN0909', N'a', NULL, NULL, 1, N'mới', 1, 0, CAST(N'2024-10-26T23:19:55.3766577' AS DateTime2), CAST(N'2024-10-26T23:19:55.3767147' AS DateTime2))
GO
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'3cb71a3e-b3d0-447b-a937-1b1e051f21a5', N'f0b3d4b5-4b30-47f4-bddf-652651e039b5', N'Độ phân giải tối đa ', N' 6960 x 4640')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'b14eb0ad-b787-46f2-b3d7-69248ced2ca7', N'8cba35ef-91a4-440e-94b4-1ef099f85222', N'Cảm ứng ', N' tốt')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'c26c7c8f-8f5e-496d-979b-72c59d39df94', N'7fc1f33b-aee1-4f21-beee-d754572a4f52', N'độ phân giải', N'120px')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'e531ebb5-1151-4c83-b5bb-a65ce640551d', N'b29a096b-5f7f-43c8-b737-120ab897cd75', N'thân máy', N'12cm')
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'bac5e4c8-0c07-4ff9-a775-abea4f4fcfe1', N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', N'độ phân giải', N'40px')
GO
INSERT [dbo].[ProductVouchers] ([ProductVoucherID], [ProductID], [VourcherID], [CreatedAt], [UpdatedAt], [IsDisable]) VALUES (N'611a6fcd-2361-4c00-a36c-f5fd905c5c4a', N'f0b3d4b5-4b30-47f4-bddf-652651e039b5', N'b5e357fe-4afb-4153-a13d-ab81d901e2b9', CAST(N'2024-10-27T02:25:52.7557835' AS DateTime2), CAST(N'2024-10-27T02:25:52.7557835' AS DateTime2), 0)
GO
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'f1bba992-64b9-428b-904b-38b8a315fc8c', N'a3dc3f4d-9d1d-44e2-b005-ea2054ac99ae', 1, NULL, NULL, NULL, CAST(N'2024-10-26T23:19:55.3771997' AS DateTime2), CAST(N'2024-10-26T23:19:55.3772592' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'572a17ef-a5cb-4682-bce6-4ea011b6ee57', N'b29a096b-5f7f-43c8-b737-120ab897cd75', 1, NULL, NULL, NULL, CAST(N'2024-10-26T23:50:20.4727211' AS DateTime2), CAST(N'2024-10-26T23:50:20.4727725' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'1795e900-1a7a-4346-aadc-4ecb0b9d8bfd', N'693066d2-fc74-4bba-bae1-21914762d76e', 10, 0, 0, 0, CAST(N'2024-10-28T01:49:51.0367720' AS DateTime2), CAST(N'2024-10-28T01:49:51.0368538' AS DateTime2))
INSERT [dbo].[RentalPrices] ([RentalPriceID], [ProductID], [PricePerHour], [PricePerDay], [PricePerWeek], [PricePerMonth], [CreatedAt], [UpdatedAt]) VALUES (N'75c86eed-bb79-4eaf-92c9-68acac3b7969', N'7fc1f33b-aee1-4f21-beee-d754572a4f52', 100000, NULL, NULL, NULL, CAST(N'2024-10-26T22:58:22.5292565' AS DateTime2), CAST(N'2024-10-26T22:58:22.5293273' AS DateTime2))
GO
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [AccountBalance], [Img], [IsDisable]) VALUES (N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'5aa7ee73-acf3-4110-8f5f-b296738b102e', N'Nikon', N'đem đến trải nghiệm rất tốt', N'188 Trần Bá Giao , P5, GV, TPHCM', N'07989999999', NULL, NULL, NULL, CAST(N'2024-10-26T17:40:07.8301292' AS DateTime2), CAST(N'2024-10-26T17:40:07.8301707' AS DateTime2), 0, NULL, 0)
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [AccountBalance], [Img], [IsDisable]) VALUES (N'ffb0ae5f-10f2-48d7-329f-08dcf5e53bbf', N'8be335d3-1fd1-4cc6-8835-138dbee72ef5', N'Nikon', N'Dịch vụ máy ảnh từ nhà cung cấp Canon đem đến cho bạn những trai nghiệm tuyệt vời ', N'188 Nguyễn Xiển, Thành phố Thủ Đức, TP HCM', N'07989878787', NULL, NULL, NULL, CAST(N'2024-10-26T17:56:00.4345177' AS DateTime2), CAST(N'2024-10-26T17:56:00.4345179' AS DateTime2), 0, NULL,  0)
GO
INSERT INTO [dbo].[Vourchers] 
    ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) 
VALUES 
    (NEWID(), N'980936d8-bb35-4432-329d-08dcf5e53bbf', N'DISC2024', N'Giảm giá 100k cho đơn hàng đầu tiên', 100, 
    CAST(N'2024-10-27T00:00:00.0000000' AS DateTime2), 
    CAST(N'2024-12-31T23:59:59.0000000' AS DateTime2), 1, 
    CAST(N'2024-10-27T02:17:54.1912484' AS DateTime2), 
    CAST(N'2024-10-27T02:17:54.1912485' AS DateTime2));

GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contracts_ContractTemplateId]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Contracts_ContractTemplateId] ON [dbo].[Contracts]
(
	[ContractTemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contracts_OrderID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Contracts_OrderID] ON [dbo].[Contracts]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ContractTemplates_AccountID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ContractTemplates_AccountID] ON [dbo].[ContractTemplates]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HistoryTransactions_SupplierID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_HistoryTransactions_SupplierID] ON [dbo].[HistoryTransactions]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_OrderID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderID] ON [dbo].[OrderDetails]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_ProductID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductID] ON [dbo].[OrderDetails]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Orders_AccountId]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_AccountId] ON [dbo].[Orders]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_DeliveriesMethodID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_DeliveriesMethodID] ON [dbo].[Orders]
(
	[DeliveriesMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_SupplierID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_SupplierID] ON [dbo].[Orders]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Payments_AccountID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_AccountID] ON [dbo].[Payments]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_OrderID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_OrderID] ON [dbo].[Payments]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_SupplierID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_SupplierID] ON [dbo].[Payments]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductImages_ProductID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductImages_ProductID] ON [dbo].[ProductImages]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ProductReports_Account]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductReports_Account] ON [dbo].[ProductReports]
(
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductReports_ProductID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductReports_ProductID] ON [dbo].[ProductReports]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductReports_SupplierID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductReports_SupplierID] ON [dbo].[ProductReports]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryID] ON [dbo].[Products]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_SupplierID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_SupplierID] ON [dbo].[Products]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductSpecifications_ProductID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductSpecifications_ProductID] ON [dbo].[ProductSpecifications]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductVouchers_ProductID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductVouchers_ProductID] ON [dbo].[ProductVouchers]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductVouchers_VourcherID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductVouchers_VourcherID] ON [dbo].[ProductVouchers]
(
	[VourcherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Ratings_AccountID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Ratings_AccountID] ON [dbo].[Ratings]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Ratings_ProductID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Ratings_ProductID] ON [dbo].[Ratings]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RentalPrices_ProductID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_RentalPrices_ProductID] ON [dbo].[RentalPrices]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Reports_AccountId]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reports_AccountId] ON [dbo].[Reports]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Requests_AccountID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Requests_AccountID] ON [dbo].[Requests]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ReturnDetails_OrderID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ReturnDetails_OrderID] ON [dbo].[ReturnDetails]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Staffs_AccountID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Staffs_AccountID] ON [dbo].[Staffs]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SupplierReports_AccountID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierReports_AccountID] ON [dbo].[SupplierReports]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierReports_StaffID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierReports_StaffID] ON [dbo].[SupplierReports]
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierReports_SupplierID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierReports_SupplierID] ON [dbo].[SupplierReports]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierRequests_SupplierID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierRequests_SupplierID] ON [dbo].[SupplierRequests]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Suppliers_AccountID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Suppliers_AccountID] ON [dbo].[Suppliers]
(
	[AccountID] ASC
)
WHERE ([AccountID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Transactions_AccountID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transactions_AccountID] ON [dbo].[Transactions]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_OrderID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Transactions_OrderID] ON [dbo].[Transactions]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Wishlists_AccountID]    Script Date: 10/28/2024 5:17:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Wishlists_AccountID] ON [dbo].[Wishlists]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Wishlists_ProductID]    Script Date: 10/28/2024 5:17:14 PM ******/
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
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_DeliveriesMethod_DeliveriesMethodID] FOREIGN KEY([DeliveriesMethodID])
REFERENCES [dbo].[DeliveriesMethod] ([DeliveriesMethodID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_DeliveriesMethod_DeliveriesMethodID]
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
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_AspNetUsers_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_AspNetUsers_AccountID]
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
