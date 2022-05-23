USE [ShopBridge]
GO

/****** Object: SqlProcedure [dbo].[sp_AddProduct] Script Date: 5/23/2022 9:09:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_AddProduct]
	@ProductName varchar(50),
	@ProductDescription varchar(100),
	@ProductPrice int,
	@Quantity int
AS
BEGIN
	insert into Products values (@ProductName,@ProductDescription,@ProductPrice,@Quantity)

	select ProductId from Products order by 1 desc ;
END
