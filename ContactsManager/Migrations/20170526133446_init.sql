IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Companies] (
    [Id] int NOT NULL IDENTITY,
    [City] nvarchar(max),
    [CompanyName] nvarchar(max),
    [Email] nvarchar(max),
    [HouseNumber] nvarchar(max),
    [PhoneNumber] nvarchar(max),
    [PostalCode] nvarchar(max),
    [Street] nvarchar(max),
    [VatNumber] nvarchar(max),
    CONSTRAINT [PK_Companies] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Persons] (
    [Id] int NOT NULL IDENTITY,
    [City] nvarchar(max),
    [DayOfBirth] datetime2 NOT NULL,
    [Email] nvarchar(max),
    [HouseNumber] nvarchar(max),
    [PhoneNumber] nvarchar(max),
    [PostalCode] nvarchar(max),
    [Street] nvarchar(max),
    CONSTRAINT [PK_Persons] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170526133446_init', N'1.1.2');

GO