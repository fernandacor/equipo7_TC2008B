USE dimensionalOdyssey;
SELECT * FROM partidas_usuarios;
SELECT * FROM contPartidas_usuarios;
SELECT * FROM contEnemiesKilled;
SELECT * FROM usersDamage;
SELECT * FROM coinsUsername;

DESC personajes;
DESC partida;

CREATE VIEW partidas_usuarios AS
SELECT idPartida, username FROM dimensionalOdyssey.partida;

CREATE VIEW contPartidas_usuarios AS
SELECT COUNT(idPartida), username FROM partida
GROUP BY username;

CREATE VIEW contEnemiesKilled AS SELECT a.username, b.enemiesKilled 
FROM dimensionalOdyssey.partida as a INNER JOIN dimensionalOdyssey.personajes as b
ON a.idPartida=b.idPartida;

CREATE VIEW usersDamage AS SELECT a.username, b.damageDealt
FROM dimensionalOdyssey.partida as a INNER JOIN dimensionalOdyssey.personajes as b
ON a.idPartida=b.idPartida;

CREATE VIEW coinsUsername AS SELECT a.username, b.coinstaken
FROM dimensionalOdyssey.partida as a INNER JOIN dimensionalOdyssey.personajes as b
ON a.idPartida=b.idPartida;

CREATE VIEW usersList AS 
SELECT username, nombre, apellido FROM dimensionalOdyssey.usuario;