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
using WPFTests.View;
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
            _UCs = new List<UserControl>() 
            { 
                new UCAuthors(), 
                new UCLicenseText(), 
                new UCLicenseDetails(), 
                new UCCertificates(), 
                new UCSupportContacts() 
            };

            

            InitializeComponent();

            currentUC.Content = _UCs[0];

            DataContext = new VMF_FormAbout();
        }

        /// <summary>
        /// Список переключаемых UserControl-ов
        /// </summary>
        private List<UserControl> _UCs;

        private void ButtonTab_Click(object sender, RoutedEventArgs e)
        {
            var uc = sender as UCImageButton;
            if (uc is UCImageButton)
            {
                string tag = uc.Tag.ToString();
                if (tag is string)
                {
                    int ind = Convert.ToInt16(tag);
                    currentUC.Content = _UCs[ind];
                }
            }

        
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
