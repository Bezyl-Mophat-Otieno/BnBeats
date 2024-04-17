using BnBEata.application;
using BnBEats.api;
using BnBEats.contracts.Authentications;
using BnBEats.infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);
{
    // Global Error handling using Filters
    // builder.Services.AddControllers(options=>options.Filters.Add<ErrorHandlingExceptionFilterAttribute>());

    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddPresentation();
    builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
    builder.Services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();
    
}

var app = builder.Build();

{
    app.UseSwagger();
    app.UseSwaggerUI();    
    // Global Error handling using Middlewares
    // app.UseMiddleware<ErrorHandlerMiddleware>();
    app.MapControllers();
    app.UseExceptionHandler("/error");
    app.Run();
}
