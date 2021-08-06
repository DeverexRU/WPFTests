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
    /// Логика взаимодействия для UCHeaderAbout.xaml
    /// </summary>
    public partial class UCHeaderAbout : UserControl
    {
        public UCHeaderAbout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Иконка
        /// </summary>
        public ImageSource Image
        {
            get => (ImageSource)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        public static readonly DependencyProperty ImageProperty =
           DependencyProperty.Register("Image", typeof(ImageSource), typeof(UCHeaderAbout), new UIPropertyMetadata(null));


        /// <summary>
        /// Размер иконки
        /// </summary>
        public double ImageSize
        {
            get => (double)GetValue(ImageSizeProperty);
            set => SetValue(ImageSizeProperty, value);
        }

        public static readonly DependencyProperty ImageSizeProperty =
           DependencyProperty.Register("ImageSize", typeof(double), typeof(UCHeaderAbout), new UIPropertyMetadata(null));
    }
}
