namespace LogsService.Common.Extensions
{
    public static class StringExtensions
    {
        public static int GetValidRunInterval(this string value)
        {
            int.TryParse(value, out var runInterval);
            return runInterval;
        }
    }
}
