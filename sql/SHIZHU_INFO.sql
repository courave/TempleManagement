USE [TEMPLE_CWCS]
GO
/****** Object:  Table [dbo].[SHIZHU_INFO]    Script Date: 05/30/2013 17:10:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SHIZHU_INFO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BIANHAO] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[XINGMING] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[XINGBIE] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[HOME_ADDR] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[ZIPCODE] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[TELE] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[MOBILE] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[SHIZHU_TYPE] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[EMAIL] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[EDU_BKG] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[GUOJI] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[SHENGSHI] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[QUXIAN] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[SHENFENZHENG] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[BIRTH_TYPE] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[NONGLI_BIRTH] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[GONGLI_BIRTH] [datetime] NULL,
	[TUIXIN] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[SANGUI] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[WUJIE] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_SHIZHU_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
