using LoansApp.Api.Dependecies.Loan;
using LoansApp.Api.Dependecies.Shared;
using LoansApp.Api.Dependecies.User;
using LoansApp.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

AuthenticationDependecies.Initialize(builder);
SwaggerDependecies.Initialize(builder);
UserDependecies.Initialize(builder);
DatabaseDependecies.Initialize(builder);
LoanDependecies.Initialize(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<AuthMiddleware>();

app.MapControllers();

app.Run();
