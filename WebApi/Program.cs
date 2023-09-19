using BusinessLayer.BLs;
using BusinessLayer.IBLs;
using DataAccessLayer;
using DataAccessLayer.DALs;
using DataAccessLayer.IDALs;
using Microsoft.EntityFrameworkCore;

try
{
    var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddDbContext<DBContextCore>();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //DALs
    builder.Services.AddTransient<IDAL_Personas, DAL_Personas_EF>();
    builder.Services.AddTransient<IDAL_Veichulos, DAL_Veichulo_EF>();

    //Bls
    builder.Services.AddTransient<IBL_Personas, BL_Personas>();
    builder.Services.AddTransient<IBL_Veichulos, BL_Veichulos>();

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

    UpdateDataBase();

    app.Run();

}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}


void UpdateDataBase()
{
    using(var context = new DataAccessLayer.DBContextCore())
    {
        context?.Database.Migrate();
    }
}


