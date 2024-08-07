USE [MiniBankingManagementSystem]
GO
/****** Object:  Table [dbo].[Tbl_Account]    Script Date: 6/30/2024 2:12:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Account](
	[AccountId] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountNo] [nvarchar](50) NOT NULL,
	[Balance] [decimal](20, 2) NOT NULL,
	[AccountLevel] [decimal](18, 1) NOT NULL,
	[CustomerCode] [nvarchar](50) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[StateCode] [nvarchar](50) NOT NULL,
	[TownshipCode] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Deposit]    Script Date: 6/30/2024 2:12:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Deposit](
	[DepositId] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountNo] [nvarchar](50) NOT NULL,
	[Amount] [decimal](20, 2) NOT NULL,
	[DepositDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Deposit] PRIMARY KEY CLUSTERED 
(
	[DepositId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_State]    Script Date: 6/30/2024 2:12:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_State](
	[StateId] [bigint] NOT NULL,
	[StateCode] [nvarchar](50) NOT NULL,
	[StateName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Township]    Script Date: 6/30/2024 2:12:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Township](
	[TownshipId] [bigint] NOT NULL,
	[TownshipCode] [nvarchar](50) NOT NULL,
	[TownshipName] [nvarchar](50) NOT NULL,
	[StateCode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Township] PRIMARY KEY CLUSTERED 
(
	[TownshipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_TransactionHistory]    Script Date: 6/30/2024 2:12:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_TransactionHistory](
	[TransactionHistoryId] [nvarchar](50) NOT NULL,
	[FromAccountNo] [nvarchar](50) NOT NULL,
	[ToAccountNo] [nvarchar](50) NOT NULL,
	[Amount] [decimal](20, 2) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_TransactionHistory] PRIMARY KEY CLUSTERED 
(
	[TransactionHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Withdraw]    Script Date: 6/30/2024 2:12:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Withdraw](
	[WithDrawId] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountNo] [nvarchar](50) NOT NULL,
	[Amount] [decimal](20, 2) NOT NULL,
	[WithDrawDate] [datetime] NOT NULL,
 CONSTRAINT [PK_WithDraw] PRIMARY KEY CLUSTERED 
(
	[WithDrawId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetTransactionHistoryListByAccountNo]    Script Date: 6/30/2024 2:12:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sp_GetTransactionHistoryListByAccountNo] @FromAccountNo nvarchar(50)
AS
BEGIN
SELECT 
    TH.TransactionHistoryId, 
    TH.Amount, 
    TH.TransactionDate, 
    SenderAccount.CustomerName AS SenderName, 
    ReceiverAccount.CustomerName AS ReceiverName 
FROM 
    [dbo].[Tbl_TransactionHistory] TH
    INNER JOIN [dbo].[Tbl_Account] SenderAccount ON TH.FromAccountNo = SenderAccount.AccountNo
    INNER JOIN [dbo].[Tbl_Account] ReceiverAccount ON TH.ToAccountNo = ReceiverAccount.AccountNo
WHERE 
    TH.FromAccountNo = @FromAccountNo
ORDER BY 
    TH.TransactionDate DESC;

END
GO
