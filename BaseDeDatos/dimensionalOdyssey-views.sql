USE dimensionalOdyssey;
SELECT * FROM partidas_usuarios;
SELECT * FROM contPartidas_usuarios;

DESC personajes;
DESC partida;

CREATE VIEW partidas_usuarios AS
SELECT idPartida, username FROM dimensionalOdyssey.partida;

CREATE VIEW contPartidas_usuarios AS
SELECT COUNT(idPartida), username FROM partida
GROUP BY username;

CREATE VIEW contEnemiesKilled AS SELECT a.username, b.enemiesKilled 
FROM dimensionalOdyssey.partida as a INNER JOIN dimensionalOdyssey.personajes as b
ON a.idPartida=b.idPartida

