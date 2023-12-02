using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DeviationModule.Models
{
    public class Launch : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        [ReadOnly(true)]
        public int Id { get; set; }

        private string? consumer;
        public int? ProcedureId { get; set; }
        public Procedure? Procedure { get; set; }
        public string? Consumer
        {
            get => consumer; set {consumer = value; OnPropertyChanged(); }
        }
        private string? period;


        public string? Period
        {
            get => period; set {period = value; OnPropertyChanged(); } 
        }
        private DateTime? launchdate;


        public DateTime? LaunchDate
        {
            get => launchdate; set { launchdate = value; OnPropertyChanged(); }
        }
        private DateTime? launchtime;


        public DateTime? LaunchTime
        {
            get => launchtime; set { launchtime = value; OnPropertyChanged(); }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
