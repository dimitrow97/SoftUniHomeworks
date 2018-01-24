USE MinionsDB

SELECT COUNT(t.Name) AS Count FROM Towns AS t
INNER JOIN Countries AS c
ON t.CountryId = c.Id
WHERE c.Name = @countryName
