using Microsoft.EntityFrameworkCore;
using Student_Management_API.Configurations;
using StudentLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<IDbContext, SqlDbContext>(optionBuilder
    => { optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")); });
builder.Services.AddTransient<IStudentRepo, StudentRepo>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IGradeRepo, GradeRepo>();
builder.Services.AddTransient<IGradeService, GradeService>();

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

MapStudentEndpoints(app, "Students");
MapGradeEndpoints(app, "Grades");
app.Run();

void MapStudentEndpoints(WebApplication app, string tag)
{
    app.MapGet("api/students", (IStudentService service)
        => { return service.ReadAll(); }).WithTags(tag);
    app.MapGet("api/students/{key}", (IStudentService service, string key)
        => { return service.Read(key); }).WithTags(tag);
    app.MapPost("api/students", (IStudentService service, StudentCreateReq req)
        => { return service.Create(req); }).WithTags(tag);
    app.MapPut("api/students", (IStudentService service, StudentUpdateReq req)
        => { return service.Update(req); }).WithTags(tag);
    app.MapDelete("api/students/{key}", (IStudentService service, string key)
        => { return service.Delete(key); }).WithTags(tag);
}

void MapGradeEndpoints(WebApplication app, string tag)
{
    app.MapGet("api/grades", (IGradeService service)
        => { return service.ReadAll(); }).WithTags(tag);
    app.MapGet("api/grades/{key}", (IGradeService service, string key)
        => { return service.Read(key); }).WithTags(tag);
    app.MapPost("api/grades", (IGradeService service, GradeCreateReq req)
        => { return service.Create(req); }).WithTags(tag);
    app.MapPut("api/grades", (IGradeService service, GradeUpdateReq req)
        => { return service.Update(req); }).WithTags(tag);
    app.MapDelete("api/grades/{key}", (IGradeService service, string key)
        => { return service.Delete(key); }).WithTags(tag);
}