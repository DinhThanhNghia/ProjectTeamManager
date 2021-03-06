USE [master]
GO
/****** Object:  Database [DBGroup1]    Script Date: 10/10/2018 12:02:25 PM ******/
CREATE DATABASE [DBGroup1]
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBGroup1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBGroup1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBGroup1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBGroup1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBGroup1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBGroup1] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBGroup1] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DBGroup1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBGroup1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBGroup1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBGroup1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBGroup1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBGroup1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBGroup1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBGroup1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBGroup1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBGroup1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBGroup1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBGroup1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBGroup1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBGroup1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBGroup1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBGroup1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBGroup1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBGroup1] SET  MULTI_USER 
GO
ALTER DATABASE [DBGroup1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBGroup1] SET DB_CHAINING OFF 
GO
USE [DBGroup1]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 10/10/2018 12:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[ContactNo] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Skills] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[InsAt] [datetime] NOT NULL,
	[InsBy] [nvarchar](50) NOT NULL,
	[UpdAt] [datetime] NOT NULL,
	[UpdBy] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManagerComment]    Script Date: 10/10/2018 12:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagerComment](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[ProjectTaskId] [uniqueidentifier] NOT NULL,
	[Comments] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[InsAt] [datetime] NOT NULL,
	[InsBy] [nvarchar](50) NOT NULL,
	[UpdAt] [datetime] NOT NULL,
	[UpdBy] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 10/10/2018 12:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[ClientName] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[InsAt] [datetime] NOT NULL,
	[InsBy] [nvarchar](50) NOT NULL,
	[UpdAt] [datetime] NOT NULL,
	[UpdBy] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectTask]    Script Date: 10/10/2018 12:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTask](
	[Id] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[TaskStartDate] [datetime] NOT NULL,
	[TaskEndDate] [datetime] NOT NULL,
	[TaskStatusId] [uniqueidentifier] NOT NULL,
	[UserStoryId] [uniqueidentifier] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[InsAt] [datetime] NOT NULL,
	[InsBy] [nvarchar](50) NOT NULL,
	[UpdAt] [datetime] NOT NULL,
	[UpdBy] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskStatus]    Script Date: 10/10/2018 12:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskStatus](
	[Id] [uniqueidentifier] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[InsAt] [datetime] NOT NULL,
	[InsBy] [nvarchar](50) NOT NULL,
	[UpdAt] [datetime] NOT NULL,
	[UpdBy] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserStory]    Script Date: 10/10/2018 12:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserStory](
	[Id] [uniqueidentifier] NOT NULL,
	[Story] [nvarchar](max) NOT NULL,
	[ProjectId] [uniqueidentifier] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[InsAt] [datetime] NOT NULL,
	[InsBy] [nvarchar](50) NOT NULL,
	[UpdAt] [datetime] NOT NULL,
	[UpdBy] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [ContactNo], [Email], [Skills], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'358b445b-abd6-4758-b342-2ced3a0c9a8c', N'Phạm Văn', N'Hưng', N'0271234789', N'hung@gmail.com', N'Back-End(PHP, ASP.NET, RUBY)', 0, CAST(N'2018-10-10T11:08:49.023' AS DateTime), N'Admin', CAST(N'2018-10-10T11:08:49.023' AS DateTime), N'Admin')
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [ContactNo], [Email], [Skills], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'8bd63d01-4929-4486-83ba-88bffd4701ce', N'Nguyễn Văn', N'Ngọc', N'0237513465', N'ngoc@gmail.com', N'Front-End(UI, UX)', 0, CAST(N'2018-10-10T11:08:06.897' AS DateTime), N'Admin', CAST(N'2018-10-10T11:08:06.897' AS DateTime), N'Admin')
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [ContactNo], [Email], [Skills], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'1492907f-ca1f-45c9-b55d-90a789130efd', N'Trần Hữu', N'Hùng', N'0894523789', N'hung@gmail.com', N'ReacJs, VueJs, AngularJs, AjaxJs', 0, CAST(N'2018-10-10T11:10:31.047' AS DateTime), N'Admin', CAST(N'2018-10-10T11:10:31.047' AS DateTime), N'Admin')
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [ContactNo], [Email], [Skills], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'20e817ee-82ef-47a0-b993-d72b4792fc98', N'Bùi Thế', N'Toàn', N'0935423789', N'toan@gmail.com', N'NodeJS, HelpDesk', 0, CAST(N'2018-10-10T11:11:18.190' AS DateTime), N'Admin', CAST(N'2018-10-10T11:11:18.190' AS DateTime), N'Admin')
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [ContactNo], [Email], [Skills], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'4f085eb1-7b2a-4885-a43b-d88da400cc0c', N'Lê Văn', N'Quang', N'0894234791', N'quang@gmail.com', N'Tester', 0, CAST(N'2018-10-10T11:09:34.190' AS DateTime), N'Admin', CAST(N'2018-10-10T11:09:34.190' AS DateTime), N'Admin')
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [ContactNo], [Email], [Skills], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'a30fb372-60b5-4bf4-837a-e1749c786f08', N'Lê Văn', N'Luyện', N'0237567984', N'luyen@gmai.com', N'Team Leader', 0, CAST(N'2018-10-10T11:07:25.890' AS DateTime), N'Admin', CAST(N'2018-10-10T11:07:25.890' AS DateTime), N'Admin')
INSERT [dbo].[ManagerComment] ([Id], [FirstName], [LastName], [ProjectTaskId], [Comments], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'24efd576-5cc8-4bd8-b852-28bc10587f6e', N'Trần Thanh', N'Phúc', N'a4cf8699-9453-41ef-b3de-fd2498af43ca', N'Hoàn thành nhiệm vụ', 0, CAST(N'2018-10-10T12:00:04.163' AS DateTime), N'Admin', CAST(N'2018-10-10T12:00:04.163' AS DateTime), N'Admin')
INSERT [dbo].[ManagerComment] ([Id], [FirstName], [LastName], [ProjectTaskId], [Comments], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'bd3e064a-545c-4396-9480-5ddfa5623360', N'Trần Thanh', N'Phúc', N'03283383-1d8e-4605-877f-2ad6a8100fa5', N'Làm việc chậm. Tìm hiểu chậm
', 0, CAST(N'2018-10-10T11:52:15.300' AS DateTime), N'Admin', CAST(N'2018-10-10T11:52:15.300' AS DateTime), N'Admin')
INSERT [dbo].[ManagerComment] ([Id], [FirstName], [LastName], [ProjectTaskId], [Comments], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'17b6e4c6-296f-4293-872e-6a7522f53a4a', N'Trần Thanh', N'Phúc', N'8ed7f94c-e3cc-4cd8-b053-1e5cb6fe177a', N'Thái độ tốt', 0, CAST(N'2018-10-10T11:51:45.593' AS DateTime), N'Admin', CAST(N'2018-10-10T11:51:45.593' AS DateTime), N'Admin')
INSERT [dbo].[ManagerComment] ([Id], [FirstName], [LastName], [ProjectTaskId], [Comments], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'f0d25c0b-4923-4378-b604-78320f5f78d6', N'Trần Thanh', N'Phúc', N'3eb81203-a758-4c1c-b45c-74c5565ca6c8', N'Cần cải thiện tiếng Anh', 0, CAST(N'2018-10-10T11:52:48.200' AS DateTime), N'Admin', CAST(N'2018-10-10T11:52:48.200' AS DateTime), N'Admin')
INSERT [dbo].[ManagerComment] ([Id], [FirstName], [LastName], [ProjectTaskId], [Comments], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'b34c5383-6b1d-4268-94b3-cf0599164c2b', N'Trần Thanh', N'Phúc', N'274dc013-c77d-483c-b0cc-ff6048538bdb', N'Mất tập trung khi làm việc', 0, CAST(N'2018-10-10T12:00:26.867' AS DateTime), N'Admin', CAST(N'2018-10-10T12:00:26.867' AS DateTime), N'Admin')
INSERT [dbo].[ManagerComment] ([Id], [FirstName], [LastName], [ProjectTaskId], [Comments], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'c1ca75e1-3ca4-4588-a1af-e14e8796e6d4', N'Trần Thanh', N'Phúc', N'c9ccf278-9c10-4c7b-bb6e-a9d23ed2514a', N'Không hợp tác', 0, CAST(N'2018-10-10T11:53:10.617' AS DateTime), N'Admin', CAST(N'2018-10-10T11:53:10.617' AS DateTime), N'Admin')
INSERT [dbo].[Project] ([Id], [Name], [StartDate], [EndDate], [ClientName], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'739eee48-08da-4c35-8648-6ddb6116ee9c', N'Hệ thống quản lý đào tạo', CAST(N'2018-10-05T00:00:00.000' AS DateTime), CAST(N'2019-01-05T00:00:00.000' AS DateTime), N'Client UDA', 0, CAST(N'2018-10-10T11:16:09.770' AS DateTime), N'Admin', CAST(N'2018-10-10T11:16:09.770' AS DateTime), N'Admin')
INSERT [dbo].[Project] ([Id], [Name], [StartDate], [EndDate], [ClientName], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'60903c77-d48a-4975-a08e-735bf1a9f99f', N'Quản lý nhân sự', CAST(N'2018-10-05T00:00:00.000' AS DateTime), CAST(N'2018-11-05T00:00:00.000' AS DateTime), N'Client UDA', 0, CAST(N'2018-10-10T11:14:05.460' AS DateTime), N'Admin', CAST(N'2018-10-10T11:14:05.460' AS DateTime), N'Admin')
INSERT [dbo].[Project] ([Id], [Name], [StartDate], [EndDate], [ClientName], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'1156a4a8-9dfb-46ed-86ab-b4b87b9ff38a', N'Quản lý thư viện', CAST(N'2018-10-05T00:00:00.000' AS DateTime), CAST(N'2018-11-05T00:00:00.000' AS DateTime), N'Client UDA', 0, CAST(N'2018-10-10T11:14:22.757' AS DateTime), N'Admin', CAST(N'2018-10-10T11:14:22.757' AS DateTime), N'Admin')
INSERT [dbo].[Project] ([Id], [Name], [StartDate], [EndDate], [ClientName], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'614bedcf-a554-4dac-92ff-d90f85f91514', N'Quản lý bán hàng', CAST(N'2018-10-05T00:00:00.000' AS DateTime), CAST(N'2018-11-05T00:00:00.000' AS DateTime), N'Client UDA', 0, CAST(N'2018-10-10T11:13:45.520' AS DateTime), N'Admin', CAST(N'2018-10-10T11:13:45.520' AS DateTime), N'Admin')
INSERT [dbo].[Project] ([Id], [Name], [StartDate], [EndDate], [ClientName], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'a62edca0-adab-4d02-aa52-f3e43c8f11e6', N'OnlineQuiz', CAST(N'2018-10-05T00:00:00.000' AS DateTime), CAST(N'2018-11-05T00:00:00.000' AS DateTime), N'Client UDA', 0, CAST(N'2018-10-10T11:15:17.553' AS DateTime), N'Admin', CAST(N'2018-10-10T11:15:17.553' AS DateTime), N'Admin')
INSERT [dbo].[ProjectTask] ([Id], [EmployeeId], [TaskStartDate], [TaskEndDate], [TaskStatusId], [UserStoryId], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'8ed7f94c-e3cc-4cd8-b053-1e5cb6fe177a', N'20e817ee-82ef-47a0-b993-d72b4792fc98', CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-25T00:00:00.000' AS DateTime), N'5b90fcc0-41d0-4437-8fdf-0eaac7fcdcac', N'5f6faf62-f4c8-4690-9ffa-1c46b2ca8dd3', 0, CAST(N'2018-10-10T11:49:51.890' AS DateTime), N'Admin', CAST(N'2018-10-10T11:49:51.890' AS DateTime), N'Admin')
INSERT [dbo].[ProjectTask] ([Id], [EmployeeId], [TaskStartDate], [TaskEndDate], [TaskStatusId], [UserStoryId], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'03283383-1d8e-4605-877f-2ad6a8100fa5', N'a30fb372-60b5-4bf4-837a-e1749c786f08', CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-25T00:00:00.000' AS DateTime), N'5b90fcc0-41d0-4437-8fdf-0eaac7fcdcac', N'5f6faf62-f4c8-4690-9ffa-1c46b2ca8dd3', 0, CAST(N'2018-10-10T11:51:00.210' AS DateTime), N'Admin', CAST(N'2018-10-10T11:51:00.210' AS DateTime), N'Admin')
INSERT [dbo].[ProjectTask] ([Id], [EmployeeId], [TaskStartDate], [TaskEndDate], [TaskStatusId], [UserStoryId], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'3eb81203-a758-4c1c-b45c-74c5565ca6c8', N'4f085eb1-7b2a-4885-a43b-d88da400cc0c', CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-25T00:00:00.000' AS DateTime), N'ed19792d-f93d-4550-afe3-3c0ffbf277e8', N'5f6faf62-f4c8-4690-9ffa-1c46b2ca8dd3', 0, CAST(N'2018-10-10T11:50:02.183' AS DateTime), N'Admin', CAST(N'2018-10-10T11:50:02.183' AS DateTime), N'Admin')
INSERT [dbo].[ProjectTask] ([Id], [EmployeeId], [TaskStartDate], [TaskEndDate], [TaskStatusId], [UserStoryId], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'c9ccf278-9c10-4c7b-bb6e-a9d23ed2514a', N'358b445b-abd6-4758-b342-2ced3a0c9a8c', CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-25T00:00:00.000' AS DateTime), N'5b90fcc0-41d0-4437-8fdf-0eaac7fcdcac', N'5f6faf62-f4c8-4690-9ffa-1c46b2ca8dd3', 0, CAST(N'2018-10-10T11:48:24.930' AS DateTime), N'Admin', CAST(N'2018-10-10T11:48:24.930' AS DateTime), N'Admin')
INSERT [dbo].[ProjectTask] ([Id], [EmployeeId], [TaskStartDate], [TaskEndDate], [TaskStatusId], [UserStoryId], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'a4cf8699-9453-41ef-b3de-fd2498af43ca', N'8bd63d01-4929-4486-83ba-88bffd4701ce', CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-25T00:00:00.000' AS DateTime), N'ed19792d-f93d-4550-afe3-3c0ffbf277e8', N'5f6faf62-f4c8-4690-9ffa-1c46b2ca8dd3', 0, CAST(N'2018-10-10T11:49:25.033' AS DateTime), N'Admin', CAST(N'2018-10-10T11:49:25.033' AS DateTime), N'Admin')
INSERT [dbo].[ProjectTask] ([Id], [EmployeeId], [TaskStartDate], [TaskEndDate], [TaskStatusId], [UserStoryId], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'274dc013-c77d-483c-b0cc-ff6048538bdb', N'1492907f-ca1f-45c9-b55d-90a789130efd', CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-25T00:00:00.000' AS DateTime), N'5b90fcc0-41d0-4437-8fdf-0eaac7fcdcac', N'5f6faf62-f4c8-4690-9ffa-1c46b2ca8dd3', 0, CAST(N'2018-10-10T11:49:38.650' AS DateTime), N'Admin', CAST(N'2018-10-10T11:49:38.650' AS DateTime), N'Admin')
INSERT [dbo].[TaskStatus] ([Id], [Status], [Description], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'f86d5912-0df9-41b9-8216-06dfea2435dd', N'Cháy dự án', N'Không kịp deathline', 0, CAST(N'2018-10-10T11:33:02.193' AS DateTime), N'Admin', CAST(N'2018-10-10T11:33:02.193' AS DateTime), N'Admin')
INSERT [dbo].[TaskStatus] ([Id], [Status], [Description], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'5b90fcc0-41d0-4437-8fdf-0eaac7fcdcac', N'Hoàn thành', N'Kịp tiến độ công việc', 0, CAST(N'2018-10-10T11:32:36.343' AS DateTime), N'Admin', CAST(N'2018-10-10T11:32:36.343' AS DateTime), N'Admin')
INSERT [dbo].[TaskStatus] ([Id], [Status], [Description], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'ed19792d-f93d-4550-afe3-3c0ffbf277e8', N'Chưa hoàn thành', N'Không kịp tiến độ công việc', 0, CAST(N'2018-10-10T11:32:23.753' AS DateTime), N'Admin', CAST(N'2018-10-10T11:32:23.753' AS DateTime), N'Admin')
INSERT [dbo].[UserStory] ([Id], [Story], [ProjectId], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'5f6faf62-f4c8-4690-9ffa-1c46b2ca8dd3', N'Quản lý chức vụ, mức lương, chấm công thông qua hệ thống vân tay,...', N'60903c77-d48a-4975-a08e-735bf1a9f99f', 0, CAST(N'2018-10-10T11:28:19.020' AS DateTime), N'Admin', CAST(N'2018-10-10T11:28:19.020' AS DateTime), N'Admin')
INSERT [dbo].[UserStory] ([Id], [Story], [ProjectId], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'0cdd9325-7ca2-4a3e-946d-1f5cd3cba157', N'Quản lý các mặt hàng. Mua bán hàng online.', N'614bedcf-a554-4dac-92ff-d90f85f91514', 0, CAST(N'2018-10-10T11:29:42.937' AS DateTime), N'Admin', CAST(N'2018-10-10T11:29:42.937' AS DateTime), N'Admin')
INSERT [dbo].[UserStory] ([Id], [Story], [ProjectId], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'a7f9322f-283b-4381-bb76-247f930d638e', N'Quản lý, phân loại các loại sách, mượn trả sách. Nhập xuất các loại sách', N'1156a4a8-9dfb-46ed-86ab-b4b87b9ff38a', 0, CAST(N'2018-10-10T11:29:07.577' AS DateTime), N'Admin', CAST(N'2018-10-10T11:29:07.577' AS DateTime), N'Admin')
INSERT [dbo].[UserStory] ([Id], [Story], [ProjectId], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'b4dd1fbe-4272-40a9-abf8-6239ab4ed277', N'Hệ thống thi trắc nghiệm online. Được áp dụng cho các môn thi trắc nghiệm tại trường Đại Học Đông Á.', N'a62edca0-adab-4d02-aa52-f3e43c8f11e6', 0, CAST(N'2018-10-10T11:30:18.293' AS DateTime), N'Admin', CAST(N'2018-10-10T11:30:18.293' AS DateTime), N'Admin')
INSERT [dbo].[UserStory] ([Id], [Story], [ProjectId], [IsDeleted], [InsAt], [InsBy], [UpdAt], [UpdBy]) VALUES (N'04be289c-06bf-481f-9e7f-a98935380b95', N'Quản lý đào tạo cho trường Đại Học Đông Á bao gồm(Đăng ký học phần, xem thời khóa biểu, xem kết quả học tập, điểm rèn luyện, ngoại trú...).
', N'739eee48-08da-4c35-8648-6ddb6116ee9c', 0, CAST(N'2018-10-10T11:27:21.000' AS DateTime), N'Admin', CAST(N'2018-10-10T11:30:32.213' AS DateTime), N'Admin')
ALTER TABLE [dbo].[ManagerComment]  WITH CHECK ADD FOREIGN KEY([ProjectTaskId])
REFERENCES [dbo].[ProjectTask] ([Id])
GO
ALTER TABLE [dbo].[ProjectTask]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[ProjectTask]  WITH CHECK ADD FOREIGN KEY([TaskStatusId])
REFERENCES [dbo].[TaskStatus] ([Id])
GO
ALTER TABLE [dbo].[ProjectTask]  WITH CHECK ADD FOREIGN KEY([UserStoryId])
REFERENCES [dbo].[UserStory] ([Id])
GO
ALTER TABLE [dbo].[UserStory]  WITH CHECK ADD FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
USE [master]
GO
ALTER DATABASE [DBGroup1] SET  READ_WRITE 
GO
