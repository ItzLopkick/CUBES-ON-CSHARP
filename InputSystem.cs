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
using System.Windows.Documents;

class InputSystem
{
    public List<Key> keyboardbuttons = new List<Key> {};
    // public InputSystem()
    // {
    //     this.keyboardbuttons = keyboardbuttons;
    // }
    public void HandlingKeysDown(object Sender,KeyEventArgs event2)
    {
        if (!keyboardbuttons.Contains(event2.Key))
        {
            keyboardbuttons.Add(event2.Key);
        }
        event2.Handled = true;
    }
    public void HandlingKeysUp(object Sender,KeyEventArgs event2)
    {
        keyboardbuttons.Remove(event2.Key);
        event2.Handled = true;
    }
}