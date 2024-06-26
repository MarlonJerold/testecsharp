using backend.Data;
using backend.Infraestrutura.Map;
using backend.Infraestrutura.Security;
using backend.Repositorio;
using backend.Repositorio.PostoRepositorio;
using backend.Repositorio.VacinaRepositorio;
using backend.Services;
using backend.Services.PostoServices;
using backend.Services.VacinaServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Adiciona serviços ao contêiner.
        builder.Services.AddControllers();
        builder.Services.AddHttpContextAccessor();


        builder.Services.AddDbContext<PostoContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));



        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Registro do repositório e sua interface
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepositorio>();
        builder.Services.AddScoped<IPostoRepository, PostoRepositorio>();
        builder.Services.AddScoped<IVacinaRepository, VacinaRepository>();

        // Registro do serviço e sua interface
        builder.Services.AddScoped<IUsuarioService, UsuarioService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IPostoService, PostoService>();
        builder.Services.AddScoped<IVacinaService, VacinaService>();

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });



        // Configura CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        // Adiciona Endpoints API Explorer e Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

            c.AddSecurityDefinition("Baerer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Autorização JWT, Digite 'Bearer' antes de"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Baerer"
                }
            },
            Array.Empty<string>()
        }
            });

        });

        var app = builder.Build();

        // Configura o pipeline de solicitação HTTP.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseCors("AllowAll");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}