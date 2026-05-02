# Gestión de Funcionarios

## Descripción

Aplicación de escritorio desarrollada en C# con Windows Forms para la gestión completa de funcionarios. Implementa operaciones CRUD (Crear, Leer, Actualizar, Eliminar) conectada a una base de datos SQLite utilizando Entity Framework Core. La aplicación permite administrar información de empleados con una interfaz intuitiva y validaciones de datos.

## Tecnologías Utilizadas

### Framework y Lenguaje
- **.NET 8.0**: Framework de desarrollo actualizado de .NET 6.0 para soporte a largo plazo y mejores prestaciones.
- **C#**: Lenguaje de programación con referencias nullables habilitadas para mayor seguridad y prevención de errores en tiempo de ejecución.

### Interfaz de Usuario
- **Windows Forms**: Framework para crear interfaces de usuario de escritorio en Windows, con componentes visuales como formularios, botones, cajas de texto y tablas de datos.

### Base de Datos y ORM
- **Entity Framework Core 8.0**: Object-Relational Mapping (ORM) moderno para .NET que facilita el acceso a datos.
- **SQLite**: Base de datos embebida ligera y sin servidor, ideal para aplicaciones de escritorio.

### Paquetes NuGet
- `Microsoft.EntityFrameworkCore.Sqlite`: Proveedor de SQLite para Entity Framework Core.
- `Microsoft.EntityFrameworkCore.Tools`: Herramientas de línea de comandos para migraciones y operaciones de base de datos.

## Requisitos Previos

- **Sistema Operativo**: Windows 10 o superior.
- **SDK de .NET**: .NET 8.0 SDK instalado. Puedes descargarlo desde [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).
- **Espacio en Disco**: Mínimo 100 MB para el SDK y dependencias.

## Instalación y Ejecución

### Paso 1: Obtener el Proyecto

Clona el repositorio desde GitHub o descarga el archivo ZIP del proyecto y extrae su contenido en una carpeta local.

```bash
git clone https://github.com/KamiloVelasquez/DESARROLLO-DE-SOFTWARE-SEGURO.git
cd DESARROLLO-DE-SOFTWARE-SEGURO
```

### Paso 2: Restaurar las Dependencias

Abre una terminal de comandos (PowerShell o Command Prompt) en el directorio raíz del proyecto y ejecuta el siguiente comando para descargar e instalar todos los paquetes NuGet necesarios:

```bash
dotnet restore
```

Este comando lee el archivo `GestionFuncionarios.csproj` y instala automáticamente:
- Entity Framework Core
- Proveedor de SQLite
- Otras dependencias del proyecto

### Paso 3: Compilar el Proyecto

Una vez restauradas las dependencias, compila el código fuente para generar los archivos ejecutables:

```bash
dotnet build
```

La compilación verifica la sintaxis, resuelve referencias y genera el ensamblado en la carpeta `bin/Debug/net8.0-windows/`.

### Paso 4: Ejecutar la Aplicación

Para iniciar la aplicación, ejecuta:

```bash
dotnet run
```

La aplicación se abrirá en una nueva ventana de Windows Forms. La base de datos SQLite (`empresa_funcionarios.db`) se crea automáticamente en el directorio del proyecto si no existe previamente.

## Funcionalidades Principales

### Gestión de Funcionarios (CRUD)
- **Crear**: Agregar nuevos funcionarios completando el formulario y presionando "Guardar".
- **Leer**: Visualizar todos los funcionarios en la tabla de datos, que se carga automáticamente al iniciar.
- **Actualizar**: Seleccionar un funcionario de la tabla, modificar sus datos en el formulario y presionar "Actualizar".
- **Eliminar**: Seleccionar un funcionario y presionar "Eliminar" para removerlo de la base de datos.

### Validaciones y Seguridad
- Campos requeridos con validación automática.
- Formatos correctos para identificación, correo electrónico y teléfono.
- Mensajes informativos para el usuario sobre operaciones exitosas o errores.
- Manejo de excepciones para prevenir cierres inesperados de la aplicación.

### Interfaz de Usuario
- Formulario principal con diseño organizado en secciones.
- Campos de entrada para: Identificación, Nombre, Apellido, Correo, Teléfono, Cargo y Dependencia.
- Tabla de datos para visualizar la lista de funcionarios.
- Botones coloreados para acciones: Verde (Guardar), Azul (Actualizar), Rojo (Eliminar), Gris (Limpiar).

## Estructura del Proyecto

```
DESARROLLO-DE-SOFTWARE-SEGURO/
├── GestionFuncionarios.csproj    # Archivo de configuración del proyecto
├── Program.cs                    # Punto de entrada de la aplicación
├── FrmPrincipal.cs               # Formulario principal con lógica de UI
├── FrmPrincipal.Designer.cs      # Código generado por el diseñador de formularios
├── Funcionario.cs                # Modelo de entidad para funcionarios
├── EmpresaFuncionariosContext.cs # Contexto de Entity Framework Core
├── app.manifest                  # Configuración del manifiesto de aplicación
└── README.md                     # Este archivo
```

## Solución de Problemas

### Error de SDK no encontrado
Asegúrate de tener instalado .NET 8.0 SDK. Verifica con:
```bash
dotnet --version
```

### Base de datos no se crea
La base de datos se crea automáticamente al ejecutar la aplicación. Si hay problemas de permisos, ejecuta como administrador.

### Warnings de compilación
Los warnings sobre referencias nullables están deshabilitados para compatibilidad con Windows Forms, pero no afectan la funcionalidad.

## Contribución

1. Haz un fork del repositorio.
2. Crea una rama para tu feature (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios y commits.
4. Envía un pull request describiendo los cambios realizados.

## Licencia

Este proyecto es de uso educativo y está disponible bajo la licencia MIT.
- Visual Studio 2022 o VS Code

## Ejecución

### Desde Visual Studio
1. Abrir el archivo `GestionFuncionarios.csproj`
2. Presionar F5 o clic en "Iniciar"

### Desde línea de comandos
```bash
dotnet run
```

### Compilación
```bash
dotnet build
```

## Estructura del Proyecto

```
GestionFuncionarios/
|-- GestionFuncionarios.csproj     # Archivo de proyecto
|-- Program.cs                     # Punto de entrada
|-- FrmPrincipal.cs               # Formulario principal con toda la lógica visual
|-- FrmPrincipal.Designer.cs      # Designer file (mínimo)
|-- app.manifest                  # Manifiesto de aplicación
|-- README.md                     # Documentación
```

## Notas Importantes

- **NO implementada lógica de base de datos** - Solo interfaz visual
- **NO implementada conexión a motor de base de datos**
- **NO implementado patrón DAO** - Interfaz lista para integración futura
- **Datos simulados** para demostración visual
- **Validaciones básicas** solo visuales (campos vacíos, formato de correo)

## Próximos Pasos para Integración

1. Implementar clases de modelo (Funcionario)
2. Crear capa de acceso a datos (DAO)
3. Configurar conexión a base de datos
4. Implementar lógica CRUD real
5. Agregar manejo de excepciones
6. Implementar logging y auditoría

## Diseño y Estilos

- **Tipografía:** Segoe UI (9F base, 10F para títulos)
- **Colores:** Esquema moderno con colores Material Design
- **Layout:** Organizado con GroupBox para mejor estructura visual
- **Espaciado:** Optimizado para buena usabilidad
