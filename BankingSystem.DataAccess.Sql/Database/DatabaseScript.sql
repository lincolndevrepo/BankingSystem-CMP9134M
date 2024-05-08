USE [master]
GO
/****** Object:  Database [BankingSystem]    Script Date: 08/05/2024 07:21:58 PM ******/
CREATE DATABASE [BankingSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BankingSystem', FILENAME = N'D:\SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BankingSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BankingSystem_log', FILENAME = N'D:\SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BankingSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BankingSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BankingSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BankingSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BankingSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BankingSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BankingSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BankingSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [BankingSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BankingSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BankingSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BankingSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BankingSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BankingSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BankingSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BankingSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BankingSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BankingSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BankingSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BankingSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BankingSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BankingSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BankingSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BankingSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BankingSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BankingSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [BankingSystem] SET  MULTI_USER 
GO
ALTER DATABASE [BankingSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BankingSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BankingSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BankingSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BankingSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BankingSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BankingSystem] SET QUERY_STORE = OFF
GO
USE [BankingSystem]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 08/05/2024 07:21:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[acc_id] [int] IDENTITY(1,1) NOT NULL,
	[acc_account_number] [varchar](50) NULL,
	[acc_holder_id] [varchar](50) NULL,
	[acc_holder_name] [varchar](50) NULL,
	[acc_holder_dob] [date] NULL,
	[acc_holder_phone] [varchar](50) NULL,
	[acc_holder_address_door] [varchar](150) NULL,
	[acc_holder_address_street] [varchar](150) NULL,
	[acc_holder_address_city] [varchar](150) NULL,
	[acc_holder_address_post_code] [varchar](15) NULL,
	[acc_account_type] [varchar](50) NULL,
	[acc_opening_date] [date] NULL,
	[acc_checkbook_requested] [bit] NULL,
	[acc_checkbook_issued] [bit] NULL,
	[acc_card_requested] [bit] NULL,
	[acc_card_issued] [bit] NULL,
	[acc_card_number] [varchar](50) NULL,
	[acc_card_issue_date] [date] NULL,
	[acc_card_expiry_date] [date] NULL,
	[acc_card_status] [bit] NULL,
	[acc_is_closed] [bit] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[acc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recurrings]    Script Date: 08/05/2024 07:21:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recurrings](
	[rdd_id] [int] IDENTITY(1,1) NOT NULL,
	[rdd_debit_acc_id_fk] [int] NULL,
	[rdd_credit_acc_id_fk] [int] NULL,
	[rdd_description] [varchar](150) NULL,
	[rdd_amount] [numeric](18, 2) NULL,
	[rdd_day_number] [int] NULL,
	[rdd_status] [bit] NULL,
 CONSTRAINT [PK_Recurrings] PRIMARY KEY CLUSTERED 
(
	[rdd_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 08/05/2024 07:21:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[trn_id] [int] IDENTITY(1,1) NOT NULL,
	[trn_date] [date] NULL,
	[trn_type] [varchar](50) NULL,
	[trn_receipt_no] [varchar](50) NULL,
	[trn_acc_id_fk] [int] NULL,
	[trn_description] [varchar](200) NULL,
	[trn_dramount] [numeric](18, 2) NULL,
	[trn_cramount] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[trn_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08/05/2024 07:21:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[usr_id] [int] IDENTITY(1,1) NOT NULL,
	[usr_firstname] [varchar](50) NOT NULL,
	[usr_lastname] [varchar](50) NOT NULL,
	[usr_email] [varchar](100) NOT NULL,
	[usr_password] [varchar](50) NOT NULL,
	[usr_phone] [varchar](250) NULL,
	[usr_is_active] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[usr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 
GO
INSERT [dbo].[Accounts] ([acc_id], [acc_account_number], [acc_holder_id], [acc_holder_name], [acc_holder_dob], [acc_holder_phone], [acc_holder_address_door], [acc_holder_address_street], [acc_holder_address_city], [acc_holder_address_post_code], [acc_account_type], [acc_opening_date], [acc_checkbook_requested], [acc_checkbook_issued], [acc_card_requested], [acc_card_issued], [acc_card_number], [acc_card_issue_date], [acc_card_expiry_date], [acc_card_status], [acc_is_closed]) VALUES (1, N'60161347389231', N'AB12345', N'Farrukh Javed', CAST(N'2024-03-18' AS Date), N'07417506395', N'Appartment 3,', N'14 Oak Street,', N'Manchester', N'M1 1AA', N'Personal', CAST(N'2024-03-18' AS Date), 1, 1, 0, 0, N'', CAST(N'2023-01-01' AS Date), CAST(N'2026-01-01' AS Date), 1, 0)
GO
INSERT [dbo].[Accounts] ([acc_id], [acc_account_number], [acc_holder_id], [acc_holder_name], [acc_holder_dob], [acc_holder_phone], [acc_holder_address_door], [acc_holder_address_street], [acc_holder_address_city], [acc_holder_address_post_code], [acc_account_type], [acc_opening_date], [acc_checkbook_requested], [acc_checkbook_issued], [acc_card_requested], [acc_card_issued], [acc_card_number], [acc_card_issue_date], [acc_card_expiry_date], [acc_card_status], [acc_is_closed]) VALUES (2, N'60161376594383', N'XYZ12345', N'Prabhjot Singh', CAST(N'2024-03-21' AS Date), N'07407740068', N'Apartment 5,', N'27 Willow Avenue,', N'London', N'SW1A 1AA', N'Business', CAST(N'2024-03-21' AS Date), 1, 0, 1, 1, N'4222-2222-2222-2222', CAST(N'2024-04-02' AS Date), CAST(N'2024-04-02' AS Date), NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Recurrings] ON 
GO
INSERT [dbo].[Recurrings] ([rdd_id], [rdd_debit_acc_id_fk], [rdd_credit_acc_id_fk], [rdd_description], [rdd_amount], [rdd_day_number], [rdd_status]) VALUES (1, 1, 2, N'Fee transfer on 1st of every month', CAST(100.00 AS Numeric(18, 2)), 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Recurrings] OFF
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON 
GO
INSERT [dbo].[Transactions] ([trn_id], [trn_date], [trn_type], [trn_receipt_no], [trn_acc_id_fk], [trn_description], [trn_dramount], [trn_cramount]) VALUES (1, CAST(N'2024-01-30' AS Date), N'D', N'522463', 1, N'Deposited Cash', CAST(0.00 AS Numeric(18, 2)), CAST(5000.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Transactions] ([trn_id], [trn_date], [trn_type], [trn_receipt_no], [trn_acc_id_fk], [trn_description], [trn_dramount], [trn_cramount]) VALUES (2, CAST(N'2024-03-10' AS Date), N'W', N'521135', 1, N'Cash Withdrawl', CAST(500.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Transactions] ([trn_id], [trn_date], [trn_type], [trn_receipt_no], [trn_acc_id_fk], [trn_description], [trn_dramount], [trn_cramount]) VALUES (3, CAST(N'2024-03-15' AS Date), N'T', N'963712', 1, N'Funds Transfer', CAST(1000.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Transactions] ([trn_id], [trn_date], [trn_type], [trn_receipt_no], [trn_acc_id_fk], [trn_description], [trn_dramount], [trn_cramount]) VALUES (4, CAST(N'2024-03-15' AS Date), N'T', N'963712', 2, N'Funds Transfer', CAST(0.00 AS Numeric(18, 2)), CAST(1000.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Transactions] ([trn_id], [trn_date], [trn_type], [trn_receipt_no], [trn_acc_id_fk], [trn_description], [trn_dramount], [trn_cramount]) VALUES (1002, CAST(N'2024-05-06' AS Date), N'D', N'883853', 1, N'Cash Deposit', CAST(0.00 AS Numeric(18, 2)), CAST(500.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Transactions] ([trn_id], [trn_date], [trn_type], [trn_receipt_no], [trn_acc_id_fk], [trn_description], [trn_dramount], [trn_cramount]) VALUES (1003, CAST(N'2024-05-06' AS Date), N'D', N'998103', 1, N'Cash Deposited', CAST(0.00 AS Numeric(18, 2)), CAST(500.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Transactions] ([trn_id], [trn_date], [trn_type], [trn_receipt_no], [trn_acc_id_fk], [trn_description], [trn_dramount], [trn_cramount]) VALUES (1004, CAST(N'2024-05-06' AS Date), N'D', N'950914', 1, N'cash deposited', CAST(0.00 AS Numeric(18, 2)), CAST(500.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Transactions] ([trn_id], [trn_date], [trn_type], [trn_receipt_no], [trn_acc_id_fk], [trn_description], [trn_dramount], [trn_cramount]) VALUES (1005, CAST(N'2024-05-06' AS Date), N'D', N'986113', 1, N'cash deposited by farrukh javed', CAST(0.00 AS Numeric(18, 2)), CAST(500.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Transactions] ([trn_id], [trn_date], [trn_type], [trn_receipt_no], [trn_acc_id_fk], [trn_description], [trn_dramount], [trn_cramount]) VALUES (1006, CAST(N'2024-05-06' AS Date), N'W', N'960639', 1, N'Cash withdraw', CAST(100.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Transactions] ([trn_id], [trn_date], [trn_type], [trn_receipt_no], [trn_acc_id_fk], [trn_description], [trn_dramount], [trn_cramount]) VALUES (1007, CAST(N'2024-05-06' AS Date), N'D', N'706251', 1, N'Cash Deposited by Farrukh Javed', CAST(0.00 AS Numeric(18, 2)), CAST(200.00 AS Numeric(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([usr_id], [usr_firstname], [usr_lastname], [usr_email], [usr_password], [usr_phone], [usr_is_active]) VALUES (1, N'Ahtesham', N'Haider', N'aht786@hotmail.com', N'1234', N'03009666431', 1)
GO
INSERT [dbo].[Users] ([usr_id], [usr_firstname], [usr_lastname], [usr_email], [usr_password], [usr_phone], [usr_is_active]) VALUES (2, N'Tehseen', N'Younis', N'teh7860@hotmail.com', N'1234', N'+923216061388', 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_acc_checkbook_requested]  DEFAULT ((0)) FOR [acc_checkbook_requested]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_acc_checkbook_issued]  DEFAULT ((0)) FOR [acc_checkbook_issued]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_acc_card_requested]  DEFAULT ((0)) FOR [acc_card_requested]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_acc_card_issued]  DEFAULT ((0)) FOR [acc_card_issued]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_acc_card_status]  DEFAULT ((0)) FOR [acc_card_status]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_acc_status_is_closed]  DEFAULT ((0)) FOR [acc_is_closed]
GO
ALTER TABLE [dbo].[Recurrings] ADD  CONSTRAINT [DF_Recurrings_rdd_status]  DEFAULT ((0)) FOR [rdd_status]
GO
/****** Object:  StoredProcedure [dbo].[Sql2Class]    Script Date: 08/05/2024 07:21:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sql2Class] 
@table as sysname
AS
BEGIN
--Updated by @Sean on 23th,December 2022

declare @TableName sysname = @table
declare @Result varchar(max) = '[Table("' + @TableName + '")]
' + 'public class ' + @TableName + '
{'

select @Result = @Result + '
    public ' + ColumnType + NullableSign + ' ' + ColumnName + ' { get; set; }'
from
(
    select 
        replace(col.name, ' ', '_') ColumnName,
        column_id ColumnId,
        case typ.name 
            when 'bigint' then 'long'
            when 'binary' then 'byte[]'
            when 'bit' then 'bool'
            when 'char' then 'string'
            when 'date' then 'DateTime'
            when 'datetime' then 'DateTime'
            when 'datetime2' then 'DateTime'
            when 'datetimeoffset' then 'DateTimeOffset'
            when 'decimal' then 'decimal'
            when 'float' then 'float'
            when 'image' then 'byte[]'
            when 'int' then 'int'
            when 'money' then 'decimal'
            when 'nchar' then 'string'
            when 'ntext' then 'string'
            when 'numeric' then 'decimal'
            when 'nvarchar' then 'string'
            when 'real' then 'double'
            when 'smalldatetime' then 'DateTime'
            when 'smallint' then 'short'
            when 'smallmoney' then 'decimal'
            when 'text' then 'string'
            when 'time' then 'TimeSpan'
            when 'timestamp' then 'DateTime'
            when 'tinyint' then 'byte'
            when 'uniqueidentifier' then 'Guid'
            when 'varbinary' then 'byte[]'
            when 'varchar' then 'string'
            else 'UNKNOWN_' + typ.name
        end ColumnType,
        case 
            when col.is_nullable = 1 and typ.name in ('bigint', 'bit', 'date', 'datetime', 'datetime2', 'datetimeoffset', 'decimal', 'float', 'int', 'money', 'numeric', 'real', 'smalldatetime', 'smallint', 'smallmoney', 'time', 'tinyint', 'uniqueidentifier') 
            then '?' 
            else '' 
        end NullableSign
    from sys.columns col
        join sys.types typ on
            col.system_type_id = typ.system_type_id AND col.user_type_id = typ.user_type_id
    where object_id = object_id(@TableName)
) t
order by ColumnId

set @Result = @Result  + '
}'

print @Result
END
GO
USE [master]
GO
ALTER DATABASE [BankingSystem] SET  READ_WRITE 
GO
