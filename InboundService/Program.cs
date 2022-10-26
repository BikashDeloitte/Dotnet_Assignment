using AutoMapper;
using InboundService.DbContexts;
using InboundService.Mapper;
using InboundService.Repository;
using InboundService.Repository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

//for database connection
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<InboundDbContext>(opt => opt.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddSingleton(mapper);
//builder.Services.AddSingleton<IRabbitMQSender, RabbitMQSender>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPalletRepository, PalletRepository>();
builder.Services.AddScoped<ILPNRepository, LPNRepository>();

//api call
builder.Services.AddHttpClient<IProductRepository, ProductRepository>(u => u.BaseAddress =
              new Uri(builder.Configuration["ServiceUrls:SystemMangementAPI"]));
builder.Services.AddHttpClient<IPalletRepository, PalletRepository>(u => u.BaseAddress =
              new Uri(builder.Configuration["ServiceUrls:SystemMangementAPI"]));
builder.Services.AddHttpClient<ILPNRepository, LPNRepository>(u => u.BaseAddress =
              new Uri(builder.Configuration["ServiceUrls:SystemMangementAPI"]));

builder.Services.AddControllers();
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
