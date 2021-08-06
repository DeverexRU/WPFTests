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

namespace WPFTests.View.About
{
    /// <summary>
    /// Логика взаимодействия для UCImageButton.xaml
    /// </summary>
    public partial class UCImageButton : UserControl
    {
        public event RoutedEventHandler Click;

        public UCImageButton()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Текст на кнопке
        /// </summary>
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly DependencyProperty TextProperty =
          DependencyProperty.Register("Text", typeof(string), typeof(UCImageButton), new UIPropertyMetadata(""));

        /// <summary>
        /// Иконка
        /// </summary>
        public ImageSource Image
        {
            get => (ImageSource)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        public static readonly DependencyProperty ImageProperty =
           DependencyProperty.Register("Image", typeof(ImageSource), typeof(UCImageButton), new UIPropertyMetadata(null));

        /// <summary>
        /// Размер иконки
        /// </summary>
        public double ImageSize
        {
            get => (double)GetValue(ImageSizeProperty);
            set => SetValue(ImageSizeProperty, value);
        }

        public static readonly DependencyProperty ImageSizeProperty =
           DependencyProperty.Register("ImageSize", typeof(double), typeof(UCImageButton), new UIPropertyMetadata(null));



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn is Button)
            {
                var grid = btn.Parent as Grid;
                if (grid is Grid)
                {
                    var UC = grid.Parent as UCImageButton;
                    if (UC is UCImageButton)
                        Click?.Invoke(UC, e);
                }
            }
            
        }
    }
}
