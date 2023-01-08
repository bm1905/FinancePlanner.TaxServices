USE [TAX_SERVICES]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Medicare_Tax_Table]') AND type in (N'U'))
DROP TABLE [dbo].[Medicare_Tax_Table]

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Medicare_Tax_Table](
	[Tax_Year] [date] NOT NULL,
	[Tax_Rate] [decimal](18, 2) NOT NULL,
	[Additional_Tax_Rate] [decimal](18, 2) NOT NULL,
	[Threshold_Wage] [decimal](18, 2) NOT NULL
) ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Percentage_Method_Table_O1_HoH]') AND type in (N'U'))
DROP TABLE [dbo].[Percentage_Method_Table_O1_HoH]
 

SET ANSI_NULLS ON
 

SET QUOTED_IDENTIFIER ON
 

CREATE TABLE [dbo].[Percentage_Method_Table_O1_HoH](
	[At_Least] [money] NOT NULL,
	[But_Less_Than] [money] NOT NULL,
	[Tentative_Hold_Amount] [money] NOT NULL,
	[Percentage] [decimal](18, 2) NOT NULL,
	[Threshold] [money] NOT NULL
) ON [PRIMARY]
 

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Percentage_Method_Table_O1_MFJ]') AND type in (N'U'))
DROP TABLE [dbo].[Percentage_Method_Table_O1_MFJ]
 

SET ANSI_NULLS ON
 

SET QUOTED_IDENTIFIER ON
 

CREATE TABLE [dbo].[Percentage_Method_Table_O1_MFJ](
	[At_Least] [money] NOT NULL,
	[But_Less_Than] [money] NOT NULL,
	[Tentative_Hold_Amount] [money] NOT NULL,
	[Percentage] [decimal](18, 2) NOT NULL,
	[Threshold] [money] NOT NULL
) ON [PRIMARY]
 

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Percentage_Method_Table_O1_SorMFS]') AND type in (N'U'))
DROP TABLE [dbo].[Percentage_Method_Table_O1_SorMFS]
 

SET ANSI_NULLS ON
 

SET QUOTED_IDENTIFIER ON
 

CREATE TABLE [dbo].[Percentage_Method_Table_O1_SorMFS](
	[At_Least] [money] NOT NULL,
	[But_Less_Than] [money] NOT NULL,
	[Tentative_Hold_Amount] [money] NOT NULL,
	[Percentage] [decimal](18, 2) NOT NULL,
	[Threshold] [money] NOT NULL
) ON [PRIMARY]
 

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Percentage_Method_Table_O2_HoH]') AND type in (N'U'))
DROP TABLE [dbo].[Percentage_Method_Table_O2_HoH]
 

SET ANSI_NULLS ON
 

SET QUOTED_IDENTIFIER ON
 

CREATE TABLE [dbo].[Percentage_Method_Table_O2_HoH](
	[At_Least] [money] NOT NULL,
	[But_Less_Than] [money] NOT NULL,
	[Tentative_Hold_Amount] [money] NOT NULL,
	[Percentage] [decimal](18, 2) NOT NULL,
	[Threshold] [money] NOT NULL
) ON [PRIMARY]
 

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Percentage_Method_Table_O2_MFJ]') AND type in (N'U'))
DROP TABLE [dbo].[Percentage_Method_Table_O2_MFJ]
 

SET ANSI_NULLS ON
 

SET QUOTED_IDENTIFIER ON
 

CREATE TABLE [dbo].[Percentage_Method_Table_O2_MFJ](
	[At_Least] [money] NOT NULL,
	[But_Less_Than] [money] NOT NULL,
	[Tentative_Hold_Amount] [money] NOT NULL,
	[Percentage] [decimal](18, 2) NOT NULL,
	[Threshold] [money] NOT NULL
) ON [PRIMARY]
 

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Percentage_Method_Table_O2_SorMFS]') AND type in (N'U'))
DROP TABLE [dbo].[Percentage_Method_Table_O2_SorMFS]
 

SET ANSI_NULLS ON
 

SET QUOTED_IDENTIFIER ON
 

CREATE TABLE [dbo].[Percentage_Method_Table_O2_SorMFS](
	[At_Least] [money] NOT NULL,
	[But_Less_Than] [money] NOT NULL,
	[Tentative_Hold_Amount] [money] NOT NULL,
	[Percentage] [decimal](18, 2) NOT NULL,
	[Threshold] [money] NOT NULL
) ON [PRIMARY]
 

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Social_Security_Tax_Table]') AND type in (N'U'))
DROP TABLE [dbo].[Social_Security_Tax_Table]
 

SET ANSI_NULLS ON
 

SET QUOTED_IDENTIFIER ON
 

CREATE TABLE [dbo].[Social_Security_Tax_Table](
	[Tax_Year] [date] NOT NULL,
	[Tax_Rate] [decimal](18, 2) NOT NULL,
	[Wage_Base_Limit] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
 

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tax_Filing_Status]') AND type in (N'U'))
DROP TABLE [dbo].[Tax_Filing_Status]
 

SET ANSI_NULLS ON
 

SET QUOTED_IDENTIFIER ON
 

CREATE TABLE [dbo].[Tax_Filing_Status](
	[Filing_Type_Id] [int] NOT NULL,
	[Filing_Type] [varchar](50) NOT NULL
) ON [PRIMARY]
 


INSERT [dbo].[Medicare_Tax_Table] ([Tax_Year], [Tax_Rate], [Additional_Tax_Rate], [Threshold_Wage]) VALUES (CAST(N'2023-01-01' AS Date), CAST(1.45 AS Decimal(18, 2)), CAST(0.90 AS Decimal(18, 2)), CAST(200000.00 AS Decimal(18, 2)))
 
INSERT [dbo].[Percentage_Method_Table_O1_HoH] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (0.0000, 10800.0000, 0.0000, CAST(0.00 AS Decimal(18, 2)), 0.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_HoH] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (10800.0000, 25450.0000, 0.0000, CAST(10.00 AS Decimal(18, 2)), 10800.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_HoH] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (25450.0000, 66700.0000, 1465.0000, CAST(12.00 AS Decimal(18, 2)), 25450.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_HoH] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (66700.0000, 99850.0000, 6415.0000, CAST(22.00 AS Decimal(18, 2)), 66700.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_HoH] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (99850.0000, 180850.0000, 13708.0000, CAST(24.00 AS Decimal(18, 2)), 99850.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_HoH] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (180850.0000, 226750.0000, 33148.0000, CAST(32.00 AS Decimal(18, 2)), 180850.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_HoH] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (226750.0000, 550700.0000, 47836.0000, CAST(35.00 AS Decimal(18, 2)), 226750.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_HoH] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (550700.0000, 100000000.0000, 161218.5000, CAST(37.00 AS Decimal(18, 2)), 550700.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_MFJ] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (0.0000, 13000.0000, 0.0000, CAST(0.00 AS Decimal(18, 2)), 0.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_MFJ] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (13000.0000, 33550.0000, 0.0000, CAST(10.00 AS Decimal(18, 2)), 13000.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_MFJ] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (33550.0000, 96550.0000, 2055.0000, CAST(12.00 AS Decimal(18, 2)), 33550.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_MFJ] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (96550.0000, 191150.0000, 9615.0000, CAST(22.00 AS Decimal(18, 2)), 96550.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_MFJ] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (191150.0000, 353100.0000, 30427.0000, CAST(24.00 AS Decimal(18, 2)), 191150.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_MFJ] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (353100.0000, 444900.0000, 69295.0000, CAST(32.00 AS Decimal(18, 2)), 353100.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_MFJ] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (444900.0000, 660850.0000, 98671.0000, CAST(35.00 AS Decimal(18, 2)), 444900.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_MFJ] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (660850.0000, 100000000.0000, 174253.5000, CAST(37.00 AS Decimal(18, 2)), 660850.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_SorMFS] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (0.0000, 4350.0000, 0.0000, CAST(0.00 AS Decimal(18, 2)), 0.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_SorMFS] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (4350.0000, 14625.0000, 0.0000, CAST(10.00 AS Decimal(18, 2)), 4350.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_SorMFS] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (14625.0000, 46125.0000, 1027.5000, CAST(12.00 AS Decimal(18, 2)), 14625.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_SorMFS] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (46125.0000, 93425.0000, 4807.5000, CAST(22.00 AS Decimal(18, 2)), 46125.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_SorMFS] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (93425.0000, 174400.0000, 15213.5000, CAST(24.00 AS Decimal(18, 2)), 93425.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_SorMFS] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (174400.0000, 220300.0000, 34647.5000, CAST(32.00 AS Decimal(18, 2)), 174400.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_SorMFS] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (220300.0000, 544250.0000, 49335.5000, CAST(35.00 AS Decimal(18, 2)), 220300.0000)
 
INSERT [dbo].[Percentage_Method_Table_O1_SorMFS] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (544250.0000, 100000000.0000, 162718.0000, CAST(37.00 AS Decimal(18, 2)), 544250.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_HoH] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (0.0000, 9700.0000, 0.0000, CAST(0.00 AS Decimal(18, 2)), 0.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_HoH] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (9700.0000, 17025.0000, 0.0000, CAST(10.00 AS Decimal(18, 2)), 9700.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_HoH] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (17025.0000, 37650.0000, 732.5000, CAST(12.00 AS Decimal(18, 2)), 17025.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_HoH] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (37650.0000, 54225.0000, 3207.5000, CAST(22.00 AS Decimal(18, 2)), 37650.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_HoH] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (54225.0000, 94725.0000, 6854.0000, CAST(24.00 AS Decimal(18, 2)), 54225.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_HoH] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (94725.0000, 117675.0000, 16574.0000, CAST(32.00 AS Decimal(18, 2)), 94725.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_HoH] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (117675.0000, 279650.0000, 23918.0000, CAST(35.00 AS Decimal(18, 2)), 117675.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_HoH] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (279650.0000, 100000000.0000, 80609.2500, CAST(37.00 AS Decimal(18, 2)), 279650.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_MFJ] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (0.0000, 12950.0000, 0.0000, CAST(0.00 AS Decimal(18, 2)), 0.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_MFJ] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (12950.0000, 23225.0000, 0.0000, CAST(10.00 AS Decimal(18, 2)), 12950.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_MFJ] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (23225.0000, 54725.0000, 1027.5000, CAST(12.00 AS Decimal(18, 2)), 23225.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_MFJ] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (54725.0000, 102025.0000, 4807.5000, CAST(22.00 AS Decimal(18, 2)), 54725.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_MFJ] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (102025.0000, 183000.0000, 15213.5000, CAST(24.00 AS Decimal(18, 2)), 102025.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_MFJ] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (183000.0000, 228900.0000, 34647.5000, CAST(32.00 AS Decimal(18, 2)), 183000.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_MFJ] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (228900.0000, 336875.0000, 49335.5000, CAST(35.00 AS Decimal(18, 2)), 228900.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_MFJ] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (336875.0000, 100000000.0000, 87126.7500, CAST(37.00 AS Decimal(18, 2)), 336875.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_SorMFS] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (0.0000, 6475.0000, 0.0000, CAST(0.00 AS Decimal(18, 2)), 0.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_SorMFS] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (6475.0000, 11613.0000, 0.0000, CAST(10.00 AS Decimal(18, 2)), 6475.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_SorMFS] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (11613.0000, 27363.0000, 513.7500, CAST(12.00 AS Decimal(18, 2)), 11613.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_SorMFS] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (27363.0000, 51013.0000, 2403.7500, CAST(22.00 AS Decimal(18, 2)), 27363.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_SorMFS] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (51013.0000, 91500.0000, 7606.7500, CAST(24.00 AS Decimal(18, 2)), 51013.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_SorMFS] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (91500.0000, 114450.0000, 17323.7500, CAST(32.00 AS Decimal(18, 2)), 91500.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_SorMFS] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (114450.0000, 276425.0000, 24667.7500, CAST(35.00 AS Decimal(18, 2)), 114450.0000)
 
INSERT [dbo].[Percentage_Method_Table_O2_SorMFS] ([At_Least], [But_Less_Than], [Tentative_Hold_Amount], [Percentage], [Threshold]) VALUES (276425.0000, 100000000.0000, 81359.0000, CAST(37.00 AS Decimal(18, 2)), 276425.0000)
 
INSERT [dbo].[Social_Security_Tax_Table] ([Tax_Year], [Tax_Rate], [Wage_Base_Limit]) VALUES (CAST(N'2023-01-01' AS Date), CAST(6.20 AS Decimal(18, 2)), CAST(147000.00 AS Decimal(18, 2)))
 
INSERT [dbo].[Tax_Filing_Status] ([Filing_Type_Id], [Filing_Type]) VALUES (1, N'MarriedFilingJointly')
 
INSERT [dbo].[Tax_Filing_Status] ([Filing_Type_Id], [Filing_Type]) VALUES (2, N'SingleOrMarriedFilingSingle')
 
INSERT [dbo].[Tax_Filing_Status] ([Filing_Type_Id], [Filing_Type]) VALUES (3, N'HeadOfHousehold')