using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DeviationModule.Models
{
    public class Deviation : INotifyPropertyChanged
    {
        [ReadOnly(true)]
        public int Id { get; set; }

        [ReadOnly(true)]
        public int? ProcId { get; set; }

        [ReadOnly(true)]
        public string? Owner { get; set; }
        [ReadOnly(true)]
        public string? Status { get; set; }

        public bool IsCorrected { get; set; }
        private string? comment;
        public string? Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                OnPropertyChanged();
            }
        }
        public string? BarCode { get; set; }
        public DateTime? Date { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
