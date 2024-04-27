namespace App.core.Extensions;

public static class DateExtensions
{

    public static DateOnly ToDateOnly(this DateTime date)
        => new(date.Year, date.Month, date.Day);

    public static DateOnly ToDateOnly(this DateTime? date)
        => date.HasValue ? new DateOnly(date.Value.Year, date.Value.Month, date.Value.Day) : new DateOnly();


}
