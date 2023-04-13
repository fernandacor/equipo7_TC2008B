DROP SCHEMA IF EXISTS dimensionalOdyssey;
CREATE SCHEMA dimensionalOdyssey DEFAULT CHARACTER SET utf8;
USE dimensionalOdyssey;

--
-- Table structure for table 'Atributos'
--

CREATE TABLE atributos(
	velocidadMov SMALLINT UNSIGNED NOT NULL,
    velocidadDis SMALLINT UNSIGNED NOT NULL,
    vida SMALLINT UNSIGNED NOT NULL,
    resistencia SMALLINT UNSIGNED NOT NULL,
    recuperacionEn SMALLINT UNSIGNED NOT NULL,
    roboVida SMALLINT UNSIGNED NOT NULL,
    idPersonaje SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (velocidadMov, velocidadDis, vida, resistencia, recuperacionEn, roboVida),
    FOREIGN KEY (idPersonaje) REFERENCES personaje(idPersonaje)
);

--
-- Table structure for table 'Armas'
--

CREATE TABLE armas(
	idArma SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombreArma VARCHAR(15) NOT NULL,
    descripcion VARCHAR(30) NOT NULL,
    damage SMALLINT UNSIGNED NOT NULL,
    velocidadDisparo SMALLINT UNSIGNED NOT NULL,
    cantDisparo SMALLINT UNSIGNED NOT NULL,
    idToken BIT NOT NULL,
    PRIMARY KEY (idArma),
    FOREIGN KEY (idToken) REFERENCES tokens(idToken)
);

--
-- Table structure for table 'Tokens'
--

CREATE TABLE tokens(
	idToken SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombreToken VARCHAR(15) NOT NULL,
    PRIMARY KEY (idToken)
);

--
-- Table structure for table 'usuario'
--

CREATE TABLE usuario(
	username VARCHAR(20) NOT NULL,
    contraseña VARCHAR(20) NOT NULL,
    correo VARCHAR(50) NOT NULL,
    nombre VARCHAR(30) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    PRIMARY KEY (username)
);

--
-- Table strucure for table 'Partida'
--

CREATE TABLE partida(
	idPartida SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    username VARCHAR(20) NOT NULL,
    fecha TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    idPersonaje SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (idPartida),
    FOREIGN KEY (username) REFERENCES usuario(username),
    FOREIGN KEY (idPersonaje) REFERENCES personaje(id_personaje)
);

--
-- Table structure for table 'Personaje'
-- 

CREATE TABLE personaje(
	id_personaje SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    energia SMALLINT UNSIGNED NOT NULL,
    xp SMALLINT UNSIGNED NOT NULL,
    idAtributo SMALLINT UNSIGNED NOT NULL,
    idArma SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (id_personaje),
    FOREIGN KEY (idAtributo) REFERENCES atributos(id_atributo),
    FOREIGN KEY (idArma) REFERENCES armas(idArma),
);

--
-- Table structure for table 'Enemigos'
--

CREATE TABLE enemigos(
	idEnemigo SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombreEnemigo VARCHAR(15) NOT NULL,
    vida SMALLINT UNSIGNED NOT NULL,
    idAtributo SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (idEnemigo),
    FOREIGN KEY (idAtributo) REFERENCES atributos(id_atributo)
);