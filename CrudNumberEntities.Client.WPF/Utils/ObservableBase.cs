﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CrudNumberEntities.Client.WPF.Utils
{
    abstract public class ObservableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
