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

public static class Program
{
    [System.STAThread]
    public static void Main()
    {
        var aboba = new Application();
        aboba.Run(new Okoshkatwo());
    }
}

public class Okoshkatwo:Window
{
    double meteorsvalue = 5;
    List<Rectangle> meteors = new List<Rectangle>{};
    Rectangle playersprite; // C
    double shirinaOkna;
    double vusotaOkna;
    Player player;

    Random random = new Random();
    public Okoshkatwo()
    {
        shirinaOkna = this.Width;
        vusotaOkna = this.Height;
        MessageBox.Show("Version 1.6");
        Title = "Squre";
        Width = 1000;
        Height = 1000;
        Icon = new BitmapImage(new Uri("pack://application:,,,/assets/app.ico"));
        var gcanvas = new Canvas{};
        var img = new Image
        {
            Width = 200,
            Height = 200,
            Source = new BitmapImage(new Uri("pack://application:,,,/assets/app.ico"))
        };
        gcanvas.Children.Add(img);
        Canvas.SetLeft(img, 500);
        Canvas.SetTop(img, 500);
        CreateMeteors(meteorsvalue);
        playersprite = new Rectangle
        {
            Width = 100,
            Height = 100,
            Fill = Brushes.Green
        };
        player = new Player(playersprite,0,0,7,100,100,10);
        gcanvas.Children.Add(player.Sprite);
        Canvas.SetLeft(player.Sprite, player.X);
        Canvas.SetTop(player.Sprite, player.Y);

        foreach (Rectangle rect in meteors)
        {
            gcanvas.Children.Add(rect);
            Canvas.SetLeft(rect,random.Next(0,Convert.ToInt32(Width)));
            Canvas.SetTop(rect,random.Next(-10000,0));
        }

        Content = gcanvas;
        this.KeyDown += HandlingKeysDown;
        this.KeyUp += HandlingKeysUp;
        this.Focusable = true;
        this.Focus();
        Loaded += async (_,__) =>
        {
            await Task.Delay(3000);
            Canvas.SetLeft(img,-56667);
            while (1 == 1)
            {
                player.Controls(shirinaOkna,vusotaOkna);
                Canvas.SetLeft(player.Sprite,player.X);
                Canvas.SetTop(player.Sprite,player.Y);
                foreach (Rectangle rect in meteors)
                {
                    double squareX = Canvas.GetLeft(rect);
                    double squareY = Canvas.GetTop(rect);
                    squareY = squareY+10;
                    Canvas.SetTop(rect,squareY);
                    shirinaOkna = this.ActualWidth-15;
                    vusotaOkna = this.ActualHeight-38;
                    if (squareY > vusotaOkna)
                    {
                        int vusotaOknaInt = Convert.ToInt32(vusotaOkna);
                        int shirinaOknaInt = Convert.ToInt32(shirinaOkna);

                        int xRandom = random.Next(0,shirinaOknaInt);
                        int yRandom = random.Next(-6000,-500);
                        Canvas.SetLeft(rect,xRandom);
                        Canvas.SetTop(rect,yRandom);
                    }
                }

                // tick
                await Task.Delay(10);
            }
            
        };
        
    }
    void HandlingKeysUp(object Sender,KeyEventArgs event2)
    {
        if (event2.Key == Key.Right)
        {
            player.MoveRightFlag = false;
        }
        if (event2.Key == Key.Up)
        {
            player.MoveUpFlag = false;
        }
        if (event2.Key == Key.Left)
        {
            player.MoveLeftFlag = false;
        }
        if (event2.Key == Key.Down)
        {
            player.MoveDownFlag = false;
        }
        if (event2.Key == Key.LeftShift)
        {
            player.ShiftFlag = false;
        }
        event2.Handled = true;
    }
    void HandlingKeysDown(object Sender,KeyEventArgs event2)
    {
        if (event2.Key == Key.Right)
        {
            player.MoveRightFlag = true;
        }
        if (event2.Key == Key.Up)
        {
            player.MoveUpFlag = true;
        }
        if (event2.Key == Key.Down)
        {
            player.MoveDownFlag = true;
        }
        if (event2.Key == Key.Left)
        {
            player.MoveLeftFlag = true;
        }
        if (event2.Key == Key.LeftShift)
        {
            player.ShiftFlag = true;
        }
        event2.Handled = true;
    }
    
    void CreateMeteors(double value)
    {
        for (int i = 0;i < value; i++)
        {
            meteors.Add(new Rectangle {Width = 100,Height = 100,Fill = Brushes.Red});
        }
    }
}