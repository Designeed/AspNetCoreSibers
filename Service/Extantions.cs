namespace AspNetCoreSibers.Service
{
    public static class Extantions
    {
        public static string RemoveController(this string str)
            => str.Replace("Controller", String.Empty, StringComparison.OrdinalIgnoreCase);
    }
}
