USE [master]
GO
/****** Object:  Database [TestServer]    Script Date: 08/02/2015 00:01:49 ******/
CREATE DATABASE [TestServer]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestServer', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\TestServer.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestServer_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\TestServer_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TestServer] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestServer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestServer] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestServer] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestServer] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestServer] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestServer] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestServer] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestServer] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TestServer] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestServer] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestServer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestServer] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestServer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestServer] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestServer] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestServer] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestServer] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestServer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestServer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestServer] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestServer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestServer] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestServer] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestServer] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestServer] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TestServer] SET  MULTI_USER 
GO
ALTER DATABASE [TestServer] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestServer] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestServer] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestServer] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [TestServer]
GO
/****** Object:  User [aTestServer]    Script Date: 08/02/2015 00:01:49 ******/
CREATE USER [aTestServer] FOR LOGIN [aTestServer] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [aTestServer]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [aTestServer]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 08/02/2015 00:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[pkAdmin_ID] [int] NOT NULL,
	[Admin_First_Name] [nvarchar](200) NOT NULL,
	[Admin_Last_Name] [nvarchar](200) NOT NULL,
	[Admin_Email] [nvarchar](200) NOT NULL,
	[Admin_Password] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[pkAdmin_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Answer]    Script Date: 08/02/2015 00:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[pkAnswer_ID] [int] IDENTITY(1,1) NOT NULL,
	[Answer_Name] [nvarchar](200) NOT NULL,
	[Answer_Description] [nvarchar](4000) NULL,
	[Answer_Order] [int] NOT NULL,
	[Answer_Correct] [bit] NOT NULL,
	[fkQuestion_ID] [int] NOT NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[pkAnswer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Exam]    Script Date: 08/02/2015 00:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam](
	[pkExam_ID] [int] IDENTITY(1,1) NOT NULL,
	[Exam_Name] [nvarchar](200) NOT NULL,
	[Exam_Date_Created] [datetime] NOT NULL,
	[Exam_Active] [bit] NOT NULL,
	[Exam_Description] [nvarchar](4000) NULL,
	[Exam_Open_Date] [datetime] NULL,
	[Exam_Open_Date_Enabled] [bit] NOT NULL,
	[Exam_Closed_Date] [datetime] NULL,
	[Exam_Closed_Date_Enabled] [bit] NOT NULL,
	[Exam_Time_Limit] [time](0) NULL,
	[Exam_Time_Limit_Enabled] [bit] NOT NULL,
	[Exam_Attempts_Allowed] [int] NOT NULL,
	[Exam_Questions_Ordered] [bit] NOT NULL,
	[Exam_Shuffle_Answers] [bit] NOT NULL,
	[Exam_Learning_Mode] [bit] NOT NULL,
	[Exam_Password] [nvarchar](200) NULL,
 CONSTRAINT [PK_Exam] PRIMARY KEY CLUSTERED 
(
	[pkExam_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Group]    Script Date: 08/02/2015 00:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[pkGroup_ID] [int] IDENTITY(1,1) NOT NULL,
	[Group_Name] [nvarchar](200) NULL,
	[Group_Active] [bit] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[pkGroup_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Machine]    Script Date: 08/02/2015 00:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Machine](
	[pkMachine_ID] [int] IDENTITY(1,1) NOT NULL,
	[Machine_Name] [nvarchar](200) NOT NULL,
	[Machine_Active] [bit] NOT NULL,
	[Machine_Auth_Code] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Machine] PRIMARY KEY CLUSTERED 
(
	[pkMachine_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Module]    Script Date: 08/02/2015 00:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[pkModule_ID] [int] IDENTITY(1,1) NOT NULL,
	[Module_Name] [nvarchar](200) NOT NULL,
	[Module_Active] [bit] NOT NULL,
	[fkSubject_ID] [int] NOT NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[pkModule_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Module_Bank]    Script Date: 08/02/2015 00:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module_Bank](
	[pkModule_Bank_ID] [int] NOT NULL,
	[fkModule_ID] [int] NOT NULL,
	[fkExam_ID] [int] NOT NULL,
 CONSTRAINT [PK_Module_Bank] PRIMARY KEY CLUSTERED 
(
	[pkModule_Bank_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Question]    Script Date: 08/02/2015 00:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[pkQuestion_ID] [int] IDENTITY(1,1) NOT NULL,
	[Question_Name] [nvarchar](200) NOT NULL,
	[Question_Active] [bit] NOT NULL,
	[Question_Description] [nvarchar](4000) NULL,
	[fkModule_ID] [int] NOT NULL,
	[fkQuestion_Type_ID] [int] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[pkQuestion_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Question_Bank]    Script Date: 08/02/2015 00:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question_Bank](
	[pkQuestion_Bank_ID] [int] NOT NULL,
	[fkQuestion_ID] [int] NOT NULL,
	[fkExam_ID] [int] NOT NULL,
 CONSTRAINT [PK_Question_Bank] PRIMARY KEY CLUSTERED 
(
	[pkQuestion_Bank_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Question_Type]    Script Date: 08/02/2015 00:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question_Type](
	[pkQuestion_Type_ID] [int] IDENTITY(1,1) NOT NULL,
	[Question_Type_Name] [nvarchar](200) NOT NULL,
	[Question_Type_Description] [nvarchar](4000) NULL,
 CONSTRAINT [PK_Question_Type] PRIMARY KEY CLUSTERED 
(
	[pkQuestion_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Result]    Script Date: 08/02/2015 00:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[pkResult_ID] [int] IDENTITY(1,1) NOT NULL,
	[Result_Date_From] [datetime] NULL,
	[Result_Date_To] [datetime] NULL,
	[Result_Complete] [int] NOT NULL,
	[fkStudent_ID] [int] NOT NULL,
	[fkMachine_ID] [int] NULL,
	[fkExam_ID] [int] NOT NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[pkResult_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Result_Answer]    Script Date: 08/02/2015 00:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result_Answer](
	[pkResult_Answer_ID] [int] NOT NULL,
	[fkResult_ID] [int] NOT NULL,
	[fkAnswer_ID] [int] NOT NULL,
	[Result_Answer_Text] [nvarchar](4000) NULL,
 CONSTRAINT [PK_Result_Answer] PRIMARY KEY CLUSTERED 
(
	[pkResult_Answer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Setting]    Script Date: 08/02/2015 00:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[pkSetting_ID] [int] NOT NULL,
	[Setting_Name] [nvarchar](200) NULL,
	[Setting_Value] [nvarchar](4000) NULL,
	[Setting_Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED 
(
	[pkSetting_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 08/02/2015 00:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[pkStudent_ID] [int] IDENTITY(1,1) NOT NULL,
	[Student_First_Name] [nvarchar](200) NOT NULL,
	[Student_Last_Name] [nvarchar](200) NOT NULL,
	[Student_Email] [nvarchar](200) NOT NULL,
	[Student_Password] [nvarchar](200) NOT NULL,
	[Student_Active] [bit] NOT NULL,
	[fkGroup_ID] [int] NOT NULL,
	[Student_Auth_Code] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[pkStudent_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 08/02/2015 00:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[pkSubject_ID] [int] IDENTITY(1,1) NOT NULL,
	[Subject_Name] [nvarchar](200) NOT NULL,
	[Subject_Active] [bit] NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[pkSubject_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([fkQuestion_ID])
REFERENCES [dbo].[Question] ([pkQuestion_ID])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Question]
GO
ALTER TABLE [dbo].[Module]  WITH CHECK ADD  CONSTRAINT [FK_Module_Subject] FOREIGN KEY([fkSubject_ID])
REFERENCES [dbo].[Subject] ([pkSubject_ID])
GO
ALTER TABLE [dbo].[Module] CHECK CONSTRAINT [FK_Module_Subject]
GO
ALTER TABLE [dbo].[Module_Bank]  WITH CHECK ADD  CONSTRAINT [FK_Module_Bank_Exam] FOREIGN KEY([fkExam_ID])
REFERENCES [dbo].[Exam] ([pkExam_ID])
GO
ALTER TABLE [dbo].[Module_Bank] CHECK CONSTRAINT [FK_Module_Bank_Exam]
GO
ALTER TABLE [dbo].[Module_Bank]  WITH CHECK ADD  CONSTRAINT [FK_Module_Bank_Module] FOREIGN KEY([fkModule_ID])
REFERENCES [dbo].[Module] ([pkModule_ID])
GO
ALTER TABLE [dbo].[Module_Bank] CHECK CONSTRAINT [FK_Module_Bank_Module]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Module] FOREIGN KEY([fkModule_ID])
REFERENCES [dbo].[Module] ([pkModule_ID])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Module]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Question_Type] FOREIGN KEY([fkQuestion_Type_ID])
REFERENCES [dbo].[Question_Type] ([pkQuestion_Type_ID])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Question_Type]
GO
ALTER TABLE [dbo].[Question_Bank]  WITH CHECK ADD  CONSTRAINT [FK_Question_Bank_Exam] FOREIGN KEY([fkExam_ID])
REFERENCES [dbo].[Exam] ([pkExam_ID])
GO
ALTER TABLE [dbo].[Question_Bank] CHECK CONSTRAINT [FK_Question_Bank_Exam]
GO
ALTER TABLE [dbo].[Question_Bank]  WITH CHECK ADD  CONSTRAINT [FK_Question_Bank_Question] FOREIGN KEY([fkQuestion_ID])
REFERENCES [dbo].[Question] ([pkQuestion_ID])
GO
ALTER TABLE [dbo].[Question_Bank] CHECK CONSTRAINT [FK_Question_Bank_Question]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Exam] FOREIGN KEY([fkExam_ID])
REFERENCES [dbo].[Exam] ([pkExam_ID])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Exam]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Machine] FOREIGN KEY([fkMachine_ID])
REFERENCES [dbo].[Machine] ([pkMachine_ID])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Machine]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Student] FOREIGN KEY([fkStudent_ID])
REFERENCES [dbo].[Student] ([pkStudent_ID])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Student]
GO
ALTER TABLE [dbo].[Result_Answer]  WITH CHECK ADD  CONSTRAINT [FK_Result_Answer_Answer] FOREIGN KEY([fkAnswer_ID])
REFERENCES [dbo].[Answer] ([pkAnswer_ID])
GO
ALTER TABLE [dbo].[Result_Answer] CHECK CONSTRAINT [FK_Result_Answer_Answer]
GO
ALTER TABLE [dbo].[Result_Answer]  WITH CHECK ADD  CONSTRAINT [FK_Result_Answer_Result] FOREIGN KEY([fkResult_ID])
REFERENCES [dbo].[Result] ([pkResult_ID])
GO
ALTER TABLE [dbo].[Result_Answer] CHECK CONSTRAINT [FK_Result_Answer_Result]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Group] FOREIGN KEY([fkGroup_ID])
REFERENCES [dbo].[Group] ([pkGroup_ID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Group]
GO
USE [master]
GO
ALTER DATABASE [TestServer] SET  READ_WRITE 
GO
