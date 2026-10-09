-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.4.3 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.5.0.6677
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para db_crea
CREATE DATABASE IF NOT EXISTS `db_crea` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `db_crea`;

-- Volcando estructura para tabla db_crea.alumno-responsable
CREATE TABLE IF NOT EXISTS `alumno-responsable` (
  `IdAlumnoRespomsable` int NOT NULL AUTO_INCREMENT,
  `id_alumno` int DEFAULT '0',
  `id_responsable` int DEFAULT '0',
  `patentesco` varchar(20) DEFAULT NULL,
  `esContactoPrincipal` tinyint DEFAULT NULL,
  PRIMARY KEY (`IdAlumnoRespomsable`),
  KEY `FK_alumno-responsable_alumnos` (`id_alumno`),
  KEY `FK_alumno-responsable_responsable` (`id_responsable`),
  CONSTRAINT `FK_alumno-responsable_alumnos` FOREIGN KEY (`id_alumno`) REFERENCES `alumnos` (`IdAlumno`),
  CONSTRAINT `FK_alumno-responsable_responsable` FOREIGN KEY (`id_responsable`) REFERENCES `responsable` (`IdResponsable`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.alumnos
CREATE TABLE IF NOT EXISTS `alumnos` (
  `IdAlumno` int NOT NULL AUTO_INCREMENT,
  `id_persona` int NOT NULL DEFAULT '0',
  `fecha_ingreso` date DEFAULT NULL,
  `fecha_egreso` date DEFAULT NULL,
  `activo` tinyint NOT NULL DEFAULT (0),
  `observacion` text NOT NULL,
  PRIMARY KEY (`IdAlumno`),
  KEY `FK_alumnos_personas` (`id_persona`),
  CONSTRAINT `FK_alumnos_personas` FOREIGN KEY (`id_persona`) REFERENCES `personas` (`IdPersona`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.aranceles
CREATE TABLE IF NOT EXISTS `aranceles` (
  `IdArancel` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `descripcion` text,
  `monto` decimal(10,2) DEFAULT NULL,
  `fecha_vigencia_desde` date DEFAULT NULL,
  `fecha_vigencia_hasta` date DEFAULT NULL,
  `activo` tinyint DEFAULT NULL,
  PRIMARY KEY (`IdArancel`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.asistencia
CREATE TABLE IF NOT EXISTS `asistencia` (
  `IdAsistencia` int NOT NULL AUTO_INCREMENT,
  `id_clase` int DEFAULT '0',
  `id_alumno` int DEFAULT '0',
  `estado` tinyint DEFAULT NULL,
  `observacion` text,
  PRIMARY KEY (`IdAsistencia`),
  KEY `FK_asistencia_clases` (`id_clase`),
  KEY `FK_asistencia_alumnos` (`id_alumno`),
  CONSTRAINT `FK_asistencia_alumnos` FOREIGN KEY (`id_alumno`) REFERENCES `alumnos` (`IdAlumno`),
  CONSTRAINT `FK_asistencia_clases` FOREIGN KEY (`id_clase`) REFERENCES `clases` (`IdClase`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.aulas
CREATE TABLE IF NOT EXISTS `aulas` (
  `IdAula` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL DEFAULT '0',
  `capacidad` int NOT NULL DEFAULT (0),
  `descripcion` varchar(255) NOT NULL DEFAULT '0',
  `activo` tinyint NOT NULL DEFAULT (0),
  PRIMARY KEY (`IdAula`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.cargos
CREATE TABLE IF NOT EXISTS `cargos` (
  `IdCargo` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `descripcion` text,
  PRIMARY KEY (`IdCargo`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.clase-alumno
CREATE TABLE IF NOT EXISTS `clase-alumno` (
  `IdClase` int NOT NULL,
  `IdAlumno` int NOT NULL,
  PRIMARY KEY (`IdClase`,`IdAlumno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.clases
CREATE TABLE IF NOT EXISTS `clases` (
  `IdClase` int NOT NULL AUTO_INCREMENT,
  `id_docente` int DEFAULT NULL,
  `id_materia` int DEFAULT NULL,
  `id_aula` int DEFAULT NULL,
  `tipo_clase` varchar(50) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `hora_inicio` time DEFAULT NULL,
  `hora_fin` time DEFAULT NULL,
  `estado` tinyint DEFAULT NULL,
  `observacion` text,
  PRIMARY KEY (`IdClase`),
  KEY `FK_clases_docentes` (`id_docente`),
  KEY `FK_clases_materias` (`id_materia`),
  KEY `FK_clases_aulas` (`id_aula`),
  CONSTRAINT `FK_clases_aulas` FOREIGN KEY (`id_aula`) REFERENCES `aulas` (`IdAula`),
  CONSTRAINT `FK_clases_docentes` FOREIGN KEY (`id_docente`) REFERENCES `docentes` (`IdDocente`),
  CONSTRAINT `FK_clases_materias` FOREIGN KEY (`id_materia`) REFERENCES `materias` (`IdMateria`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.cuotas
CREATE TABLE IF NOT EXISTS `cuotas` (
  `IdCuotas` int NOT NULL AUTO_INCREMENT,
  `id_arancel` int DEFAULT '0',
  `id_inscripcion` int DEFAULT '0',
  `periodo` varchar(50) DEFAULT NULL,
  `monto` decimal(10,2) DEFAULT NULL,
  `fecha_vencimiento` date DEFAULT NULL,
  `estado` tinyint DEFAULT NULL,
  PRIMARY KEY (`IdCuotas`),
  KEY `FK_cuotas_aranceles` (`id_arancel`),
  KEY `FK_cuotas_inscripciones` (`id_inscripcion`),
  CONSTRAINT `FK_cuotas_aranceles` FOREIGN KEY (`id_arancel`) REFERENCES `aranceles` (`IdArancel`),
  CONSTRAINT `FK_cuotas_inscripciones` FOREIGN KEY (`id_inscripcion`) REFERENCES `inscripciones` (`IdInscripcion`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.cursos
CREATE TABLE IF NOT EXISTS `cursos` (
  `IdCurso` int NOT NULL AUTO_INCREMENT,
  `id_nivel` int DEFAULT '0',
  `nombre` varchar(50) DEFAULT NULL,
  `orden` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`IdCurso`),
  KEY `FK_cursos_nivel-educativo` (`id_nivel`),
  CONSTRAINT `FK_cursos_nivel-educativo` FOREIGN KEY (`id_nivel`) REFERENCES `nivel-educativo` (`IdNiverEducativo`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.disponibilidad-docente
CREATE TABLE IF NOT EXISTS `disponibilidad-docente` (
  `IdDisponibilidad` int NOT NULL AUTO_INCREMENT,
  `id_docente` int DEFAULT NULL,
  `dia_semana` varchar(20) DEFAULT NULL,
  `hora_inicio` time DEFAULT NULL,
  `hora_fin` time DEFAULT NULL,
  `turno` varchar(50) DEFAULT NULL,
  `activo` tinyint DEFAULT NULL,
  PRIMARY KEY (`IdDisponibilidad`),
  KEY `FK_disponibilidad-docente_docentes` (`id_docente`),
  CONSTRAINT `FK_disponibilidad-docente_docentes` FOREIGN KEY (`id_docente`) REFERENCES `docentes` (`IdDocente`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.docente-materia
CREATE TABLE IF NOT EXISTS `docente-materia` (
  `Iddocente` int NOT NULL,
  `IdMateria` int NOT NULL,
  PRIMARY KEY (`Iddocente`,`IdMateria`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.docentes
CREATE TABLE IF NOT EXISTS `docentes` (
  `IdDocente` int NOT NULL AUTO_INCREMENT,
  `id_persona` int DEFAULT NULL,
  `especialidad` varchar(100) DEFAULT NULL,
  `fecha_alta` date DEFAULT NULL,
  `activo` tinyint DEFAULT NULL,
  PRIMARY KEY (`IdDocente`),
  KEY `FK_docentes_personas` (`id_persona`),
  CONSTRAINT `FK_docentes_personas` FOREIGN KEY (`id_persona`) REFERENCES `personas` (`IdPersona`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.inscripcion-materia
CREATE TABLE IF NOT EXISTS `inscripcion-materia` (
  `IdInscripcionMateria` int NOT NULL AUTO_INCREMENT,
  `id_inscripcion` int DEFAULT NULL,
  `id_materia` int DEFAULT NULL,
  `fecha_inicio` date DEFAULT NULL,
  `fecha_fin` date DEFAULT NULL,
  `estado` tinyint DEFAULT NULL,
  PRIMARY KEY (`IdInscripcionMateria`),
  KEY `FK_inscripcion-materia_inscripciones` (`id_inscripcion`),
  KEY `FK_inscripcion-materia_materias` (`id_materia`),
  CONSTRAINT `FK_inscripcion-materia_inscripciones` FOREIGN KEY (`id_inscripcion`) REFERENCES `inscripciones` (`IdInscripcion`),
  CONSTRAINT `FK_inscripcion-materia_materias` FOREIGN KEY (`id_materia`) REFERENCES `materias` (`IdMateria`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.inscripciones
CREATE TABLE IF NOT EXISTS `inscripciones` (
  `IdInscripcion` int NOT NULL AUTO_INCREMENT,
  `id_alumno` int DEFAULT '0',
  `fecha_inicio` date DEFAULT NULL,
  `fecha_fin` date DEFAULT NULL,
  `tipo_inscripcion` varchar(50) DEFAULT NULL,
  `estado` tinyint DEFAULT NULL,
  `observacion` text,
  PRIMARY KEY (`IdInscripcion`),
  KEY `FK_inscripciones_alumnos` (`id_alumno`),
  CONSTRAINT `FK_inscripciones_alumnos` FOREIGN KEY (`id_alumno`) REFERENCES `alumnos` (`IdAlumno`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.institucion-educativa
CREATE TABLE IF NOT EXISTS `institucion-educativa` (
  `IdInstitucion` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `direccion` varchar(100) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `activo` tinyint DEFAULT NULL,
  PRIMARY KEY (`IdInstitucion`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.materias
CREATE TABLE IF NOT EXISTS `materias` (
  `IdMateria` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `descripcion` text,
  `activo` tinyint DEFAULT NULL,
  PRIMARY KEY (`IdMateria`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.nivel-educativo
CREATE TABLE IF NOT EXISTS `nivel-educativo` (
  `IdNiverEducativo` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `descripcion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`IdNiverEducativo`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.pagos
CREATE TABLE IF NOT EXISTS `pagos` (
  `IdPago` int NOT NULL AUTO_INCREMENT,
  `id_cuota` int DEFAULT '0',
  `id_personal` int DEFAULT '0',
  `fecha_pago` date DEFAULT NULL,
  `monto` decimal(10,2) DEFAULT NULL,
  `medio_pago` varchar(50) DEFAULT NULL,
  `observacion` text,
  PRIMARY KEY (`IdPago`),
  KEY `FK_pagos_cuotas` (`id_cuota`),
  KEY `FK_pagos_personal` (`id_personal`),
  CONSTRAINT `FK_pagos_cuotas` FOREIGN KEY (`id_cuota`) REFERENCES `cuotas` (`IdCuotas`),
  CONSTRAINT `FK_pagos_personal` FOREIGN KEY (`id_personal`) REFERENCES `personal` (`IdPersonal`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.personal
CREATE TABLE IF NOT EXISTS `personal` (
  `IdPersonal` int NOT NULL AUTO_INCREMENT,
  `id_persona` int NOT NULL DEFAULT '0',
  `id_cargo` int NOT NULL DEFAULT '0',
  `fecha_ingreso` date DEFAULT NULL,
  `activo` tinyint NOT NULL DEFAULT (0),
  PRIMARY KEY (`IdPersonal`),
  KEY `FK_personal_personas` (`id_persona`),
  KEY `FK_personal_cargos` (`id_cargo`),
  CONSTRAINT `FK_personal_cargos` FOREIGN KEY (`id_cargo`) REFERENCES `cargos` (`IdCargo`),
  CONSTRAINT `FK_personal_personas` FOREIGN KEY (`id_persona`) REFERENCES `personas` (`IdPersona`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.personas
CREATE TABLE IF NOT EXISTS `personas` (
  `IdPersona` int NOT NULL AUTO_INCREMENT,
  `dni` varchar(10) DEFAULT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `apellido` varchar(50) DEFAULT NULL,
  `fechaNacimiento` date DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `direccion` varchar(100) DEFAULT NULL,
  `activo` tinyint DEFAULT NULL,
  `fechaAlta` date DEFAULT NULL,
  PRIMARY KEY (`IdPersona`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.responsable
CREATE TABLE IF NOT EXISTS `responsable` (
  `IdResponsable` int NOT NULL AUTO_INCREMENT,
  `id_persona` int DEFAULT '0',
  PRIMARY KEY (`IdResponsable`),
  KEY `FK__personas` (`id_persona`),
  CONSTRAINT `FK__personas` FOREIGN KEY (`id_persona`) REFERENCES `personas` (`IdPersona`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.roles
CREATE TABLE IF NOT EXISTS `roles` (
  `IdRol` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL DEFAULT '0',
  `descripcion` varchar(255) NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdRol`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.seguimiento-pedagogico
CREATE TABLE IF NOT EXISTS `seguimiento-pedagogico` (
  `IdSeguimiento` int NOT NULL AUTO_INCREMENT,
  `id_materia` int DEFAULT NULL,
  `id_alumno` int DEFAULT NULL,
  `id_docente` int DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `tema_trabajado` text,
  `avance` text,
  `dificultades` text,
  `recomendacion` text,
  `observacion` text,
  PRIMARY KEY (`IdSeguimiento`),
  KEY `FK_seguimiento-pedagogico_docentes` (`id_docente`),
  KEY `FK_seguimiento-pedagogico_alumnos` (`id_alumno`),
  KEY `FK_seguimiento-pedagogico_materias` (`id_materia`),
  CONSTRAINT `FK_seguimiento-pedagogico_alumnos` FOREIGN KEY (`id_alumno`) REFERENCES `alumnos` (`IdAlumno`),
  CONSTRAINT `FK_seguimiento-pedagogico_docentes` FOREIGN KEY (`id_docente`) REFERENCES `docentes` (`IdDocente`),
  CONSTRAINT `FK_seguimiento-pedagogico_materias` FOREIGN KEY (`id_materia`) REFERENCES `materias` (`IdMateria`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para procedimiento db_crea.sp_alumno_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_alumno_actualizar`()
BEGIN
UPDATE alumnos
SET fecha_ingreso = p_fecha_ingreso,
    fecha_egreso = p_fecha_egreso,
    activo = p_activo,
    Observacion = p_observacion
WHERE IdAlumno = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_alumno_asignar_responsable
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_alumno_asignar_responsable`()
BEGIN
INSERT INTO `alumno-responsable`
   (id_alumno, id_responsable, parentesco, esContactoPrincipal)
VALUES
   (p_id_alumno, p_id_responsable, p_parentesco, p_esContactoPrincipal);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_alumno_consultar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_alumno_consultar`()
BEGIN
SELECT * 
FROM alumnos
WHERE p_id_alumno IS NULL 
   OR IdAlumno = p_id_alumno;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_alumno_desasignar_responsable
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_alumno_desasignar_responsable`()
BEGIN
DELETE FROM `alumno-responsable`
WHERE IdAlumnoResponsable = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_alumno_insertar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_alumno_insertar`()
BEGIN
INSERT INTO Alumnos
    (id_persona, fecha_ingreso, fecha_egreso, activo, Observacion)
VALUES
    (p_id_persona, p_fecha_ingreso, p_fecha_egreso,
     p_activo, p_observacion);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_alumno_responsables
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_alumno_responsables`()
BEGIN
SELECT r.*, p.nombre, p.apellido, ar.parentesco,
           ar.esContactoPrincipal
FROM `alumno-responsable` ar
   INNER JOIN Responsables r
      ON ar.id_responsable = r.IdResponsable
   INNER JOIN personas p
      ON r.id_persona = p.IdPersona
WHERE ar.id_alumno = p_id_alumno;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_arancel_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_arancel_actualizar`()
BEGIN
UPDATE aranceles
SET nombre = p_nombre,
    descripcion = p_descripcion,
    monto = p_monto,
    fecha_vigencia_hasta = p_fecha_hasta,
    activo = p_activo
WHERE IdArancel = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_arancel_insertar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_arancel_insertar`()
BEGIN
INSERT INTO aranceles
   (nombre, descripcion, monto, fecha_vigencia_desde,
   fecha_vigencia_hasta, activo)
VALUES
   (p_nombre, p_descripcion, p_monto, p_fecha_desde,
   p_fecha_hasta, p_activo);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_arancel_listado
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_arancel_listado`()
BEGIN
SELECT *
FROM aranceles
WHERE p_id IS NULL OR IdArancel = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_asistencias_alumno
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_asistencias_alumno`()
BEGIN
SELECT *
FROM asistencia
WHERE id_alumno = p_id_alumno;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_asistencia_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_asistencia_actualizar`()
BEGIN
UPDATE asistencia
SET estado = p_estado,
    observacion = p_observacion
WHERE IdAsistencia = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_asistencia_registrar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_asistencia_registrar`()
BEGIN
INSERT INTO asistencia
    (id_clase, id_alumno, estado, observacion)
VALUES
    (p_id_clase, p_id_alumno, p_estado, p_observacion);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_aula_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_aula_actualizar`()
BEGIN
UPDATE aulas
SET nombre = p_nombre,
    capacidad = p_capacidad,
    descripcion = p_descripcion,
   activo = p_activo
WHERE IdAula = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_aula_consultar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_aula_consultar`()
BEGIN
SELECT *
FROM aulas
WHERE p_id IS NULL OR IdAula = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_aula_insertar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_aula_insertar`()
BEGIN
INSERT INTO aulas
   (nombre, capacidad, descripcion, activo)
VALUES
   (p_nombre, p_capacidad, p_descripcion, p_activo);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_cargo_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_cargo_actualizar`()
BEGIN
UPDATE cargos
SET nombre = p_nombre,
    descripcion = p_descripcion
WHERE IdCargo = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_cargo_insertar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_cargo_insertar`()
BEGIN
INSERT INTO cargos(nombre, descripcion)
VALUES (p_nombre, p_descripcion);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_cargo_listado
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_cargo_listado`()
BEGIN
SELECT *
FROM cargos
WHERE p_id IS NULL OR IdCargo = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_clase_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_clase_actualizar`()
BEGIN
UPDATE clases
SET id_docente = p_id_docente,
   id_materia = p_id_materia,
   id_aula = p_id_aula,
   fecha = p_fecha,
   hora_inicio = p_hora_inicio,
   hora_fin = p_hora_fin,
   estado = p_estado,
   observacion = p_observacion
WHERE IdClase = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_clase_alumnos
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_clase_alumnos`()
BEGIN
SELECT a.*, p.nombre, p.apellido
FROM `Clase-Alumno` ca
  INNER JOIN Alumnos a ON ca.idAlumno = a.IdAlumno
  INNER JOIN Personas p ON a.id_persona = p.IdPersona
WHERE ca.IdClase = p_id_clase;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_clase_asignar_alumno
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_clase_asignar_alumno`()
BEGIN
INSERT INTO `clase-alumno`
   (IdClase, idAlumno)
VALUES (p_id_clase, p_id_alumno);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_clase_consultar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_clase_consultar`()
BEGIN
SELECT *
FROM clases
WHERE p_id IS NULL OR IdClase = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_clase_crear
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_clase_crear`()
BEGIN
INSERT INTO clases
   (id_docente, id_materia, id_aula, tipo_clase, fecha,
   hora_inicio, hora_fin, estado, observacion)
VALUES
   (p_id_docente, p_id_materia, p_id_aula, p_tipo_clase, p_fecha,
   p_hora_inicio, p_hora_fin, p_estado, p_observacion);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_clase_quitar_alumno
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_clase_quitar_alumno`()
BEGIN
DELETE FROM `clase-alumno`
WHERE IdClase = p_id_clase
AND idAlumno = p_id_alumno;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_cuotas_incripcion
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_cuotas_incripcion`()
BEGIN
SELECT *
FROM cuotas
WHERE id_inscripcion = p_id_inscripcion;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_cuota_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_cuota_actualizar`()
BEGIN
UPDATE cuotas
SET monto = p_monto,
    fecha_vencimiento = p_fecha_vencimiento,
    estado = p_estado
WHERE IdCuota = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_cuota_generar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_cuota_generar`()
BEGIN
INSERT INTO cuotas
   (id_arancel, id_inscripcion, periodo, monto,
   fecha_vencimiento, estado)
VALUES
   (p_id_arancel, p_id_inscripcion, p_periodo, p_monto,
   p_fecha_vencimiento, p_estado);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_curso_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_curso_actualizar`()
BEGIN
UPDATE cursos
SET id_nivel = p_id_nivel,
     nombre = p_nombre,
     orden = p_orden
WHERE IdCurso = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_curso_consultar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_curso_consultar`()
BEGIN
SELECT c.*, n.nombre AS nivel
FROM cursos c
INNER JOIN `Nivel-Educativo` n
    ON c.id_nivel = n.IdNivelEducativo
WHERE p_id IS NULL OR c.IdCurso = p_id;

END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_curso_insertar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_curso_insertar`()
BEGIN
INSERT INTO cursos(id_nivel, nombre, orden)
VALUES (p_id_nivel, p_nombre, p_orden);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_disponibilidad_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_disponibilidad_actualizar`()
BEGIN
UPDATE `disponibilidad-docente`
SET dia_semana = p_dia_semana,
      hora_inicio = p_hora_inicio,
      hora_fin = p_hora_fin,
      turno = p_turno,
      activo = p_activo
WHERE IdDisponibilidad = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_disponibilidad_docente
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_disponibilidad_docente`()
BEGIN
SELECT *
FROM `disponibilidad-docente`
WHERE id_docente = p_id_docente;

END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_disponibilidad_registrar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_disponibilidad_registrar`()
BEGIN
INSERT INTO `disponibilidad-docente`
    (id_docente, dia_semana, hora_inicio, hora_fin, turno, activo)
VALUES
    (p_id_docente, p_dia_semana, p_hora_inicio, p_hora_fin,
     p_turno, p_activo);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_docente_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_docente_actualizar`()
BEGIN
  UPDATE docente
  SET especialidad = p_especialidad,
      activo = p_activo
  WHERE IdDocente = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_docente_asignar_materia
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_docente_asignar_materia`()
BEGIN
INSERT INTO `docente-materia`
   (IdDocente, IdMateria)
VALUES (p_id_docente, p_id_materia);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_docente_consultar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_docente_consultar`()
BEGIN
   SELECT d.*, p.nombre, p.apellido, p.dni
   FROM Docentes d
      INNER JOIN Personas p ON d.id_persona = p.IdPersona
   WHERE p_id IS NULL OR d.IdDocente = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_docente_desasignar_materia
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_docente_desasignar_materia`()
BEGIN
DELETE FROM `docente-materia`
WHERE IdDocente = p_id_docente
AND IdMateria = p_id_materia;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_docente_insertar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_docente_insertar`()
BEGIN
   INSERT INTO docentes (id_persona, especialida, fecha_alta, activo)
   VALUES  
    (p_id_persona, p_especialidad, p_fecha_alta, p_activo);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_docente_materias
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_docente_materias`()
BEGIN
SELECT m.*
FROM `docente-materia` dm
INNER JOIN Materias m ON dm.IdMateria = m.IdMateria
WHERE dm.IdDocente = p_id_docente;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_inscripciones_alumno
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_inscripciones_alumno`()
BEGIN
SELECT *
FROM inscripciones
WHERE id_alumno = p_id_alumno;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_inscripcion_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_inscripcion_actualizar`()
BEGIN
UPDATE inscripciones
SET fecha_fin = p_fecha_fin,
    tipo_inscripcion = p_tipo_inscripcion,
    estado = p_estado,
    observacion = p_observacion
WHERE IdInscripcion = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_inscripcion_agregar_materia
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_inscripcion_agregar_materia`()
BEGIN
INSERT INTO `inscripcion-materia`
    (id_inscripcion, id_materia, fecha_inicio, estado)
VALUES
    (p_id_inscripcion, p_id_materia, p_fecha_inicio, p_estado);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_inscripcion_consultar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_inscripcion_consultar`()
BEGIN
SELECT *
FROM inscripciones
WHERE p_id IS NULL OR IdInscripcion = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_inscripcion_crear
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_inscripcion_crear`()
BEGIN
INSERT INTO inscripciones
   (id_alumno, fecha_inicio, fecha_fin, tipo_inscripcion,
   estado, observacion)
VALUES
   (p_id_alumno, p_fecha_inicio, p_fecha_fin,
   p_tipo_inscripcion, p_estado, p_observacion);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_inscripcion_materias
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_inscripcion_materias`()
BEGIN
SELECT m.*
FROM `inscripcion-materia` im
   INNER JOIN Materias m ON im.id_materia = m.IdMateria
WHERE im.id_inscripcion = p_id_inscripcion;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_inscripcion_quitar_materia
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_inscripcion_quitar_materia`()
BEGIN
DELETE FROM `inscripcion-materia`
WHERE IdInscripcionMateria = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_institucion_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_institucion_actualizar`()
BEGIN
  UPDATE `institución-educativa`
  SET nombre = p_nombre,
      direccion = p_direccion,
      telefono = p_telefono,
      email = p_email,
      activo = p_activo
  WHERE IdInstitucion = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_institucion_consultar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_institucion_consultar`()
BEGIN
 SELECT *
 FROM `institucion-educativa`
 WHERE p_id IS NULL OR IdInstitucion = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_institucion_insertar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_institucion_insertar`()
BEGIN
INSERT INTO `institución-educativa`
    (nombre, direccion, telefono, email, activo)
VALUES
    (p_nombre, p_direccion, p_telefono, p_email, p_activo);

END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_materia_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_materia_actualizar`()
BEGIN
UPDATE materias
SET nombre = p_nombre,
    descripcion = p_descripcion,
    activo = p_activo
WHERE IdMateria = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_materia_consultar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_materia_consultar`()
BEGIN
SELECT *
FROM materias
WHERE p_id IS NULL OR IdMateria = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_materia_insertar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_materia_insertar`()
BEGIN
INSERT INTO materias(nombre, descripcion, activo)
VALUES (p_nombre, p_descripcion, p_activo);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_nivel_educativo_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_nivel_educativo_actualizar`()
BEGIN
UPDATE `nivel-educativo`
SET nombre = p_nombre,
        descripcion = p_descripcion
WHERE IdNivelEducativo = p_id;

END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_nivel_educativo_consultar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_nivel_educativo_consultar`()
BEGIN
SELECT *
FROM `nivel-educativo`
WHERE p_id IS NULL OR IdNivelEducativo = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_nivel_educativo_insertar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_nivel_educativo_insertar`()
BEGIN
INSERT INTO `nivel-educativo`
    (nombre, descripcion)
VALUES 
    (p_nombre, p_descripcion);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_pagos_cuota
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_pagos_cuota`()
BEGIN
SELECT *
FROM pagos
WHERE id_cuota = p_id_cuota;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_pago_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_pago_actualizar`()
BEGIN
UPDATE pagos
SET monto = p_monto,
    medio_pago = p_medio_pago,
    observacion = p_observacion
WHERE IdPago = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_pago_registar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_pago_registar`()
BEGIN
INSERT INTO pagos
   (id_cuota, id_personal, fecha_pago, monto,
   medio_pago, observacion)
VALUES
   (p_id_cuota, p_id_personal, p_fecha_pago,
   p_monto, p_medio_pago, p_observacion);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_personal_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_personal_actualizar`()
BEGIN
UPDATE personal 
SET  
   id_cargo = p_id_cargo,
   activo = p_activo
WHERE IdPersonal = p_id; 

END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_personal_consultar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_personal_consultar`()
BEGIN
   SELECT p.*, pe.nombre, pe.apellido, c.nombre AS cargo
   FROM Personal p
    INNER JOIN Personas pe ON p.id_persona = pe.IdPersona
    INNER JOIN Cargos c ON p.id_cargo = c.IdCargo
   WHERE p_id IS NULL OR p.IdPersonal = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_personal_insertar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_personal_insertar`()
BEGIN
INSERT INTO personal(id_persona, id_cargo, fecha_ingreso, activo)
VALUES (p_id_persona, p_id_cargo, p_fecha_ingreso, p_actvio); 
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_persona_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_persona_actualizar`()
BEGIN
UPDATE personas
SET dni = p_dni,
    nombre = p_nombre,
    apellido = p_apellido,
    fechaNacimiento = p_fechaNacimiento,
    telefono = p_telefono,
    email = p_email,
    direccion = p_direccion
WHERE IdPersona = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_persona_buscar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_persona_buscar`()
BEGIN
SELECT * 
FROM personas 
WHERE dni LIKE CONCAT (p_busqueda) 
   OR nombre LIKE CONCAT (p_busqueda)
   OR apellido LIKE CONCAT (p_busqueda);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_persona_insertar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_persona_insertar`()
BEGIN
insert into personas
     (dni, nombre, apellido, fechaNacimiento, teléfono, email, dirección, activo, fechaAlta)
VALUES 
     (p_nombre, p_apellido, p_fechaNacimienteo, p_telefono, p_email, p_direccion, p_activo, p_fechaAlta);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_persona_obtener
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_persona_obtener`()
BEGIN
SELECT * FROM personas WHERE IdPersona = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_responsable_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_responsable_actualizar`()
BEGIN
   UPDATE responsable
   SET id_persona = p_id_persona
   WHERE IdResponsable = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_responsable_consultar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_responsable_consultar`()
BEGIN
SELECT r.*, p.nombre, p.apellido, p.dni
FROM Responsables r
   INNER JOIN Personas p ON r.id_persona = p.IdPersona
WHERE r.IdResponsable = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_responsable_insertar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_responsable_insertar`()
BEGIN
INSERT INTO responsable (id_persona)
VALUE (p_id_persona);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_rol_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_rol_actualizar`()
BEGIN
 UPDATE roles
 SET nombre = p_nombre,
    descripción = p_descripcion
 WHERE IdRol = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_rol_consultar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_rol_consultar`()
BEGIN
  SELECT *  
  FROM roles
  WHERE p_id IS NULL OR IdRol = p_id; 
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_rol_insertar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_rol_insertar`()
BEGIN
INSERT INTO roles (nombre, descripción)
VALUES (p_nombre, p_descripcion);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_seguimientop_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_seguimientop_actualizar`()
BEGIN
UPDATE `seguimiento-pedagógico`
SET tema_trabajado = p_tema_trabajado,
    avance = p_avance,
    dificultades = p_dificultades,
    recomendacion = p_recomendacion,
    observacion = p_observacion
WHERE IdSeguimiento = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_seguimientop_alumno
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_seguimientop_alumno`()
BEGIN
SELECT *
FROM `seguimiento-pedagógico`
WHERE id_alumno = p_id_alumno
  ORDER BY fecha DESC;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_seguimientop_registrar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_seguimientop_registrar`()
BEGIN
INSERT INTO `seguimiento-pedagógico`
   (id_materia, id_alumno, id_docente, fecha,
   tema_trabajado, avance, dificultades, recomendacion, observacion)
VALUES
   (p_id_materia, p_id_alumno, p_id_docente, p_fecha,
   p_tema_trabajado, p_avance, p_dificultades,
   p_recomendacion, p_observacion);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_trayectoria_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_trayectoria_actualizar`()
BEGIN
UPDATE `trayectoria-educativa`
SET id_curso = p_id_curso,
    division = p_division,
    ciclo_lectivo = p_ciclo_lectivo,
    fecha_desde = p_fecha_desde,
    fecha_hasta = p_fecha_hasta,
    observaciones = p_observaciones
WHERE IdTrayectoriaEdu = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_trayectoria_alumno
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_trayectoria_alumno`()
BEGIN
SELECT *
FROM `trayectoria-educativa`
WHERE id_alumno = p_id_alumno
ORDER BY fecha_desde;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_trayectoria_registrar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_trayectoria_registrar`()
BEGIN
INSERT INTO `trayectoria-educativa`
    (id_alumno, id_institucion, id_curso, division,
     ciclo_lectivo, fecha_desde, fecha_hasta, observaciones)
VALUES
    (p_id_alumno, p_id_institucion, p_id_curso, p_division,
     p_ciclo_lectivo, p_fecha_desde, p_fecha_hasta, p_observaciones);

END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_usuario_actualizar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_usuario_actualizar`()
BEGIN
UPDATE usuarios
SET usuario = p_usuario,
    password_hash = p_password_hash,
    activo = p_activo
WHERE IdUsuario = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_usuario_asignar_rol
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_usuario_asignar_rol`()
BEGIN
INSERT INTO `usuario-rol`
    (IdUsuario, IdRol)
VALUES (p_id_usuario, p_id_rol);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_usuario_consultar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_usuario_consultar`()
BEGIN
SELECT *
FROM usuarios
WHERE p_id IS NULL OR IdUsuario = p_id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_usuario_crear
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_usuario_crear`()
BEGIN
INSERT INTO usuarios
   (id_persona, usuario, password_hash, activo)
VALUES
   (p_id_persona, p_usuario, p_password_hash, p_activo);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_usuario_login
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_usuario_login`()
BEGIN
SELECT *
FROM usuarios
WHERE usuario = p_usuario
   AND activo = TRUE;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_usuario_quitar_rol
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_usuario_quitar_rol`()
BEGIN
DELETE FROM `usuario-rol`
WHERE IdUsuario = p_id_usuario
   AND IdRol = p_id_rol;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_crea.sp_usuario_roles
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_usuario_roles`()
BEGIN
SELECT r.*
FROM `usuario-rol` ur
   INNER JOIN Roles r ON ur.IdRol = r.IdRol
WHERE ur.IdUsuario = p_id_usuario;
END//
DELIMITER ;

-- Volcando estructura para tabla db_crea.trayectoria-educativa
CREATE TABLE IF NOT EXISTS `trayectoria-educativa` (
  `IdTrayctoriaEdu` int NOT NULL AUTO_INCREMENT,
  `id_alumno` int DEFAULT '0',
  `id_institucion` int DEFAULT '0',
  `id_cuso` int DEFAULT '0',
  `division` varchar(20) DEFAULT NULL,
  `ciclo_luctivo` varchar(4) DEFAULT NULL,
  `fecha_desde` date DEFAULT NULL,
  `fecha_hasta` date DEFAULT NULL,
  `observaciones` text,
  PRIMARY KEY (`IdTrayctoriaEdu`),
  KEY `FK_trayectoria-educativa_alumnos` (`id_alumno`),
  KEY `FK_trayectoria-educativa_institucion-educativa` (`id_institucion`),
  KEY `FK_trayectoria-educativa_cursos` (`id_cuso`),
  CONSTRAINT `FK_trayectoria-educativa_alumnos` FOREIGN KEY (`id_alumno`) REFERENCES `alumnos` (`IdAlumno`),
  CONSTRAINT `FK_trayectoria-educativa_cursos` FOREIGN KEY (`id_cuso`) REFERENCES `cursos` (`IdCurso`),
  CONSTRAINT `FK_trayectoria-educativa_institucion-educativa` FOREIGN KEY (`id_institucion`) REFERENCES `institucion-educativa` (`IdInstitucion`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.usuario-rol
CREATE TABLE IF NOT EXISTS `usuario-rol` (
  `IdRol` int NOT NULL,
  `IdUsuario` int NOT NULL,
  PRIMARY KEY (`IdRol`,`IdUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `IdUsuario` int NOT NULL AUTO_INCREMENT,
  `id_persona` int NOT NULL DEFAULT '0',
  `usuario` varchar(50) NOT NULL DEFAULT '0',
  `password_hash` varchar(255) NOT NULL DEFAULT '0',
  `activo` tinyint NOT NULL DEFAULT (0),
  `fecha_creacion` datetime DEFAULT NULL,
  `ultimo_acceso` datetime DEFAULT NULL,
  PRIMARY KEY (`IdUsuario`),
  KEY `FK_usuarios_personas` (`id_persona`),
  CONSTRAINT `FK_usuarios_personas` FOREIGN KEY (`id_persona`) REFERENCES `personas` (`IdPersona`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
