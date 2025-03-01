 
ALTER DATABASE [CameraCapstone] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CameraCapstone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CameraCapston  e] SET ANSI_NULL_DEFAULT OFF 
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10/6/2024 1:36:23 AM ******/
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
	[Gender] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsVerified] [bit] NOT NULL,
	[VerifyCode] [nvarchar](max) NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[RefreshTokenExpiryTime] [datetime2](7) NULL,
	[Address] [nvarchar](max) NULL,
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
	[Hobby] [int] NULL,
	[Job] [int] NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[BankInformation]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[Categories]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[Contracts]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[DeliveriesMethod]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[Members]    Script Date: 10/6/2024 1:36:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[MemberID] [uniqueidentifier] NOT NULL,
	[AccountID] [nvarchar](450) NULL,
	[JoinedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Dob] [datetime2](7) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[Gender] [int] NOT NULL,
	[IsAdult] [bit] NOT NULL,
	[IsVerfiedPhoneNumber] [bit] NULL,
	[IsVerifiedEmail] [bit] NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Money] [float] NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[VerficationCodeEmail] [nvarchar](max) NULL,
	[VerficationCodePhoneNumber] [nvarchar](max) NULL,
	[Hobby] [int] NULL,
	[Job] [int] NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[OrderHistory]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[Orders]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[Policies]    Script Date: 10/6/2024 1:36:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Policies](
	[PolicyID] [uniqueidentifier] NOT NULL,
	[PolicyType] [int] NOT NULL,
	[PolicyContent] [nvarchar](max) NOT NULL,
	[EffectiveDate] [datetime2](7) NOT NULL,
	[Value] [datetime2](7) NOT NULL,
	[ApplicableObject] [int] NOT NULL,
 CONSTRAINT [PK_Policies] PRIMARY KEY CLUSTERED 
(
	[PolicyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[ProductReports]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 10/6/2024 1:36:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [uniqueidentifier] NOT NULL,
	[SerialNumber] [nvarchar](255) NOT NULL,
	[SupplierID] [uniqueidentifier] NULL,
	[CategoryID] [uniqueidentifier] NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[ProductDescription] [nvarchar](max) NULL,
	[Price] [float] NOT NULL,
	[Brand] [nvarchar](max) NULL,
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
/****** Object:  Table [dbo].[ProductSpecifications]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[Ratings]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[Reports]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[ReturnDetails]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[Staffs]    Script Date: 10/6/2024 1:36:23 AM ******/
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
 CONSTRAINT [PK_Staffs] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierReports]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[SupplierRequests]    Script Date: 10/6/2024 1:36:23 AM ******/
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
/****** Object:  Table [dbo].[Suppliers]    Script Date: 10/6/2024 1:36:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierID] [uniqueidentifier] NOT NULL,
	[AccountID] [nvarchar](450) NOT NULL,
	[SupplierName] [nvarchar](max) NOT NULL,
	[SupplierDescription] [nvarchar](max) NOT NULL,
	[SupplierAddress] [nvarchar](max) NOT NULL,
	[ContactNumber] [nvarchar](20) NULL,
	[SupplierLogo] [nvarchar](max) NOT NULL,
	[BlockReason] [nvarchar](max) NULL,
	[BlockedAt] [datetime2](7) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[AccountBalance] [float] NOT NULL,
	[VourcherID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 10/6/2024 1:36:23 AM ******/
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
	[MemberId] [uniqueidentifier] NOT NULL,
	[BankInformationBankId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vourchers]    Script Date: 10/6/2024 1:36:23 AM ******/
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
	[DiscountType] [int] NOT NULL,
	[MaxUsageLimit] [int] NULL,
	[UsagePerCustomer] [int] NULL,
	[MinOrderAmount] [float] NULL,
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
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'086b7a13-79af-4610-851d-204d9d84b865', N'STAFF', N'Staff', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1cf2de31-b0d8-4447-8f2f-c41df905a3a5', N'ADMIN', N'ADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'74bd6d3a-1119-449b-9743-3956d74e7575', N'Supplier', N'Supplier', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9', N'MEMBER', N'Member', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3f720222-e872-40f7-b578-57413e13955e', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'43cc4051-949e-4c52-bec6-bda4bba42b75', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4ca7c186-8c45-4d88-a3e0-865ce8e7e653', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4eec7749-ba5d-407d-a643-bc3c5a48e461', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'882404ca-6de4-471c-a0f6-a5bace3b0d7f', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a03ade30-d417-4ba2-9bf4-a49ef20248d0', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'be266567-7b48-41d1-ac22-ca0f48ded153', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd07dafc5-c402-4d45-a47f-3917d0fb0416', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd08801b4-9d36-4506-9231-e6253ddffb91', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'de86651b-954f-421d-98e7-d49a031e1eb0', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f3907f15-6a42-4f20-a6a1-53e53aa3458e', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ff8f2265-c820-41f0-b377-cc7ef0d03374', N'e64b36a7-ed67-47d2-b92e-d2f6caa3eda9')
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Gender], [IsDeleted], [IsVerified], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Hobby], [Job]) VALUES (N'3f720222-e872-40f7-b578-57413e13955e', 1, N'0901234568', N'Lê', N'Thị Kim Anh', 0, 0, 1, N'', N'Gy+/oYe+Dp+xVz50KPOvKSgimOdYQHCQbods+SoBJZfC1nLJTOhHKcSlMepyR2W1A1ppyqzq19QFuiuBETFqcQ==', CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2), NULL, N'lethikimanh@gmail.com', N'LETHIKIMANH@GMAIL.COM', N'lethikimanh@gmail.com', N'LETHIKIMANH@GMAIL.COM', N'AQAAAAIAAYagAAAAEOazn8gTMpIRPWhA2kEs4NyQulNYOCxoCiNsA67hdbPT+cvxzSlNDkP+QbcxwPWilw==', N'3JLXRDO7NNDZJ6ZZIXHSLEMFQAZL453J', N'0b19e780-ee14-408c-bc92-80bd77054474', 0, 0, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Gender], [IsDeleted], [IsVerified], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Hobby], [Job]) VALUES (N'43cc4051-949e-4c52-bec6-bda4bba42b75', 1, N'0901234565', N'Đinh', N'Hoài Linh', 0, 0, 1, N'218a85', N'vMYRia/tW8r4tkNlOVCCNp616G4SUc7oA7tiNkW83HcLxqo/s5NJ3ubEKblP9SHVcseqnma/fnTX1O1S8gmrPQ==', CAST(N'2024-10-04T00:00:00.0000000' AS DateTime2), NULL, N'dinhhoailinh@gmail.com', N'DINHHOAILINH@GMAIL.COM', N'dinhhoailinh@gmail.com', N'DINHHOAILINH@GMAIL.COM', N'AQAAAAIAAYagAAAAEBM94Wv9+CHuWBytY9TOELYkRAaWnow+ISHBLl2Ngj5bDNLwOLHQdKCiNKBwm8feqw==', N'2FNARJ34AANKJ2PF5NMJ4YTDOUURDEA6', N'5247fd73-93fe-413a-a324-cff20c00cd48', 0, 0, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Gender], [IsDeleted], [IsVerified], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Hobby], [Job]) VALUES (N'4ca7c186-8c45-4d88-a3e0-865ce8e7e653', 1, N'0901234567', N'Đỗ', N'Đức Mạnh', 1, 0, 1, N'218a84', NULL, NULL, NULL, N'doducmanh@gmail.com', N'DODUCMANH@GMAIL.COM', N'doducmanh@gmail.com', N'DODUCMANH@GMAIL.COM', N'AQAAAAIAAYagAAAAED8w17uBI4t6ASih7M37jQ1pUU2N++aN28Dvm433R1SaQsD7pEfyzsVqJlmRbVBnFA==', N'6NUEURM6BFXMVDSBDL7IDJNUMTPYFQ2O', N'321f6541-1b8a-4e3b-baf8-30f4545dd901', 0, 0, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Gender], [IsDeleted], [IsVerified], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Hobby], [Job]) VALUES (N'4eec7749-ba5d-407d-a643-bc3c5a48e461', 1, N'0901234566', N'Hoàng', N'Văn Hiếu', 1, 0, 1, N'218a83', N'11Pl5EL2UlTalMWd73uMkgg01ERALlkMYwxZ3QGb0c5LfeZTTh0pH0pKw89TKsokRGH12VxZcomomQezAbNiJg==', CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2), NULL, N'hoangvanhieu@gmail.com', N'HOANGVANHIEU@GMAIL.COM', N'hoangvanhieu@gmail.com', N'HOANGVANHIEU@GMAIL.COM', N'AQAAAAIAAYagAAAAELubfSKBK1wjikeyJ62QpTKJAndFFs/h15QNUhPrRTJBjWEi668CorzrEStpf3ky/Q==', N'2JMBZ57WPVE47EI7X3PL7BPXBT6NPIGM', N'7b05ec22-f323-420f-998f-a2dc696bd55b', 0, 0, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Gender], [IsDeleted], [IsVerified], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Hobby], [Job]) VALUES (N'882404ca-6de4-471c-a0f6-a5bace3b0d7f', 1, N'0901234562', N'Trần', N'Quốc Anh', 1, 0, 1, N'2868a8', NULL, NULL, NULL, N'tranquocanh@gmail.com', N'TRANQUOCANH@GMAIL.COM', N'tranquocanh@gmail.com', N'TRANQUOCANH@GMAIL.COM', N'AQAAAAIAAYagAAAAECg56xMMTyRwKPBJG3SioyxvfCr6YW+FM0TNvQPejVkhX3pQta+ZTPl3a6WKnH/aoQ==', N'UW57ACBINX3QF2VJGXFULSBSLQWBUEIQ', N'bfa4a4ae-8a54-4b7a-bd90-abead4ff1286', 0, 0, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Gender], [IsDeleted], [IsVerified], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Hobby], [Job]) VALUES (N'a03ade30-d417-4ba2-9bf4-a49ef20248d0', 1, N'0817363768', N'string', N'string', 1, 0, 1, N'218a81', NULL, NULL, NULL, N'buitrunghieu@gmail.com', N'BUITRUNGHIEU@GMAIL.COM', N'buitrunghieu@gmail.com', N'BUITRUNGHIEU@GMAIL.COM', N'AQAAAAIAAYagAAAAEKn+dtDSeeAQ13Gd+dM6gB5Un37P3cwD130pGu8UMMNVGzJcumvyOH3UEYJ5mQs4LA==', N'E5NIFUSWSD5AHDCNC2DOEPAQ53IGUOCG', N'94350ed7-e287-4364-8d94-9d6e0d971d3e', 0, 0, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Gender], [IsDeleted], [IsVerified], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Hobby], [Job]) VALUES (N'be266567-7b48-41d1-ac22-ca0f48ded153', 1, N'0901234567', N'Nguyễn', N'Văn Anh', 1, 0, 1, N'fa5093', NULL, NULL, NULL, N'nguyenvananh@gmail.com', N'NGUYENVANANH@GMAIL.COM', N'nguyenvananh@gmail.com', N'NGUYENVANANH@GMAIL.COM', N'AQAAAAIAAYagAAAAEIVZu1Y6O2ExBESfoQC5zTErJHLnf33VGuzW/SpwFcU7EONMiObqN0GKBUoQTP3vbQ==', N'TQGNUHKZR6JJ7JJQCRNLJWBUO2S6RMUT', N'39667ef9-e0b4-4ecf-909d-205ffbd747b7', 0, 0, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Gender], [IsDeleted], [IsVerified], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Hobby], [Job]) VALUES (N'd07dafc5-c402-4d45-a47f-3917d0fb0416', 1, N'0901234561', N'Nguyễn', N'Minh Thư', 0, 0, 1, N'f2ddbf', NULL, NULL, NULL, N'nguyenminhthu@gmail.com', N'NGUYENMINHTHU@GMAIL.COM', N'nguyenminhthu@gmail.com', N'NGUYENMINHTHU@GMAIL.COM', N'AQAAAAIAAYagAAAAEG9L4Bsv4PMmU7DVgZvTWWWnupFitYvcZ0VdIMaGH7SH0m/vWbzwOYdTMl4y5NfFAQ==', N'OINXHQ34J4HMRQZGBTIJMSMEVG5YF2QC', N'f68f27b9-847c-4b53-9d7c-46f7de711759', 0, 0, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Gender], [IsDeleted], [IsVerified], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Hobby], [Job]) VALUES (N'd08801b4-9d36-4506-9231-e6253ddffb91', 1, N'0901234564', N'Phạm', N'Thanh Sơn', 1, 0, 1, N'9a9ea3', NULL, NULL, NULL, N'phamthanhson@gmail.com', N'PHAMTHANHSON@GMAIL.COM', N'phamthanhson@gmail.com', N'PHAMTHANHSON@GMAIL.COM', N'AQAAAAIAAYagAAAAECp2OVPqrMKdMa9Qp+4ICKe3WMR9tTt5fNrfSUJxfLWoAwaLS0kf8AP8iSHYF1BJLg==', N'YYOXRLL7AFUUWT7RCJAHDFYUPV5GD4FB', N'48829aa1-3c2f-46e4-9460-c49caa3968d9', 0, 0, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Gender], [IsDeleted], [IsVerified], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Hobby], [Job]) VALUES (N'de86651b-954f-421d-98e7-d49a031e1eb0', 0, N'', N'Duong Binh An (K16_HCM)', N'', 1, 0, 1, N'', N'Uomym4yZSaBFaPULfqNvh+xnidyYbVXE5PelbIwwbMI4Jg3KauWntxkJWVujdsJueOsOIcZ/4kGgVKojyA4G2A==', CAST(N'2024-10-06T00:00:00.0000000' AS DateTime2), NULL, N'andbse161205@fpt.edu.vn', N'ANDBSE161205@FPT.EDU.VN', N'andbse161205@fpt.edu.vn', N'ANDBSE161205@FPT.EDU.VN', N'AQAAAAIAAYagAAAAEGDnRM5TauXmgPbhF9HAcARuAMGsvwsxr7kuZNJU4uhpcT3OodPfbkHe8IcQzS6qEg==', N'DSX2UCYBOLUY6LCT4VERS64BPOFXQNMJ', N'66db8f7e-9330-431e-8879-094728b1dd03', 0, 0, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Gender], [IsDeleted], [IsVerified], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Hobby], [Job]) VALUES (N'f3907f15-6a42-4f20-a6a1-53e53aa3458e', 1, N'0901234563', N'Lê', N'Bích Ngọc', 0, 0, 0, N'6e7500', NULL, NULL, NULL, N'lebichngoc@gmail.com', N'LEBICHNGOC@GMAIL.COM', N'lebichngoc@gmail.com', N'LEBICHNGOC@GMAIL.COM', N'AQAAAAIAAYagAAAAEH+aT06V7w1BQdJ7rgl4f+7P4MgZjlshMNtrR4BiD6x0bgbK6czlC8ghCrudcfYFQg==', N'I526I4VKTVHII54M5CCAAAFUWKJADZOL', N'9a0f597e-2647-4e1e-a94f-39811869ea87', 0, 0, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [EmailConfirmed], [PhoneNumber], [FirstName], [LastName], [Gender], [IsDeleted], [IsVerified], [VerifyCode], [RefreshToken], [RefreshTokenExpiryTime], [Address], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Hobby], [Job]) VALUES (N'ff8f2265-c820-41f0-b377-cc7ef0d03374', 0, N'0901234570', N'Nguyễn', N'Thị Thanh', 0, 0, 1, N'218a82', NULL, NULL, NULL, N'nguyenthithanh@gmail.com', N'NGUYENTHITHANH@GMAIL.COM', N'nguyenthithanh@gmail.com', N'NGUYENTHITHANH@GMAIL.COM', N'AQAAAAIAAYagAAAAELHngf3hRRYyVP6+seHRl5HDT89bEEsKMB87LNnnDdA27t5vGmDIeXQ4WoF/KgKbnw==', N'P3YQ5IZGXXBN4POE56IRS6AUNAI2KMNX', N'ab4c22e7-8b93-49ce-84e2-fe1d6ce4ac5a', 0, 0, NULL, 1, 0, NULL, NULL)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'd39481af-f68e-4a41-b5d5-1dcedd623fea', N'Pin và Bộ Sạc', N'Các loại pin và bộ sạc máy ảnh đảm bảo máy luôn sẵn sàng hoạt động trong mọi tình huống.')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'cc889386-5ae5-4f4c-a7eb-5a47c4b84fc3', N'Máy Ảnh Kỹ Thuật Số', N'Danh mục các loại máy ảnh kỹ thuật số nhỏ gọn, dễ sử dụng, phù hợp cho mọi đối tượng.')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'109f3b3d-55ef-4003-8a54-80d7845e1b89', N'Ống Kính Máy Ảnh', N'Danh mục ống kính máy ảnh đa dạng từ ống kính góc rộng đến ống kính tele cho các dòng máy ảnh khác nhau.')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'd0a0cb4a-b1f3-4920-b8fd-a72697c59be2', N'Máy Ảnh', N'Danh mục bao gồm các loại máy ảnh kỹ thuật số, máy ảnh DSLR, máy ảnh không gương lật và các phụ kiện liên quan.')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'b99d84c9-8d23-4aa1-9850-ab15f0450f0f', N'Túi Máy Ảnh', N'Túi máy ảnh chất lượng cao, giúp bảo vệ máy ảnh và phụ kiện trong quá trình di chuyển.')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'26dd9ae2-03ec-4c60-9307-b6e046747259', N'Thẻ Nhớ', N'Danh mục thẻ nhớ tốc độ cao, dung lượng lớn để lưu trữ hình ảnh và video từ máy ảnh.')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'd6b1656b-e24c-4316-a601-bcd506e0085b', N'Máy Ảnh DSLR', N'Danh mục máy ảnh DSLR chuyên nghiệp, với chất lượng ảnh cao và khả năng thay đổi ống kính.')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'7e75d53f-bbfd-492b-9872-c1a5fa1ee9d2', N'Phụ Kiện Máy Ảnh Khác', N'Danh mục các phụ kiện máy ảnh khác như bộ lọc, kính lọc, dây đeo và bảo vệ màn hình.')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'85a67ac3-e2e3-4cbb-a8fa-cfbfaf335627', N'Đèn Flash Máy Ảnh', N'Danh mục đèn flash và phụ kiện ánh sáng dành cho máy ảnh, hỗ trợ chụp ảnh trong điều kiện thiếu sáng.')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'ebb2511f-9778-4ebb-bc0f-e7dc7aed83f6', N'Chân Máy Ảnh', N'Danh mục các loại chân máy ảnh chuyên dụng, giúp cố định máy ảnh và chụp ảnh ổn định.')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription]) VALUES (N'7dbb3e52-ce81-4c10-b031-f268a95f5443', N'Máy Ảnh Không Gương Lật', N'Máy ảnh không gương lật với thiết kế nhỏ gọn, linh hoạt và chất lượng hình ảnh vượt trội.')
GO
INSERT [dbo].[Members] ([MemberID], [AccountID], [JoinedAt], [IsActive], [Address], [Dob], [Email], [FirstName], [Gender], [IsAdult], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [LastName], [Money], [PhoneNumber], [VerficationCodeEmail], [VerficationCodePhoneNumber], [Hobby], [Job]) VALUES (N'3bdab013-a942-4b5f-a526-228b4c84bfbf', N'd07dafc5-c402-4d45-a47f-3917d0fb0416', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'nguyenminhthu@gmail.com', N'Nguyễn', 0, 1, 1, 1, N'Minh Thư', 0, N'0901234561', NULL, NULL, NULL, NULL)
INSERT [dbo].[Members] ([MemberID], [AccountID], [JoinedAt], [IsActive], [Address], [Dob], [Email], [FirstName], [Gender], [IsAdult], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [LastName], [Money], [PhoneNumber], [VerficationCodeEmail], [VerficationCodePhoneNumber], [Hobby], [Job]) VALUES (N'd957c529-6c72-4b0c-9ce7-43c76ebf84e5', N'4eec7749-ba5d-407d-a643-bc3c5a48e461', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'hoangvanhieu@gmail.com', N'Hoàng', 1, 1, 1, 1, N'Văn Hiếu', 0, N'0901234566', NULL, NULL, NULL, NULL)
INSERT [dbo].[Members] ([MemberID], [AccountID], [JoinedAt], [IsActive], [Address], [Dob], [Email], [FirstName], [Gender], [IsAdult], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [LastName], [Money], [PhoneNumber], [VerficationCodeEmail], [VerficationCodePhoneNumber], [Hobby], [Job]) VALUES (N'123f93a0-99f6-475e-985a-52d9473e225a', N'd08801b4-9d36-4506-9231-e6253ddffb91', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'phamthanhson@gmail.com', N'Phạm', 1, 1, 1, 1, N'Thanh Sơn', 0, N'0901234564', NULL, NULL, NULL, NULL)
INSERT [dbo].[Members] ([MemberID], [AccountID], [JoinedAt], [IsActive], [Address], [Dob], [Email], [FirstName], [Gender], [IsAdult], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [LastName], [Money], [PhoneNumber], [VerficationCodeEmail], [VerficationCodePhoneNumber], [Hobby], [Job]) VALUES (N'ad17339f-1330-4cec-9928-87701bdd695f', N'a03ade30-d417-4ba2-9bf4-a49ef20248d0', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'buitrunghieu@gmail.com', N'Bùi', 1, 1, 1, 1, N'Trung Hiếu', 0, N'0901234569', NULL, NULL, NULL, NULL)
INSERT [dbo].[Members] ([MemberID], [AccountID], [JoinedAt], [IsActive], [Address], [Dob], [Email], [FirstName], [Gender], [IsAdult], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [LastName], [Money], [PhoneNumber], [VerficationCodeEmail], [VerficationCodePhoneNumber], [Hobby], [Job]) VALUES (N'985af2c1-22f9-438f-b0ed-8a9a0d7b3998', N'f3907f15-6a42-4f20-a6a1-53e53aa3458e', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'lebichngoc@gmail.com', N'Lê', 0, 1, 1, 1, N'Bích Ngọc', 0, N'0901234563', NULL, NULL, NULL, NULL)
INSERT [dbo].[Members] ([MemberID], [AccountID], [JoinedAt], [IsActive], [Address], [Dob], [Email], [FirstName], [Gender], [IsAdult], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [LastName], [Money], [PhoneNumber], [VerficationCodeEmail], [VerficationCodePhoneNumber], [Hobby], [Job]) VALUES (N'bb0caa36-8fd5-4247-938e-8f644934bfd0', N'de86651b-954f-421d-98e7-d49a031e1eb0', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'andbse161205@fpt.edu.vn', N'Duong Binh An (K16_HCM)', 1, 1, 1, 1, N'', 0, N'', NULL, NULL, NULL, NULL)
INSERT [dbo].[Members] ([MemberID], [AccountID], [JoinedAt], [IsActive], [Address], [Dob], [Email], [FirstName], [Gender], [IsAdult], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [LastName], [Money], [PhoneNumber], [VerficationCodeEmail], [VerficationCodePhoneNumber], [Hobby], [Job]) VALUES (N'fb55cf8e-4759-481b-ace4-9b1a64db195c', N'3f720222-e872-40f7-b578-57413e13955e', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'lethikimanh@gmail.com', N'Lê', 0, 1, 1, 1, N'Thị Kim Anh', 0, N'0901234568', NULL, NULL, NULL, NULL)
INSERT [dbo].[Members] ([MemberID], [AccountID], [JoinedAt], [IsActive], [Address], [Dob], [Email], [FirstName], [Gender], [IsAdult], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [LastName], [Money], [PhoneNumber], [VerficationCodeEmail], [VerficationCodePhoneNumber], [Hobby], [Job]) VALUES (N'42b852cd-b9c4-42bb-9140-b71e9bcb2a4a', N'43cc4051-949e-4c52-bec6-bda4bba42b75', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'dinhhoailinh@gmail.com', N'Đinh', 0, 1, 1, 1, N'Hoài Linh', 0, N'0901234565', NULL, NULL, NULL, NULL)
INSERT [dbo].[Members] ([MemberID], [AccountID], [JoinedAt], [IsActive], [Address], [Dob], [Email], [FirstName], [Gender], [IsAdult], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [LastName], [Money], [PhoneNumber], [VerficationCodeEmail], [VerficationCodePhoneNumber], [Hobby], [Job]) VALUES (N'67457e79-af4d-48a7-a13c-b98329588a79', N'ff8f2265-c820-41f0-b377-cc7ef0d03374', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'nguyenthithanh@gmail.com', N'Nguyễn', 0, 1, 1, 1, N'Thị Thanh', 0, N'0901234570', NULL, NULL, NULL, NULL)
INSERT [dbo].[Members] ([MemberID], [AccountID], [JoinedAt], [IsActive], [Address], [Dob], [Email], [FirstName], [Gender], [IsAdult], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [LastName], [Money], [PhoneNumber], [VerficationCodeEmail], [VerficationCodePhoneNumber], [Hobby], [Job]) VALUES (N'2e26fc47-2648-4529-afd5-c00359328d72', N'4ca7c186-8c45-4d88-a3e0-865ce8e7e653', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'doducmanh@gmail.com', N'Đỗ', 1, 1, 1, 1, N'Đức Mạnh', 0, N'0901234567', NULL, NULL, NULL, NULL)
INSERT [dbo].[Members] ([MemberID], [AccountID], [JoinedAt], [IsActive], [Address], [Dob], [Email], [FirstName], [Gender], [IsAdult], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [LastName], [Money], [PhoneNumber], [VerficationCodeEmail], [VerficationCodePhoneNumber], [Hobby], [Job]) VALUES (N'1ed59ce3-6e02-496e-97f2-c1d78f7fc292', N'882404ca-6de4-471c-a0f6-a5bace3b0d7f', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'tranquocanh@gmail.com', N'Trần', 1, 1, 1, 1, N'Quốc Anh', 0, N'0901234562', NULL, NULL, NULL, NULL)
INSERT [dbo].[Members] ([MemberID], [AccountID], [JoinedAt], [IsActive], [Address], [Dob], [Email], [FirstName], [Gender], [IsAdult], [IsVerfiedPhoneNumber], [IsVerifiedEmail], [LastName], [Money], [PhoneNumber], [VerficationCodeEmail], [VerficationCodePhoneNumber], [Hobby], [Job]) VALUES (N'490a2813-9182-4aac-a50d-dd8ce9e62df1', N'be266567-7b48-41d1-ac22-ca0f48ded153', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'nguyenvananh@gmail.com', N'Nguyễn', 1, 1, 1, 1, N'Văn Anh', 0, N'0901234567', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'e7682b4a-f158-484d-be65-12b72a322e55', N'db56024d-231a-4b8d-88ed-3fd2318b1ba7', N'/images/canon-eos-r5-2.jpg')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'f9355253-dc30-4019-9918-199c06377d67', N'db56024d-231a-4b8d-88ed-3fd2318b1ba7', N'/images/canon-eos-r5-1.jpg')
INSERT [dbo].[ProductImages] ([ProductImagesID], [ProductID], [Image]) VALUES (N'e44987f7-d013-4867-bada-b6f6f274b373', N'229ffd63-e707-4a9e-8612-9fd8f6d37d7a', N'/images/nikon-z7-ii.jpg')
GO
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [Price], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'db56024d-231a-4b8d-88ed-3fd2318b1ba7', N'SN12345', NULL, NULL, N'Canon EOS R5', N'Mirrorless camera with 45MP resolution', 3499.99, NULL, N'New', 2, 5, CAST(N'2024-10-06T00:13:31.8866667' AS DateTime2), CAST(N'2024-10-06T00:13:31.8866667' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [SerialNumber], [SupplierID], [CategoryID], [ProductName], [ProductDescription], [Price], [Brand], [Quality], [Status], [Rating], [CreatedAt], [UpdatedAt]) VALUES (N'229ffd63-e707-4a9e-8612-9fd8f6d37d7a', N'SN98765', NULL, NULL, N'Nikon Z7 II', N'High-resolution mirrorless camera with 45.7MP sensor', 2999.99, NULL, N'Used - Like New', 1, 4.8, CAST(N'2024-10-06T00:13:31.8866667' AS DateTime2), CAST(N'2024-10-06T00:13:31.8866667' AS DateTime2))
GO
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [AccountBalance], [VourcherID]) VALUES (N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'43cc4051-949e-4c52-bec6-bda4bba42b75', N'Nikon Pro Distributors', N'Authorized Nikon distributor', N'5678 Lens Avenue, Hanoi', N'0908000002', N'/images/nikon-logo.png', NULL, NULL, CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), 15000, NULL)
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [AccountBalance], [VourcherID]) VALUES (N'47babe88-fdd0-41a4-8788-2309419cf5f3', N'4ca7c186-8c45-4d88-a3e0-865ce8e7e653', N'Canon Official Store', N'Official supplier of Canon products', N'1234 Camera Street, Ho Chi Minh City', N'0908000001', N'/images/canon-logo.png', NULL, NULL, CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), 10000, NULL)
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [AccountBalance], [VourcherID]) VALUES (N'31f0617f-4e0c-4630-bfee-66940e2b2fc9', N'882404ca-6de4-471c-a0f6-a5bace3b0d7f', N'Sony Gear Distributors', N'Sony authorized distributor', N'7890 Shutter Lane, Da Nang', N'0908000003', N'/images/sony-logo.png', NULL, NULL, CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), 20000, NULL)
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [AccountBalance], [VourcherID]) VALUES (N'e2018a09-032d-4931-ace7-8211a4c54eac', N'a03ade30-d417-4ba2-9bf4-a49ef20248d0', N'Olympus Professional Supplies', N'Distributor of Olympus products', N'2468 Focus Road, Da Lat', N'0908000005', N'/images/olympus-logo.png', NULL, NULL, CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), 5000, NULL)
INSERT [dbo].[Suppliers] ([SupplierID], [AccountID], [SupplierName], [SupplierDescription], [SupplierAddress], [ContactNumber], [SupplierLogo], [BlockReason], [BlockedAt], [CreatedAt], [UpdatedAt], [AccountBalance], [VourcherID]) VALUES (N'd22b3835-25f6-402c-869b-b29dd20c6e7a', N'be266567-7b48-41d1-ac22-ca0f48ded153', N'Fujifilm Supplies', N'Authorized Fujifilm store', N'1357 Lens Boulevard, Hue', N'0908000004', N'/images/fujifilm-logo.png', NULL, NULL, CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), CAST(N'2024-10-06T00:54:27.7300000' AS DateTime2), 8000, NULL)
GO
INSERT [dbo].[Vourchers] ([VourcherID], [SupplierID], [VourcherCode], [Description], [DiscountAmount], [DiscountType], [MaxUsageLimit], [UsagePerCustomer], [MinOrderAmount], [ValidFrom], [ExpirationDate], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'd88dc878-675c-49b3-946e-0a126921ace7', N'2bc015e1-a1d1-4531-b136-12a039e1eff2', N'NIKON50OFF', N'Giảm 50% cho tất cả sản phẩm Nikon', 50, 1, 100, 1, 5000, CAST(N'2024-10-05T18:05:06.7420000' AS DateTime2), CAST(N'2024-11-05T18:05:06.7420000' AS DateTime2), 1, CAST(N'2024-10-05T18:15:55.4269395' AS DateTime2), CAST(N'2024-10-05T18:15:55.4269398' AS DateTime2))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BankInformation_MemberId]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_BankInformation_MemberId] ON [dbo].[BankInformation]
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contracts_OrderID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Contracts_OrderID] ON [dbo].[Contracts]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Members_AccountID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Members_AccountID] ON [dbo].[Members]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_OrderID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_OrderDetails_OrderID] ON [dbo].[OrderDetails]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_ProductID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductID] ON [dbo].[OrderDetails]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderHistory_MemberID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_OrderHistory_MemberID] ON [dbo].[OrderHistory]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderHistory_OrderID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_OrderHistory_OrderID] ON [dbo].[OrderHistory]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_DeliveriesMethodID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_DeliveriesMethodID] ON [dbo].[Orders]
(
	[DeliveriesMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_MemberID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_MemberID] ON [dbo].[Orders]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_SupplierID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_SupplierID] ON [dbo].[Orders]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductImages_ProductID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProductImages_ProductID] ON [dbo].[ProductImages]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ProductReports_Account]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProductReports_Account] ON [dbo].[ProductReports]
(
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductReports_ProductID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProductReports_ProductID] ON [dbo].[ProductReports]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductReports_SupplierID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProductReports_SupplierID] ON [dbo].[ProductReports]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryID] ON [dbo].[Products]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_SupplierID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Products_SupplierID] ON [dbo].[Products]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductSpecifications_ProductID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProductSpecifications_ProductID] ON [dbo].[ProductSpecifications]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Ratings_AccountID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Ratings_AccountID] ON [dbo].[Ratings]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Ratings_ProductID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Ratings_ProductID] ON [dbo].[Ratings]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Reports_AccountId]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Reports_AccountId] ON [dbo].[Reports]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ReturnDetails_OrderID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_ReturnDetails_OrderID] ON [dbo].[ReturnDetails]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Staffs_AccountID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Staffs_AccountID] ON [dbo].[Staffs]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SupplierReports_HandledByAccountId]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierReports_HandledByAccountId] ON [dbo].[SupplierReports]
(
	[HandledByAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierReports_SupplierID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierReports_SupplierID] ON [dbo].[SupplierReports]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierRequests_SupplierID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_SupplierRequests_SupplierID] ON [dbo].[SupplierRequests]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Suppliers_AccountID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Suppliers_AccountID] ON [dbo].[Suppliers]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Suppliers_VourcherID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Suppliers_VourcherID] ON [dbo].[Suppliers]
(
	[VourcherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_BankInformationBankId]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Transactions_BankInformationBankId] ON [dbo].[Transactions]
(
	[BankInformationBankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_MemberId]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Transactions_MemberId] ON [dbo].[Transactions]
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_OrderID]    Script Date: 10/6/2024 1:36:24 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Transactions_OrderID] ON [dbo].[Transactions]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Members] ADD  DEFAULT (N'') FOR [Address]
GO
ALTER TABLE [dbo].[Members] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Dob]
GO
ALTER TABLE [dbo].[Members] ADD  DEFAULT (N'') FOR [Email]
GO
ALTER TABLE [dbo].[Members] ADD  DEFAULT (N'') FOR [FirstName]
GO
ALTER TABLE [dbo].[Members] ADD  DEFAULT ((0)) FOR [Gender]
GO
ALTER TABLE [dbo].[Members] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsAdult]
GO
ALTER TABLE [dbo].[Members] ADD  DEFAULT (N'') FOR [LastName]
GO
ALTER TABLE [dbo].[Members] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Money]
GO
ALTER TABLE [dbo].[Members] ADD  DEFAULT (N'') FOR [PhoneNumber]
GO
ALTER TABLE [dbo].[Policies] ADD  DEFAULT ((0)) FOR [ApplicableObject]
GO
ALTER TABLE [dbo].[Transactions] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [BankInformationBankId]
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
ALTER TABLE [dbo].[OrderHistory]  WITH CHECK ADD  CONSTRAINT [FK_OrderHistory_Members_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Members] ([MemberID])
ON DELETE CASCADE
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
