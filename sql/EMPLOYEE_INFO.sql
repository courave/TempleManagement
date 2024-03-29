USE [TEMPLE_CWCS]
GO
/****** Object:  Table [dbo].[EMPLOYEE_INFO]    Script Date: 05/29/2013 16:53:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLOYEE_INFO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[XINGMING] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[NICHENG] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[SEX] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[BIRTH_YEARMONTH] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[JIGUAN] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[MINZU] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[EMP_TYPE] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[GUOMINXUELI] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[SHENFENZHENG] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[DIANHUA] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[YOUBIAN] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[SHEHUIZHIWU] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[XIANZAIZHIWU] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[EMAIL] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[HUJISUOZAIDI] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[JOIN_TIME] [datetime] NULL,
	[XINGQUAIHAO] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[TECHANG] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[CENGYONGMING] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[JIAOMING] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[CHUJIASIYUAN] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[SHEOUJIESHI] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[TIDUSHI] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[JIAONEIZHIWU] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[CHUJIA_TIME] [datetime] NULL,
	[SHOUJIE_TIME] [datetime] NULL,
	[JIAOZHIZHENGSHU] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ZONGJIAOXUELI] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[GERENJIANLI] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[JIANLI_FILEID] [int] NULL,
	[SHEHUIGUANXI] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[JIANGCHENG] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[BEIZHU] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[AVATAR_ID] [int] NULL,
	[SHENFEN_FRONT_ID] [int] NULL,
	[SHENFEN_BACK_ID] [int] NULL,
	[LISI_TIME] [datetime] NULL,
 CONSTRAINT [PK_EMPLOYEE_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
