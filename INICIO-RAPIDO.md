# 🚀 Inicio Rápido - E-commerce ABP

## ⚡ Opción 1: Con Docker (Más Rápido)

```bash
# 1. Clonar el proyecto
cd ecommerce-abp

# 2. Levantar servicios
docker-compose up --build

# 3. Esperar a que inicien (2-3 minutos)

# 4. Acceder:
# - Frontend: http://localhost:4200
# - Backend: http://localhost:44300
# - Swagger: http://localhost:44300/swagger

# 5. Login:
# Username: admin
# Password: 1q2w3E*
```

## 🛠️ Opción 2: Desarrollo Local

### Requisitos:
- .NET 8 SDK
- Node.js 18+
- PostgreSQL 15
- ABP CLI

### Backend:

```bash
# 1. Instalar ABP CLI
dotnet tool install -g Volo.Abp.Cli

# 2. Ir al proyecto
cd aspnet-core/src/Ecommerce.HttpApi.Host

# 3. Configurar base de datos en appsettings.json
# Cambiar la cadena de conexión a tu PostgreSQL local

# 4. Aplicar migraciones
dotnet ef database update

# 5. Ejecutar
dotnet run

# Backend en: https://localhost:44300
```

### Frontend:

```bash
# 1. Ir al proyecto Angular
cd angular

# 2. Instalar dependencias
npm install

# 3. Ejecutar
npm start

# Frontend en: http://localhost:4200
```

## 📝 Primer Login

1. Ir a http://localhost:4200
2. Click en "Login"
3. Usar credenciales:
   - **Username:** admin
   - **Password:** 1q2w3E*

## 🎯 Siguientes Pasos

### 1. Explorar el Dashboard
- Ver estadísticas
- Navegar por los módulos

### 2. Gestionar Productos
- Ir a "Productos"
- Crear nuevo producto
- Subir imagen
- Asignar categoría

### 3. Crear Categorías
- Ir a "Categorías"
- Crear categorías principales
- Crear subcategorías

### 4. Probar el Carrito
- Ir al catálogo
- Agregar productos al carrito
- Ver carrito
- Hacer checkout

### 5. Gestionar Pedidos
- Ir a "Pedidos"
- Ver listado
- Cambiar estados
- Generar reportes

## 🔧 Configuración Adicional

### Cambiar Puerto del Backend

En `appsettings.json`:
```json
{
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://localhost:5000"
      }
    }
  }
}
```

### Cambiar Puerto del Frontend

En `angular.json`:
```json
{
  "serve": {
    "options": {
      "port": 3000
    }
  }
}
```

### Configurar Email

En `appsettings.json`:
```json
{
  "Settings": {
    "Abp.Mailing.Smtp.Host": "smtp.gmail.com",
    "Abp.Mailing.Smtp.Port": "587",
    "Abp.Mailing.Smtp.UserName": "tu@email.com",
    "Abp.Mailing.Smtp.Password": "tu-password"
  }
}
```

## 🐛 Solución de Problemas

### Error: "Connection refused" en base de datos

Verificar que PostgreSQL esté corriendo:
```bash
# En Docker
docker-compose ps

# En local
pg_isready
```

### Error: "CORS policy"

Agregar origin en `appsettings.json`:
```json
{
  "App": {
    "CorsOrigins": "http://localhost:4200"
  }
}
```

### Frontend no muestra datos

1. Verificar que el backend esté corriendo
2. Revisar consola del navegador (F12)
3. Verificar environment.ts tiene la URL correcta

### Error de migraciones

```bash
# Eliminar migraciones
dotnet ef migrations remove

# Recrear
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## 📚 Recursos

- [Documentación ABP](https://docs.abp.io)
- [GitHub ABP](https://github.com/abpframework/abp)
- [Community](https://community.abp.io)
- [Tutoriales](https://docs.abp.io/en/abp/latest/Tutorials/Index)

## 💡 Tips

1. **Swagger UI:** Usa http://localhost:44300/swagger para probar la API
2. **ABP Suite:** Herramienta visual para generar CRUD (licencia comercial)
3. **Hot Reload:** Usa `dotnet watch run` en backend
4. **Angular DevTools:** Instala extensión en Chrome
5. **Postman:** Importa colección desde Swagger

## ✅ Checklist de Verificación

- [ ] PostgreSQL corriendo
- [ ] Backend iniciado (puerto 44300)
- [ ] Frontend iniciado (puerto 4200)
- [ ] Login exitoso
- [ ] Productos visibles
- [ ] Carrito funcional
- [ ] Checkout completo

## 🎉 ¡Listo!

Tu e-commerce con ABP está funcionando. Ahora puedes:
- Personalizar el diseño
- Agregar más funcionalidades
- Integrar pasarelas de pago
- Desplegar en producción

**¡Feliz desarrollo! 🚀**
