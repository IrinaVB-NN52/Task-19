using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task_19.Models;

namespace Task_19.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string PropertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        private int radiys;
        public  int Radius
        {
            get => radiys;
            set
            {
                radiys  = value;
                OnPropertyChanged();
            }
        }
        private double circumference;
       public double Circumference
        {
            get => circumference;
            set

            {
                circumference = value;
                OnPropertyChanged();
            }

        }
    
        public ICommand AddCommand { get; }
        private void OnAddCommandExecute(object p)
        {
            Circumference = Ariph.FindCircumference(Radius);
        }
        private bool CanAddCommandExecute(object p)
        {
            if (Radius !=0)
                return true;
            else 
                return false;

        }
        public MainWindowViewModel()
        {
            AddCommand =new RelayComman(OnAddCommandExecute, CanAddCommandExecute);
        }
    }

        
}
