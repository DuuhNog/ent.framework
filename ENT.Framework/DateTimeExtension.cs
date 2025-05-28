namespace ENT.Framework;

public static class DateTimeExtension
{
    public static DateTime Now
    {
        get
        {
            var standardTime = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, standardTime);
        }
    }
    public static DateTime NowCentralAsiaStandardTime
    {
        get
        {
            var standardTime = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, standardTime);
        }
    }
    public static DateTime NowEasternStandardTime
    {
        get
        {
            var standardTime = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, standardTime);
        }
    }

    public static DateTime NowCentralStandardTime
    {
        get
        {
            var standardTime = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, standardTime);
        }
    }
}