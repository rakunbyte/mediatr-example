using Databases;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add MediatR from all Assemblies
builder.Services.AddMediatR(cfg =>
{
    //Just need one from each assembly
    cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly);
    cfg.RegisterServicesFromAssemblies(typeof(ProductStore).Assembly);
    cfg.RegisterServicesFromAssemblies(typeof(ProductsService).Assembly);
});

//Add Controllers
builder.Services.AddControllers();
builder.Services.AddRouting(o => o.LowercaseUrls = true);

//Add Databases
builder.Services.AddSingleton<ProductStore>();

//Add Services
//builder.Services.AddSingleton<ProductsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();
app.Run();