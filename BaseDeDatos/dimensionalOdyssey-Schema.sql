USE dimensionalOdyssey;

--
-- Table structure for table 'usuario'
--

CREATE TABLE usuario(
	username VARCHAR(20) NOT NULL,
	nombre_usuario VARCHAR(20) NOT NULL,
    contraseña VARCHAR(20) NOT NULL,
    correo VARCHAR(50) NOT NULL,
    PRIMARY KEY (username)
);

--
-- Table structure for table 'Atributos'
--

CREATE TABLE atributos(
	id_atributo SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    velocidad_movimiento SMALLINT UNSIGNED NOT NULL,
    fuerza SMALLINT UNSIGNED NOT NULL,
    resistencia SMALLINT UNSIGNED NOT NULL,
    damage SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (id_atributo)
);

--
-- Table structure for table 'Personaje'
-- 

CREATE TABLE personaje(
	id_personaje SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    vida SMALLINT UNSIGNED NOT NULL,
    energia SMALLINT UNSIGNED NOT NULL,  
    xp SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (id_personaje)
);
