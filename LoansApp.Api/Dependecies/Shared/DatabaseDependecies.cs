using LoansApp.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace LoansApp.Api.Dependecies.Shared
{
    public class DatabaseDependecies
    {
        public static void Initialize(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration["Database:ConnectionString"];

            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
        }
    }
}