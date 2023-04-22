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

INSERT INTO dimensionalOdyssey.partida VALUES (NULL, 'samacesan_sam', NOW()),(NULL, 'JpAbuelo', NOW()),(NULL, 'fernandacor', NOW()),
			(NULL, 'sebas21mg', NOW()),(NULL, 'JpJoven', NOW()),(NULL, 'alinarosasm', NOW());

INSERT INTO dimensionalOdyssey.armas VALUES (NULL, 'Pistola', 'Pistola de corto alcance', 15, 3, 1), (NULL, 'Escopeta', 'Escopeta de corto alcance', 30, 1, 3), 
			(NULL, 'Ametralladora', 'Ametralladora de mediano alcance', 23, 5, 1);
            
INSERT INTO dimensionalOdyssey.personajes VALUES (NULL, 100, 3500, 2, 1,10, 0, 100, 60, 25, 10), (NULL, 85, 2500, 3, 2,15, 5, 85, 35, 40, 5), 
(NULL, 98, 5500, 2, 3, 5, 7, 90, 30, 55, 8), (NULL, 100, 500, 3, 4,20, 5, 100, 50, 15, 10), (NULL, 44, 10500, 3, 5,10, 6, 80, 40, 50, 10), (NULL, 60, 5000, 1, 6,10, 3, 75, 70, 45, 3);
            

INSERT INTO dimensionalOdyssey.tokens VALUES (NULL, 'Multidisparo', 0, 1), (NULL, 'Disparo doble', 1, 1), (NULL, 'Disparo trasero', 1, 1), (NULL, 'Disparo Rebote', 0, 1),
			(NULL, 'Multidisparo', 1, 2), (NULL, 'Disparo doble', 0, 2), (NULL, 'Disparo trasero', 1, 2), (NULL, 'Disparo Rebote', 1, 2),
			(NULL, 'Multidisparo', 0, 3), (NULL, 'Disparo doble', 0, 3), (NULL, 'Disparo trasero', 0, 3), (NULL, 'Disparo Rebote', 1, 3),
            (NULL, 'Multidisparo', 1, 4), (NULL, 'Disparo doble', 1, 4), (NULL, 'Disparo trasero', 1, 4), (NULL, 'Disparo Rebote', 0, 4),
            (NULL, 'Multidisparo', 0, 5), (NULL, 'Disparo doble', 0, 5), (NULL, 'Disparo trasero', 0, 5), (NULL, 'Disparo Rebote', 0, 5),
            (NULL, 'Multidisparo', 1, 6), (NULL, 'Disparo doble', 1, 6), (NULL, 'Disparo trasero', 1, 6), (NULL, 'Disparo Rebote', 1, 6);
