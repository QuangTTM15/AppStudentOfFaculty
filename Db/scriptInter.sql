
USE [DBHungQuangBaoInter]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/21/2024 5:18:56 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contribution]    Script Date: 4/21/2024 5:18:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contribution](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[UserId] [bigint] NOT NULL,
	[TypeFile] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[IsPublished] [bit] NOT NULL,
 CONSTRAINT [PK_Contribution] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContributionComment]    Script Date: 4/21/2024 5:18:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContributionComment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[ContributionId] [bigint] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_ContributionComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 4/21/2024 5:18:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[FacultyId] [bigint] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 4/21/2024 5:18:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[CoordinatorId] [bigint] NOT NULL,
 CONSTRAINT [PK_Faculty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 4/21/2024 5:18:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/21/2024 5:18:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[Avartar] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[Gender] [int] NOT NULL,
	[Level] [int] NOT NULL,
	[IsSupperAdmin] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[FacultyId] [bigint] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 4/21/2024 5:18:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedBy] [bigint] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240410071452_InnitDB', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240411043549_addColumnUserId', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240412040648_addColumnFaculty', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240421094455_AddColumnIsPublished', N'5.0.0')
GO
SET IDENTITY_INSERT [dbo].[Contribution] ON 

INSERT [dbo].[Contribution] ([Id], [FileName], [UserId], [TypeFile], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [IsPublished]) VALUES (1, N'a188ce6b-7893-49b3-a071-cfc679fc8528-434240548_406697642308605_207880604967199007_n.jpg', 5, 0, CAST(N'2024-04-11T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 5, 5, 0, 0, 1)
INSERT [dbo].[Contribution] ([Id], [FileName], [UserId], [TypeFile], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [IsPublished]) VALUES (2, N'3f80f4a5-ecb9-4305-b50b-50ad6e58e16a-toyota.jpg', 5, 0, CAST(N'2024-04-12T10:31:22.7893292' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 5, 5, 0, 0, 1)
INSERT [dbo].[Contribution] ([Id], [FileName], [UserId], [TypeFile], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [IsPublished]) VALUES (3, N'f06c0631-4148-4919-be4c-e8b638173820-Template_12.04.2024 (2).xlsx', 5, 0, CAST(N'2024-04-21T16:13:21.6044155' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 5, 5, 0, 0, 1)
INSERT [dbo].[Contribution] ([Id], [FileName], [UserId], [TypeFile], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [IsPublished]) VALUES (5, N'66633a76-96d7-4c77-963f-b18019ffbc3f-Coursework-2024.xlsx', 5, 0, CAST(N'2024-04-21T16:20:57.0747106' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 5, 5, 0, 0, 1)
INSERT [dbo].[Contribution] ([Id], [FileName], [UserId], [TypeFile], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [IsPublished]) VALUES (6, N'017a562e-8e60-4443-ac34-6eca48b6c10c-3f80f4a5-ecb9-4305-b50b-50ad6e58e16a-toyota.jpg', 5, 0, CAST(N'2024-04-21T16:22:13.9314282' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 5, 5, 0, 0, 1)
SET IDENTITY_INSERT [dbo].[Contribution] OFF
GO
SET IDENTITY_INSERT [dbo].[ContributionComment] ON 

INSERT [dbo].[ContributionComment] ([Id], [Content], [ContributionId], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (1, N'hehe', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 5, 5, 0, 0)
INSERT [dbo].[ContributionComment] ([Id], [Content], [ContributionId], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (2, N'hahaa', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 5, 5, 0, 0)
INSERT [dbo].[ContributionComment] ([Id], [Content], [ContributionId], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (3, N'huhu', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 5, 5, 0, 0)
INSERT [dbo].[ContributionComment] ([Id], [Content], [ContributionId], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (4, N'Hung Hoàng cảm thấy không thích', 1, CAST(N'2024-04-21T16:11:47.8323725' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 5, 5, 0, 0)
SET IDENTITY_INSERT [dbo].[ContributionComment] OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [Name], [FacultyId], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (1, N'IT', 1, CAST(N'2024-04-10T16:26:13.2066413' AS DateTime2), CAST(N'2024-04-10T16:26:13.2066439' AS DateTime2), 0, 1, 1, 0)
INSERT [dbo].[Department] ([Id], [Name], [FacultyId], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (2, N'IT Ecommerce', 1, CAST(N'2024-04-10T16:26:45.7492547' AS DateTime2), CAST(N'2024-04-10T16:26:45.7492558' AS DateTime2), 0, 1, 1, 0)
INSERT [dbo].[Department] ([Id], [Name], [FacultyId], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (3, N'Accouting', 2, CAST(N'2024-04-10T16:27:07.6823407' AS DateTime2), CAST(N'2024-04-10T16:27:07.6823419' AS DateTime2), 0, 1, 1, 0)
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Faculty] ON 

INSERT [dbo].[Faculty] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [CoordinatorId]) VALUES (1, N'Information System', CAST(N'2024-04-21T15:57:10.7906517' AS DateTime2), CAST(N'2024-04-21T15:57:10.7906536' AS DateTime2), 0, 1, 1, 0, 4)
INSERT [dbo].[Faculty] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [CoordinatorId]) VALUES (2, N'Accounting', CAST(N'2024-04-10T16:18:57.9703193' AS DateTime2), CAST(N'2024-04-10T16:18:57.9703224' AS DateTime2), 0, 1, 1, 0, 4)
INSERT [dbo].[Faculty] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [CoordinatorId]) VALUES (3, N'HR', CAST(N'2024-04-10T16:19:11.0907681' AS DateTime2), CAST(N'2024-04-10T16:19:11.0907717' AS DateTime2), 0, 1, 1, 0, 4)
INSERT [dbo].[Faculty] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [CoordinatorId]) VALUES (4, N'Electronic', CAST(N'2024-04-10T16:20:11.5288935' AS DateTime2), CAST(N'2024-04-10T16:20:11.5288978' AS DateTime2), 0, 1, 1, 0, 4)
INSERT [dbo].[Faculty] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [CoordinatorId]) VALUES (5, N'Kinh tế', CAST(N'2024-04-21T15:49:45.1147958' AS DateTime2), CAST(N'2024-04-21T15:49:45.1147976' AS DateTime2), 0, 1, 1, 0, 4)
INSERT [dbo].[Faculty] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [CoordinatorId]) VALUES (6, N'Phổ Thông', CAST(N'2024-04-21T15:57:14.0377571' AS DateTime2), CAST(N'2024-04-21T15:57:14.0377586' AS DateTime2), 0, 1, 1, 1, 4)
SET IDENTITY_INSERT [dbo].[Faculty] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (1, N'Administrator', CAST(N'2024-04-21T16:44:54.7757161' AS DateTime2), CAST(N'2024-04-21T16:44:54.7757182' AS DateTime2), 1, NULL, 1, 0)
INSERT [dbo].[Role] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (2, N'Manager', CAST(N'2024-04-21T16:44:54.7757668' AS DateTime2), CAST(N'2024-04-21T16:44:54.7757669' AS DateTime2), 1, NULL, 1, 0)
INSERT [dbo].[Role] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (3, N'Coordinator', CAST(N'2024-04-21T16:44:54.7757671' AS DateTime2), CAST(N'2024-04-21T16:44:54.7757672' AS DateTime2), 1, NULL, 1, 0)
INSERT [dbo].[Role] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (4, N'Student', CAST(N'2024-04-21T16:44:54.7757673' AS DateTime2), CAST(N'2024-04-21T16:44:54.7757674' AS DateTime2), 1, NULL, 1, 0)
INSERT [dbo].[Role] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (5, N'Guest', CAST(N'2024-04-21T16:44:54.7757675' AS DateTime2), CAST(N'2024-04-21T16:44:54.7757676' AS DateTime2), 1, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Email], [Password], [Phone], [FullName], [Avartar], [Address], [DateOfBirth], [Gender], [Level], [IsSupperAdmin], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [FacultyId]) VALUES (1, N'admin@gmail.com', N'123', N'099999999', N'admin@gmail.com', NULL, NULL, NULL, 0, 0, 1, CAST(N'2024-04-21T16:44:54.7741517' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, NULL, 1, 0, 1)
INSERT [dbo].[User] ([Id], [Email], [Password], [Phone], [FullName], [Avartar], [Address], [DateOfBirth], [Gender], [Level], [IsSupperAdmin], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [FacultyId]) VALUES (2, N'Guest1@gmail.com', N'123456', N'0987654321', N'Guest1', N'', N'HCM', CAST(N'2024-04-17T00:00:00.0000000' AS DateTime2), 1, 0, 0, CAST(N'2024-04-11T09:56:24.5540179' AS DateTime2), CAST(N'2024-04-11T09:56:24.5540204' AS DateTime2), 0, NULL, 1, 0, 1)
INSERT [dbo].[User] ([Id], [Email], [Password], [Phone], [FullName], [Avartar], [Address], [DateOfBirth], [Gender], [Level], [IsSupperAdmin], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [FacultyId]) VALUES (3, N'manager1@gmail.com', N'123456', N'987654321', N'manager1', N'', N'HCM', CAST(N'2024-04-11T00:00:00.0000000' AS DateTime2), 1, 0, 0, CAST(N'2024-04-11T09:57:00.9565825' AS DateTime2), CAST(N'2024-04-11T09:57:00.9565867' AS DateTime2), 0, NULL, 1, 0, 1)
INSERT [dbo].[User] ([Id], [Email], [Password], [Phone], [FullName], [Avartar], [Address], [DateOfBirth], [Gender], [Level], [IsSupperAdmin], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [FacultyId]) VALUES (4, N'minhhung2802@gmail.com', N'123456', N'0987654321', N'coordinator1', N'', N'HCM', CAST(N'2024-04-11T00:00:00.0000000' AS DateTime2), 1, 0, 0, CAST(N'2024-04-21T16:10:20.9482009' AS DateTime2), CAST(N'2024-04-21T16:10:20.9482026' AS DateTime2), 0, 1, 1, 0, 1)
INSERT [dbo].[User] ([Id], [Email], [Password], [Phone], [FullName], [Avartar], [Address], [DateOfBirth], [Gender], [Level], [IsSupperAdmin], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [FacultyId]) VALUES (5, N'student1@gmail.com', N'123456', N'0987654321', N'student1', N'', N'HCM', CAST(N'2024-04-11T00:00:00.0000000' AS DateTime2), 1, 0, 0, CAST(N'2024-04-11T09:58:10.2964088' AS DateTime2), CAST(N'2024-04-11T09:58:10.2964099' AS DateTime2), 0, NULL, 1, 0, 1)
INSERT [dbo].[User] ([Id], [Email], [Password], [Phone], [FullName], [Avartar], [Address], [DateOfBirth], [Gender], [Level], [IsSupperAdmin], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [FacultyId]) VALUES (6, N'minhhung2802@gmail.com', N'123456', N'098765432', N'HungHoang1', N'', N'HCM', CAST(N'2024-04-17T00:00:00.0000000' AS DateTime2), 1, 0, 0, CAST(N'2024-04-21T16:03:08.2455589' AS DateTime2), CAST(N'2024-04-21T16:03:08.2455632' AS DateTime2), 1, NULL, 1, 0, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (1, 1, 1, CAST(N'2024-04-21T16:44:54.7757973' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, NULL, 1, 0)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (2, 5, 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, NULL, 0, 0)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (3, 2, 3, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, NULL, 0, 0)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (4, 3, 4, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, 1, 0, 0)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (5, 4, 5, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, NULL, 0, 0)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (6, 1, 6, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
ALTER TABLE [dbo].[Contribution] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsPublished]
GO
ALTER TABLE [dbo].[Faculty] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [CoordinatorId]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [FacultyId]
GO
USE [master]
GO
ALTER DATABASE [DBHungHoangInter] SET  READ_WRITE 
GO
