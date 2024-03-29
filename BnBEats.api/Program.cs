using BnBEata.application.Services.Authentication;
using BnBEats.application.Services.Authentication;
using BnBEata.application;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddApplication();
}

var app = builder.Build();

{
    // app.UseHttpsRedirection();/
    app.Run();
}
