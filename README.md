# Gestión de Funcionarios - Interfaz Windows Forms

Aplicación de escritorio desarrollada en C# con Windows Forms para la gestión de funcionarios (CRUD).

## Características

### Interfaz Visual Completa
- **Ventana principal** con título "Gestión de Funcionarios"
- **Diseño responsive** dentro de las capacidades de WinForms
- **Apariencia moderna y organizada** con colores y tipografía profesional

### Componentes Principales

#### Sección de Formulario (GroupBox "Datos del Funcionario")
- **Campos de entrada:**
  - Identificación (TextBox)
  - Nombre (TextBox)
  - Apellido (TextBox)
  - Correo electrónico (TextBox)
  - Teléfono (TextBox)
  - Cargo (ComboBox) - Opciones: Administrador, Analista, Coordinador, Gerente, Supervisor, Técnico
  - Dependencia (ComboBox) - Opciones: Recursos Humanos, Finanzas, Tecnología, Operaciones, Marketing, Ventas

- **Botones de acción con colores diferenciados:**
  - Guardar (Verde)
  - Actualizar (Azul)
  - Eliminar (Rojo)
  - Limpiar (Gris)

#### Sección de Listado (GroupBox "Lista de Funcionarios")
- **DataGridView** con columnas:
  - ID
  - Identificación
  - Nombre completo
  - Correo
  - Teléfono
  - Cargo
  - Dependencia

### Funcionalidades Visuales Implementadas

1. **Carga de datos al hacer clic** en una fila del DataGridView
2. **Validaciones visuales** con mensajes informativos
3. **Datos de ejemplo** precargados para demostración
4. **Feedback visual** a través de etiquetas de estado

## Requisitos

- .NET 6.0 o superior
- Windows 10 o superior
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
