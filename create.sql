	/*	Voer eerst het script createDB.sql uit! */
	USE dbSchool;

	if OBJECT_ID('tblRichting') IS NULL
	BEGIN 
		CREATE TABLE tblRichting 
		(
			richting_id int IDENTITY(1,1) PRIMARY KEY,
			naam varchar(255) NOT NULL,
			omschrijving text NOT NULL
		)
		print('Tabel "tblRichting" is successvol toegevoegd.');
	END
	ELSE 
	BEGIN
		PRINT('De tabel "tblRichting" bestaat al  in deze database.');
	END

	if OBJECT_ID('tblDocent') IS NULL
	BEGIN
		CREATE TABLE tblDocent
		(
			docent_id int IDENTITY(1,1) PRIMARY KEY, 
			voornaam varchar(255) NOT NULL,
			achternaam varchar(255) NOT NULL,
			email varchar(255)
		)
		print('Tabel "tblDocent" is successvol toegevoegd.');
	END
	ELSE 
	BEGIN
		PRINT('De tabel "tblDocent" bestaat al  in deze database.');
	END

	if OBJECT_ID('tblKlasgroep') IS NULL
	BEGIN
		CREATE TABLE tblKlasgroep
		(
			klasgroep_id int IDENTITY(1,1) PRIMARY KEY,
			naam varchar(255) NOT NULL,
			klascode varchar(5) NOT NULL,
			richting_id int FOREIGN KEY REFERENCES tblRichting(richting_id),
			docent_id int FOREIGN KEY REFERENCES tblDocent(docent_id)
		)
		print('Tabel "tblKlasgroep" is successvol toegevoegd.');
	END
	ELSE 
	BEGIN
		PRINT('De tabel "tblKlasgroep" bestaat al  in deze database.');
	END



	if OBJECT_ID('tblStudent') IS NULL
	BEGIN
		CREATE TABLE tblStudent
		(
			student_id int IDENTITY(1,1) PRIMARY KEY, 
			voornaam varchar(255) NOT NULL, 
			achternaam varchar(255) NOT NULL, 
			email_ouder varchar(255),
			rapport_wiskunde float NULL,
			rapport_frans float NULL,
			rapport_engels float NULL,
			rapport_sport float NULL,
			rapport_biologie float NULL,
			klasgroep_id int FOREIGN KEY REFERENCES tblKlasgroep(klasgroep_id)
		)
		print('Tabel "tblStudent" is successvol toegevoegd.');
	END
	ELSE 
	BEGIN
		PRINT('De tabel "tblStudent" bestaat al  in deze database.');
	END
