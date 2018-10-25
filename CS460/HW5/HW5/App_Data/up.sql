--Forms Table
CREATE TABLE [dbo].[Forms]
(
	[ID]			INT IDENTITY (1,1)	NOT NULL,
	[FirstName]		NVARCHAR(64)		NOT NULL,
	[LastName]		NVARCHAR(64)		NOT NULL,
	[Phone]			NVARCHAR(64)		NOT NULL,
	[ApartmentName]	NVARCHAR(64)		NOT NULL,
	[UnitNumber]	INT					NOT NULL,
	CONSTRAINT [PK_dbo.Forms] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Forms] (FirstName, LastName, Phone, ApartmentName, UnitNumber) VALUES
	('Nina', 'Ki', '808-772-9178', 'Home', 12),
	('Anglea', 'Ki', '808-479-7473', 'Home', 3),
	('Ed', 'Ki', '808-479-7616', 'Home', 6)
GO

