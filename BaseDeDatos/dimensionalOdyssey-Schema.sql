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
    PRIMARY KEY (idArma),
    KEY idx_idArma (idArma)
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
    PRIMARY KEY (username),
    KEY idx_username (username)
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Table strucure for table 'Partida'
--

CREATE TABLE partida(
	idPartida SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    username VARCHAR(20) NOT NULL,
    fecha TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY (idPartida),
    CONSTRAINT `fk_username_partida`FOREIGN KEY (username) REFERENCES usuario(username) ON DELETE RESTRICT ON UPDATE CASCADE,
    KEY idx_idPartida (idPartida)
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
	enemiesKilled SMALLINT UNSIGNED NOT NULL,
    damageDealt SMALLINT UNSIGNED NOT NULL,
    coinsTaken SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (idPersonaje),
    CONSTRAINT `fk_armaPersonaje` FOREIGN KEY (idArma) REFERENCES armas(idArma) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_partidaPersonaje` FOREIGN KEY (idPartida) REFERENCES partida(idPartida) ON DELETE RESTRICT ON UPDATE CASCADE,
    KEY idx_fk_partidaPersonaje (idPartida)
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

--
-- New table structure for table 'Tokens'
--

CREATE TABLE newToken(
	idToken SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    idPersonaje SMALLINT UNSIGNED NOT NULL,
    multiDoble SMALLINT UNSIGNED NOT NULL,
    multiTriple SMALLINT UNSIGNED NOT NULL,
    multiCuadriple SMALLINT UNSIGNED NOT NULL,
    disDoble SMALLINT UNSIGNED NOT NULL,
    disTriple SMALLINT UNSIGNED NOT NULL,
    rebote SMALLINT UNSIGNED NOT NULL,
    autoDir SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (idToken),
    CONSTRAINT `fk_personaje_Newtokens` FOREIGN KEY (idPersonaje) REFERENCES personajes(idPersonaje) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Table structure for table 'Items'
--

CREATE TABLE items(
    idItem SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombrePocion VARCHAR(20) NOT NULL,
    valor BOOLEAN NOT NULL,
    idPersonaje SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (idItem),
    CONSTRAINT `fk_personaje_items` FOREIGN KEY (idItem) REFERENCES personajes(idPersonaje) ON DELETE CASCADE ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- New table structure for table 'Items'
--

CREATE TABLE newItems(
	idItem SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    idPersonaje SMALLINT UNSIGNED NOT NULL,
    velocidad SMALLINT UNSIGNED NOT NULL,
    energia SMALLINT UNSIGNED NOT NULL,
    vida SMALLINT UNSIGNED NOT NULL,
    superVida SMALLINT UNSIGNED NOT NULL,
    superEnergia SMALLINT UNSIGNED NOT NULL,
    inmunidad SMALLINT UNSIGNED NOT NULL,
    mystery SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (idItem),
    CONSTRAINT `fk_personaje_Newitems` FOREIGN KEY (idItem) REFERENCES personajes(idPersonaje) ON DELETE CASCADE ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;