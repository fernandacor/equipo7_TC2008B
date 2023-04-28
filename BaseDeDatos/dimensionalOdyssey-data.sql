USE dimensionalOdyssey;

DESC dimensionalOdyssey.partida;
DESC dimensionalOdyssey.armas;
DESC dimensionalOdyssey.personajes;
DESC dimensionalOdyssey.tokens;
SELECT * FROM dimensionalOdyssey.usuario;
SELECT * FROM dimensionalOdyssey.armas;
SELECT * FROM dimensionalOdyssey.partida;
SELECT * FROM dimensionalOdyssey.tokens;
SELECT * FROM dimensionalOdyssey.items;
SELECT * FROM dimensionalOdyssey.personajes;
SELECT * FROM dimensionalOdyssey.newToken;
SELECT * FROM dimensionalOdyssey.newItems;

INSERT INTO dimensionalOdyssey.usuario VALUES ('samacesan_sam','chami', 'a01026893@tec.mx','Samuel Roberto','Acevedo'), 
('JpAbuelo', 'jpUwU123', 'a01374091@tec.mx', 'Juan pablo', 'Moreno'), ('fernandacor','ferGameMaster0987','A01782232@tec.mx', 'Fernanda', 'Cantú'),
('sebas21mg','SebasBb','a01027028@tec.mx','Sebastian','Moncada'),('JpJoven','JpUnU456','A01783127@tec.mx','Juan Pablo', 'Ruiz'),
('alinarosasm','Aly7u7','A01252720@tec.mx','Alina','Rosas');
            
INSERT INTO dimensionalOdyssey.partida (username, fecha) VALUES ('samacesan_sam', NOW()), ('JpAbuelo', NOW()), ('fernandacor', NOW()),
('sebas21mg', NOW()), ('JpJoven', NOW()), ('alinarosasm', NOW());

INSERT INTO dimensionalOdyssey.armas (nombreArma, descripcion, damage, velocidadDisparo, cantDisparo) VALUES ('Pistola', 'Pistola de corto alcance', 15, 3, 1), ('Escopeta', 'Escopeta de corto alcance', 30, 1, 3), 
			('Ametralladora', 'Ametralladora de mediano alcance', 23, 5, 1);
            
INSERT INTO dimensionalOdyssey.personajes (energia, xp, idArma, idPartida, velocidadMov, velocidadDis, vida, resistencia, recuperacionEn, enemiesKilled, damageDealt, coinsTaken) VALUES (100, 3500, 2, 1,10, 0, 100, 60, 25, 45, 750, 15), (85, 2500, 3, 2,15, 5, 85, 35, 40, 30, 500, 10), 
(98, 5500, 2, 3, 5, 7, 90, 30, 55, 55, 900, 20), (100, 500, 3, 4,20, 5, 100, 50, 15, 40, 625, 12), (44, 10500, 3, 5,10, 6, 80, 40, 50, 70, 1200, 25), (60, 5000, 1, 6,10, 3, 75, 70, 45, 33, 560, 8);
            

INSERT INTO dimensionalOdyssey.tokens (nombreToken, valor, idPersonaje) VALUES ('Multidisparo', 0, 1), ('Disparo doble', 1, 1), ('Disparo trasero', 1, 1), ('Disparo Rebote', 0, 1),
			('Multidisparo', 1, 2), ('Disparo doble', 0, 2), ('Disparo trasero', 1, 2), ('Disparo Rebote', 1, 2),
			('Multidisparo', 0, 3), ('Disparo doble', 0, 3), ('Disparo trasero', 0, 3), ('Disparo Rebote', 1, 3),
            ('Multidisparo', 1, 4), ('Disparo doble', 1, 4), ('Disparo trasero', 1, 4), ('Disparo Rebote', 0, 4),
            ('Multidisparo', 0, 5), ('Disparo doble', 0, 5), ('Disparo trasero', 0, 5), ('Disparo Rebote', 0, 5),
            ('Multidisparo', 1, 6), ('Disparo doble', 1, 6), ('Disparo trasero', 1, 6), ('Disparo Rebote', 1, 6);

INSERT INTO dimensionalOdyssey.newToken (idPersonaje, multiDoble, multiTriple, multiCuadriple, disDoble, disTriple, rebote, autoDir) VALUES (1, 0, 0, 0, 0, 0, 0, 0),
			(2, 0, 0, 0, 0, 0, 0, 0), (3, 0, 0, 0, 0, 0, 0, 0), (4, 0, 0, 0, 0, 0, 0, 0), (5, 0, 0, 0, 0, 0, 0, 0), (6, 0, 0, 0, 0, 0, 0, 0);

INSERT INTO dimensionalOdyssey.newItems (idPersonaje, velocidad, energia, vida, superVida, superEnergia, inmunidad, mystery) VALUES (1, 0, 0, 0, 0, 0, 0, 0),
			(2, 0, 0, 0, 0, 0, 0, 0), (3, 0, 0, 0, 0, 0, 0, 0), (4, 0, 0, 0, 0, 0, 0, 0), (5, 0, 0, 0, 0, 0, 0, 0), (6, 0, 0, 0, 0, 0, 0, 0);

INSERT INTO dimensionalOdyssey.partida (username, fecha) VALUES ('sebas21mg', NOW());

INSERT INTO dimensionalOdyssey.personajes (energia, xp, idArma, idPartida, velocidadMov, velocidadDis, vida, resistencia, recuperacionEn, enemiesKilled, damageDealt, coinsTaken) 
VALUES (100, 3500, 2, LAST_INSERT_ID(), 10, 0, 100, 60, 25, 10);

--
-- Ejemplo de como hacer update a las estadísticas
--

UPDATE personajes
SET energia = 85,
    xp = 500,
    velocidadMov = 13,
    velocidadDis = 3,
    vida = 50,
    resistencia = 70,
    recuperacionEn = 28,
    roboVida = 15
WHERE idPartida = 1;