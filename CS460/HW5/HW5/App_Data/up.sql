--Forms Table
CREATE TABLE [dbo].[Forms]
(
	[ID]			INT IDENTITY (1,1)	NOT NULL,
	[FirstName]		NVARCHAR(64)		NOT NULL,
	[LastName]		NVARCHAR(64)		NOT NULL,
	[Phone]			NVARCHAR(64)		NOT NULL,
	[ApartmentName]	NVARCHAR(64)		NOT NULL,
	[UnitNumber]	INT					NOT NULL,
	[Explanation]	VARCHAR(364)		NOT NULL,
	[Permission]	BIT					NOT NULL,
	CONSTRAINT [PK_dbo.Forms] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Forms] (FirstName, LastName, Phone, ApartmentName, UnitNumber, Explanation, Permission) VALUES
	('Nina', 'Loser', '999-999-9178', 'Home', 12, 'Super Important', 0),
	('Anglea', 'Nihei', '999-899-7473', 'Hawaii', 3, 'Not important', 1),
	('Ed', 'Key', '888-889-7616', 'Oahu', 6, 'Super broken', 1),
	('Junior', 'John', '888-809-7616', 'Monmouth', 1, 'Kinda broken', 0),
	('Boy', 'Robins', '888-889-0000', 'Kuliouou', 8, 'Not important', 0)
GO

--Select * from dbo.Forms