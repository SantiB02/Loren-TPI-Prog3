using Loren_TPI_Prog3.Data;
using Loren_TPI_Prog3.Enums;
using Loren_TPI_Prog3.Services.Implementations;
using Loren_TPI_Prog3.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); //para que no haya referencia circular de objetos en el Include

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("LorenLingerieApiBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Ac� pegar el token generado al loguearse."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "LorenLingerieApiBearerAuth" } //Tiene que coincidir con el id seteado arriba en la definici�n
                }, new List<string>() }
    });
});

builder.Configuration.AddUserSecrets<Program>(); //indicamos al Program que use los user-secrets (por el repositorio p�blico)

builder.Services.AddDbContext<LorenContext>(dbContextOptions =>
{
    var connectionString = builder.Configuration.GetConnectionString("MyConnectionString");
    var dbPassword = builder.Configuration["DbPassword"];

    connectionString = connectionString.Replace("{DbPassword}", dbPassword); //uso de un user-secret para no publicar la contrase�a de acceso SQL Server al repositorio p�blico de GitHub

    dbContextOptions.UseSqlServer(connectionString); //cambiamos el motor de la base de datos de SQLite a SQL Server para poder deployar el back-end en Azure (no admite SQLite nativamente)
});


#region Injections

builder.Services.AddScoped<IUserService, UserService>(); //Scoped: se instancia el servicio por cada solicitud HTTP
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISaleOrderService, SaleOrderService>();
#endregion

builder.Services.AddAuthentication("Bearer") //"Bearer" es el tipo de autenticaci�n que tenemos que elegir despu�s en PostMan para pasarle el token
    .AddJwtBearer(options => //Ac� definimos la configuraci�n de la autenticaci�n. le decimos qu� cosas queremos comprobar. La fecha de expiraci�n se valida por defecto.
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    }
);
builder.Services.AddCors(options => //habilitamos las solicitudes Cross-Origin para deployar correctamente el back-end en Azure
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
