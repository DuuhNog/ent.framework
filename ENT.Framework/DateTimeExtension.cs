namespace ENT.Framework;

public static class DateTimeExtension
{
    public static DateTime Now
    {
        get
        {
            TimeZoneInfo Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Standard_Time);
        }
    }
    public static DateTime NowCentralAsiaStandardTime
    {
        get
        {
            TimeZoneInfo Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Standard_Time);
        }
    }
    public static DateTime NowEasternStandardTime
    {
        get
        {
            TimeZoneInfo Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Standard_Time);
        }
    }

    public static DateTime NowCentralStandardTime
    {
        get
        {
            TimeZoneInfo Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Standard_Time);
        }
    }
}