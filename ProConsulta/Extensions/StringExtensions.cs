using System.Text.RegularExpressions;

namespace ProConsulta.Extensions;

public static class StringExtensions
{
    public static string SomenteCarecteres(this string inpunt)
    {
        if (string.IsNullOrWhiteSpace(inpunt)) return inpunt;

        string padrao = @"[-\.\(\)\s]";

        string resultado = Regex.Replace(inpunt, padrao, string.Empty);

        return resultado;
    }
}

