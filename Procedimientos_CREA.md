# =====================================================================================================================================





PROCEDIMIENTOS ALMACENADOS:



### PERSONAS

sp\_persona\_insertar
insert into personas
(dni, nombre, apellido, fechaNacimiento, teléfono, email, dirección, activo, fechaAlta)
values
(p\_nombre, p\_apellido, p\_fechaNacimienteo, p\_telefono, p\_email, p\_direccion, p\_activo, p\_fechaAlta);

sp\_persona\_obtener
slect \* from personas where IdPersona = p\_id;



sp\_persona\_buscar
select \*
from personas
where dni like concat(%, p\_busqueda, %)
or nombre like concat(%, p\_busqueda, %)
or apellido like concat(%, p\_busqueda, %);

&#x20;

sp\_persona\_actualizar
update personas
set dni = p\_dni,

&#x20;   nombre = p\_nombre,

&#x20;   apellido = p\_apellido,

&#x20;   fechaNacimiento = p\_fechaNacimiento,

&#x20;   telefono = p\_telefono,

&#x20;   email = p\_email,

&#x20;   direccion = p\_direccion

where IdPersona = p\_id;

### 

### 

### ALUMNOS

sp\_alumno\_insertar
INSERT INTO Alumnos

&#x20;   (id\_persona, fecha\_ingreso, fecha\_egreso, activo, Observacion)

&#x20;   VALUES

&#x20;   (p\_id\_persona, p\_fecha\_ingreso, p\_fecha\_egreso,

&#x20;    p\_activo, p\_observacion);



sp\_alumno\_consultar

select \*
from alumnos
where p\_id\_alumno is null
or IdAlumno = p\_id\_alumno;



sp\_alumno\_actualizar
update alumno
set fecha\_ingreso = p\_fecha\_ingreso,

&#x20;   fecha\_egreso = p\_fecha\_egreso,

&#x20;   activo = p\_activo,

&#x20;   Observacion = p\_observacion
where IdAlumno = p\_id;



### RESPONSABLE

sp\_responsable\_insertar
insert into responsable (id\_persona)
value (p\_id\_persona);



sp\_responsable\_consultar
SELECT r.\*, p.nombre, p.apellido, p.dni

&#x20;   FROM Responsables r

&#x20;   INNER JOIN Personas p ON r.id\_persona = p.IdPersona

&#x20;   WHERE r.IdResponsable = p\_id;

sp\_responsable\_actualizar
update responsable
set id\_persona = p\_id\_persona
where IdResponsable = p\_id;



### DOCENTES

sp\_docente\_insertar

insert into docentes (id\_persona, especialida, fecha\_alta, activo)

values
(p\_id\_persona, p\_especialidad, p\_fecha\_alta, p\_activo);



sp\_docente\_consultar
SELECT d.\*, p.nombre, p.apellido, p.dni

&#x20;   FROM Docentes d

&#x20;   INNER JOIN Personas p ON d.id\_persona = p.IdPersona

&#x20;   WHERE p\_id IS NULL OR d.IdDocente = p\_id;



sp\_docente\_actualizar
update docente
set especialidad = p\_especialidad,
activo = p\_activo
where IdDocente = p\_id;





### PERSONAL

sp\_personal\_insertar
insert into personal(id\_persona, id\_cargo, fecha\_ingreso, activo)
values (p\_id\_persona, p\_id\_cargo, p\_fecha\_ingreso, p\_actvio);



sp\_personal\_consultar
SELECT p.\*, pe.nombre, pe.apellido, c.nombre AS cargo

&#x20;   FROM Personal p

&#x20;   INNER JOIN Personas pe ON p.id\_persona = pe.IdPersona

&#x20;   INNER JOIN Cargos c ON p.id\_cargo = c.IdCargo

&#x20;   WHERE p\_id IS NULL OR p.IdPersonal = p\_id;



sp\_personal\_actualizar
update personal
set
id\_cargo = p\_id\_cargo,
activo = p\_activo
where IdPersonal = p\_id;





### ROLES

sp\_rol\_consultar
select \*
from roles
where p\_id is null or IdRol = p\_id;



sp\_rol\_actualizar
update Roles
set nombre = p\_nombre,
descripción = p\_descripcion
where IdRol = p\_id;



sp\_rol\_insertar

insert into Roles (nombre, descripción)
values (p\_nombre, p\_descripcion);





### INSTITUCION EDUCATIVA

sp\_institucion\_insertar

INSERT INTO `Institución-Educativa`

&#x20;   (nombre, direccion, telefono, email, activo)
VALUES

&#x20;   (p\_nombre, p\_direccion, p\_telefono, p\_email, p\_activo);



sp\_institucion\_consultar
SELECT \*

&#x20;   FROM `Institución-Educativa`

&#x20;   WHERE p\_id IS NULL OR IdInstitucion = p\_id;



sp\_institucion\_actualizar
UPDATE `Institución-Educativa`

&#x20;   SET nombre = p\_nombre,

&#x20;       direccion = p\_direccion,

&#x20;       telefono = p\_telefono,

&#x20;       email = p\_email,

&#x20;       activo = p\_activo

&#x20;   WHERE IdInstitucion = p\_id;







### NIVEL EDUCATIVO

sp\_nivel\_educativo\_consultar
SELECT \*

FROM `Nivel-Educativo`

WHERE p\_id IS NULL OR IdNivelEducativo = p\_id;



sp\_nivel\_educativo\_insertar
INSERT INTO `Nivel-Educativo`

&#x20;   (nombre, descripcion)

VALUES
(p\_nombre, p\_descripcion);



sp\_nivel\_educativo\_actualizar
UPDATE `Nivel-Educativo`

SET nombre = p\_nombre,

&#x20;       descripcion = p\_descripcion

WHERE IdNivelEducativo = p\_id;





### CURSOS

sp\_curso\_insertar
INSERT INTO Cursos(id\_nivel, nombre, orden)

VALUES (p\_id\_nivel, p\_nombre, p\_orden);



sp\_curso\_consultar
SELECT c.\*, n.nombre AS nivel

FROM Cursos c

INNER JOIN `Nivel-Educativo` n

&#x20;   ON c.id\_nivel = n.IdNivelEducativo

WHERE p\_id IS NULL OR c.IdCurso = p\_id;



sp\_curso\_actualizar

UPDATE Cursos

SET id\_nivel = p\_id\_nivel,

&#x20;    nombre = p\_nombre,

&#x20;    orden = p\_orden
WHERE IdCurso = p\_id;



### TRAYETORIA EDUCATIVA

sp\_trayectoria\_registrar
INSERT INTO `Trayectoria-Educativa`

&#x20;   (id\_alumno, id\_institucion, id\_curso, division,

&#x20;    ciclo\_lectivo, fecha\_desde, fecha\_hasta, observaciones)

VALUES

&#x20;   (p\_id\_alumno, p\_id\_institucion, p\_id\_curso, p\_division,

&#x20;    p\_ciclo\_lectivo, p\_fecha\_desde, p\_fecha\_hasta, p\_observaciones);



sp\_trayectoria\_alumno
SELECT \*

FROM `Trayectoria-Educativa`

WHERE id\_alumno = p\_id\_alumno

ORDER BY fecha\_desde;

sp\_trayectoria\_actualizar

UPDATE `Trayectoria-Educativa`

SET id\_curso = p\_id\_curso,

&#x20;     division = p\_division,

&#x20;     ciclo\_lectivo = p\_ciclo\_lectivo,

&#x20;     fecha\_desde = p\_fecha\_desde,

&#x20;     fecha\_hasta = p\_fecha\_hasta,

&#x20;     observaciones = p\_observaciones
WHERE IdTrayectoriaEdu = p\_id;



### MATERIAS

sp\_materia\_insertar
INSERT INTO Materias(nombre, descripcion, activo)

&#x20;   VALUES (p\_nombre, p\_descripcion, p\_activo);



sp\_materia\_consultar
SELECT \*

&#x20;   FROM Materias

&#x20;   WHERE p\_id IS NULL OR IdMateria = p\_id;



sp\_materia\_actualizar

&#x20;UPDATE Materias

&#x20;   SET nombre = p\_nombre,

&#x20;       descripcion = p\_descripcion,

&#x20;       activo = p\_activo

&#x20;   WHERE IdMateria = p\_id;





### DOCENTE-MATERIA

sp\_docente\_asignar\_materia
INSERT INTO `Docente-Materia`

&#x20;   (IdDocente, IdMateria)

&#x20;   VALUES (p\_id\_docente, p\_id\_materia);



sp\_docente\_desasignar\_materia
DELETE FROM `Docente-Materia`

&#x20;   WHERE IdDocente = p\_id\_docente

&#x20;     AND IdMateria = p\_id\_materia;



sp\_docente\_materias

SELECT m.\*

&#x20;   FROM `Docente-Materia` dm

&#x20;   INNER JOIN Materias m ON dm.IdMateria = m.IdMateria

&#x20;   WHERE dm.IdDocente = p\_id\_docente;



### DISPONIBILIDAD DOCENTE

sp\_disponibilidad\_registrar
INSERT INTO `Disponibilidad-Docente`

&#x20;   (id\_docente, dia\_semana, hora\_inicio, hora\_fin, turno, activo)

&#x20;   VALUES

&#x20;   (p\_id\_docente, p\_dia\_semana, p\_hora\_inicio, p\_hora\_fin,

&#x20;    p\_turno, p\_activo);



sp\_disponibilidad\_docente
SELECT \*

&#x20;   FROM `Disponibilidad-Docente`

&#x20;   WHERE id\_docente = p\_id\_docente;



sp\_disponibilidad\_actualizar

UPDATE `Disponibilidad-Docente`

&#x20;   SET dia\_semana = p\_dia\_semana,

&#x20;       hora\_inicio = p\_hora\_inicio,

&#x20;       hora\_fin = p\_hora\_fin,

&#x20;       turno = p\_turno,

&#x20;       activo = p\_activo

&#x20;   WHERE IdDisponibilidad = p\_id;



### CLASES

sp\_clase\_crear
INSERT INTO Clases

&#x20;   (id\_docente, id\_materia, id\_aula, tipo\_clase, fecha,

&#x20;    hora\_inicio, hora\_fin, estado, observacion)

&#x20;   VALUES

&#x20;   (p\_id\_docente, p\_id\_materia, p\_id\_aula, p\_tipo\_clase, p\_fecha,

&#x20;    p\_hora\_inicio, p\_hora\_fin, p\_estado, p\_observacion);



sp\_clase\_consultar
SELECT \*

&#x20;   FROM Clases

&#x20;   WHERE p\_id IS NULL OR IdClase = p\_id;



sp\_clase\_actualizar

UPDATE Clases

&#x20;   SET id\_docente = p\_id\_docente,

&#x20;       id\_materia = p\_id\_materia,

&#x20;       id\_aula = p\_id\_aula,

&#x20;       fecha = p\_fecha,

&#x20;       hora\_inicio = p\_hora\_inicio,

&#x20;       hora\_fin = p\_hora\_fin,

&#x20;       estado = p\_estado,

&#x20;       observacion = p\_observacion

&#x20;   WHERE IdClase = p\_id;



### CLASE-ALUMNO

sp\_clase\_asignar\_alumno
INSERT INTO `Clase-Alumno`

&#x20;   (IdClase, idAlumno)

VALUES (p\_id\_clase, p\_id\_alumno);



sp\_clase\_quitar\_alumno
DELETE FROM `Clase-Alumno`

&#x20;   WHERE IdClase = p\_id\_clase

&#x20;     AND idAlumno = p\_id\_alumno;



sp\_clase\_alumnos
SELECT a.\*, p.nombre, p.apellido

&#x20;   FROM `Clase-Alumno` ca

&#x20;   INNER JOIN Alumnos a ON ca.idAlumno = a.IdAlumno

&#x20;   INNER JOIN Personas p ON a.id\_persona = p.IdPersona

&#x20;   WHERE ca.IdClase = p\_id\_clase;





### ASISTENCIAS

sp\_asistencia\_registrar
INSERT INTO Asistencias

&#x20;   (id\_clase, id\_alumno, estado, observacion)

&#x20;   VALUES

&#x20;   (p\_id\_clase, p\_id\_alumno, p\_estado, p\_observacion);



sp\_asistencia\_actualizar
UPDATE Asistencias

&#x20;   SET estado = p\_estado,

&#x20;       observacion = p\_observacion

&#x20;   WHERE IdAsistencia = p\_id;



sp\_asistencias\_alumno
SELECT \*

&#x20;   FROM Asistencias

&#x20;   WHERE id\_alumno = p\_id\_alumno;





### SEGUIMIENTO PEDAGOGICO

sp\_seguimientop\_registrar
INSERT INTO `Seguimiento-Pedagógico`

&#x20;   (id\_materia, id\_alumno, id\_docente, fecha,

&#x20;    tema\_trabajado, avance, dificultades, recomendacion, observacion)

&#x20;   VALUES

&#x20;   (p\_id\_materia, p\_id\_alumno, p\_id\_docente, p\_fecha,

&#x20;    p\_tema\_trabajado, p\_avance, p\_dificultades,

&#x20;    p\_recomendacion, p\_observacion);



sp\_seguimientop\_alumno
SELECT \*

&#x20;   FROM `Seguimiento-Pedagógico`

&#x20;   WHERE id\_alumno = p\_id\_alumno

&#x20;   ORDER BY fecha DESC;



sp\_seguimientop\_actualizar
UPDATE `Seguimiento-Pedagógico`

&#x20;   SET tema\_trabajado = p\_tema\_trabajado,

&#x20;       avance = p\_avance,

&#x20;       dificultades = p\_dificultades,

&#x20;       recomendacion = p\_recomendacion,

&#x20;       observacion = p\_observacion

&#x20;   WHERE IdSeguimiento = p\_id;





### INSCRIPCIONES

sp\_inscripcion\_crear
INSERT INTO `Inscripciónes`

&#x20;   (id\_alumno, fecha\_inicio, fecha\_fin, tipo\_inscripcion,

&#x20;    estado, observacion)

&#x20;   VALUES

&#x20;   (p\_id\_alumno, p\_fecha\_inicio, p\_fecha\_fin,

&#x20;    p\_tipo\_inscripcion, p\_estado, p\_observacion);



sp\_inscripcion\_consultar
SELECT \*

&#x20;   FROM `Inscripciónes`

&#x20;   WHERE p\_id IS NULL OR IdInscripcion = p\_id;



sp\_inscripciones\_alumno
SELECT \*

&#x20;   FROM `Inscripciónes`

&#x20;   WHERE id\_alumno = p\_id\_alumno;



sp\_inscripcion\_actualizar
UPDATE `Inscripciónes`

&#x20;   SET fecha\_fin = p\_fecha\_fin,

&#x20;       tipo\_inscripcion = p\_tipo\_inscripcion,

&#x20;       estado = p\_estado,

&#x20;       observacion = p\_observacion

&#x20;   WHERE IdInscripcion = p\_id;





### INCRIPCION-MATERIA

sp\_inscripcion\_agregar\_materia
INSERT INTO `Inscripción-Materia`

&#x20;   (id\_inscripcion, id\_materia, fecha\_inicio, estado)

&#x20;   VALUES

&#x20;   (p\_id\_inscripcion, p\_id\_materia, p\_fecha\_inicio, p\_estado);



sp\_inscripcion\_quitar\_materia
DELETE FROM `Inscripción-Materia`

&#x20;   WHERE IdInscripcionMateria = p\_id;



sp\_inscripcion\_materias
SELECT m.\*

&#x20;   FROM `Inscripción-Materia` im

&#x20;   INNER JOIN Materias m ON im.id\_materia = m.IdMateria

&#x20;   WHERE im.id\_inscripcion = p\_id\_inscripcion;





### ARANCELES

sp\_arancel\_listado
SELECT \*

&#x20;   FROM Aranceles

&#x20;   WHERE p\_id IS NULL OR IdArancel = p\_id;



sp\_arancel\_insertar
INSERT INTO Aranceles

&#x20;   (nombre, descripcion, monto, fecha\_vigencia\_desde,

&#x20;    fecha\_vigencia\_hasta, activo)

&#x20;   VALUES

&#x20;   (p\_nombre, p\_descripcion, p\_monto, p\_fecha\_desde,

&#x20;    p\_fecha\_hasta, p\_activo);



sp\_arancel\_actualizar
UPDATE Aranceles

&#x20;   SET nombre = p\_nombre,

&#x20;       descripcion = p\_descripcion,

&#x20;       monto = p\_monto,

&#x20;       fecha\_vigencia\_hasta = p\_fecha\_hasta,

&#x20;       activo = p\_activo

&#x20;   WHERE IdArancel = p\_id;





### CUOTAS

sp\_cuota\_generar
INSERT INTO Cuotas

&#x20;   (id\_arancel, id\_inscripcion, periodo, monto,

&#x20;    fecha\_vencimiento, estado)

&#x20;   VALUES

&#x20;   (p\_id\_arancel, p\_id\_inscripcion, p\_periodo, p\_monto,

&#x20;    p\_fecha\_vencimiento, p\_estado);



sp\_cuotas\_incripcion
SELECT \*

&#x20;   FROM Cuotas

&#x20;   WHERE id\_inscripcion = p\_id\_inscripcion;



sp\_cuota\_actualizar
UPDATE Cuotas

&#x20;   SET monto = p\_monto,

&#x20;       fecha\_vencimiento = p\_fecha\_vencimiento,

&#x20;       estado = p\_estado

&#x20;   WHERE IdCuota = p\_id;



### PAGOS

sp\_pago\_registar
INSERT INTO Pagos

&#x20;   (id\_cuota, id\_personal, fecha\_pago, monto,

&#x20;    medio\_pago, observacion)

&#x20;   VALUES

&#x20;   (p\_id\_cuota, p\_id\_personal, p\_fecha\_pago,

&#x20;    p\_monto, p\_medio\_pago, p\_observacion);



sp\_pagos\_cuota
SELECT \*

&#x20;   FROM Pagos

&#x20;   WHERE id\_cuota = p\_id\_cuota;



sp\_pago\_actualizar
UPDATE Pagos

&#x20;   SET monto = p\_monto,

&#x20;       medio\_pago = p\_medio\_pago,

&#x20;       observacion = p\_observacion

&#x20;   WHERE IdPago = p\_id;



### ALUMNO-RESPONSABLE

sp\_alumno\_asignar\_responsable
INSERT INTO `Alumno-Responsable`

&#x20;   (id\_alumno, id\_responsable, parentesco, esContactoPrincipal)

&#x20;   VALUES

&#x20;   (p\_id\_alumno, p\_id\_responsable,

&#x20;    p\_parentesco, p\_esContactoPrincipal);



sp\_alumno\_desasignar\_responsable
DELETE FROM `Alumno-Responsable`

&#x20;   WHERE IdAlumnoResponsable = p\_id;



sp\_alumno\_responsables
SELECT r.\*, p.nombre, p.apellido, ar.parentesco,

&#x20;          ar.esContactoPrincipal

&#x20;   FROM `Alumno-Responsable` ar

&#x20;   INNER JOIN Responsables r

&#x20;       ON ar.id\_responsable = r.IdResponsable

&#x20;   INNER JOIN Personas p

&#x20;       ON r.id\_persona = p.IdPersona

&#x20;   WHERE ar.id\_alumno = p\_id\_alumno;





### CARGOS

sp\_cargo\_listado
SELECT \*

&#x20;   FROM Cargos

&#x20;   WHERE p\_id IS NULL OR IdCargo = p\_id;



sp\_cargo\_insertar
INSERT INTO Cargos(nombre, descripcion)

&#x20;   VALUES (p\_nombre, p\_descripcion);



sp\_cargo\_actualizar
UPDATE Cargos

&#x20;   SET nombre = p\_nombre,

&#x20;       descripcion = p\_descripcion

&#x20;   WHERE IdCargo = p\_id;





### USUARIOS

sp\_usuario\_crear
INSERT INTO Usuarios

&#x20;   (id\_persona, usuario, password\_hash, activo)

&#x20;   VALUES

&#x20;   (p\_id\_persona, p\_usuario, p\_password\_hash, p\_activo);



sp\_usuario\_consultar
SELECT \*

&#x20;   FROM Usuarios

&#x20;   WHERE p\_id IS NULL OR IdUsuario = p\_id;



sp\_usuario\_actualizar
UPDATE Usuarios

&#x20;   SET usuario = p\_usuario,

&#x20;       password\_hash = p\_password\_hash,

&#x20;       activo = p\_activo

&#x20;   WHERE IdUsuario = p\_id;



sp\_usuario\_login
SELECT \*

&#x20;   FROM Usuarios

&#x20;   WHERE usuario = p\_usuario

&#x20;     AND activo = TRUE;



### USUARIO-ROL

sp\_usuario\_asignar\_rol
INSERT INTO `Usuario-Rol`

&#x20;   (IdUsuario, IdRol)

&#x20;   VALUES (p\_id\_usuario, p\_id\_rol);



sp\_usuario\_quitar\_rol
DELETE FROM `Usuario-Rol`

&#x20;   WHERE IdUsuario = p\_id\_usuario

&#x20;     AND IdRol = p\_id\_rol;



sp\_usuario\_roles

SELECT r.\*

&#x20;   FROM `Usuario-Rol` ur

&#x20;   INNER JOIN Roles r ON ur.IdRol = r.IdRol

&#x20;   WHERE ur.IdUsuario = p\_id\_usuario;





### AULAS

sp\_aula\_insertar
INSERT INTO Aulas

&#x20;   (nombre, capacidad, descripcion, activo)

&#x20;   VALUES

&#x20;   (p\_nombre, p\_capacidad, p\_descripcion, p\_activo);



sp\_aula\_consultar
SELECT \*

&#x20;   FROM Aulas

&#x20;   WHERE p\_id IS NULL OR IdAula = p\_id;



sp\_aula\_actualizar
UPDATE Aulas

&#x20;   SET nombre = p\_nombre,

&#x20;       capacidad = p\_capacidad,

&#x20;       descripcion = p\_descripcion,

&#x20;       activo = p\_activo

&#x20;   WHERE IdAula = p\_id;









&#x20;

