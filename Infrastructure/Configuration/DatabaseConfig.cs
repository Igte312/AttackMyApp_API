

namespace Infrastructure.Configuration
{
    public class DatabaseConfig
    {
        public static string GetConnectionString()
        {
            // Construir la cadena de conexión usando variables de entorno
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "default_host";
            var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "default_db";
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
            var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "default_user";
            var dbPass = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "default_password";

            // Crear la cadena de conexión
            return $"Host={dbHost};Database={dbName};Port={dbPort};Username={dbUser};Password={dbPass};";
        }
    }
}
