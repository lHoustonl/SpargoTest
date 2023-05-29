namespace SpargoTest;

public static class UserRoles
{
    public const string Agent = nameof(Agent);
    public const string F3bus = nameof(F3bus);

    public static IEnumerable<string> Values()
    {
        yield return Agent;
        yield return F3bus;
    }
}