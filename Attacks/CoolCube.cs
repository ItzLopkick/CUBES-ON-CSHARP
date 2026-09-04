using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

public class Attack2
{
    public Rectangle Sprite;
    public double X;
    public double Y;
    public double X2;
    public double Y2;
    public double Width;
    public double Height;
    public bool IsApear;
    public bool Agresive;
    public Attack2(Rectangle Sprite,double X, double Y,double Width,double Height)
    {
        this.Sprite = Sprite;
        this.X = X;
        this.Y = Y;
        this.Width = Width;
        this.Height = Height;
        this.X2 = X+Width;
        this.Y2 = Y+Height;
        this.Agresive = false;
        this.IsApear = false;
    }
    public void Apear(double ArenaPhysX,double ArenaPhysY,double ArenaPhysX2,double ArenaPhysY2)
    {
        this.IsApear = true;
        this.Agresive = false;
        Random random = new Random();
        this.X = random.Next(Convert.ToInt32(ArenaPhysX),Convert.ToInt32(ArenaPhysX2-this.Width));
        this.X2 = this.X+this.Width;
        this.Y = random.Next(Convert.ToInt32(ArenaPhysY),Convert.ToInt32(ArenaPhysY2-this.Height));
        this.Y2 = this.Y+this.Height;
    }
    public void Disapear()
    {
        this.X = 9999;
        this.X2 = 9999;
        this.Y = 9999;
        this.Y2 = 9999;
        this.Agresive = false;
        this.IsApear = false;
    }
}