CREATE TABLE [dbo].[Contacts] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NULL,
    [LastName]  NVARCHAR (50) NULL,
    [Email]     NVARCHAR (50) NULL,
    [Company]   NVARCHAR (50) NULL,
    [Title]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([Id] ASC)
);

