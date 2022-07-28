using Microsoft.EntityFrameworkCore;
using Template.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("TemplateDb");
builder.Services.AddDbContext<TemplateContext>(x => x.UseSqlServer(connectionString).EnableSensitiveDataLogging());

builder.Services.AddAuthentication();

builder.Services.AddControllers();



var app = builder.Build();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}


app.UseSwagger();
app.UseSwaggerUI();
app.UseExceptionHandler("/Error");


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.Run();
