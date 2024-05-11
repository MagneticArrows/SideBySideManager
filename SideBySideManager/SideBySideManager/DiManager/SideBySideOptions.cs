using KellermanSoftware.CompareNetObjects;

namespace SideBySideManagerNuget.DiManager
{
    public class SideBySideOptions
    {
        public string Environment { get; set; }
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(10);
        public CompareLogic CompareLogic { get; set; } = new();
    }
}
