namespace LogsService.Common.Extensions
{
    public static class StringExtensions
    {
        public static int GetValidRunInterval(this string value)
        {
            if (value == null) return 0;
            int.TryParse(value, out var runInterval);
            return runInterval;
        }
    }
}
