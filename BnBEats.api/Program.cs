using BnBEata.application;
using BnBEats.api;
using BnBEats.infrastructure;


var builder = WebApplication.CreateBuilder(args);
{
    // Global Error handling using Filters
    // builder.Services.AddControllers(options=>options.Filters.Add<ErrorHandlingExceptionFilterAttribute>());
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);

    
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
