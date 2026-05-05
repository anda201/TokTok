using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace TokTok.Converters
{
    public class WindowStateMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            WindowState state = (WindowState)value;
            if (state == WindowState.Normal)
            {
                // 윈도우 창이 최대화되지 않았을 때는 여백이 필요 없으므로 0으로 설정
                return new Thickness(0);
            }
            else
            {
                var param = (string)parameter;
                var right = param == "Exit" ? 7 : 0;
                // 윈도우 창이 최대화되었을 때는 상단에 여백을 추가
                return new Thickness(0,7,right,0);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
