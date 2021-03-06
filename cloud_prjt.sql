USE [master]
GO
/****** Object:  Database [Cloud_project]    Script Date: 7/29/2020 1:34:02 PM ******/
CREATE DATABASE [Cloud_project]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cloud_project].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cloud_project] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cloud_project] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cloud_project] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cloud_project] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cloud_project] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cloud_project] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cloud_project] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Cloud_project] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cloud_project] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cloud_project] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cloud_project] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cloud_project] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cloud_project] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cloud_project] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cloud_project] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cloud_project] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Cloud_project] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cloud_project] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cloud_project] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cloud_project] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [Cloud_project] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cloud_project] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Cloud_project] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cloud_project] SET RECOVERY FULL 
GO
ALTER DATABASE [Cloud_project] SET  MULTI_USER 
GO
ALTER DATABASE [Cloud_project] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cloud_project] SET DB_CHAINING OFF 
GO
USE [Cloud_project]
GO
/****** Object:  Schema [bluebir1_tav]    Script Date: 7/29/2020 1:34:03 PM ******/
CREATE SCHEMA [bluebir1_tav]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 7/29/2020 1:34:03 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/29/2020 1:34:03 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/29/2020 1:34:04 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/29/2020 1:34:04 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/29/2020 1:34:05 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/29/2020 1:34:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 7/29/2020 1:34:06 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 7/29/2020 1:34:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeCompanyId] [nvarchar](10) NOT NULL,
	[FullName] [nvarchar](256) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Owner] [nvarchar](256) NOT NULL,
	[Manpower] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[EmployeeInProject]    Script Date: 7/29/2020 1:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeInProject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_EmployeeInProject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[EmployeeRole]    Script Date: 7/29/2020 1:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
	[Active] [bit] NOT NULL,
	[Owner] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_CompanyRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Project]    Script Date: 7/29/2020 1:34:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectCompanyId] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[ActualEndDate] [datetime] NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[StatusId] [int] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Status]    Script Date: 7/29/2020 1:34:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[User]    Script Date: 7/29/2020 1:34:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Email] [nvarchar](256) NOT NULL,
	[FullName] [nvarchar](256) NOT NULL,
	[Avatar] [nvarchar](256) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](15) NOT NULL,
	[ActiveCode] [nvarchar](6) NOT NULL,
	[CodeCreateTime] [datetime] NOT NULL,
	[Avtive] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[WorkTime]    Script Date: 7/29/2020 1:34:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkTime](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[WorkDate] [datetime] NOT NULL,
	[WorkHour] [float] NOT NULL,
 CONSTRAINT [PK_WorkTime] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[WorkTimeInProject]    Script Date: 7/29/2020 1:34:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkTimeInProject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeInProjectId] [int] NOT NULL,
	[WorkDate] [datetime] NOT NULL,
	[WorkHour] [float] NOT NULL,
 CONSTRAINT [PK_WorkTimeInProject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1', N'User', N'USER', N'06/07/2020')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'70b7b2a0-a209-4a33-afef-d2daea2a4efa', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9f9c64ad-e753-43dd-9048-eebeea15f833', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b30512b3-ceed-423a-9749-baa44bc08b18', N'1')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0a303162-5a19-4d8a-955d-fd2c6df950c8', N'test117@gmail.com', N'TEST117@GMAIL.COM', N'test117@gmail.com', N'TEST117@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEOK9Jw3XDO2jHCTvzZCLu7Z2DFRFw6xB2Fudls5t5vw0TxQ/SnLs0nO0wZh4rNJUjg==', N'SEX2DJHL2GJRPRHL5TF6D6WECA2ZDFDB', N'fa84ab72-955f-4788-9ed9-1115b0340de8', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'124bf2bd-7356-4af7-92bf-0550380a92b6', N'nguyennkse61616@fpt.edu.vn', N'NGUYENNKSE61616@FPT.EDU.VN', N'nguyennkse61616@fpt.edu.vn', N'NGUYENNKSE61616@FPT.EDU.VN', 0, N'AQAAAAEAACcQAAAAEF9ZaKa7HeoC0rnO+Ves7Ac7xOaxRvO6KUe+EKN1gWIDP3LB0Ko4sNTqYRUcuxMz1w==', N'HM644GTDGWNYOCJODCMNNYPK2XMQE3W5', N'c22bc8aa-0163-4bcd-a10b-9f1f0d9425ff', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'1294fd5a-8bda-4286-8696-219ea006b90b', N'trantienhoabinh6@gmail.com', N'TRANTIENHOABINH6@GMAIL.COM', N'trantienhoabinh6@gmail.com', N'TRANTIENHOABINH6@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEAjg+/oXTSCEvSyN3Ui2rzWMR6f2oxU3J1FPXrgk5wydAmK/yZy4J7lHSwHZ4LQmeA==', N'4M7PWN7YBQOZUAIUEFUGP63SF3HNRPIJ', N'c6cde714-d937-4e60-b027-8136382723ae', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'1353e3ec-5b4e-42c3-b9a5-05cc92d42e31', N'trantienhoabinh5@gmail.com', N'TRANTIENHOABINH5@GMAIL.COM', N'trantienhoabinh5@gmail.com', N'TRANTIENHOABINH5@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKLHga2xUCO59XF0O4kda2uq+GwSwqWQdJsY0ZsNVkhgsIFJ/kSyEY24AiXIDTqGEw==', N'T6SVPCWSUAJFGRUBZVTBR372VKMPH4S5', N'524d29d6-eddb-4d1e-a8e8-3fb4248b7504', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2f540ad4-8d7b-4786-b204-ebcb71991ad7', N'trantienhoabinh1111@gmail.com', N'TRANTIENHOABINH1111@GMAIL.COM', N'trantienhoabinh1111@gmail.com', N'TRANTIENHOABINH1111@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEJ9M7ZMdd+FcjvSHB+XT6+/X6cy4Dg+snjQAz3GTW4Fz+Jr7FP8psHyk64/gaAe0SA==', N'I3USMGPZKWIYVMHS54NBPDV5VVWOZL5C', N'a105d84e-7a16-4e28-ac6c-0cf3fe4f6800', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'39e54f7a-fa42-4b08-9542-4eefdf9725df', N'asd@gmail.com', N'ASD@GMAIL.COM', N'asd@gmail.com', N'ASD@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEGDtP2Wd8gSZ5dQzPHQhDeyZ0pZyuZc6kVQGtF7iWkuo/bCaVZVUBNHIoPDpkC8gyg==', N'VCRWSJLSRZF7PS52T77S3OHH52MYHNQF', N'14bc21e9-ba4d-4c02-90f6-afaae6f3e885', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'70b7b2a0-a209-4a33-afef-d2daea2a4efa', N'trantienhoabinh3331@gmail.com', N'TRANTIENHOABINH3331@GMAIL.COM', N'trantienhoabinh3331@gmail.com', N'TRANTIENHOABINH3331@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEGnwuwnspF4hFJiTWw4ihiISgJX4sWytKjCvSbkkxoN9m9LkyOr0oj0hetqe7fOF6w==', N'KHVHAXFNTCDMY6YGRJDAMHQCPCCVPDB4', N'0b4c940d-c68d-4fbd-8fb1-1a52b5ba169d', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'84dc2b54-e9e7-452e-ae54-a336ea7e8417', N'vitcai1@gmail.com', N'VITCAI1@GMAIL.COM', N'vitcai1@gmail.com', N'VITCAI1@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAELbwLWCJn3nrfuQag1byMqjWJ/CDvl2qu5M2k/vYw+e5B0g8rz68njdhZh1aHdj+9w==', N'AQJKLRLCMTPPVWLYJNO25F4NOAB7WLW6', N'70123f0a-e2e8-4ade-a387-5aafe502cc6d', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9807161f-356f-4d75-81e9-6d5f1b45d66e', N'test118@gmail.com', N'TEST118@GMAIL.COM', N'test118@gmail.com', N'TEST118@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAENa5uRG8BbzTZL+Y+L/zqGUW9xE2zEsHOMEvVkKKNBz2ZMlEOZDl5/MzCsWMaa7yzA==', N'VZ5UFREF2KEXE7Z7NOCAD7IJJFDEQS72', N'c8fe7e6c-dd4b-4c52-a587-dcedcf345d9e', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9bcb74c4-ae50-46dd-acaa-f94343348c3a', N'trantienhoabinh3@gmail.com', N'TRANTIENHOABINH3@GMAIL.COM', N'trantienhoabinh3@gmail.com', N'TRANTIENHOABINH3@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEEhccC1E7+PymROTd2Qmev+AwHqKlBXO75ua1yV//k6vbQc8fwB0SSlYIUo3FXLZSw==', N'ATFEBT3U6R3K2WZQSXIH3XEZSFDJAWZB', N'560d644a-ad77-4161-ba3f-81ee40cc3f42', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9c7f8da9-b843-4821-bfcb-3693ab3ab6c6', N'trantienhoabinh1121@gmail.com', N'TRANTIENHOABINH1121@GMAIL.COM', N'trantienhoabinh1121@gmail.com', N'TRANTIENHOABINH1121@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAELQLLBrztG34V0FiyBVzFsYRxoS40wIRm8Mujs4LjPEzX+eUrT+JVl9s6GEsAKEwRg==', N'3BFFLSC5LSP7D2LGUCJ3RC5HAXSEFR5V', N'b893131f-5f2b-47bb-8a68-1d58a2c1ee41', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9f9c64ad-e753-43dd-9048-eebeea15f833', N'trantienhoabinh1221@gmail.com', N'TRANTIENHOABINH1221@GMAIL.COM', N'trantienhoabinh1221@gmail.com', N'TRANTIENHOABINH1221@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEEJr1gGWafEDpd+m/zCFFvO/basWC5i+EsCBQyxuZ5gXLPC3zC1DnhDMYFhLFa4qRQ==', N'PTOXMXWAC7Y7GZWOWIN6DELYEGWRULSE', N'95a27afa-a785-4102-ba68-9e20eadcb88c', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a0ddf6f8-54e1-491a-aa1a-55bd2dd584d3', N'vitcai@gmail.com', N'VITCAI@GMAIL.COM', N'vitcai@gmail.com', N'VITCAI@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEJXIN4q+U825pWTCQNeE9782PG/8yUOIy7CgWYMBBhJmZsEj3IZkxkebxOCCMZA8rg==', N'HK7NHNIBWZ7JCJSS727VMIXPBIELZL2V', N'872d0682-86f5-4f67-be15-23d592212843', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a23f6e17-9069-499b-b22c-b1112974135f', N'trantienhoabinh8@gmail.com', N'TRANTIENHOABINH8@GMAIL.COM', N'trantienhoabinh8@gmail.com', N'TRANTIENHOABINH8@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEII8fptTgQOF8vzVNFlxeR8/268QbWR3XU6seU/Zn6GhnRe5tRS+9paDJV4s1e942w==', N'4U3M6VYAERJNV4FOEGMMI5PXITQ43UNR', N'2a2e1b7b-0ba2-4072-bfbe-a0ee1fbc7ce8', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a9989c64-b612-4518-9265-1f3fe49ab351', N'test@gmail.com', N'TEST@GMAIL.COM', N'test@gmail.com', N'TEST@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEIbPzN5JYpuIG8R0xZPdxU6iHCCzG+INccIdER3UQa8628XCSbUBnG0KsL3wYN+DLw==', N'5UWUXF4CJQBGZTY33LYPX36BTGYNP6ME', N'a86c19cc-5de3-493c-857a-b9e2fbc5f766', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'acaa437e-4a41-480f-80a3-ef2b10e0735a', N'trantienhoabinh9@gmail.com', N'TRANTIENHOABINH9@GMAIL.COM', N'trantienhoabinh9@gmail.com', N'TRANTIENHOABINH9@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKD9WvmSmxqaCxYspqrJ77GijB6zWT9Oa1tAyteDUBDctH7c+NTYxzoa+Ta4SdE6vw==', N'ELQC5DUFUGPEQHE3SCVKJRONCBXILFLD', N'3e68990f-f842-494d-af22-89e4d5a27e75', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b30512b3-ceed-423a-9749-baa44bc08b18', N'trantienhoabinh10@gmail.com', N'TRANTIENHOABINH10@GMAIL.COM', N'trantienhoabinh10@gmail.com', N'TRANTIENHOABINH10@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEEYRVV/PmcM4zEdmfkGFxiIU8k71h6PNMD267dX4janAKRPr2vQWQAmqjmebSLrXeg==', N'W32FHBQQEVALVTJ25DLZCD2WJD6DCS2E', N'69f5e5a8-439a-427e-bf7d-f426fca53a4f', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b9c9ebec-a590-46bd-a0c2-117270ac0bb4', N'trantienhoabinh2@gmail.com', N'TRANTIENHOABINH2@GMAIL.COM', N'trantienhoabinh2@gmail.com', N'TRANTIENHOABINH2@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKxtYZtqVrxDuz8TelvMazUT52+JGrtXhT4TR4IdkR+o58bx0TgJf9O1K05rY7wR4Q==', N'UH6BM4HFGIN3SW5YFJ7ME6PORMCOBHNX', N'c959a7c2-3487-4cc3-8260-db4584d7500e', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b9d215f9-d07d-403d-a6c6-b9b0ebdf4f72', N'asdasd@gmail.com', N'ASDASD@GMAIL.COM', N'asdasd@gmail.com', N'ASDASD@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPk/pXHclwW6J0H4E/1sc3PMT5AfluXdmD49uvkSpUDlhXDpoxPpBsgNYjyWRtK1kA==', N'EGV5IQX2TP23NL4K634I4G44ENUGAIQX', N'fec09ed1-662d-4193-ab70-503de826a97c', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ba69a527-c316-4ce0-b4d2-dca57627f613', N'trananvu1997@gmail.com', N'TRANANVU1997@GMAIL.COM', N'trananvu1997@gmail.com', N'TRANANVU1997@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEL5B396nRiNxy2CaIatW7s0QfI6QwSOBJdB/rn4pKRgEw14H6iIfiMv7x4J1sOcgJQ==', N'ZWAUALGW4UE5QWS4YDBQHGQCJXDNJEXW', N'8d1088be-1c51-4ca5-8262-d02194041ca5', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c83f452b-af23-442a-a50c-e45ff8605914', N'trantienhoabinh7@gmail.com', N'TRANTIENHOABINH7@GMAIL.COM', N'trantienhoabinh7@gmail.com', N'TRANTIENHOABINH7@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEFdk5mFELOcAGfz8xCt9bSMMx00b6bHoQAUPigiQllXqI7t63fA2jrwCD0ePe555Yw==', N'6TTYDB5W7CRHBLLEARQSML6NUOL43TFC', N'f57b3415-6998-40eb-8e13-7dfd401c97d2', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'cdba3ebd-22cc-427c-acbb-a054f48da76b', N'nh0k.miss.you117@gmail.com', N'NH0K.MISS.YOU117@GMAIL.COM', N'nh0k.miss.you117@gmail.com', N'NH0K.MISS.YOU117@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBhhrKDHqj5ZI+G+abbg58rTqj4fh3XPosP5IEN+QFnHl6zGNTiCc7EN49C5jUQ9tw==', N'CQBCZFK2IWJW6F5KCWM2P3YI7NS33GQG', N'b4dd7bf0-9d65-443e-8666-3d060cc43c4a', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd166d743-6a8e-4d6f-8b7c-877cc83c5202', N'tav@gmail.com', N'TAV@GMAIL.COM', N'tav@gmail.com', N'TAV@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEJ/xwIye8u9MJ5m38lEpe4oEKYtWFxPYvNEY4R7SR38ssIkZApZNet59p+X744blFg==', N'E7ZN37GYKEVCY57FZUGZXMLYI55P7QUF', N'1609f8f6-9f12-4fa8-ad3d-a271fa180a61', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd495c279-cbc0-4a86-85ae-600571e44d16', N'trantienhoabinh111@gmail.com', N'TRANTIENHOABINH111@GMAIL.COM', N'trantienhoabinh111@gmail.com', N'TRANTIENHOABINH111@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEB9emNzMuLvxjWDA6hHQTAUwLLsBv0iwz/1uJbC9sKxaH37GXEa6S77rLCSKt5RXoA==', N'SNDWJBEZEIO677TDJLAHOGXXHMJEQ5YV', N'fcf51786-62e1-4b52-b5e7-e17ec65c8f48', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ddf6b2c2-c4e9-49ea-9da5-e180ffdc2499', N'nacker', N'NACKER', N'nacker', N'NACKER', 0, N'AQAAAAEAACcQAAAAEIdK4zkSAx1m+6Ogkp3NJow77Flw43vMVEwkMne8SCIqnOt9SgSE5vUoBzTovCzMDg==', N'WSVP6PTIXWPUD3NSLU3TDY73OP6E3KDQ', N'7360b120-53fb-4c0a-a9f8-93bce8a69f07', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ecdfaf1d-f9fe-4dc5-a97e-28e4170c04ad', N'khoinguyen.nick@gmail.com', N'KHOINGUYEN.NICK@GMAIL.COM', N'khoinguyen.nick@gmail.com', N'KHOINGUYEN.NICK@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEB9rWuI9/fVtyFNZGD0gYOk0ccHnEJksoGmY3KSh6S75JxSJ8Lw74PBgQWRiaPfOog==', N'AA4FRW5HIVFANW4D5UUM37BO4SZZETCP', N'31ee38ab-9759-4ee4-8a7e-c953d208a984', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [EmployeeCompanyId], [FullName], [RoleId], [Owner], [Manpower], [Active]) VALUES (1, N'Emp001', N'Hòa Bình', 1, N'trantienhoabinh10@gmail.com', 111, 1)
INSERT [dbo].[Employee] ([Id], [EmployeeCompanyId], [FullName], [RoleId], [Owner], [Manpower], [Active]) VALUES (2, N'DEV2', N'Tien Thanh', 5, N'tav@gmail.com', 6, 1)
INSERT [dbo].[Employee] ([Id], [EmployeeCompanyId], [FullName], [RoleId], [Owner], [Manpower], [Active]) VALUES (3, N'TEST2', N'Ba Nam', 6, N'tav@gmail.com', 8, 1)
INSERT [dbo].[Employee] ([Id], [EmployeeCompanyId], [FullName], [RoleId], [Owner], [Manpower], [Active]) VALUES (4, N'EM01', N'Tran Vu', 5, N'tav@gmail.com', 6, 1)
INSERT [dbo].[Employee] ([Id], [EmployeeCompanyId], [FullName], [RoleId], [Owner], [Manpower], [Active]) VALUES (5, N'EM02', N'Duc Nam', 5, N'tav@gmail.com', 5, 0)
INSERT [dbo].[Employee] ([Id], [EmployeeCompanyId], [FullName], [RoleId], [Owner], [Manpower], [Active]) VALUES (6, N'EM03', N'Nguyen Nguyen', 5, N'tav@gmail.com', 6, 1)
INSERT [dbo].[Employee] ([Id], [EmployeeCompanyId], [FullName], [RoleId], [Owner], [Manpower], [Active]) VALUES (8, N'EM04', N'Loc Loc', 6, N'tav@gmail.com', 6, 1)
INSERT [dbo].[Employee] ([Id], [EmployeeCompanyId], [FullName], [RoleId], [Owner], [Manpower], [Active]) VALUES (9, N'T002', N'Dai Phong', 6, N'tav@gmail.com', 5, 1)
INSERT [dbo].[Employee] ([Id], [EmployeeCompanyId], [FullName], [RoleId], [Owner], [Manpower], [Active]) VALUES (10, N'T003', N'Phong Nam', 7, N'tav@gmail.com', 5, 1)
INSERT [dbo].[Employee] ([Id], [EmployeeCompanyId], [FullName], [RoleId], [Owner], [Manpower], [Active]) VALUES (11, N'MN00A', N'Nawui', 7, N'tav@gmail.com', 9, 1)
INSERT [dbo].[Employee] ([Id], [EmployeeCompanyId], [FullName], [RoleId], [Owner], [Manpower], [Active]) VALUES (12, N'MNS00', N'Uiop', 7, N'tav@gmail.com', 10, 1)
INSERT [dbo].[Employee] ([Id], [EmployeeCompanyId], [FullName], [RoleId], [Owner], [Manpower], [Active]) VALUES (13, N'MGQ111', N'Guzmi', 5, N'tav@gmail.com', 10, 1)
INSERT [dbo].[Employee] ([Id], [EmployeeCompanyId], [FullName], [RoleId], [Owner], [Manpower], [Active]) VALUES (14, N'ASW', N'asd', 5, N'tav@gmail.com', 55, 1)
INSERT [dbo].[Employee] ([Id], [EmployeeCompanyId], [FullName], [RoleId], [Owner], [Manpower], [Active]) VALUES (15, N'NMA001', N'Hinzja', 6, N'tav@gmail.com', 5, 1)
INSERT [dbo].[Employee] ([Id], [EmployeeCompanyId], [FullName], [RoleId], [Owner], [Manpower], [Active]) VALUES (16, N'dev5', N'hahay', 7, N'tav@gmail.com', 56, 1)
INSERT [dbo].[Employee] ([Id], [EmployeeCompanyId], [FullName], [RoleId], [Owner], [Manpower], [Active]) VALUES (17, N't18', N'hh', 6, N'tav@gmail.com', 63639, 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[EmployeeInProject] ON 

INSERT [dbo].[EmployeeInProject] ([Id], [EmployeeId], [ProjectId], [Active]) VALUES (1, 4, 2, 1)
INSERT [dbo].[EmployeeInProject] ([Id], [EmployeeId], [ProjectId], [Active]) VALUES (2, 4, 1, 1)
INSERT [dbo].[EmployeeInProject] ([Id], [EmployeeId], [ProjectId], [Active]) VALUES (3, 3, 1, 1)
INSERT [dbo].[EmployeeInProject] ([Id], [EmployeeId], [ProjectId], [Active]) VALUES (5, 3, 2, 1)
INSERT [dbo].[EmployeeInProject] ([Id], [EmployeeId], [ProjectId], [Active]) VALUES (6, 2, 1, 1)
INSERT [dbo].[EmployeeInProject] ([Id], [EmployeeId], [ProjectId], [Active]) VALUES (10, 5, 1, 1)
INSERT [dbo].[EmployeeInProject] ([Id], [EmployeeId], [ProjectId], [Active]) VALUES (13, 3, 4, 1)
INSERT [dbo].[EmployeeInProject] ([Id], [EmployeeId], [ProjectId], [Active]) VALUES (14, 3, 5, 1)
INSERT [dbo].[EmployeeInProject] ([Id], [EmployeeId], [ProjectId], [Active]) VALUES (15, 3, 6, 1)
INSERT [dbo].[EmployeeInProject] ([Id], [EmployeeId], [ProjectId], [Active]) VALUES (16, 6, 1, 1)
INSERT [dbo].[EmployeeInProject] ([Id], [EmployeeId], [ProjectId], [Active]) VALUES (17, 4, 6, 1)
INSERT [dbo].[EmployeeInProject] ([Id], [EmployeeId], [ProjectId], [Active]) VALUES (18, 2, 7, 1)
INSERT [dbo].[EmployeeInProject] ([Id], [EmployeeId], [ProjectId], [Active]) VALUES (19, 8, 1, 1)
INSERT [dbo].[EmployeeInProject] ([Id], [EmployeeId], [ProjectId], [Active]) VALUES (20, 1, 1, 1)
INSERT [dbo].[EmployeeInProject] ([Id], [EmployeeId], [ProjectId], [Active]) VALUES (21, 11, 1, 1)
INSERT [dbo].[EmployeeInProject] ([Id], [EmployeeId], [ProjectId], [Active]) VALUES (22, 1, 12, 1)
SET IDENTITY_INSERT [dbo].[EmployeeInProject] OFF
SET IDENTITY_INSERT [dbo].[EmployeeRole] ON 

INSERT [dbo].[EmployeeRole] ([Id], [Description], [Active], [Owner]) VALUES (1, N'Project Manager', 1, N'trantienhoabinh10@gmail.com')
INSERT [dbo].[EmployeeRole] ([Id], [Description], [Active], [Owner]) VALUES (5, N'Dev', 1, N'tav@gmail.com')
INSERT [dbo].[EmployeeRole] ([Id], [Description], [Active], [Owner]) VALUES (6, N'Tester', 1, N'tav@gmail.com')
INSERT [dbo].[EmployeeRole] ([Id], [Description], [Active], [Owner]) VALUES (7, N'Manager', 1, N'tav@gmail.com')
INSERT [dbo].[EmployeeRole] ([Id], [Description], [Active], [Owner]) VALUES (8, N'Coder', 1, N'tav@gmail.com')
INSERT [dbo].[EmployeeRole] ([Id], [Description], [Active], [Owner]) VALUES (9, N'tttttttt', 0, N'tav@gmail.com')
INSERT [dbo].[EmployeeRole] ([Id], [Description], [Active], [Owner]) VALUES (10, N'asdasdasd', 0, N'tav@gmail.com')
INSERT [dbo].[EmployeeRole] ([Id], [Description], [Active], [Owner]) VALUES (15, N'TESTt', 0, N'tav@gmail.com')
INSERT [dbo].[EmployeeRole] ([Id], [Description], [Active], [Owner]) VALUES (16, N'TESTt', 0, N'tav@gmail.com')
INSERT [dbo].[EmployeeRole] ([Id], [Description], [Active], [Owner]) VALUES (17, N'TESTt', 0, N'tav@gmail.com')
INSERT [dbo].[EmployeeRole] ([Id], [Description], [Active], [Owner]) VALUES (18, N'TEAS', 0, N'tav@gmail.com')
INSERT [dbo].[EmployeeRole] ([Id], [Description], [Active], [Owner]) VALUES (19, N'asdasd', 0, N'tav@gmail.com')
SET IDENTITY_INSERT [dbo].[EmployeeRole] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [ProjectCompanyId], [Description], [StartDate], [EndDate], [ActualEndDate], [Email], [StatusId]) VALUES (1, N'PR001', N'Dota Moblie App', CAST(0x0000AA55005EDE28 AS DateTime), CAST(0x0000AD30005EDE28 AS DateTime), CAST(0x0000AA8E01835D42 AS DateTime), N'tav@gmail.com', 2)
INSERT [dbo].[Project] ([Id], [ProjectCompanyId], [Description], [StartDate], [EndDate], [ActualEndDate], [Email], [StatusId]) VALUES (2, N'PR002', N'Dota Web app', CAST(0x0000AA55005E7A4C AS DateTime), CAST(0x0000AA55005E7A4C AS DateTime), CAST(0x00008EAC00000000 AS DateTime), N'tav@gmail.com', 2)
INSERT [dbo].[Project] ([Id], [ProjectCompanyId], [Description], [StartDate], [EndDate], [ActualEndDate], [Email], [StatusId]) VALUES (4, N'PR003', N'Coffee Web App', CAST(0x0000A9C800000000 AS DateTime), CAST(0x0000AB3500000000 AS DateTime), CAST(0x00008EAF00000000 AS DateTime), N'trananvu1997@gmail.com', 6)
INSERT [dbo].[Project] ([Id], [ProjectCompanyId], [Description], [StartDate], [EndDate], [ActualEndDate], [Email], [StatusId]) VALUES (5, N'PR004', N'Dota Api', CAST(0x0000A9C800000000 AS DateTime), CAST(0x0000AB3500000000 AS DateTime), CAST(0x00008EAF00000000 AS DateTime), N'tav@gmail.com', 4)
INSERT [dbo].[Project] ([Id], [ProjectCompanyId], [Description], [StartDate], [EndDate], [ActualEndDate], [Email], [StatusId]) VALUES (6, N'PRCWA', N'Coffee Web App', CAST(0x00008F65001F573F AS DateTime), CAST(0x0000AA80001F573F AS DateTime), CAST(0x00008EAC00000000 AS DateTime), N'tav@gmail.com', 2)
INSERT [dbo].[Project] ([Id], [ProjectCompanyId], [Description], [StartDate], [EndDate], [ActualEndDate], [Email], [StatusId]) VALUES (7, N'PRJCF', N'Coffee Mobile App', CAST(0x0000AB2100034BC0 AS DateTime), CAST(0x0000AC8E00034BC0 AS DateTime), CAST(0x0000AA8E018263FE AS DateTime), N'tav@gmail.com', 3)
INSERT [dbo].[Project] ([Id], [ProjectCompanyId], [Description], [StartDate], [EndDate], [ActualEndDate], [Email], [StatusId]) VALUES (8, N'PR001', N'TAV', CAST(0x0000A9E600270060 AS DateTime), CAST(0x0000AB6C00FD3C20 AS DateTime), CAST(0x00008EAC00000000 AS DateTime), N'vitcai1@gmail.com', 6)
INSERT [dbo].[Project] ([Id], [ProjectCompanyId], [Description], [StartDate], [EndDate], [ActualEndDate], [Email], [StatusId]) VALUES (9, N'JustT', N'Test', CAST(0x0000AA8F00000000 AS DateTime), CAST(0x0000AAAE00000000 AS DateTime), CAST(0x00008EAC00000000 AS DateTime), N'tav@gmail.com', 6)
INSERT [dbo].[Project] ([Id], [ProjectCompanyId], [Description], [StartDate], [EndDate], [ActualEndDate], [Email], [StatusId]) VALUES (10, N'Noh', N'Tasd', CAST(0x0000AA8F00000000 AS DateTime), CAST(0x0000AB2800000000 AS DateTime), CAST(0x00008EAC00000000 AS DateTime), N'tav@gmail.com', 6)
INSERT [dbo].[Project] ([Id], [ProjectCompanyId], [Description], [StartDate], [EndDate], [ActualEndDate], [Email], [StatusId]) VALUES (11, N'TAS', N'SomeT', CAST(0x0000AA8F00000000 AS DateTime), CAST(0x0000AAEB00000000 AS DateTime), CAST(0x00008EAC00000000 AS DateTime), N'tav@gmail.com', 6)
INSERT [dbo].[Project] ([Id], [ProjectCompanyId], [Description], [StartDate], [EndDate], [ActualEndDate], [Email], [StatusId]) VALUES (12, N'ProjectTest001', N'Testttt001', CAST(0x0000ABEB00000000 AS DateTime), CAST(0x0000AC0900000000 AS DateTime), CAST(0x00008EAC00000000 AS DateTime), N'trantienhoabinh10@gmail.com', 6)
SET IDENTITY_INSERT [dbo].[Project] OFF
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Id], [Description], [Active]) VALUES (2, N'IN PROGRESS', 1)
INSERT [dbo].[Status] ([Id], [Description], [Active]) VALUES (3, N'FINISHED', 1)
INSERT [dbo].[Status] ([Id], [Description], [Active]) VALUES (4, N'LATE', 1)
INSERT [dbo].[Status] ([Id], [Description], [Active]) VALUES (5, N'CANCEL', 1)
INSERT [dbo].[Status] ([Id], [Description], [Active]) VALUES (6, N'NOT STARTED', 1)
SET IDENTITY_INSERT [dbo].[Status] OFF
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'asd@gmail.com', N'TAV', N'Media/User/default.jpg', N'Tav@123', N'0123456', N'', CAST(0x0000AA7E0142DA0F AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'asdasd@gmail.com', N'TAV', N'Media/User/default.jpg', N'TAV', N'8442179867', N'SVACC', CAST(0x0000AA7E01538936 AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'khoinguyen.nick@gmail.com', N'nguyen khoi nguyen', N'https://i.ibb.co/wNPsP1C/default.jpg', N'12 dkjw', N'0869275637', N'JDWRN', CAST(0x0000ABFA018AA8BB AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'nacker', N'NackerPri', N'Media/User/default.jpg', N'Home less', N'000000000', N'', CAST(0x0000AA8300CB62BD AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'nguyennkse61616@fpt.edu.vn', N'nguyen', N'https://i.ibb.co/wNPsP1C/default.jpg', N'27 NBK', N'0869275637', N'', CAST(0x0000ABFA00D5EE57 AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'nh0k.miss.you117@gmail.com', N'Tien Thanh', N'Media/User/default.jpg', N'công ty Fsoft ,Đường D1, Khu Công Nghệ Cao', N'5435112323', N'', CAST(0x0000AA8C01084977 AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'tav@gmail.com', N'Tran Vu', N'Media/User/tav@gmail.com.jpg', N'123 32', N'0123456789', N'', CAST(0x0000AA4E01650812 AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'test@gmail.com', N'Tester', N'Media/User/default.jpg', N'121211', N'0123123654', N'', CAST(0x0000AA6F00CBF964 AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'test117@gmail.com', N'Tien Thanh', N'Media/User/default.jpg', N'132 go go FULL', N'092123123', N'', CAST(0x0000AA8C0107F4BF AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'test118@gmail.com', N'tien thanh', N'Media/User/test118@gmail.com.png', N'heuw 12', N'73737262', N'', CAST(0x0000AA8C0108D182 AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'trananvu1997@gmail.com', N'Trần Vũ', N'Media/User/default.jpg', N'123aaaaaa', N'0123456789222', N'PHLQQ', CAST(0x0000AA7F0094D45B AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'trantienhoabinh10@gmail.com', N'trantienhoabinh', N'https://i.ibb.co/wNPsP1C/default.jpg', N'620NTD', N'0909842554', N'', CAST(0x0000ABF0016BAE97 AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'trantienhoabinh111@gmail.com', N'binhhhhhhhhhh', N'https://i.ibb.co/wNPsP1C/default.jpg', N'aaaaaaaaaaa', N'0948875554', N'', CAST(0x0000AC050133540D AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'trantienhoabinh1111@gmail.com', N'binhhhhhhhhhh', N'https://i.ibb.co/wNPsP1C/default.jpg', N'aaaaaaaaaaa', N'0948875554', N'', CAST(0x0000AC050133CABC AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'trantienhoabinh1121@gmail.com', N'binhhhhhhhhhh', N'https://i.ibb.co/wNPsP1C/default.jpg', N'aaaaaaaaaaa', N'0948875554', N'', CAST(0x0000AC0501352684 AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'trantienhoabinh1221@gmail.com', N'binhhhhhhhhhh', N'https://i.ibb.co/wNPsP1C/default.jpg', N'aaaaaaaaaaa', N'0948875554', N'', CAST(0x0000AC05013697A6 AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'trantienhoabinh2@gmail.com', N'Tran tien hoa binh 3', N'https://i.ibb.co/wNPsP1C/default.jpg', N'620 NTD', N'0946842249', N'', CAST(0x0000ABF000E96FE2 AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'trantienhoabinh3@gmail.com', N'Tran tien hoa binh 3', N'https://i.ibb.co/wNPsP1C/default.jpg', N'620 NTD', N'0946842249', N'', CAST(0x0000ABF000E94F58 AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'trantienhoabinh3331@gmail.com', N'bbbbbbbbbbhnhnh', N'https://cs1100320008fffce60.blob.core.windows.net/ppsystem-blob/trantienhoabinh3331@gmail.com.jpg', N'dddddddddddddss', N'0984842244', N'', CAST(0x0000AC0500C3C78D AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'trantienhoabinh5@gmail.com', N'trantienhoabinh', N'https://i.ibb.co/wNPsP1C/default.jpg', N'620 ntd5adsasd', N'094879754', N'', CAST(0x0000ABF000EA4429 AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'trantienhoabinh6@gmail.com', N'trantienhoabinh6', N'https://i.ibb.co/wNPsP1C/default.jpg', N'620 NTDQ2TPHCM', N'0909243885', N'', CAST(0x0000ABF000EB5E69 AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'trantienhoabinh7@gmail.com', N'trantienhoabinh6', N'https://i.ibb.co/wNPsP1C/default.jpg', N'620 NTDQ2TPHCM', N'0909243885', N'', CAST(0x0000ABF0015F5A80 AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'trantienhoabinh8@gmail.com', N'trantienhoabinh6', N'https://i.ibb.co/wNPsP1C/default.jpg', N'620 NTDQ2TPHCM', N'0909243885', N'', CAST(0x0000ABF00161303A AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'trantienhoabinh9@gmail.com', N'Tran Tien Hoa Binh', N'https://i.ibb.co/wNPsP1C/default.jpg', N'620 NTD', N'0946844488', N'BCUXF', CAST(0x0000ABFA015B2D40 AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'vitcai@gmail.com', N'Ngay hom qua', N'Media/User/default.jpg', N'123', N'123', N'', CAST(0x0000AA7E01516FE1 AS DateTime), 1)
INSERT [dbo].[User] ([Email], [FullName], [Avatar], [Address], [PhoneNumber], [ActiveCode], [CodeCreateTime], [Avtive]) VALUES (N'vitcai1@gmail.com', N'Tran Vu', N'Media/User/default.jpg', N'121/1 ABCD', N'0123456789', N'', CAST(0x0000AA8600A7B2D5 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[WorkTime] ON 

INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (1, 1, CAST(0x0000AA5A0010A451 AS DateTime), 8)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (2, 1, CAST(0x0000AA5B0010A451 AS DateTime), 8)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (3, 1, CAST(0x0000AA5C0010A451 AS DateTime), 8)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (4, 1, CAST(0x0000AA5D0010A451 AS DateTime), 8)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (5, 2, CAST(0x0000AA5A0042BFEF AS DateTime), 6)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (6, 1, CAST(0x0000AA86007C8A70 AS DateTime), 5)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (7, 1, CAST(0x0000AA8600899D66 AS DateTime), 3)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (8, 6, CAST(0x0000AA860089A7BF AS DateTime), 14)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (9, 1, CAST(0x0000AA86009B622A AS DateTime), 7)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (10, 1, CAST(0x0000AA86009B6E32 AS DateTime), 14)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (11, 1, CAST(0x0000AA8D00D72A1E AS DateTime), 2)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (12, 1, CAST(0x0000AA8D00D78AE5 AS DateTime), 5)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (13, 1, CAST(0x0000AA8D00D79123 AS DateTime), 11)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (14, 2, CAST(0x0000AA8D00D8CEDC AS DateTime), 7)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (15, 2, CAST(0x0000AA8D00DE312D AS DateTime), 1)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (16, 2, CAST(0x0000AA8D00DE3BAC AS DateTime), 12)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (17, 2, CAST(0x0000AA8D00DE3F57 AS DateTime), 12)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (18, 2, CAST(0x0000AA8D00DE4068 AS DateTime), 12)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (19, 15, CAST(0x0000AA8D00DE4639 AS DateTime), 1)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (20, 1, CAST(0x0000AA8D00DE62CA AS DateTime), 1)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (21, 1, CAST(0x0000AA8D00DE64A6 AS DateTime), 1)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (22, 1, CAST(0x0000AA8D00DE66EF AS DateTime), 1)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (23, 1, CAST(0x0000AA8D00DE6734 AS DateTime), 1)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (24, 1, CAST(0x0000AA8D00DE677E AS DateTime), 1)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (25, 16, CAST(0x0000AA8D00DE9F55 AS DateTime), 9)
INSERT [dbo].[WorkTime] ([Id], [EmployeeId], [WorkDate], [WorkHour]) VALUES (26, 17, CAST(0x0000AA8E0134AE70 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[WorkTime] OFF
SET IDENTITY_INSERT [dbo].[WorkTimeInProject] ON 

INSERT [dbo].[WorkTimeInProject] ([Id], [EmployeeInProjectId], [WorkDate], [WorkHour]) VALUES (1, 2, CAST(0x0000A9C800000000 AS DateTime), 5)
INSERT [dbo].[WorkTimeInProject] ([Id], [EmployeeInProjectId], [WorkDate], [WorkHour]) VALUES (2, 2, CAST(0x0000A9C800000000 AS DateTime), 6)
INSERT [dbo].[WorkTimeInProject] ([Id], [EmployeeInProjectId], [WorkDate], [WorkHour]) VALUES (4, 3, CAST(0x0000A9C900000000 AS DateTime), 5)
INSERT [dbo].[WorkTimeInProject] ([Id], [EmployeeInProjectId], [WorkDate], [WorkHour]) VALUES (5, 2, CAST(0x0000A9C900000000 AS DateTime), 8)
INSERT [dbo].[WorkTimeInProject] ([Id], [EmployeeInProjectId], [WorkDate], [WorkHour]) VALUES (6, 6, CAST(0x0000AA8400DC8278 AS DateTime), 5)
INSERT [dbo].[WorkTimeInProject] ([Id], [EmployeeInProjectId], [WorkDate], [WorkHour]) VALUES (7, 2, CAST(0x0000AA8400E39BD1 AS DateTime), 3)
INSERT [dbo].[WorkTimeInProject] ([Id], [EmployeeInProjectId], [WorkDate], [WorkHour]) VALUES (8, 2, CAST(0x0000AA8400E4951D AS DateTime), 11)
INSERT [dbo].[WorkTimeInProject] ([Id], [EmployeeInProjectId], [WorkDate], [WorkHour]) VALUES (9, 2, CAST(0x0000AA8F0004A276 AS DateTime), 1)
INSERT [dbo].[WorkTimeInProject] ([Id], [EmployeeInProjectId], [WorkDate], [WorkHour]) VALUES (10, 2, CAST(0x0000AA8F0004A6E1 AS DateTime), 8)
INSERT [dbo].[WorkTimeInProject] ([Id], [EmployeeInProjectId], [WorkDate], [WorkHour]) VALUES (11, 16, CAST(0x0000AA8F0004B0B5 AS DateTime), 14)
INSERT [dbo].[WorkTimeInProject] ([Id], [EmployeeInProjectId], [WorkDate], [WorkHour]) VALUES (12, 16, CAST(0x0000AA8F0004B511 AS DateTime), 7)
INSERT [dbo].[WorkTimeInProject] ([Id], [EmployeeInProjectId], [WorkDate], [WorkHour]) VALUES (13, 16, CAST(0x0000AA8F0004B60B AS DateTime), 7)
INSERT [dbo].[WorkTimeInProject] ([Id], [EmployeeInProjectId], [WorkDate], [WorkHour]) VALUES (14, 5, CAST(0x0000AA8F0010E05E AS DateTime), 1)
INSERT [dbo].[WorkTimeInProject] ([Id], [EmployeeInProjectId], [WorkDate], [WorkHour]) VALUES (15, 22, CAST(0x0000ABF000FDB65C AS DateTime), 9)
SET IDENTITY_INSERT [dbo].[WorkTimeInProject] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 7/29/2020 1:34:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 7/29/2020 1:34:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 7/29/2020 1:34:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 7/29/2020 1:34:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EmailIndex]    Script Date: 7/29/2020 1:34:15 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 7/29/2020 1:34:15 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
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
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_CompanyRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[EmployeeRole] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_CompanyRole]
GO
ALTER TABLE [dbo].[EmployeeInProject]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeInProject_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[EmployeeInProject] CHECK CONSTRAINT [FK_EmployeeInProject_Employee]
GO
ALTER TABLE [dbo].[EmployeeInProject]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeInProject_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[EmployeeInProject] CHECK CONSTRAINT [FK_EmployeeInProject_Project]
GO
ALTER TABLE [dbo].[EmployeeRole]  WITH CHECK ADD  CONSTRAINT [FK_CompanyRole_User] FOREIGN KEY([Owner])
REFERENCES [dbo].[User] ([Email])
GO
ALTER TABLE [dbo].[EmployeeRole] CHECK CONSTRAINT [FK_CompanyRole_User]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Status]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_User] FOREIGN KEY([Email])
REFERENCES [dbo].[User] ([Email])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_User]
GO
ALTER TABLE [dbo].[WorkTime]  WITH CHECK ADD  CONSTRAINT [FK_WorkTime_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[WorkTime] CHECK CONSTRAINT [FK_WorkTime_Employee]
GO
ALTER TABLE [dbo].[WorkTimeInProject]  WITH CHECK ADD  CONSTRAINT [FK_WorkTimeInProject_EmployeeInProject] FOREIGN KEY([EmployeeInProjectId])
REFERENCES [dbo].[EmployeeInProject] ([Id])
GO
ALTER TABLE [dbo].[WorkTimeInProject] CHECK CONSTRAINT [FK_WorkTimeInProject_EmployeeInProject]
GO
USE [master]
GO
ALTER DATABASE [Cloud_project] SET  READ_WRITE 
GO
