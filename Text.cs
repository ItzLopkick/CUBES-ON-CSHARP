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
class Text
{
    public TextBox TextBox;
    public Text(TextBox TextBox)
    {
        this.TextBox = TextBox;
        this.TextBox.Foreground = Brushes.Black;
        this.TextBox.Background = Brushes.Black;
        this.TextBox.FontFamily = new FontFamily("Georgia");
        this.TextBox.IsHitTestVisible = false;
    }
}
class Message
{
    public TextBox Text;
    public Message(TextBox Text)
    {
        this.Text = Text;
        this.Text.Foreground = Brushes.White;
        this.Text.Background = Brushes.Black;
        this.Text.FontFamily = new FontFamily("Georgia");
        this.Text.IsHitTestVisible = false;
    }
    public void Dialog(TextBox Text)
    {
        
    }
}