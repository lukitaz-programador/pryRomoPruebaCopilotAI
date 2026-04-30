-- QUERYS DE REFERENCIA - Sistema de Gestión Médica
-- Archivo con ejemplos de consultas SQL utilizadas en la aplicación

-- ============================================
-- 1. ESPECIALIDADES
-- ============================================

-- Crear tabla (Ejecutado automáticamente)
-- CREATE TABLE Especialidades (
--    ID_Especialidad COUNTER PRIMARY KEY, 
--    Nombre_Especialidad TEXT NOT NULL UNIQUE
-- )

-- Obtener todas las especialidades
SELECT ID_Especialidad, Nombre_Especialidad FROM Especialidades ORDER BY Nombre_Especialidad

-- Agregar nueva especialidad
INSERT INTO Especialidades (Nombre_Especialidad) VALUES ('Cardiología')

-- Actualizar especialidad
UPDATE Especialidades SET Nombre_Especialidad = 'Cardiología Infantil' WHERE ID_Especialidad = 1

-- Eliminar especialidad
DELETE FROM Especialidades WHERE ID_Especialidad = 1


-- ============================================
-- 2. MÉDICOS
-- ============================================

-- Crear tabla (Ejecutado automáticamente)
-- CREATE TABLE Medicos (
--    Matricula TEXT PRIMARY KEY, 
--    Nombre_Completo TEXT NOT NULL
-- )

-- Obtener todos los médicos
SELECT Matricula, Nombre_Completo FROM Medicos ORDER BY Nombre_Completo

-- Agregar nuevo médico
INSERT INTO Medicos (Matricula, Nombre_Completo) VALUES ('123456', 'Dra. Elena Pérez')

-- Buscar médico por matrícula
SELECT Nombre_Completo FROM Medicos WHERE Matricula = '123456'

-- Buscar médicos por nombre
SELECT Matricula, Nombre_Completo FROM Medicos WHERE Nombre_Completo LIKE '%Elena%'

-- Actualizar médico
UPDATE Medicos SET Nombre_Completo = 'Dra. Elena Patricia Pérez' WHERE Matricula = '123456'

-- Eliminar médico
DELETE FROM Medicos WHERE Matricula = '123456'


-- ============================================
-- 3. RELACIÓN MEDICO - ESPECIALIDAD
-- ============================================

-- Crear tabla (Ejecutado automáticamente)
-- CREATE TABLE Medico_Especialidad (
--    Matricula TEXT, 
--    ID_Especialidad COUNTER,
--    PRIMARY KEY (Matricula, ID_Especialidad),
--    FOREIGN KEY (Matricula) REFERENCES Medicos(Matricula),
--    FOREIGN KEY (ID_Especialidad) REFERENCES Especialidades(ID_Especialidad)
-- )

-- Asignar especialidad a médico
INSERT INTO Medico_Especialidad (Matricula, ID_Especialidad) VALUES ('123456', 1)

-- Obtener especialidades de un médico
SELECT e.Nombre_Especialidad FROM Medico_Especialidad me 
JOIN Especialidades e ON me.ID_Especialidad = e.ID_Especialidad 
WHERE me.Matricula = '123456'

-- Obtener médicos por especialidad
SELECT m.Matricula, m.Nombre_Completo FROM Medico_Especialidad me
JOIN Medicos m ON me.Matricula = m.Matricula
WHERE me.ID_Especialidad = 1

-- Eliminar todas las especialidades de un médico
DELETE FROM Medico_Especialidad WHERE Matricula = '123456'

-- Eliminar una especialidad específica de un médico
DELETE FROM Medico_Especialidad WHERE Matricula = '123456' AND ID_Especialidad = 1


-- ============================================
-- 4. CONSULTAS COMPLEJAS (Para reportes)
-- ============================================

-- Médicos con todas sus especialidades (manual en la app)
SELECT m.Matricula, m.Nombre_Completo
FROM Medicos m
LEFT JOIN Medico_Especialidad me ON m.Matricula = me.Matricula
ORDER BY m.Nombre_Completo

-- Contar especialidades por médico
SELECT m.Matricula, m.Nombre_Completo, COUNT(me.ID_Especialidad) as Total_Especialidades
FROM Medicos m
LEFT JOIN Medico_Especialidad me ON m.Matricula = me.Matricula
GROUP BY m.Matricula, m.Nombre_Completo

-- Especialidades sin médicos asignados
SELECT e.ID_Especialidad, e.Nombre_Especialidad
FROM Especialidades e
LEFT JOIN Medico_Especialidad me ON e.ID_Especialidad = me.ID_Especialidad
WHERE me.ID_Especialidad IS NULL

-- Especialidades más solicitadas
SELECT e.ID_Especialidad, e.Nombre_Especialidad, COUNT(me.Matricula) as Total_Medicos
FROM Especialidades e
LEFT JOIN Medico_Especialidad me ON e.ID_Especialidad = me.ID_Especialidad
GROUP BY e.ID_Especialidad, e.Nombre_Especialidad
ORDER BY COUNT(me.Matricula) DESC

-- Médicos con más de 2 especialidades
SELECT m.Matricula, m.Nombre_Completo, COUNT(me.ID_Especialidad) as Total_Especialidades
FROM Medicos m
JOIN Medico_Especialidad me ON m.Matricula = me.Matricula
GROUP BY m.Matricula, m.Nombre_Completo
HAVING COUNT(me.ID_Especialidad) > 2

-- Listar médicos sin especialidades asignadas
SELECT m.Matricula, m.Nombre_Completo
FROM Medicos m
WHERE m.Matricula NOT IN (
    SELECT DISTINCT Matricula FROM Medico_Especialidad
)


-- ============================================
-- 5. MANTENIMIENTO DE DATOS
-- ============================================

-- Limpiar especialidades sin médicos (y no usadas)
DELETE FROM Especialidades 
WHERE ID_Especialidad NOT IN (
    SELECT DISTINCT ID_Especialidad FROM Medico_Especialidad
)

-- Resetear auto-incremento (Crear nueva tabla con datos)
-- En Access: Requiere crear tabla nueva y copiar datos

-- Ver estructura de tablas (En Access Query Design)
-- SELECT * FROM Medicos
-- SELECT * FROM Especialidades
-- SELECT * FROM Medico_Especialidad

-- Estadísticas generales
SELECT 
    (SELECT COUNT(*) FROM Medicos) as Total_Medicos,
    (SELECT COUNT(*) FROM Especialidades) as Total_Especialidades,
    (SELECT COUNT(*) FROM Medico_Especialidad) as Total_Asignaciones

-- ============================================
-- NOTAS IMPORTANTES
-- ============================================
-- - Access usa TEXT en lugar de VARCHAR
-- - Access usa COUNTER en lugar de IDENTITY/AUTO_INCREMENT
-- - Los FOREIGN KEY deben tener ON DELETE CASCADE
-- - Las búsquedas usan LIKE con % para comodín
-- - GROUP_CONCAT NO existe en Access (usar en aplicación)
-- - En Access, los comentarios usan -- o /* */
