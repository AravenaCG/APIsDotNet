using APIs_.NET.Middleware;
using APIs_.NET.Services;
using Entity_Framework_Platzi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("SqlServerConectTareas"));
builder.Services.AddScoped<IHelloWorldService, HelloworldService>();
builder.Services.AddScoped<ITareasService, TareasService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
//builder.Services.AddScoped<IHelloWorldService>(p=> new HelloWorldService());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();
//app.UseTimeMiddleware();
app.MapControllers();

app.Run();
