using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Documents;
using System.Security.Cryptography.X509Certificates;

class EnemyBtl
{
    public Image Sprite;

    public double hp;
    public double X;
    public double Y;
    public double X2;
    public double Y2;
    public double Width;
    public double Height;
    public BitmapImage DefaultSprite = new BitmapImage(new Uri("assets/EnemyIdle.png",UriKind.Relative));

    public EnemyBtl(double X, double Y,double Width,double Height,double hp)
    {
        this.Sprite = new Image
        {
            Width = Width,
            Height = Height,
            Source = this.DefaultSprite
        };
        this.X = X;
        this.Y = Y;
        this.Width = Width;
        this.Height = Height;
        this.X2 = X+Width;
        this.Y2 = Y+Height;
        this.hp = hp;
    }
}