using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Activation API", Version = "v1" });
});
builder.Services.AddCors(o => o.AddPolicy("AllowAll", b => 
    b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Activation API v1"));
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();