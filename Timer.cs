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
    public void Activate()
    {
        IsTimerActive = true;
    }
    public void AddTime()
    {
        if (this.IsTimerActive == true)
        {
            this.Time = this.Time + 1000;
        }
        else if (this.Time >= this.TimeMax)
        {
            this.Time = 0;
            this.IsTimerActive = false;
            DoAction = true;
        }
    }
}