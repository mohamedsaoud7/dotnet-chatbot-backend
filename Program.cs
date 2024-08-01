
using chatbot_backend.Data;
using Microsoft.EntityFrameworkCore;
using chatbot_backend.Interfaces;
using chatbot_backend.Repository;
using chatbot_backend.IServices;
using chatbot_backend.Services;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => {
    options.AddPolicy(
"AllowAllOrigins"
, builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddControllers();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IDamageReasonRepo, DamageReasonsRepo>();
builder.Services.AddScoped<IDraftFormRepo, DraftFormRepo>();
builder.Services.AddScoped<IDraftFormService, DraftFormService>();
builder.Services.AddScoped<IFeedbackRepo, FeedbackRepo>();
builder.Services.AddScoped<IFallbackRepo, FallbackRepo>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<IVecozoService, VecozoService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("MyConnexion")));
builder.Services.AddDbContext<LocalDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("MyLocalConnexion")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy =>
{
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
});
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
