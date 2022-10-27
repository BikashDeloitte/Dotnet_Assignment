using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OutBoundService.DbContexts;
using OutBoundService.Mapper;
using OutBoundService.Repository;
using OutBoundService.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

//for database connection
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<OutBoundServiceDbContext>(opt => opt.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICustomerOrderRespository, CustomerOrderRespository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//api call
builder.Services.AddHttpClient<IProductRepository, ProductRepository>(u => u.BaseAddress =
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
