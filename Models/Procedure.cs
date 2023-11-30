﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DeviationModule.Models;

public class Procedure : INotifyPropertyChanged
{
    public ObservableCollection<Deviation>? Deviations { get; set; }
    private string? owner;
    private string? name;
    private string? description;
    private string? type;
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
    public string? Description
    {
        get { return description; }
        set
        {
            description = value;
            OnPropertyChanged();
        }
    }
    public string? Owner
    {
        get { return owner; }
        set
        {
            owner = value;
            OnPropertyChanged();
        }
    }
    public string? Type
    {
        get { return type; }
        set
        {
            type = value;
            OnPropertyChanged();
        }
    }
    public string? Status { get; set; }


    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
