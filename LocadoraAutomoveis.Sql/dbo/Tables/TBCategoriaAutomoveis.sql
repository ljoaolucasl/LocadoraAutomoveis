CREATE TABLE [dbo].[TBCategoriaAutomoveis] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Nome] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_TBCategoriaAutomoveis] PRIMARY KEY CLUSTERED ([ID] ASC)
);

