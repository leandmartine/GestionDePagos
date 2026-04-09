using Microsoft.EntityFrameworkCore;
using LogicaAccesoDatos.EF;
using Microsoft.Extensions.Logging;

namespace ExpenseManagerWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            // Repositorios
            builder.Services.AddDbContext<ManagerContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection") ??
                    "Server=(localdb)\\mssqllocaldb;Database=ExpenseManager;Integrated Security=true;",
                    sqlOptions => sqlOptions.EnableRetryOnFailure()
                ));

            builder.Services.AddScoped<GestionDePagos.InterfacesDeRepositorio.ICategoriaRepositorio, LogicaAccesoDatos.EF.Repositorios.CategoriaRepositorio>();
            builder.Services.AddScoped<GestionDePagos.InterfacesDeRepositorio.IUsuarioRepositorio, LogicaAccesoDatos.EF.Repositorios.UsuarioRepositorio>();
            builder.Services.AddScoped<GestionDePagos.InterfacesDeRepositorio.IMetodoPagoRepositorio, LogicaAccesoDatos.EF.Repositorios.MetodoPagoRepositorio>();
            builder.Services.AddScoped<GestionDePagos.InterfacesDeRepositorio.IPagoRepositorio, LogicaAccesoDatos.EF.Repositorios.PagoRepositorio>();
            builder.Services.AddScoped<GestionDePagos.InterfacesDeRepositorio.ILimiteGastoRepositorio, LogicaAccesoDatos.EF.Repositorios.LimiteGastoRepositorio>();

            // Casos de Uso - Categorias
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.Categorias.IAltaCategoria, LogicaAplicacion.CasosDeUso.Categorias.AltaCategoria>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.Categorias.IEncontrarTodasCategorias, LogicaAplicacion.CasosDeUso.Categorias.EncontrarTodasCategorias>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.Categorias.IEncontrarCategoriaPorId, LogicaAplicacion.CasosDeUso.Categorias.EncontrarCategoriaPorId>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.Categorias.IEditarCategoria, LogicaAplicacion.CasosDeUso.Categorias.EditarCategoria>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.Categorias.IEliminarCategoria, LogicaAplicacion.CasosDeUso.Categorias.EliminarCategoria>();

            // Casos de Uso - MetodosPago
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.MetodosPagos.IAltaMetodoPago, LogicaAplicacion.CasosDeUso.MetodosPagos.AltaMetodoPago>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.MetodosPagos.IEncontrarTodosMetodosPago, LogicaAplicacion.CasosDeUso.MetodosPagos.EncontrarTodosMetodosPago>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.MetodosPagos.IEncontrarMetodoPagoPorId, LogicaAplicacion.CasosDeUso.MetodosPagos.EncontrarMetodoPagoPorId>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.MetodosPagos.IEditarMetodoPago, LogicaAplicacion.CasosDeUso.MetodosPagos.EditarMetodoPago>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.MetodosPagos.IEliminarMetodoPago, LogicaAplicacion.CasosDeUso.MetodosPagos.EliminarMetodoPago>();

            // Casos de Uso - Usuarios
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.Usuarios.IAltaUsuario, LogicaAplicacion.CasosDeUso.Usuarios.AltaUsuario>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.Usuarios.IEncontrarTodosUsuarios, LogicaAplicacion.CasosDeUso.Usuarios.EncontrarTodosUsuarios>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.Usuarios.IEncontrarUsuarioPorId, LogicaAplicacion.CasosDeUso.Usuarios.EncontrarUsuarioPorId>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.Usuarios.IEditarUsuario, LogicaAplicacion.CasosDeUso.Usuarios.EditarUsuario>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.Usuarios.IEliminarUsuario, LogicaAplicacion.CasosDeUso.Usuarios.EliminarUsuario>();

            // Casos de Uso - Pagos
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.Pagos.IAltaPagoUnico, LogicaAplicacion.CasosDeUso.Pagos.AltaPagoUnico>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.Pagos.IAltaPagoCuotas, LogicaAplicacion.CasosDeUso.Pagos.AltaPagoCuotas>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.Pagos.IAltaSuscripcion, LogicaAplicacion.CasosDeUso.Pagos.AltaSuscripcion>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.Pagos.IEncontrarTodosPagos, LogicaAplicacion.CasosDeUso.Pagos.EncontrarTodosPagos>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.Pagos.IEncontrarPagoPorId, LogicaAplicacion.CasosDeUso.Pagos.EncontrarPagoPorId>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.Pagos.IEliminarPago, LogicaAplicacion.CasosDeUso.Pagos.EliminarPago>();

            // Casos de Uso - LimitesGasto
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.LimitesGasto.IAltaLimiteGasto, LogicaAplicacion.CasosDeUso.LimitesGasto.AltaLimiteGasto>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.LimitesGasto.IEncontrarTodosLimitesGasto, LogicaAplicacion.CasosDeUso.LimitesGasto.EncontrarTodosLimitesGasto>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.LimitesGasto.IEncontrarLimiteGastoPorId, LogicaAplicacion.CasosDeUso.LimitesGasto.EncontrarLimiteGastoPorId>();
            builder.Services.AddScoped<LogicaAplicacion.InterfacesCasosDeUso.LimitesGasto.IEliminarLimiteGasto, LogicaAplicacion.CasosDeUso.LimitesGasto.EliminarLimiteGasto>();


            WebApplication app = builder.Build();

            // Aplicar migraciones al iniciar (si el proveedor lo soporta)
            try
            {
                using IServiceScope scope = app.Services.CreateScope();
                ManagerContext context = scope.ServiceProvider.GetRequiredService<ManagerContext>();
                context.Database.Migrate();
            }
            catch (System.Exception ex)
            {
                ILogger<Program> logger = app.Services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Error aplicando migraciones al iniciar la aplicación.");
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Pago}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
