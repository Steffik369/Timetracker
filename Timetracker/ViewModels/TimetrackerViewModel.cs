using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Timetracker.Models;
using Timetracker.Repository;

namespace Timetracker.ViewModels
{
    public class TimetrackerViewModel : ITimetrackerViewModel
    {
        private ITimetrackerRepository timetrackerRepository;

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

        public TimetrackerViewModel(ITimetrackerRepository repository)
        {
            this.timetrackerRepository = repository;
            GetJobItems();
        }

        public void DeleteJobItem(JobItem jobItem)
        {
            if (jobItem is null) throw new ArgumentNullException(nameof(jobItem), "Given item is NULL!");
            
            isBusy = true;
            timetrackerRepository.DeleteItemAsync(jobItem);
            isBusy = false;
        }

        public void GetJobItems()
        {
            IsBusy = true;
            JobItems = timetrackerRepository.GetItemsAsync().Result;
            IsBusy = false;
        }

        public void SaveJobItem(JobItem jobItem)
        {
            if (jobItem is null) throw new ArgumentNullException(nameof(jobItem), "Given item is NULL!");

            IsBusy = true;

            if (jobItem.Id.Equals(Guid.Empty))
            {
                jobItem.Id = Guid.NewGuid();
                timetrackerRepository.AddItemAsync(jobItem);
            }
            else
            {
                timetrackerRepository.UpdateItemAsync(jobItem);
            }

            GetJobItems();

            IsBusy = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
