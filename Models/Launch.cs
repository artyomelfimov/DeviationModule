//using DeviationModule.Components;
//using DeviationModule.Models.Interfaces;
//using System;
//using System.ComponentModel;
//using System.Runtime.CompilerServices;

//namespace DeviationModule.Models
//{
//    public class Launch : INotifyPropertyChanged, IEntity
//    {
//        public event PropertyChangedEventHandler? PropertyChanged;

//        [ReadOnly(true)]
//        public int Id { get; set; }
         
//        private string? consumer;
//        public Procedure? Procedure { get; set; }
//        public string? Consumer
//        {
//            get => consumer; set {consumer = value; OnPropertyChanged(); }
//        }
//        private string? period;


//        public string? Period
//        {
//            get => period; set {period = value; OnPropertyChanged(); } 
//        }
//        private DateTime? launchdate;


//        public DateTime? LaunchDate
//        {
//            get => launchdate; 
//            set {
//                var olddate = launchdate;
//                launchdate = value;
//                OnPropertyChanged();
//                  }
//        }
//        private DateTime? launchtime;


//        public DateTime? LaunchTime
//        {
//            get => launchtime; set { launchtime = value; OnPropertyChanged(); }
//        }

//        public void OnPropertyChanged([CallerMemberName] string prop = "")
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
//        }
       
//    }
//}
