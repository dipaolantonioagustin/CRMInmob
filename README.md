# CRMInmob

Base inicial para un **CRM inmobiliario web** orientado a administración y ventas.

## Contenido del repositorio
- `backend/CRMInmob.Api`: API en C# (ASP.NET Core) con Identity + EF Core + SQL Server.
- `frontend/index.html`: maqueta inicial de dashboard diario usando Bootstrap.
- `database/schema.sql`: script SQL base para tablas principales de negocio.
- `docs/arquitectura-crm.md`: definición funcional y alcance MVP.

## Alcance funcional inicial
- Tareas con prioridad y estado.
- Asignación por usuario responsable.
- Vista diaria (`my-day`) ordenada por urgencia.
- Relación de tareas con contacto y carpeta inmobiliaria.

## Endpoints ejemplo
- `GET /api/tasks/my-day/{userId}`
- `POST /api/tasks`
- `GET /api/tasks/{id}`
- `PATCH /api/tasks/{id}/status`

## Requisitos para compilar en tu IDE
1. Instalar **.NET 8 SDK**.
2. Abrir la carpeta `backend/CRMInmob.Api` en Visual Studio / Rider / VS Code.
3. Restaurar paquetes NuGet con `dotnet restore`.

> No necesitás instalar los paquetes uno por uno: el archivo `.csproj` ya declara todas las dependencias.

## NuGet que se restauran automáticamente
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.Design`
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Swashbuckle.AspNetCore`

## ¿Hace falta tener SQL Server corriendo?
Sí, para **ejecutar la API con acceso real a datos** y para aplicar migraciones, necesitás una instancia de SQL Server disponible.

### Qué ya está resuelto y qué no
- ✅ Ya está resuelto en código: la app toma la conexión desde `ConnectionStrings:DefaultConnection` en `appsettings.json`.
- ❌ No está resuelto automáticamente: levantar/instalar SQL Server y configurar la cadena de conexión de tu ambiente.

## Configuración de conexión
La conexión actual en `appsettings.json` es:

```json
"Server=localhost;Database=CRMInmob;Trusted_Connection=True;TrustServerCertificate=True;"
```

Si usás SQL Server con usuario/clave, podés cambiarla por algo así:

```json
"Server=localhost,1433;Database=CRMInmob;User Id=sa;Password=TuPassword;TrustServerCertificate=True;"
```

## Crear base de datos
Tenés dos opciones:

1. **Con EF Core Migrations** (recomendado):
   - `dotnet tool install --global dotnet-ef`
   - `dotnet ef migrations add InitialCreate`
   - `dotnet ef database update`

2. **Con script SQL manual**:
   - Ejecutar `database/schema.sql` en tu SQL Server.

## Nota de ejecución en este entorno
Este entorno de trabajo no incluye `dotnet` instalado, por lo que la estructura quedó preparada para compilarse en tu máquina de desarrollo con .NET 8 SDK.
