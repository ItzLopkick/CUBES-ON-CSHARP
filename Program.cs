using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;

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
    public static void Iftouching(Rectangle player,double PlayerX,double PlayerY,double ScreenWidth,double ScreenHeight,double PlayerWidth)
    {
        if (PlayerX == ScreenWidth || PlayerX > ScreenWidth)
        {
            Canvas.SetLeft(player,ScreenHeight - PlayerWidth);
        }
        else if (PlayerX == 0 || PlayerX < 0)
        {
            Canvas.SetLeft(player,0);
        }
        else if (PlayerY == 0 || PlayerY > 0)
        {
            Canvas.SetTop(player,0);
        }
        else if (PlayerY == ScreenHeight || PlayerY < ScreenHeight)
        {
            Canvas.SetTop(player,ScreenHeight);
        }
    }
    Rectangle player;
    double PlayerX;
    double PlayerY;
    double shirinaOkna;
    double vusotaOkna;
    double PlayerWidth;
    public Okoshkatwo()
    {
        shirinaOkna = this.Width;
        vusotaOkna = this.Height;
        Random random = new Random();
        MessageBox.Show("Version 1.1");
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

        var squres = new List<Rectangle>
        {
            new Rectangle{Width = random.Next(100,250),Height = random.Next(100,250),Fill = Brushes.Red},
            new Rectangle{Width = random.Next(100,250),Height = random.Next(100,250),Fill = Brushes.Red},
            new Rectangle{Width = random.Next(100,250),Height = random.Next(100,250),Fill = Brushes.Red},
            new Rectangle{Width = random.Next(100,250),Height = random.Next(100,250),Fill = Brushes.Red},
            new Rectangle{Width = random.Next(100,250),Height = random.Next(100,250),Fill = Brushes.Red},
            new Rectangle{Width = random.Next(100,250),Height = random.Next(100,250),Fill = Brushes.Red}
        };
        player = new Rectangle
        {
            Width = 100,
            Height = 100,
            Fill = Brushes.Green
        };
        PlayerWidth = player.Width;
        gcanvas.Children.Add(player);
        Canvas.SetLeft(player, Width/2);
        Canvas.SetTop(player, Height/2);

        foreach (Rectangle rect in squres)
        {
            gcanvas.Children.Add(rect);
            Canvas.SetLeft(rect,random.Next(0,Convert.ToInt32(Width)));
            Canvas.SetTop(rect,random.Next(-10000,0));
        }
        // var sqaure = new Rectangle{Width = 100,Height = 100,Fill = Brushes.Red};
        // gcanvas.Children.Add(sqaure); // добавление фигуры
        // Canvas.SetLeft(sqaure,100);
        // Canvas.SetTop(sqaure,100);

        Content = gcanvas;
        this.KeyDown += Controls;
        this.Focusable = true;
        this.Focus();
        Loaded += async (_,__) =>
        {
            await Task.Delay(3000);
            Canvas.SetLeft(img,-56667);
            while (1 == 1)
            {
                Iftouching(player,PlayerX,PlayerY,shirinaOkna,vusotaOkna,PlayerWidth);
                foreach (Rectangle rect in squres)
                {
                    double squareX = Canvas.GetLeft(rect);
                    double squareY = Canvas.GetTop(rect);
                    squareY = squareY+10;
                    Canvas.SetTop(rect,squareY);
                    double shirinaOkna = this.Width;
                    double vusotaOkna = this.Height;
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
    void Controls(object Sender,KeyEventArgs event2)
    {
        if (event2.Key == Key.Left)
        {
            Console.WriteLine("!left");
            PlayerX = Canvas.GetLeft(player);
            PlayerY = Canvas.GetTop(player);
            PlayerX = PlayerX-10;
            Canvas.SetLeft(player,PlayerX);
        }
        else if (event2.Key == Key.Right)
        {
            Console.WriteLine("!right");
            PlayerX = Canvas.GetLeft(player);
            PlayerY = Canvas.GetTop(player);
            PlayerX = PlayerX+10;
            Canvas.SetLeft(player,PlayerX);
        }
        else if (event2.Key == Key.Up)
        {
            Console.WriteLine("!up");
            PlayerX = Canvas.GetLeft(player);
            PlayerY = Canvas.GetTop(player);
            PlayerY = PlayerY-10;
            Canvas.SetTop(player,PlayerY);
        }
        else if (event2.Key == Key.Down)
        {
            Console.WriteLine("!down");
            PlayerX = Canvas.GetLeft(player);
            PlayerY = Canvas.GetTop(player);
            PlayerY = PlayerY+10;
            Canvas.SetTop(player,PlayerY);
        }
        else if (event2.Key == Key.Space)
        {
            Console.WriteLine("!Debug = true");
            Console.WriteLine("Debug features : \nWidth : "+Width+" \nHeight : "+Height);
        }
        event2.Handled = true;
    }
}