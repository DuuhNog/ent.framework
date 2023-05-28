using ENT.Framework.Domain.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using RabbitMQ.Client;

namespace ENT.Framework;

public static class RabbitMQHelper
{
    private static IConnection _connection;
    private static IConnection CreateConnection()
    {
        var factory = new ConnectionFactory()
        {
            UserName = ConfigAppFramework.RabbitUsername,
            Port = ConfigAppFramework.RabbitPort,
            Password = ConfigAppFramework.RabbitPassword,
            VirtualHost = ConfigAppFramework.RabbitVirtualHost,
            HostName = ConfigAppFramework.RabbitHostName,
        };

        return factory.CreateConnection();
    }

    public static void Publish<T>(string topic, MessageQueue<T> Body)
    {
        var headers = new Dictionary<string, string>();

        if (string.IsNullOrEmpty(Body.CorrelationId))
        {
            var correlationId = Guid.NewGuid().ToString();
            headers.Add("CorrelationId", correlationId);
            Body.CorrelationId = correlationId.ToString();
        }
        else
            headers.Add("CorrelationId", Body.CorrelationId);

        byte[] jsonBytes = null;

        if (Body != null)
            jsonBytes = Body.ConvertGenericToByteJson();

        using var connection = CreateConnection();
        using var channel = connection.CreateModel();
        var props = channel.CreateBasicProperties();
        props.DeliveryMode = 2;
        props.Headers = headers.ToDictionary(x => x.Key, x => (object)x.Value);
        channel.BasicPublish(ConfigAppFramework.RabbitExchange, topic, props, jsonBytes);
        connection.Close();
    }
}

public static class ByteExtensions
{
    public static object ConvertByteJsonToObject(this byte[] bytes, Type type)
    {
        using var ms = new MemoryStream(bytes);
        using var reader = new BsonDataReader(ms);
            return JsonSerializer.Create().Deserialize(reader, type);
    }

    public static byte[] ConvertGenericToByteJson<T>(this T body)
    {
        using var ms = new MemoryStream();
        using var writer = new BsonDataWriter(ms);
        var serializer = new JsonSerializer();
        serializer.Serialize(writer, body);
        return ms.ToArray();

    }
}
