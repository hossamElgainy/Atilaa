namespace Core.Enums
{
    public static class EnumExtensions
    {
        public static T? ToEnum<T>(this string? value, bool ignoreCase = true)
            where T : struct, Enum
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            return Enum.TryParse<T>(value, ignoreCase, out var result)
                ? result
                : null;
        }
    }
    }
