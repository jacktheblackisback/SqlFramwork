using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SqlFramework
{
    public class MainObject : INotifyPropertyChanged
    {
        public MainObject()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void InvokePropertyChanged([CallerMemberName] string propname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
