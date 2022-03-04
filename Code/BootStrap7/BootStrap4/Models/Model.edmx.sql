
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/15/2022 10:36:50
-- Generated from EDMX file: C:\Users\Asus\Desktop\Thuc_tap\TT\BootStrap4\BootStrap4\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dtbtt1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__DangKyTin__MaMon__74AE54BC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DangKyTin] DROP CONSTRAINT [FK__DangKyTin__MaMon__74AE54BC];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DangKyTin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DangKyTin];
GO
IF OBJECT_ID(N'[dbo].[MonHoc]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MonHoc];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DangKyTins'
CREATE TABLE [dbo].[DangKyTins] (
    [MaDangKy] int IDENTITY(1,1) NOT NULL,
    [TenTaiKhoan] varchar(10)  NULL,
    [MaMon] int  NOT NULL,
    [NgayTao] datetime  NULL,
    [NgaySua] datetime  NULL,
    [NguoiTao] nvarchar(30)  NULL,
    [NguoiSua] nvarchar(30)  NULL
);
GO

-- Creating table 'MonHocs'
CREATE TABLE [dbo].[MonHocs] (
    [MaMon] int  NOT NULL,
    [TenMon] nvarchar(20)  NULL,
    [NgayTao] datetime  NULL,
    [NgaySua] datetime  NULL,
    [NguoiTao] nvarchar(30)  NULL,
    [NguoiSua] nvarchar(30)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MaDangKy] in table 'DangKyTins'
ALTER TABLE [dbo].[DangKyTins]
ADD CONSTRAINT [PK_DangKyTins]
    PRIMARY KEY CLUSTERED ([MaDangKy] ASC);
GO

-- Creating primary key on [MaMon] in table 'MonHocs'
ALTER TABLE [dbo].[MonHocs]
ADD CONSTRAINT [PK_MonHocs]
    PRIMARY KEY CLUSTERED ([MaMon] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MaMon] in table 'DangKyTins'
ALTER TABLE [dbo].[DangKyTins]
ADD CONSTRAINT [FK__DangKyTin__MaMon__74AE54BC]
    FOREIGN KEY ([MaMon])
    REFERENCES [dbo].[MonHocs]
        ([MaMon])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__DangKyTin__MaMon__74AE54BC'
CREATE INDEX [IX_FK__DangKyTin__MaMon__74AE54BC]
ON [dbo].[DangKyTins]
    ([MaMon]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------