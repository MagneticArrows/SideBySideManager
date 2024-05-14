namespace SideBySideManagerNuget.Contracts;

public class ComparisonAuditItemDto
{
    public bool AreEquals { get; set; }
    public string DifferencesString { get; set; }
    public object Response1 { get; set; }
    public object Response2 { get; set; }
}
