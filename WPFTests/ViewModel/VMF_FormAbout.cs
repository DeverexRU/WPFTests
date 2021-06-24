using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTests.ViewModel
{
    class VMF_FormAbout
    {
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


    }
}
