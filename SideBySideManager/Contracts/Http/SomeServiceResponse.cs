namespace Contracts.Http;

public class SomeServiceResponse
{
    public int SomeInt { get; set; } = 1;
    public string SomeString { get; set; } = "some string";
    public double SomeDouble { get; set; } = 1.1;
    public DateTime SomeDateTime { get; set; } = DateTime.Now;
}
