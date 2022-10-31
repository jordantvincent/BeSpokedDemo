-- ============================================================================================
--			TABLES
-- ============================================================================================

-- This section contains all of the CREATE statements for the tables in my BeSpoked database

USE [BeSpoked]
GO

/****** Object:  Table [dbo].[customer_master]    Script Date: 10/31/2022 10:44:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[customer_master](
	[Cu_Key] [int] IDENTITY(1,1) NOT NULL,
	[Cu_Name_First] [nvarchar](50) NOT NULL,
	[Cu_Name_Last] [nvarchar](50) NOT NULL,
	[Cu_Name] [nvarchar](50) NOT NULL,
	[Cu_Addr_1] [nvarchar](50) NOT NULL,
	[Cu_Addr_2] [nvarchar](50) NOT NULL,
	[Cu_Phone] [nvarchar](15) NOT NULL,
	[Cu_Date_Start] [datetime] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
	[Process] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_custom_master] PRIMARY KEY CLUSTERED 
(
	[Cu_Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [BeSpoked]
GO

/****** Object:  Table [dbo].[department_master]    Script Date: 10/31/2022 10:44:49 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[department_master](
	[Dm_Key] [int] IDENTITY(1,1) NOT NULL,
	[Dm_Name] [nvarchar](50) NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[Process] [nvarchar](50) NULL,
 CONSTRAINT [PK_department_master] PRIMARY KEY CLUSTERED 
(
	[Dm_Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [BeSpoked]
GO

/****** Object:  Table [dbo].[discount_master]    Script Date: 10/31/2022 10:44:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[discount_master](
	[Dc_Key] [int] IDENTITY(1,1) NOT NULL,
	[Dc_Pr_Key] [int] NOT NULL,
	[Dc_Date_Beg] [datetime] NOT NULL,
	[Dc_Date_End] [datetime] NOT NULL,
	[Dc_Percent] [decimal](5, 2) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
	[Process] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_discount_master] PRIMARY KEY CLUSTERED 
(
	[Dc_Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[discount_master]  WITH CHECK ADD FOREIGN KEY([Dc_Pr_Key])
REFERENCES [dbo].[product_master] ([Pr_Key])
GO


USE [BeSpoked]
GO

/****** Object:  Table [dbo].[manager_master]    Script Date: 10/31/2022 10:45:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[manager_master](
	[Mg_Key] [int] IDENTITY(1,1) NOT NULL,
	[Mg_Name] [nvarchar](75) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
	[Process] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_managers_master] PRIMARY KEY CLUSTERED 
(
	[Mg_Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [BeSpoked]
GO

/****** Object:  Table [dbo].[manufacturer_master]    Script Date: 10/31/2022 10:45:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[manufacturer_master](
	[Mf_Key] [int] IDENTITY(1,1) NOT NULL,
	[Mf_Name] [nvarchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
	[Process] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_manufacturer_master] PRIMARY KEY CLUSTERED 
(
	[Mf_Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [BeSpoked]
GO

/****** Object:  Table [dbo].[product_master]    Script Date: 10/31/2022 10:45:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[product_master](
	[Pr_Key] [int] IDENTITY(1,1) NOT NULL,
	[Pr_Name] [nvarchar](75) NULL,
	[Pr_Manufacturer] [int] NULL,
	[Pr_Style] [int] NULL,
	[Pr_Amt_Purchase] [decimal](18, 2) NULL,
	[Pr_Amt_Sale] [decimal](18, 2) NULL,
	[Pr_Qty] [int] NOT NULL,
	[Pr_Commission] [decimal](5, 2) NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[Process] [nvarchar](75) NULL,
 CONSTRAINT [PK_product_master] PRIMARY KEY CLUSTERED 
(
	[Pr_Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Pr_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[product_master]  WITH CHECK ADD FOREIGN KEY([Pr_Manufacturer])
REFERENCES [dbo].[manufacturer_master] ([Mf_Key])
GO

ALTER TABLE [dbo].[product_master]  WITH CHECK ADD FOREIGN KEY([Pr_Style])
REFERENCES [dbo].[style_master] ([St_Key])
GO

ALTER TABLE [dbo].[product_master]  WITH CHECK ADD CHECK  (([Pr_Qty]>=(0)))
GO


USE [BeSpoked]
GO

/****** Object:  Table [dbo].[sales_master]    Script Date: 10/31/2022 10:45:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[sales_master](
	[Sa_Key] [int] IDENTITY(1,1) NOT NULL,
	[Sa_Pr_Key] [int] NULL,
	[Sa_Sp_Key] [int] NULL,
	[Sa_Cu_Key] [int] NULL,
	[Sa_Qty] [int] NULL,
	[Sa_Amt] [decimal](18, 2) NULL,
	[Sa_Commission_Amt] [decimal](18, 2) NULL,
	[Sa_Commission_Percent] [decimal](5, 2) NULL,
	[Sa_Date_Trans] [datetime] NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[Process] [nvarchar](50) NULL,
 CONSTRAINT [PK_sales_mastser] PRIMARY KEY CLUSTERED 
(
	[Sa_Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[sales_master]  WITH CHECK ADD FOREIGN KEY([Sa_Cu_Key])
REFERENCES [dbo].[customer_master] ([Cu_Key])
GO

ALTER TABLE [dbo].[sales_master]  WITH CHECK ADD FOREIGN KEY([Sa_Pr_Key])
REFERENCES [dbo].[product_master] ([Pr_Key])
GO

ALTER TABLE [dbo].[sales_master]  WITH CHECK ADD FOREIGN KEY([Sa_Sp_Key])
REFERENCES [dbo].[salesperson_master] ([Sp_Key])
GO


USE [BeSpoked]
GO

/****** Object:  Table [dbo].[salesperson_master]    Script Date: 10/31/2022 10:45:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[salesperson_master](
	[Sp_Key] [int] IDENTITY(1,1) NOT NULL,
	[Sp_Name_First] [nvarchar](50) NOT NULL,
	[Sp_Name_Last] [nvarchar](50) NOT NULL,
	[Sp_Name] [nvarchar](100) NOT NULL,
	[Sp_Addr_1] [nvarchar](50) NOT NULL,
	[Sp_Addr_2] [nvarchar](50) NOT NULL,
	[Sp_Phone] [nvarchar](15) NOT NULL,
	[Sp_Date_Start] [datetime] NOT NULL,
	[Sp_Date_Termination] [datetime] NULL,
	[Sp_Mg_Key] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
	[Process] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_salesperson_master] PRIMARY KEY CLUSTERED 
(
	[Sp_Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Sp_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Sp_Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[salesperson_master]  WITH CHECK ADD FOREIGN KEY([Sp_Mg_Key])
REFERENCES [dbo].[manager_master] ([Mg_Key])
GO


USE [BeSpoked]
GO

/****** Object:  Table [dbo].[style_master]    Script Date: 10/31/2022 10:45:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[style_master](
	[St_Key] [int] IDENTITY(1,1) NOT NULL,
	[St_Desc] [nvarchar](20) NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[Process] [nvarchar](50) NULL,
 CONSTRAINT [PK_style_master] PRIMARY KEY CLUSTERED 
(
	[St_Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO





-- ============================================================================================
--			STORED PROCEDURES
-- ============================================================================================

-- This section contains all of the CREATE statements for the stored procedures in my BeSpoked database


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Customer_Get_VM_ById]    Script Date: 10/31/2022 10:47:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Customer_Get_VM_ById]      
	
	@Cu_Key int
AS  
 BEGIN   
 SET NOCOUNT ON;    

 SELECT 
	   Cu_Key
      ,Cu_Name_First
      ,Cu_Name_Last
      ,Cu_Name
      ,Cu_Addr_1
      ,Cu_Addr_2
      ,Cu_Phone
      ,Cu_Date_Start
      ,Created
      ,Updated
      ,Process

 
 FROM customser_master
 
 WHERE Cu_Key = @Cu_Key
 
 END      
GO



USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Customer_GetById]    Script Date: 10/31/2022 10:48:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[Customer_GetById]      
	
	@Cu_Key int
AS  
 BEGIN   
 SET NOCOUNT ON;    

 SELECT * 
 FROM customer_master 
 WHERE cu_key = @Cu_Key
 END      
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Customer_GetSelectList]    Script Date: 10/31/2022 10:48:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Customer_GetSelectList]      
	
AS  
 BEGIN   
 SET NOCOUNT ON;    

 SELECT 
 Cu_Key as "Key", 
 Cu_Name as "Display"

 FROM customer_master 
 
 ORDER BY cu_name

 END      
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Customer_Insert]    Script Date: 10/31/2022 10:48:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[Customer_Insert]      
@Cu_Name_First nvarchar(50),
@Cu_Name_Last nvarchar(50),
@Cu_Addr_1 nvarchar(50),
@Cu_Addr_2 nvarchar(50),
@Cu_Phone nvarchar(15),
@Cu_Date_Start datetime,
@Cu_Key int = 0 output  AS 

BEGIN   SET NOCOUNT ON;                

	INSERT INTO customer_master
		 ([Cu_Name_First]
		  ,[Cu_Name_Last]
		  ,[Cu_Name]
		  ,[Cu_Addr_1]
		  ,[Cu_Addr_2]
		  ,[Cu_Phone]
		  ,[Cu_Date_Start]
		  ,[Created]
		  ,[Updated]
		  ,[Process])

	VALUES (@Cu_Name_First, 
			@Cu_Name_Last,
			CONCAT(@Cu_Name_Last, ', ', @Cu_Name_First), 
			@Cu_Addr_1, 
			@Cu_Addr_2,  
			@Cu_Phone, 
			@Cu_Date_Start, 
			SYSDATETIME(), 
			SYSDATETIME(), 
			'SP: Customer_Insert')
					
	select @Cu_Key = SCOPE_IDENTITY(); 

END                 
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Customer_Update]    Script Date: 10/31/2022 10:48:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[Customer_Update]     
@Cu_Key int,
@Cu_Name_First nvarchar(50),
@Cu_Name_Last nvarchar(50),
@Cu_Addr_1 nvarchar(50),
@Cu_Addr_2 nvarchar(50),
@Cu_Phone nvarchar(15),
@Cu_Date_Start datetime
AS 

BEGIN   
SET NOCOUNT ON;                

	UPDATE customer_master
	SET
		Cu_Name_First = @Cu_Name_First,
		Cu_Name_Last = @Cu_Name_Last,
		Cu_Name = CONCAT(@Cu_Name_Last, ', ', @Cu_Name_First),
		Cu_Addr_1 = @Cu_Addr_1,
		Cu_Addr_2 = @Cu_Addr_2,
		Cu_Phone = @Cu_Phone,
		Cu_Date_Start = @Cu_Date_Start,
		Updated = SYSDATETIME(),
		Process = 'SP: Customer_Update'

	WHERE Cu_Key = @Cu_Key

END                 
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Customers_GetAll]    Script Date: 10/31/2022 10:48:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[Customers_GetAll]      
	
AS  
 BEGIN   
 SET NOCOUNT ON;    

 SELECT * 
 FROM customer_master
 END      
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Discount_Insert]    Script Date: 10/31/2022 10:48:53 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[Discount_Insert]      
@Dc_Pr_Key int,
@Dc_Date_Beg datetime,
@Dc_Date_End datetime,
@Dc_Percent decimal(5,2),
@Dc_Key int = 0 output  AS 

BEGIN   SET NOCOUNT ON;                

	INSERT INTO discount_master
		 ([Dc_Pr_Key]
		  ,[Dc_Date_Beg]
		  ,[Dc_Date_End]
		  ,[Dc_Percent]
		  ,[Created]
		  ,[Updated]
		  ,[Process])

	VALUES (@Dc_Pr_Key, 
			@Dc_Date_Beg, 
			@Dc_Date_End, 
			@Dc_Percent,  
			SYSDATETIME(), 
			SYSDATETIME(), 
			'SP: Discount_Insert')
					
	select @Dc_Key = SCOPE_IDENTITY();  

END                 
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Managers_GetSelectList]    Script Date: 10/31/2022 10:49:05 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Managers_GetSelectList]      
	
AS  
 BEGIN   
 SET NOCOUNT ON;    

 SELECT 
 mg_key as "Key", 
 mg_name as "Display"

 FROM manager_master

 END      
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Manufacturers_GetSelectList]    Script Date: 10/31/2022 10:49:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Manufacturers_GetSelectList]      
	
AS  
 BEGIN   
 SET NOCOUNT ON;    

 SELECT
 mf_key as "Key", 
 mf_name as "Display" 

 FROM manufacturer_master

 END      
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Product_Get_SelectList]    Script Date: 10/31/2022 10:49:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Product_Get_SelectList]      
	
AS  
 BEGIN   
 SET NOCOUNT ON;    

SELECT 
Pr_Key as "Key",
pr_name as "Display" 

FROM product_master 

WHERE 
pr_qty > 0

ORDER BY
pr_name

 END      
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Product_Get_VM_ById]    Script Date: 10/31/2022 10:49:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[Product_Get_VM_ById]      
	
	@Pr_Key int
AS  
 BEGIN   
 SET NOCOUNT ON;    

 DECLARE @DISCOUNT decimal(5,2) = (ISNULL((select dc_percent from discount_master where dc_pr_key = @Pr_Key and SYSDATETIME() >= dc_date_beg and SYSDATETIME() <= dc_date_end),0))

 SELECT 
 Pr_Key, 
 Pr_Name, 
 Mf_Name as "Pr_Manufacturer", 
 St_Desc as "Pr_Style", 
 Pr_Amt_Purchase,
 Pr_Amt_Sale,
 Pr_Qty,
 Pr_Commission,
 @DISCOUNT as "Pr_Amt_Discount"
 
 FROM product_master, style_master, manufacturer_master
 
 WHERE st_key = Pr_Style
 and mf_key = Pr_Manufacturer 
 and Pr_Key = @Pr_Key
 
 END      
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Product_GetAll]    Script Date: 10/31/2022 10:49:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Product_GetAll]      
	
AS  
 BEGIN   
 SET NOCOUNT ON;    

	 SELECT 
	 Pr_Key, 
	 Pr_Name, 
	 Mf_Name as "Pr_Manufacturer", 
	 St_Desc as "Pr_Style", 
	 Pr_Amt_Purchase,
	 (Pr_Amt_Sale * (1 - ISNULL((select dc_percent from discount_master where dc_pr_key = Pr_Key and SYSDATETIME() >= dc_date_beg and SYSDATETIME() <= dc_date_end),0))) as "Pr_Amt_Sale", Pr_Qty, Pr_Commission
 
	 FROM 
	 product_master, 
	 style_master, 
	 manufacturer_master
 
	 WHERE 
	 st_key = Pr_Style
	 and mf_key = Pr_Manufacturer

 END      
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Product_GetById]    Script Date: 10/31/2022 10:49:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[Product_GetById]      
	
	@Pr_Key int
AS  
 BEGIN   
 SET NOCOUNT ON;    

	 SELECT *
 
	 FROM product_master
 
	 WHERE pr_key = @Pr_Key
 
 END      
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Product_GetCurrentDiscount]    Script Date: 10/31/2022 10:49:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Product_GetCurrentDiscount]      
	@Pr_Key int
AS  
 BEGIN   
 SET NOCOUNT ON;    

	 SELECT * 
 
	 FROM discount_master 
 
	 WHERE 
	 dc_date_beg <= SYSDATETIME() 
	 and dc_date_end >= SYSDATETIME() 
	 and dc_pr_key = @Pr_Key

 END      
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Product_GetSelectList]    Script Date: 10/31/2022 10:50:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Product_GetSelectList]      
	
AS  
 BEGIN   
 SET NOCOUNT ON;    

		SELECT 
		Pr_Key as "Key",
		Pr_Name as "Display" 

		FROM product_master 

		WHERE pr_qty > 0 

		ORDER BY pr_name

 END      
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Product_Insert]    Script Date: 10/31/2022 10:50:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[Product_Insert]      
@Pr_Name nvarchar(50),
@Pr_Manufacturer int,
@Pr_Style int,
@Pr_Amt_Purchase decimal(18,2),
@Pr_Amt_Sale decimal(18,2),
@Pr_Qty int,
@Pr_Commission decimal(5,2),
@Pr_Key int = 0 output  AS 

BEGIN   SET NOCOUNT ON;                

	INSERT INTO product_master 
		 ([Pr_Name]
		  ,[Pr_Manufacturer]
		  ,[Pr_Style]
		  ,[Pr_Amt_Purchase]
		  ,[Pr_Amt_Sale]
		  ,[Pr_Qty]
		  ,[Pr_Commission]
		  ,[Created]
		  ,[Updated]
		  ,[Process])
	VALUES (@Pr_Name, 
			@Pr_Manufacturer,
			@Pr_Style, 
			@Pr_Amt_Purchase,
			@Pr_Amt_Sale, 
			@Pr_Qty,
			@Pr_Commission,
			SYSDATETIME(),
			SYSDATETIME(), 
			'SP: Product_Insert')
					
	select @Pr_Key = SCOPE_IDENTITY();

END                 
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Product_Update]    Script Date: 10/31/2022 10:50:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[Product_Update]  
@Pr_Key int,
@Pr_Name nvarchar(50),
@Pr_Manufacturer int,
@Pr_Style int,
@Pr_Amt_Purchase decimal(18,2),
@Pr_Amt_Sale decimal(18,2),
@Pr_Qty int,
@Pr_Commission decimal(5,2)
AS
BEGIN
SET NOCOUNT ON;                

	UPDATE product_master 

	SET 
	Pr_Name = @Pr_Name,
	Pr_Manufacturer = @Pr_Manufacturer,
	Pr_Style = @Pr_Style,
	Pr_Amt_Purchase = @Pr_Amt_Purchase,
	Pr_Amt_Sale = @Pr_Amt_Sale,
	Pr_Qty = @Pr_Qty,
	Pr_Commission = @Pr_Commission,
	Updated = SYSDATETIME(),
	Process = 'SP: Product_Update'

	WHERE Pr_Key = @Pr_Key

END                 
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Product_UpdateQty]    Script Date: 10/31/2022 10:50:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[Product_UpdateQty]      
@Pr_Key int,
@Pr_Qty int

AS 
BEGIN  
SET NOCOUNT ON;                

	UPDATE product_master 
	
	SET pr_qty = (pr_qty - @Pr_Qty) 
		
	WHERE pr_key = @Pr_Key

END                 
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Sale_Get_VM_ById]    Script Date: 10/31/2022 10:50:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









CREATE PROCEDURE [dbo].[Sale_Get_VM_ById]      
	
	@Sa_Key int
AS  
 BEGIN   
 SET NOCOUNT ON;    

	SELECT 
	sa_key, 
	pr_name, 
	pr_style, 
	cu_name, 
	sa_date_trans, 
	sa_amt, sp_name, 
	sa_commission_amt,
	sa_qty, 
	sa_commission_percent

	FROM 
	sales_master, 
	customer_master, 
	product_master, 
	salesperson_master, 
	style_master

	WHERE 
	sa_cu_key = cu_key
	and sa_pr_key = pr_key
	and sa_sp_key= sp_key
	and sa_key = @Sa_Key
	and st_key = pr_style

 END      

GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Sale_Insert]    Script Date: 10/31/2022 10:51:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[Sale_Insert]      
@Sa_Pr_Key int,
@Sa_Cu_Key int,
@Sa_Sp_Key int,
@Sa_Date_Trans datetime,
@Sa_Qty int,
@Sa_Key int = 0 output 

AS 
BEGIN  
SET NOCOUNT ON;                

-- Get cost of the product
DECLARE @Pr_Cost decimal (18,2) = (SELECT Pr_Amt_Sale from product_master where pr_key = @Sa_Pr_Key)
-- Get commission for the product
DECLARE @Pr_Commission decimal(5,2) = (SELECT Pr_Commission from product_master where pr_key = @Sa_Pr_Key)

-- Get discount of product based on date of transaction
DECLARE @DISCOUNT decimal(5,2) = ISNULL((select dc_percent from discount_master where dc_pr_key = @Sa_Pr_Key and @Sa_Date_Trans >= dc_date_beg and @Sa_Date_Trans <= dc_date_end),0)
-- Calculate Sale amount
DECLARE @Sa_Amt decimal(18,2) = @Sa_Qty * (1 - @Discount) * @Pr_Cost
-- Calculate Commission Amount
DECLARE @Sa_Commission_Amt decimal(18,2) = @Sa_Amt * @Pr_Commission


	BEGIN TRY
		BEGIN TRANSACTION

			INSERT INTO sales_master
				 ([Sa_Pr_Key]
				  ,[Sa_Sp_Key]
				  ,[Sa_Cu_Key]
				  ,[Sa_Qty]
				  ,[Sa_Amt]
				  ,[Sa_Commission_Amt]
				  ,[Sa_Commission_Percent]
				  ,[Sa_Date_Trans]
				  ,[Created]
				  ,[Updated]
				  ,[Process])
				VALUES (
					@Sa_Pr_Key, 
					@Sa_Sp_Key, 
					@Sa_Cu_Key, 
					@Sa_Qty, 
					@Sa_Amt,
					@Sa_Commission_Amt,
					@Pr_Commission,
					@Sa_Date_Trans,  SYSDATETIME(), SYSDATETIME(), 'SP: Sale_Insert')
					
			select @Sa_Key = SCOPE_IDENTITY();  

			EXEC	[dbo].[Product_UpdateQty]
					@Pr_Key = @Sa_Pr_Key,
					@Pr_Qty = @Sa_Qty

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRAN 

		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  

		SELECT   
		   @ErrorMessage = ERROR_MESSAGE(),  
		   @ErrorSeverity = ERROR_SEVERITY(),  
		   @ErrorState = ERROR_STATE();  

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);  
	END CATCH

END                 
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Sales_GetAll]    Script Date: 10/31/2022 10:51:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[Sales_GetAll]      

AS 
BEGIN  
SET NOCOUNT ON;   

	SELECT 
	sa_key, 
	pr_name,
	cu_name, 
	sa_date_trans, 
	sa_amt, sp_name, 
	sa_commission_amt, 
	sa_qty, 
	sa_commission_percent

	FROM
	sales_master,
	customer_master, 
	product_master, 
	salesperson_master

	WHERE 
	sa_cu_key = cu_key
	and sa_pr_key = pr_key
	and sa_sp_key= sp_key

END                 
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Sales_GetQuarterlyReport]    Script Date: 10/31/2022 10:51:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[Sales_GetQuarterlyReport]      
@YEAR int,
@QUARTER int

AS 
BEGIN  
SET NOCOUNT ON;    

	SELECT  
	ROW_NUMBER() OVER(ORDER BY SUM(sa_commission_amt) desc) as "sa_rank", 
	sp_name, 
	datepart(quarter,sa_date_trans) as "quarter", 
	sum(sa_commission_amt) as "sa_commission_amt",
	sum(sa_amt) as "sa_amt",
	count(*) as "sa_count" 

	FROM sales_master, salesperson_master 

	WHERE datepart(quarter, sa_date_trans) = @QUARTER and datepart(year, sa_date_trans) = @YEAR and sa_sp_key = sp_key

	GROUP BY sp_name, datepart(quarter, sa_date_trans)

	ORDER BY sa_commission_amt desc

END                 
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Sales_GetYears]    Script Date: 10/31/2022 10:51:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[Sales_GetYears]      

AS 
BEGIN  
SET NOCOUNT ON;                

	SELECT 
	DISTINCT(datepart(year,sa_date_trans)) 
	
	FROM sales_master

END                 
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Salesperson_Get_VM_ById]    Script Date: 10/31/2022 10:51:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









CREATE PROCEDURE [dbo].[Salesperson_Get_VM_ById]      
	
	@Sp_Key int
AS  
 BEGIN   
 SET NOCOUNT ON;    

	 SELECT 
	 Sp_Key, 
	 Sp_Name,
	 Sp_Name_First, 
	 Sp_Name_Last,
	 Sp_Date_Start,
	 Sp_Date_Termination,
	 Mg_Name as "Mg_Name",
	 Sp_Phone,
	 Sp_Addr_1,
	 Sp_Addr_2,
	 CASE WHEN Sp_Date_Termination is null THEN 'TRUE'
	 ELSE 'FALSE' END AS "Sp_Active"
 
	 FROM salesperson_master, manager_master
 
	 WHERE Sp_mg_key = mg_key
	 and Sp_Key = @Sp_Key
 
 END      
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Salesperson_GetAll]    Script Date: 10/31/2022 10:51:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[Salesperson_GetAll]      
	
AS  
 BEGIN   
 SET NOCOUNT ON;    

	 SELECT 
	 Sp_Key, 
	 Sp_Name,
	 Sp_Name_First, 
	 Sp_Name_Last,
	 Sp_Date_Start,
	 Sp_Date_Termination,
	 Mg_Name as "Mg_Name",
	 Sp_Phone,
	 Sp_Addr_1,
	 Sp_Addr_2,
	 CASE WHEN Sp_Date_Termination is null THEN 'TRUE'
	 ELSE 'FALSE' END AS "Sp_Active"
 
	 FROM 
	 salesperson_master, 
	 manager_master
 
	 WHERE Sp_mg_key = mg_key
 
 END      
 
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Salesperson_GetById]    Script Date: 10/31/2022 10:51:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Salesperson_GetById]      
	@Sp_Key int
AS  
 BEGIN   
 SET NOCOUNT ON;    

	 SELECT * 

	 FROM salesperson_master 
 
	 WHERE Sp_Key = @Sp_Key

 END      
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Salesperson_GetSelectList]    Script Date: 10/31/2022 10:52:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Salesperson_GetSelectList]      
	
AS  
 BEGIN   
 SET NOCOUNT ON;    

	 SELECT 
	 Sp_Key as "Key", 
	 Sp_Name as "Display" 

	 FROM salesperson_master 
 
	 WHERE sp_date_termination is null 
 
	 ORDER BY Sp_name

 END      
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Salesperson_Insert]    Script Date: 10/31/2022 10:52:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[Salesperson_Insert]      
@Sp_Name_First nvarchar(50),
@Sp_Name_Last nvarchar(50),
@Sp_Addr_1 nvarchar(50),
@Sp_Addr_2 nvarchar(50),
@Sp_Phone nvarchar(15),
@Sp_Date_Start datetime,
@Sp_Mg_Key int,
@Sp_Key int = 0 output  AS 

BEGIN   SET NOCOUNT ON;                

	INSERT INTO salesperson_master 
		 (
		 [Sp_Name_First]
		  ,[Sp_Name_Last]
		  ,[Sp_Name]
		  ,[Sp_Addr_1]
		  ,[Sp_Addr_2]
		  ,[Sp_Phone]
		  ,[Sp_Date_Start]
		  ,[Sp_Mg_Key]
		  ,[Created]
		  ,[Updated]
		  ,[Process])
	VALUES (@Sp_Name_First, 
			@Sp_Name_Last, 
			CONCAT(@Sp_Name_Last,', ',@Sp_Name_First),
			@Sp_Addr_1, @Sp_Addr_2,
			@Sp_Phone,
			@Sp_Date_Start,
			@Sp_Mg_Key,
			SYSDATETIME(),
			SYSDATETIME(), 
			'SP: Salesperson_Insert')
					
	select @Sp_Key = SCOPE_IDENTITY();

END                 
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Salesperson_Terminate]    Script Date: 10/31/2022 10:52:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[Salesperson_Terminate]     
@Sp_Key int,
@Sp_Date_Terminate datetime
AS 

BEGIN   
SET NOCOUNT ON;                

	UPDATE salesperson_master
	SET
		Sp_Date_Termination = @Sp_Date_Terminate,
		Updated = SYSDATETIME(),
		Process = 'SP: Salesperson_Terminate'

	WHERE Sp_Key = @Sp_Key

END                 
GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Salesperson_Update]    Script Date: 10/31/2022 10:52:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[Salesperson_Update]      
@Sp_Name_First nvarchar(50),
@Sp_Name_Last nvarchar(50),
@Sp_Addr_1 nvarchar(50),
@Sp_Addr_2 nvarchar(50),
@Sp_Phone nvarchar(15),
@Sp_Date_Start datetime,
@Sp_Mg_Key int,
@Sp_Key int = 0 output  AS 

BEGIN   SET NOCOUNT ON;                

	UPDATE salesperson_master

	SET
	Sp_Name_First = @Sp_Name_First,
	Sp_Name_Last = @Sp_Name_Last,
	Sp_Name = CONCAT(@Sp_Name_Last,', ',@Sp_Name_First),
	Sp_Addr_1 = @Sp_Addr_1,
	Sp_Addr_2 = @Sp_Addr_2,
	Sp_Phone = @Sp_Phone,
	Sp_Date_Start = @Sp_Date_Start,
	Sp_Mg_Key = @Sp_Mg_Key,
	Updated = SYSDATETIME(),
	Process = 'SP: Salesperson_Update'

	WHERE Sp_Key = @Sp_Key
 
END                 


GO


USE [BeSpoked]
GO

/****** Object:  StoredProcedure [dbo].[Styles_GetSelectList]    Script Date: 10/31/2022 10:52:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Styles_GetSelectList]      
	
AS  
 BEGIN   
 SET NOCOUNT ON;    

	 SELECT 
	 st_key as "Key", 
	 st_desc as "Display"

	 FROM style_master

 END      
GO


