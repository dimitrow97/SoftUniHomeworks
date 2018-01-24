USE [LocalStore]

SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Distributor], [Description], [Price]) VALUES (1, N'Sugar', N'Sweetness OOD', N'1kg of Sugar', CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([Id], [Name], [Distributor], [Description], [Price]) VALUES (2, N'Ham', N'Meat Delivery OOD', N'250gr of Ham', CAST(3.50 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([Id], [Name], [Distributor], [Description], [Price]) VALUES (3, N'Coca Cola', N'Coca Cola OOD', N'2l of Cola', CAST(2.20 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Products] OFF
