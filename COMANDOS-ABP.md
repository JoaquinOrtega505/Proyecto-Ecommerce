# 🛠️ Comandos Útiles ABP Framework

## Instalación ABP CLI

```bash
dotnet tool install -g Volo.Abp.Cli
dotnet tool update -g Volo.Abp.Cli
```

## Crear Proyecto Completo desde Cero

```bash
abp new Ecommerce -t app -u angular -d ef -dbms PostgreSQL --mobile none --pwa
```

Parámetros:
- `-t app`: Template de aplicación
- `-u angular`: UI con Angular
- `-d ef`: Entity Framework Core
- `-dbms PostgreSQL`: Base de datos PostgreSQL
- `--mobile none`: Sin app móvil
- `--pwa`: Progressive Web App

## Comandos de Desarrollo

### Backend

```bash
cd aspnet-core/src/Ecommerce.HttpApi.Host

# Restaurar paquetes NuGet
dotnet restore

# Crear migración
dotnet ef migrations add InitialCreate

# Aplicar migraciones
dotnet ef database update

# Ejecutar aplicación
dotnet run

# Watch mode (auto-reload)
dotnet watch run
```

### Frontend

```bash
cd angular

# Instalar dependencias
npm install

# Ejecutar en desarrollo
npm start

# Build para producción
npm run build:prod

# Generar proxy de API
abp generate-proxy -t ng
```

## Generar Entidades CRUD

```bash
# Desde la raíz del proyecto
abp generate crud Producto --base-class FullAuditedAggregateRoot
```

Esto generará automáticamente:
- Entidad en Domain
- Repository en EntityFrameworkCore
- AppService en Application
- DTOs en Application.Contracts
- Controller en HttpApi
- Componentes en Angular

## Migraciones

```bash
# Agregar migración
cd aspnet-core/src/Ecommerce.EntityFrameworkCore
dotnet ef migrations add NombreMigracion

# Actualizar base de datos
dotnet ef database update

# Revertir última migración
dotnet ef migrations remove

# Ver historial
dotnet ef migrations list
```

## Módulos ABP

### Agregar módulo existente

```bash
abp add-module Volo.Payment
abp add-module Volo.FileManagement
abp add-module Volo.Blogging
```

### Actualizar módulos

```bash
abp update
```

## Permisos

Los permisos se definen en:
`Ecommerce.Application.Contracts/Permissions/EcommercePermissions.cs`

```csharp
public static class EcommercePermissions
{
    public const string GroupName = "Ecommerce";

    public static class Productos
    {
        public const string Default = GroupName + ".Productos";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
```

## Localización

Archivos de idioma en:
`Ecommerce.Domain.Shared/Localization/Ecommerce/`

- `es.json` - Español
- `en.json` - Inglés

## Seed Data

Crear datos iniciales en:
`Ecommerce.Domain/Data/EcommerceDataSeeder.cs`

## Testing

```bash
cd aspnet-core/test/Ecommerce.Application.Tests
dotnet test
```

## Docker

```bash
# Build y ejecutar
docker-compose up --build

# Solo ejecutar
docker-compose up

# Detener
docker-compose down

# Ver logs
docker-compose logs -f backend
docker-compose logs -f frontend

# Reiniciar servicio
docker-compose restart backend
```

## Publicación

### Backend

```bash
cd aspnet-core/src/Ecommerce.HttpApi.Host
dotnet publish -c Release
```

### Frontend

```bash
cd angular
npm run build:prod
```

Los archivos estarán en `dist/ecommerce`

## Swagger

Acceder a la documentación de API:
- Desarrollo: http://localhost:44300/swagger
- Producción: https://tu-dominio.com/swagger

## Troubleshooting

### Error de conexión a base de datos

Verificar cadena de conexión en `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "Default": "Host=localhost;Port=5432;Database=EcommerceDb;Username=postgres;Password=postgres"
  }
}
```

### Error de CORS

Agregar en `appsettings.json`:

```json
{
  "App": {
    "CorsOrigins": "http://localhost:4200,https://tu-dominio.com"
  }
}
```

### Regenerar proxy de Angular

```bash
cd angular
abp generate-proxy -t ng
```

## Recursos

- Documentación ABP: https://docs.abp.io
- Ejemplos: https://github.com/abpframework/abp-samples
- Community: https://community.abp.io
- Blog: https://blog.abp.io
