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

namespace WPFTests.View
{
    /// <summary>
    /// Логика взаимодействия для UCHeaderAbout.xaml
    /// </summary>
    public partial class UCHeaderAbout : UserControl
    {
        public UCHeaderAbout()
        {
            InitializeComponent();
            ImgLogo.DataContext = this;
        }
        
        public string LogoSource { set; get; }
    }
}
