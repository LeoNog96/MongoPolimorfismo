using JsonSubTypes;
using Microsoft.OpenApi.Models;
using MongoPolimorfismo.Domain.Models;
using MongoPolimorfismo.Repository.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(
        JsonSubtypesConverterBuilder
        .Of(typeof(Campo), nameof(Campo.Tipo))
        .RegisterSubtype(typeof(CampoNumerico), "CampoNumerico")
        .RegisterSubtype(typeof(CampoTexto), "CampoTexto")
        .Build()
    );

});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "PolymorphismInWebApi",
                        Version = "v1"
                    }
                );
    c.UseAllOfToExtendReferenceSchemas();
    c.UseAllOfForInheritance();
    c.UseOneOfForPolymorphism();
    c.SelectDiscriminatorNameUsing(type =>
    {
        return type.Name switch
        {
            nameof(Campo) => "Campo",
            _ => null
        };
    });
});
builder.Services.ConfigurarRepository();
RepositoryExtensions.ConfigurarPolimorfismo();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
