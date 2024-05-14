namespace SideBySideManagerNuget.Contracts;

public class ComparisonAuditItemDto<TResponseObject> : BaseComparisonAuditItemDto where TResponseObject : class
{
    public TResponseObject Response1 { get; set; }
    public TResponseObject Response2 { get; set; }
}
