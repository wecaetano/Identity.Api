using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Identity.Api.Documentation.SchemaFilters;

/// <summary>
/// SchemaFilter para parsear e incluir dados dos Enums na documentação.
/// </summary>
public class EnumeratorSchemaFilter : ISchemaFilter
{
    private readonly XDocument? _xmlDocument;

    /// <summary>
    /// Carrega o XDocument a partir do path informado
    /// </summary>
    /// <param name="xmlPath">Diretório do XML</param>
    public EnumeratorSchemaFilter(string xmlPath)
    {
        if (File.Exists(xmlPath))
        {
            _xmlDocument = XDocument.Load(xmlPath);
        }
    }

    /// <summary>
    /// Parseia os dados do Enum e inclui no XML da documentação.
    /// </summary>
    public void Apply(OpenApiSchema argSchema, SchemaFilterContext argContext)
    {
        if (_xmlDocument is null)
        {
            return;
        }

        var enumType = argContext.Type;

        if (!enumType.IsEnum)
        {
            return;
        }

        var stringBuilder = new StringBuilder(argSchema.Description);

        stringBuilder.AppendLine("<p>Possible values:</p>");
        stringBuilder.AppendLine("<ul>");

        foreach (var enumMember in Enum.GetNames(enumType))
        {
            var enumMemberName = $"F:{enumType.FullName}.{enumMember}";

            var enumDescription = _xmlDocument.XPathEvaluate(
                $"normalize-space(//member[@name = '{enumMemberName}']/summary/text())"
            ) as string;

            var enumValue = (int)Enum.Parse(enumType, enumMember);

            stringBuilder.AppendLine($"<li><b>{enumValue} - {enumMember}</b>");

            if (!string.IsNullOrWhiteSpace(enumDescription))
            {
                stringBuilder.Append($": {enumDescription}");
            }

            stringBuilder.Append("</li>");
        }

        stringBuilder.AppendLine("</ul>");

        argSchema.Description = stringBuilder.ToString();
    }
}