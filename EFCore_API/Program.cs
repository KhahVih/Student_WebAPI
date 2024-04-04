using EFCore_API.Data;
using EFCore_API.Services;
using Microsoft.EntityFrameworkCore;

var model_builder = WebApplication.CreateBuilder(args);

// Add services to the container.

model_builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
model_builder.Services.AddEndpointsApiExplorer();
model_builder.Services.AddSwaggerGen();

model_builder.Services.AddTransient<ILibraryService, LibraryService>();



model_builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(model_builder.Configuration.GetConnectionString("DefaultConnection")));

var app = model_builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
