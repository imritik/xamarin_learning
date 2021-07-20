using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using xamarin_notes_app.Models;

namespace xamarin_notes_app.ViewModels
{
    class TaskViewModel : INotifyPropertyChanged
    {
        List<Task> source;

        public ObservableCollection<Task> AllTask { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        
    }
}
