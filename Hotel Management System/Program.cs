
using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Cores.Repository;
using Hotel_Management_System.Cores.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication().AddCookie().
                AddFacebook(option =>
                {
                    option.AppId = "";
                    option.AppSecret = "";
                    option.Scope.Add("email");
                    option.SaveTokens = true;
                    ;
                }).
                AddGoogle(option =>
                {
                    option.ClientId = "";
                    option.ClientSecret = "";
                    option.Scope.Add("email");
                    option.SaveTokens = true;
                });

            builder.Services.AddDbContext<ApplicationDbContext>(e =>
            e.UseSqlServer(builder.Configuration.GetConnectionString("CS")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<ApplicationDbContext>().
                AddDefaultTokenProviders();

            builder.Services.AddScoped<IRepository<AmenitiesDto>, AmenitiesRepo>();
            builder.Services.AddScoped<IRepository<CountryDto>, CountryRepo>();
            builder.Services.AddScoped<IRepository<FeedBacksDto>, FeedBacksRepo>();
            builder.Services.AddScoped<IRepository<PaymentsDto>, PaymentsRepo>();
            builder.Services.AddScoped<IRepository<PaymentMethodsDto>, PaymentMethodsRepo>();
            builder.Services.AddScoped<IRepository<ReservationsDto>, ReservationsRepo>();
            builder.Services.AddScoped<IRepository<ReservationStatusesDto>, ReservationStatusesRepo>();
            builder.Services.AddScoped<IRepository<RolesDto>, RolesRepo>();
            builder.Services.AddScoped<IRepository<RoomsDto>, RoomsRepo>();
            builder.Services.AddScoped<IRepository<RoomAmenitiesDto>, RoomAmenitiesRepo>();
            builder.Services.AddScoped<IRepository<RoomStatusesDto>, RoomStatusesRepo>();
            builder.Services.AddScoped<IRepository<RoomTypesDto>, RoomTypesRepo>();
            builder.Services.AddScoped<IRepository<StatesDto>, StatesRepo>();
            builder.Services.AddScoped<IRepository<UsersDto>, UsersRepo>();
            builder.Services.AddScoped<IAuthService, AuthService>();          



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
