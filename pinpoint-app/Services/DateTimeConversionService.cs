using System.Globalization;

namespace pinpoint_app.Services
{
    class DateTimeConversionService
    // This class provides methods to convert date and time strings into a more readable and better-looking format.
    {
        public static string FormatDateAndTime(string date, string time)
        // Takes a date and time string and combines them into a single string
        {
            try
            {
                var combined = DateTime.ParseExact($"{date} {time}", "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
                return combined.ToString("f"); // e.g., "Saturday, April 19, 2025 10:00 AM"
            }
            catch (FormatException)
            {
                return $"{date} {time}"; // fallback if parsing fails
            }
        }

        public static string FormatTime(string time) { 
        // Takes a time string and converts it into a single string  
            try
            {
                var parsedTime = DateTime.ParseExact(time, "HH:mm:ss", CultureInfo.InvariantCulture); // uses the user's current culture to parse the time into their local time format. 
                return parsedTime.ToString("h:mm tt"); // e.g., "5:00 PM"
            }
            catch (FormatException)
            {
                return time;
            }
        }
    }
}
