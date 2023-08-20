using QL_Nuoc;
using QL_Nuoc.Repository;
using QL_Nuoc.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IChiTietDonHangRepository, ChiTietDonHangRepository>();
builder.Services.AddScoped<IChiTietDonHangService, ChiTietDonHangService>();

builder.Services.AddScoped<IKhachHangRepository, KhachHangRepository>();
builder.Services.AddScoped<IKhachHangService, KhachHangService>();

builder.Services.AddScoped<IDonHangService, DonHangService>();
builder.Services.AddScoped<IDonHangRepository, DonHangRepository>();

builder.Services.AddScoped<ILoaiNuocUongService, LoaiNuocUongService>();
builder.Services.AddScoped<ILoaiNuocUongRepository, LoaiNuocUongRepository>();

builder.Services.AddScoped<INuocUongService, NuocUongService>();
builder.Services.AddScoped<INuocUongRepository, NuocUongRepository>();

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
