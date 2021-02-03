CREATE TABLE [dbo].[owner_tenant] (
    [id]        INT      IDENTITY (1, 1) NOT NULL,
    [unit_id]   INT      NOT NULL,
    [person_id] INT      NOT NULL,
    [from]      DATETIME NOT NULL,
    [to]        DATETIME NULL,
    [is_owner]  BIT      CONSTRAINT [DF_owner_tenant_is_owner] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_owner_tenant] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_owner_tenant_person] FOREIGN KEY ([person_id]) REFERENCES [dbo].[person] ([id]),
    CONSTRAINT [FK_owner_tenant_Units] FOREIGN KEY ([unit_id]) REFERENCES [dbo].[Units] ([Id])
);

