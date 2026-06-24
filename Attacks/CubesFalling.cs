using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

public class Attack
{
    public Rectangle Sprite;
    public double X;
    public double Y;
    public double X2;
    public double Y2;
    public double Speed;
    public double Width;
    public double Height;
    public Attack(Rectangle Sprite,double X, double Y,double Width,double Height,double Speed)
    {
        this.Sprite = Sprite;
        this.X = X;
        this.Y = Y;
        this.Width = Width;
        this.Height = Height;
        this.Speed = Speed;
        this.X2 = X+Width;
        this.Y2 = Y+Height;
    }
    public void Undertale()
    {
        this.Y = this.Y+this.Speed;
        this.Y2 = this.Y+this.Height;
    }
}