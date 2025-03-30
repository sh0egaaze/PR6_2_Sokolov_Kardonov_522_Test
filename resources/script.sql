CREATE DATABASE [UserManagement]
GO

USE [UserManagement]
GO

CREATE TABLE [dbo].[User](
    [ID] [int] IDENTITY(1,1) NOT NULL,
    [Login] [nvarchar](50) NOT NULL,
    [Password] [nvarchar](50) NOT NULL,
    [Role] [nvarchar](50) NOT NULL,
    [FIO] [nvarchar](100) NOT NULL,
    [Gender] [nvarchar](10) NULL,
    [PhoneNumber] [nvarchar](20) NULL,
    [PhotoURL] [nvarchar](255) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
GO

INSERT INTO [dbo].[User] ([Login], [Password], [Role], [FIO], [Gender], [PhoneNumber], [PhotoURL]) 
VALUES 
    ('manager', 'password', 'Manager', 'Кузнецова Елена Сергеевна', 'Женский', '+7(456)789-01-23', 'http://example.com/manager.jpg'),
    ('administrator', '12345', 'Administrator', 'administrator administrator administrator', 'Женский', '1234567890', 'sdfghj'),
    ('user', 'qwerty', 'User', 'user user user', 'Мужской', '1234567890', 'qwerdfghjk'),
    ('test', 'test', 'User', 'fdghu fxcghjk cxghj', 'Мужской', '546789', 'fcghjkl')
GO
