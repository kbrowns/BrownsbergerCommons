public static class StringExtensions
{
    public static string FormatWith(this string expression, params object[] args)
    {
        if (expression == null || args == null || args.Length < 1)
            return expression;

        return string.Format(expression, args);
    }
}