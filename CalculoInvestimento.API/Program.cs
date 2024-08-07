using CalculoInvestimento.Services;
using CalculoInvestimento.Services.Interfaces;

namespace CalculoInvestimento.API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddScoped<ICalculoCdb, CalculoCdb>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CdbApi v1"));
            }

            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
