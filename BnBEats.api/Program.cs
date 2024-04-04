using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.Swagger;
using BnBEata.application.Services.Authentication;
using BnBEats.application.Services.Authentication;
using BnBEata.application;
using BnBEats.application;
using BnBEats.infrastructure;


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddApplication();
    builder.Services.AddScoped<IDateTimeProvider , DateTimeProvider>();
    builder.Services.AddScoped<IJwtTokenGenerator , JwtTokenGenarator>();
    
}

var app = builder.Build();

{
    app.UseSwagger();
    app.UseSwaggerUI();    
    app.Run();
}
