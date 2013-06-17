
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/17/2013 22:31:47
-- Generated from EDMX file: C:\Users\Alex\Desktop\Новая папка\CRMnewm\CRMnewm\Model2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\USERS\ALEX\DESKTOP\НОВАЯ ПАПКА\CRMNEWM\CRMNEWM\APP_DATA\DATABASE1.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[webpages_UsersInRoles] DROP CONSTRAINT [fk_RoleId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AccountsNabor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountsNabor];
GO
IF OBJECT_ID(N'[dbo].[ContaktsNabor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContaktsNabor];
GO
IF OBJECT_ID(N'[dbo].[RegistratioNabor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegistratioNabor];
GO
IF OBJECT_ID(N'[dbo].[Tasksnabor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tasksnabor];
GO
IF OBJECT_ID(N'[dbo].[webpages_Membership]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_Membership];
GO
IF OBJECT_ID(N'[dbo].[webpages_OAuthMembership]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_OAuthMembership];
GO
IF OBJECT_ID(N'[dbo].[webpages_Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_Roles];
GO
IF OBJECT_ID(N'[dbo].[webpages_UsersInRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_UsersInRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AccountsNabor'
CREATE TABLE [dbo].[AccountsNabor] (
    [Accounts_id] int IDENTITY(1,1) NOT NULL,
    [Family] nvarchar(max)  NULL,
    [Name] nvarchar(max)  NULL,
    [Surname] nvarchar(max)  NULL,
    [Sex] nvarchar(max)  NULL,
    [Country] nvarchar(max)  NULL,
    [Region] nvarchar(max)  NULL,
    [E_mail] nvarchar(max)  NULL,
    [Web_site] nvarchar(max)  NULL,
    [Osebe] nvarchar(max)  NULL
);
GO

-- Creating table 'ContaktsNabor'
CREATE TABLE [dbo].[ContaktsNabor] (
    [Contakts_id] int IDENTITY(1,1) NOT NULL,
    [Family] nvarchar(max)  NULL,
    [Name] nvarchar(max)  NULL,
    [Surname] nvarchar(max)  NULL,
    [Status] nvarchar(max)  NULL,
    [Skype] nvarchar(max)  NULL,
    [ISQ] nvarchar(max)  NULL
);
GO

-- Creating table 'RegistratioNabor'
CREATE TABLE [dbo].[RegistratioNabor] (
    [Registration_id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [E_mail] nvarchar(max)  NULL
);
GO

-- Creating table 'Tasksnabor'
CREATE TABLE [dbo].[Tasksnabor] (
    [Tasks_id] int IDENTITY(1,1) NOT NULL,
    [Subject] nvarchar(max)  NULL,
    [Status] nvarchar(max)  NULL,
    [Begin_Tasks] datetime  NULL,
    [Limit_Tasks] datetime  NULL,
    [End_Tasks] datetime  NULL,
    [Prioriti] nvarchar(max)  NULL
);
GO

-- Creating table 'webpages_Membership'
CREATE TABLE [dbo].[webpages_Membership] (
    [UserId] int  NOT NULL,
    [CreateDate] datetime  NULL,
    [ConfirmationToken] nvarchar(128)  NULL,
    [IsConfirmed] bit  NULL,
    [LastPasswordFailureDate] datetime  NULL,
    [PasswordFailuresSinceLastSuccess] int  NOT NULL,
    [Password] nvarchar(128)  NOT NULL,
    [PasswordChangedDate] datetime  NULL,
    [PasswordSalt] nvarchar(128)  NOT NULL,
    [PasswordVerificationToken] nvarchar(128)  NULL,
    [PasswordVerificationTokenExpirationDate] datetime  NULL
);
GO

-- Creating table 'webpages_OAuthMembership'
CREATE TABLE [dbo].[webpages_OAuthMembership] (
    [Provider] nvarchar(30)  NOT NULL,
    [ProviderUserId] nvarchar(100)  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'webpages_Roles'
CREATE TABLE [dbo].[webpages_Roles] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'webpages_UsersInRoles'
CREATE TABLE [dbo].[webpages_UsersInRoles] (
    [UserId] int  NOT NULL,
    [RoleId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Accounts_id] in table 'AccountsNabor'
ALTER TABLE [dbo].[AccountsNabor]
ADD CONSTRAINT [PK_AccountsNabor]
    PRIMARY KEY CLUSTERED ([Accounts_id] ASC);
GO

-- Creating primary key on [Contakts_id] in table 'ContaktsNabor'
ALTER TABLE [dbo].[ContaktsNabor]
ADD CONSTRAINT [PK_ContaktsNabor]
    PRIMARY KEY CLUSTERED ([Contakts_id] ASC);
GO

-- Creating primary key on [Registration_id] in table 'RegistratioNabor'
ALTER TABLE [dbo].[RegistratioNabor]
ADD CONSTRAINT [PK_RegistratioNabor]
    PRIMARY KEY CLUSTERED ([Registration_id] ASC);
GO

-- Creating primary key on [Tasks_id] in table 'Tasksnabor'
ALTER TABLE [dbo].[Tasksnabor]
ADD CONSTRAINT [PK_Tasksnabor]
    PRIMARY KEY CLUSTERED ([Tasks_id] ASC);
GO

-- Creating primary key on [UserId] in table 'webpages_Membership'
ALTER TABLE [dbo].[webpages_Membership]
ADD CONSTRAINT [PK_webpages_Membership]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Provider], [ProviderUserId] in table 'webpages_OAuthMembership'
ALTER TABLE [dbo].[webpages_OAuthMembership]
ADD CONSTRAINT [PK_webpages_OAuthMembership]
    PRIMARY KEY CLUSTERED ([Provider], [ProviderUserId] ASC);
GO

-- Creating primary key on [RoleId] in table 'webpages_Roles'
ALTER TABLE [dbo].[webpages_Roles]
ADD CONSTRAINT [PK_webpages_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [UserId], [RoleId] in table 'webpages_UsersInRoles'
ALTER TABLE [dbo].[webpages_UsersInRoles]
ADD CONSTRAINT [PK_webpages_UsersInRoles]
    PRIMARY KEY CLUSTERED ([UserId], [RoleId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RoleId] in table 'webpages_UsersInRoles'
ALTER TABLE [dbo].[webpages_UsersInRoles]
ADD CONSTRAINT [fk_RoleId]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[webpages_Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_RoleId'
CREATE INDEX [IX_fk_RoleId]
ON [dbo].[webpages_UsersInRoles]
    ([RoleId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------