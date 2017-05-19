USE Chinook;

-- MySQL

-- DROP TABLE CustomerDocument
-- TRUNCATE TABLE CustomerDocument

CREATE TABLE CustomerDocument
(
    CustomerDocumentId integer AUTO_INCREMENT NOT NULL, 
    CustomerId integer NOT NULL, 
    Description varchar(100) NOT NULL,
    FileName varchar(100) NOT NULL,
	FileAcronym varchar(10) NOT NULL, -- docx | xlsx | pdf | ...
	PRIMARY KEY (CustomerDocumentId)
);
ALTER TABLE CustomerDocument ADD CONSTRAINT FK_CustomerDocument_01
    FOREIGN KEY(CustomerId) REFERENCES Customer(CustomerId) ON UPDATE CASCADE;
CREATE INDEX IX_CustomerDocument_01 ON CustomerDocument(CustomerId);
CREATE INDEX IX_CustomerDocument_02 ON CustomerDocument(FileName);
CREATE INDEX IX_CustomerDocument_03 ON CustomerDocument(FileAcronym);

/*
INSERT INTO CustomerDocument VALUES (1, 'Excel', 'xlsx');
INSERT INTO CustomerDocument VALUES (1, 'PDF', 'pdf');
INSERT INTO CustomerDocument VALUES (1, 'Word', 'docx');
*/