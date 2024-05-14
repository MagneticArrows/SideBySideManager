using SideBySideManagerNuget.Contracts;

namespace SideBySideManagerNuget.DataAuditor;

public interface IAuditManager
{
    public Task SaveComparisonAuditItem<TAuditObject>(ComparisonAuditItemDto comparisonAuditItemDto) where TAuditObject : class;
}
