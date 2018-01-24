USE MinionsDB

SELECT m.Name, m.Age FROM Minions AS m
INNER JOIN MinionsVillains AS v
ON m.Id = v.MinionId
WHERE v.VillainId = @villainsId