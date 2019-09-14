using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTests.ViewModel
{
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

}
