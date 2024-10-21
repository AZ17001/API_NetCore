using API.Data;
using API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Aniadimos la conexion a la base de datos //
builder.Services.AddSqlServer<ApplicationDBContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IServiceDataBase, ServiceDataBase>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
