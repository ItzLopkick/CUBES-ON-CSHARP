using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;
using System.Security;
using System;
using System.Media;
using NAudio;
using NAudio.Wave;
using System.Xml.Serialization;

class Timer
{
    public bool IsTimerActive;
    public double Time;
    public double TimeMax;
    public bool DoAction;
    public Timer(double TimeMax)
    {
        this.TimeMax = TimeMax*1000;
        this.Time = 0;
        this.IsTimerActive = false;
        this.DoAction = false;
    }
    public void Activate(bool IsTimerActive)
    {
        IsTimerActive = true;
    }
    public void AddTime(double Time,double TimeMax,bool IsTimerActive,bool DoAction)
    {
        if (IsTimerActive == true)
        {
            Time = Time + 1000;
        }
        else if (Time == TimeMax)
        {
            Time = 0;
            IsTimerActive = false;
            DoAction = true;
        }
    }
}