--Create 4 Tables
--Be careful with foreign key use, make sure to follow diagram
CREATE TABLE [dbo].[Buyer]
(
	[ID]		INT IDENTITY (1,1)	NOT NULL,
	[Name]		NVARCHAR(50)		NOT NULL,
	CONSTRAINT [PK_dbo.Buyer] PRIMARY KEY CLUSTERED (Name)
);
CREATE TABLE [dbo].[Seller]
(
	[ID]		INT IDENTITY (1,1)	NOT NULL,
	[Name]		NVARCHAR(50)		NOT NULL,
	CONSTRAINT [PK_dbo.Seller] PRIMARY KEY CLUSTERED (Name)
);
--Needed to set ID to start at 1001 for proper use of the given insert statements below
CREATE TABLE [dbo].[Item]
(
	[ID]			INT IDENTITY (1001,1)	NOT NULL,
	[Name]			NVARCHAR(50)			NOT NULL,
	[Description]	NVARCHAR(150)			NOT NULL,
	[Seller]		NVARCHAR(50)			NOT NULL,
	CONSTRAINT [PK_dbo.Item] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Item] FOREIGN KEY (Seller) REFERENCES [dbo].[Seller] (Name) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [dbo].[Bid]
(
	[ID]			INT IDENTITY (1,1)	NOT NULL,
	[ItemID]		INT					NOT NULL,
	[Buyer]			NVARCHAR(50)		NOT NULL,
	[Price]			INT					NOT NULL,
	[Timestamp]		DATETIME			NOT NULL,
	CONSTRAINT [PK_dbo.Bid] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK1_dbo.Bid] FOREIGN KEY (Buyer) REFERENCES [dbo].[Buyer] (Name),
	CONSTRAINT [FK2_dbo.Bid] FOREIGN KEY (ItemID) REFERENCES [dbo].[Item] (ID),
);

--Populate the above tables with code given from Dr.Morse in the HW
INSERT INTO [dbo].[Buyer] (Name) VALUES
('Jane Stone'),
('Tom McMasters'),
('Otto Vanderwall');
GO

INSERT INTO [dbo].[Seller] (Name) VALUES
('Gayle Hardy'),
('Lyle Banks'),
('Pearl Greene');
GO

INSERT INTO [dbo].[Item] (Name, Description, Seller) VALUES
('Abraham Lincoln Hammer'    ,'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln', 'Pearl Greene'),
('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927', 'Lyle Banks'),
('Bob Dylan Love Poems'      ,'Five versions of an original unpublished, handwritten, love poem by Bob Dylan', 'Gayle Hardy');
GO

INSERT INTO [dbo].[Bid] (ItemID, Buyer, Price, Timestamp) VALUES
(1001, 'Jane Stone',250000,'12/04/2017 09:04:22'),
(1003, 'Tom McMasters', 95000 ,'12/04/2017 08:44:03');
GO