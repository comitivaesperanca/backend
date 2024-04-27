using ComitivaEsperanca.API.CrossCutting.DependencyInjection;
using ComitivaEsperanca.API.Data.Context;
using Microsoft.EntityFrameworkCore;
using SesiFlow.API.CrossCutting.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<CoreContext>(options =>
    options.UseNpgsql("Server=monorail.proxy.rlwy.net;Database=railway;Port=31794;User Id=postgres;Password=EzDQbWnjRodVzAGWdQeIkkOOpZJpiJOF;Ssl Mode=disable; CommandTimeout=300"));

ConfigureService.Configure(builder.Services);
ConfigureRepositories.Configure(builder.Services, builder.Configuration);
ConfigureMappers.Configure(builder.Services);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var context = (CoreContext) app.Services.GetService(typeof(CoreContext)))
        {
            context.Database.Migrate();
        }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}else{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Comitiva Esperança API");
        c.RoutePrefix = string.Empty;
    });
}

#region [Cors]
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseCors(option => option.AllowAnyOrigin()); 
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
