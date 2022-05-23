USE [ShopBridge]
GO

/****** Object: SqlProcedure [dbo].[sp_getProduct] Script Date: 5/23/2022 9:10:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_getProduct]
@productId int
AS
BEGIN
	select * from Products where ProductId = @productId
END
