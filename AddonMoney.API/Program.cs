using AddonMoney.API.Services;
using AddonMoney.Data.Models;
using AddonMoney.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AddonMoneyContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("AddonMoneyDB")));
builder.Services.AddTransient<BalanceInfoRepository>();
builder.Services.AddTransient<ErrorInfoRepository>();
builder.Services.AddTransient<MQProducer>();

builder.Services.AddHostedService<ConsumerHostedService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
