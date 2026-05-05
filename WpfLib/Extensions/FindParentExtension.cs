using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfLib.Extensions
{
    public static class FindParentExtension
    {
        //name이 없는 부모 요소를 찾는 확장 메서드 오버로드
        public static T FindParent<T>(this DependencyObject child)
            where T : DependencyObject
        {
            return FindParent<T>(child, null);
        }

        //부모 요소를 찾는 확장 메서드
        public static T FindParent<T>(this DependencyObject child, string? parentName)
            where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);
            if (parent == null) return null;

            //DependencyObject는 Name 속성을 가지지 않으므로 FrameworkElement 타입으로 캐스팅하여 Name 속성을 확인
            var frameworkElement = (FrameworkElement)parent;
            if ((parentName == null || frameworkElement.Name == parentName) && frameworkElement is T)
            {
                return (T)parent;
            }
            else
            {
                return FindParent<T>(parent, parentName);
            }
        }
    }
}
