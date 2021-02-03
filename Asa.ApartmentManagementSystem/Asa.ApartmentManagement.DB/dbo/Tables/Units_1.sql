CREATE TABLE [dbo].[Units] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [building_id] INT            NOT NULL,
    [number]      INT            NOT NULL,
    [area]        DECIMAL (5, 1) NOT NULL,
    [description] NVARCHAR (250) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Fk_unit_building] FOREIGN KEY ([building_id]) REFERENCES [dbo].[Building] ([id])
);

