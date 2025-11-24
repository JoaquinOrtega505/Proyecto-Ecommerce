# 📁 Estructura Completa del Proyecto ABP

## Proyecto E-commerce con ABP.io

```
ecommerce-abp/
│
├── README.md                          # Documentación principal
├── COMANDOS-ABP.md                    # Comandos útiles
├── ESTRUCTURA-PROYECTO.md             # Este archivo
├── docker-compose.yml                 # Configuración Docker
│
├── aspnet-core/                       # Backend .NET
│   ├── Dockerfile
│   ├── Ecommerce.sln                  # Solución de Visual Studio
│   │
│   └── src/
│       ├── Ecommerce.Domain/          # Capa de dominio (entidades)
│       │   ├── Productos/
│       │   │   └── Producto.cs
│       │   ├── Categorias/
│       │   │   └── Categoria.cs
│       │   ├── Carritos/
│       │   │   └── Carrito.cs
│       │   └── Pedidos/
│       │       └── Pedido.cs
│       │
│       ├── Ecommerce.Domain.Shared/   # Constantes, enums compartidos
│       │   └── EcommerceConsts.cs
│       │
│       ├── Ecommerce.Application/     # Servicios de aplicación
│       │   └── Productos/
│       │       └── ProductoAppService.cs
│       │
│       ├── Ecommerce.Application.Contracts/ # DTOs e interfaces
│       │   └── Productos/
│       │       ├── ProductoDto.cs
│       │       └── IProductoAppService.cs
│       │
│       ├── Ecommerce.EntityFrameworkCore/  # Configuración EF Core
│       │   ├── EcommerceDbContext.cs
│       │   └── Migrations/
│       │
│       ├── Ecommerce.HttpApi/         # Controllers HTTP
│       │   └── Controllers/
│       │
│       └── Ecommerce.HttpApi.Host/    # Aplicación host
│           ├── Program.cs
│           ├── appsettings.json
│           └── Dockerfile
│
└── angular/                           # Frontend Angular
    ├── Dockerfile
    ├── nginx.conf
    ├── package.json
    ├── angular.json
    ├── tsconfig.json
    │
    └── src/
        ├── app/
        │   ├── productos/             # Módulo de productos
        │   │   ├── services/
        │   │   │   └── producto.service.ts
        │   │   ├── lista-productos.component.ts
        │   │   └── detalle-producto.component.ts
        │   │
        │   ├── categorias/            # Módulo de categorías
        │   ├── carrito/               # Módulo de carrito
        │   └── pedidos/               # Módulo de pedidos
        │
        └── environments/
            ├── environment.ts
            └── environment.prod.ts
```

## Capas del Proyecto ABP

### 1. Domain Layer (Ecommerce.Domain)
- **Entidades:** Producto, Categoria, Carrito, Pedido
- **Agregados:** Lógica de negocio
- **Repositorios:** Interfaces
- **Domain Services:** Lógica de dominio compleja

### 2. Application Layer (Ecommerce.Application)
- **App Services:** ProductoAppService, CarritoAppService
- **DTOs:** Objetos de transferencia de datos
- **AutoMapper:** Mapeo entidad-DTO

### 3. Infrastructure Layer (Ecommerce.EntityFrameworkCore)
- **DbContext:** Configuración de base de datos
- **Migrations:** Migraciones de EF Core
- **Repositorios:** Implementaciones

### 4. Presentation Layer
- **HttpApi:** Controllers Web API
- **HttpApi.Host:** Aplicación ASP.NET Core
- **Angular:** Frontend SPA

## Archivos Clave

### Backend

**Program.cs**
```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication<EcommerceHttpApiHostModule>();

var app = builder.Build();
app.InitializeApplication();
app.Run();
```

**EcommerceDbContext.cs**
```csharp
public class EcommerceDbContext : AbpDbContext<EcommerceDbContext>
{
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Carrito> Carritos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
}
```

### Frontend

**app.module.ts** (si no usa standalone)
```typescript
@NgModule({
  imports: [
    CoreModule.forRoot({
      environment
    }),
    // Otros módulos ABP
  ]
})
export class AppModule {}
```

## Módulos ABP Integrados

- **Volo.Abp.Identity:** Gestión de usuarios
- **Volo.Abp.PermissionManagement:** Permisos
- **Volo.Abp.TenantManagement:** Multi-tenancy (opcional)
- **Volo.Abp.FeatureManagement:** Características
- **Volo.Abp.SettingManagement:** Configuraciones
- **Volo.Abp.AuditLogging:** Auditoría

## Flujo de Trabajo

1. **Crear Entidad** → Domain Layer
2. **Crear DTO** → Application.Contracts
3. **Crear AppService** → Application
4. **Configurar EF** → EntityFrameworkCore
5. **Crear Migración** → `dotnet ef migrations add`
6. **Generar Proxy** → `abp generate-proxy -t ng`
7. **Crear Componente Angular** → angular/src/app

## Patrones de Diseño Utilizados

- **Domain Driven Design (DDD)**
- **Repository Pattern**
- **Unit of Work**
- **Dependency Injection**
- **CQRS** (opcional)
- **Event Sourcing** (opcional)

## Características ABP Incluidas

✅ Multi-idioma (i18n)
✅ Multi-tenancy (SaaS)
✅ Audit Logging
✅ Exception Handling
✅ Validation automática
✅ Authorization con permisos
✅ Background Jobs
✅ Event Bus
✅ Caching
✅ Email sending
✅ Blob Storage

## Extensiones Recomendadas

- **Volo.FileManagement:** Gestión de archivos
- **Volo.Payment:** Integración de pagos
- **Volo.Blogging:** Sistema de blog
- **Volo.Docs:** Documentación
