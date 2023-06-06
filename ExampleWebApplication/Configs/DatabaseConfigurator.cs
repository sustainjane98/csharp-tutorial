using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ExampleWebApplication.Configs;

public static class DatabaseConfigurator
{
    public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
    {
        var nCsb = new NpgsqlConnectionStringBuilder
        {
            Database = "pokemon",
            Host = "localhost",
            Port = 5432,
            Password = "dp3LLThr3eP4HJMk",
            Username = "postgres"
        };

        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(nCsb.ToString()));
        return builder;
    }
}