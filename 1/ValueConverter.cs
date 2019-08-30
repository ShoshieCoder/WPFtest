using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFtest._1
{
    public class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int val = System.Convert.ToInt32(value);
            if (val <= 25)
            {
                return "SMALL";
            }
            else if ((val > 25) && (val <= 50))
            {
                return "MEDIUM";
            }
            else if ((val > 50) && (val < 75))
            {
                return "LARGE";
            }
            return "EXTRA LARGE";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
