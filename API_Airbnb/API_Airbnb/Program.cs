using API_Airbnb.AutoMapperProfile;
using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.CategoriesRepository;
using API_Airbnb.Data.Repositories.SubcategoriesRepository;
using API_Airbnb.Data.Repositories.DisputesRepository;
using API_Airbnb.Data.Repositories.PromoCodeRepository;
using API_Airbnb.Data.Repositories.PropertyRepository;
using API_Airbnb.Data.Repositories.PropertyReviewsRepository;
using API_Airbnb.Data.Repositories.RoomTypeRepository;
using API_Airbnb.Data.Repositories.UserRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using API_Airbnb.Data.Repositories.CityRepository;
using API_Airbnb.Data.Repositories.CountryRepository;
using API_Airbnb.Data.Repositories.PropertyTypeRepository;
using API_Airbnb.Data.Repositories.BookingsRepository;
using API_Airbnb.Data.Repositories.CurrenciesRepository;
using API_Airbnb.Data.Repositories.TransactionsRepository;
using API_Airbnb.Data.Repositories.PropertyImagesRepository;

var builder = WebApplication.CreateBuilder(args);
var allowAll = "allowAll";
// Add services to the container.
//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region ConnectionString
var connectionString = builder.Configuration.GetConnectionString("AirbnbDB");
builder.Services.AddDbContext<AirbnbContext>(options => options.UseSqlServer(connectionString));

#endregion
#region Configuration Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IPromoCodeRepository, PromoCodeRepository>();
builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
builder.Services.AddScoped<IPropertyReviewsRepository, PropertyReviewsRepository>();
builder.Services.AddScoped<IDisputesRepository, DisputesRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ISubcategoriesRepository, SubcategoriesRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IPropertyTypeRepository, PropertyTypeRepository>();
builder.Services.AddScoped<IBookingsRepository, BookingsRepository>();
builder.Services.AddScoped<ICurrenciesRepository, CurrenciesRepository>();
builder.Services.AddScoped<ITransactionsRepository, TransactionsRepository>();
builder.Services.AddScoped<IPropertyImagesRepository, PropertyImagesRepository>();

#endregion
#region Allow Origin
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowAll, builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();

    });
});
#endregion
#region Configure Aspnet Identity UserManager
builder.Services.AddIdentity<ArUsers, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
    options.User.RequireUniqueEmail = true;
    options.Lockout.MaxFailedAccessAttempts = 3;

}).AddEntityFrameworkStores<AirbnbContext>();
#endregion
#region jwtAuthConfiguration
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "jwtAuth";
    options.DefaultChallengeScheme = "jwtAuth";
    options.DefaultScheme = "jwtAuth";
}).AddJwtBearer("jwtAuth", options =>
{
    var secretKey = builder.Configuration.GetValue<string>("SecretKey");
    var byteKey = Encoding.ASCII.GetBytes(secretKey);
    var securityKey = new SymmetricSecurityKey(byteKey);

    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = securityKey,
        ValidateIssuer = false,
        ValidateAudience = false,
        

    };
});
#endregion
#region Configuration Policy Authorization
builder.Services.AddAuthorization(options =>
{
options.AddPolicy("host", policy => policy.RequireClaim(ClaimTypes.Role, "host"));
options.AddPolicy("user", policy => policy.RequireClaim(ClaimTypes.Role, "user"));
options.AddPolicy("admin", policy => policy.RequireClaim(ClaimTypes.Role, "admin"));
options.AddPolicy("adminAndhost", policy => policy.RequireClaim(ClaimTypes.Role, "admin","host"));

});

#endregion
#region mapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
#region Img Path
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Assets")),
    RequestPath = "/Assets"
});
#endregion
app.UseCors(allowAll);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();
