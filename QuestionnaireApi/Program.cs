using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuestionnaireApi;
using Questionaire.Entities;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.AddOptions();
builder.Services.AddDbContext<QuestionaireDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Questionaire")));
builder.Services.AddMapperProfiles();
builder.Services.AddDependencies();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

AppDomain.CurrentDomain.SetData("ContentRootPath", app.Environment.ContentRootPath);
AppDomain.CurrentDomain.SetData("WebRootPath", app.Environment.WebRootPath);

app.CreateDbIfNotExists();
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