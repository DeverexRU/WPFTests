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
    public class VSupportContact
    {
        public string VFIO { set; get; }
        public string VAddress { set; get; }
        public string VEmail { set; get; }
        public string VPhoneNumber { set; get; }

        public VSupportContact(string fio, string address,
                              string email, string phonenumber)
        {
            VFIO = fio;
            VAddress = address;
            VEmail = email;
            VPhoneNumber = phonenumber;
        }
    }

    public class VLicense
    {
        public string VNumber { set; get; }
        public string VDate { set; get; }

        public VLicense(string number, string date)
        {
            VNumber = number;
            VDate = date;
        }
    }

    class VMF_FormAbout :INotifyPropertyChanged
    {
        public VMF_FormAbout() 
        { 
            tiIndex = 0; 
            VAuthors = new List<string>()
            {
                "Медяник Сергей Сергеевич",
                "Кесиян Грант Арутович",
                "Дубров Александр Дмитриевич",
                "Поверенный Юрий Сергеевич",
                "Гилев Николай Григорьевич",
                "Зенков Евгений Валерьевич",
                "Загуменникова Анна Вячеславовна",
                "Федосеенко Валентин Олегович"
            };
            VRazrabs = new List<string>()
            {
                "Медяник Сергей Сергеевич",
                "Кесиян Грант Арутович",
                "Лахин Михаил Юрьевич",
                "Плигина Эвелина Евгеньевна",
                "Кузнецов Кирилл Игоревич"
            };
            VModules = new List<string>()
            {
                "Свая-САПР Про",
                "РН-Симулар",
                "Типизация",
                "Сервер ЦМЛО"
            };
            VSupports = new List<VSupportContact>()
            {
                new VSupportContact("Иванов Иван Иванович", "г. Краснодар, ул. Красная 54, каб. 1", "II_Ivanov@ntc.rosneft.ru", "+79181234567"),
                new VSupportContact("Андреев Андрей Андреевич", "г. Краснодар, ул. Красная 54, каб. 2", "AA_Andreev@ntc.rosneft.ru", "+79181234321"),
                new VSupportContact("Петров Петр Петрович", "г. Краснодар, ул. Красная 54, каб. 3", "PP_Petrov@ntc.rosneft.ru", "+79187654321")
            };
            VLicenses = new List<VLicense>()
            {
                new VLicense("№12345678910","24.06.2021"),
                new VLicense("№10987654321","25.06.2021")
            };
        }

        #region [ Свойства VM ]

        #region [ Списки ]

        public List<string> VAuthors { set; get; } 
        public List<string> VRazrabs { set; get; }
        public List<string> VModules { set; get; }
        public List<VSupportContact> VSupports { set; get; }
        public List<VLicense> VLicenses { set; get; }


        #endregion

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
        
        #endregion

        public ICommand cmdSetTabIndex0 => new RelayCommand(() => tiIndex = 0, _AlwaysTrue);
        public ICommand cmdSetTabIndex1 => new RelayCommand(() => tiIndex = 1, _AlwaysTrue);
        public ICommand cmdSetTabIndex2 => new RelayCommand(() => tiIndex = 2, _AlwaysTrue);
        public ICommand cmdSetTabIndex3 => new RelayCommand(() => tiIndex = 3, _AlwaysTrue);
        public ICommand cmdSetTabIndex4 => new RelayCommand(() => tiIndex = 4, _AlwaysTrue);



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
