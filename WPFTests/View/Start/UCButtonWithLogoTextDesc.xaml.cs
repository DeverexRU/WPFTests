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
        #region [ Значения по умолчанию для свойств UC ]

        private static double _defaultLogoSize = 0.0;
        private static Cursor _defaultCursor = Cursors.Arrow;
        private static Clickable _defaultClickablePlace = Clickable.AllPlace;

        private static Brush _defaultBackgroundUC = Brushes.LightGray;
        private static Brush _defaultBorderBrushUC = Brushes.Black;
        private static Brush _defaultSelectBackgroundUC = Brushes.SkyBlue;
        private static Brush _defaultClickBackgroundUC = Brushes.DeepSkyBlue;

        private static double _defaultTextFontSize = 14.0;
        private static Brush _defaultTextForeground = Brushes.Black;
        private static FontWeight _defaultTextFontWeight = FontWeights.Medium;

        private static double _defaultDescFontSize = 12.0;
        private static Brush _defaultDescForeground = Brushes.Black;
        private static FontWeight _defaultDescFontWeight = FontWeights.Normal;

        #endregion

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
                        if ((_curPlaceCursor & ClickablePlace) > 0)
                        {
                            Click?.Invoke(UC, e);
                            Command?.Execute(null);
                        }
                    }

                }
            }
        }

        #region [ Стандартный вид ]

        /// <summary>
        /// Размер логотипа
        /// </summary>
        public double LogoSize
        {
            get => (double)GetValue(LogoSizeProperty);
            set => SetValue(LogoSizeProperty, value);
        }
        public static readonly DependencyProperty LogoSizeProperty =
           DependencyProperty.Register(nameof(LogoSize), typeof(double), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultLogoSize));

        /// <summary>
        /// Логотип
        /// </summary>
        public ImageSource LogoSource
        {
            get => (ImageSource)GetValue(LogoSourceProperty);
            set => SetValue(LogoSourceProperty, value);
        }
        public static readonly DependencyProperty LogoSourceProperty =
           DependencyProperty.Register(nameof(LogoSource), typeof(ImageSource), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(null));

        /// <summary>
        /// Цвет фона
        /// </summary>
        public new Brush Background
        {
            get => (Brush)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }
        public static new readonly DependencyProperty BackgroundProperty =
           DependencyProperty.Register(nameof(Background), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultBackgroundUC));

        /// <summary>
        /// Цвет границ кнопки
        /// </summary>
        public new Brush BorderBrush
        {
            get => (Brush)GetValue(BorderBrushProperty);
            set => SetValue(BorderBrushProperty, value);
        }
        public static new readonly DependencyProperty BorderBrushProperty =
           DependencyProperty.Register(nameof(BorderBrush), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultBorderBrushUC));

        #region [ Text ]

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
        /// Размер шрифта текста
        /// </summary>
        public double TextFontSize
        {
            get => (double)GetValue(TextFontSizeProperty);
            set => SetValue(TextFontSizeProperty, value);
        }
        public static readonly DependencyProperty TextFontSizeProperty =
           DependencyProperty.Register(nameof(TextFontSize), typeof(double), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultTextFontSize));

        /// <summary>
        /// Цвет текста
        /// </summary>
        public Brush TextForeground
        {
            get => (Brush)GetValue(TextForegroundProperty);
            set => SetValue(TextForegroundProperty, value);
        }
        public static readonly DependencyProperty TextForegroundProperty =
           DependencyProperty.Register(nameof(TextForeground), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultTextForeground));

        /// <summary>
        /// Декор текста 
        /// </summary>
        public TextDecorationCollection TextDecoration
        {
            get => (TextDecorationCollection)GetValue(TextDecorationProperty);
            set => SetValue(TextDecorationProperty, value);
        }
        public static readonly DependencyProperty TextDecorationProperty =
           DependencyProperty.Register(nameof(TextDecoration), typeof(TextDecorationCollection), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(null));

        /// <summary>
        /// Насыщенность текста 
        /// </summary>
        public FontWeight TextFontWeight
        {
            get => (FontWeight)GetValue(TextDecorationProperty);
            set => SetValue(TextDecorationProperty, value);
        }
        public static readonly DependencyProperty TextFontWeightProperty =
           DependencyProperty.Register(nameof(TextFontWeight), typeof(FontWeight), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultTextFontWeight));

        #endregion

        #region [ Desc ]

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
        /// Размер шрифта описание
        /// </summary>
        public double DescFontSize
        {
            get => (double)GetValue(DescFontSizeProperty);
            set => SetValue(DescFontSizeProperty, value);
        }
        public static readonly DependencyProperty DescFontSizeProperty =
           DependencyProperty.Register(nameof(DescFontSize), typeof(double), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultDescFontSize));

        /// <summary>
        /// Цвет описания
        /// </summary>
        public Brush DescForeground
        {
            get => (Brush)GetValue(DescForegroundProperty);
            set => SetValue(DescForegroundProperty, value);
        }
        public static readonly DependencyProperty DescForegroundProperty =
           DependencyProperty.Register(nameof(DescForeground), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultDescForeground));

        /// <summary>
        /// Декор описания 
        /// </summary>
        public TextDecorationCollection DescDecoration
        {
            get => (TextDecorationCollection)GetValue(DescDecorationProperty);
            set => SetValue(DescDecorationProperty, value);
        }
        public static readonly DependencyProperty DescDecorationProperty =
           DependencyProperty.Register(nameof(DescDecoration), typeof(TextDecorationCollection), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(null));

        /// <summary>
        /// Насыщенность описания
        /// </summary>
        public FontWeight DescFontWeight
        {
            get => (FontWeight)GetValue(DescDecorationProperty);
            set => SetValue(DescDecorationProperty, value);
        }
        public static readonly DependencyProperty DescFontWeightProperty =
           DependencyProperty.Register(nameof(DescFontWeight), typeof(FontWeight), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultDescFontWeight));

        #endregion

        #endregion

        #region [ Вид при наведении курсора на UC ]

        /// <summary>
        /// Цвет фона при наведении курсора
        /// </summary>
        public Brush SelectBackground
        {
            get => (Brush)GetValue(SelectBackgroundProperty);
            set => SetValue(SelectBackgroundProperty, value);
        }
        public static readonly DependencyProperty SelectBackgroundProperty =
           DependencyProperty.Register(nameof(SelectBackground), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultSelectBackgroundUC));

        /// <summary>
        /// Курсор при наведении
        /// </summary>
        public Cursor SelectCursor
        {
            get => (Cursor)GetValue(SelectCursorProperty);
            set => SetValue(SelectCursorProperty, value);
        }
        public static readonly DependencyProperty SelectCursorProperty =
           DependencyProperty.Register(nameof(SelectCursor), typeof(Cursor), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultCursor));

        /// <summary>
        /// Цвет текста при наведении курсора
        /// </summary>
        public Brush SelectTextForeground
        {
            get => (Brush)GetValue(SelectTextForegroundProperty);
            set => SetValue(SelectTextForegroundProperty, value);
        }
        public static readonly DependencyProperty SelectTextForegroundProperty =
           DependencyProperty.Register(nameof(SelectTextForeground), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultTextForeground));

        /// <summary>
        /// Цвет описания при наведении курсора 
        /// </summary>
        public Brush SelectDescForeground
        {
            get => (Brush)GetValue(SelectDescForegroundProperty);
            set => SetValue(SelectDescForegroundProperty, value);
        }
        public static readonly DependencyProperty SelectDescForegroundProperty =
           DependencyProperty.Register(nameof(SelectDescForeground), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultDescForeground));

        /// <summary>
        /// Декор текста при наведении курсора 
        /// </summary>
        public TextDecorationCollection SelectTextDecoration
        {
            get => (TextDecorationCollection)GetValue(SelectTextDecorationProperty);
            set => SetValue(SelectTextDecorationProperty, value);
        }
        public static readonly DependencyProperty SelectTextDecorationProperty =
           DependencyProperty.Register(nameof(SelectTextDecoration), typeof(TextDecorationCollection), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(null));

        /// <summary>
        /// Декор описания при наведении курсора 
        /// </summary>
        public TextDecorationCollection SelectDescDecoration
        {
            get => (TextDecorationCollection)GetValue(SelectDescDecorationProperty);
            set => SetValue(SelectDescDecorationProperty, value);
        }
        public static readonly DependencyProperty SelectDescDecorationProperty =
           DependencyProperty.Register(nameof(SelectDescDecoration), typeof(TextDecorationCollection), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(null));

        #endregion

        #region [ Вид при нажатии мыши на UC ]

        /// <summary>
        /// Цвет фона при нажатии
        /// </summary>
        public Brush ClickBackground
        {
            get => (Brush)GetValue(ClickBackgroundProperty);
            set => SetValue(ClickBackgroundProperty, value);
        }
        public static readonly DependencyProperty ClickBackgroundProperty =
           DependencyProperty.Register(nameof(ClickBackground), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultClickBackgroundUC));

        /// <summary>
        /// Цвет текста при нажатии
        /// </summary>
        public Brush ClickTextForeground
        {
            get => (Brush)GetValue(ClickTextForegroundProperty);
            set => SetValue(ClickTextForegroundProperty, value);
        }
        public static readonly DependencyProperty ClickTextForegroundProperty =
           DependencyProperty.Register(nameof(ClickTextForeground), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultTextForeground));

        /// <summary>
        /// Цвет описания при нажатии
        /// </summary>
        public Brush ClickDescForeground
        {
            get => (Brush)GetValue(ClickDescForegroundProperty);
            set => SetValue(ClickDescForegroundProperty, value);
        }
        public static readonly DependencyProperty ClickDescForegroundProperty =
           DependencyProperty.Register(nameof(ClickDescForeground), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultDescForeground));

        #endregion

        #region [ Вид элементов при наведении курсора именно на них]

        /// <summary>
        /// Цвет текста при наведении курсора
        /// </summary>
        public Brush SelectOnlyTextForeground
        {
            get => (Brush)GetValue(SelectOnlyTextForegroundProperty);
            set => SetValue(SelectOnlyTextForegroundProperty, value);
        }
        public static readonly DependencyProperty SelectOnlyTextForegroundProperty =
           DependencyProperty.Register(nameof(SelectOnlyTextForeground), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultTextForeground));

        /// <summary>
        /// Цвет описания при наведении курсора
        /// </summary>
        public Brush SelectOnlyDescForeground
        {
            get => (Brush)GetValue(SelectOnlyDescForegroundProperty);
            set => SetValue(SelectOnlyDescForegroundProperty, value);
        }
        public static readonly DependencyProperty SelectOnlyDescForegroundProperty =
           DependencyProperty.Register(nameof(SelectOnlyDescForeground), typeof(Brush), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultDescForeground));

        /// <summary>
        /// Тип курсора при наведении на текст
        /// </summary>
        public Cursor SelectOnlyTextCursor
        {
            get => (Cursor)GetValue(SelectOnlyTextCursorProperty);
            set => SetValue(SelectOnlyTextCursorProperty, value);
        }
        public static readonly DependencyProperty SelectOnlyTextCursorProperty =
           DependencyProperty.Register(nameof(SelectOnlyTextCursor), typeof(Cursor), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultCursor));

        /// <summary>
        /// Тип курсора при наведении на описание
        /// </summary>
        public Cursor SelectOnlyDescCursor
        {
            get => (Cursor)GetValue(SelectOnlyDescCursorProperty);
            set => SetValue(SelectOnlyDescCursorProperty, value);
        }
        public static readonly DependencyProperty SelectOnlyDescCursorProperty =
           DependencyProperty.Register(nameof(SelectOnlyDescCursor), typeof(Cursor), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultCursor));

        /// <summary>
        /// Декор текста при наведении курсора на текст
        /// </summary>
        public TextDecorationCollection SelectOnlyTextDecoration
        {
            get => (TextDecorationCollection)GetValue(SelectOnlyTextDecorationProperty);
            set => SetValue(SelectOnlyTextDecorationProperty, value);
        }
        public static readonly DependencyProperty SelectOnlyTextDecorationProperty =
           DependencyProperty.Register(nameof(SelectOnlyTextDecoration), typeof(TextDecorationCollection), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(null));

        /// <summary>
        /// Декор описания при наведении курсора на описание 
        /// </summary>
        public TextDecorationCollection SelectOnlyDescDecoration
        {
            get => (TextDecorationCollection)GetValue(SelectOnlyDescDecorationProperty);
            set => SetValue(SelectOnlyDescDecorationProperty, value);
        }
        public static readonly DependencyProperty SelectOnlyDescDecorationProperty =
           DependencyProperty.Register(nameof(SelectOnlyDescDecoration), typeof(TextDecorationCollection), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(null));

        /// <summary>
        /// Тип курсора при наведении на логотип
        /// </summary>
        public Cursor SelectOnlyLogoCursor
        {
            get => (Cursor)GetValue(SelectOnlyLogoCursorProperty);
            set => SetValue(SelectOnlyLogoCursorProperty, value);
        }
        public static readonly DependencyProperty SelectOnlyLogoCursorProperty =
           DependencyProperty.Register(nameof(SelectOnlyLogoCursor), typeof(Cursor), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultCursor));

        #endregion


        /// <summary>
        /// Вычисление начальных значений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCBtn_Loaded(object sender, RoutedEventArgs e)
        {
            LogoSize = LogoSource == null ? 0.0 : 30.0;
            DescFontSize = Desc == "" ? 0.1 : DescFontSize;
            TextFontSize = Text == "" ? 0.1 : TextFontSize;

            SelectTextDecoration = SelectTextDecoration == null ? TextDecoration : SelectTextDecoration;
            SelectOnlyTextDecoration = SelectOnlyTextDecoration == null ? SelectTextDecoration : SelectOnlyTextDecoration;

            SelectDescDecoration = SelectDescDecoration == null ? DescDecoration : SelectDescDecoration;
            SelectOnlyDescDecoration = SelectOnlyDescDecoration == null ? SelectDescDecoration : SelectOnlyDescDecoration;


            SelectTextForeground = SelectTextForeground == _defaultTextForeground ? TextForeground : SelectTextForeground;
            ClickTextForeground = ClickTextForeground == _defaultTextForeground ? SelectTextForeground : ClickTextForeground;
            SelectOnlyTextForeground = SelectOnlyTextForeground == _defaultTextForeground ? SelectTextForeground : SelectOnlyTextForeground;

            SelectDescForeground = SelectDescForeground == _defaultDescForeground ? DescForeground : SelectDescForeground;
            ClickDescForeground = ClickDescForeground == _defaultDescForeground ? SelectDescForeground : ClickDescForeground;
            SelectOnlyDescForeground = SelectOnlyDescForeground == _defaultDescForeground ? SelectDescForeground : SelectOnlyDescForeground;


            SelectOnlyTextCursor = SelectOnlyTextCursor == _defaultCursor ? SelectCursor : SelectOnlyTextCursor;
            SelectOnlyDescCursor = SelectOnlyDescCursor == _defaultCursor ? SelectCursor : SelectOnlyDescCursor;
            SelectOnlyLogoCursor = SelectOnlyLogoCursor == _defaultCursor ? SelectCursor : SelectOnlyLogoCursor;

        }



        #region [ Доступные области для нажатия ]

        public enum Clickable
        {
            Nothing = 0b0000,
            AllPlace = 0b1111,   // Включая пустое место между элементами
            Logo = 0b0001,
            Text = 0b0010,
            Desc = 0b0100,
            LogoText = 0b0011,
            LogoDesc = 0b0101,
            TextDesc = 0b0110,
            LogoTextDesc = 0b0111
        }

        private Clickable _curPlaceCursor;

        /// <summary>
        /// Режим доступных для нажатия областей
        /// </summary>
        public Clickable ClickablePlace
        {
            get => (Clickable)GetValue(ClickablePlaceProperty);
            set => SetValue(ClickablePlaceProperty, value);
        }
        public static readonly DependencyProperty ClickablePlaceProperty =
           DependencyProperty.Register(nameof(ClickablePlace), typeof(Clickable), typeof(UCButtonWithLogoTextDesc), new PropertyMetadata(_defaultClickablePlace));

        #endregion

        private void Element_MouseEnter(object sender, MouseEventArgs e)
        {
            var t = sender as FrameworkElement; 
            if (t is FrameworkElement)
            {
                int tag = Convert.ToInt16(t.Tag);
                switch (tag)
                {
                    case 0:
                        _curPlaceCursor = Clickable.Logo;
                        break;
                    case 1:
                        _curPlaceCursor = Clickable.Text;
                        break;
                    case 2:
                        _curPlaceCursor = Clickable.Desc;
                        break;
                }
                
            }
        }

        private void Element_MouseLeave(object sender, MouseEventArgs e)
        {
            
            _curPlaceCursor = Clickable.AllPlace;
            
        }
    }
}
