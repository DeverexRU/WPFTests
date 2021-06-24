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
using System.Windows.Shapes;
using WPFTests.ViewModel;

namespace WPFTests
{
    /// <summary>
    /// Логика взаимодействия для FormAbout.xaml
    /// </summary>
    public partial class FormAbout : Window
    {
        public FormAbout()
        {
            InitializeComponent();

            DataContext = new VMF_FormAbout();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
                this.DialogResult = false;
        }
    }
}
