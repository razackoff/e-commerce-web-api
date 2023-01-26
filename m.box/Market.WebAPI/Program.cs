using System.Reflection;
using Market.Persistence;
using Market.Application.Common.Mappings;
using Market.Application.Interfaces;
using Market.Application;
using Market.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();


builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new 
        AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new 
        AssemblyMappingProfile(typeof(IProductDbContext).Assembly));
});

builder.Services.AddApplication();

builder.Services.AddPersistence(builder.Configuration   );

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(); 

var app = builder.Build();

app.UseCustomExceptionHandler(); 

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<ProductDbContext>();
        DbInitializer.Initialize(context); 
    }
    catch(Exception exception)
    {

    }
}

app.Run();
