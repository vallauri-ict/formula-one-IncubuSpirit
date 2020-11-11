CREATE TABLE [dbo].[Teams] (
    [id] INT IDENTITY (1, 1) NOT NULL,
    [name] VARCHAR (128) NOT NULL,
    [fullTeamName] VARCHAR (256) NOT NULL,
    [Country] CHAR (2) NOT NULL,
    [powerUnit] VARCHAR (128) NOT NULL,
    [technicalChief] VARCHAR (128) NOT NULL,
    [FirstDriver] INT NOT NULL,
    [SecondDriver] INT NOT NULL,
	[logo] VARCHAR(512)	NOT NULL,
	[img] VARCHAR(512) NOT NULL
    PRIMARY KEY CLUSTERED ([id] ASC)
);

SET IDENTITY_INSERT [dbo].[Teams] ON;
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [Country], [powerUnit], [technicalChief], [FirstDriver], [SecondDriver], [logo], [img])
VALUES (1, 'Alfa Romeo', 'Alfa Romeo Racing', 'CH', 'Ferrari', 'Jan Monchaux', 'C38', 14, 16, 'https://www.formula1.com/content/fom-website/en/teams/Alfa-Romeo-Racing/_jcr_content/logo.img.jpg/1582650443223.jpg', 'https://www.formula1.com/content/dam/fom-website/teams/2020/alfa-romeo-racing.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [Country], [powerUnit], [technicalChief], [FirstDriver], [SecondDriver], [logo], [img])
VALUES (2, 'Ferrari', 'Scuderia Ferrari Mission Winnow', 'IT', 'Ferrari', 'Mattia Binotto', 'SF90', 3, 5, 'https://www.formula1.com/content/fom-website/en/teams/Ferrari/_jcr_content/logo.img.jpg/1521797345005.jpg', 'https://www.formula1.com/content/dam/fom-website/teams/2020/ferrari.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [Country], [powerUnit], [technicalChief], [FirstDriver], [SecondDriver], [logo], [img])
VALUES (3, 'Red Bull', 'Aston Martin Red Bull Racing', 'GB', 'Honda', 'Pierre Waché', 'RB15', 7, 8, 'https://www.formula1.com/content/fom-website/en/teams/Red-Bull-Racing/_jcr_content/logo.img.jpg/1514762875081.jpg', 'https://www.formula1.com/content/dam/fom-website/teams/2020/red-bull-racing.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [Country], [powerUnit], [technicalChief], [FirstDriver], [SecondDriver], [logo], [img])
VALUES (4, 'Haas', 'Haas F1 Team', 'US', 'Ferrari', 'Rob Taylor', 'VF-19', 18, 17, 'https://www.formula1.com/content/fom-website/en/teams/Haas-F1-Team/_jcr_content/logo.img.png/1568040720597.png', 'https://www.formula1.com/content/dam/fom-website/teams/2020/haas-f1-team.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [Country], [powerUnit], [technicalChief], [FirstDriver], [SecondDriver], [logo], [img])
VALUES (5, 'McLaren', 'McLaren F1 Team', 'GB', 'Renault', 'James Key', 'MCL34', 9, 10, 'https://www.formula1.com/content/fom-website/en/teams/McLaren/_jcr_content/logo.img.jpg/1515152671364.jpg', 'https://www.formula1.com/content/dam/fom-website/teams/2020/mclaren.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [Country], [powerUnit], [technicalChief], [FirstDriver], [SecondDriver], [logo], [img])
VALUES (6, 'Mercedes', 'Mercedes AMG Petronas Motorsport', 'GB', 'Mercedes', 'James Allison', 'W10', 1, 2, 'https://www.formula1.com/content/fom-website/en/teams/Mercedes/_jcr_content/logo.img.jpg/1582638375557.jpg', 'https://www.formula1.com/content/dam/fom-website/teams/2020/mercedes.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [Country], [powerUnit], [technicalChief], [FirstDriver], [SecondDriver], [logo], [img])
VALUES (7, 'Toro Rosso', 'Red Bull Toro Rosso Honda', 'IT', 'Honda', 'Jody Eggington', 'STR14', 4, 20, 'https://www.formula1.it/admin/foto/Scuderie/Scuderia_173.gif.png', 'https://www.formula1.com/content/dam/fom-website/teams/2020/alphatauri.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [Country], [powerUnit], [technicalChief], [FirstDriver], [SecondDriver], [logo], [img])
VALUES (8, 'Racing Point', 'SportPesa Racing Point F1 Team', 'GB', 'BWT Mercedes', 'Andrew Green', 'RP19', 12, 15, 'https://www.formula1.com/content/fom-website/en/teams/Racing-Point/_jcr_content/logo.img.jpg/1582650505746.jpg', 'https://www.formula1.com/content/dam/fom-website/teams/2020/racing-point.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [Country], [powerUnit], [technicalChief], [FirstDriver], [SecondDriver], [logo], [img])
VALUES (9, 'Williams', 'ROKiT Williams Racing', 'GB', 'Mercedes', 'TBC', 'FW42', 13, 19, 'https://www.formula1.com/content/fom-website/en/teams/Williams/_jcr_content/logo.img.png/1551261665481.png', 'https://www.formula1.com/content/dam/fom-website/teams/2020/williams.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [Country], [powerUnit], [technicalChief], [FirstDriver], [SecondDriver], [logo], [img])
VALUES (10, 'Renault', 'Renault F1 Team', 'GB', 'Renault', 'Nick Chester', 'R.S.19', 6, 11, 'https://www.formula1.com/content/fom-website/en/teams/Renault/_jcr_content/logo.img.jpg/1584017512684.jpg', 'https://www.formula1.com/content/dam/fom-website/teams/2020/renault.png.transform/2col/image.png');
SET IDENTITY_INSERT [dbo].[Teams] OFF;