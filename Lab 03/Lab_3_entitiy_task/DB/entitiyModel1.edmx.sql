
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/23/2023 07:53:43
-- Generated from EDMX file: D:\aiub\0. Github\dotNet-Lab-Task\Lab 03\Lab_3_entitiy_task\DB\entitiyModel1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [lab_3_entity_task];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[student];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'students'
CREATE TABLE [dbo].[students] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(100)  NOT NULL,
    [username] varchar(15)  NOT NULL,
    [gender] varchar(50)  NOT NULL,
    [profession] varchar(50)  NOT NULL,
    [studentID] varchar(50)  NOT NULL,
    [email] varchar(50)  NOT NULL,
    [dob] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'students'
ALTER TABLE [dbo].[students]
ADD CONSTRAINT [PK_students]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------