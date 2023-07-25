using Microsoft.EntityFrameworkCore;
using Serilog;
using SmartWallet.DatabaseEntity;
using SmartWallet.DatabaseEntity.Interfaces;
using SmartWallet.DatabaseEntity.Repository;
using SmartWallet.Services.Wallet.AddFundRequest.Interfaces;
using SmartWallet.Services.Wallet.AddFundRequest.service;
using SmartWallet.Services.Wallet.WalletCreation.Interfaces;
using SmartWallet.Services.Wallet.WalletCreation.Service;
using SmartWallet.Services.Wallet.WithdrawFundRequest.Interfaces;
using SmartWallet.Services.Wallet.WithdrawFundRequest.Service;
using SmartWallet.WebAPI.CustomMiddleware;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(Program));

// Repos life
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

//Services life
builder.Services.AddScoped<IWalletCreationService, WalletCreationService>();
builder.Services.AddScoped<IAddFundWalletRequestService, AddFundWalletRequestService>();
builder.Services.AddScoped<IWithdrawFundWalletRequestService, WithdrawFundRequestService>();





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configure Serilog service and print log in 
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration)) ;

//configure postgresSQL service
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(conn);
});

var app = builder.Build();

//configure UI Exception
app.UseExceptionHandlerMiddleware();

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
