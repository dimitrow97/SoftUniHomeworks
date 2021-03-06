USE [_3_Working_with_the_Database.StudentsContext]
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [Name], [Description], [StartDate], [EndDate], [Price]) VALUES (1, N'Himiq', NULL, CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2017-07-03T00:00:00.000' AS DateTime), CAST(200.00 AS Decimal(18, 2)))
INSERT [dbo].[Courses] ([Id], [Name], [Description], [StartDate], [EndDate], [Price]) VALUES (2, N'Matematika', NULL, CAST(N'2016-09-01T00:00:00.000' AS DateTime), CAST(N'2017-07-21T00:00:00.000' AS DateTime), CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[Courses] ([Id], [Name], [Description], [StartDate], [EndDate], [Price]) VALUES (3, N'Literatura', NULL, CAST(N'2016-11-01T00:00:00.000' AS DateTime), CAST(N'2017-04-12T00:00:00.000' AS DateTime), CAST(250.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Courses] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [Name], [PhoneNumber], [RegistrationDate], [BirthDay]) VALUES (1, N'Ivan', NULL, CAST(N'2015-01-20T00:00:00.000' AS DateTime), CAST(N'1997-02-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Students] ([Id], [Name], [PhoneNumber], [RegistrationDate], [BirthDay]) VALUES (2, N'Mitko', NULL, CAST(N'2015-01-20T00:00:00.000' AS DateTime), CAST(N'1997-07-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Students] ([Id], [Name], [PhoneNumber], [RegistrationDate], [BirthDay]) VALUES (3, N'Pesho', NULL, CAST(N'2015-01-20T00:00:00.000' AS DateTime), CAST(N'1997-09-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Students] ([Id], [Name], [PhoneNumber], [RegistrationDate], [BirthDay]) VALUES (4, N'Petar', NULL, CAST(N'2016-12-20T00:00:00.000' AS DateTime), CAST(N'1997-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Students] ([Id], [Name], [PhoneNumber], [RegistrationDate], [BirthDay]) VALUES (5, N'Sasho', NULL, CAST(N'2016-12-20T00:00:00.000' AS DateTime), CAST(N'1997-02-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Students] ([Id], [Name], [PhoneNumber], [RegistrationDate], [BirthDay]) VALUES (6, N'Dragan', NULL, CAST(N'2016-12-20T00:00:00.000' AS DateTime), CAST(N'1997-04-15T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Students] OFF
SET IDENTITY_INSERT [dbo].[Homework] ON 

INSERT [dbo].[Homework] ([Id], [Content], [ContextsType], [SubmissionDate], [Course_Id], [Student_Id]) VALUES (1, N'Uravneniq', 1, CAST(N'2017-03-12T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Homework] ([Id], [Content], [ContextsType], [SubmissionDate], [Course_Id], [Student_Id]) VALUES (2, N'Uravneniq', 1, CAST(N'2017-03-12T00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[Homework] ([Id], [Content], [ContextsType], [SubmissionDate], [Course_Id], [Student_Id]) VALUES (3, N'Uravneniq', 1, CAST(N'2017-03-12T00:00:00.000' AS DateTime), 1, 3)
INSERT [dbo].[Homework] ([Id], [Content], [ContextsType], [SubmissionDate], [Course_Id], [Student_Id]) VALUES (4, N'Zadachi geometriq', 1, CAST(N'2017-04-08T00:00:00.000' AS DateTime), 2, 4)
INSERT [dbo].[Homework] ([Id], [Content], [ContextsType], [SubmissionDate], [Course_Id], [Student_Id]) VALUES (5, N'Zadachi aritmetika', 1, CAST(N'2017-04-09T00:00:00.000' AS DateTime), 2, 4)
INSERT [dbo].[Homework] ([Id], [Content], [ContextsType], [SubmissionDate], [Course_Id], [Student_Id]) VALUES (6, N'Uravneniq aritmetika', 1, CAST(N'2017-03-12T00:00:00.000' AS DateTime), 2, 5)
INSERT [dbo].[Homework] ([Id], [Content], [ContextsType], [SubmissionDate], [Course_Id], [Student_Id]) VALUES (7, N'LIS Levski', 1, CAST(N'2017-02-18T00:00:00.000' AS DateTime), 3, 6)
INSERT [dbo].[Homework] ([Id], [Content], [ContextsType], [SubmissionDate], [Course_Id], [Student_Id]) VALUES (8, N'LIS Don Kihot', 1, CAST(N'2017-01-18T00:00:00.000' AS DateTime), 3, 6)
SET IDENTITY_INSERT [dbo].[Homework] OFF
SET IDENTITY_INSERT [dbo].[Resources] ON 

INSERT [dbo].[Resources] ([Id], [Name], [ResourcesType], [URL], [Course_Id]) VALUES (1, N'Organichna himiq', 1, N'organicchemistry.com', 1)
INSERT [dbo].[Resources] ([Id], [Name], [ResourcesType], [URL], [Course_Id]) VALUES (2, N'Blagorodni Gazove', 1, N'nobelgases.com', 1)
INSERT [dbo].[Resources] ([Id], [Name], [ResourcesType], [URL], [Course_Id]) VALUES (3, N'Tablica na Mendeleev', 2, N'mendeleev.com', 1)
INSERT [dbo].[Resources] ([Id], [Name], [ResourcesType], [URL], [Course_Id]) VALUES (4, N'Alkalni Metali', 1, N'metals.com', 1)
INSERT [dbo].[Resources] ([Id], [Name], [ResourcesType], [URL], [Course_Id]) VALUES (5, N'Tablica s EDN', 2, N'edn.com', 1)
INSERT [dbo].[Resources] ([Id], [Name], [ResourcesType], [URL], [Course_Id]) VALUES (6, N'Geometriq', 3, N'geometry.com', 2)
INSERT [dbo].[Resources] ([Id], [Name], [ResourcesType], [URL], [Course_Id]) VALUES (7, N'Aritmetika', 3, N'arithmetics.com', 2)
INSERT [dbo].[Resources] ([Id], [Name], [ResourcesType], [URL], [Course_Id]) VALUES (8, N'Kombinatorika', 3, N'combinations.com', 2)
INSERT [dbo].[Resources] ([Id], [Name], [ResourcesType], [URL], [Course_Id]) VALUES (9, N'Evropeiska literatura', 2, N'euliterature.com', 3)
INSERT [dbo].[Resources] ([Id], [Name], [ResourcesType], [URL], [Course_Id]) VALUES (10, N'Balgarska literatura', 2, N'bgliterature.com', 3)
INSERT [dbo].[Resources] ([Id], [Name], [ResourcesType], [URL], [Course_Id]) VALUES (11, N'Alkani', 2, N'alkani.com', 1)
SET IDENTITY_INSERT [dbo].[Resources] OFF
INSERT [dbo].[StudentCourses] ([Student_Id], [Course_Id]) VALUES (1, 1)
INSERT [dbo].[StudentCourses] ([Student_Id], [Course_Id]) VALUES (2, 1)
INSERT [dbo].[StudentCourses] ([Student_Id], [Course_Id]) VALUES (3, 1)
INSERT [dbo].[StudentCourses] ([Student_Id], [Course_Id]) VALUES (4, 2)
INSERT [dbo].[StudentCourses] ([Student_Id], [Course_Id]) VALUES (5, 2)
INSERT [dbo].[StudentCourses] ([Student_Id], [Course_Id]) VALUES (6, 2)
INSERT [dbo].[StudentCourses] ([Student_Id], [Course_Id]) VALUES (6, 3)
