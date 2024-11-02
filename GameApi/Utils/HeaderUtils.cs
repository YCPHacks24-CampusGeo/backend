using System.Diagnostics.CodeAnalysis;

namespace GameApi.Utils;

public class HeaderUtils
{
    public const string XGameStateId = "X-Game-State-Id";
    public const string XGameId = "X-Game-Id";

    public static bool TryGetHeader(HttpRequest request, string name, [NotNullWhen(true)] out string? result)
    {
        result = null;

        if (request.Headers.TryGetValue(name, out var value))
        {
            if (!string.IsNullOrEmpty(value))
            {
                result = value!;
                return true;
            }
        }

        return false;
    }

    public static void AddHeader(HttpResponse response, string name, string value)
    {
        response.Headers.Append(name, value);
    }
}
