namespace ENT.Framework.Domain.Model;

public static class ConfigAppFramework
{
    public static string RabbitUsername { get; set; }
    public static int RabbitPort { get; set; }
    public static string RabbitPassword { get; set; }
    public static string RabbitVirtualHost { get; set; }
    public static int RabbitConsumerDispatchConcurrency { get; set; }
    public static string RabbitClientProvidedName { get; set; }
    public static string RabbitHostName { get; set; }
    public static string RabbitExchange { get; set; }
}
