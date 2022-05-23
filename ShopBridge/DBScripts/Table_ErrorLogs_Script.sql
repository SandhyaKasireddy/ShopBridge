USE [ShopBridge]
GO

/****** Object: Table [dbo].[ErrorLogs] Script Date: 5/23/2022 9:06:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ErrorLogs] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [ErrorMessage]  VARCHAR (100) NOT NULL,
    [ErrorLocation] VARCHAR (500) NOT NULL
);


