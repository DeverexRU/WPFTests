using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTests.Model;

namespace WPFTests.ViewModel
{
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

}