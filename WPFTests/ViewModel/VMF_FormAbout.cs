using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPFTests.View;

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
        public string VImage { set; get; }

        public VLicense(string number, string date, string img)
        {
            VNumber = number;
            VDate = date;
            VImage = img;
        }
    }

    class VMF_FormAbout :INotifyPropertyChanged
    {
        public VMF_FormAbout() 
        {
            VFIO_Authors = new List<string>()
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
            VFIO_DDT = new List<string>()
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
            VSupportContacts = new List<VSupportContact>()
            {
                new VSupportContact("Иванов Иван Иванович", "г. Краснодар, ул. Красная 54, каб. 1", "II_Ivanov@ntc.rosneft.ru", "+79181234567"),
                new VSupportContact("Андреев Андрей Андреевич", "г. Краснодар, ул. Красная 54, каб. 2", "AA_Andreev@ntc.rosneft.ru", "+79181234321"),
                new VSupportContact("Петров Петр Петрович", "г. Краснодар, ул. Красная 54, каб. 3", "PP_Petrov@ntc.rosneft.ru", "+79187654321")
            };
            VLicenses = new List<VLicense>()
            {
                new VLicense("№12345678910","24.06.2021", "/Resources/LicenseImage.jpg"),
                new VLicense("№10987654321","25.06.2021", "/Resources/LicenseImage.jpg")
            };
        }

        #region [ Свойства VM ]

        private UserControl _curUC;
        public UserControl curUC
        {
            set
            {
                _curUC = value;
                OnPropertyChanged();
            }
            get => _curUC;
        }

        #region [ Списки ]

        public List<string> VFIO_Authors { set; get; } 
        public List<string> VFIO_DDT { set; get; }
        public List<string> VModules { set; get; }
        public List<VSupportContact> VSupportContacts { set; get; }
        public List<VLicense> VLicenses { set; get; }


        #endregion

        public string VTitle
        {
            get => "РН-Симулар";
        }

        public string VVersion
        {
            get => "1.0.0.6";
        }

        public string VDescription
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
        
        public string VLicenseText
        {
            get => " ...Текст лицензии...";
        }

        #endregion

        



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
