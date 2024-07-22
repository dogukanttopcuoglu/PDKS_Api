using PDKS_Api.Models.DapperContext;
using PDKS_Api.Repositories.Devaml�l�kRepository;
using PDKS_Api.Repositories.OgrenciRepository;
using PDKS_Api.Repositories.OgretmenRepository;
using PDKS_Api.Repositories.S�n�fRepository;
using PDKS_Api.Repositories.VeliRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<IOgrenciRepository, OgrenciRepository>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddTransient<IVeliRepository, VeliRepository>();  
builder.Services.AddTransient<IOgretmenRepository, OgretmenRepository>();
builder.Services.AddTransient<IS�n�fRepository, S�n�fRepository>();
builder.Services.AddTransient<IDevaml�l�kRepository, Devaml�l�Repository>();
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
