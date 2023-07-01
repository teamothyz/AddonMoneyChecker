using AddonMoney.Data.Models;
using AddonMoney.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Services.AddDbContext<AddonMoneyContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("AddonMoneyDB")));
builder.Services.AddTransient<BalanceInfoRepository>();
builder.Services.AddTransient<ErrorInfoRepository>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
