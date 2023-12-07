public static class Debugger
{
    public static void Assert(object left, object right)
    {
        if (!left.Equals(right))
        {
            throw new AssertionException($"Assertion failed: {nameof(left)} is not {nameof(right)}. {left} != {right}");
        }
    }
    protected class AssertionException(string message) : Exception(message)
    {
    }
}