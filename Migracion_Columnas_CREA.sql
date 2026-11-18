-- Migración segura de nombres mal escritos al modelo actual.
-- Ejecutar sobre db_crea antes de importar UltAct_DB_Procedimientos_Corregido.sql.
USE `db_crea`;

SET @old_exists = (SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'alumno-responsable' AND COLUMN_NAME = 'IdAlumnoRespomsable');
SET @new_exists = (SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'alumno-responsable' AND COLUMN_NAME = 'IdAlumnoResponsable');
SET @ddl = IF(@old_exists > 0 AND @new_exists = 0, 'ALTER TABLE `alumno-responsable` RENAME COLUMN `IdAlumnoRespomsable` TO `IdAlumnoResponsable`', 'SELECT 1');
PREPARE mig_stmt FROM @ddl; EXECUTE mig_stmt; DEALLOCATE PREPARE mig_stmt;

SET @old_exists = (SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'alumno-responsable' AND COLUMN_NAME = 'patentesco');
SET @new_exists = (SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'alumno-responsable' AND COLUMN_NAME = 'parentesco');
SET @ddl = IF(@old_exists > 0 AND @new_exists = 0, 'ALTER TABLE `alumno-responsable` RENAME COLUMN `patentesco` TO `parentesco`', 'SELECT 1');
PREPARE mig_stmt FROM @ddl; EXECUTE mig_stmt; DEALLOCATE PREPARE mig_stmt;

SET @old_exists = (SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'nivel-educativo' AND COLUMN_NAME = 'IdNiverEducativo');
SET @new_exists = (SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'nivel-educativo' AND COLUMN_NAME = 'IdNivelEducativo');
SET @ddl = IF(@old_exists > 0 AND @new_exists = 0, 'ALTER TABLE `nivel-educativo` RENAME COLUMN `IdNiverEducativo` TO `IdNivelEducativo`', 'SELECT 1');
PREPARE mig_stmt FROM @ddl; EXECUTE mig_stmt; DEALLOCATE PREPARE mig_stmt;

SET @old_exists = (SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'trayectoria-educativa' AND COLUMN_NAME = 'IdTrayctoriaEdu');
SET @new_exists = (SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'trayectoria-educativa' AND COLUMN_NAME = 'IdTrayectoriaEdu');
SET @ddl = IF(@old_exists > 0 AND @new_exists = 0, 'ALTER TABLE `trayectoria-educativa` RENAME COLUMN `IdTrayctoriaEdu` TO `IdTrayectoriaEdu`', 'SELECT 1');
PREPARE mig_stmt FROM @ddl; EXECUTE mig_stmt; DEALLOCATE PREPARE mig_stmt;

SET @old_exists = (SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'trayectoria-educativa' AND COLUMN_NAME = 'id_cuso');
SET @new_exists = (SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'trayectoria-educativa' AND COLUMN_NAME = 'id_curso');
SET @ddl = IF(@old_exists > 0 AND @new_exists = 0, 'ALTER TABLE `trayectoria-educativa` RENAME COLUMN `id_cuso` TO `id_curso`', 'SELECT 1');
PREPARE mig_stmt FROM @ddl; EXECUTE mig_stmt; DEALLOCATE PREPARE mig_stmt;

SET @old_exists = (SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'trayectoria-educativa' AND COLUMN_NAME = 'ciclo_luctivo');
SET @new_exists = (SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'trayectoria-educativa' AND COLUMN_NAME = 'ciclo_lectivo');
SET @ddl = IF(@old_exists > 0 AND @new_exists = 0, 'ALTER TABLE `trayectoria-educativa` RENAME COLUMN `ciclo_luctivo` TO `ciclo_lectivo`', 'SELECT 1');
PREPARE mig_stmt FROM @ddl; EXECUTE mig_stmt; DEALLOCATE PREPARE mig_stmt;