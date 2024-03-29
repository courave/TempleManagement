USE [CWCS_OL]
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_EMPLOYEES_STATUS]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLOYEES]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EMPLOYEES_STATUS]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EMPLOYEES] DROP CONSTRAINT [DF_EMPLOYEES_STATUS]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_SHIZHU_INFO_SHIZHU_TUIXIN]') AND parent_object_id = OBJECT_ID(N'[dbo].[SHIZHU_INFO]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SHIZHU_INFO_SHIZHU_TUIXIN]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SHIZHU_INFO] DROP CONSTRAINT [DF_SHIZHU_INFO_SHIZHU_TUIXIN]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_tbFAHUA_HAS_PRINT]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbFAHUA]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_tbFAHUA_HAS_PRINT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tbFAHUA] DROP CONSTRAINT [DF_tbFAHUA_HAS_PRINT]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_tbSANSHI_HAS_PRINT]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbSANSHI]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_tbSANSHI_HAS_PRINT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tbSANSHI] DROP CONSTRAINT [DF_tbSANSHI_HAS_PRINT]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_tbWANGSHENG_HAS_PRINT]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbWANGSHENG]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_tbWANGSHENG_HAS_PRINT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tbWANGSHENG] DROP CONSTRAINT [DF_tbWANGSHENG_HAS_PRINT]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_tbYANSHENG_HAS_PRINT]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbYANSHENG]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_tbYANSHENG_HAS_PRINT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tbYANSHENG] DROP CONSTRAINT [DF_tbYANSHENG_HAS_PRINT]
END


End
GO
/****** Object:  ForeignKey [FK_File_FileMgr]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_File_FileMgr]') AND parent_object_id = OBJECT_ID(N'[dbo].[File]'))
ALTER TABLE [dbo].[File] DROP CONSTRAINT [FK_File_FileMgr]
GO
/****** Object:  ForeignKey [FK_Stock_Goods]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Stock_Goods]') AND parent_object_id = OBJECT_ID(N'[dbo].[Stock]'))
ALTER TABLE [dbo].[Stock] DROP CONSTRAINT [FK_Stock_Goods]
GO
/****** Object:  ForeignKey [FK_StockTrans_Goods]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StockTrans_Goods]') AND parent_object_id = OBJECT_ID(N'[dbo].[StockTrans]'))
ALTER TABLE [dbo].[StockTrans] DROP CONSTRAINT [FK_StockTrans_Goods]
GO
/****** Object:  Table [dbo].[File]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[File]') AND type in (N'U'))
DROP TABLE [dbo].[File]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Stock]') AND type in (N'U'))
DROP TABLE [dbo].[Stock]
GO
/****** Object:  Table [dbo].[StockTrans]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StockTrans]') AND type in (N'U'))
DROP TABLE [dbo].[StockTrans]
GO
/****** Object:  Table [dbo].[tbFAHUA]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbFAHUA]') AND type in (N'U'))
DROP TABLE [dbo].[tbFAHUA]
GO
/****** Object:  Table [dbo].[tbFOSHI]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbFOSHI]') AND type in (N'U'))
DROP TABLE [dbo].[tbFOSHI]
GO
/****** Object:  Table [dbo].[tbSANSHI]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbSANSHI]') AND type in (N'U'))
DROP TABLE [dbo].[tbSANSHI]
GO
/****** Object:  Table [dbo].[tbWANGSHENG]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbWANGSHENG]') AND type in (N'U'))
DROP TABLE [dbo].[tbWANGSHENG]
GO
/****** Object:  Table [dbo].[tbYANSHENG]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbYANSHENG]') AND type in (N'U'))
DROP TABLE [dbo].[tbYANSHENG]
GO
/****** Object:  Table [dbo].[ADMIN]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADMIN]') AND type in (N'U'))
DROP TABLE [dbo].[ADMIN]
GO
/****** Object:  Table [dbo].[CAHNGNIAN_GONGWEI]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAHNGNIAN_GONGWEI]') AND type in (N'U'))
DROP TABLE [dbo].[CAHNGNIAN_GONGWEI]
GO
/****** Object:  Table [dbo].[CHANGNIAN_TYPE]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CHANGNIAN_TYPE]') AND type in (N'U'))
DROP TABLE [dbo].[CHANGNIAN_TYPE]
GO
/****** Object:  Table [dbo].[EMPLOYEES]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EMPLOYEES]') AND type in (N'U'))
DROP TABLE [dbo].[EMPLOYEES]
GO
/****** Object:  Table [dbo].[FASHI_FOSHI]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FASHI_FOSHI]') AND type in (N'U'))
DROP TABLE [dbo].[FASHI_FOSHI]
GO
/****** Object:  Table [dbo].[FASHI_INFO]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FASHI_INFO]') AND type in (N'U'))
DROP TABLE [dbo].[FASHI_INFO]
GO
/****** Object:  Table [dbo].[FileMgr]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FileMgr]') AND type in (N'U'))
DROP TABLE [dbo].[FileMgr]
GO
/****** Object:  Table [dbo].[FOSHI_JIESONG]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FOSHI_JIESONG]') AND type in (N'U'))
DROP TABLE [dbo].[FOSHI_JIESONG]
GO
/****** Object:  Table [dbo].[FOSHI_SHENG]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FOSHI_SHENG]') AND type in (N'U'))
DROP TABLE [dbo].[FOSHI_SHENG]
GO
/****** Object:  Table [dbo].[GONGDE_TYPE]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GONGDE_TYPE]') AND type in (N'U'))
DROP TABLE [dbo].[GONGDE_TYPE]
GO
/****** Object:  Table [dbo].[Goods]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Goods]') AND type in (N'U'))
DROP TABLE [dbo].[Goods]
GO
/****** Object:  Table [dbo].[LEAVE_RECORD]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LEAVE_RECORD]') AND type in (N'U'))
DROP TABLE [dbo].[LEAVE_RECORD]
GO
/****** Object:  Table [dbo].[OVERTIME_RECORD]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OVERTIME_RECORD]') AND type in (N'U'))
DROP TABLE [dbo].[OVERTIME_RECORD]
GO
/****** Object:  Table [dbo].[PrintConfig]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintConfig]') AND type in (N'U'))
DROP TABLE [dbo].[PrintConfig]
GO
/****** Object:  Table [dbo].[PrintTemplate]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintTemplate]') AND type in (N'U'))
DROP TABLE [dbo].[PrintTemplate]
GO
/****** Object:  Table [dbo].[SANSHI_TYPE]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SANSHI_TYPE]') AND type in (N'U'))
DROP TABLE [dbo].[SANSHI_TYPE]
GO
/****** Object:  Table [dbo].[SHIZHU_GONGDE]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SHIZHU_GONGDE]') AND type in (N'U'))
DROP TABLE [dbo].[SHIZHU_GONGDE]
GO
/****** Object:  Table [dbo].[SHIZHU_INFO]    Script Date: 05/03/2012 18:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SHIZHU_INFO]') AND type in (N'U'))
DROP TABLE [dbo].[SHIZHU_INFO]
GO
/****** Object:  Table [dbo].[SHIZHU_INFO]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SHIZHU_INFO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SHIZHU_INFO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SHIZHU_ID] [nvarchar](255) NULL,
	[SHIZHU_NAME] [nvarchar](255) NULL,
	[SHIZHU_SEX] [nvarchar](255) NULL,
	[SHIZHU_HOME_ADDR] [nvarchar](255) NULL,
	[SHIZHU_HOME_ZIP] [nvarchar](255) NULL,
	[SHIZHU_HOME_TEL] [nvarchar](255) NULL,
	[SHIZHU_MOBILE] [nvarchar](255) NULL,
	[SHIZHU_TYPE] [nvarchar](255) NULL,
	[SHIZHU_EMAIL] [nvarchar](255) NULL,
	[SHIZHU_EDU] [nvarchar](255) NULL,
	[SHIZHU_NATIONALITY] [nvarchar](255) NULL,
	[SHIZHU_CITY] [nvarchar](255) NULL,
	[SHIZHU_DISTRICT] [nvarchar](255) NULL,
	[SHIZHU_IDCODE] [nvarchar](255) NULL,
	[SHIZHU_BIRTHDAY] [nvarchar](255) NULL,
	[SHIZHU_BIRTH_TYPE] [nvarchar](255) NULL,
	[SHIZHU_LUNAR_DAY] [nvarchar](255) NULL,
	[SHIZHU_TUIXIN] [nvarchar](255) NULL,
	[SHIZHU_SANGUI] [nvarchar](255) NULL,
	[SHIZHU_WUJIE] [nvarchar](255) NULL,
	[BIRTH_MONTH] [int] NULL,
	[BIRTH_DAY] [int] NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[SHIZHU_GONGDE]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SHIZHU_GONGDE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SHIZHU_GONGDE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DONATE_NO] [nvarchar](255) NULL,
	[DONATE_TYPE] [nvarchar](255) NULL,
	[DONATE_MONEY] [real] NULL,
	[INVOICE_NO] [nvarchar](255) NULL,
	[DONATE_DATE] [datetime] NULL,
	[LOG_USER] [nvarchar](255) NULL,
	[LOG_TIME] [datetime] NULL,
	[GONGDE_FANGMING] [nvarchar](255) NULL,
	[DONATE_DESCRIPTION] [text] NULL,
	[DONATE_COMMENTS] [text] NULL,
	[SHIZHU_ID] [nvarchar](255) NULL,
	[FANGWEI] [nvarchar](255) NULL,
	[ROW] [int] NULL,
	[COL] [nvarchar](max) NULL,
	[MONEY_TYPE] [nvarchar](255) NULL,
 CONSTRAINT [PK_SHIZHU_GONGDE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[SANSHI_TYPE]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SANSHI_TYPE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SANSHI_TYPE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FANGWEI] [nvarchar](255) NULL,
	[ROWS] [int] NULL,
	[COLS] [nvarchar](max) NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PrintTemplate]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintTemplate]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PrintTemplate](
	[tid] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[value] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_PrintTemplate] PRIMARY KEY CLUSTERED 
(
	[tid] ASC,
	[name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PrintConfig]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintConfig]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PrintConfig](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[deftemplate] [bit] NOT NULL,
 CONSTRAINT [PK_PrintConfig] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[OVERTIME_RECORD]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OVERTIME_RECORD]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OVERTIME_RECORD](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OVERTIME_REASON] [nvarchar](255) NULL,
	[OVERTIME_FROM] [datetime] NOT NULL,
	[OVERTIME_TO] [datetime] NOT NULL,
	[EMPLOYEE_ID] [int] NOT NULL,
	[REQUEST_TIME] [datetime] NOT NULL,
	[OVERTIME_TYPE] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_OVERTIME_RECORD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[LEAVE_RECORD]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LEAVE_RECORD]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LEAVE_RECORD](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LEAVE_REASON] [nvarchar](255) NULL,
	[LEAVE_FROM] [datetime] NOT NULL,
	[LEAVE_TO] [datetime] NOT NULL,
	[EMPLOYEE_ID] [int] NOT NULL,
	[REQUEST_TIME] [datetime] NOT NULL,
	[LEAVE_TYPE] [nvarchar](255) NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Goods]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Goods]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Goods](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GoodsNo] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[BarCode] [nvarchar](50) NULL,
	[Category] [nvarchar](255) NULL,
	[Specification] [nvarchar](255) NULL,
	[Unit] [nvarchar](50) NULL,
	[Remark] [nvarchar](255) NULL,
 CONSTRAINT [PK_Goods] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[GONGDE_TYPE]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GONGDE_TYPE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GONGDE_TYPE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TYPE] [nvarchar](255) NOT NULL,
	[FANGWEI] [nvarchar](255) NULL,
	[ROWS] [int] NULL,
	[COLS] [nvarchar](500) NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[FOSHI_SHENG]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FOSHI_SHENG]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FOSHI_SHENG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FoshiID] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[JZ1] [nvarchar](255) NULL,
	[JZ2] [nvarchar](255) NULL,
	[JZ3] [nvarchar](255) NULL,
	[JZ4] [nvarchar](255) NULL,
	[YS1] [nvarchar](255) NULL,
	[YS2] [nvarchar](255) NULL,
	[YS3] [nvarchar](255) NULL,
	[YS4] [nvarchar](255) NULL,
 CONSTRAINT [PK_FOSHI_SHENG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[FOSHI_JIESONG]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FOSHI_JIESONG]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FOSHI_JIESONG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FoshiID] [int] NOT NULL,
	[Driver] [nvarchar](50) NULL,
	[LicPlate] [nvarchar](50) NULL,
	[PeopleCount] [int] NULL,
	[Cost] [nvarchar](50) NULL,
 CONSTRAINT [PK_FOSHI_JIESONG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[FileMgr]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FileMgr]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FileMgr](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FileNo] [nvarchar](50) NULL,
	[FileTitle] [nvarchar](50) NULL,
	[LogUser] [nvarchar](50) NULL,
	[LogTime] [datetime] NULL,
	[Info] [nvarchar](max) NULL,
 CONSTRAINT [PK_FileMgr] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[FASHI_INFO]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FASHI_INFO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FASHI_INFO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FAHAO] [nvarchar](255) NULL,
	[ZHIWEI] [nvarchar](255) NULL,
	[FASHI_NAME] [nvarchar](255) NULL,
 CONSTRAINT [PK_FASHI_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[FASHI_FOSHI]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FASHI_FOSHI]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FASHI_FOSHI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FAHAO] [nvarchar](255) NULL,
	[FOSHI_ID] [int] NOT NULL,
	[DANZI] [nvarchar](255) NULL,
	[POSITION] [nvarchar](255) NULL,
 CONSTRAINT [PK_FASHI_FOSHI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[EMPLOYEES]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EMPLOYEES]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EMPLOYEES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NATIVE_NAME] [nvarchar](255) NULL,
	[TYPE] [nvarchar](255) NULL,
	[SEX] [bit] NULL,
	[PHONE] [nvarchar](255) NULL,
	[EMAIL] [nvarchar](255) NULL,
	[STATUS] [bit] NULL,
	[BIRTH_MONTH] [int] NULL,
	[BIRTH_YEAR] [int] NULL,
	[HOME_ADDR] [nvarchar](max) NULL,
	[DEGREE] [nvarchar](255) NULL,
	[HOBBY] [nvarchar](255) NULL,
	[ABILITY] [nvarchar](255) NULL,
	[HEAD_IMG] [image] NULL,
	[COMMENTS] [nvarchar](max) NULL,
	[NICK_NAME] [nvarchar](255) NULL,
	[FAHAO] [nvarchar](255) NULL,
	[HIRE_DATE] [datetime] NULL,
	[QUIT_DATE] [datetime] NULL,
	[JIGUAN] [nvarchar](255) NULL,
	[MINZU] [nvarchar](255) NULL,
	[CHUJIA_DATE] [datetime] NULL,
	[CHUJIA_TEMPLE] [nvarchar](255) NULL,
	[TIDUSHI] [nvarchar](255) NULL,
	[SHOUJIE_DATE] [datetime] NULL,
	[SHOUJIESHI] [nvarchar](255) NULL,
	[ID_NO] [nvarchar](255) NULL,
	[ZIP_CODE] [nvarchar](255) NULL,
	[JIAONEI_POSITION] [nvarchar](255) NULL,
	[SHEHUI_POSITION] [nvarchar](255) NULL,
	[NOW_POSITION] [nvarchar](255) NULL,
	[RESUME] [nvarchar](max) NULL,
	[MAIN_SOCIAL] [nvarchar](max) NULL,
	[JIANGCHENG] [nvarchar](max) NULL,
	[ID_COPY_FRONT] [image] NULL,
	[ID_COPY_BACK] [image] NULL,
	[ZDEGREE] [nvarchar](255) NULL,
	[ONAME] [nvarchar](255) NULL,
	[CERT] [nvarchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[CHANGNIAN_TYPE]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CHANGNIAN_TYPE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CHANGNIAN_TYPE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FANGWEI] [nvarchar](255) NULL,
	[ROWS] [int] NULL,
	[COLS] [nvarchar](max) NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[CAHNGNIAN_GONGWEI]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAHNGNIAN_GONGWEI]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CAHNGNIAN_GONGWEI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LOD_DATE] [datetime] NULL,
	[BIANHAO] [nvarchar](255) NULL,
	[YUAN] [nvarchar](255) NULL,
	[PAI] [int] NULL,
	[ZUO] [int] NULL,
	[ZHIFUXIN1] [nvarchar](255) NULL,
	[ZHIFUXIN2] [nvarchar](255) NULL,
	[ZHIFUXIN3] [nvarchar](255) NULL,
	[ZHIFUXIN4] [nvarchar](255) NULL,
	[LIANXIREN] [nvarchar](255) NULL,
	[DIANHUA] [nvarchar](255) NULL,
	[SHOUJI] [nvarchar](255) NULL,
	[YOUBIAN] [nvarchar](255) NULL,
	[DIZHI] [nvarchar](255) NULL,
	[SHEHE] [nvarchar](255) NULL,
	[CHAOJIAN] [nvarchar](255) NULL,
	[FUJIAN1] [nvarchar](255) NULL,
	[FUJIAN2] [nvarchar](255) NULL,
	[FUJIAN3] [nvarchar](255) NULL,
	[YANGSHANG1] [nvarchar](255) NULL,
	[YANGSHANG2] [nvarchar](255) NULL,
	[YANGSHANG3] [nvarchar](255) NULL,
	[YANGSHANG4] [nvarchar](255) NULL,
	[YANGSHANG5] [nvarchar](255) NULL,
	[YANGSHANG6] [nvarchar](255) NULL,
	[TYPE] [nvarchar](255) NULL,
	[LOG_USER] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ADMIN]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADMIN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ADMIN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERNAME] [nvarchar](50) NULL,
	[PASSWORD] [nvarchar](50) NULL,
	[PERMISSION] [text] NULL,
 CONSTRAINT [PK_ADMIN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbYANSHENG]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbYANSHENG]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbYANSHENG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LOG_TIME] [datetime] NULL,
	[LOG_USER] [nvarchar](255) NULL,
	[FAHUI_NAME] [nvarchar](255) NULL,
	[ZHUZHAO1] [nvarchar](255) NULL,
	[ZHUZHAO2] [nvarchar](255) NULL,
	[ZHUZHAO3] [nvarchar](255) NULL,
	[ZHUZHAO4] [nvarchar](255) NULL,
	[ZUOCI] [int] NOT NULL,
	[ZIHAO] [nvarchar](255) NULL,
	[HAS_PRINT] [bit] NULL,
 CONSTRAINT [PK_YANSHENG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbWANGSHENG]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbWANGSHENG]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbWANGSHENG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LOG_USER] [nvarchar](255) NULL,
	[LOG_TIME] [nvarchar](255) NULL,
	[FAHUI_NAME] [nvarchar](255) NULL,
	[ZUOCI] [int] NULL,
	[ZIHAO] [nvarchar](255) NULL,
	[JIEYIN1] [nvarchar](255) NULL,
	[JIEYIN2] [nvarchar](255) NULL,
	[JIEYIN3] [nvarchar](255) NULL,
	[JIEYIN4] [nvarchar](255) NULL,
	[YANGSHANG1] [nvarchar](255) NULL,
	[YANGSHANG2] [nvarchar](255) NULL,
	[YANGSHANG3] [nvarchar](255) NULL,
	[YANGSHANG4] [nvarchar](255) NULL,
	[YANGSHANG5] [nvarchar](255) NULL,
	[YANGSHANG6] [nvarchar](255) NULL,
	[HAS_PRINT] [bit] NULL,
 CONSTRAINT [PK_tbWANGSHANG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbSANSHI]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbSANSHI]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbSANSHI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SANSHI_NO] [nvarchar](255) NULL,
	[LOG_USER] [nvarchar](255) NULL,
	[LOG_TIME] [nvarchar](255) NULL,
	[FAHUI_NAME] [nvarchar](255) NULL,
	[ZUOCI] [int] NULL,
	[ZIHAO] [nvarchar](255) NULL,
	[JIEYIN1] [nvarchar](255) NULL,
	[JIEYIN2] [nvarchar](255) NULL,
	[JIEYIN3] [nvarchar](255) NULL,
	[JIEYIN4] [nvarchar](255) NULL,
	[YANGSHANG1] [nvarchar](255) NULL,
	[YANGSHANG2] [nvarchar](255) NULL,
	[YANGSHANG3] [nvarchar](255) NULL,
	[YANGSHANG4] [nvarchar](255) NULL,
	[YANGSHANG5] [nvarchar](255) NULL,
	[YANGSHANG6] [nvarchar](255) NULL,
	[EXPIRED_TIME] [datetime] NULL,
	[SHIZHU_BIANHAO] [nvarchar](255) NULL,
	[FANGWEI] [nvarchar](255) NULL,
	[ROW] [int] NULL,
	[COL] [int] NULL,
	[HAS_PRINT] [bit] NULL,
 CONSTRAINT [PK_tbSANSHI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbFOSHI]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbFOSHI]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbFOSHI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ZHAIZHU_NAME] [nvarchar](255) NULL,
	[FOSHI_DATETIME] [datetime] NULL,
	[JIESONG_ADDR] [nvarchar](255) NULL,
	[TEL] [nvarchar](255) NULL,
	[LOG_USER] [nvarchar](255) NULL,
	[LOG_TIME] [datetime] NULL,
	[COMMENT] [nvarchar](255) NULL,
 CONSTRAINT [PK_tbFOSHI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbFAHUA]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbFAHUA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbFAHUA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FAHUA_NO] [nvarchar](255) NULL,
	[LOG_TIME] [datetime] NULL,
	[LOG_USER] [nvarchar](255) NULL,
	[FAHUI_NAME] [nvarchar](255) NULL,
	[ZHUZHAO1] [nvarchar](255) NULL,
	[ZHUZHAO2] [nvarchar](255) NULL,
	[ZHUZHAO3] [nvarchar](255) NULL,
	[ZHUZHAO4] [nvarchar](255) NULL,
	[ZUOCI] [int] NULL,
	[ZIHAO] [nvarchar](255) NULL,
	[EXPIRED_TIME] [datetime] NULL,
	[SHIZHU_BIANHAO] [nvarchar](255) NULL,
	[HAS_PRINT] [bit] NULL,
 CONSTRAINT [PK_FAHUA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[StockTrans]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StockTrans]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StockTrans](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[StockId] [nvarchar](50) NOT NULL,
	[GoodsId] [int] NOT NULL,
	[BillNo] [nvarchar](50) NULL,
	[EditTime] [datetime] NULL,
	[Amount] [decimal](18, 4) NULL,
	[TotalPrice] [decimal](18, 4) NULL,
	[FromTo] [nvarchar](255) NULL,
	[Manager] [nvarchar](50) NULL,
	[Operator] [nvarchar](50) NULL,
	[Remark] [nvarchar](255) NULL,
	[RUKU_DATE] [datetime] NULL,
	[LIANXUHAO] [nvarchar](255) NULL,
	[FAPIAO] [nvarchar](255) NULL,
	[JIAOKUSHU] [decimal](18, 4) NULL,
	[CAIWU] [nvarchar](255) NULL,
	[JIZHANG] [nvarchar](255) NULL,
	[BAOGUAN] [nvarchar](255) NULL,
	[YANSHOU] [nvarchar](255) NULL,
	[DANJIA] [decimal](18, 4) NULL,
 CONSTRAINT [PK_StockTrans] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Stock]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Stock](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StockId] [nvarchar](50) NOT NULL,
	[GoodsId] [int] NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[File]    Script Date: 05/03/2012 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[File]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[File](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MgrId] [int] NOT NULL,
	[FileName] [nvarchar](260) NOT NULL,
	[Data] [image] NULL,
 CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Default [DF_EMPLOYEES_STATUS]    Script Date: 05/03/2012 18:17:45 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_EMPLOYEES_STATUS]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLOYEES]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EMPLOYEES_STATUS]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EMPLOYEES] ADD  CONSTRAINT [DF_EMPLOYEES_STATUS]  DEFAULT ((1)) FOR [STATUS]
END


End
GO
/****** Object:  Default [DF_SHIZHU_INFO_SHIZHU_TUIXIN]    Script Date: 05/03/2012 18:17:45 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_SHIZHU_INFO_SHIZHU_TUIXIN]') AND parent_object_id = OBJECT_ID(N'[dbo].[SHIZHU_INFO]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SHIZHU_INFO_SHIZHU_TUIXIN]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SHIZHU_INFO] ADD  CONSTRAINT [DF_SHIZHU_INFO_SHIZHU_TUIXIN]  DEFAULT (N'否') FOR [SHIZHU_TUIXIN]
END


End
GO
/****** Object:  Default [DF_tbFAHUA_HAS_PRINT]    Script Date: 05/03/2012 18:17:45 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_tbFAHUA_HAS_PRINT]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbFAHUA]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_tbFAHUA_HAS_PRINT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tbFAHUA] ADD  CONSTRAINT [DF_tbFAHUA_HAS_PRINT]  DEFAULT ((0)) FOR [HAS_PRINT]
END


End
GO
/****** Object:  Default [DF_tbSANSHI_HAS_PRINT]    Script Date: 05/03/2012 18:17:45 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_tbSANSHI_HAS_PRINT]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbSANSHI]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_tbSANSHI_HAS_PRINT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tbSANSHI] ADD  CONSTRAINT [DF_tbSANSHI_HAS_PRINT]  DEFAULT ((0)) FOR [HAS_PRINT]
END


End
GO
/****** Object:  Default [DF_tbWANGSHENG_HAS_PRINT]    Script Date: 05/03/2012 18:17:45 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_tbWANGSHENG_HAS_PRINT]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbWANGSHENG]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_tbWANGSHENG_HAS_PRINT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tbWANGSHENG] ADD  CONSTRAINT [DF_tbWANGSHENG_HAS_PRINT]  DEFAULT ((0)) FOR [HAS_PRINT]
END


End
GO
/****** Object:  Default [DF_tbYANSHENG_HAS_PRINT]    Script Date: 05/03/2012 18:17:45 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_tbYANSHENG_HAS_PRINT]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbYANSHENG]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_tbYANSHENG_HAS_PRINT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tbYANSHENG] ADD  CONSTRAINT [DF_tbYANSHENG_HAS_PRINT]  DEFAULT ((0)) FOR [HAS_PRINT]
END


End
GO
/****** Object:  ForeignKey [FK_File_FileMgr]    Script Date: 05/03/2012 18:17:45 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_File_FileMgr]') AND parent_object_id = OBJECT_ID(N'[dbo].[File]'))
ALTER TABLE [dbo].[File]  WITH CHECK ADD  CONSTRAINT [FK_File_FileMgr] FOREIGN KEY([MgrId])
REFERENCES [dbo].[FileMgr] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_File_FileMgr]') AND parent_object_id = OBJECT_ID(N'[dbo].[File]'))
ALTER TABLE [dbo].[File] CHECK CONSTRAINT [FK_File_FileMgr]
GO
/****** Object:  ForeignKey [FK_Stock_Goods]    Script Date: 05/03/2012 18:17:45 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Stock_Goods]') AND parent_object_id = OBJECT_ID(N'[dbo].[Stock]'))
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Goods] FOREIGN KEY([GoodsId])
REFERENCES [dbo].[Goods] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Stock_Goods]') AND parent_object_id = OBJECT_ID(N'[dbo].[Stock]'))
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Goods]
GO
/****** Object:  ForeignKey [FK_StockTrans_Goods]    Script Date: 05/03/2012 18:17:45 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StockTrans_Goods]') AND parent_object_id = OBJECT_ID(N'[dbo].[StockTrans]'))
ALTER TABLE [dbo].[StockTrans]  WITH CHECK ADD  CONSTRAINT [FK_StockTrans_Goods] FOREIGN KEY([GoodsId])
REFERENCES [dbo].[Goods] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StockTrans_Goods]') AND parent_object_id = OBJECT_ID(N'[dbo].[StockTrans]'))
ALTER TABLE [dbo].[StockTrans] CHECK CONSTRAINT [FK_StockTrans_Goods]
GO
