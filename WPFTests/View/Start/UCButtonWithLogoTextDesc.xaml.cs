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

namespace WPFTests.View.Start
{
    /// <summary>
    /// Логика взаимодействия для UCButtonWithLogoTextDesc.xaml
    /// </summary>
    public partial class UCButtonWithLogoTextDesc : UserControl
    {
        public UCButtonWithLogoTextDesc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие клика
        /// </summary>
        public event RoutedEventHandler Click;

        /// <summary>
        /// Команда
        /// </summary>
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(null));

        /// <summary>
        /// Размер иконки
        /// </summary>
        public double LogoSize
        {
            get => (double)GetValue(LogoSizeProperty);
            set => SetValue(LogoSizeProperty, value);
        }
        public static readonly DependencyProperty LogoSizeProperty =
           DependencyProperty.Register(nameof(LogoSize), typeof(double), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(30.0));

        /// <summary>
        /// Иконка
        /// </summary>
        public ImageSource LogoSource
        {
            get => (ImageSource)GetValue(LogoSourceProperty);
            set => SetValue(LogoSourceProperty, value);
        }
        public static readonly DependencyProperty LogoSourceProperty =
           DependencyProperty.Register(nameof(LogoSource), typeof(ImageSource), typeof(UCButtonWithLogoTextDesc));

        /// <summary>
        /// Текст на кнопке
        /// </summary>
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly DependencyProperty TextProperty =
          DependencyProperty.Register(nameof(Text), typeof(string), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(""));

        /// <summary>
        /// Описание на кнопке
        /// </summary>
        public string Desc
        {
            get => (string)GetValue(DescProperty);
            set => SetValue(DescProperty, value);
        }
        public static readonly DependencyProperty DescProperty =
          DependencyProperty.Register(nameof(Desc), typeof(string), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(""));

        /// <summary>
        /// Размер шрифта текста
        /// </summary>
        public double TextSize
        {
            get => (double)GetValue(TextSizeProperty);
            set => SetValue(TextSizeProperty, value);
        }
        public static readonly DependencyProperty TextSizeProperty =
           DependencyProperty.Register(nameof(TextSize), typeof(double), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(14.0));

        /// <summary>
        /// Размер шрифта описание
        /// </summary>
        public double DescSize
        {
            get => (double)GetValue(DescSizeProperty);
            set => SetValue(DescSizeProperty, value);
        }
        public static readonly DependencyProperty DescSizeProperty =
           DependencyProperty.Register(nameof(DescSize), typeof(double), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(12.0));


        /// <summary>
        /// Цвет текста
        /// </summary>
        public Brush TextColor
        {
            get => (Brush)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }
        public static readonly DependencyProperty TextColorProperty =
           DependencyProperty.Register(nameof(TextColor), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(Brushes.Black));

        /// <summary>
        /// Цвет описания
        /// </summary>
        public Brush DescColor
        {
            get => (Brush)GetValue(DescColorProperty);
            set => SetValue(DescColorProperty, value);
        }
        public static readonly DependencyProperty DescColorProperty =
           DependencyProperty.Register(nameof(DescColor), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(Brushes.Black));

        /// <summary>
        /// Цвет фона
        /// </summary>
        public new Brush Background
        {
            get => (Brush)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }
        public static new readonly DependencyProperty BackgroundProperty =
           DependencyProperty.Register(nameof(Background), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(Brushes.LightGray));

        /// <summary>
        /// Цвет границ кнопки
        /// </summary>
        public new Brush BorderBrush
        {
            get => (Brush)GetValue(BorderBrushProperty);
            set => SetValue(BorderBrushProperty, value);
        }
        public static new readonly DependencyProperty BorderBrushProperty =
           DependencyProperty.Register(nameof(BorderBrush), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(Brushes.Black));

        #region [ Все что связано с наведением курсора на UC ]

        /// <summary>
        /// Цвет фона при наведении курсора
        /// </summary>
        public Brush SelectColor
        {
            get => (Brush)GetValue(SelectColorProperty);
            set => SetValue(SelectColorProperty, value);
        }
        public static readonly DependencyProperty SelectColorProperty =
           DependencyProperty.Register(nameof(SelectColor), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(Brushes.LightGray));

        /// <summary>
        /// Курсор при наведении
        /// </summary>
        public Cursor SelectCursor
        {
            get => (Cursor)GetValue(SelectCursorProperty);
            set => SetValue(SelectCursorProperty, value);
        }
        public static readonly DependencyProperty SelectCursorProperty =
           DependencyProperty.Register(nameof(SelectCursor), typeof(Cursor), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(Cursors.Arrow));

        /// <summary>
        /// Цвет текста при наведении курсора
        /// </summary>
        public Brush SelectTextColor
        {
            get => (Brush)GetValue(SelectTextColorProperty);
            set => SetValue(SelectTextColorProperty, value);
        }
        public static readonly DependencyProperty SelectTextColorProperty =
           DependencyProperty.Register(nameof(SelectTextColor), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(Brushes.Black));

        /// <summary>
        /// Цвет описания при наведении курсора 
        /// </summary>
        public Brush SelectDescColor
        {
            get => (Brush)GetValue(SelectDescColorProperty);
            set => SetValue(SelectDescColorProperty, value);
        }
        public static readonly DependencyProperty SelectDescColorProperty =
           DependencyProperty.Register(nameof(SelectDescColor), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(Brushes.Black));

        #endregion


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn is Button)
            {
                var grid = btn.Parent as Grid;
                if (grid is Grid)
                {
                    var UC = grid.Parent as UCButtonWithLogoTextDesc;
                    if (UC is UCButtonWithLogoTextDesc)
                    {
                        Click?.Invoke(UC, e);
                        Command?.Execute(null);
                    }

                }
            }
        }
    }
}
