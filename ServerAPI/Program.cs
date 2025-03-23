using ServerAPI.Repositories;
namespace ServerAPI;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("policy",
                policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                });
        });
        builder.Services.AddSingleton<IBikeRepository, BikeRepositoryMongoDB>();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();
        app.UseCors("policy");

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}