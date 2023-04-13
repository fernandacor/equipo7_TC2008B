DROP SCHEMA IF EXISTS dimensionalOdyssey;
CREATE SCHEMA dimensionalOdyssey DEFAULT CHARACTER SET utf8;
USE dimensionalOdyssey;

--
-- Table structure for table 'Enemigos'
--

CREATE TABLE enemigos(
	idEnemigo SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombreEnemigo VARCHAR(15) NOT NULL,
    PRIMARY KEY (idEnemigo)
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
    PRIMARY KEY (idArma)
);

--
-- Table structure for table 'usuario'
--

CREATE TABLE usuario(
	username VARCHAR(20) NOT NULL,
    contrasena VARCHAR(20) NOT NULL,
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
    CONSTRAINT `fk_username_partida`FOREIGN KEY (username) REFERENCES usuario(username) ON DELETE RESTRICT ON UPDATE CASCADE
);

--
-- Table structure for table 'Personaje'
-- 

CREATE TABLE personajes(
	idPersonaje SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    energia SMALLINT UNSIGNED NOT NULL,
    xp SMALLINT UNSIGNED NOT NULL,
    idArma SMALLINT UNSIGNED NOT NULL,
    idPartida SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (idPersonaje),
    CONSTRAINT `fk_armaPersonaje` FOREIGN KEY (idArma) REFERENCES armas(idArma) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_partidaPersonaje` FOREIGN KEY (idPartida) REFERENCES partida(idPartida) ON DELETE RESTRICT ON UPDATE CASCADE
);

--
-- Table structure for table 'Tokens'
--

CREATE TABLE tokens(
	idToken SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombreToken VARCHAR(15) NOT NULL,
    valor BIT NOT NULL,
    idPersonaje SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (idToken),
    CONSTRAINT `fk_personaje_tokens` FOREIGN KEY (idPersonaje) REFERENCES personajes(idPersonaje) ON DELETE RESTRICT ON UPDATE CASCADE
);

--
-- Table structure for table 'Atributos'
--

CREATE TABLE atributos(
	idAtributo SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
	velocidadMov SMALLINT UNSIGNED NOT NULL,
    velocidadDis SMALLINT UNSIGNED NOT NULL,
    vida SMALLINT UNSIGNED NOT NULL,
    resistencia SMALLINT UNSIGNED NOT NULL,
    recuperacionEn SMALLINT UNSIGNED NOT NULL,
    roboVida SMALLINT UNSIGNED NOT NULL,
    idPersonaje SMALLINT UNSIGNED NOT NULL,
	idEnemigo SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (idAtributo),
    CONSTRAINT `fk_personaje_atributos` FOREIGN KEY (idPersonaje) REFERENCES personajes(idPersonaje) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_enemigos_atributos` FOREIGN KEY (idEnemigo) REFERENCES enemigos(idEnemigo) ON DELETE RESTRICT ON UPDATE CASCADE
);
