USE [ShopBridge]
GO

/****** Object: SqlProcedure [dbo].[sp_deleteProduct] Script Date: 5/23/2022 9:09:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_deleteProduct]
	@productId int
AS
BEGIN

DELETE from Products where ProductId = @productId

END
