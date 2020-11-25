CREATE TABLE [dbo].[History]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(0,1),
	[ServerId] INT NOT NULL,
	[TimeStamp] DATETIME NOT NULL,
	[CPU] INT NOT NULL,
	[Memory] INT NOT NULL,
	[DriveC] INT NOT NULL,
	[Users] INT NOT NULL,
	[Uptime] INT NOT NULL

)
