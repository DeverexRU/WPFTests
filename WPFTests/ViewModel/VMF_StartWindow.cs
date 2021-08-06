using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFTests.ViewModel
{
    class VMF_StartWindow
    {
        public RelayCommand CmdNewProject
        {
            get { return new RelayCommand(_DoNewProject, _AlwaysTrue); }
        }
        private void _DoNewProject()
        {
            MessageBox.Show("Создается форма с пустым проектом");
        }

        public RelayCommand CmdOpenProjectDialog
        {
            get { return new RelayCommand(_DoOpenProjectDialog, _AlwaysTrue); }
        }
        private void _DoOpenProjectDialog()
        {
            MessageBox.Show("Открывается проводник для открытия проекта");
        }

        public RelayCommand CmdLoadExample
        {
            get { return new RelayCommand(_DoLoadExample, _AlwaysTrue); }
        }
        private void _DoLoadExample()
        {
            MessageBox.Show("Открывается проект-пример");
        }

        public RelayCommand CmdOpenSprav { get { return new RelayCommand(_DoOpenSprav, _AlwaysTrue); } }
        private void _DoOpenSprav()
        {
            MessageBox.Show("Открывается инструкция");
        }

        public RelayCommand CmdOpenExampleIsh { get { return new RelayCommand(_DoOpenExampleIsh, _AlwaysTrue); } }
        private void _DoOpenExampleIsh()
        {
            MessageBox.Show("Открывается пример исходных данных");
        }

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
