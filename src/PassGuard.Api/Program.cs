using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using PassGuard.Infrastructure;
using PassGuard.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PassGuard",
        Version = "v1"
    });
});
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddShared();

var app = builder.Build();
app
    .MapIdentityApi<IdentityUser>()
    .WithTags("Identity");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "PassGuard v1");
    }});
}
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.Run();