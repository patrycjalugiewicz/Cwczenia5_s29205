using ClinicAPI.Data;
using ClinicAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

 builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);



builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();

var app = builder.Build();


 if (app.Environment.IsDevelopment())
 {
     app.UseSwagger();
     app.UseSwaggerUI();
 }


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();