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

public class BtlButton
{
    public Image Sprite;
    public double X;
    public double Y;
    public double Width;
    public double Height;
    public bool IsActive;
    public bool IsClicked;
    public BtlButton(Image Sprite,double X, double Y,double Width,double Height,bool IsActive,bool IsClicked)
    {
        this.Sprite = Sprite;
        this.X = X;
        this.Y = Y;
        this.Width = Width;
        this.Height = Height;
        this.IsActive = IsActive;
        this.IsClicked = IsClicked;
    }

}