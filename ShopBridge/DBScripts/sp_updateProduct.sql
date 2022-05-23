USE [ShopBridge]
GO

/****** Object: SqlProcedure [dbo].[sp_updateProduct] Script Date: 5/23/2022 9:11:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_updateProduct]  
 @productId int,  
 @productName varchar(50) null,  
 @productDesc varchar(100) null,  
 @productPrice int null,  
 @availableQuantity int null  
AS  
BEGIN  
  
update Products  
 set ProductNAME = CASE WHEN ISNULL(@productName,'') != '' THEN   @productName ELSE ProductNAME END,  
 ProductDescription= CASE WHEN ISNULL(@productDesc,'') != '' THEN   @productDesc ELSE ProductDescription END,  
 ProductPrice= CASE WHEN ISNULL(@productPrice,0) != 0 THEN   @productPrice ELSE ProductPrice END,  
 AvailableQuantity = CASE WHEN ISNULL(@availableQuantity,0) != 0 THEN   @availableQuantity ELSE AvailableQuantity END  
where ProductId = @productId  
  
END
