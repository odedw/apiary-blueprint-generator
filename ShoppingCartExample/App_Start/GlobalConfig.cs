using System.Web.Http;
using Newtonsoft.Json.Serialization;

public class GlobalConfig
{
    public static void CustomizeConfig(HttpConfiguration configuration)
    {
        configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);
        var json = configuration.Formatters.JsonFormatter;
        json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    }
}