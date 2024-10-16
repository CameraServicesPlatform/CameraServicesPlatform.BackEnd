USE [master]
GO
/****** Object:  Database [CameraCapstone]    Script Date: 14/10/2024 5:50:43 PM ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14/10/2024 5:50:43 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 14/10/2024 5:50:44 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 14/10/2024 5:50:44 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 14/10/2024 5:50:44 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 14/10/2024 5:50:44 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 14/10/2024 5:50:44 PM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 14/10/2024 5:50:44 PM ******/
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
	[StaffID] [nvarchar](max) NULL,
	[SupplierID] [nvarchar](max) NULL,
	[Img] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 14/10/2024 5:50:44 PM ******/
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
/****** Object:  Table [dbo].[BankInformation]    Script Date: 14/10/2024 5:50:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankInformation](
	[BankId] [uniqueidentifier] NOT NULL,
	[BankName] [nvarchar](max) NOT NULL,
	[AccountNumber] [nvarchar](max) NOT NULL,
	[AccountHolder] [nvarchar](max) NOT NULL,
	[MemberId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_BankInformation] PRIMARY KEY CLUSTERED 
(
	[BankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 14/10/2024 5:50:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [uniqueidentifier] NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
	[CategoryDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contracts]    Script Date: 14/10/2024 5:50:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contracts](
	[ContractID] [uniqueidentifier] NOT NULL,
	[OrderID] [uniqueidentifier] NOT NULL,
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
/****** Object:  Table [dbo].[DeliveriesMethod]    Script Date: 14/10/2024 5:50:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveriesMethod](
	[DeliveriesMethodID] [uniqueidentifier] NOT NULL,
	[MethodName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_DeliveriesMethod] PRIMARY KEY CLUSTERED 
(
	[DeliveriesMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 14/10/2024 5:50:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[MemberID] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Job] [int] NULL,
	[Hobby] [int] NULL,
	[Gender] [int] NOT NULL,
	[Dob] [datetime2](7) NOT NULL,
	[IsAdult] [bit] NOT NULL,
	[Money] [float] NOT NULL,
	[AccountID] [nvarchar](450) NULL,
	[JoinedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsVerfiedPhoneNumber] [bit] NULL,
	[IsVerifiedEmail] [bit] NULL,
	[VerficationCodePhoneNumber] [nvarchar](max) NULL,
	[VerficationCodeEmail] [nvarchar](max) NULL,
	[Img] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 14/10/2024 5:50:44 PM ******/
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
/****** Object:  Table [dbo].[OrderHistory]    Script Date: 14/10/2024 5:50:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderHistory](
	[OrderHistoryID] [uniqueidentifier] NOT NULL,
	[MemberID] [uniqueidentifier] NOT NULL,
	[OrderID] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[TotalAmount] [float] NOT NULL,
	[OrderDetails] [nvarchar](max) NOT NULL,
	[OrderStatus] [int] NOT NULL,
 CONSTRAINT [PK_OrderHistory] PRIMARY KEY CLUSTERED 
(
	[OrderHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 14/10/2024 5:50:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [uniqueidentifier] NOT NULL,
	[SupplierID] [uniqueidentifier] NOT NULL,
	[MemberID] [uniqueidentifier] NOT NULL,
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
	[OrderDetailID] [uniqueidentifier] NULL,
	[DeliveriesMethodID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Policies]    Script Date: 14/10/2024 5:50:44 PM ******/
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
 CONSTRAINT [PK_Policies] PRIMARY KEY CLUSTERED 
(
	[PolicyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 14/10/2024 5:50:44 PM ******/
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
/****** Object:  Table [dbo].[ProductReports]    Script Date: 14/10/2024 5:50:44 PM ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 14/10/2024 5:50:44 PM ******/
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
/****** Object:  Table [dbo].[ProductSpecifications]    Script Date: 14/10/2024 5:50:44 PM ******/
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
/****** Object:  Table [dbo].[ProductVouchers]    Script Date: 14/10/2024 5:50:44 PM ******/
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
 CONSTRAINT [PK_ProductVouchers] PRIMARY KEY CLUSTERED 
(
	[ProductVoucherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 14/10/2024 5:50:44 PM ******/
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
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[RatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 14/10/2024 5:50:44 PM ******/
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
/****** Object:  Table [dbo].[ReturnDetails]    Script Date: 14/10/2024 5:50:44 PM ******/
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
 CONSTRAINT [PK_ReturnDetails] PRIMARY KEY CLUSTERED 
(
	[ReturnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 14/10/2024 5:50:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[StaffID] [uniqueidentifier] NOT NULL,
	[AccountID] [nvarchar](450) NOT NULL,
	[JobTitle] [nvarchar](max) NOT NULL,
	[Department] [nvarchar](max) NOT NULL,
	[StaffStatus] [nvarchar](max) NOT NULL,
	[HireDate] [datetime2](7) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[Img] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Staffs] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierReports]    Script Date: 14/10/2024 5:50:44 PM ******/
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
	[HandledBy] [uniqueidentifier] NOT NULL,
	[HandledByAccountId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_SupplierReports] PRIMARY KEY CLUSTERED 
(
	[SupplierReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierRequests]    Script Date: 14/10/2024 5:50:44 PM ******/
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
/****** Object:  Table [dbo].[Suppliers]    Script Date: 14/10/2024 5:50:44 PM ******/
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
	[ContactNumber] [nvarchar](20) NULL,
	[SupplierLogo] [nvarchar](max) NULL,
	[BlockReason] [nvarchar](max) NULL,
	[BlockedAt] [datetime2](7) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[AccountBalance] [float] NOT NULL,
	[VourcherID] [uniqueidentifier] NULL,
	[Img] [nvarchar](max) NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 14/10/2024 5:50:44 PM ******/
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
	[BankId] [uniqueidentifier] NOT NULL,
	[BankInformationBankId] [uniqueidentifier] NOT NULL,
	[MemberId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vourchers]    Script Date: 14/10/2024 5:50:44 PM ******/
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240918072721_InitTable', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240919213243_RemoveWarmmingForgeinKey', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240920161058_VPS', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240922072935_UpdateMembertable', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240922075350_ChangeTyleDecimalToDouble', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240922075504_ChangeTyleDecimalToDouble2nd', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240922083744_fixReportForgienKeyAccount', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240922223534_UpdateCategoryIDType', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240925071144_FixCategoryIDType', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240925072542_productfix', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240929095133_Update', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240929111359_UpdateRole', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241005161133_[UpdateAccountField]', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241005162644_[UpdateProdcutReport]', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241005191431_[vourcher]', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241006050945_[updateProduct]', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241006052157_[updateProduct]', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241006054901_[addProductVoucher]', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241006081905_[UpdateProduct]', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241007172642_[account]', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241007212254_[accountupdate]', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241008142953_[rolename]', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241009135028_[fiximgnullSupplier]', N'8.0.8')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'086b7a13-79af-4610-851d-204d9d84b865', N'STAFF', N'staff', N'086b7a13-79af-4610-851d-204d9d84b865')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1cf2de31-b0d8-4447-8f2f-c41df905a3a5', N'ADMIN', N'admin', N'1cf2de31-b0d8-4447-8f2f-c41df905a3a5')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'74bd6d3a-1119-449b-9743-3956d74e7575', N'SUPPLIER', N'supplier', N'74bd6d3a-1119-449b-9743-3956d74e7575')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9', N'MEMBER', N'member', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4ca7c186-8c45-4d88-a3e0-865ce8e7e653', N'086b7a13-79af-4610-851d-204d9d84b865')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8f8a606e-f696-435b-af50-017505328399', N'1cf2de31-b0d8-4447-8f2f-c41df905a3a5')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0bab8444-ad59-4fe8-b1a4-559bc34275b0', N'74bd6d3a-1119-449b-9743-3956d74e7575')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'633d54c5-44cd-4c96-b04f-c8499bf72f2a', N'74bd6d3a-1119-449b-9743-3956d74e7575')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'aaa9fe0a-98eb-41f5-819d-e4e6a0263c4c', N'74bd6d3a-1119-449b-9743-3956d74e7575')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3f720222-e872-40f7-b578-57413e13955e', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'43cc4051-949e-4c52-bec6-bda4bba42b75', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4ca7c186-8c45-4d88-a3e0-865ce8e7e653', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4e371651-c4e2-40ec-a4e0-75dc6a233d1e', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4eec7749-ba5d-407d-a643-bc3c5a48e461', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a03ade30-d417-4ba2-9bf4-a49ef20248d0', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'be266567-7b48-41d1-ac22-ca0f48ded153', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd08801b4-9d36-4506-9231-e6253ddffb91', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd6752203-c978-48a0-aaf5-fd8bd3ff586e', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f3907f15-6a42-4f20-a6a1-53e53aa3458e', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ff8f2265-c820-41f0-b377-cc7ef0d03374', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StaffID], [SupplierID], [Img]) VALUES (N'0bab8444-ad59-4fe8-b1a4-559bc34275b0', 0, N'01447856963', N'An', N'An', NULL, NULL, 0, 0, 1, NULL, NULL, N'4zR4VWxIm/Vc1BZnEitLza1vWml54K98r+/pzN5pp5EJEu2X0kV+6v/CY6q+9MeGOJoFC1iYnf+WAe/ngAlZrQ==', CAST(N'2024-10-11T00:00:00.0000000' AS DateTime2), N'supplier1@gmail.com', N'SUPPLIER1@GMAIL.COM', N'supplier1@gmail.com', N'SUPPLIER1@GMAIL.COM', N'AQAAAAIAAYagAAAAECJ1Ji9P04cJ3ftpVnynDXo51iFpbEPJ1j8r+gWysyWoTWsC0iC0r+bukD+HKYxUjg==', N'QBDEMHUSDRAECOUN5JMEESBAA3XBXX6U', N'0a4774cf-dd7c-4de3-b5b9-24e3f4016431', 0, 0, NULL, 1, 0, NULL, N'F5B5F748-898E-4A91-AC47-08DCE8900678', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StaffID], [SupplierID], [Img]) VALUES (N'3d2ca765-ab6d-4772-8a7c-32aa8c7ed4d0', 0, N'1234567890', N'John', N'Doe', NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL, N'abc@gmail.com', N'ABC@GMAIL.COM', N'abc@gmail.com', N'ABC@GMAIL.COM', N'AQAAAAIAAYagAAAAEDz0s2qqnsNlZcfQ9cvY57ZlusxYIdjFv1D+iRTvyqhEPJlguv+TIDTaHqCjs6O8Zg==', N'XTDXZBEKRXSQ2GAKWXEL7U34DTGUVT6M', N'2132bb20-df44-447c-9fa6-ee4a8ccc8186', 0, 0, NULL, 1, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StaffID], [SupplierID], [Img]) VALUES (N'3f720222-e872-40f7-b578-57413e13955e', 1, N'0901234568', N'Lê', N'Thị Kim Anh', NULL, NULL, 0, 0, 1, NULL, N'', N'Gy+/oYe+Dp+xVz50KPOvKSgimOdYQHCQbods+SoBJZfC1nLJTOhHKcSlMepyR2W1A1ppyqzq19QFuiuBETFqcQ==', CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2), N'lethikimanh@gmail.com', N'LETHIKIMANH@GMAIL.COM', N'lethikimanh@gmail.com', N'LETHIKIMANH@GMAIL.COM', N'AQAAAAIAAYagAAAAEOazn8gTMpIRPWhA2kEs4NyQulNYOCxoCiNsA67hdbPT+cvxzSlNDkP+QbcxwPWilw==', N'3JLXRDO7NNDZJ6ZZIXHSLEMFQAZL453J', N'0b19e780-ee14-408c-bc92-80bd77054474', 0, 0, NULL, 1, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StaffID], [SupplierID], [Img]) VALUES (N'43cc4051-949e-4c52-bec6-bda4bba42b75', 1, N'0901234565', N'Đinh', N'Hoài Linh', NULL, NULL, 0, 0, 1, NULL, NULL, N'vMYRia/tW8r4tkNlOVCCNp616G4SUc7oA7tiNkW83HcLxqo/s5NJ3ubEKblP9SHVcseqnma/fnTX1O1S8gmrPQ==', CAST(N'2024-10-04T00:00:00.0000000' AS DateTime2), N'dinhhoailinh@gmail.com', N'DINHHOAILINH@GMAIL.COM', N'dinhhoailinh@gmail.com', N'DINHHOAILINH@GMAIL.COM', N'AQAAAAIAAYagAAAAEBM94Wv9+CHuWBytY9TOELYkRAaWnow+ISHBLl2Ngj5bDNLwOLHQdKCiNKBwm8feqw==', N'2FNARJ34AANKJ2PF5NMJ4YTDOUURDEA6', N'ca4517f5-f4bc-4ec8-b2fc-3a4915b4d71a', 0, 0, NULL, 1, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StaffID], [SupplierID], [Img]) VALUES (N'4ca7c186-8c45-4d88-a3e0-865ce8e7e653', 1, N'0901234567', N'Đỗ', N'Đức Mạnh', NULL, NULL, 1, 0, 1, NULL, N'218a84', N'dEQ/hfJfVcdULTWkot1EG1MNVuCd09Nzgl50VQM0WqlRcYlgVz79jDhzVpx2lUc138ceyW3HpMOWAxpjH9c9eg==', CAST(N'2024-10-11T00:00:00.0000000' AS DateTime2), N'doducmanh@gmail.com', N'DODUCMANH@GMAIL.COM', N'doducmanh@gmail.com', N'DODUCMANH@GMAIL.COM', N'AQAAAAIAAYagAAAAED8w17uBI4t6ASih7M37jQ1pUU2N++aN28Dvm433R1SaQsD7pEfyzsVqJlmRbVBnFA==', N'6NUEURM6BFXMVDSBDL7IDJNUMTPYFQ2O', N'321f6541-1b8a-4e3b-baf8-30f4545dd901', 0, 0, NULL, 1, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StaffID], [SupplierID], [Img]) VALUES (N'4e371651-c4e2-40ec-a4e0-75dc6a233d1e', 1, N'0901234561', N'Nguyễn', N'Minh Thư', NULL, NULL, 0, 0, 1, NULL, N'adf8c5', N'Ekthxd3kSfecQZ/HQ9W7M/bVMYvRVMhP5TTiglOvzOBKEUwyS8On8KJbCAdg+rrpGRuA/FVWpA9cEInFebnjNg==', CAST(N'2024-10-09T00:00:00.0000000' AS DateTime2), N'nguyenminhthu@gmail.com', N'NGUYENMINHTHU@GMAIL.COM', N'nguyenminhthu@gmail.com', N'NGUYENMINHTHU@GMAIL.COM', N'AQAAAAIAAYagAAAAEGn4UnxM30TFATG1COG6TtKGo/4u43k4YthjXyzll8TlddXHWtlUYg/cqdd3caWgxw==', N'QMTTY3YKP4WADGQ7CU7XKWR73FQI2DOW', N'9127534b-cd8a-455b-a3d5-ef7d389b134b', 0, 0, NULL, 1, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StaffID], [SupplierID], [Img]) VALUES (N'4eec7749-ba5d-407d-a643-bc3c5a48e461', 1, N'0901234566', N'Hoàng', N'Văn Hiếu', NULL, NULL, 1, 0, 1, NULL, N'218a83', N'JjbwJlAijPgx4yPcf9KLDSPV7CGFi92f0MwnbVRSf6GsP+FA7zW4RAtvPIEXLo7aw9Gd7H64ELjZTYEtcrCqIw==', CAST(N'2024-10-11T00:00:00.0000000' AS DateTime2), N'hoangvanhieu@gmail.com', N'HOANGVANHIEU@GMAIL.COM', N'hoangvanhieu@gmail.com', N'HOANGVANHIEU@GMAIL.COM', N'AQAAAAIAAYagAAAAELubfSKBK1wjikeyJ62QpTKJAndFFs/h15QNUhPrRTJBjWEi668CorzrEStpf3ky/Q==', N'2JMBZ57WPVE47EI7X3PL7BPXBT6NPIGM', N'7b05ec22-f323-420f-998f-a2dc696bd55b', 0, 0, NULL, 1, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StaffID], [SupplierID], [Img]) VALUES (N'633d54c5-44cd-4c96-b04f-c8499bf72f2a', 0, N'0914363355', N'Supplier', N'An', NULL, NULL, 0, 0, 1, NULL, NULL, N'AyhZCFD22O6Wd2VoQsx2yTCj1MGONks4x03+G86O/GbVfCtzxjlbJ5G963xxTR1iYDV85XKGGKMobyckLuuX5g==', CAST(N'2024-10-11T00:00:00.0000000' AS DateTime2), N'supplier1234@gmail.com', N'SUPPLIER1234@GMAIL.COM', N'supplier1234@gmail.com', N'SUPPLIER1234@GMAIL.COM', N'AQAAAAIAAYagAAAAEBeJmdscxxUHHdY7GXsUUChhV73pC0z/9QMqtcQMlEcsossyfXTmdWLPc/dGcmADGg==', N'QHN6BX5TBCS6H673ENXTOEDCQYU2U3OX', N'74e677f3-a7dc-4d8e-bf81-0751ee94186c', 0, 0, NULL, 1, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StaffID], [SupplierID], [Img]) VALUES (N'8f8a606e-f696-435b-af50-017505328399', 0, N'0944557788', N'Duong Binh An (K16_HCM)', N'An', NULL, NULL, 0, 0, 1, NULL, N'', N'LjlnxVKJko4sap57bH0J5yzT+jQB0wXmgTRDDS1OLMEaMuyr5RTtfqKPmuXxG453jo/IVvyoDCvDl1T4GczQ0w==', CAST(N'2024-10-11T00:00:00.0000000' AS DateTime2), N'andbse161205@fpt.edu.vn', N'ANDBSE161205@FPT.EDU.VN', N'andbse161205@fpt.edu.vn', N'ANDBSE161205@FPT.EDU.VN', N'AQAAAAIAAYagAAAAEJ03EtLxiZvSka6+85YfUCT45uhJOHwDilqYzlTUHhXdRfnpd8Jw3lljs6rS0Lbo+Q==', N'M3Y6QL46UHQGF5OXJYA3B4EZXHA4WRFD', N'a138ac4b-d460-4d43-b358-d515c3d69a22', 0, 0, NULL, 1, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StaffID], [SupplierID], [Img]) VALUES (N'a03ade30-d417-4ba2-9bf4-a49ef20248d0', 1, N'0817363768', N'string', N'string', NULL, NULL, 1, 0, 1, NULL, N'218a81', NULL, NULL, N'buitrunghieu@gmail.com', N'BUITRUNGHIEU@GMAIL.COM', N'buitrunghieu@gmail.com', N'BUITRUNGHIEU@GMAIL.COM', N'AQAAAAIAAYagAAAAEKn+dtDSeeAQ13Gd+dM6gB5Un37P3cwD130pGu8UMMNVGzJcumvyOH3UEYJ5mQs4LA==', N'E5NIFUSWSD5AHDCNC2DOEPAQ53IGUOCG', N'94350ed7-e287-4364-8d94-9d6e0d971d3e', 0, 0, NULL, 1, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StaffID], [SupplierID], [Img]) VALUES (N'aaa9fe0a-98eb-41f5-819d-e4e6a0263c4c', 0, N'string', N'string', N'string', NULL, NULL, 0, 0, 1, NULL, NULL, N'WOU2Okz6S/RzldMhvlr+oQUH5cEe0LgO3gXhe5AnHSs/2l4iG6g9RFVkbZnUhu7z6gVuU/kbPubRtmCQ+7Gqcw==', CAST(N'2024-10-11T00:00:00.0000000' AS DateTime2), N'test@gmail.com', N'TEST@GMAIL.COM', N'test@gmail.com', N'TEST@GMAIL.COM', N'AQAAAAIAAYagAAAAEHb7x9e2K93kHy2D6yLKe/4G5o1nR9Kq8VBtdkvD4IeRQ17C85gMKOIER0s9xvnVzA==', N'HVYQFTHEAWRQLH6ZMER5PW5LXQLIZ7RC', N'4c0b2214-3edc-44da-9762-28d1580ebfae', 0, 0, NULL, 1, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StaffID], [SupplierID], [Img]) VALUES (N'be266567-7b48-41d1-ac22-ca0f48ded153', 1, N'0901234567', N'Nguyễn', N'Văn Anh', NULL, NULL, 1, 0, 1, NULL, N'fa5093', NULL, NULL, N'nguyenvananh@gmail.com', N'NGUYENVANANH@GMAIL.COM', N'nguyenvananh@gmail.com', N'NGUYENVANANH@GMAIL.COM', N'AQAAAAIAAYagAAAAEIVZu1Y6O2ExBESfoQC5zTErJHLnf33VGuzW/SpwFcU7EONMiObqN0GKBUoQTP3vbQ==', N'TQGNUHKZR6JJ7JJQCRNLJWBUO2S6RMUT', N'39667ef9-e0b4-4ecf-909d-205ffbd747b7', 0, 0, NULL, 1, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StaffID], [SupplierID], [Img]) VALUES (N'd08801b4-9d36-4506-9231-e6253ddffb91', 1, N'0901234564', N'Phạm', N'Thanh Sơn', NULL, NULL, 1, 0, 1, NULL, N'9a9ea3', NULL, NULL, N'phamthanhson@gmail.com', N'PHAMTHANHSON@GMAIL.COM', N'phamthanhson@gmail.com', N'PHAMTHANHSON@GMAIL.COM', N'AQAAAAIAAYagAAAAECp2OVPqrMKdMa9Qp+4ICKe3WMR9tTt5fNrfSUJxfLWoAwaLS0kf8AP8iSHYF1BJLg==', N'YYOXRLL7AFUUWT7RCJAHDFYUPV5GD4FB', N'48829aa1-3c2f-46e4-9460-c49caa3968d9', 0, 0, NULL, 1, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StaffID], [SupplierID], [Img]) VALUES (N'd6752203-c978-48a0-aaf5-fd8bd3ff586e', 0, N'0901234562', N'Trần', N'Quốc Anh', NULL, NULL, 1, 0, 1, NULL, NULL, N'CwQkpp7GoRvmHlvnB/PXs2584xcg4suTZPCcsWEF0jcgiebcpFWBR5Yyn9BhSwKWyoiH5bJ0F1OEMJdy00rKxg==', CAST(N'2024-10-09T00:00:00.0000000' AS DateTime2), N'tranquocanh@gmail.com', N'TRANQUOCANH@GMAIL.COM', N'tranquocanh@gmail.com', N'TRANQUOCANH@GMAIL.COM', N'AQAAAAIAAYagAAAAEN/kSSHpos5grfpgXfok2cxQkPVTIdYST5vSsZpA5GK9s9kIxrhSkcLzaCflyjjFLA==', N'4CCHBLICCKNKBCTONRLALA5NNY7W75RP', N'7920d133-3997-48d1-8d16-1f86e09b0bfd', 0, 0, NULL, 1, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StaffID], [SupplierID], [Img]) VALUES (N'f3907f15-6a42-4f20-a6a1-53e53aa3458e', 1, N'0901234563', N'Lê', N'Bích Ngọc', NULL, NULL, 0, 0, 0, NULL, N'6e7500', NULL, NULL, N'lebichngoc@gmail.com', N'LEBICHNGOC@GMAIL.COM', N'lebichngoc@gmail.com', N'LEBICHNGOC@GMAIL.COM', N'AQAAAAIAAYagAAAAEH+aT06V7w1BQdJ7rgl4f+7P4MgZjlshMNtrR4BiD6x0bgbK6czlC8ghCrudcfYFQg==', N'I526I4VKTVHII54M5CCAAAFUWKJADZOL', N'9a0f597e-2647-4e1e-a94f-39811869ea87', 0, 0, NULL, 1, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Job], [Hobby], [Gender], [IsDeleted], [IsVerified], [Address], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StaffID], [SupplierID], [Img]) VALUES (N'ff8f2265-c820-41f0-b377-cc7ef0d03374', 0, N'0901234570', N'Nguyễn', N'Thị Thanh', NULL, NULL, 0, 0, 1, NULL, N'218a82', NULL, NULL, N'nguyenthithanh@gmail.com', N'NGUYENTHITHANH@GMAIL.COM', N'nguyenthithanh@gmail.com', N'NGUYENTHITHANH@GMAIL.COM', N'AQAAAAIAAYagAAAAELHngf3hRRYyVP6+seHRl5HDT89bEEsKMB87LNnnDdA27t5vGmDIeXQ4WoF/KgKbnw==', N'P3YQ5IZGXXBN4POE56IRS6AUNAI2KMNX', N'ab4c22e7-8b93-49ce-84e2-fe1d6ce4ac5a', 0, 0, NULL, 1, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'd39481af-f68e-4a41-b5d5-1dcedd623fea', N'Pin và Bộ Sạc', N'Các loại pin và bộ sạc máy ảnh đảm bảo máy luôn sẵn sàng hoạt động trong mọi tình huống.')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'cc889386-5ae5-4f4c-a7eb-5a47c4b84fc3', N'Máy Ảnh Kỹ Thuật Số', N'Danh mục các loại máy ảnh kỹ thuật số nhỏ gọn, dễ sử dụng, phù hợp cho mọi đối tượng.')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'109f3b3d-55ef-4003-8a54-80d7845e1b89', N'Ống Kính Máy Ảnh', N'Danh mục ống kính máy ảnh đa dạng từ ống kính góc rộng đến ống kính tele cho các dòng máy ảnh khác nhau.')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'd0a0cb4a-b1f3-4920-b8fd-a72697c59be2', N'Máy Ảnh', N'Danh mục bao gồm các loại máy ảnh kỹ thuật số, máy ảnh DSLR, máy ảnh không gương lật và các phụ kiện liên quan.')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'b99d84c9-8d23-4aa1-9850-ab15f0450f0f', N'Túi Máy Ảnh', N'Túi máy ảnh chất lượng cao, giúp bảo vệ máy ảnh và phụ kiện trong quá trình di chuyển.')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'26dd9ae2-03ec-4c60-9307-b6e046747259', N'Thẻ Nhớ', N'Danh mục thẻ nhớ tốc độ cao, dung lượng lớn để lưu trữ hình ảnh và video từ máy ảnh.')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'd6b1656b-e24c-4316-a601-bcd506e0085b', N'Máy Ảnh DSLR', N'Danh mục máy ảnh DSLR chuyên nghiệp, với chất lượng ảnh cao và khả năng thay đổi ống kính.')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'7e75d53f-bbfd-492b-9872-c1a5fa1ee9d2', N'Phụ Kiện Máy Ảnh Khác', N'Danh mục các phụ kiện máy ảnh khác như bộ lọc, kính lọc, dây đeo và bảo vệ màn hình.')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'85a67ac3-e2e3-4cbb-a8fa-cfbfaf335627', N'Đèn Flash Máy Ảnh', N'Danh mục đèn flash và phụ kiện ánh sáng dành cho máy ảnh, hỗ trợ chụp ảnh trong điều kiện thiếu sáng.')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'04675fa8-f1c5-4ab4-8b26-e1f0a398ffaa', N'Chân Máy Ảnh	', N'Danh mục các loại chân máy ảnh chuyên dụng, giúp cố định máy ảnh và chụp ảnh ổn định.	
')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'ebb2511f-9778-4ebb-bc0f-e7dc7aed83f6', N'Chân Máy Ảnh', N'Danh mục các loại chân máy ảnh chuyên dụng, giúp cố định máy ảnh và chụp ảnh ổn định.')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'7dbb3e52-ce81-4c10-b031-f268a95f5443', N'Máy Ảnh Không Gương Lật', N'Máy ảnh không gương lật với thiết kế nhỏ gọn, linh hoạt và chất lượng hình ảnh vượt trội.')
GO
INSERT [dbo].[Members] ([MemberID], [FirstName], [LastName], [Address], [PhoneNumber], [Email], [Job], [Hobby], [Gender], [Dob], [IsAdult], [Money], [AccountID], [JoinedAt], [IsActive], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [VerficationCodePhoneNumber], [VerficationCodeEmail], [Img]) VALUES (N'd957c529-6c72-4b0c-9ce7-43c76ebf84e5', N'Hoàng', N'Văn Hiếu', N'', N'0901234566', N'hoangvanhieu@gmail.com', NULL, NULL, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 0, N'4eec7749-ba5d-407d-a643-bc3c5a48e461', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, 1, 1, NULL, NULL, N'')
GO
INSERT [dbo].[Members] ([MemberID], [FirstName], [LastName], [Address], [PhoneNumber], [Email], [Job], [Hobby], [Gender], [Dob], [IsAdult], [Money], [AccountID], [JoinedAt], [IsActive], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [VerficationCodePhoneNumber], [VerficationCodeEmail], [Img]) VALUES (N'123f93a0-99f6-475e-985a-52d9473e225a', N'Phạm', N'Thanh Sơn', N'', N'0901234564', N'phamthanhson@gmail.com', NULL, NULL, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 0, N'd08801b4-9d36-4506-9231-e6253ddffb91', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, 1, 1, NULL, NULL, N'')
GO
INSERT [dbo].[Members] ([MemberID], [FirstName], [LastName], [Address], [PhoneNumber], [Email], [Job], [Hobby], [Gender], [Dob], [IsAdult], [Money], [AccountID], [JoinedAt], [IsActive], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [VerficationCodePhoneNumber], [VerficationCodeEmail], [Img]) VALUES (N'ad17339f-1330-4cec-9928-87701bdd695f', N'Bùi', N'Trung Hiếu', N'', N'0901234569', N'buitrunghieu@gmail.com', NULL, NULL, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 0, N'a03ade30-d417-4ba2-9bf4-a49ef20248d0', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, 1, 1, NULL, NULL, N'')
GO
INSERT [dbo].[Members] ([MemberID], [FirstName], [LastName], [Address], [PhoneNumber], [Email], [Job], [Hobby], [Gender], [Dob], [IsAdult], [Money], [AccountID], [JoinedAt], [IsActive], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [VerficationCodePhoneNumber], [VerficationCodeEmail], [Img]) VALUES (N'985af2c1-22f9-438f-b0ed-8a9a0d7b3998', N'Lê', N'Bích Ngọc', N'', N'0901234563', N'lebichngoc@gmail.com', NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 0, N'f3907f15-6a42-4f20-a6a1-53e53aa3458e', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, 1, 1, NULL, NULL, N'')
GO
INSERT [dbo].[Members] ([MemberID], [FirstName], [LastName], [Address], [PhoneNumber], [Email], [Job], [Hobby], [Gender], [Dob], [IsAdult], [Money], [AccountID], [JoinedAt], [IsActive], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [VerficationCodePhoneNumber], [VerficationCodeEmail], [Img]) VALUES (N'fb55cf8e-4759-481b-ace4-9b1a64db195c', N'Lê', N'Thị Kim Anh', N'', N'0901234568', N'lethikimanh@gmail.com', NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 0, N'3f720222-e872-40f7-b578-57413e13955e', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, 1, 1, NULL, NULL, N'')
GO
INSERT [dbo].[Members] ([MemberID], [FirstName], [LastName], [Address], [PhoneNumber], [Email], [Job], [Hobby], [Gender], [Dob], [IsAdult], [Money], [AccountID], [JoinedAt], [IsActive], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [VerficationCodePhoneNumber], [VerficationCodeEmail], [Img]) VALUES (N'42b852cd-b9c4-42bb-9140-b71e9bcb2a4a', N'Đinh', N'Hoài Linh', N'', N'0901234565', N'dinhhoailinh@gmail.com', NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 0, N'43cc4051-949e-4c52-bec6-bda4bba42b75', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, 1, 1, NULL, NULL, N'')
GO
INSERT [dbo].[Members] ([MemberID], [FirstName], [LastName], [Address], [PhoneNumber], [Email], [Job], [Hobby], [Gender], [Dob], [IsAdult], [Money], [AccountID], [JoinedAt], [IsActive], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [VerficationCodePhoneNumber], [VerficationCodeEmail], [Img]) VALUES (N'67457e79-af4d-48a7-a13c-b98329588a79', N'Nguyễn', N'Thị Thanh', N'', N'0901234570', N'nguyenthithanh@gmail.com', NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 0, N'ff8f2265-c820-41f0-b377-cc7ef0d03374', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, 1, 1, NULL, NULL, N'')
GO
INSERT [dbo].[Members] ([MemberID], [FirstName], [LastName], [Address], [PhoneNumber], [Email], [Job], [Hobby], [Gender], [Dob], [IsAdult], [Money], [AccountID], [JoinedAt], [IsActive], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [VerficationCodePhoneNumber], [VerficationCodeEmail], [Img]) VALUES (N'2e26fc47-2648-4529-afd5-c00359328d72', N'Đỗ', N'Đức Mạnh', N'', N'0901234567', N'doducmanh@gmail.com', NULL, NULL, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 0, N'4ca7c186-8c45-4d88-a3e0-865ce8e7e653', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, 1, 1, NULL, NULL, N'')
GO
INSERT [dbo].[Members] ([MemberID], [FirstName], [LastName], [Address], [PhoneNumber], [Email], [Job], [Hobby], [Gender], [Dob], [IsAdult], [Money], [AccountID], [JoinedAt], [IsActive], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [VerficationCodePhoneNumber], [VerficationCodeEmail], [Img]) VALUES (N'490a2813-9182-4aac-a50d-dd8ce9e62df1', N'Nguyễn', N'Văn Anh', N'', N'0901234567', N'nguyenvananh@gmail.com', NULL, NULL, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 0, N'be266567-7b48-41d1-ac22-ca0f48ded153', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, 1, 1, NULL, NULL, N'')
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [RentalPeriod]) VALUES (N'3c28f3c7-5acb-4de2-e7af-08dce90de538', N'7f836ab3-56f7-469c-f878-08dce90de4eb', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', 2000, N'New', 0, 2000, NULL)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [RentalPeriod]) VALUES (N'f193de05-be95-41f1-85a9-08dce94187ad', N'a0ad6399-c983-4094-a1f0-08dce941876b', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', 2000, N'string', 0, 2000, NULL)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [RentalPeriod]) VALUES (N'03afb8e2-aa30-4357-0289-08dce94ac1a6', N'edf63ada-00a7-479f-afd6-08dce94ac13b', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', 2000, N'string', 0, 2000, NULL)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [RentalPeriod]) VALUES (N'b6a64b28-c0fb-47a1-028a-08dce94ac1a6', N'130f0763-61d6-4be3-afd7-08dce94ac13b', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', 2000, N'string', 0, 2000, NULL)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [RentalPeriod]) VALUES (N'05c75fe0-17b1-4b63-83d4-08dce94b3ae6', N'4c375a77-2b98-4e5b-c310-08dce94b3a79', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', 2000, N'string', 0, 2000, NULL)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [RentalPeriod]) VALUES (N'd87f88dd-11e3-4411-6117-08dce94bd997', N'52207701-2efd-4331-c86c-08dce94bd922', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', 2000, N'string', 0, 2000, NULL)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [RentalPeriod]) VALUES (N'9d9c37be-e863-44a4-6118-08dce94bd997', N'472cdf20-ac0f-4354-c86d-08dce94bd922', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', 2000, N'string', 0, 2000, NULL)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [RentalPeriod]) VALUES (N'554aaba0-70ff-4046-6119-08dce94bd997', N'21066e68-1590-496f-c86e-08dce94bd922', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', 2000, N'string', 0, 2000, NULL)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [RentalPeriod]) VALUES (N'1d118256-648e-400d-54c5-08dce94c1ccd', N'd64d6671-b06c-46c8-623e-08dce94c1509', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', 2000, N'string', 0, 2000, NULL)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [RentalPeriod]) VALUES (N'09248954-d9b8-4fa2-54c6-08dce94c1ccd', N'f67920a8-1cf6-498c-623f-08dce94c1509', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', 2000, N'string', 0, 2000, NULL)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [RentalPeriod]) VALUES (N'bd4a55f0-9e05-4b5b-4cfc-08dce94d4b41', N'5fc27d05-77eb-4dc2-52a9-08dce94d35b7', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', 2000, N'string', 0, 2000, NULL)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [ProductPrice], [ProductQuality], [Discount], [ProductPriceTotal], [RentalPeriod]) VALUES (N'0560fb69-efac-4b1e-15f3-08dcebace969', N'17a661e4-629c-4be7-9854-08dcebace237', N'5a6a92d8-8c06-4e35-b616-af35d9743339', 1800, N'string', 0, 1800, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [MemberID], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'7f836ab3-56f7-469c-f878-08dce90de4eb', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'ad17339f-1330-4cec-9928-87701bdd695f', CAST(N'2024-10-10T09:28:26.3874812' AS DateTime2), 2, 2000, 0, NULL, NULL, 0, 0, NULL, N'Quận 9', 0, CAST(N'2024-10-10T09:23:53.0360000' AS DateTime2), CAST(N'2024-10-10T09:23:53.0360000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [MemberID], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'a0ad6399-c983-4094-a1f0-08dce941876b', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'42b852cd-b9c4-42bb-9140-b71e9bcb2a4a', CAST(N'2024-10-10T22:38:03.3612342' AS DateTime2), 0, 2000, 0, NULL, NULL, 0, 0, NULL, N'string', 0, CAST(N'2024-10-10T15:35:22.6960000' AS DateTime2), CAST(N'2024-10-10T15:35:22.6960000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [MemberID], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'edf63ada-00a7-479f-afd6-08dce94ac13b', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'490a2813-9182-4aac-a50d-dd8ce9e62df1', CAST(N'2024-10-10T23:44:05.8264412' AS DateTime2), 0, 2000, 0, NULL, NULL, 0, 0, NULL, N'string', 0, CAST(N'2024-10-10T16:42:52.2320000' AS DateTime2), CAST(N'2024-10-10T16:42:52.2320000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [MemberID], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'130f0763-61d6-4be3-afd7-08dce94ac13b', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'490a2813-9182-4aac-a50d-dd8ce9e62df1', CAST(N'2024-10-10T23:44:26.8943253' AS DateTime2), 0, 2000, 0, NULL, NULL, 0, 0, NULL, N'string', 0, CAST(N'2024-10-10T16:42:52.2320000' AS DateTime2), CAST(N'2024-10-10T16:42:52.2320000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [MemberID], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'4c375a77-2b98-4e5b-c310-08dce94b3a79', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'490a2813-9182-4aac-a50d-dd8ce9e62df1', CAST(N'2024-10-10T23:47:29.2332142' AS DateTime2), 0, 2000, 0, NULL, NULL, 0, 0, NULL, N'string', 0, CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [MemberID], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'52207701-2efd-4331-c86c-08dce94bd922', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'490a2813-9182-4aac-a50d-dd8ce9e62df1', CAST(N'2024-10-10T23:51:55.4224344' AS DateTime2), 0, 2000, 0, NULL, NULL, 0, 0, NULL, N'string', 0, CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [MemberID], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'472cdf20-ac0f-4354-c86d-08dce94bd922', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'490a2813-9182-4aac-a50d-dd8ce9e62df1', CAST(N'2024-10-10T23:52:58.7998116' AS DateTime2), 0, 2000, 0, NULL, NULL, 0, 0, NULL, N'string', 0, CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [MemberID], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'21066e68-1590-496f-c86e-08dce94bd922', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'490a2813-9182-4aac-a50d-dd8ce9e62df1', CAST(N'2024-10-10T23:53:15.1556259' AS DateTime2), 0, 2000, 0, NULL, NULL, 0, 0, NULL, N'string', 0, CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [MemberID], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'd64d6671-b06c-46c8-623e-08dce94c1509', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'490a2813-9182-4aac-a50d-dd8ce9e62df1', CAST(N'2024-10-10T23:53:48.5144397' AS DateTime2), 0, 2000, 0, NULL, NULL, 0, 0, NULL, N'string', 0, CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [MemberID], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'f67920a8-1cf6-498c-623f-08dce94c1509', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'490a2813-9182-4aac-a50d-dd8ce9e62df1', CAST(N'2024-10-10T23:54:01.6252431' AS DateTime2), 0, 2000, 0, NULL, NULL, 0, 0, NULL, N'string', 0, CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [MemberID], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'5fc27d05-77eb-4dc2-52a9-08dce94d35b7', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'490a2813-9182-4aac-a50d-dd8ce9e62df1', CAST(N'2024-10-11T00:01:40.2446345' AS DateTime2), 0, 2000, 0, NULL, NULL, 0, 0, NULL, N'string', 0, CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [MemberID], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'2d4c2d6e-cc54-46a6-96d0-08dce94d7bcd', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'490a2813-9182-4aac-a50d-dd8ce9e62df1', CAST(N'2024-10-11T00:03:37.8306547' AS DateTime2), 0, 2000, 0, NULL, NULL, 0, 0, NULL, N'string', 0, CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [MemberID], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'21a7b5fe-4ab1-4e6d-25d7-08dce94dc6c6', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'490a2813-9182-4aac-a50d-dd8ce9e62df1', CAST(N'2024-10-11T00:05:43.6122190' AS DateTime2), 0, 2000, 0, NULL, NULL, 0, 0, NULL, N'string', 0, CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), CAST(N'2024-10-10T16:46:31.2720000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [MemberID], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'c295166d-4d24-4c57-c741-08dcebab6f1c', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'ad17339f-1330-4cec-9928-87701bdd695f', CAST(N'2024-10-14T00:21:11.5533416' AS DateTime2), 0, 1800, 0, NULL, NULL, 0, 0, NULL, N'string', 0, CAST(N'2024-10-13T17:19:07.2520000' AS DateTime2), CAST(N'2024-10-13T17:19:07.2520000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [SupplierID], [MemberID], [OrderDate], [OrderStatus], [TotalAmount], [OrderType], [RentalStartDate], [RentalEndDate], [DurationUnit], [DurationValue], [ReturnDate], [ShippingAddress], [DeliveryMethod], [CreatedAt], [UpdatedAt], [OrderDetailID], [DeliveriesMethodID]) VALUES (N'17a661e4-629c-4be7-9854-08dcebace237', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'ad17339f-1330-4cec-9928-87701bdd695f', CAST(N'2024-10-14T00:31:19.5688912' AS DateTime2), 2, 1800, 0, NULL, NULL, 0, 0, NULL, N'string', 0, CAST(N'2024-10-13T17:19:07.2520000' AS DateTime2), CAST(N'2024-10-13T17:19:07.2520000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'a9eb2c1f-9492-403e-9224-18ea2e49ad03', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', N'https://binhminhdigital.com/storedata/images/product/may-anh-canon-eos-m50-kit-18150mm(1).jpg')
GO
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'0b4d511e-c4d3-459d-849b-c7870e0c103f', N'30acca93-09c3-41d4-9265-9669033830c4', N'https://firebasestorage.googleapis.com/v0/b/cameraserviceplatform.appspot.com/o/supplier%2F30acca93-09c3-41d4-9265-9669033830c4d8eb7357-8067-4cf5-a284-5e653e925bb5.jpg.png?alt=media&token=cf2f84c8-cbaf-4c91-aaea-b6b46f3fcd31')
GO
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'b26e5eaa-884f-4c51-9bde-ff01ef894614', N'9cfda11a-4d58-43ef-93dd-6d68f4a1fa62', N'https://bizweb.dktcdn.net/100/107/650/products/canon-0922c011-eos-m10-mirrorless-cam-1188037.jpg?v=1553084123443')
GO
INSERT [dbo].[ProductReports] ([ProductReportID], [SupplierID], [ProductID], [StatusType], [StartDate], [EndDate], [Reason], [AccountID], [Account], [CreatedAt], [UpdatedAt]) VALUES (N'3e463312-ae51-4332-b600-b5337ecef907', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', 1, CAST(N'2024-10-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-10T00:00:00.0000000' AS DateTime2), N'Damaged product reported', N'3f720222-e872-40f7-b578-57413e13955e', NULL, CAST(N'2024-10-10T01:21:36.8500000' AS DateTime2), CAST(N'2024-10-10T01:21:36.8500000' AS DateTime2))
GO
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'03aa116c-f7c0-4d87-adb2-20d6677aa61f', N'abc', N'13d341dc-7517-493b-635f-08dce86e9cd0', N'109f3b3d-55ef-4003-8a54-80d7845e1b89', N'string', N'string', 0, 0, 0, N'moi', 0, 0, CAST(N'2024-10-10T16:04:59.9467431' AS DateTime2), CAST(N'2024-10-10T16:04:59.9470682' AS DateTime2))
GO
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'10a8ea28-c732-4810-aa04-6b1ee23bff30', N'SN54321', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'd0a0cb4a-b1f3-4920-b8fd-a72697c59be2', N'Sony A7III', N'Versatile full-frame camera with 24.2 MP sensor.', 40, 2000, 1, N'New', 3, 4.7, CAST(N'2024-10-08T17:03:35.9566667' AS DateTime2), CAST(N'2024-10-08T17:03:35.9566667' AS DateTime2))
GO
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'9cfda11a-4d58-43ef-93dd-6d68f4a1fa62', N'SN12345', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'd0a0cb4a-b1f3-4920-b8fd-a72697c59be2', N'Canon EOS R5', N'High-end mirrorless camera with 45 MP sensor.', 50, 3500, 1, N'New', 1, 4.8, CAST(N'2024-10-08T17:03:35.9566667' AS DateTime2), CAST(N'2024-10-08T17:03:35.9566667' AS DateTime2))
GO
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'4ab83b0d-c7d1-49b9-912d-797eeb7f973e', N'1abc', N'f5b5f748-898e-4a91-ac47-08dce8900678', N'109f3b3d-55ef-4003-8a54-80d7845e1b89', N'string', N'string', 0, 0, 0, N'moi', 0, 0, CAST(N'2024-10-10T16:37:11.8318609' AS DateTime2), CAST(N'2024-10-10T16:37:11.8327975' AS DateTime2))
GO
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'30acca93-09c3-41d4-9265-9669033830c4', N'a32425564654', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'd0a0cb4a-b1f3-4920-b8fd-a72697c59be2', N'a', N'a', 1000, 2100, 1, N'moi', 1, 0, CAST(N'2024-10-13T18:55:36.9616405' AS DateTime2), CAST(N'2024-10-13T18:55:36.9616446' AS DateTime2))
GO
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'b2dc2870-1f94-41f6-880d-a4ed009217b2', N'abc', N'13d341dc-7517-493b-635f-08dce86e9cd0', N'd39481af-f68e-4a41-b5d5-1dcedd623fea', N'string', N'string', 0, 0, 0, N'moi', 0, 0, CAST(N'2024-10-10T14:44:54.9955124' AS DateTime2), CAST(N'2024-10-10T14:44:54.9963890' AS DateTime2))
GO
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'5a6a92d8-8c06-4e35-b616-af35d9743339', N'SN67890', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'd0a0cb4a-b1f3-4920-b8fd-a72697c59be2', N'Nikon Z6', N'Full-frame mirrorless camera with 24.5 MP sensor.', 45, 1800, 2, N'New', 3, 4.6, CAST(N'2024-10-08T17:03:35.9566667' AS DateTime2), CAST(N'2024-10-08T17:03:35.9566667' AS DateTime2))
GO
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [PriceRent], [PriceBuy], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'85ff4172-e2f2-4a92-8923-d19dd73b432c', N'string', N'13d341dc-7517-493b-635f-08dce86e9cd0', N'd39481af-f68e-4a41-b5d5-1dcedd623fea', N'string', N'string', 0, 0, 0, N'moi', 0, 0, CAST(N'2024-10-10T14:36:07.0368887' AS DateTime2), CAST(N'2024-10-10T14:36:07.0374968' AS DateTime2))
GO
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'312c5161-0761-40f2-8392-83df8fb5ae5b', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', N'Lens Type', N'50mm f/1.8 Prime Lens')
GO
INSERT [dbo].[ProductSpecifications] ([ProductSpecificationID], [ProductID], [Specification], [Details]) VALUES (N'1b78391c-2142-4e99-951e-852d605c683a', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', N'Camera Resolution', N'24 Megapixels')
GO
INSERT [dbo].[ProductVouchers] ([ProductVoucherID], [ProductID], [VourcherID], [CreatedAt], [UpdatedAt]) VALUES (N'9e1d6967-c88e-4498-9bd5-1320931a4bd0', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', N'15ca5779-a342-48a8-8f60-4b5666197ae0', CAST(N'2024-10-10T01:46:24.7600000' AS DateTime2), CAST(N'2024-10-10T01:46:24.7600000' AS DateTime2))
GO
INSERT [dbo].[ProductVouchers] ([ProductVoucherID], [ProductID], [VourcherID], [CreatedAt], [UpdatedAt]) VALUES (N'3a6cbb4e-902b-43f4-be53-3db4e7d65389', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', N'15ca5779-a342-48a8-8f60-4b5666197ae0', CAST(N'2024-10-10T01:46:24.7633333' AS DateTime2), CAST(N'2024-10-10T01:46:24.7633333' AS DateTime2))
GO
INSERT [dbo].[Ratings] ([RatingID], [ProductID], [AccountID], [RatingValue], [CreatedAt], [ReviewComment]) VALUES (N'8771a7d1-d0e5-44a7-a44f-f6a07a728074', N'10a8ea28-c732-4810-aa04-6b1ee23bff30', N'a03ade30-d417-4ba2-9bf4-a49ef20248d0', 4, CAST(N'2024-10-10T10:02:51.4703523' AS DateTime2), N'Good')
GO
INSERT [dbo].[Reports] ([ReportID], [AccountId], [ReportType], [ReportDetails], [ReportDate], [Status]) VALUES (N'4186bfdb-4943-48e1-93b2-02e1f4a32bce', N'3d2ca765-ab6d-4772-8a7c-32aa8c7ed4d0', 2, N'Request for additional camera accessories', CAST(N'2024-10-09T00:00:00.0000000' AS DateTime2), 2)
GO
INSERT [dbo].[Reports] ([ReportID], [AccountId], [ReportType], [ReportDetails], [ReportDate], [Status]) VALUES (N'68a0a8a3-557d-47c0-bce9-08dce90eee79', N'a03ade30-d417-4ba2-9bf4-a49ef20248d0', 0, N'string', CAST(N'2024-10-10T09:35:51.9501964' AS DateTime2), 0)
GO
INSERT [dbo].[Reports] ([ReportID], [AccountId], [ReportType], [ReportDetails], [ReportDate], [Status]) VALUES (N'5d7a928a-398c-440f-b6d1-24fc3dcd8bc0', N'3d2ca765-ab6d-4772-8a7c-32aa8c7ed4d0', 1, N'The camera lens is damaged', CAST(N'2024-10-09T00:00:00.0000000' AS DateTime2), 1)
GO
INSERT [dbo].[Reports] ([ReportID], [AccountId], [ReportType], [ReportDetails], [ReportDate], [Status]) VALUES (N'807ecda8-b8ae-42b4-96ad-d2d482c37cf6', N'3d2ca765-ab6d-4772-8a7c-32aa8c7ed4d0', 1, N'Battery life is very short', CAST(N'2024-10-09T00:00:00.0000000' AS DateTime2), 2)
GO
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [AccountBalance], [VourcherID], [Img]) VALUES (N'13d341dc-7517-493b-635f-08dce86e9cd0', N'aaa9fe0a-98eb-41f5-819d-e4e6a0263c4c', N'string', N'string', N'string', N'string', NULL, NULL, NULL, CAST(N'2024-10-09T14:28:15.4579424' AS DateTime2), CAST(N'2024-10-09T14:28:15.4579425' AS DateTime2), 0, NULL, NULL)
GO
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [AccountBalance], [VourcherID], [Img]) VALUES (N'f5b5f748-898e-4a91-ac47-08dce8900678', N'0bab8444-ad59-4fe8-b1a4-559bc34275b0', N'sa', N'sa', N'á', N'147895463', NULL, NULL, NULL, CAST(N'2024-10-09T18:27:26.1101479' AS DateTime2), CAST(N'2024-10-09T18:27:26.1102092' AS DateTime2), 0, NULL, NULL)
GO
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [AccountBalance], [VourcherID], [Img]) VALUES (N'85898953-c65c-400a-f83d-08dce91322fa', N'633d54c5-44cd-4c96-b04f-c8499bf72f2a', N'Nikon', N'Nikon mays anh', N'Hồ Chí Minh', N'0944557788', NULL, NULL, NULL, CAST(N'2024-10-10T10:05:58.0191759' AS DateTime2), CAST(N'2024-10-10T10:05:58.0192174' AS DateTime2), 0, NULL, NULL)
GO
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [AccountBalance], [VourcherID], [Img]) VALUES (N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'43cc4051-949e-4c52-bec6-bda4bba42b75', N'Nikon Pro Distributors', N'Authorized Nikon distributor', N'5678 Lens Avenue, Hanoi', N'0908000002', N'/images/nikon-logo.png', NULL, NULL, CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), 15000, NULL, N'')
GO
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [AccountBalance], [VourcherID], [Img]) VALUES (N'47babe88-fdd0-41a4-8788-2309419cf5f3', N'4ca7c186-8c45-4d88-a3e0-865ce8e7e653', N'Canon Official Store', N'Official supplier of Canon products', N'1234 Camera Street, Ho Chi Minh City', N'0908000001', N'/images/canon-logo.png', NULL, NULL, CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), 10000, NULL, N'')
GO
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [AccountBalance], [VourcherID], [Img]) VALUES (N'e2018a09-032d-4931-ace7-8211a4c54eac', N'a03ade30-d417-4ba2-9bf4-a49ef20248d0', N'Olympus Professional Supplies', N'Distributor of Olympus products', N'2468 Focus Road, Da Lat', N'0908000005', N'/images/olympus-logo.png', NULL, NULL, CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), 5000, NULL, N'')
GO
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [AccountBalance], [VourcherID], [Img]) VALUES (N'd22b3835-25f6-402c-869b-b29dd20c6e7a', N'be266567-7b48-41d1-ac22-ca0f48ded153', N'Fujifilm Supplies', N'Authorized Fujifilm store', N'1357 Lens Boulevard, Hue', N'0908000004', N'/images/fujifilm-logo.png', NULL, NULL, CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), 8000, NULL, N'')
GO
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'd88dc878-675c-49b3-946e-0a126921ace7', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'NIKON50OFF', N'Giảm 50% cho tất cả sản phẩm Nikon', 50, CAST(N'2024-10-05T18:05:06.7420000' AS DateTime2), CAST(N'2024-11-05T18:05:06.7420000' AS DateTime2), 1, CAST(N'2024-10-05T18:15:55.4269395' AS DateTime2), CAST(N'2024-10-05T18:15:55.4269398' AS DateTime2))
GO
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'15ca5779-a342-48a8-8f60-4b5666197ae0', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'NIKON2024', N'Discount for Nikon Pro Distributors', 15000, CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2), CAST(N'2025-10-06T00:00:00.0000000' AS DateTime2), 1, CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'11d52913-71dd-4164-8294-7b97b2bb196e', N'31f0617f-4e0c-4630-bfee-66940e2b2fc9', N'SONY2024', N'Discount for Sony Gear Distributors', 20000, CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2), CAST(N'2025-10-06T00:00:00.0000000' AS DateTime2), 1, CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'96bfcde9-4f71-400f-81c8-96a702f8309d', N'e2018a09-032d-4931-ace7-8211a4c54eac', N'OLYMPUS2024', N'Discount for Olympus Professional Supplies', 5000, CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2), CAST(N'2025-10-06T00:00:00.0000000' AS DateTime2), 1, CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'4d451c76-21c9-4b14-853c-d4408183b4c4', N'47babe88-fdd0-41a4-8788-2309419cf5f3', N'CANON2024', N'Discount for Canon Official Store', 10000, CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2), CAST(N'2025-10-06T00:00:00.0000000' AS DateTime2), 1, CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BankInformation_MemberId]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_BankInformation_MemberId] ON [dbo].[BankInformation]
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contracts_OrderID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Contracts_OrderID] ON [dbo].[Contracts]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Members_AccountID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Members_AccountID] ON [dbo].[Members]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_OrderID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_OrderDetails_OrderID] ON [dbo].[OrderDetails]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_ProductID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductID] ON [dbo].[OrderDetails]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderHistory_MemberID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_OrderHistory_MemberID] ON [dbo].[OrderHistory]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderHistory_OrderID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderHistory_OrderID] ON [dbo].[OrderHistory]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_DeliveriesMethodID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_DeliveriesMethodID] ON [dbo].[Orders]
(
	[DeliveriesMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_MemberID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_MemberID] ON [dbo].[Orders]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_SupplierID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_SupplierID] ON [dbo].[Orders]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductImages_ProductID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductImages_ProductID] ON [dbo].[ProductImages]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ProductReports_Account]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductReports_Account] ON [dbo].[ProductReports]
(
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductReports_ProductID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductReports_ProductID] ON [dbo].[ProductReports]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductReports_SupplierID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductReports_SupplierID] ON [dbo].[ProductReports]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryID] ON [dbo].[Products]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_SupplierID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_SupplierID] ON [dbo].[Products]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductSpecifications_ProductID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductSpecifications_ProductID] ON [dbo].[ProductSpecifications]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductVouchers_ProductID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductVouchers_ProductID] ON [dbo].[ProductVouchers]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductVouchers_VourcherID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductVouchers_VourcherID] ON [dbo].[ProductVouchers]
(
	[VourcherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Ratings_AccountID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Ratings_AccountID] ON [dbo].[Ratings]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Ratings_ProductID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Ratings_ProductID] ON [dbo].[Ratings]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Reports_AccountId]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reports_AccountId] ON [dbo].[Reports]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ReturnDetails_OrderID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_ReturnDetails_OrderID] ON [dbo].[ReturnDetails]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Staffs_AccountID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Staffs_AccountID] ON [dbo].[Staffs]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SupplierReports_HandledByAccountId]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierReports_HandledByAccountId] ON [dbo].[SupplierReports]
(
	[HandledByAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierReports_SupplierID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierReports_SupplierID] ON [dbo].[SupplierReports]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierRequests_SupplierID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierRequests_SupplierID] ON [dbo].[SupplierRequests]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Suppliers_AccountID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Suppliers_AccountID] ON [dbo].[Suppliers]
(
	[AccountID] ASC
)
WHERE ([AccountID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Suppliers_VourcherID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Suppliers_VourcherID] ON [dbo].[Suppliers]
(
	[VourcherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_BankInformationBankId]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transactions_BankInformationBankId] ON [dbo].[Transactions]
(
	[BankInformationBankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_MemberId]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transactions_MemberId] ON [dbo].[Transactions]
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_OrderID]    Script Date: 14/10/2024 5:50:45 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Transactions_OrderID] ON [dbo].[Transactions]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Members] ADD  DEFAULT (N'') FOR [Img]
GO
ALTER TABLE [dbo].[Staffs] ADD  DEFAULT (N'') FOR [Img]
GO
ALTER TABLE [dbo].[Staffs] ADD  DEFAULT (N'') FOR [Name]
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
ALTER TABLE [dbo].[BankInformation]  WITH CHECK ADD  CONSTRAINT [FK_BankInformation_Members_MemberId] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BankInformation] CHECK CONSTRAINT [FK_BankInformation_Members_MemberId]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_Contracts_Orders_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_Contracts_Orders_OrderID]
GO
ALTER TABLE [dbo].[Members]  WITH CHECK ADD  CONSTRAINT [FK_Members_AspNetUsers_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Members] CHECK CONSTRAINT [FK_Members_AspNetUsers_AccountID]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderID]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products_ProductID]
GO
ALTER TABLE [dbo].[OrderHistory]  WITH CHECK ADD  CONSTRAINT [FK_OrderHistory_Members_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Members] ([MemberID])
GO
ALTER TABLE [dbo].[OrderHistory] CHECK CONSTRAINT [FK_OrderHistory_Members_MemberID]
GO
ALTER TABLE [dbo].[OrderHistory]  WITH CHECK ADD  CONSTRAINT [FK_OrderHistory_Orders_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderHistory] CHECK CONSTRAINT [FK_OrderHistory_Orders_OrderID]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_DeliveriesMethod_DeliveriesMethodID] FOREIGN KEY([DeliveriesMethodID])
REFERENCES [dbo].[DeliveriesMethod] ([DeliveriesMethodID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_DeliveriesMethod_DeliveriesMethodID]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Members_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Members] ([MemberID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Members_MemberID]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Suppliers_SupplierID] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Suppliers_SupplierID]
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
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_AspNetUsers_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_AspNetUsers_AccountId]
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
ALTER TABLE [dbo].[SupplierReports]  WITH CHECK ADD  CONSTRAINT [FK_SupplierReports_AspNetUsers_HandledByAccountId] FOREIGN KEY([HandledByAccountId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SupplierReports] CHECK CONSTRAINT [FK_SupplierReports_AspNetUsers_HandledByAccountId]
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
ALTER TABLE [dbo].[Suppliers]  WITH CHECK ADD  CONSTRAINT [FK_Suppliers_Vourchers_VourcherID] FOREIGN KEY([VourcherID])
REFERENCES [dbo].[Vourchers] ([VourcherID])
GO
ALTER TABLE [dbo].[Suppliers] CHECK CONSTRAINT [FK_Suppliers_Vourchers_VourcherID]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_BankInformation_BankInformationBankId] FOREIGN KEY([BankInformationBankId])
REFERENCES [dbo].[BankInformation] ([BankId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_BankInformation_BankInformationBankId]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Members_MemberId] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Members_MemberId]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Orders_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Orders_OrderID]
GO
USE [master]
GO
ALTER DATABASE [CameraCapstone] SET  READ_WRITE 
GO
