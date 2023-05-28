namespace ENT.Framework.Domain.Model;

public class AppTenant
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ConnectionString { get; set; }
}
