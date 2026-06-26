namespace ENT.Framework.Domain.Commands.Requests;

public class AutoCompleteIdRequest : AutoCompleteRequest
{
    public Guid Id { get; set; }
}
