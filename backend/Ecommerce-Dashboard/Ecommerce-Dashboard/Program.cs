using Ecommerce_Dashboard.Data;
using Ecommerce_Dashboard.Data.Repositories.Interfaces;
using Ecommerce_Dashboard.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    op => {
    op.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("ConDb"));
    op.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
    );

builder.Services.AddScoped(typeof(IRepository<>), typeof(MainRepository<>));


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                    
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthorization();

app.MapControllers();


app.Run();
