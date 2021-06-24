using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTests.ViewModel
{
    class VMF_FormAbout :INotifyPropertyChanged
    {
        public VMF_FormAbout() => tiIndex = 0;
        public string FullProgrameName
        {
            get => "РН-Симулар";
        }

        public string ProgrameVersion
        {
            get => "1.0.0.6";
        }

        public string ProgrameDescription
        {
            get => "Программа для расчета свайных фундаментов";
        }

        public string NumberLicense
        {
            get => "№12345678910";
        }

        public string DateLicense
        {
            get => "24.06.2021";
        }

        public string TypeLicense
        {
            get => "Однопользовательская(сетевая)";
        }

        public string Licenseziat
        {
            get => "ООО «НК «Роснефть» - НТЦ»";
        }

        public int CountLicense
        {
            get => 111;
        }

        public int tiIndex
        {
            set
            {
                _tiIndex = value;
                OnPropertyChanged();
            }
            get => _tiIndex;
        }
        private int _tiIndex;

        public ICommand cmdSetTabIndex0 => new RelayCommand(() => tiIndex = 0, _AlwaysTrue);
        public ICommand cmdSetTabIndex1 => new RelayCommand(() => tiIndex = 1, _AlwaysTrue);
        public ICommand cmdSetTabIndex2 => new RelayCommand(() => tiIndex = 2, _AlwaysTrue);
        public ICommand cmdSetTabIndex3 => new RelayCommand(() => tiIndex = 3, _AlwaysTrue);



        /// <summary>
        /// Заглушка для свойства Enabled в Command: TRUE
        /// </summary>
        protected bool _AlwaysTrue() { return true; }

        /// <summary>
        /// Заглушка для свойства Enabled в Command: FALSE
        /// </summary>
        protected bool _AlwaysFalse() { return false; }

        /// <summary>
        /// Объявление свойства из INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
