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
            int SliderValue = System.Convert.ToInt32(value);
            if (SliderValue <= 25)
            {
                return "SMALL";
            }
            else if ((SliderValue > 25) && (SliderValue <= 50))
            {
                return "MEDIUM";
            }
            else if ((SliderValue > 50) && (SliderValue < 75))
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
