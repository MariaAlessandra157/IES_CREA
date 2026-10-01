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
IF NOT EXISTS ;

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
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=InnoDB AUTO_INCREMENT=101 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.aulas
CREATE TABLE IF NOT EXISTS `aulas` (
  `IdAula` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL DEFAULT '0',
  `capacidad` int NOT NULL DEFAULT (0),
  `descripcion` varchar(255) NOT NULL DEFAULT '0',
  `activo` tinyint NOT NULL DEFAULT (0),
  PRIMARY KEY (`IdAula`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.cargos
CREATE TABLE IF NOT EXISTS `cargos` (
  `IdCargo` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `descripcion` text,
  PRIMARY KEY (`IdCargo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.cursos
CREATE TABLE IF NOT EXISTS `cursos` (
  `IdCurso` int NOT NULL AUTO_INCREMENT,
  `id_nivel` int DEFAULT '0',
  `nombre` varchar(50) DEFAULT NULL,
  `orden` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`IdCurso`),
  KEY `FK_cursos_nivel-educativo` (`id_nivel`),
  CONSTRAINT `FK_cursos_nivel-educativo` FOREIGN KEY (`id_nivel`) REFERENCES `nivel-educativo` (`IdNivelEducativo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.materias
CREATE TABLE IF NOT EXISTS `materias` (
  `IdMateria` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `descripcion` text,
  `activo` tinyint DEFAULT NULL,
  PRIMARY KEY (`IdMateria`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.nivel-educativo
CREATE TABLE IF NOT EXISTS `nivel-educativo` (
  `IdNivelEducativo` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `descripcion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`IdNivelEducativo`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=InnoDB AUTO_INCREMENT=141 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.responsable
CREATE TABLE IF NOT EXISTS `responsable` (
  `IdResponsable` int NOT NULL AUTO_INCREMENT,
  `id_persona` int DEFAULT '0',
  PRIMARY KEY (`IdResponsable`),
  KEY `FK__personas` (`id_persona`),
  CONSTRAINT `FK__personas` FOREIGN KEY (`id_persona`) REFERENCES `personas` (`IdPersona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.roles
CREATE TABLE IF NOT EXISTS `roles` (
  `IdRol` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL DEFAULT '0',
  `descripcion` varchar(255) NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdRol`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla db_crea.trayectoria-educativa
CREATE TABLE IF NOT EXISTS `trayectoria-educativa` (
  `IdTrayctoriaEducativa` int NOT NULL AUTO_INCREMENT,
  `id_alumno` int DEFAULT '0',
  `id_institucion` int DEFAULT '0',
  `id_cuso` int DEFAULT '0',
  `division` varchar(20) DEFAULT NULL,
  `ciclo_lectivo` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `fecha_desde` date DEFAULT NULL,
  `fecha_hasta` date DEFAULT NULL,
  `observaciones` text,
  PRIMARY KEY (`IdTrayctoriaEducativa`) USING BTREE,
  KEY `FK_trayectoria-educativa_alumnos` (`id_alumno`),
  KEY `FK_trayectoria-educativa_institucion-educativa` (`id_institucion`),
  KEY `FK_trayectoria-educativa_cursos` (`id_cuso`),
  CONSTRAINT `FK_trayectoria-educativa_alumnos` FOREIGN KEY (`id_alumno`) REFERENCES `alumnos` (`IdAlumno`),
  CONSTRAINT `FK_trayectoria-educativa_cursos` FOREIGN KEY (`id_cuso`) REFERENCES `cursos` (`IdCurso`),
  CONSTRAINT `FK_trayectoria-educativa_institucion-educativa` FOREIGN KEY (`id_institucion`) REFERENCES `institucion-educativa` (`IdInstitucion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- La exportación de datos fue deseleccionada.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
