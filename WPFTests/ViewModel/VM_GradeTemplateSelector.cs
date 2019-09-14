using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFTests.ViewModel
{
    /// <summary>
    /// Класс для селектора содержимого ячейки таблицы
    /// </summary>
    public class VM_GradeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TemplateString { get; set; }
        public DataTemplate TemplateDouble { get; set; }
        public DataTemplate TemplateList_UrovOtv { get; set; }
        public DataTemplate TemplateList_gKind { get; set; }
        public DataTemplate TemplateList_gTorfy { get; set; }
        public DataTemplate TemplateList_SaltType { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            VM_IGEParameter v = item as VM_IGEParameter;

            if (v != null)
            {
                switch (v.VPropType)
                {
                    case 1:
                        return TemplateDouble;
                    case 2:
                        return TemplateList_UrovOtv;
                    case 3:
                        return TemplateList_gKind;
                    default:
                        return TemplateString;
                }
            }
            else
            {
                return base.SelectTemplate(item, container);
            }
        }
    }
}
