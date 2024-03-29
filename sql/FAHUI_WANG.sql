USE [TEMPLE_CWCS]
GO
/****** Object:  Table [dbo].[FAHUI_WANG]    Script Date: 06/03/2013 14:57:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAHUI_WANG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ZUOCI] [int] NULL,
	[ZIHAO] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[JIEYIN1] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[JIEYIN2] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[JIEYIN3] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[JIEYIN4] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[YANGSHANG1] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[YANGSHANG2] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[YANGSHANG3] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[YANGSHANG4] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[YANGSHANG5] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[YANGSHANG6] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[HAS_PRINT] [bit] NULL,
	[FAHUI_ID] [int] NULL,
 CONSTRAINT [PK_FAHUI_WANG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
