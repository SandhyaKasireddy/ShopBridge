USE [ShopBridge]
GO

/****** Object: SqlProcedure [dbo].[sp_GetAllProducts] Script Date: 5/23/2022 9:10:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAllProducts]
AS
BEGIN
	SELECT * from Products order by 1
END
