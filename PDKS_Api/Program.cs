using PDKS_Api.Models.DapperContext;
using PDKS_Api.Repositories.DevamlýlýkRepository;
using PDKS_Api.Repositories.OgrenciRepository;
using PDKS_Api.Repositories.OgretmenRepository;
using PDKS_Api.Repositories.SýnýfRepository;
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
builder.Services.AddTransient<ISýnýfRepository, SýnýfRepository>();
builder.Services.AddTransient<IDevamlýlýkRepository, DevamlýlýRepository>();
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
