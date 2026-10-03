-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.4.3 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.8.0.6908
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Volcando datos para la tabla db_crea.alumno-responsable: ~10 rows (aproximadamente)
INSERT INTO `alumno-responsable` (`IdAlumnoResponsable`, `id_alumno`, `id_responsable`, `patentesco`, `esContactoPrincipal`) VALUES
	(1, 1, 1, 'Madre', 1),
	(2, 2, 2, 'Padre', 1),
	(3, 3, 3, 'Madre', 1),
	(4, 4, 4, 'Padre', 1),
	(5, 5, 5, 'Madre', 1),
	(6, 6, 6, 'Tutor', 1),
	(7, 7, 7, 'Madre', 1),
	(8, 8, 8, 'Padre', 1),
	(9, 9, 9, 'Abuela', 1),
	(10, 10, 10, 'Madre', 1);

-- Volcando datos para la tabla db_crea.alumnos: ~10 rows (aproximadamente)
INSERT INTO `alumnos` (`IdAlumno`, `id_persona`, `fecha_ingreso`, `fecha_egreso`, `activo`, `observacion`) VALUES
	(1, 1, '2026-03-01', NULL, 1, 'Alumno de nivel secundario.'),
	(2, 2, '2026-03-02', NULL, 1, 'Asiste a clases de matemática y lengua.'),
	(3, 3, '2026-03-03', NULL, 1, 'Alumno de nivel primario.'),
	(4, 4, '2026-03-04', NULL, 1, 'Asiste a clases de inglés.'),
	(5, 5, '2026-03-05', NULL, 1, 'Alumno de nivel terciario.'),
	(6, 6, '2026-03-06', NULL, 1, 'Asiste a clases de matemática y física.'),
	(7, 7, '2026-03-07', NULL, 1, 'Alumno de nivel secundario.'),
	(8, 8, '2026-03-08', NULL, 1, 'Asiste a clases de química e historia.'),
	(9, 9, '2026-03-09', NULL, 1, 'Alumno que se prepara para el ingreso universitario.'),
	(10, 10, '2026-03-10', NULL, 1, 'Asiste a acompañamiento escolar.');

-- Volcando datos para la tabla db_crea.aranceles: ~10 rows (aproximadamente)
INSERT INTO `aranceles` (`IdArancel`, `nombre`, `descripcion`, `monto`, `fecha_vigencia_desde`, `fecha_vigencia_hasta`, `activo`) VALUES
	(1, 'Cuota mensual', 'Arancel mensual por acompañamiento escolar general.', 25000.00, '2026-01-01', '2026-12-31', 1),
	(2, 'Matemática', 'Arancel por clases de apoyo de matemática.', 8000.00, '2026-01-01', '2026-12-31', 1),
	(3, 'Lengua y Literatura', 'Arancel por clases de apoyo de lengua y literatura.', 8000.00, '2026-01-01', '2026-12-31', 1),
	(4, 'Inglés', 'Arancel por clases de apoyo de inglés.', 8500.00, '2026-01-01', '2026-12-31', 1),
	(5, 'Geografía', 'Arancel por clases de apoyo de geografía.', 7500.00, '2026-01-01', '2026-12-31', 1),
	(6, 'Física', 'Arancel por clases de apoyo de física.', 9000.00, '2026-01-01', '2026-12-31', 1),
	(7, 'Química', 'Arancel por clases de apoyo de química.', 9000.00, '2026-01-01', '2026-12-31', 1),
	(8, 'Historia', 'Arancel por clases de apoyo de historia.', 7500.00, '2026-01-01', '2026-12-31', 1),
	(9, 'Preparación ingreso', 'Arancel por preparación para ingreso a universidad o policía.', 12000.00, '2026-01-01', '2026-12-31', 1),
	(10, 'Apoyo escolar primario', 'Arancel por acompañamiento escolar para alumnos de nivel primario.', 22000.00, '2026-01-01', '2026-12-31', 1);

-- Volcando datos para la tabla db_crea.asistencia: ~10 rows (aproximadamente)
INSERT INTO `asistencia` (`IdAsistencia`, `id_clase`, `id_alumno`, `estado`, `observacion`) VALUES
	(11, 1, 1, 1, 'Asistió y realizó las actividades de matemática.'),
	(12, 2, 2, 1, 'Asistió con normalidad y participó en la clase.'),
	(13, 3, 3, 0, 'No asistió a la clase de inglés.'),
	(14, 4, 4, 1, 'Asistió y completó las actividades de geografía.'),
	(15, 5, 5, 1, 'Asistió y realizó los ejercicios de física.'),
	(16, 6, 6, 0, 'No asistió a la clase de química.'),
	(17, 7, 7, 1, 'Asistió y participó en las actividades de historia.'),
	(18, 8, 8, 1, 'Asistió al acompañamiento escolar de nivel primario.'),
	(19, 9, 9, 1, 'Asistió y completó los ejercicios de matemática.'),
	(20, 10, 10, 0, 'Ausencia justificada por el responsable.');

-- Volcando datos para la tabla db_crea.aulas: ~10 rows (aproximadamente)
INSERT INTO `aulas` (`IdAula`, `nombre`, `capacidad`, `descripcion`, `activo`) VALUES
	(1, 'Aula 1', 4, 'Aula destinada a clases de matemática y física.', 1),
	(2, 'Aula 2', 4, 'Aula destinada a clases de lengua y literatura.', 1),
	(3, 'Aula 3', 4, 'Aula destinada a clases de inglés.', 1),
	(4, 'Aula 4', 4, 'Aula destinada a clases de geografía e historia.', 1),
	(5, 'Aula 5', 4, 'Aula destinada a clases de química.', 1),
	(6, 'Aula 6', 5, 'Aula destinada al acompañamiento escolar primario.', 1),
	(7, 'Aula 7', 6, 'Aula destinada a preparación para ingresos universitarios.', 1),
	(8, 'Aula 8', 6, 'Aula destinada a preparación para ingreso a la policía.', 1),
	(9, 'Aula 9', 4, 'Aula disponible para clases de apoyo y actividades especiales.', 1),
	(10, 'Aula 10', 8, 'Aula de uso general para grupos de mayor tamaño.', 1);

-- Volcando datos para la tabla db_crea.cargos: ~10 rows (aproximadamente)
INSERT INTO `cargos` (`IdCargo`, `nombre`, `descripcion`) VALUES
	(1, 'Director', 'Responsable de la dirección y coordinación general del C.R.E.A.'),
	(2, 'Profesor de Matemática', 'Docente encargado de brindar apoyo y acompañamiento en matemática.'),
	(3, 'Profesor de Lengua y Literatura', 'Docente encargado de brindar apoyo en lengua y literatura.'),
	(4, 'Profesor de Inglés', 'Docente encargado de brindar apoyo y enseñanza de inglés.'),
	(5, 'Profesor de Geografía', 'Docente encargado de brindar apoyo en geografía.'),
	(6, 'Profesor de Física y Química', 'Docente encargado de brindar apoyo en física y química.'),
	(7, 'Profesor de Historia y Formación Ética', 'Docente encargado de brindar apoyo en historia y formación ética.'),
	(8, 'Maestra de Primaria', 'Docente encargada del acompañamiento escolar de alumnos de nivel primario.'),
	(9, 'Secretaria', 'Personal encargado de tareas administrativas y atención a alumnos y responsables.'),
	(10, 'Personal de Limpieza', 'Personal encargado de la limpieza y mantenimiento de las instalaciones.');

-- Volcando datos para la tabla db_crea.clase-alumno: ~10 rows (aproximadamente)
INSERT INTO `clase-alumno` (`IdClase`, `IdAlumno`) VALUES
	(1, 101),
	(1, 102),
	(1, 103),
	(2, 101),
	(2, 104),
	(3, 105),
	(3, 106),
	(4, 107),
	(4, 108),
	(5, 109);

-- Volcando datos para la tabla db_crea.clases: ~10 rows (aproximadamente)
INSERT INTO `clases` (`IdClase`, `id_docente`, `id_materia`, `id_aula`, `tipo_clase`, `fecha`, `hora_inicio`, `hora_fin`, `estado`, `observacion`) VALUES
	(1, 1, 1, 1, 'Apoyo escolar', '2026-09-01', '09:00:00', '10:00:00', 1, 'Clase de apoyo de matemática.'),
	(2, 2, 2, 2, 'Apoyo escolar', '2026-09-01', '09:00:00', '10:00:00', 1, 'Comprensión lectora y actividades de lengua.'),
	(3, 3, 3, 3, 'Apoyo escolar', '2026-09-02', '16:00:00', '17:00:00', 1, 'Práctica de vocabulario y comprensión en inglés.'),
	(4, 4, 4, 4, 'Apoyo escolar', '2026-09-02', '16:00:00', '17:00:00', 1, 'Repaso de contenidos de geografía.'),
	(5, 5, 5, 5, 'Apoyo escolar', '2026-09-03', '09:00:00', '10:00:00', 1, 'Resolución de ejercicios de física.'),
	(6, 5, 6, 5, 'Apoyo escolar', '2026-09-03', '10:00:00', '11:00:00', 1, 'Actividades prácticas de química.'),
	(7, 6, 7, 4, 'Apoyo escolar', '2026-09-04', '16:00:00', '17:00:00', 1, 'Repaso de contenidos de historia.'),
	(8, 7, 9, 6, 'Acompañamiento primario', '2026-09-04', '17:00:00', '18:00:00', 1, 'Acompañamiento escolar para nivel primario.'),
	(9, 8, 1, 1, 'Apoyo escolar', '2026-09-05', '09:00:00', '10:00:00', 1, 'Ejercicios de matemática para nivel secundario.'),
	(10, 10, 10, 7, 'Preparación ingreso', '2026-09-05', '10:00:00', '12:00:00', 1, 'Preparación para ingreso universitario.');

-- Volcando datos para la tabla db_crea.cuotas: ~10 rows (aproximadamente)
INSERT INTO `cuotas` (`IdCuotas`, `id_arancel`, `id_inscripcion`, `periodo`, `monto`, `fecha_vencimiento`, `estado`) VALUES
	(2, 1, 1, 'Marzo 2026', 25000.00, '2026-03-10', 1),
	(3, 1, 2, 'Abril 2026', 25000.00, '2026-04-10', 1),
	(4, 2, 3, 'Mayo 2026', 8000.00, '2026-05-15', 0),
	(5, 2, 4, 'Junio 2026', 8000.00, '2026-06-15', 1),
	(6, 3, 5, 'Julio 2026', 8000.00, '2026-07-10', 1),
	(7, 3, 6, 'Agosto 2026', 8000.00, '2026-08-10', 0),
	(8, 4, 7, 'Septiembre 2026', 8500.00, '2026-09-10', 1),
	(9, 4, 8, 'Octubre 2026', 8500.00, '2026-10-10', 1),
	(10, 5, 9, 'Noviembre 2026', 9000.00, '2026-11-10', 0),
	(11, 5, 10, 'Diciembre 2026', 9000.00, '2026-12-10', 1);

-- Volcando datos para la tabla db_crea.cursos: ~10 rows (aproximadamente)
INSERT INTO `cursos` (`IdCurso`, `id_nivel`, `nombre`, `orden`) VALUES
	(1, 1, '1.º Grado', '1'),
	(2, 1, '2.º Grado', '2'),
	(3, 1, '3.º Grado', '3'),
	(4, 1, '4.º Grado', '4'),
	(5, 1, '5.º Grado', '5'),
	(6, 1, '6.º Grado', '6'),
	(7, 2, '1.º Año', '1'),
	(8, 2, '2.º Año', '2'),
	(9, 2, '3.º Año', '3'),
	(10, 2, '4.º Año', '4');

-- Volcando datos para la tabla db_crea.disponibilidad-docente: ~9 rows (aproximadamente)
INSERT INTO `disponibilidad-docente` (`IdDisponibilidad`, `id_docente`, `dia_semana`, `hora_inicio`, `hora_fin`, `turno`, `activo`) VALUES
	(1, 1, 'Lunes', '08:00:00', '12:00:00', 'Mañana', 1),
	(2, 1, 'Martes', '14:00:00', '18:00:00', 'Tarde', 1),
	(3, 2, 'Miércoles', '08:00:00', '12:00:00', 'Mañana', 1),
	(4, 2, 'Jueves', '16:00:00', '20:00:00', 'Tarde', 1),
	(5, 3, 'Viernes', '09:00:00', '13:00:00', 'Mañana', 1),
	(6, 3, 'Sábado', '10:00:00', '14:00:00', 'Mañana', 1),
	(7, 4, 'Lunes', '18:00:00', '22:00:00', 'Noche', 1),
	(8, 4, 'Martes', '08:00:00', '12:00:00', 'Mañana', 1),
	(9, 5, 'Miércoles', '14:00:00', '18:00:00', 'Tarde', 1),
	(10, 5, 'Viernes', '18:00:00', '22:00:00', 'Noche', 1);

-- Volcando datos para la tabla db_crea.docente-materia: ~10 rows (aproximadamente)
INSERT INTO `docente-materia` (`Iddocente`, `IdMateria`) VALUES
	(1, 1),
	(2, 2),
	(3, 3),
	(4, 4),
	(5, 5),
	(5, 6),
	(6, 7),
	(6, 8),
	(7, 9),
	(8, 1);

-- Volcando datos para la tabla db_crea.docentes: ~10 rows (aproximadamente)
INSERT INTO `docentes` (`IdDocente`, `id_persona`, `especialidad`, `fecha_alta`, `activo`) VALUES
	(1, 1, 'Matemática', '2026-02-01', 1),
	(2, 2, 'Lengua y Literatura', '2026-02-01', 1),
	(3, 3, 'Inglés', '2026-02-02', 1),
	(4, 4, 'Geografía', '2026-02-02', 1),
	(5, 5, 'Física y Química', '2026-02-03', 1),
	(6, 6, 'Historia y Formación Ética', '2026-02-03', 1),
	(7, 7, 'Maestra de Nivel Primario', '2026-02-05', 1),
	(8, 8, 'Matemática', '2026-02-10', 1),
	(9, 9, 'Ciencias Naturales', '2026-02-12', 1),
	(10, 10, 'Preparación para Ingreso Universitario', '2026-02-15', 1);

-- Volcando datos para la tabla db_crea.inscripcion-materia: ~9 rows (aproximadamente)
INSERT INTO `inscripcion-materia` (`IdInscripcionMateria`, `id_inscripcion`, `id_materia`, `fecha_inicio`, `fecha_fin`, `estado`) VALUES
	(21, 1, 1, '2026-03-01', '2026-07-15', 1),
	(22, 2, 2, '2026-03-05', '2026-07-20', 1),
	(23, 3, 3, '2026-03-10', '2026-07-25', 1),
	(24, 4, 4, '2026-03-15', '2026-07-30', 0),
	(25, 5, 5, '2026-03-20', '2026-08-05', 1),
	(26, 6, 6, '2026-03-25', '2026-08-10', 1),
	(27, 7, 7, '2026-04-01', '2026-08-15', 0),
	(28, 8, 8, '2026-04-05', '2026-08-20', 1),
	(29, 9, 9, '2026-04-10', '2026-08-25', 1),
	(30, 10, 10, '2026-04-15', '2026-08-30', 0);

-- Volcando datos para la tabla db_crea.inscripciones: ~10 rows (aproximadamente)
INSERT INTO `inscripciones` (`IdInscripcion`, `id_alumno`, `fecha_inicio`, `fecha_fin`, `tipo_inscripcion`, `estado`, `observacion`) VALUES
	(1, 1, '2026-03-02', NULL, 'Acompañamiento escolar', 1, 'Acompañamiento durante el ciclo lectivo.'),
	(2, 2, '2026-03-02', NULL, 'Acompañamiento escolar', 1, 'Asiste regularmente durante el año.'),
	(3, 3, '2026-03-05', '2026-05-05', 'Apoyo terciario', 1, 'Inscripción por dos meses para preparación de materias.'),
	(4, 4, '2026-03-10', NULL, 'Apoyo secundario', 1, 'Apoyo en materias específicas.'),
	(5, 5, '2026-04-01', '2026-06-01', 'Ingreso universitario', 1, 'Preparación para examen de ingreso.'),
	(6, 6, '2026-04-05', NULL, 'Apoyo primario', 1, 'Acompañamiento escolar de nivel primario.'),
	(7, 7, '2026-04-10', NULL, 'Apoyo secundario', 1, 'Asiste para matemática y física.'),
	(8, 8, '2026-05-02', '2026-07-02', 'Ingreso Policía', 1, 'Preparación para ingreso a la policía.'),
	(9, 9, '2026-05-15', NULL, 'Apoyo terciario', 1, 'Asiste para materias específicas de su carrera.'),
	(10, 10, '2026-06-01', '2026-08-01', 'Apoyo universitario', 0, 'Inscripción finalizada.');

-- Volcando datos para la tabla db_crea.institucion-educativa: ~10 rows (aproximadamente)
INSERT INTO `institucion-educativa` (`IdInstitucion`, `nombre`, `direccion`, `telefono`, `email`, `activo`) VALUES
	(1, 'E.P.E.T. N.º 13 General José de San Martín', 'Av. San Martín 125', '3838-450001', 'epet13@gmail.com', 1),
	(2, 'Escuela Secundaria Santa María', 'Belgrano 240', '3838-450002', 'secundariasantamaria@gmail.com', 1),
	(3, 'Escuela Primaria N.º 705', 'Rivadavia 315', '3838-450003', 'escuela705@gmail.com', 1),
	(4, 'Colegio Privado San Francisco', 'Mitre 420', '3838-450004', 'colegiosanfrancisco@gmail.com', 1),
	(5, 'Escuela Secundaria N.º 448', 'Sarmiento 180', '3838-450005', 'escuela448@gmail.com', 1),
	(6, 'Instituto de Estudios Superiores Santa María', 'Av. 9 de Julio 350', '3838-450006', 'iesma@gmail.com', 1),
	(7, 'Escuela Normal de Santa María', 'Belgrano 580', '3838-450007', 'escuelanormal@gmail.com', 1),
	(8, 'Escuela Primaria N.º 114', 'San Martín 625', '3838-450008', 'escuela114@gmail.com', 1),
	(9, 'Colegio Secundario Santa Rosa', 'Catamarca 290', '3838-450009', 'colegiosantarosa@gmail.com', 1),
	(10, 'Instituto de Formación Profesional', 'Rivadavia 710', '3838-450010', 'institutoformacion@gmail.com', 1);

-- Volcando datos para la tabla db_crea.materias: ~10 rows (aproximadamente)
INSERT INTO `materias` (`IdMateria`, `nombre`, `descripcion`, `activo`) VALUES
	(1, 'Matemática', 'Clases de apoyo y acompañamiento en matemática.', 1),
	(2, 'Lengua y Literatura', 'Clases de apoyo en lengua, literatura y comprensión lectora.', 1),
	(3, 'Inglés', 'Clases de apoyo y aprendizaje del idioma inglés.', 1),
	(4, 'Geografía', 'Clases de apoyo en geografía y contenidos relacionados.', 1),
	(5, 'Física', 'Clases de apoyo en física.', 1),
	(6, 'Química', 'Clases de apoyo en química.', 1),
	(7, 'Historia', 'Clases de apoyo en historia.', 1),
	(8, 'Formación Ética', 'Clases de apoyo en formación ética y ciudadana.', 1),
	(9, 'Ciencias Naturales', 'Apoyo escolar en ciencias naturales para nivel primario y secundario.', 1),
	(10, 'Informática', 'Clases de apoyo en informática y contenidos relacionados con tecnología.', 1);

-- Volcando datos para la tabla db_crea.nivel-educativo: ~10 rows (aproximadamente)
INSERT INTO `nivel-educativo` (`IdNiverEducativo`, `nombre`, `descripcion`) VALUES
	(1, 'Primario', 'Educación primaria'),
	(2, 'Secundario', 'Educación secundaria'),
	(3, 'Terciario', 'Educación terciaria'),
	(4, 'Universitario', 'Educación universitaria'),
	(5, 'Ingreso Universitario', 'Preparación para ingreso universitario'),
	(6, 'Ingreso Policía', 'Preparación para ingreso a la policía'),
	(7, 'Inicial', 'Educación inicial'),
	(8, 'Adultos', 'Educación para jóvenes y adultos'),
	(9, 'Formación Profesional', 'Cursos de formación profesional'),
	(10, 'Otro', 'Nivel educativo no especificado');

-- Volcando datos para la tabla db_crea.pagos: ~10 rows (aproximadamente)
INSERT INTO `pagos` (`IdPago`, `id_cuota`, `id_personal`, `fecha_pago`, `monto`, `medio_pago`, `observacion`) VALUES
	(11, 2, 1, '2026-03-10', 15000.00, 'Efectivo', 'Pago realizado en caja.'),
	(12, 3, 2, '2026-04-10', 15000.00, 'Transferencia', 'Transferencia bancaria confirmada.'),
	(13, 4, 3, '2026-05-15', 18000.00, 'Tarjeta de crédito', 'Pago con tarjeta Visa.'),
	(14, 5, 4, '2026-06-15', 18000.00, 'Efectivo', 'Pago directo en oficina.'),
	(15, 6, 5, '2026-07-20', 20000.00, 'Transferencia', 'Pago automático desde cuenta.'),
	(16, 7, 6, '2026-08-20', 20000.00, 'Tarjeta de débito', 'Pago con tarjeta Mastercard.'),
	(17, 8, 7, '2026-09-25', 22000.00, 'Efectivo', 'Pago realizado por tesorería.'),
	(18, 9, 8, '2026-10-25', 22000.00, 'Transferencia', 'Pago confirmado por banco.'),
	(19, 10, 9, '2026-11-30', 25000.00, 'Tarjeta de crédito', 'Pago con cuotas sin interés.'),
	(20, 11, 10, '2026-12-30', 25000.00, 'Efectivo', 'Pago final del período.');

-- Volcando datos para la tabla db_crea.personal: ~10 rows (aproximadamente)
INSERT INTO `personal` (`IdPersonal`, `id_persona`, `id_cargo`, `fecha_ingreso`, `activo`) VALUES
	(1, 1, 1, '2022-02-01', 1),
	(2, 2, 2, '2022-03-10', 1),
	(3, 3, 3, '2022-03-15', 1),
	(4, 4, 4, '2022-04-01', 1),
	(5, 5, 5, '2022-04-20', 1),
	(6, 6, 6, '2022-05-05', 1),
	(7, 7, 7, '2022-05-15', 1),
	(8, 8, 8, '2022-06-01', 1),
	(9, 9, 9, '2022-06-10', 1),
	(10, 10, 10, '2022-06-20', 1);

-- Volcando datos para la tabla db_crea.personas: ~10 rows (aproximadamente)
INSERT INTO `personas` (`IdPersona`, `dni`, `nombre`, `apellido`, `fechaNacimiento`, `telefono`, `email`, `direccion`, `activo`, `fechaAlta`) VALUES
	(1, '40123456', 'Juan', 'Pérez', '2000-05-12', '3834123456', 'juan.perez@gmail.com', 'Av. Belgrano 125', 1, '2026-09-01'),
	(2, '42345678', 'María', 'Gómez', '1999-08-23', '3834234567', 'maria.gomez@gmail.com', 'Calle Sarmiento 234', 1, '2026-09-02'),
	(3, '43456789', 'Lucía', 'Fernández', '2002-01-15', '3834345678', 'lucia.fernandez@gmail.com', 'Calle San Martín 456', 1, '2026-09-03'),
	(4, '44567890', 'Carlos', 'Rodríguez', '1998-11-30', '3834456789', 'carlos.rodriguez@gmail.com', 'Av. Rivadavia 789', 1, '2026-09-04'),
	(5, '45678901', 'Sofía', 'López', '2001-06-18', '3834567890', 'sofia.lopez@gmail.com', 'Calle Mitre 321', 1, '2026-09-05'),
	(6, '40123456', 'Juan', 'Pérez', '2000-05-12', '3834123456', 'juan.perez@gmail.com', 'Av. Belgrano 125', 1, '2026-09-01'),
	(7, '42345678', 'María', 'Gómez', '1999-08-23', '3834234567', 'maria.gomez@gmail.com', 'Calle Sarmiento 234', 1, '2026-09-02'),
	(8, '43456789', 'Lucía', 'Fernández', '2002-01-15', '3834345678', 'lucia.fernandez@gmail.com', 'Calle San Martín 456', 1, '2026-09-03'),
	(9, '44567890', 'Carlos', 'Rodríguez', '1998-11-30', '3834456789', 'carlos.rodriguez@gmail.com', 'Av. Rivadavia 789', 1, '2026-09-04'),
	(10, '45678901', 'Sofía', 'López', '2001-06-18', '3834567890', 'sofia.lopez@gmail.com', 'Calle Mitre 321', 1, '2026-09-05');

-- Volcando datos para la tabla db_crea.responsable: ~10 rows (aproximadamente)
INSERT INTO `responsable` (`IdResponsable`, `id_persona`) VALUES
	(1, 1),
	(2, 2),
	(3, 3),
	(4, 4),
	(5, 5),
	(6, 6),
	(7, 7),
	(8, 8),
	(9, 9),
	(10, 10);

-- Volcando datos para la tabla db_crea.roles: ~10 rows (aproximadamente)
INSERT INTO `roles` (`IdRol`, `nombre`, `descripcion`) VALUES
	(1, 'Administrador', 'Tiene acceso completo al sistema y puede gestionar usuarios, roles y datos.'),
	(2, 'Director', 'Puede consultar y gestionar la información general del C.R.E.A.'),
	(3, 'Secretaria', 'Puede gestionar alumnos, responsables, inscripciones y datos administrativos.'),
	(4, 'Profesor', 'Puede consultar sus clases, alumnos y registrar asistencias y observaciones.'),
	(5, 'Maestra de Primaria', 'Puede gestionar el acompañamiento y seguimiento de alumnos de nivel primario.'),
	(6, 'Preceptor', 'Puede registrar y consultar asistencias y novedades de los alumnos.'),
	(7, 'Personal de Limpieza', 'Rol destinado al personal encargado de limpieza y mantenimiento.'),
	(8, 'Consulta', 'Permite consultar información del sistema sin modificar datos.'),
	(9, 'Coordinador', 'Puede coordinar clases, docentes, aulas y horarios.'),
	(10, 'Invitado', 'Acceso limitado a determinadas funciones del sistema.');

-- Volcando datos para la tabla db_crea.seguimiento-pedagogico: ~10 rows (aproximadamente)
INSERT INTO `seguimiento-pedagogico` (`IdSeguimiento`, `id_materia`, `id_alumno`, `id_docente`, `fecha`, `tema_trabajado`, `avance`, `dificultades`, `recomendacion`, `observacion`) VALUES
	(1, 1, 1, 1, '2026-09-01', 'Introducción a álgebra', 'Buen progreso en operaciones básicas', 'Confusión en signos negativos', 'Reforzar ejercicios con números enteros', 'Participó activamente'),
	(2, 2, 2, 2, '2026-09-02', 'Lectura comprensiva', 'Mejoró la velocidad de lectura', 'Dificultad en inferencias', 'Practicar textos cortos con preguntas', 'Necesita más confianza'),
	(3, 3, 3, 3, '2026-09-03', 'Historia Argentina', 'Reconoce fechas clave', 'Problemas para relacionar causas y consecuencias', 'Usar línea de tiempo visual', 'Atento en clase'),
	(4, 4, 4, 4, '2026-09-04', 'Química básica', 'Comprende estados de la materia', 'Confusión en cambios físicos vs químicos', 'Realizar experimentos simples', 'Entusiasmado con prácticas'),
	(5, 5, 5, 5, '2026-09-05', 'Geometría', 'Identifica figuras y perímetros', 'Errores en cálculo de áreas', 'Revisar fórmulas con ejemplos', 'Se distrae con facilidad'),
	(6, 6, 6, 6, '2026-09-06', 'Inglés básico', 'Aprendió vocabulario cotidiano', 'Pronunciación débil', 'Escuchar audios y repetir', 'Motivado por canciones'),
	(7, 7, 7, 7, '2026-09-07', 'Biología celular', 'Reconoce partes de la célula', 'Confunde funciones de orgánulos', 'Usar esquemas gráficos', 'Preguntó mucho en clase'),
	(8, 8, 8, 8, '2026-09-08', 'Educación física', 'Mejoró coordinación motriz', 'Cansancio rápido', 'Ejercicios de resistencia progresiva', 'Buen trabajo en equipo'),
	(9, 9, 9, 9, '2026-09-09', 'Literatura', 'Analizó un cuento breve', 'Dificultad en identificar narrador', 'Revisar ejemplos de narradores', 'Interesado en escribir'),
	(10, 10, 10, 10, '2026-09-10', 'Matemática financiera', 'Comprende interés simple', 'Confusión con interés compuesto', 'Resolver problemas prácticos', 'Necesita más práctica');

-- Volcando datos para la tabla db_crea.trayectoria-educativa: ~10 rows (aproximadamente)
INSERT INTO `trayectoria-educativa` (`IdTrayctoriaEdu`, `id_alumno`, `id_institucion`, `id_cuso`, `division`, `ciclo_luctivo`, `fecha_desde`, `fecha_hasta`, `observaciones`) VALUES
	(1, 1, 1, 1, 'A', '2023', '2023-03-01', '2023-12-15', 'Buen desempeño en Matemática'),
	(2, 2, 2, 2, 'B', '2023', '2023-03-01', '2023-12-15', 'Necesita apoyo en Lengua'),
	(3, 3, 3, 3, 'C', '2023', '2023-03-01', '2023-12-15', 'Participación destacada en Historia'),
	(4, 4, 4, 4, 'A', '2024', '2024-03-01', '2024-12-15', 'Mejoró en Ciencias Naturales'),
	(5, 5, 5, 5, 'B', '2024', '2024-03-01', '2024-12-15', 'Dificultades en comprensión lectora'),
	(6, 6, 6, 6, 'C', '2024', '2024-03-01', '2024-12-15', 'Excelente rendimiento en Inglés'),
	(7, 7, 7, 7, 'A', '2025', '2025-03-01', '2025-12-15', 'Avances en Educación Física'),
	(8, 8, 8, 8, 'B', '2025', '2025-03-01', '2025-12-15', 'Problemas de asistencia'),
	(9, 9, 9, 9, 'C', '2025', '2025-03-01', '2025-12-15', 'Gran interés en Arte'),
	(10, 10, 10, 10, 'A', '2025', '2025-03-01', '2025-12-15', 'Requiere refuerzo en Química');

-- Volcando datos para la tabla db_crea.usuario-rol: ~10 rows (aproximadamente)
INSERT INTO `usuario-rol` (`IdRol`, `IdUsuario`) VALUES
	(1, 1),
	(2, 2),
	(3, 3),
	(4, 4),
	(5, 5),
	(6, 6),
	(7, 7),
	(8, 8),
	(9, 9),
	(10, 10);

-- Volcando datos para la tabla db_crea.usuarios: ~10 rows (aproximadamente)
INSERT INTO `usuarios` (`IdUsuario`, `id_persona`, `usuario`, `password_hash`, `activo`, `fecha_creacion`, `ultimo_acceso`) VALUES
	(1, 1, 'malena.galarza', '$2b$10$EjemploHash001', 1, '2026-01-10 08:30:00', '2026-09-01 10:15:00'),
	(2, 2, 'juan.perez', '$2b$10$EjemploHash002', 1, '2026-01-12 09:00:00', '2026-09-02 08:45:00'),
	(3, 3, 'maria.gomez', '$2b$10$EjemploHash003', 1, '2026-01-15 10:20:00', '2026-09-03 11:30:00'),
	(4, 4, 'carlos.lopez', '$2b$10$EjemploHash004', 1, '2026-01-18 08:15:00', '2026-08-30 09:20:00'),
	(5, 5, 'ana.martinez', '$2b$10$EjemploHash005', 1, '2026-01-20 11:00:00', '2026-09-04 16:10:00'),
	(6, 6, 'lucas.fernandez', '$2b$10$EjemploHash006', 1, '2026-02-01 09:30:00', '2026-09-05 10:00:00'),
	(7, 7, 'sofia.diaz', '$2b$10$EjemploHash007', 1, '2026-02-05 14:00:00', '2026-09-06 15:25:00'),
	(8, 8, 'martin.sosa', '$2b$10$EjemploHash008', 1, '2026-02-10 08:45:00', '2026-09-07 09:40:00'),
	(9, 9, 'valentina.ruiz', '$2b$10$EjemploHash009', 1, '2026-02-15 10:15:00', '2026-09-08 10:30:00'),
	(10, 10, 'diego.torres', '$2b$10$EjemploHash010', 0, '2026-02-20 12:00:00', NULL);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
