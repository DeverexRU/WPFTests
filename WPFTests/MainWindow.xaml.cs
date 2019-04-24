using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTests
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Sprav1> arrSprav1 = new List<Sprav1>
        {
            new Sprav1 { ParamName ="paramName1", ParamDiscription = "Описание параметра 1",ParamMeasure="кг", ParamValue=0.123 },
            new Sprav1 { ParamName ="paramName2", ParamDiscription = "Описание параметра 2",ParamMeasure="м", ParamValue=0.123 },
            new Sprav1 { ParamName ="paramName3", ParamDiscription = "Описание параметра 3",ParamMeasure="см", ParamValue=0.123 },
            new Sprav1 { ParamName ="paramName4", ParamDiscription = "Описание параметра 4",ParamMeasure="грд", ParamValue=0.123 },
            new Sprav1 { ParamName ="paramName5", ParamDiscription = "Описание параметра 5",ParamMeasure="лк", ParamValue=0.123 }
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid1.ItemsSource = arrSprav1;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //что-то меняем просто в массиве
            arrSprav1[2].ParamValue = 1.111;
        }
    }

    public class Sprav1
    {
        public string ParamName { get; set; }
        public string ParamDiscription { get; set; }
        public string ParamMeasure { get; set; }
        public double ParamValue { get; set; }
    }

}
