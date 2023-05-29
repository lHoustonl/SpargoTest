namespace SpargoTest;

public sealed class GetUserDepartmentsResponse
{
    public Department Department { get; set; } = null!;
    public Source Source { get; set; } = null!;
    public bool IsActivated { get; init; }
}

public class Department
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
}

public class Source
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
}