using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DAL;
using Project.Models;

public class Program
{
    private static readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ���� ������ ������ ����� appsettings.json
        var connectionString = builder.Configuration.GetConnectionString("DefaultDatabase");

        // ����� DbContext �� ������ ������
        builder.Services.AddDbContext<DBContext>(options =>
            options.UseSqlServer(connectionString));

        // ����� CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(MyAllowSpecificOrigins,
            builder =>
            {
                builder.WithOrigins("*")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });

        // ����� ������� ������
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // ������ �� ���������
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // ����� �-CORS ���� UseRouting �-UseAuthorization
        app.UseCors(MyAllowSpecificOrigins);

        app.UseRouting();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}










//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using DAL; 
//using Project.Models;
//var builder = WebApplication.CreateBuilder(args);

//// ����� DbContext �� ������ ������
//builder.Services.AddDbContext<DBContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")));

//// ����� CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", builder =>
//    {
//        builder.AllowAnyOrigin()
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//    });
//});

//// ����� ������� ������
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// ������ �� ���������
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//// ����� �-CORS
//app.UseCors("AllowAll");

//app.UseRouting();
//app.UseAuthorization();

//app.MapControllers();

//app.Run();


//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using DAL; // ��� ����� ����� ����
//using Project.Models;

//var builder = WebApplication.CreateBuilder(args);

//// ���� ������ ������ ����� appsettings.json
//var connectionString = builder.Configuration.GetConnectionString("DefaultDatabase");

//// ����� DbContext �� ������ ������
//builder.Services.AddDbContext<DBContext>(options =>
//    options.UseSqlServer(connectionString));

//// ������ ������ �� �������
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// ������ �� ���������
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.UseRouting();
//app.UseAuthorization();

//app.MapControllers();

//app.Run();
