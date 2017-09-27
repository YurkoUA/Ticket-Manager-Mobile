using System;
using Windows.UI.Xaml.Data;

namespace TicketManagerMobile.Converters
{
    public class DateTimeToLocalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is DateTime date)
            {
                if (parameter is string dateFormat)
                    return date.ToLocalTime().ToString(dateFormat);

                throw new ArgumentException("Parameter is not valid");
            }
            throw new ArgumentException("Value is not valid.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is DateTime date)
            {
                return date.ToUniversalTime();
            }
            else if (value is string dateStr)
            {
                return DateTime.Parse(dateStr).ToUniversalTime();
            }

            throw new ArgumentException("Value is not valid.");
        }
    }
}
