﻿CREATE TABLE [dbo].[FileLocation]
(
	[FileLocationId] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Location] VARCHAR(MAX) NOT NULL,
    [DateCreatedUtc] DATETIME NOT NULL DEFAULT GETUTCDATE()
)
