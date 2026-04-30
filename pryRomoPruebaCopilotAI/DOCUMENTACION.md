# Sistema de Gestión Médica - Documentación

## Descripción General
Sistema de gestión médica desarrollado en C# con Windows Forms (.NET Framework 4.7.2) que permite gestionar:
- Especialidades médicas
- Registro de médicos
- Asignación de especialidades a médicos (relación muchos a muchos)
- Consultas y reportes
- Mantenimiento (edición y eliminación de registros)

## Estructura de la Base de Datos

### Tablas
1. **Especialidades**
   - ID_Especialidad (COUNTER - Clave Primaria)
   - Nombre_Especialidad (TEXT - Única)

2. **Medicos**
   - Matricula (TEXT - Clave Primaria)
   - Nombre_Completo (TEXT)

3. **Medico_Especialidad** (Tabla Intermedia)
   - Matricula (TEXT - Clave Foránea)
   - ID_Especialidad (COUNTER - Clave Foránea)
   - Clave Primaria Compuesta: (Matricula, ID_Especialidad)

## Ubicación de la Base de Datos
`Application.StartupPath\Base de Datos\Consultorio.mdb`

La base de datos se crea automáticamente la primera vez que se ejecuta la aplicación.

## Formularios

### 1. Formulario Principal (FrmPrincipal)
- Menú de navegación con opciones:
  - **Archivo**: Opción para salir
  - **Registros**: Acceso a Especialidades y Médicos
  - **Consultas**: Acceso a Consultas y Mantenimiento
- Indicador de estado de conexión en la barra de estado
- Contenedor MDI para todos los formularios

### 2. Registro de Especialidades (FrmEspecialidades)
**Funcionalidad:**
- Visualizar lista de especialidades existentes
- Agregar nuevas especialidades
- Validación: El nombre de especialidad no puede estar vacío

**Campos:**
- ID de Especialidad (Automático)
- Nombre de Especialidad (Input)

**Botones:**
- + Agregar: Guarda la nueva especialidad
- Limpiar: Limpia el campo de entrada

### 3. Registro de Médicos (FrmMedicos)
**Funcionalidad:**
- Registrar nuevos médicos
- Asignar múltiples especialidades a cada médico
- Las especialidades se cargan automáticamente desde la BD

**Campos:**
- Nº Matrícula (Clave Primaria)
- Nombre Completo
- Asignación de Especialidades (CheckedListBox)

**Validaciones:**
- Matrícula requerida
- Nombre completo requerido
- Mínimo una especialidad debe ser seleccionada

**Botones:**
- Guardar Registro: Inserta médico y asignaciones
- Limpiar: Reinicia el formulario

### 4. Consultas de Personal Médico (FrmConsultas)
**Funcionalidad:**
- Visualizar lista completa de médicos
- Buscar médicos por matrícula o nombre
- Mostrar todas las especialidades asignadas (concatenadas)

**Campos:**
- Buscador (Por matrícula o nombre)
- DataGridView con:
  - Matrícula
  - Nombre Médico
  - Especialidades Asignadas

**Botones:**
- Buscar: Ejecuta búsqueda (También funciona con ENTER)

### 5. Eliminación y Modificación de Médicos (FrmMantenimiento)
**Funcionalidad:**
- Buscar médico por matrícula
- Modificar especialidades asignadas
- Eliminar médico completo (incluyendo especialidades)

**Campos:**
- Buscador por matrícula
- DataGridView con lista completa
- Nombre del médico seleccionado
- CheckedListBox para actualizar especialidades

**Botones:**
- Buscar: Localiza médico y carga sus especialidades
- Actualizar Especialidades: Modifica asignaciones
- Eliminar Médica: Elimina médico y sus asignaciones (Confirmación requerida)

## Características Visuales

**Diseño:**
- Tema oscuro (Color de fondo: RGB(25, 32, 71))
- Botones con colores distintivos:
  - Verde para guardar/agregar: RGB(0, 200, 100)
  - Azul para buscar: RGB(0, 100, 200)
  - Rojo para eliminar: RGB(200, 0, 0)
  - Gris para limpiar: RGB(100, 100, 100)
- DataGridView con fondo oscuro RGB(40, 50, 90)
- Texto blanco para mejor contraste

## Clase AccesoDatos

**Métodos disponibles:**
- `EjecutarConsulta(string query)`: Ejecuta SELECT, retorna DataTable
- `EjecutarComando(string query)`: Ejecuta INSERT, UPDATE, DELETE
- `VerificarConexion()`: Valida conexión a BD
- `CrearBaseDatos()`: Inicializa tablas si no existen

## Flujo de Uso Recomendado

1. **Iniciar con Especialidades**
   - Ir a Registros ? Especialidades
   - Agregar todas las especialidades necesarias

2. **Registrar Médicos**
   - Ir a Registros ? Médicos
   - Ingresar matrícula, nombre y seleccionar especialidades
   - Guardar registro

3. **Consultar Médicos**
   - Ir a Consultas ? Consulta a Edición
   - Visualizar lista completa
   - Usar buscador si es necesario

4. **Mantener Datos**
   - Ir a Consultas ? Eliminación y Modificación
   - Buscar médico por matrícula
   - Actualizar especialidades o eliminar registro

## Requisitos del Sistema
- .NET Framework 4.7.2 o superior
- Windows Forms
- Microsoft Jet OLEDB 4.0 (Para acceso a .mdb)
- Permisos de lectura/escritura en la carpeta de la aplicación

## Notas Importantes
- La base de datos Access (*.mdb) debe tener permisos de lectura/escritura
- Las consultas SQL están optimizadas para Microsoft Jet OLEDB
- Las búsquedas usan LIKE para flexibilidad
- Las eliminaciones requieren confirmación del usuario
- Los IDs de especialidades son autocrement
