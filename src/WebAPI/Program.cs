using Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCorsPolicy();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddServicesConfiguration(builder.Configuration);
builder.Services.AddHealthChecks(builder.Configuration);

builder.Services.AddDependencyInjection();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.AddMiddlewarePipelines();