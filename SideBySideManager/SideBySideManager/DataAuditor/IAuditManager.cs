using SideBySideManagerNuget.Contracts;

namespace SideBySideManagerNuget.DataAuditor;

public interface IAuditManager
{
    public Task SaveComparisonAuditItem<TResponseObject>(ComparisonAuditItemDto<TResponseObject> comparisonAuditItemDto) where TResponseObject : class;
}
