DROP SCHEMA IF EXISTS dimensionalOdyssey;
CREATE SCHEMA dimensionalOdyssey;
USE dimensionalOdyssey;

--
-- Table structure for table 'Armas'
--

CREATE TABLE armas(
	idArma SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombreArma VARCHAR(15) NOT NULL,
    descripcion VARCHAR(50) NOT NULL,
    damage SMALLINT UNSIGNED NOT NULL,
    velocidadDisparo SMALLINT UNSIGNED NOT NULL,
    cantDisparo SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (idArma)
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Table strucure for table 'Partida'
--

CREATE TABLE partida(
	idPartida SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    username VARCHAR(20) NOT NULL,
    fecha TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY (idPartida),
    CONSTRAINT `fk_username_partida`FOREIGN KEY (username) REFERENCES usuario(username) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Table structure for table 'Personaje'
-- 

CREATE TABLE personajes(
	idPersonaje SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    energia SMALLINT UNSIGNED NOT NULL,
    xp SMALLINT UNSIGNED NOT NULL,
    idArma SMALLINT UNSIGNED NOT NULL,
    idPartida SMALLINT UNSIGNED NOT NULL,
    velocidadMov SMALLINT UNSIGNED NOT NULL,
    velocidadDis SMALLINT UNSIGNED NOT NULL,
    vida SMALLINT UNSIGNED NOT NULL,
    resistencia SMALLINT UNSIGNED NOT NULL,
    recuperacionEn SMALLINT UNSIGNED NOT NULL,
    roboVida SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (idPersonaje),
    CONSTRAINT `fk_armaPersonaje` FOREIGN KEY (idArma) REFERENCES armas(idArma) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_partidaPersonaje` FOREIGN KEY (idPartida) REFERENCES partida(idPartida) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Table structure for table 'Tokens'
--

CREATE TABLE tokens(
	idToken SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombreToken VARCHAR(20) NOT NULL,
    valor BOOLEAN NOT NULL,
    idPersonaje SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (idToken),
    CONSTRAINT `fk_personaje_tokens` FOREIGN KEY (idPersonaje) REFERENCES personajes(idPersonaje) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;