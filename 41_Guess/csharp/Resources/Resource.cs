using System.Reflection;
using System.Runtime.CompilerServices;

namespace Guess.Resources;

internal static class Resource
{
    internal static class Streams
    {
        public static Stream Introduction => GetStream();
        public static Stream TooLow => GetStream();
        public static Stream TooHigh => GetStream();
        public static Stream Good => GetStream();
        public static Stream VeryGood => GetStream();
    }

    internal static class Formats
    {
        public static string Thinking => GetString();
        public static string ThatsIt => GetString();
        public static string ShouldHave => GetString();
    }

    internal static class Prompts
    {
        public static string Limit => GetString();
    }

    private static string GetString([CallerMemberName] string? name = null)
    {
        using var stream = GetStream(name);
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    private static Stream GetStream([CallerMemberName] string? name = null) =>
        Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(Resource).Namespace}.{name}.txt")
            ?? throw new Exception($"Could not find embedded resource stream '{name}'.");
}