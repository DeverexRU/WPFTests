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
using WPFTests.ViewModel;

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

