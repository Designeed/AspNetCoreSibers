﻿namespace AspNetCoreSibers.Service.Shared
{
    public static class Extantions
    {
        public static string RemoveController(this string str)
            => str.Replace("Controller", string.Empty, StringComparison.OrdinalIgnoreCase);
    }
}