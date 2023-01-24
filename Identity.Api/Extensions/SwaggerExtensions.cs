using Identity.Api.Documentation.SchemaFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Identity.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static void ConfigureApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 1);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();

                c.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
                {
                    Description = "Basic auth added to authorization header",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "basic",
                    Type = SecuritySchemeType.Http
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Basic" }
                        },
                        new List<string>()
                    }
                });

                var xmlFiles = Directory
                    .GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.AllDirectories)
                    .ToList();

                var executingProjectName = Assembly.GetExecutingAssembly().GetName().Name!;

                foreach (var xmlFile in xmlFiles)
                {
                    c.IncludeXmlComments(xmlFile, true);

                    c.SchemaFilter<EnumeratorSchemaFilter>(xmlFile);
                }

                //c.ExampleFilters();
            });

            //services.AddSwaggerExamplesFromAssemblyOf<GetnetPaymentRequestExamples>();
        }

        public static void ConfigureSwaggerUi(this WebApplication app)
        {
            var scope = app.Services.CreateScope();

            var provider = scope.ServiceProvider.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
            });
        }
    }
}
