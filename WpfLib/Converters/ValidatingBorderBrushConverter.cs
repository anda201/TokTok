using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfLib.Converters
{
    public class ValidatingBorderBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? isValidation = values[0] as bool?;
            // 디자이너에서 null이 들어올 수 있기 때문에 null 체크를 해준다.
            if (isValidation != null && isValidation == true)
            {
                return Brushes.Red;
            }
            else
            {
                return (Brush)values[1];
            }
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}       
