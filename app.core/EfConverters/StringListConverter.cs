using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aimo.Data.Converters;

public class StringListConverter : ValueConverter<List<string>, string>
{
    public StringListConverter() : base(
        toString => string.Join(",", toString),
        toList => toList.Split(',', StringSplitOptions.None).ToList())
    { }

}