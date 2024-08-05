using Microsoft.EntityFrameworkCore;
using Wallet.Api.Extensions;
using Wallet.DAL.Repository.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI
builder.Services.ConfigureBLLDependencies();
builder.Services.ConfigureDALDependencies();
builder.Services.ConfigureHttpClients();


// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<DBContext>(options => options.UseNpgsql(connection));

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
