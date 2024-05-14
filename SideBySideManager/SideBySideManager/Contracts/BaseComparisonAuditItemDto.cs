namespace SideBySideManagerNuget.Contracts;

public class BaseComparisonAuditItemDto
{
    public bool AreEquals { get; set; }
    public string DifferencesString { get; set; }
}
