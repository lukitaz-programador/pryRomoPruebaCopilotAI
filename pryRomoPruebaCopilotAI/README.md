# MedManage C# - Sistema de Gestión Médica

## ?? Descripción

Sistema de gestión médica desarrollado en **C# con Windows Forms** para clínicas y consultorios. Permite administrar especialidades, médicos y sus asignaciones de forma intuitiva y moderna.

## ? Características Principales

? **Gestión de Especialidades**
- Crear y mantener catálogo de especialidades médicas
- Validaciones automáticas

? **Registro de Médicos**
- Información de médicos (matrícula, nombre)
- Asignación de múltiples especialidades por médico

? **Consultas Inteligentes**
- Visualización completa de médicos y especialidades
- Búsqueda por matrícula o nombre
- Lista concatenada de especialidades por médico

? **Mantenimiento de Datos**
- Edición de especialidades asignadas
- Eliminación segura de registros con confirmación

? **Interfaz Moderna**
- Diseño oscuro profesional
- Navegación tipo MDI
- Botones contextuales con colores descriptivos

## ?? Inicio Rápido

### 1. Requisitos Previos
- Visual Studio 2015 o superior
- .NET Framework 4.7.2
- Windows 7 o posterior

### 2. Clonar/Descargar
```bash
git clone <url-del-repositorio>
cd pryRomoPruebaCopilotAI
```

### 3. Compilar
```
Visual Studio ? Build ? Build Solution
O presionar: Ctrl + Shift + B
```

### 4. Ejecutar
```
Visual Studio ? Debug ? Start Debugging
O presionar: F5
```

## ?? Estructura del Proyecto

```
pryRomoPruebaCopilotAI/
??? AccesoDatos.cs                 # Clase para conexión BD
??? FrmPrincipal.cs                # Formulario principal (MDI)
??? FrmPrincipal.Designer.cs
??? FrmEspecialidades.cs           # Gestión de especialidades
??? FrmEspecialidades.Designer.cs
??? FrmMedicos.cs                  # Registro de médicos
??? FrmMedicos.Designer.cs
??? FrmConsultas.cs                # Consultas de médicos
??? FrmConsultas.Designer.cs
??? FrmMantenimiento.cs            # Edición/eliminación
??? FrmMantenimiento.Designer.cs
??? Program.cs                     # Punto de entrada
??? Base de Datos/
?   ??? Consultorio.mdb            # Base de datos (se crea automáticamente)
??? DOCUMENTACION.md               # Documentación detallada
```

## ??? Base de Datos

**Ubicación:** `Base de Datos\Consultorio.mdb`

### Tablas:
- **Especialidades**: Catálogo de especialidades médicas
- **Medicos**: Registro de médicos
- **Medico_Especialidad**: Relación muchos a muchos

**La BD se crea automáticamente** en la primera ejecución.

## ?? Uso de la Aplicación

### Paso 1: Crear Especialidades
1. Click en **Registros ? Especialidades**
2. Ingrese nombre de especialidad (ej: "Cardiología")
3. Click **+ Agregar**

### Paso 2: Registrar Médicos
1. Click en **Registros ? Médicos**
2. Ingrese:
   - Nº Matrícula (ej: "123456")
   - Nombre Completo (ej: "Dra. Elena Pérez")
3. Seleccione especialidades (puede elegir varias)
4. Click **Guardar Registro**

### Paso 3: Consultar Médicos
1. Click en **Consultas ? Consulta a Edición**
2. Vea lista completa de médicos
3. Use **Buscar** para filtrar por matrícula o nombre

### Paso 4: Editar o Eliminar
1. Click en **Consultas ? Eliminación y Modificación**
2. Ingrese matrícula y click **Buscar**
3. Opción:
   - **Actualizar Especialidades**: Modifique selección y guarde
   - **Eliminar Médica**: Confirme eliminación

## ?? Paleta de Colores

| Elemento | Color |
|----------|-------|
| Fondo | RGB(25, 32, 71) - Azul oscuro |
| Texto | Blanco |
| Guardar/Agregar | RGB(0, 200, 100) - Verde |
| Buscar | RGB(0, 100, 200) - Azul |
| Eliminar | RGB(200, 0, 0) - Rojo |
| Limpiar | RGB(100, 100, 100) - Gris |

## ?? Validaciones Implementadas

? No permite especialidades vacías
? Matrícula requerida para médicos
? Nombre completo requerido
? Mínimo una especialidad por médico
? Confirmación antes de eliminar
? Búsquedas con LIKE para flexibilidad

## ?? Notas Importantes

- **Primera ejecución**: La aplicación creará automáticamente la carpeta `Base de Datos` y el archivo `Consultorio.mdb`
- **Permisos**: Asegúrese de tener permisos de lectura/escritura en la carpeta del ejecutable
- **Backup**: Realice copias de seguridad de `Consultorio.mdb` regularmente
- **Compatibilidad**: Requiere `Microsoft Jet OLEDB 4.0` (incluido en Windows)

## ??? Desarrollo

### Tecnologías Utilizadas
- **Lenguaje**: C#
- **Framework**: .NET Framework 4.7.2
- **UI**: Windows Forms
- **BD**: Microsoft Access (.mdb)
- **Proveedor BD**: System.Data.OleDb

### Clase AccesoDatos (Métodos principales)
```csharp
EjecutarConsulta(string query)          // SELECT
EjecutarComando(string query)           // INSERT, UPDATE, DELETE
VerificarConexion()                     // Prueba conexión
CrearBaseDatos()                        // Inicializa BD
```

## ?? Soporte

Para reportar problemas o sugerencias, contacte al desarrollador.

## ?? Licencia

Este proyecto es de uso interno para educación y capacitación.

---

**Versión**: 1.0  
**Última actualización**: 2024  
**Autor**: Sistema de Gestión Médica - Educativo
