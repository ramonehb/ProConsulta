using System.Text.RegularExpressions;

namespace ProConsulta.Extensions;

public static class StringExtensions
{
    public static string SomenteCarecteres(this string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return input;

        var expressaoRegular = @"[-\.\(\)\s]";

        var resultado = Regex.Replace(input, expressaoRegular, string.Empty);

        return resultado;
    }
}

