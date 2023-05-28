namespace ENT.Framework;

public class MessageQueue<T>
{
    public T Content { get; set; }
    public string CorrelationId { get; set; }
    public DateTime CreatedOn { get; set; }
}
