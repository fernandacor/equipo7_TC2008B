USE dimensionalOdyssey;
SELECT * FROM dimensionalOdyssey.usuario;
SELECT * FROM dimensionalOdyssey.armas;
SELECT * FROM dimensionalOdyssey.partida;
SELECT * FROM dimensionalOdyssey.tokens;
SELECT * FROM dimensionalOdyssey.personajes;
SELECT * FROM dimensionalOdyssey.enemigos;
SELECT * FROM dimensionalOdyssey.atributos;

INSERT INTO dimensionalOdyssey.usuario VALUES ('samacesan_sam','chami', 'a01026893@tec.mx','Samuel Roberto','Acevedo'), 
('JpAbuelo', 'jpUwU123', 'a01374091@tec.mx', 'Juan pablo', 'Moreno'), ('fernandacor','ferGameMaster0987','A01782232@tec.mx', 'Fernanda', 'Cantú'),
('sebas21mg','SebasBb','a01027028@tec.mx','Sebastian','Moncada'),('JpJoven','JpUnU456','A01783127@tec.mx','Juan Pablo', 'Ruiz'),
('alinarosasm','Aly7u7','A01252720@tec.mx','Alina','Rosas');

INSERT INTO dimensionalOdyssey.partida VALUES (NULL, 'samacesan_sam', NOW(), 1),(NULL, 'JpAbuelo', NOW(), 2),(NULL, 'fernandacor', NOW(), 3),
			(NULL, 'sebas21mg', NOW(), 4),(NULL, 'JpJoven', NOW(), 5),(NULL, 'alinarosasm', NOW(), 6);

INSERT INTO dimensionalOdyssey.armas VALUES (NULL, 'Pistola', 'Pistola de corto alcance', 15, 3, 1), (NULL, 'Escopeta', 'Escopeta de corto alcance', 30, 1, 3), 
			(NULL, 'Ametralladora', 'Ametralladora de mediano alcance', 23, 5, 1);
            
INSERT INTO dimensionalOdyssey.personajes VALUES (NULL, 100, 3500, 2, 1), (NULL, 85, 2500, 3, 2), (NULL, 98, 5500, 2, 3), 
			(NULL, 100, 500, 3, 4), (NULL, 44, 10500, 3, 5), (NULL, 60, 5000, 1, 6);
            
INSERT INTO dimensionalOdyssey.enemigos VALUES (NULL, 'SecuacesDimDorada'), (NULL, 'SecuacesDimMilitar'), (NULL, 'SecuacesDimNormal'), (NULL, 'SecuacesDimColorida'), 
			(NULL, 'BossDimDorada'), (NULL, 'BossDimMilitar'), (NULL, 'BossDimColorida'), (NULL, 'FinalBoss');

INSERT INTO dimensionalOdyssey.tokens VALUES (NULL, 'Multidisparo', 0, 1), (NULL, 'Disparo doble', 1, 1), (NULL, 'Disparo trasero', 1, 1), (NULL, 'Disparo Rebote', 0, 1),
			(NULL, 'Multidisparo', 1, 2), (NULL, 'Disparo doble', 0, 2), (NULL, 'Disparo trasero', 1, 2), (NULL, 'Disparo Rebote', 1, 2),
			(NULL, 'Multidisparo', 0, 3), (NULL, 'Disparo doble', 0, 3), (NULL, 'Disparo trasero', 0, 3), (NULL, 'Disparo Rebote', 1, 3),
            (NULL, 'Multidisparo', 1, 4), (NULL, 'Disparo doble', 1, 4), (NULL, 'Disparo trasero', 1, 4), (NULL, 'Disparo Rebote', 0, 4),
            (NULL, 'Multidisparo', 0, 5), (NULL, 'Disparo doble', 0, 5), (NULL, 'Disparo trasero', 0, 5), (NULL, 'Disparo Rebote', 0, 5),
            (NULL, 'Multidisparo', 1, 6), (NULL, 'Disparo doble', 1, 6), (NULL, 'Disparo trasero', 1, 6), (NULL, 'Disparo Rebote', 1, 6);
            
INSERT INTO dimensionOdyssey.atributos VALUES (NULL, 10, 0, 100, 60, 25, 10, 1, NULL), (NULL, 15, 5, 85, 35, 40, 5, 2, NULL), (NULL, 5, 7, 90, 30, 55, 8, 3, NULL),
			(NULL, 20, 5, 100, 50, 15, 10, 4, NULL), (NULL, 10, 6, 80, 40, 50, 10, 5, NULL), (NULL, 10, 3, 75, 70, 45, 3, 6, NULL),
            (NULL, 10, 0, 100, 60, 25, 10, NULL, 1), (NULL, 15, 5, 85, 35, 40, 5, NULL, 2), (NULL, 5, 7, 90, 30, 55, 8, NULL, 3),
            (NULL, 8, 0, 100, 60, 25, 10, NULL, 4), (NULL, 10, 10, 500, 35, 40, 15, NULL, 5), (NULL, 20, 9, 500, 30, 55, 15, NULL, 6),
            (NULL, 10, 0, 500, 60, 25, 15, NULL, 7), (NULL, 25, 13, 1000, 120, 50, 25, NULL, 8);

