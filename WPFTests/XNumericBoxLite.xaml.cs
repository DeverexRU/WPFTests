using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibASPIRCore.Views.XUserControls
{
    /// <summary>
    /// Логика взаимодействия для XNumericBoxLite.xaml
    /// </summary>
    public partial class XNumericBoxLite : UserControl, IDataErrorInfo
    {
        public XNumericBoxLite()
        {            
            InitializeComponent();
            //DataContext = this;// new VM_XNumericBoxLite(); TO DELETE
            //Если элемент управления зависит от какой-либо VM или тесно связан / зависит
            //от того, помещен ли он в определенный контекст для работы, то он не является «элементом управления».
            //Вы нарушили принцип разделения интересов.
        }

        /// <summary>
        /// Статический конструктор для регистрации свойств зависимостей и маршрутизируемых событий
        /// </summary>
        static XNumericBoxLite()
        {
            // Регистрация события ValueChanged
            ValueChangedLightEvent = EventManager.RegisterRoutedEvent(
                    "ValueChangedLight", RoutingStrategy.Bubble,
                    typeof(RoutedEventHandler), typeof(XNumericBoxLite));

            // Регистрация события ValueStringChanged
            ValueStringChangedEvent = EventManager.RegisterRoutedEvent(
                    "ValueStringChanged", RoutingStrategy.Bubble,
                    typeof(RoutedEventHandler), typeof(XNumericBoxLite));
        }

        #region [ Свойства зависимостей элемента ]

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value);}
        }

        public static readonly DependencyProperty IsValidProperty =
            DependencyProperty.Register
            (
               "IsValid",
               typeof(bool),
               typeof(XNumericBoxLite),
               new PropertyMetadata(false)
            );

        /// <summary>
        /// Выранивание текста внутри поля ввода.
        /// TextAlignment.Center, TextAlignment.Justify, TextAlignment.Left, TextAlignment.Right
        /// </summary>
        public TextAlignment TextBoxTextAlignment
        {
            get { return (TextAlignment)GetValue(TextBoxTextAlignmentProperty); }
            set { SetValue(TextBoxTextAlignmentProperty, value); }
        }

        public static readonly DependencyProperty TextBoxTextAlignmentProperty =
            DependencyProperty.Register
            (
               "TextBoxTextAlignment",
               typeof(TextAlignment),
               typeof(XNumericBoxLite),
               new PropertyMetadata(TextAlignment.Left)
            );

        /// <summary>
        /// Вещественное представление значения.
        /// Только для чтения. Изменять можно свойство ValueString
        /// </summary>
        //public double Value
        //{
        //    get { return _value; }
        //}

        /// <summary>
        /// Вещественное представление значения.
        /// Только для чтения. Изменять можно свойство ValueString
        /// </summary>
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { //KGA TO private
                SetValue(ValueProperty, value);
                //SetValue(ValueStringProperty, value.ToString());
            }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register
            (
               "Value",
               typeof(double),
               typeof(XNumericBoxLite),
               new PropertyMetadata(0.0)
            );

        public string ValueString
        {
            get { return (string)GetValue(ValueStringProperty); }
            set {
                SetValue(ValueStringProperty, value);
                //SetValue(ValueProperty, value);
            }
        }
        public static readonly DependencyProperty ValueStringProperty =
            DependencyProperty.Register
            (
                "ValueString",
                typeof(string),
                typeof(XNumericBoxLite),
                new PropertyMetadata(
                        "",
                        new PropertyChangedCallback(OnValueStringChanged),
                        new CoerceValueCallback(CoerceValueString)),
                new ValidateValueCallback(IsValidValueString)
            );

        /// <summary>
        /// Валидация ValueString. В случае безуспешной валидации будет вызвано исключение.
        /// Этот Callback срабатывает первым.
        /// </summary>
        /// <param name="value">Проверяемое значение</param>
        /// <returns>True - валидно, False - не валидно</returns>
        public static bool IsValidValueString(object value)
        {
            return true;
        }
        /// <summary>
        /// Позволяет корректировать данное свойство на основе других свойств.
        /// Этот Callback срабатывает вторым.
        /// </summary>
        /// <param name="d">Объект вызвавший Callback</param>
        /// <param name="value">Значение для корректировки</param>
        /// <returns>Скорректированное значение</returns>
        private static object CoerceValueString(DependencyObject d, object value)
        {
            XNumericBoxLite numBox = (XNumericBoxLite)d;
            double oldValue = numBox.Value; //Запоминаем старое значение

            string sVal = (value is null) ? "" : value.ToString();
            if (string.IsNullOrEmpty(sVal))//(numBox._valueString))//Пустая строка является допустимой. Приводить к константе double.NaN
            {
                numBox.Value = double.NaN;
                DoValueChanged(numBox, oldValue);
                return value;
            }

            //numBox._valueString = numBox._valueString.Replace(",", dec_sep).Replace(".", dec_sep);
            string dec_sep = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            sVal = sVal.Replace(",", dec_sep).Replace(".", dec_sep);
            double _val; //Нужна, чтобы TryParse не перезаписал _Value при неуспешной конвертации. То есть храним последнее успешно сконвертированное значение.
            bool IsNewValid = double.TryParse(sVal, out _val);//numBox._valueString, out _val);
            if (IsNewValid) //Если валидное значение, то сохраняем его
            {
                numBox.Value = _val;
                //if ((_val >= numBox.Min) && (_val <= numBox.Max)) //Если попадает в диапазон, то вызываем событие ValueChange
                if (IsInRange(_val, numBox.Min, numBox.Max, numBox.IncludeMin, numBox.IncludeMax, numBox.AllowEmptyValue))
                {
                    DoValueChanged(numBox, oldValue);
                }
            }
            //if (Regex.IsMatch(sVal, @"^\.\d*$|^\,\d*$"))
            //    sVal = '0' + sVal;
            return sVal;
        }        

        /// <summary>
        /// Позволяет корректировать другие свойства после изменения данного
        /// Этот Callback срабатывает третьим.
        /// </summary>
        /// <param name="d">Объект вызвавший Callback</param>
        /// <param name="e">Данные события изменения свойства</param>
        private static void OnValueStringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string oldVal = e.OldValue == null ? "" : e.OldValue.ToString();
            string newVal = e.NewValue == null ? "" : e.NewValue.ToString();

            bool isValid = (newVal is null) ? true : Regex.IsMatch(newVal, @"^$|^\d*\.\d+$|^\d*\,\d+$|^[0-9]+$|^[0-9]+[,.]{0,1}[0-9]*$|^[-][0-9]+$|^[-][0-9]+[,.]{0,1}[0-9]*$");

            if (newVal != "")
            {
                double val = 0;
                if (double.TryParse(newVal, out val))
                {
                    XNumericBoxLite numBox = (XNumericBoxLite)d;
                    //if ((val < (double)d.GetValue(MinProperty)) || (val > (double)d.GetValue(MaxProperty)))
                    if (!IsInRange(val, numBox.Min, numBox.Max, numBox.IncludeMin, numBox.IncludeMax, numBox.AllowEmptyValue))
                    {
                        isValid = false;
                    }
                }
                else
                    isValid = false;

                d.SetValue(IsValidProperty, isValid);
            }


            DoValueStringChanged(d, oldVal, newVal);
            //XNumericBoxLite numBox = (XNumericBoxLite)d;
            //double oldValue = numBox.Value; //Запоминаем старое значение

            //string sValueString = e.NewValue.ToString();
            //if (string.IsNullOrEmpty(sValueString)) //Пустая строка является допустимой. Приводить к константе double.NaN
            //{
            //    numBox.Value = double.NaN;
            //    DoValueChanged(numBox, oldValue);
            //}

            //string dec_sep = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            //sValueString = sValueString.Replace(",", dec_sep).Replace(".", dec_sep);
            //double _val; //Нужна, чтобы TryParse не перезаписал _Value при неуспешной конвертации. То есть храним последнее успешно сконвертированное значение.
            //bool IsNewValid = double.TryParse(sValueString, out _val);
            //if (IsNewValid) //Если валидное значение, то сохраняем его
            //{
            //    numBox.Value = _val;
            //    if ((_val >= numBox.Min) && (_val <= numBox.Max)) //Если попадает в диапазон, то вызываем событие ValueChange
            //    {
            //        DoValueChanged(numBox, oldValue);
            //    }
            //}
            //  d.SetValue(ValueProperty, value);
            //SetValue(ValueProperty, value);
            //d.CoerceValue(GroupIndexProperty); //Пример вызова корректировки в другом свойстве
        }

        /// <summary>
        /// Минимально допустимое значение.
        /// Участвует в валидации поля.
        /// </summary>
        public double Min
        {
            get { return (double)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register
            (
                "Min",
                typeof(double),
                typeof(XNumericBoxLite),
                new PropertyMetadata(double.NaN,
                new PropertyChangedCallback(OnMinChanged))
            );

        /// <summary>
        /// Позволяет корректировать другие свойства после изменения данного
        /// Этот Callback срабатывает третьим.
        /// </summary>
        /// <param name="d">Объект вызвавший Callback</param>
        /// <param name="e">Данные события изменения свойства</param>
        private static void OnMinChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            double newMinVal = (double)e.NewValue;
            if (double.IsNaN(newMinVal))
                return;

            string newVal = d.GetValue(ValueStringProperty) == null ? "" : d.GetValue(ValueStringProperty).ToString();

            bool isValid = (newVal is null) ? true : Regex.IsMatch(newVal, @"^$|^\d*\.\d+$|^\d*\,\d+$|^[0-9]+$|^[0-9]+[,.]{0,1}[0-9]*$|^[-][0-9]+$|^[-][0-9]+[,.]{0,1}[0-9]*$");

            if (newVal != "")
            {
                XNumericBoxLite numBox = (XNumericBoxLite)d;
                double val = 0;
                if (double.TryParse(newVal, out val))
                {
                    //if ((val < (double)d.GetValue(MinProperty)) || (val > (double)d.GetValue(MaxProperty)))
                    if (!IsInRange(val, numBox.Min, numBox.Max, numBox.IncludeMin, numBox.IncludeMax, numBox.AllowEmptyValue, out string errMsg))
                    {
                        numBox.Error = errMsg;// "Значение не входит в диапазон от " + numBox.Min + " до " + numBox.Max + ".";
                        //(d as XNumericBoxLite).Error = "Значение не входит в диапазон от " + d.GetValue(MinProperty) + " до " + d.GetValue(MaxProperty) + ".";
                        isValid = false;
                    }
                }
                else
                {
                    numBox.Error = "Значение не является действительным числом";
                    //(d as XNumericBoxLite).Error = "Значение не является действительным числом";
                    isValid = false;
                }                
                d.SetValue(IsValidProperty, isValid);
                //d. Error.
            }            
        }

        /// <summary>
        /// Максимально допустимое значение.
        /// Участвует в валидации поля.
        /// </summary>
        public double Max
        {
            get { return (double)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register
            (
                "Max",
                typeof(double),
                typeof(XNumericBoxLite),
                new FrameworkPropertyMetadata(double.NaN, null, new CoerceValueCallback(CoerceMaximum))
            );
        /// <summary>
        /// Корректирует значение Max, если оно меньше Min
        /// </summary>     
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object CoerceMaximum(DependencyObject obj, object value)
        {
            if ((double)value < ((XNumericBoxLite)obj).Min)
                return ((XNumericBoxLite)obj).Min;

            return value;
        }

        public int GroupIndex
        {
            get { return (int)GetValue(GroupIndexProperty); }
            set { SetValue(GroupIndexProperty, value); }
        }
        public static readonly DependencyProperty GroupIndexProperty =
            DependencyProperty.Register
            (
                "GroupIndex",
                typeof(int),
                typeof(XNumericBoxLite),
                new PropertyMetadata(-1)
            );

        public int ItemIndex
        {
            get { return (int)GetValue(ItemIndexProperty); }
            set { SetValue(ItemIndexProperty, value); }
        }
        public static readonly DependencyProperty ItemIndexProperty =
            DependencyProperty.Register
            ( 
                "ItemIndex",
                typeof(int),
                typeof(XNumericBoxLite),
                new PropertyMetadata(-1)
            );

        /// <summary>
        /// Включить левую границу диапазона
        /// По умолчанию true
        /// </summary>
        public bool IncludeMin
        {
            get { return (bool)GetValue(IncludeMinProperty); }
            set { SetValue(IncludeMinProperty, value); }
        }

        public static readonly DependencyProperty IncludeMinProperty =
            DependencyProperty.Register
            (
               "IncludeMin",
               typeof(bool),
               typeof(XNumericBoxLite),
               new PropertyMetadata(true)
            );

        /// <summary>
        /// Включить правую границу диапазона
        /// По умолчанию true
        /// </summary>
        public bool IncludeMax
        {
            get { return (bool)GetValue(IncludeMaxProperty); }
            set { SetValue(IncludeMaxProperty, value); }
        }

        public static readonly DependencyProperty IncludeMaxProperty =
            DependencyProperty.Register
            (
               "IncludeMax",
               typeof(bool),
               typeof(XNumericBoxLite),
               new PropertyMetadata(true)
            );

        /// <summary>
        /// Позволяет вводить пустое значение (не выводит ошибку)
        /// По умолчанию true
        /// </summary>
        public bool AllowEmptyValue
        {
            get { return (bool)GetValue(AllowEmptyValueProperty); }
            set { SetValue(AllowEmptyValueProperty, value); }
        }

        public static readonly DependencyProperty AllowEmptyValueProperty =
            DependencyProperty.Register
            (
               "AllowEmptyValue",
               typeof(bool),
               typeof(XNumericBoxLite),
               new PropertyMetadata(true)
            );

        #endregion

        #region [ Команды ]

        public ICommand CmdValueChange
        {
            get { return (ICommand)GetValue(CmdValueChangeProperty); }
            set { SetValue(CmdValueChangeProperty, value); }
        }
        public static readonly DependencyProperty CmdValueChangeProperty =
            DependencyProperty.Register(
                "CmdValueChange",
                typeof(ICommand),
                typeof(XNumericBoxLite),
                new PropertyMetadata(null));

        #endregion

        #region [ Методы ]
        /// <summary>
        /// Обработка событий валидации на уровне компонента.
        /// Является Bubble-событием
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Аргументы</param>
        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            //Console.WriteLine("XNumericBox --> TextBox_Error");
           //Console.WriteLine("-------------->" + e.Error.ErrorContent.ToString());
           // Console.WriteLine("-------------->" + Error);
        }
        #endregion

        #region [ Маршрутизируемые события ]
        //public delegate void RoutedPropertyChangedEventHandler<T>(object sender, RoutedPropertyChangedEventArgs<T> e);

        public static readonly RoutedEvent ValueStringChangedEvent;
        public event RoutedEventHandler ValueStringChanged
        {
            add { AddHandler(XNumericBoxLite.ValueStringChangedEvent, value); }
            remove { RemoveHandler(XNumericBoxLite.ValueStringChangedEvent, value); }
        }

        protected static void DoValueStringChanged(object sender, string OldValue, string NewValue)
        {
            RoutedEventArgs eArg = new RoutedEventArgs(ValueStringChangedEvent, sender);
            ((XNumericBoxLite)sender).RaiseEvent(eArg);
        }

        /// <summary>                                
        /// Определение события при изменении значения Value
        /// </summary>
        public static readonly RoutedEvent ValueChangedLightEvent;

        /// <summary>
        /// Традиционная оболочка события при изменении значения Value
        /// На него можно подписаться и следить за старым и новым значениями.
        /// </summary>
        public event RoutedEventHandler ValueChangedLight
        {
            add { AddHandler(XNumericBoxLite.ValueChangedLightEvent, value); }
            remove { RemoveHandler(XNumericBoxLite.ValueChangedLightEvent, value); }
        }

        /// <summary>
        /// Вызывает событие ValueChangedEvent
        /// </summary> 
        /// <param name="_oldValue">Старое значение Value. Новое значение хранится в т екущем Value</param>
        protected static void DoValueChanged(object sender, double _oldValue)
        {
            //_OnValueChanged?.Invoke(this, _oldValue);

            //В маршрутизируемых событиях пользовательский аргумент _oldValue не использован [ TODO ]
            RoutedEventArgs eArg = new RoutedEventArgs(ValueChangedLightEvent, sender);
            ((XNumericBoxLite)sender).RaiseEvent(eArg);
        }

        #endregion

        #region [ IDataErrorInfo ]

        /// <summary>
        /// Осуществляет валидацию необходимых полей
        /// </summary>
        /// <param name="columnName">Имя поля для валидации</param>
        /// <returns>Строка ошибки при валидации</returns>
        public string this[string columnName]
        {
            get
            {
               // Console.WriteLine($"this[{columnName}] = {ValueString}");
                bool numericBoxIsValid = true;
                Error = string.Empty;
                switch (columnName)
                {
                    case "ValueString":
                        bool isValid = (ValueString is null) ? true : Regex.IsMatch(ValueString, @"^$|^\d*\.\d+$|^\d*\,\d+$|^[0-9]+$|^[0-9]+[,.]{0,1}[0-9]*$|^[-][0-9]+$|^[-][0-9]+[,.]{0,1}[0-9]*$");
                        if (!isValid)
                        {
                            Error = "Значение не является действительным числом";
                            numericBoxIsValid = false;
                        }
                        else
                        {
                            //if ((Value < Min) || (Value > Max))
                            if (!IsInRange(Value, Min, Max, IncludeMin, IncludeMax, AllowEmptyValue, out string errMsg))
                            {
                                Error = errMsg;// "Значение не входит в диапазон от " + Min + " до " + Max + ".";
                                numericBoxIsValid = false;
                            }
                        }
                        break;
                }
                IsValid = numericBoxIsValid;
                return Error;
            }
        }

        public string Error { get; private set; }

        #endregion

        /// <summary>
        /// Проверка вхождения value в диапазон min..max
        /// </summary>
        /// <param name="value">Проверяемое значение</param>
        /// <param name="min">Минимальное</param>
        /// <param name="max">Максимальное</param>
        /// <param name="includeMin">Включать ли границу min</param>
        /// <param name="includeMax">Включать ли границу max</param>
        /// <param name="allowEmpty">Позволять ли пустое значение value</param>
        /// <param name="errorMessage">Сообщение о том, почему value не входит в диапазон min..max</param>
        /// <returns></returns>
        private static bool IsInRange(double value, double min, double max, bool includeMin, bool includeMax, bool allowEmpty, out string errorMessage)
        {
            errorMessage = "";
            if (double.IsNaN(value))
            {
                if (allowEmpty)
                    return true;

                errorMessage = $"Значение не введено";
                return false;
            }

            bool minExpr = double.IsNaN(min) || (includeMin ? value >= min : value > min);
            bool maxExpr = double.IsNaN(max) || (includeMax ? value <= max : value < max);

            if (minExpr && maxExpr)
                return true;

            if (!double.IsNaN(min) && !double.IsNaN(max))
            {
                errorMessage = $"Значение '{value}' не входит в диапазон: " +
                                (includeMin ? "[" : "(") + min +
                                $"; {max}" + (includeMax ? "]" : ")") + ".";
                return false;
            }

            if (double.IsNaN(min))
            {
                errorMessage = "Значение должно быть меньше " +
                                (includeMax ? "или равно " : "") + max + ".";
                return false;
            }

            errorMessage = "Значение должно быть больше " +
                             (includeMin ? "или равно " : "") + min + ".";

            return false;
        }

        /// <summary>
        /// Проверка вхождения value в диапазон min..max
        /// </summary>
        /// <param name="value">Проверяемое значение</param>
        /// <param name="min">Минимальное</param>
        /// <param name="max">Максимальное</param>
        /// <param name="includeMin">Включать ли границу min</param>
        /// <param name="includeMax">Включать ли границу max</param>
        /// <returns></returns>
        private static bool IsInRange(double value, double min, double max, bool includeMin, bool allowEmpty, bool includeMax)
        {
            if (double.IsNaN(value))
            {
                if (allowEmpty)
                    return true;

                return false;
            }

            bool minExpr = double.IsNaN(min) || (includeMin ? value >= min : value > min);
            bool maxExpr = double.IsNaN(max) || (includeMax ? value <= max : value < max);

            return minExpr && maxExpr;
        }
    }
}