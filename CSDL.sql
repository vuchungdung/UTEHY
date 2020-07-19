USE [FIT]
GO
/****** Object:  Table [dbo].[CommandInFunctions]    Script Date: 7/19/2020 3:41:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommandInFunctions](
	[CommandId] [nvarchar](50) NOT NULL,
	[FunctionId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CommandInFunctions] PRIMARY KEY CLUSTERED 
(
	[CommandId] ASC,
	[FunctionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Commands]    Script Date: 7/19/2020 3:41:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commands](
	[CommandId] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Commands] PRIMARY KEY CLUSTERED 
(
	[CommandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 7/19/2020 3:41:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[PostId] [nvarchar](128) NULL,
	[ReplyId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [bit] NULL,
	[Email] [nvarchar](100) NULL,
	[UserName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Footers]    Script Date: 7/19/2020 3:41:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Footers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Functions]    Script Date: 7/19/2020 3:41:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Functions](
	[FunctionId] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Url] [nvarchar](200) NULL,
	[SortOrder] [int] NULL,
	[ParentId] [varchar](50) NULL,
	[Icons] [varchar](50) NULL,
 CONSTRAINT [PK_Funtions] PRIMARY KEY CLUSTERED 
(
	[FunctionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupUsers]    Script Date: 7/19/2020 3:41:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupUsers](
	[GroupId] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_GroupUsers] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 7/19/2020 3:41:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[URL] [varchar](256) NULL,
	[DisplayOrder] [int] NULL,
	[Status] [bit] NULL,
	[ParentId] [int] NULL,
	[Content] [nvarchar](max) NULL,
 CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 7/19/2020 3:41:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[FunctionId] [nvarchar](50) NOT NULL,
	[GroupId] [nvarchar](128) NOT NULL,
	[CommandId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[CommandId] ASC,
	[FunctionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostCategorys]    Script Date: 7/19/2020 3:41:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostCategorys](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Alias] [varchar](256) NULL,
	[ParentId] [int] NULL,
 CONSTRAINT [PK_PostCategorys] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 7/19/2020 3:41:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[ID] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Alias] [varchar](256) NULL,
	[CategoryId] [int] NULL,
	[Description] [nvarchar](256) NULL,
	[Content] [nvarchar](max) NULL,
	[HomeFlag] [bit] NULL,
	[ViewCount] [int] NULL,
	[LikeCount] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[Img] [nvarchar](256) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slides]    Script Date: 7/19/2020 3:41:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slides](
	[SlideId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Img] [nvarchar](256) NULL,
	[Url] [nvarchar](256) NULL,
	[DisplayOrder] [int] NULL,
	[Status] [bit] NULL,
	[ImgType] [int] NULL,
 CONSTRAINT [PK_Slides] PRIMARY KEY CLUSTERED 
(
	[SlideId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 7/19/2020 3:41:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[TecherId] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[Fax] [varchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[Position] [nvarchar](50) NULL,
	[WorkPlace] [nchar](10) NULL,
	[WebSite] [nvarchar](80) NULL,
	[Content] [nvarchar](max) NULL,
	[Img] [nvarchar](256) NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[TecherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/19/2020 3:41:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](256) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](max) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Dob] [datetime] NULL,
	[GroupId] [nvarchar](128) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'CREATE', N'CONTENT')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'CREATE', N'CONTENT_CATEGORY')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'CREATE', N'CONTENT_COMMENT')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'CREATE', N'CONTENT_KNOWLEDGEBASE')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'CREATE', N'MORE_SYSTEM')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'CREATE', N'STATISTIC')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'CREATE', N'STATISTIC_MONTHLY_COMMENT')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'CREATE', N'STATISTIC_MONTHLY_NEWKB')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'CREATE', N'SYSTEM')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'CREATE', N'SYSTEM_FUNCTION')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'CREATE', N'SYSTEM_PERMISSION')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'CREATE', N'SYSTEM_ROLE')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'CREATE', N'SYSTEM_USER')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'CREATE', N'TEACHER')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'DELETE', N'CONTENT')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'DELETE', N'CONTENT_CATEGORY')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'DELETE', N'CONTENT_COMMENT')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'DELETE', N'CONTENT_KNOWLEDGEBASE')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'DELETE', N'MORE_SYSTEM')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'DELETE', N'STATISTIC')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'DELETE', N'STATISTIC_MONTHLY_COMMENT')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'DELETE', N'STATISTIC_MONTHLY_NEWKB')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'DELETE', N'SYSTEM')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'DELETE', N'SYSTEM_FUNCTION')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'DELETE', N'SYSTEM_PERMISSION')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'DELETE', N'SYSTEM_ROLE')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'DELETE', N'SYSTEM_USER')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'DELETE', N'TEACHER')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'UPDATE', N'CONTENT')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'UPDATE', N'CONTENT_CATEGORY')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'UPDATE', N'CONTENT_COMMENT')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'UPDATE', N'CONTENT_KNOWLEDGEBASE')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'UPDATE', N'MORE_SYSTEM')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'UPDATE', N'STATISTIC')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'UPDATE', N'STATISTIC_MONTHLY_COMMENT')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'UPDATE', N'STATISTIC_MONTHLY_NEWKB')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'UPDATE', N'SYSTEM')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'UPDATE', N'SYSTEM_FUNCTION')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'UPDATE', N'SYSTEM_PERMISSION')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'UPDATE', N'SYSTEM_ROLE')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'UPDATE', N'SYSTEM_USER')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'UPDATE', N'TEACHER')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'VIEW', N'CONTENT')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'VIEW', N'CONTENT_CATEGORY')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'VIEW', N'CONTENT_COMMENT')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'VIEW', N'CONTENT_KNOWLEDGEBASE')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'VIEW', N'MORE_SYSTEM')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'VIEW', N'STATISTIC')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'VIEW', N'STATISTIC_MONTHLY_COMMENT')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'VIEW', N'STATISTIC_MONTHLY_NEWKB')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'VIEW', N'SYSTEM')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'VIEW', N'SYSTEM_FUNCTION')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'VIEW', N'SYSTEM_PERMISSION')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'VIEW', N'SYSTEM_ROLE')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'VIEW', N'SYSTEM_USER')
INSERT [dbo].[CommandInFunctions] ([CommandId], [FunctionId]) VALUES (N'VIEW', N'TEACHER')
INSERT [dbo].[Commands] ([CommandId], [Name]) VALUES (N'APPROVE', N'Duyệt')
INSERT [dbo].[Commands] ([CommandId], [Name]) VALUES (N'CREATE', N'Thêm')
INSERT [dbo].[Commands] ([CommandId], [Name]) VALUES (N'DELETE', N'Xoá')
INSERT [dbo].[Commands] ([CommandId], [Name]) VALUES (N'UPDATE', N'Sửa')
INSERT [dbo].[Commands] ([CommandId], [Name]) VALUES (N'VIEW', N'Xem')
INSERT [dbo].[Functions] ([FunctionId], [Name], [Url], [SortOrder], [ParentId], [Icons]) VALUES (N'CONTENT', N'QUẢN LÝ NỘI DUNG', N'/Post', 2, NULL, N'far fa-newspaper')
INSERT [dbo].[Functions] ([FunctionId], [Name], [Url], [SortOrder], [ParentId], [Icons]) VALUES (N'CONTENT_CATEGORY', N'DANH MỤC', N'/PostCategory', 0, N'CONTENT', N'fas fa-layer-group')
INSERT [dbo].[Functions] ([FunctionId], [Name], [Url], [SortOrder], [ParentId], [Icons]) VALUES (N'CONTENT_COMMENT', N'BÌNH LUẬN', N'/Comment', 0, N'CONTENT', N'fas fa-comments')
INSERT [dbo].[Functions] ([FunctionId], [Name], [Url], [SortOrder], [ParentId], [Icons]) VALUES (N'CONTENT_KNOWLEDGEBASE', N'BÀI VIẾT', N'/Post', 0, N'CONTENT', N'fas fa-edit')
INSERT [dbo].[Functions] ([FunctionId], [Name], [Url], [SortOrder], [ParentId], [Icons]) VALUES (N'MORE_SYSTEM', N'CHỨC NĂNG KHÁC', N'/More', 4, NULL, N'fas fa-list')
INSERT [dbo].[Functions] ([FunctionId], [Name], [Url], [SortOrder], [ParentId], [Icons]) VALUES (N'STATISTIC', N'THỐNG KÊ', N'/Statistic', 3, NULL, N'fas fa-chart-line')
INSERT [dbo].[Functions] ([FunctionId], [Name], [Url], [SortOrder], [ParentId], [Icons]) VALUES (N'STATISTIC_MONTHLY_COMMENT', N'BÌNH LUẬN (tháng)', N'/Statistic/StatisticComment', 0, N'STATISTIC', N'fas fa-comments')
INSERT [dbo].[Functions] ([FunctionId], [Name], [Url], [SortOrder], [ParentId], [Icons]) VALUES (N'STATISTIC_MONTHLY_NEWKB', N'BÀI ĐĂNG (tháng)', N'/Statistic/StatisticPost', 0, N'STATISTIC', N'fas fa-edit')
INSERT [dbo].[Functions] ([FunctionId], [Name], [Url], [SortOrder], [ParentId], [Icons]) VALUES (N'SYSTEM', N'QUẢN LÝ HỆ THỐNG', N'/User', 1, NULL, N'fas fa-users-cog')
INSERT [dbo].[Functions] ([FunctionId], [Name], [Url], [SortOrder], [ParentId], [Icons]) VALUES (N'SYSTEM_FUNCTION', N'CHỨC NĂNG', N'/Function', 0, N'SYSTEM', N'fas fa-hand-paper')
INSERT [dbo].[Functions] ([FunctionId], [Name], [Url], [SortOrder], [ParentId], [Icons]) VALUES (N'SYSTEM_PERMISSION', N'QUYỀN HẠN', N'/Permission', 0, N'SYSTEM', N'fas fa-user-tag')
INSERT [dbo].[Functions] ([FunctionId], [Name], [Url], [SortOrder], [ParentId], [Icons]) VALUES (N'SYSTEM_ROLE', N'NHÓM QUYỀN', N'/GroupUser', 0, N'SYSTEM', N'fas fa-user-friends')
INSERT [dbo].[Functions] ([FunctionId], [Name], [Url], [SortOrder], [ParentId], [Icons]) VALUES (N'SYSTEM_USER', N'NGƯỜI DÙNG', N'/User', 0, N'SYSTEM', N'fas fa-user-edit')
INSERT [dbo].[Functions] ([FunctionId], [Name], [Url], [SortOrder], [ParentId], [Icons]) VALUES (N'TEACHER', N'GIẢNG VIÊN', N'/Teacher', 0, N'MORE_SYSTEM', N'fas fa-chalkboard-teacher')
INSERT [dbo].[GroupUsers] ([GroupId], [Name]) VALUES (N'Admin', N'Admin')
INSERT [dbo].[GroupUsers] ([GroupId], [Name]) VALUES (N'Editor', N'Editor')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'CONTENT', N'Admin', N'CREATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'CONTENT_CATEGORY', N'Admin', N'CREATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'CONTENT_COMMENT', N'Admin', N'CREATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'CONTENT_KNOWLEDGEBASE', N'Admin', N'CREATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'MORE_SYSTEM', N'Admin', N'CREATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'STATISTIC', N'Admin', N'CREATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'STATISTIC_MONTHLY_COMMENT', N'Admin', N'CREATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'STATISTIC_MONTHLY_NEWKB', N'Admin', N'CREATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM', N'Admin', N'CREATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM_FUNCTION', N'Admin', N'CREATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM_PERMISSION', N'Admin', N'CREATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM_ROLE', N'Admin', N'CREATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM_USER', N'Admin', N'CREATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'TEACHER', N'Admin', N'CREATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'CONTENT', N'Admin', N'DELETE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'CONTENT_CATEGORY', N'Admin', N'DELETE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'CONTENT_COMMENT', N'Admin', N'DELETE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'CONTENT_KNOWLEDGEBASE', N'Admin', N'DELETE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'MORE_SYSTEM', N'Admin', N'DELETE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'STATISTIC', N'Admin', N'DELETE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'STATISTIC_MONTHLY_COMMENT', N'Admin', N'DELETE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'STATISTIC_MONTHLY_NEWKB', N'Admin', N'DELETE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM', N'Admin', N'DELETE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM_FUNCTION', N'Admin', N'DELETE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM_PERMISSION', N'Admin', N'DELETE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM_ROLE', N'Admin', N'DELETE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM_USER', N'Admin', N'DELETE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'TEACHER', N'Admin', N'DELETE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'CONTENT', N'Admin', N'UPDATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'CONTENT_CATEGORY', N'Admin', N'UPDATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'CONTENT_COMMENT', N'Admin', N'UPDATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'CONTENT_KNOWLEDGEBASE', N'Admin', N'UPDATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'MORE_SYSTEM', N'Admin', N'UPDATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'STATISTIC', N'Admin', N'UPDATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'STATISTIC_MONTHLY_COMMENT', N'Admin', N'UPDATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'STATISTIC_MONTHLY_NEWKB', N'Admin', N'UPDATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM', N'Admin', N'UPDATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM_FUNCTION', N'Admin', N'UPDATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM_PERMISSION', N'Admin', N'UPDATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM_ROLE', N'Admin', N'UPDATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM_USER', N'Admin', N'UPDATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'TEACHER', N'Admin', N'UPDATE')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'CONTENT', N'Admin', N'VIEW')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'CONTENT_CATEGORY', N'Admin', N'VIEW')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'CONTENT_COMMENT', N'Admin', N'VIEW')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'CONTENT_KNOWLEDGEBASE', N'Admin', N'VIEW')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'MORE_SYSTEM', N'Admin', N'VIEW')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'STATISTIC', N'Admin', N'VIEW')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'STATISTIC_MONTHLY_COMMENT', N'Admin', N'VIEW')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'STATISTIC_MONTHLY_NEWKB', N'Admin', N'VIEW')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM', N'Admin', N'VIEW')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM_FUNCTION', N'Admin', N'VIEW')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM_PERMISSION', N'Admin', N'VIEW')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM_ROLE', N'Admin', N'VIEW')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'SYSTEM_USER', N'Admin', N'VIEW')
INSERT [dbo].[Permissions] ([FunctionId], [GroupId], [CommandId]) VALUES (N'TEACHER', N'Admin', N'VIEW')
INSERT [dbo].[Users] ([UserId], [Name], [Email], [PhoneNumber], [Address], [UserName], [Password], [FirstName], [LastName], [Dob], [GroupId]) VALUES (N'331831D6-6948-42D0-80FA-DC7E375A9D47', N'Vũ Chung Dũng', N'vuchungdung@gmail.com', N'0987654321', N'Yên Mỹ', N'admin', N'admin@123', N'Dũng', N'Vũ', CAST(N'2000-02-20T00:00:00.000' AS DateTime), N'Admin')
ALTER TABLE [dbo].[CommandInFunctions]  WITH CHECK ADD  CONSTRAINT [FK_CommandInFunctions_Commands] FOREIGN KEY([CommandId])
REFERENCES [dbo].[Commands] ([CommandId])
GO
ALTER TABLE [dbo].[CommandInFunctions] CHECK CONSTRAINT [FK_CommandInFunctions_Commands]
GO
ALTER TABLE [dbo].[CommandInFunctions]  WITH CHECK ADD  CONSTRAINT [FK_CommandInFunctions_Funtions] FOREIGN KEY([FunctionId])
REFERENCES [dbo].[Functions] ([FunctionId])
GO
ALTER TABLE [dbo].[CommandInFunctions] CHECK CONSTRAINT [FK_CommandInFunctions_Funtions]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Posts] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([ID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Posts]
GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_Commands] FOREIGN KEY([CommandId])
REFERENCES [dbo].[Commands] ([CommandId])
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_Commands]
GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_Funtions] FOREIGN KEY([FunctionId])
REFERENCES [dbo].[Functions] ([FunctionId])
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_Funtions]
GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_GroupUsers] FOREIGN KEY([GroupId])
REFERENCES [dbo].[GroupUsers] ([GroupId])
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_GroupUsers]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_PostCategorys] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[PostCategorys] ([ID])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_PostCategorys]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_GroupUsers] FOREIGN KEY([GroupId])
REFERENCES [dbo].[GroupUsers] ([GroupId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_GroupUsers]
GO
