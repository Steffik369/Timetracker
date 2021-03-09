using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Timetracker.Models;

namespace Timetracker.ViewModels
{
    public class TimetrackerViewModel : ITimetrackerViewModel
    {
        public TimetrackerViewModel()
        {
        }

        private bool isBusy = false;
        public bool IsBusy 
        {
            get => isBusy;
            private set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        private List<JobItem> jobItems = new List<JobItem>();
        public List<JobItem> JobItems
        {
            get => jobItems;
            private set
            {
                jobItems = value;
                OnPropertyChanged();
            }
        }

        private JobItem jobItem = new JobItem();

        public JobItem JobItem 
        { 
            get => jobItem;
            set
            {
                jobItem = value;
                OnPropertyChanged();
            }
        }


        public void DeleteJobItem(JobItem jobItem)
        {
            throw new NotImplementedException();
        }

        public void GetJobItems()
        {
            throw new NotImplementedException();
        }

        public void SaveJobItem(JobItem jobItem)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
