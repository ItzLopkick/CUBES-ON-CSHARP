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
    public double X;
    public double Y;
    public double X2;
    public double Y2;
    public double Width;
    public double Height;
    public List<BitmapImage> Animation2Bitmaps = new List<BitmapImage>
    {
        new BitmapImage(new Uri("assets/EatingTest/LopkickEat1.png",UriKind.Relative)),
        new BitmapImage(new Uri("assets/EatingTest/LopkickEat2.png",UriKind.Relative)),
        new BitmapImage(new Uri("assets/EatingTest/LopkickEat3.png",UriKind.Relative)),
        new BitmapImage(new Uri("assets/EatingTest/LopkickEat4.png",UriKind.Relative)),
        new BitmapImage(new Uri("assets/EatingTest/LopkickEat5.png",UriKind.Relative)),
        new BitmapImage(new Uri("assets/EatingTest/LopkickEat6.png",UriKind.Relative)),
        new BitmapImage(new Uri("assets/EatingTest/LopkickEat7.png",UriKind.Relative)),
        new BitmapImage(new Uri("assets/EatingTest/LopkickEat8.png",UriKind.Relative)),
        new BitmapImage(new Uri("assets/EatingTest/LopkickEat9.png",UriKind.Relative)),

        
    };
    public List<BitmapImage> HirtAnimBitmaps = new List<BitmapImage>
    {
        new BitmapImage(new Uri("assets/HirtAnim/LopkickHirt1.png",UriKind.Relative)),
        new BitmapImage(new Uri("assets/HirtAnim/LopkickHirt2.png",UriKind.Relative)),
        new BitmapImage(new Uri("assets/HirtAnim/LopkickHirt3.png",UriKind.Relative)),
        new BitmapImage(new Uri("assets/HirtAnim/LopkickHirt4.png",UriKind.Relative)),
    };
    public BitmapImage DefaultSprite = new BitmapImage(new Uri("assets/playerbtlidle.png",UriKind.Relative));
    public double Animation2Time;
    public int Animation2Frame;
    public double HirtAnimTime;
    public int HirtAnimFrame;

    public EnemyBtl(double X, double Y,double Width,double Height)
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
        this.Animation2Time = 0;
        this.Animation2Frame = 0;
        this.HirtAnimTime = 0;
        this.HirtAnimFrame = 0;
    }
}