USE dimensionalOdyssey;
SELECT * FROM partidas_usuarios;
SELECT * FROM contPartidas_usuarios;

CREATE VIEW partidas_usuarios AS
SELECT idPartida, username FROM dimensionalOdyssey.partida;

CREATE VIEW contPartidas_usuarios AS
SELECT COUNT(idPartida), username FROM partida
GROUP BY username;