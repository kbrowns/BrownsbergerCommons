using System;

public static class ObjectExtensions
{
    public static T CheckForNullArg<T>(this T obj, string argumentName) where T : class
    {
        return CheckForNull(obj, () => new ArgumentNullException(argumentName));
    }

    public static T CheckForNull<T>(this T obj, Func<Exception> exceptionProvider = null) where T : class
    {
        if (exceptionProvider == null)
            exceptionProvider = () => new NullReferenceException(string.Format("The supplied {0} instace was null when null was not expected.", typeof(T).FullName));

        if (obj == null)
            throw exceptionProvider();

        return obj;
    }

    public static string CheckForNullOrEmptyArg(this string obj, string argumentName)
    {
        if (!string.IsNullOrEmpty(obj))
            return obj;

        throw new ArgumentNullException(argumentName);
    }
}