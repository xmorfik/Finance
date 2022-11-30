using Finance.WebApi.Exceptions;
using System.Globalization;
using System.Reflection;

namespace Finance.WebApi.Helpers;

public record DateBinder(DateOnly Date)
{
    public static DateBinder? TryParse(string input)
    {
        try
        {
            var dateTime = DateTime.ParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var dateOnly = DateOnly.FromDateTime(dateTime);
            return new DateBinder(dateOnly);
        }
        catch 
        {
            throw new WrongDateFormatException("Wrong date format, expected: dd.MM.yyyy");
        }
    }

    public static async ValueTask<DateBinder?> BindAsync(HttpContext context, ParameterInfo parameter)
    {
        var input = context.GetRouteValue(parameter.Name!) as string ?? string.Empty;
        return TryParse(input);
    }
}
