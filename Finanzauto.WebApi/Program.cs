using Finanzauto.WebApi;
using Finanzauto.WebApi.Middlewares;
using Finanzauto.Infrastructure.Persistence;
using Finanzauto.Infrastructure.AuthenticationJWT;
using Finanzauto.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPresentation()
                .AddApplication()
                .AddAuthentication(builder.Configuration)
                .AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
