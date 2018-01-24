USE MinionsDB

DECLARE @countryId INT 
SET @countryID = (SELECT Id FROM Countries
WHERE Name = @countryName)

UPDATE Towns
SET Name = UPPER(Name)
WHERE CountryId = @countryId

SELECT UPPER(t.Name) AS Town FROM Towns AS t
INNER JOIN Countries AS c
ON t.CountryId = c.Id
WHERE c.Name = @countryName