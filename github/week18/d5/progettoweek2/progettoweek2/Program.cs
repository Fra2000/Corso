using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using progettoweek2.DAO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<PrenotazioneDao>(sp => new PrenotazioneDao("Data Source=localhost\\sqlexpress;Initial Catalog=weekimpegnativa;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"));
builder.Services.AddScoped<ClienteDao>(sp => new ClienteDao("Data Source=localhost\\sqlexpress;Initial Catalog=weekimpegnativa;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"));
builder.Services.AddScoped<CameraDao>(sp => new CameraDao("Data Source=localhost\\sqlexpress;Initial Catalog=weekimpegnativa;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"));

// Configure JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "YourIssuer",
        ValidAudience = "YourAudience",
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("YourSecretKey")) // Assicurati di mantenere questa chiave segreta sicura e configurata altrove
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
