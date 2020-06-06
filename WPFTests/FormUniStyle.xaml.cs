using System;
using System.Collections.Generic;
using System.IO;
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
using WpfMath;

namespace WPFTests
{
    /// <summary>
    /// Логика взаимодействия для FormUniStyle.xaml
    /// </summary>
    public partial class FormUniStyle : Window
    {
        public FormUniStyle()
        {
            InitializeComponent();
        }

        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            //const string latex = @"\left(x^2 + 2 \cdot x + 2\right) = 0 \frac{2+2}{2} \text{Русские ЛаТеХ}";
            const string latex = @"\frac{Wt}{m ^{\circ} C}";
            // \text{Русские ЛаТеХ}
            const string fileName = @"D:\ProjectsVS2017\WPFTests\latex_out";

            var parser = new TexFormulaParser();
            var formula = parser.Parse(latex);
//            var pngBytes = formula.RenderToPng(20.0, 0.0, 0.0, "Arial");
            var pngBytes = formula.RenderToPng(20.0, 0.0, 0.0, "Cambria Math");
            File.WriteAllBytes(fileName, pngBytes);
        }

        private void LaTeX_to_File(string latex, string fileName)
        {
            var parser = new TexFormulaParser();
            var formula = parser.Parse(latex);
            var renderer = formula.GetRenderer(TexStyle.Display, 25.0, "Cambria Math"); // Math
            //var renderer = formula.GetRenderer(TexStyle.Display, 25.0, "Arial"); // Math
            var bitmapSource = renderer.RenderToBitmap(0.0, 0.0);
            //Console.WriteLine($"Image width: {bitmapSource.Width}");
            //Console.WriteLine($"Image height: {bitmapSource.Height}");

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
            using (var target = new FileStream(fileName, FileMode.Create))
            {
                encoder.Save(target);
                //Console.WriteLine($"File saved to {fileName}");
            }
        }

        private void Button02_Click(object sender, RoutedEventArgs e)
        {
            //const string latex = @"\left(x^2 + 2 \cdot x + 2\right) = 0 \frac{2+2}{2} \text{Русские ЛаТеХ}";
            //const string fileNamePrefix = @"D:\Temp\formula2.png";
            const string fileNamePrefix = @"D:\ProjectsVS2017\WPFTests\latex_out\";

            LaTeX_to_File(@"T_{0}", fileNamePrefix + "001.png");
            LaTeX_to_File(@"T_{bf}", fileNamePrefix + "002.png");
            LaTeX_to_File(@"\lambda_{f}", fileNamePrefix + "003.png");
            LaTeX_to_File(@"\lambda_{th}", fileNamePrefix + "004.png");
            LaTeX_to_File(@"C_{f}", fileNamePrefix + "005.png");
            LaTeX_to_File(@"C_{th}", fileNamePrefix + "006.png");

            LaTeX_to_File(@"\frac{\text{Дж}}{{{\text{м}}^3}}", fileNamePrefix + "007.png");
            LaTeX_to_File(@"\cdot^{\circ}", fileNamePrefix + "008.png");
            LaTeX_to_File(@"\circ", fileNamePrefix + "009.png");
            LaTeX_to_File(@"\text{C}", fileNamePrefix + "010.png");
            LaTeX_to_File(@"\frac{\text{Вт}}{ {{\text{м}}^2} {\cdot}^{\circ} {\text{C}} }", fileNamePrefix + "011.png");
        }
    }
}
