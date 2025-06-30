using FluentValidation.AspNetCore;
using GitClock.Api.Middlewares;
using GitClock.Application.Configurations;
using GitClock.Common.Translations.Languages;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);
var supportedCultures = new string[] { AcceptedLanguages.En_US, AcceptedLanguages.Pt_Br };
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenLocalhost(5000); // HTTP
    serverOptions.ListenLocalhost(5001, options => options.UseHttps()); // HTTPS
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Gerenciador de Tarefas",
        Version = "v1",
        Description = "API para gerenciamento de tarefas",

        License = new OpenApiLicense
        {
            Name = "Uso Interno"
        }
    });
});

builder.Services.AddApplication();
builder.Services.AddFluentValidation();
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())

{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gerenciador de Tarefas v1"));
}


app.UseHttpsRedirection();
app.UseCors("AllowAll");

// Aplicar configuração de localização
var LocalizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(AcceptedLanguages.En_US)
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(LocalizationOptions);

app.UseMiddleware<ControllerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
