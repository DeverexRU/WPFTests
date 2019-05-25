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
            //какие-то изменения в коде

            Style buttonStyle = new Style();
            buttonStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            buttonStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(10) });
            buttonStyle.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Colors.Black) });
            buttonStyle.Setters.Add(new Setter { Property = Control.ForegroundProperty, Value = new SolidColorBrush(Colors.White) });
            buttonStyle.Setters.Add(new EventSetter { Event = Button.ClickEvent, Handler = new RoutedEventHandler(button_Click) });
            //При создании сеттера нам надо использовать свойство зависимостей, например, Property = Control.FontFamilyProperty.
            //Причем для свойства Value у сеттера должен быть установлен объект именно того типа, которое хранится в этом свойстве зависимости.


            button1.Style = buttonStyle;
            button2.Style = buttonStyle;


            //Также мы можем загружать словарь динамически в коде C#. Так, загрузим в коде C# вышеопределенный словарь:
            //this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Dictionary1.xaml") };
            //При динамической загрузке, если мы определяем ресурсы через xaml, то они должны быть динамическими:
            //xaml: < Button Content = "OK" MaxHeight = "40" MaxWidth = "80" Background = "{DynamicResource buttonBrush}" />

            ////ручное добавление ресурсов из кода
            // определение объекта-ресурса
            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.GradientStops.Add(new GradientStop(Colors.LightGray, 0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.White, 1));
            // добавление ресурса в словарь ресурсов окна
            this.Resources.Add("buttonGradientBrush", gradientBrush);
            // установка ресурса у кнопки
            button1.Background = (Brush)this.TryFindResource("buttonGradientBrush");
            // или так
            //button1.Background = (Brush)this.Resources["buttonGradientBrush"];
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //dataGrid1.ItemsSource = arrSprav1;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //что-то меняем просто в массиве
            arrSprav1[2].ParamValue = 1.111;
        }

        private void Button1_Click_1(object sender, RoutedEventArgs e)
        {
            var f = new FormUniStyle();
            f.Show();
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
