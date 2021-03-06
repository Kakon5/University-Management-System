USE [master]
GO
/****** Object:  Database [UniversityDB]    Script Date: 9/14/2019 9:44:09 PM ******/
CREATE DATABASE [UniversityDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityDB', FILENAME = N'D:\Coaching Asp.net\Database\University\UniversityDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityDB_log', FILENAME = N'D:\Coaching Asp.net\Database\University\UniversityDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversityDB] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UniversityDB]
GO
/****** Object:  Table [dbo].[Classroom]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Classroom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Classroom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClassroomAllocate]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassroomAllocate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[ClassroomId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Day] [varchar](15) NOT NULL,
	[StartTime] [varchar](12) NOT NULL,
	[EndTime] [varchar](12) NOT NULL,
	[Allocated] [varchar](3) NOT NULL,
 CONSTRAINT [PK_ClassroomAllocate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Course]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](20) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Credit] [decimal](5, 1) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseAssign]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CourseAssign](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Assigned] [varchar](3) NULL,
 CONSTRAINT [PK_CourseAssign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseEnroll]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CourseEnroll](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Grade] [varchar](30) NULL,
 CONSTRAINT [PK_CourseEnroll] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](7) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Semester] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[ContactNo] [varchar](30) NOT NULL,
	[Date] [date] NOT NULL,
	[Address] [varchar](500) NOT NULL,
	[Code] [varchar](10) NULL,
	[RegistrationNo] [varchar](20) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Address] [varchar](500) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[ContactNo] [varchar](15) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CreditToBeTaken] [decimal](5, 2) NOT NULL,
	[RemainingCredit] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[GetClassScheduleInformation]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[GetClassScheduleInformation] as

select co.Code CourseCode, co.Name CourseName, ca.Day, ca.StartTime, ca.EndTime, co.DepartmentId, ca.Allocated, cl.RoomNo 
 from Course co join ClassroomAllocate ca on co.Id = ca.CourseId 
  join Classroom cl on cl.Id = ca.ClassroomId 
 where ca.Allocated = 'Yes'
GO
/****** Object:  View [dbo].[GetCourseStatics]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create View GetCoursesWithSemester As
--Select co.id, co.Name,co.Code,s.Semester, co.DepartmentId from Course co join Semester s on co.SemesterId=s.Id

--Create View GetCoursesSemesterWithAssigned as
--select cs.id CourseId, cs.Name,cs.Code,cs.Semester,cs.DepartmentId, ca.Assigned,ca.TeacherId 
-- from GetCoursesWithSemester cs full outer join CourseAssign ca on cs.id= ca.CourseId

--Create View GetCourseStatics As 
--Select csa.CourseId,csa.Name, csa.Code, csa.Semester,csa.DepartmentId, t.Name TeacherName, c[dbo].[GetCourseStatics]sa.Assigned
-- from GetCoursesSemesterWithAssigned 
-- csa left outer join Teacher t on t.Id=csa.TeacherId 

create view [dbo].[GetCourseStatics] as
select co.Code, co.Name CourseName, co.DepartmentId,  s.Semester, t.Name TeacherName, ca.Assigned from CourseAssign ca 
join Course co on co.Id = ca.CourseId join Semester s on s.Id = co.SemesterId 
join Teacher t on t.Id = ca.TeacherId where Assigned = 'Yes'
GO
/****** Object:  View [dbo].[GetCoursesWithSemester]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create View GetCoursesWithSemester As
--Select co.id, co.Name,co.Code,s.Semester, co.DepartmentId from Course co join Semester s on co.SemesterId=s.Id

--Create View GetCoursesSemesterWithAssigned as
--select cs.id CourseId, cs.Name,cs.Code,cs.Semester,cs.DepartmentId, ca.Assigned,ca.TeacherId 
-- from GetCoursesWithSemester cs full outer join CourseAssign ca on cs.id= ca.CourseId

--Create View GetCourseStatics As 
--Select csa.CourseId,csa.Name, csa.Code, csa.Semester,csa.DepartmentId, t.Name TeacherName, c[dbo].[GetCourseStatics]sa.Assigned
-- from GetCoursesSemesterWithAssigned 
-- csa left outer join Teacher t on t.Id=csa.TeacherId 

--create view GetCourseStatics as
--select co.Code, co.Name CourseName, co.DepartmentId,  s.Semester, t.Name TeacherName, ca.Assigned from CourseAssign ca 
--join Course co on co.Id = ca.CourseId join Semester s on s.Id = co.SemesterId 
--join Teacher t on t.Id = ca.TeacherId where Assigned = 'Yes'

create view [dbo].[GetCoursesWithSemester] as
select co.Code, co.Name, co.DepartmentId, s.Semester from course co join Semester s on co.SemesterId = s.Id
GO
/****** Object:  View [dbo].[GetEnrolledCoursesWithCourseName]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[GetEnrolledCoursesWithCourseName]
As
select co.Id CourseId, co.Code, co.Name, ce.StudentId from Course co join CourseEnroll ce on co.Id = ce.CourseId
GO
/****** Object:  View [dbo].[GetStudentsResultWithCourseName]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[GetStudentsResultWithCourseName]
AS
SELECT c.Code CourseCode, c.Name CourseName, c.Credit, cE.StudentId, cE.Grade 
FROM Course c JOIN CourseEnroll cE ON c.Id = cE.CourseId 


GO
/****** Object:  View [dbo].[GetStudentsWithDepartmentName]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[GetStudentsWithDepartmentName]
AS
SELECT s.Id StudentId, s.Name, s.RegistrationNo, s.Email, s.Address, s.DepartmentId, d.Name DeptName
 FROM Student s JOIN Department d ON s.DepartmentId = d.Id

GO
/****** Object:  View [dbo].[RegistrationNoInfromation]    Script Date: 9/14/2019 9:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RegistrationNoInfromation]
AS
SELECT s.Name StudentName, s.RegistrationNo, YEAR(s.Date) Date, s.Code StudentCode, d.Code DeptCode, d.Id DeptId FROM Student s 
JOIN Department d ON s.DepartmentId = d.Id
GO
SET IDENTITY_INSERT [dbo].[Classroom] ON 

INSERT [dbo].[Classroom] ([Id], [RoomNo]) VALUES (1, N'2201')
INSERT [dbo].[Classroom] ([Id], [RoomNo]) VALUES (2, N'2202')
INSERT [dbo].[Classroom] ([Id], [RoomNo]) VALUES (3, N'2301')
INSERT [dbo].[Classroom] ([Id], [RoomNo]) VALUES (4, N'2302')
INSERT [dbo].[Classroom] ([Id], [RoomNo]) VALUES (5, N'2401')
INSERT [dbo].[Classroom] ([Id], [RoomNo]) VALUES (6, N'2402')
INSERT [dbo].[Classroom] ([Id], [RoomNo]) VALUES (7, N'3201')
INSERT [dbo].[Classroom] ([Id], [RoomNo]) VALUES (8, N'3202')
INSERT [dbo].[Classroom] ([Id], [RoomNo]) VALUES (9, N'3301')
INSERT [dbo].[Classroom] ([Id], [RoomNo]) VALUES (10, N'3302')
INSERT [dbo].[Classroom] ([Id], [RoomNo]) VALUES (11, N'3401')
INSERT [dbo].[Classroom] ([Id], [RoomNo]) VALUES (12, N'3402')
INSERT [dbo].[Classroom] ([Id], [RoomNo]) VALUES (13, N'3501')
INSERT [dbo].[Classroom] ([Id], [RoomNo]) VALUES (14, N'3502')
INSERT [dbo].[Classroom] ([Id], [RoomNo]) VALUES (15, N'3503')
SET IDENTITY_INSERT [dbo].[Classroom] OFF
SET IDENTITY_INSERT [dbo].[ClassroomAllocate] ON 

INSERT [dbo].[ClassroomAllocate] ([Id], [DepartmentId], [ClassroomId], [CourseId], [Day], [StartTime], [EndTime], [Allocated]) VALUES (1, 1, 1, 1, N'Sunday', N'11:00 AM', N'12:30 PM', N'No')
INSERT [dbo].[ClassroomAllocate] ([Id], [DepartmentId], [ClassroomId], [CourseId], [Day], [StartTime], [EndTime], [Allocated]) VALUES (2, 2, 3, 7, N'Monday', N'08:00 AM', N'09:30 AM', N'No')
INSERT [dbo].[ClassroomAllocate] ([Id], [DepartmentId], [ClassroomId], [CourseId], [Day], [StartTime], [EndTime], [Allocated]) VALUES (15, 6, 1, 16, N'Monday', N'08:00 AM', N'09:30 AM', N'Yes')
INSERT [dbo].[ClassroomAllocate] ([Id], [DepartmentId], [ClassroomId], [CourseId], [Day], [StartTime], [EndTime], [Allocated]) VALUES (16, 6, 3, 17, N'Tuesday', N'09:29 AM', N'10:00 AM', N'No')
INSERT [dbo].[ClassroomAllocate] ([Id], [DepartmentId], [ClassroomId], [CourseId], [Day], [StartTime], [EndTime], [Allocated]) VALUES (17, 5, 4, 5, N'Sunday', N'10:30 AM', N'12:00 PM', N'Yes')
INSERT [dbo].[ClassroomAllocate] ([Id], [DepartmentId], [ClassroomId], [CourseId], [Day], [StartTime], [EndTime], [Allocated]) VALUES (18, 5, 7, 5, N'Wednesday', N'11:30 AM', N'01:30 PM', N'Yes')
INSERT [dbo].[ClassroomAllocate] ([Id], [DepartmentId], [ClassroomId], [CourseId], [Day], [StartTime], [EndTime], [Allocated]) VALUES (19, 1, 3, 1, N'Thursday', N'01:00 PM', N'02:30 PM', N'No')
INSERT [dbo].[ClassroomAllocate] ([Id], [DepartmentId], [ClassroomId], [CourseId], [Day], [StartTime], [EndTime], [Allocated]) VALUES (20, 2, 4, 7, N'Friday', N'09:30 AM', N'11:30 AM', N'No')
INSERT [dbo].[ClassroomAllocate] ([Id], [DepartmentId], [ClassroomId], [CourseId], [Day], [StartTime], [EndTime], [Allocated]) VALUES (21, 1, 4, 11, N'Monday', N'10:00 AM', N'12:30 PM', N'Yes')
INSERT [dbo].[ClassroomAllocate] ([Id], [DepartmentId], [ClassroomId], [CourseId], [Day], [StartTime], [EndTime], [Allocated]) VALUES (22, 5, 5, 4, N'Monday', N'11:00 AM', N'12:30 PM', N'No')
INSERT [dbo].[ClassroomAllocate] ([Id], [DepartmentId], [ClassroomId], [CourseId], [Day], [StartTime], [EndTime], [Allocated]) VALUES (23, 1, 1, 6, N'Monday', N'08:00 AM', N'09:30 AM', N'Yes')
INSERT [dbo].[ClassroomAllocate] ([Id], [DepartmentId], [ClassroomId], [CourseId], [Day], [StartTime], [EndTime], [Allocated]) VALUES (24, 1, 1, 6, N'Sunday', N'11:00 AM', N'12:30 PM', N'Yes')
SET IDENTITY_INSERT [dbo].[ClassroomAllocate] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (1, N'CSE209', N'Algorithms', CAST(3.0 AS Decimal(5, 1)), N'Sorting, Searching, Greedy Algorithm, Trees, Graphs', 1, 4)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (4, N'SOC101', N'Social Science', CAST(5.0 AS Decimal(5, 1)), N'Explanation for social enironment', 5, 3)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (5, N'HEA101', N'Health & Environment', CAST(2.5 AS Decimal(5, 1)), N'Rural & urban health condition', 5, 2)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (6, N'CSE412', N'Artificial Intelligence', CAST(3.0 AS Decimal(5, 1)), N'Machine learning, Advance algorithms', 1, 8)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (7, N'EEE101', N'Introduction of Electronics', CAST(3.0 AS Decimal(5, 1)), N'Circuits, Diods, Capacitors', 2, 2)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (8, N'EEE207', N'Electronic Devices & Circuits', CAST(3.0 AS Decimal(5, 1)), N'Laws of current & advance circuit design', 2, 5)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (9, N'ETE303', N'Data Communication', CAST(2.5 AS Decimal(5, 1)), N'Methods of data passing', 4, 6)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (10, N'ETE314', N'Digital Communications', CAST(3.0 AS Decimal(5, 1)), N'Advance topics in data passing', 4, 8)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (11, N'CSE321', N'Compiler', CAST(3.0 AS Decimal(5, 1)), N'Specifications of Compilers', 1, 7)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (13, N'CSE101', N'Introduction to Computer', CAST(2.5 AS Decimal(5, 1)), N'Computer related topics', 1, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (14, N'CSE401', N'Embedded Systems', CAST(3.0 AS Decimal(5, 1)), N'Architecture of embedded system ', 1, 7)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (15, N'IT213', N'Software Architecture', CAST(1.5 AS Decimal(5, 1)), N'Software related work', 6, 2)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (16, N'IT303', N'Cloud Computing', CAST(3.0 AS Decimal(5, 1)), N'Cloud related work', 6, 3)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (17, N'IT421', N'Big Data', CAST(3.0 AS Decimal(5, 1)), N'Data related work', 6, 3)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[CourseAssign] ON 

INSERT [dbo].[CourseAssign] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assigned]) VALUES (1, 1, 2, 1, N'No')
INSERT [dbo].[CourseAssign] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assigned]) VALUES (2, 2, 3, 7, N'No')
INSERT [dbo].[CourseAssign] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assigned]) VALUES (29, 6, 10, 16, N'No')
INSERT [dbo].[CourseAssign] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assigned]) VALUES (30, 6, 10, 15, N'Yes')
INSERT [dbo].[CourseAssign] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assigned]) VALUES (31, 6, 10, 17, N'No')
INSERT [dbo].[CourseAssign] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assigned]) VALUES (32, 1, 2, 1, N'Yes')
INSERT [dbo].[CourseAssign] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assigned]) VALUES (33, 1, 6, 6, N'No')
INSERT [dbo].[CourseAssign] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assigned]) VALUES (34, 4, 1, 9, N'Yes')
INSERT [dbo].[CourseAssign] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assigned]) VALUES (35, 1, 2, 11, N'No')
INSERT [dbo].[CourseAssign] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assigned]) VALUES (36, 1, 2, 13, N'Yes')
INSERT [dbo].[CourseAssign] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assigned]) VALUES (37, 1, 2, 14, N'No')
INSERT [dbo].[CourseAssign] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assigned]) VALUES (38, 5, 4, 4, N'Yes')
INSERT [dbo].[CourseAssign] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assigned]) VALUES (39, 1, 2, 1, N'No')
SET IDENTITY_INSERT [dbo].[CourseAssign] OFF
SET IDENTITY_INSERT [dbo].[CourseEnroll] ON 

INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (1, 2, 1, CAST(0x273F0B00 AS Date), N'A+')
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (2, 2, 6, CAST(0x273F0B00 AS Date), N'A-')
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (3, 3, 7, CAST(0x8B3F0B00 AS Date), N'B-')
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (4, 4, 10, CAST(0xBE3F0B00 AS Date), N'A')
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (5, 4, 9, CAST(0x273F0B00 AS Date), N'A-')
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (6, 5, 4, CAST(0x1F400B00 AS Date), N'B')
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (7, 9, 1, CAST(0x1F400B00 AS Date), N'A+')
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (8, 8, 6, CAST(0x22400B00 AS Date), N'Not Graded Yet')
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (10, 8, 1, CAST(0x23400B00 AS Date), N'B+')
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (11, 23, 7, CAST(0x23400B00 AS Date), N'Not Graded Yet')
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (12, 25, 8, CAST(0x23400B00 AS Date), N'Not Graded Yet')
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (13, 18, 11, CAST(0x23400B00 AS Date), N'Not Graded Yet')
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (14, 17, 9, CAST(0x23400B00 AS Date), N'A')
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (15, 3, 8, CAST(0x23400B00 AS Date), N'Not Graded Yet')
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (16, 2, 11, CAST(0x23400B00 AS Date), N'F')
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (17, 2, 13, CAST(0x23400B00 AS Date), N'Not Graded Yet')
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (18, 2, 14, CAST(0x23400B00 AS Date), N'B-')
SET IDENTITY_INSERT [dbo].[CourseEnroll] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (1, N'CSE', N'Computer Science & Engineering')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (2, N'EEE', N'Electrical & Electronics Engineering')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (4, N'ETE', N'Electrical & Communication Engineering')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (5, N'BBA', N'Bachelor of Business Administration')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (6, N'IT', N'Information Technology')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([Id], [Name]) VALUES (4, N'Assistant Professor')
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (3, N'Associate Professor')
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (1, N'Dean')
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (5, N'Lecturer')
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (2, N'Professor')
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[Semester] ON 

INSERT [dbo].[Semester] ([Id], [Semester]) VALUES (1, N'1st')
INSERT [dbo].[Semester] ([Id], [Semester]) VALUES (2, N'2nd')
INSERT [dbo].[Semester] ([Id], [Semester]) VALUES (3, N'3rd')
INSERT [dbo].[Semester] ([Id], [Semester]) VALUES (4, N'4th')
INSERT [dbo].[Semester] ([Id], [Semester]) VALUES (5, N'5th')
INSERT [dbo].[Semester] ([Id], [Semester]) VALUES (6, N'6th')
INSERT [dbo].[Semester] ([Id], [Semester]) VALUES (7, N'7th')
INSERT [dbo].[Semester] ([Id], [Semester]) VALUES (8, N'8th')
SET IDENTITY_INSERT [dbo].[Semester] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [Code], [RegistrationNo], [DepartmentId]) VALUES (2, N'Riaz', N'riaz@mail.com', N'015498799', CAST(0x543B0B00 AS Date), N'Ctg', N'001', N'CSE-2016-001', 1)
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [Code], [RegistrationNo], [DepartmentId]) VALUES (3, N'Keya', N'keya@mail.com', N'015498798', CAST(0xA33C0B00 AS Date), N'Ctg', N'001', N'EEE-2017-001', 2)
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [Code], [RegistrationNo], [DepartmentId]) VALUES (4, N'Aditya', N'aditya@mail.com', N'078998998', CAST(0x5C3C0B00 AS Date), N'Ctg', N'001', N'ETE-2017-001', 4)
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [Code], [RegistrationNo], [DepartmentId]) VALUES (5, N'Rupa', N'rupa@mail.com', N'035645997', CAST(0x2E3E0B00 AS Date), N'Ctg', N'001', N'BBA-2018-001', 5)
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [Code], [RegistrationNo], [DepartmentId]) VALUES (8, N'Kakon', N'kakon@email.com', N'54997', CAST(0x1C400B00 AS Date), N'Ctg', N'001', N'CSE-2019-001', 1)
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [Code], [RegistrationNo], [DepartmentId]) VALUES (9, N'Rimpa', N'rimpa@email.com', N'756876', CAST(0x1C400B00 AS Date), N'ctg', N'002', N'CSE-2019-002', 1)
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [Code], [RegistrationNo], [DepartmentId]) VALUES (15, N'Dipta', N'dipta@email.com', N'01547896525', CAST(0x1C400B00 AS Date), N'Chittagong', N'001', N'BBA-2019-001', 5)
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [Code], [RegistrationNo], [DepartmentId]) VALUES (17, N'Antara', N'antara@email.com', N'8799545646', CAST(0x1C400B00 AS Date), N'Chittagong', N'002', N'ETE-2019-002', 4)
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [Code], [RegistrationNo], [DepartmentId]) VALUES (18, N'Sathi', N'sathi@mail.com', N'5276283', CAST(0x20400B00 AS Date), N'ctg', N'003', N'CSE-2019-003', 1)
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [Code], [RegistrationNo], [DepartmentId]) VALUES (23, N'Abir', N'abir@mail.com', N'05895465', CAST(0x23400B00 AS Date), N'Chittagong', N'001', N'EEE-2019-001', 2)
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [Code], [RegistrationNo], [DepartmentId]) VALUES (25, N'Abir12', N'abir12@mail.com', N'05895465', CAST(0x23400B00 AS Date), N'Chittagong', N'002', N'EEE-2019-002', 2)
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [RemainingCredit]) VALUES (1, N'Nizam Uddin', N'Ctg', N'nizam@mail.com', N'01254896565', 3, 4, CAST(15.00 AS Decimal(5, 2)), CAST(12.50 AS Decimal(5, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [RemainingCredit]) VALUES (2, N'Akash Chowdhury', N'Ctg', N'akash@mail.com', N'01548795678', 1, 1, CAST(10.00 AS Decimal(5, 2)), CAST(-4.50 AS Decimal(5, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [RemainingCredit]) VALUES (3, N'Taslim Arefin', N'Dhaka', N'taslim@mail.com', N'05989878999', 4, 2, CAST(10.00 AS Decimal(5, 2)), CAST(10.00 AS Decimal(5, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [RemainingCredit]) VALUES (4, N'Bristy Talukdar', N'Ctg', N'bristy@mail.com', N'21549897879', 2, 5, CAST(9.00 AS Decimal(5, 2)), CAST(4.00 AS Decimal(5, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [RemainingCredit]) VALUES (6, N'Sathi Chowdhury', N'Ctg', N'sathi@mail.com', N'21564987989', 5, 1, CAST(6.00 AS Decimal(5, 2)), CAST(3.00 AS Decimal(5, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [RemainingCredit]) VALUES (7, N'Zareen Sultana', N'Chittagong', N'zareen@mail.com', N'549865267', 2, 5, CAST(20.00 AS Decimal(5, 2)), CAST(20.00 AS Decimal(5, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [RemainingCredit]) VALUES (8, N'Masuma Minhar', N'Chittagong', N'minhar@mail.com', N'65768768', 5, 1, CAST(15.00 AS Decimal(5, 2)), CAST(15.00 AS Decimal(5, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [RemainingCredit]) VALUES (9, N'Enamul Haque', N'Chittagong
', N'enamul@mail.com', N'5487998879', 3, 1, CAST(13.00 AS Decimal(5, 2)), CAST(13.00 AS Decimal(5, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [RemainingCredit]) VALUES (10, N'Soma Barua', N'Chittagong', N'soma@mail.com', N'528998978897', 2, 6, CAST(12.00 AS Decimal(5, 2)), CAST(4.50 AS Decimal(5, 2)))
SET IDENTITY_INSERT [dbo].[Teacher] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Classroom]    Script Date: 9/14/2019 9:44:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Classroom] ON [dbo].[Classroom]
(
	[RoomNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Course]    Script Date: 9/14/2019 9:44:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Course] ON [dbo].[Course]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department]    Script Date: 9/14/2019 9:44:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Department] ON [dbo].[Department]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department_1]    Script Date: 9/14/2019 9:44:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Department_1] ON [dbo].[Department]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Designation]    Script Date: 9/14/2019 9:44:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Designation] ON [dbo].[Designation]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Semester]    Script Date: 9/14/2019 9:44:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Semester] ON [dbo].[Semester]
(
	[Semester] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Student]    Script Date: 9/14/2019 9:44:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_Student] ON [dbo].[Student]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Teacher]    Script Date: 9/14/2019 9:44:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Teacher] ON [dbo].[Teacher]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClassroomAllocate]  WITH CHECK ADD  CONSTRAINT [FK_ClassroomAllocate_Classroom] FOREIGN KEY([ClassroomId])
REFERENCES [dbo].[Classroom] ([Id])
GO
ALTER TABLE [dbo].[ClassroomAllocate] CHECK CONSTRAINT [FK_ClassroomAllocate_Classroom]
GO
ALTER TABLE [dbo].[ClassroomAllocate]  WITH CHECK ADD  CONSTRAINT [FK_ClassroomAllocate_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[ClassroomAllocate] CHECK CONSTRAINT [FK_ClassroomAllocate_Course]
GO
ALTER TABLE [dbo].[ClassroomAllocate]  WITH CHECK ADD  CONSTRAINT [FK_ClassroomAllocate_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[ClassroomAllocate] CHECK CONSTRAINT [FK_ClassroomAllocate_Department]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Department]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Semester] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semester] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Semester]
GO
ALTER TABLE [dbo].[CourseAssign]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssign_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[CourseAssign] CHECK CONSTRAINT [FK_CourseAssign_Course]
GO
ALTER TABLE [dbo].[CourseAssign]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssign_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[CourseAssign] CHECK CONSTRAINT [FK_CourseAssign_Department]
GO
ALTER TABLE [dbo].[CourseAssign]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssign_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[CourseAssign] CHECK CONSTRAINT [FK_CourseAssign_Teacher]
GO
ALTER TABLE [dbo].[CourseEnroll]  WITH CHECK ADD  CONSTRAINT [FK_CourseEnroll_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[CourseEnroll] CHECK CONSTRAINT [FK_CourseEnroll_Course]
GO
ALTER TABLE [dbo].[CourseEnroll]  WITH CHECK ADD  CONSTRAINT [FK_CourseEnroll_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[CourseEnroll] CHECK CONSTRAINT [FK_CourseEnroll_Student]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Department]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Department]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Designation] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designation] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Designation]
GO
USE [master]
GO
ALTER DATABASE [UniversityDB] SET  READ_WRITE 
GO
