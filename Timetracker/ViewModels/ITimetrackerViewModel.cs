using System;
using System.Collections.Generic;
using System.ComponentModel;
using Timetracker.Models;

namespace Timetracker.ViewModels
{
    interface ITimetrackerViewModel
    {
        bool IsBusy { get; }
        List<JobItem> JobItems { get; }
        List<string> JobTypes { get; set; }

        JobItem JobItem { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void GetJobItems();
        void SaveJobItem(JobItem jobItem);
        void DeleteJobItem(JobItem jobItem);
    }
}
