# Expense Manager

Aplicación de ejemplo para gestión de gastos personales.

Descripción
- Proyecto monorepo con capas separadas: UI web, lógica de aplicación, acceso a datos y entidades del dominio.
- Permite registrar usuarios, categorías, métodos de pago, pagos (individuales, en cuotas y suscripciones) y límites de gasto.

Estructura principal
- `ExpenseManagerWebApp` — Aplicación web ASP.NET Core (Razor Pages / MVC) y punto de arranque.
- `LogicaAccesoDatos` — Implementación EF Core y `ManagerContext`.
- `LogicaAplicacion` — Casos de uso y servicios de aplicación.
- `GestionDePagos` — Entidades del dominio e interfaces de repositorio.
- `CasosUso` — DTOs y mappers.

Tecnologías
- `.NET 10` / C#
- `ASP.NET Core` (Razor Pages / MVC)
- `Entity Framework Core` (migrations incluidas)
- `SQL Server` (por defecto `(localdb)\MSSQLLocalDB`)

Configuración y ejecución rápida
1. Revisar la cadena de conexión en `ExpenseManagerWebApp/appsettings.json` (valor por defecto):
   - `Server=(localdb)\\MSSQLLocalDB;Database=ExpenseManager;Integrated Security=true;`
2. Aplicar migraciones (desde la raíz del repo):
   - `dotnet ef database update --project LogicaAccesoDatos --startup-project ExpenseManagerWebApp`
3. Compilar y ejecutar:
   - `dotnet build`
   - `dotnet run --project ExpenseManagerWebApp`

Notas útiles
- `Program.cs` aplica migraciones automáticamente al iniciar y configura EF Core con `EnableRetryOnFailure()` para resiliencia a errores transitorios.
- Si el ejecutable queda bloqueado durante compilaciones, puede deshabilitarse la generación del `apphost` (propiedad `GenerateAppHost` en `ExpenseManagerWebApp.csproj`) o detener procesos en ejecución antes de compilar.

Contacto
- Revisar los controladores y vistas en `ExpenseManagerWebApp/Controllers` y `ExpenseManagerWebApp/Views` para ejemplos de uso.
