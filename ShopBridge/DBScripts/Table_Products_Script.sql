USE [ShopBridge]
GO

/****** Object: Table [dbo].[Products] Script Date: 5/23/2022 9:07:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products] (
    [ProductId]          INT           IDENTITY (1, 1) NOT NULL,
    [ProductNAME]        VARCHAR (50)  NOT NULL,
    [ProductDescription] VARCHAR (200) NOT NULL,
    [ProductPrice]       INT           NOT NULL,
    [AvailableQuantity]  INT           NULL
);


