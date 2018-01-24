CREATE PROC usp_GetOlder(@Id INT)
AS 
UPDATE Minions
SET Age = Age + 1
WHERE Id = @Id