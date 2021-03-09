using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Timetracker.Models;
using Timetracker.Repository;

namespace Timetracker.ViewModels
{
    public class TimetrackerViewModel : INotifyPropertyChanged, ITimetrackerViewModel
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
                //OnPropertyChanged();
            }
        }

        private List<string> jobTypes = Enum.GetValues(typeof(JobType)).Cast<JobType>().Select(v => v.ToString()).ToList();
        public List<string> JobTypes
        {
            get => jobTypes;
            set
            {
                jobTypes = value;
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

            GetJobItems();
            isBusy = false;
        }

        public void GetJobItems()
        {
            IsBusy = true;
            JobItems = timetrackerRepository.GetItemsAsync().Result;

            RefreshJobTypeList();
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

        private void RefreshJobTypeList()
        {
            List<string> originalList = Enum.GetValues(typeof(JobType)).Cast<JobType>().Select(v => v.ToString()).ToList();
            List<string> notIncludedJobTypes = JobItems.Select(item => item.Type).Except(originalList).ToList();
            JobTypes = originalList.Union(notIncludedJobTypes).Distinct().ToList();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
