USE [ShopBridge]
GO

/****** Object: SqlProcedure [dbo].[sp_InsertErrorLogs] Script Date: 5/23/2022 9:10:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertErrorLogs]
	@ErrorMessage varchar(50),
	@ErrorLocation varchar(500)
AS
BEGIN
	insert into ErrorLogs values (@ErrorMessage,@ErrorLocation)
END
