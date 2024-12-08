using Camp6AssignmentProductionSales.Model;
using Camp6AssignmentProductionSales.Repository;
using Microsoft.EntityFrameworkCore;

namespace Camp6AssignmentProductionSales
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //3- JSON format

            builder.Services.AddControllersWithViews()
                .AddJsonOptions(
                           options =>
                           {
                               options.JsonSerializerOptions.PropertyNamingPolicy = null;
                               options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                               options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                               options.JsonSerializerOptions.WriteIndented = true;
                           });

            //1-Connection String as Middleware

            builder.Services.AddDbContext<SalesProductionDbContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("PropelAug24Connection")));

            //2-Register repository and service layer --if not giving then communication with db wont takes place

            builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
            builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
            builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
            builder.Services.AddScoped<IRepository<Staff>, StaffRepository>();
            builder.Services.AddScoped<IRepository<Store>, StoreRepository>();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
