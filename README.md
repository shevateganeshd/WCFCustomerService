/* CREATE DATABASE CRM and Table Customer */
CREATE DATABASE [CRM];

USE [CRM];

CREATE TABLE [CRM].[dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[MiddleName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](10) NOT NULL
 );

 
