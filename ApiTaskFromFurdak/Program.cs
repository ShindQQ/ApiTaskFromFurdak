using ApiTask.Bll.Models;
using ApiTask.Bll.Services;
using ApiTask.Dal.Contexts;
using ApiTask.Dal.Entities;
using ApiTaskFromFurdak.CustomMiddlewares;
using ApiTaskFromFurdak.Options;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<AuthorizationOptions>(builder.Configuration.GetSection("Authorization"));

builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("ApiTaskFromFurdakSpecification", new OpenApiInfo
    {
        Title = "Furdak API task",
        Description = "Using this API you can operate with products services for internet-market.",
        Contact = new OpenApiContact
        {
            Name = "Denys Fedorov",
            Url = new Uri("https://t.me/Shindd"),
            Email = "ishindqq@gmail.com",
        }
    });

    setupAction.AddSecurityDefinition("BearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Input a valid token to access this API"
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "BearerAuth"
                }
            },
            new List<string>()
        }
    });

    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

    setupAction.IncludeXmlComments(xmlCommentsFullPath);
});

builder.Services.AddDbContext<ProductsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionDbFirst")));

builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authorization:SecretForKey"]))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

//app.MapGet("api/Products/Products", async ([FromServices] IProductsService _productsService) =>
//{
//    return await _productsService.GetAsync();
//});

//app.MapGet("api/Products/{id:int}", async ([Required][FromRoute] int id,
//    [FromServices] IProductsService _productsService) =>
//{
//    return await _productsService.FindProductAsync(new ProductForSearchDto { Id = id });
//});

//app.MapGet("api/Products", async ([Required] string category,
//    [FromServices] IProductsService _productsService) =>
//{
//    return await _productsService.FindProductsAsync(new ProductForSearchDto { Category = category });
//});

//app.MapPost("api/Products/{id:int}/Quantity", async ([Required] int id,
//    [Required][FromBody] int quantity,
//    [FromServices] IProductsService _productsService) =>
//{
//    return await _productsService.ChangeProductQuantityAsync(id, quantity);
//});

//app.MapPost("api/Products", async ([Required][FromBody] ProductForInsertAndUpdateDto product,
//    [FromServices] IMapper _mapper,
//    [FromServices] IProductsService _productsService) =>
//{
//    return await _productsService.AddAsync(_mapper.Map<Product>(product));
//});

//app.MapPost("api/Products/{id:int}/Attribute", async ([Required] int id,
//    [Required][FromBody] List<ProductAttribute> productAttributes,
//    [FromServices] IMapper _mapper,
//    [FromServices] IProductsService _productsService) =>
//{
//    return await _productsService.ChangeProductAttributesAsync(id, productAttributes);
//});

//app.MapPut("api/Products/{id:int}/Attribute", async ([Required] int id,
//    [Required][FromBody] List<ProductAttribute> productAttributes,
//    [FromServices] IMapper _mapper,
//    [FromServices] IProductsService _productsService) =>
//{
//    return await _productsService.AddProductAttributesAsync(id, productAttributes);
//});

//app.MapDelete("api/Products/{id:int}", async ([Required] int id,
//    [FromServices] IMapper _mapper,
//    [FromServices] IProductsService _productsService) =>
//{
//    await _productsService.RemoveAsync(id);
//});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setupAction =>
    {
        setupAction.SwaggerEndpoint("/swagger/ApiTaskFromFurdakSpecification/swagger.json", "Furdak API task");
    });
}

app.UseRouting();

app.UseMiddleware<HttpStatusCodeExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
