internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddSwaggerGen(config => 
        {
            config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "TickTick.api",
                Version = "v1",
                Description = "Lorem ipsum",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "Jordy Schuermans",
                    Email= "jordy.schuermans@assign.be"
                }
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}