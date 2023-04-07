global using Microsoft.EntityFrameworkCore;
global using TsppAPI.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json.Serialization;
using TsppAPI.Providers.Abstract;
using TsppAPI.Providers;
using TsppAPI.Repository;
using TsppAPI.Repository.Abstract;
using TsppAPI.Services;
using TsppAPI.Services.Abstract;
using TsppApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddScoped<ISoldProductRepository, SoldProductRepository>();
builder.Services.AddScoped<IStorageProductRepository, StorageProductRepository>();
builder.Services.AddScoped<IStorageRepository, StorageRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ICurrentDbUserProvider>(CurrentDbUserProvider.Instance);
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<IProductAmountRepository, ProductAmountRepository>();
builder.Services.AddScoped<IMatrixDeterminantCalculator, MatrixDeterminantCalculator>();


SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(connectionBuilder.ConnectionString);
});
CurrentDbUserProvider.Instance.SetUserCredentials(connectionBuilder.UserID, connectionBuilder.Password);
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
