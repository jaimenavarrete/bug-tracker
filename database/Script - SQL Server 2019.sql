USE [master]
GO
/****** Object:  Database [BugTracker]    Script Date: 17/10/2022 22:03:08 ******/
CREATE DATABASE [BugTracker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BugTracker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BugTracker.mdf' , SIZE = 65536KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BugTracker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BugTracker_log.ldf' , SIZE = 65536KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BugTracker] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BugTracker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BugTracker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BugTracker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BugTracker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BugTracker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BugTracker] SET ARITHABORT OFF 
GO
ALTER DATABASE [BugTracker] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BugTracker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BugTracker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BugTracker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BugTracker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BugTracker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BugTracker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BugTracker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BugTracker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BugTracker] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BugTracker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BugTracker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BugTracker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BugTracker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BugTracker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BugTracker] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BugTracker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BugTracker] SET RECOVERY FULL 
GO
ALTER DATABASE [BugTracker] SET  MULTI_USER 
GO
ALTER DATABASE [BugTracker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BugTracker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BugTracker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BugTracker] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BugTracker] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BugTracker] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BugTracker', N'ON'
GO
ALTER DATABASE [BugTracker] SET QUERY_STORE = OFF
GO
USE [BugTracker]
GO
/****** Object:  Table [dbo].[ActionTypes]    Script Date: 17/10/2022 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_ActionTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivityFlow]    Script Date: 17/10/2022 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityFlow](
	[Id] [nvarchar](36) NOT NULL,
	[UserId] [nvarchar](36) NOT NULL,
	[ActionTypeId] [int] NOT NULL,
	[ItemTypeId] [int] NOT NULL,
	[ItemId] [nvarchar](36) NOT NULL,
	[ActionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ActivityFlow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classifications]    Script Date: 17/10/2022 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Classifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GravityLevels]    Script Date: 17/10/2022 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GravityLevels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_TicketGravities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 17/10/2022 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [nvarchar](36) NOT NULL,
	[Name] [nvarchar](75) NOT NULL,
	[Description] [text] NULL,
	[CreationDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](36) NOT NULL,
	[LastModificationDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](36) NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemTypes]    Script Date: 17/10/2022 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_ItemTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 17/10/2022 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [nvarchar](36) NOT NULL,
	[Name] [nvarchar](75) NOT NULL,
	[Description] [text] NULL,
	[TicketsPrefix] [nvarchar](4) NOT NULL,
	[OwnerId] [nvarchar](36) NULL,
	[StateId] [nvarchar](36) NOT NULL,
	[StartDate] [datetime] NULL,
	[CompletionDate] [datetime] NULL,
	[GroupId] [nvarchar](36) NULL,
	[CreationDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](36) NOT NULL,
	[LastModificationDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](36) NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectStates]    Script Date: 17/10/2022 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectStates](
	[Id] [nvarchar](36) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[GroupId] [nvarchar](36) NULL,
	[ColorHexCode] [nvarchar](7) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](36) NOT NULL,
	[LastModificationDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](36) NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectTags]    Script Date: 17/10/2022 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTags](
	[Id] [nvarchar](36) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[GroupId] [nvarchar](36) NULL,
	[ColorHexCode] [nvarchar](7) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](36) NOT NULL,
	[LastModificationDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](36) NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectTagsAssignment]    Script Date: 17/10/2022 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTagsAssignment](
	[ProjectId] [nvarchar](36) NOT NULL,
	[TagId] [nvarchar](36) NOT NULL,
 CONSTRAINT [PK_ProjectTagsAssignment] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReproducibilityLevels]    Script Date: 17/10/2022 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReproducibilityLevels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_ReproducibilityLevels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 17/10/2022 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[Id] [nvarchar](36) NOT NULL,
	[Name] [nvarchar](75) NOT NULL,
	[Description] [text] NULL,
	[SubmitterId] [nvarchar](36) NOT NULL,
	[StateId] [nvarchar](36) NOT NULL,
	[AssignedUserId] [nvarchar](36) NULL,
	[CompletionDate] [datetime] NULL,
	[GravityId] [int] NULL,
	[ReproducibilityId] [int] NULL,
	[ClassificationId] [int] NULL,
	[ProjectId] [nvarchar](36) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](36) NOT NULL,
	[LastModificationDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](36) NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketStates]    Script Date: 17/10/2022 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketStates](
	[Id] [nvarchar](36) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[ProjectId] [nvarchar](36) NOT NULL,
	[ColorHexCode] [nvarchar](7) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](36) NOT NULL,
	[LastModificationDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](36) NULL,
 CONSTRAINT [PK_TicketStates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketTags]    Script Date: 17/10/2022 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketTags](
	[Id] [nvarchar](36) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[ProjectId] [nvarchar](36) NOT NULL,
	[ColorHexCode] [nvarchar](7) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](36) NOT NULL,
	[LastModificationDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](36) NULL,
 CONSTRAINT [PK_TicketTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketTagsAssignment]    Script Date: 17/10/2022 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketTagsAssignment](
	[TicketId] [nvarchar](36) NOT NULL,
	[TagId] [nvarchar](36) NOT NULL,
 CONSTRAINT [PK_TicketTagsAssignment] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ActivityFlow]  WITH CHECK ADD  CONSTRAINT [FK_ActivityEntities_ActivityFlow] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[ItemTypes] ([Id])
GO
ALTER TABLE [dbo].[ActivityFlow] CHECK CONSTRAINT [FK_ActivityEntities_ActivityFlow]
GO
ALTER TABLE [dbo].[ActivityFlow]  WITH CHECK ADD  CONSTRAINT [FK_ActivityTypes_ActivityFlow] FOREIGN KEY([ActionTypeId])
REFERENCES [dbo].[ActionTypes] ([Id])
GO
ALTER TABLE [dbo].[ActivityFlow] CHECK CONSTRAINT [FK_ActivityTypes_ActivityFlow]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Projects] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Groups_Projects]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStates_Projects] FOREIGN KEY([StateId])
REFERENCES [dbo].[ProjectStates] ([Id])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_ProjectStates_Projects]
GO
ALTER TABLE [dbo].[ProjectStates]  WITH CHECK ADD  CONSTRAINT [FK_Groups_ProjectStates] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[ProjectStates] CHECK CONSTRAINT [FK_Groups_ProjectStates]
GO
ALTER TABLE [dbo].[ProjectTags]  WITH CHECK ADD  CONSTRAINT [FK_Groups_ProjectTags] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[ProjectTags] CHECK CONSTRAINT [FK_Groups_ProjectTags]
GO
ALTER TABLE [dbo].[ProjectTagsAssignment]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ProjectTagsAssignment] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[ProjectTagsAssignment] CHECK CONSTRAINT [FK_Projects_ProjectTagsAssignment]
GO
ALTER TABLE [dbo].[ProjectTagsAssignment]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTags_ProjectTagsAssignment] FOREIGN KEY([TagId])
REFERENCES [dbo].[ProjectTags] ([Id])
GO
ALTER TABLE [dbo].[ProjectTagsAssignment] CHECK CONSTRAINT [FK_ProjectTags_ProjectTagsAssignment]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Classifications_Tickets] FOREIGN KEY([ClassificationId])
REFERENCES [dbo].[Classifications] ([Id])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Classifications_Tickets]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_GravityLevels_Tickets] FOREIGN KEY([GravityId])
REFERENCES [dbo].[GravityLevels] ([Id])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_GravityLevels_Tickets]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Tickets] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Projects_Tickets]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_ReproducibilityLevels_Tickets] FOREIGN KEY([ReproducibilityId])
REFERENCES [dbo].[ReproducibilityLevels] ([Id])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_ReproducibilityLevels_Tickets]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_TicketsStates_Tickets] FOREIGN KEY([StateId])
REFERENCES [dbo].[TicketStates] ([Id])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_TicketsStates_Tickets]
GO
ALTER TABLE [dbo].[TicketStates]  WITH CHECK ADD  CONSTRAINT [FK_Projects_TicketStates] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[TicketStates] CHECK CONSTRAINT [FK_Projects_TicketStates]
GO
ALTER TABLE [dbo].[TicketTags]  WITH CHECK ADD  CONSTRAINT [FK_Projects_TicketTags] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[TicketTags] CHECK CONSTRAINT [FK_Projects_TicketTags]
GO
ALTER TABLE [dbo].[TicketTagsAssignment]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_TicketTagsAssignment] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([Id])
GO
ALTER TABLE [dbo].[TicketTagsAssignment] CHECK CONSTRAINT [FK_Tickets_TicketTagsAssignment]
GO
ALTER TABLE [dbo].[TicketTagsAssignment]  WITH CHECK ADD  CONSTRAINT [FK_TicketTags_TicketTagsAssignment] FOREIGN KEY([TagId])
REFERENCES [dbo].[TicketTags] ([Id])
GO
ALTER TABLE [dbo].[TicketTagsAssignment] CHECK CONSTRAINT [FK_TicketTags_TicketTagsAssignment]
GO
USE [master]
GO
ALTER DATABASE [BugTracker] SET  READ_WRITE 
GO
