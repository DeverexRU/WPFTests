using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace WPFTests
{
    /// <summary>
    /// Логика взаимодействия для FormDataGrid.xaml
    /// </summary>
    public partial class FormDataGrid : Window
    {
        public VM_FormIGECalc vm = new VM_FormIGECalc();
        public List<string> list_UrovOtv = new List<string>();
        public List<string> list_gKind = new List<string>();
        public List<string> list_gTorfy = new List<string>();
        public List<string> list_SaltType = new List<string>();


        public FormDataGrid()
        {
            InitializeComponent();

            DataContext = vm;

            //добавление ресурсов для выпадающих списков
            //просто создать - не привязывает DynamicSource, пришлось удалить пустую заготовку и пересоздать массив 
            this.Resources.Remove("list_UrovOtv");
            list_UrovOtv.Add("(Не определено)");
            list_UrovOtv.Add("I - повышенный");
            list_UrovOtv.Add("II,III - пониженный");
            this.Resources.Add("list_UrovOtv", list_UrovOtv);

            
            this.Resources.Remove("list_gKind");
            for (int i = 0; i <= PropertiesConsts.fParamDis_gKind.GetUpperBound(0); i++)
                list_gKind.Add(PropertiesConsts.fParamDis_gKind[i].fCaption);
            this.Resources.Add("list_gKind", list_gKind);

        }

    }

    public struct PropFields
    {
        public string fCaption;
        public string fMark;
        public int fType;
        public string fMU;
    }

    public struct ParamDis_gKind
    {
        public int fgKind;
        public string fCaption;
    }


    public static class PropertiesConsts
    {
        public static PropFields[] IGEPropParams =
        {
                new PropFields() {fCaption = "Шифр ИГЭ", fMark = "", fType = 1, fMU = "строка"},
                new PropFields() {fCaption = "Уровень ответственности", fMark = "", fType = 2, fMU = "список"},

                new PropFields() {fCaption = "Тип грунта", fMark = "", fType = 3, fMU = "список"},
                new PropFields() {fCaption = "Плотность сухого грунта (скелета грунта)", fMark = "ro d,th", fType = 1, fMU = "г./куб.см"},
                new PropFields() {fCaption = "Число пластичности", fMark = "Ip", fType = 1, fMU = "д.ед."},
                new PropFields() {fCaption = "Показатель консистенции (текучести)", fMark = "IL", fType = 1, fMU = "д.ед."},
                new PropFields() {fCaption = "Коэффициент пористости", fMark = "e", fType = 1, fMU = "д.ед."},
            };

        public static ParamDis_gKind[] fParamDis_gKind =
        {
                new ParamDis_gKind() {fgKind = 0,
                    fCaption = "(Не определено)" },
                new ParamDis_gKind() {fgKind = 1,
                    fCaption = "Песок" }
            };
    }

    #region ===== ViewModel: VM_FormIGECalc =====

    /// <summary>
    /// Класс для селектора содержимого ячейки таблицы
    /// </summary>
    public class GradeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TemplateString { get; set; }
        public DataTemplate TemplateDouble { get; set; }
        public DataTemplate TemplateList_UrovOtv { get; set; }
        public DataTemplate TemplateList_gKind { get; set; }
        public DataTemplate TemplateList_gTorfy { get; set; }
        public DataTemplate TemplateList_SaltType { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            VM_IGEParameter v = item as VM_IGEParameter;

            if (v != null)
            {
                switch (v.VPropType)
                {
                    case 1:
                        return TemplateDouble;
                    case 2:
                        return TemplateList_UrovOtv;
                    case 3:
                        return TemplateList_gKind;
                    default:
                        return TemplateString;
                }
            }
            else
            {
                return base.SelectTemplate(item, container);
            }
        }
    }

    public class VM_FormIGECalc : INotifyPropertyChanged
    {
        private string fProjectShifr { get; set; }

        //сетка параметров материала
        public ObservableCollection<VM_IGEParameter> FIGEParams { get; set; }

        //конструктор класса
        public VM_FormIGECalc()
        {
            //первоначальная примитивная инициализация полей VM
            FIGEParams = new ObservableCollection<VM_IGEParameter>();
            /*
            //размещение слоя
            FMaterialPlacementsList = new ObservableCollection<VM_MaterialPlacement>();
            */

            //заполнение таблицы для ввода - из справочника параметров
            for (int i = 0; i <= PropertiesConsts.IGEPropParams.GetUpperBound(0); i++)
            {
                //пропускаем параметр "Тип грунта"
                //if (P.fParamTypeIndex == 1) { continue; }
                VM_IGEParameter MP = new VM_IGEParameter();
                MP.VPropType = (int)PropertiesConsts.IGEPropParams[i].fType;
                MP.VName = PropertiesConsts.IGEPropParams[i].fCaption;
                MP.VMark = PropertiesConsts.IGEPropParams[i].fMark;
                MP.VManualValue = (int)PropertiesConsts.IGEPropParams[i].fType; //параметр - изменяемый пользователем !!!
                MP.VManualMU = "";
                MP.VCalcValue = 0; //параметр - изменяемый пользователем !!!
                MP.VCalcMU = "";
                FIGEParams.Add(MP);

                //                Debug.WriteLine(MP.VName);
            }

        }

        public string VProjectShifr
        {
            get { return fProjectShifr; }
            set
            {
                fProjectShifr = value;
                OnPropertyChanged("VProjectShifr");
            }
        }


        /// <summary>Поле - событие для извещения об изменения свойства</summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary> Реализация метода OnPropertyChanged для INotifyPropertyChanged</summary>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class VM_IGEParameter : INotifyPropertyChanged
    {
        //внутренние поля
        //ВРЕМЕННОЕ РЕШЕНИЕ - методы должны связываться с общей базой числовых данных (параметров)
        private int fPropType;
        private string fName;
        private string fMark;
        private double fManualValue;
        private string fManualMU; //единицы измерения
        private double fCalcValue;
        private string fCalcMU;

        //методы свойств сквозняком обрабатывают тип параметра и выдают только его значение

        public int VPropType
        {
            get { return fPropType; }
            set { fPropType = value; OnPropertyChanged("VPropType"); }
        }

        public string VName
        {
            get { return fName; }
            set { fName = value; OnPropertyChanged("VName"); }
        }

        public string VMark
        {
            get { return fMark; }
            set { fMark = value; OnPropertyChanged("VMark"); }
        }

        public double VManualValue
        {
            get { return fManualValue; }
            set { fManualValue = value; OnPropertyChanged("VManualValue"); }
        }

        public string VManualMU
        {
            get { return fManualMU; }
            set { fManualMU = value; OnPropertyChanged("VManualMU"); }
        }

        public double VCalcValue
        {
            get { return fCalcValue; }
            set { fCalcValue = value; OnPropertyChanged("VCalcValue"); }
        }

        public string VCalcMU
        {
            get { return fCalcMU; }
            set { fCalcMU = value; OnPropertyChanged("VCalcMU"); }
        }

        /// <summary>Поле - событие для извещения об изменения свойства</summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary> Реализация метода OnPropertyChanged для INotifyPropertyChanged</summary>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    #endregion
}
