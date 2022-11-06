using Market.Auth.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });   
});

var authOptionsConfiguration = builder.Configuration.GetSection("Auth");

builder.Services.Configure<AuthOptions>(authOptionsConfiguration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
