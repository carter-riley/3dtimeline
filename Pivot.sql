--How to access Database in shell

--\sql
--\connect root@localhost
--team7

DROP TABLE IF EXISTS Artifacts;
DROP TABLE IF EXISTS AllData;
DROP TABLE IF EXISTS phildata;
DROP TABLE IF EXISTS philantropy;
--------------------------------------------------------------------------------------------------------------------------
-----------CREATE THE TABLE FOR COMING OF AGE NARRATIVE TO EXPORT TO UNITY----------------------------

-- Creates a new table named AllData that holds all artifacts with the tag "Coming of Age"
CREATE VIEW COAData AS
SELECT DISTINCT e.record_id, e.element_id, e.text, f.filename
FROM omeka_element_texts e, omeka_files f
WHERE e.record_id = f.item_id AND e.record_id = ANY (SELECT record_id FROM omeka_tags t JOIN omeka_records_tags r ON t.id = r.tag_id WHERE t.id = 1044); -- t.id = 1044 refers to tag coming of age

--Creates an empty table to hold data for each artifact for coming of age narrative
CREATE TABLE ComingofAge (
	Record_id int,
	Title varchar(50),
	Date_id varchar(50),
	Source varchar(100),
	Type_of varchar(100),
	format_type varchar(50),
	URL varchar(50),
	PRIMARY KEY (Record_id)
);

--Inserts all Record_id's into artifacts. Each record_ird refers to one item
INSERT INTO ComingofAge(Record_id)
SELECT DISTINCT record_id
FROM COAData;

--Adds the Titles into table Artifacts based on record_id
UPDATE ComingofAge a, COAData d SET a.title = d.text
WHERE a.record_id = d.record_id AND d.element_id = 50; -- id 50 refers to title

--Adds the dates into table Artifacts based on record_id
UPDATE ComingofAge a, COAData d SET a.Date_id = d.text
WHERE a.record_id = d.record_id AND d.element_id = 40;

--Adds the Source into table Artifacts based on record_id
UPDATE ComingofAge a, COAData d SET a.Source = d.text
WHERE a.record_id = d.record_id AND d.element_id = 48;

--Adds the type into table Artifacts based on record_id
UPDATE ComingofAge a, COAData d SET a.Type_of = d.text
WHERE a.record_id = d.record_id AND d.element_id = 51;

--Adds the format into table Artifacts based on record_id
UPDATE ComingofAge a, COAData d SET a.format_type = d.text
WHERE a.record_id = d.record_id AND d.element_id = 42;

--Adds the URL's into table Artifacts 
UPDATE ComingofAge a, COAData d SET a.url = d.filename
WHERE a.record_id = d.record_id;

-----------------------------------------------------------------------------------------------------------
--------------CREATE THE TABLE FOR PHILANTHROPY NARRATIVE TO EXPORT TO UNITY-------------
CREATE VIEW phildata AS
SELECT DISTINCT e.record_id, e.element_id, e.text, f.filename
FROM omeka_element_texts e, omeka_files f
WHERE e.record_id = f.item_id AND e.record_id = ANY (SELECT record_id FROM omeka_tags t JOIN omeka_records_tags r ON t.id = r.tag_id WHERE t.id = 180); -- t.id = 180 refers to tag Philantropy

CREATE VIEW phildata AS
SELECT e.record_id, e.element_id, e.text, f.filename
FROM omeka_element_texts e LEFT OUTER JOIN omeka_files f ON e.record_id = f.item_id, omeka_tags t, omeka_records_tags r 
WHERE e.record_id = r.record_id AND r.tag_id = t.id AND t.id = 180;

--Creates an empty table to hold data for each artifact in Philantropy
CREATE TABLE philanthropy (
	Record_id int,
	Title varchar(100),
	Date_id varchar(50),
	Source varchar(50),
	Type_of varchar(100),
	format_type varchar(50),
	URL varchar(50),
	PRIMARY KEY (Record_id)
);

--Inserts all Record_id's into artifacts. Each record_ird refers to one item
INSERT INTO philanthropy(Record_id)
SELECT DISTINCT record_id
FROM phildata;


--Adds the Titles into table Artifacts based on record_id
UPDATE philanthropy p, phildata d SET p.title = d.text
WHERE p.record_id = d.record_id AND d.element_id = 50; -- id 50 refers to title

--Adds the dates into table Artifacts based on record_id
UPDATE philanthropy p, phildata d SET p.Date_id = d.text
WHERE p.record_id = d.record_id AND d.element_id = 40;

--Adds the Source into table Artifacts based on record_id
UPDATE philanthropy p, phildata d SET p.Source = d.text
WHERE p.record_id = d.record_id AND d.element_id = 48;

--Adds the type into table Artifacts based on record_id
UPDATE philanthropy p, phildata d SET p.Type_of = d.text
WHERE p.record_id = d.record_id AND d.element_id = 51;

--Adds the format into table Artifacts based on record_id
UPDATE philanthropy p, phildata d SET p.format_type = d.text
WHERE p.record_id = d.record_id AND d.element_id = 42;

--Adds the URL's into table Artifacts 
UPDATE philanthropy p, phildata d SET p.url = d.filename
WHERE p.record_id = d.record_id;
