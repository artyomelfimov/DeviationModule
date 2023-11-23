using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DeviationModule.Models;

public class Procedure : INotifyPropertyChanged
{
    private string? owner;
    private string? name;
    public int Id { get; }
    public string? Name
    {
        get { return name; }
        set
        {
            name = value;
            OnPropertyChanged();
        }
    }

    public string? Owner
    {
        get { return owner; }
        set
        {
            owner = value;
            OnPropertyChanged("Owner");
        }
    }

    public string? Status { get; }


    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
