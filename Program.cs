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
    double meteorsvalue = 50;
    List<Rectangle> meteors = new List<Rectangle>{};
    Rectangle player;
    double PlayerX;
    double PlayerY;
    double shirinaOkna;
    double vusotaOkna;
    double PlayerWidth;
    double PlayerSpeed;
    double PlayerHeight;
    bool MoveUpFlag = false;
    bool MoveRightFlag = false;
    bool MoveDownFlag = false;
    bool MoveLeftFlag = false;
    bool ShiftFlag = false;
    Random random = new Random();
    public Okoshkatwo()
    {
        shirinaOkna = this.Width;
        vusotaOkna = this.Height;
        MessageBox.Show("Version 1.4");
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
        player = new Rectangle
        {
            Width = 100,
            Height = 100,
            Fill = Brushes.Green
        };
        PlayerWidth = player.Width;
        PlayerHeight = player.Height;
        PlayerSpeed = 5;
        gcanvas.Children.Add(player);
        Canvas.SetLeft(player, Width/2);
        Canvas.SetTop(player, Height/2);

        foreach (Rectangle rect in meteors)
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
        this.KeyDown += HandlingKeysDown;
        this.KeyUp += HandlingKeysUp;
        this.Focusable = true;
        this.Focus();
        Loaded += async (_,__) =>
        {
            await Task.Delay(3000);
            Canvas.SetLeft(img,-56667);
            // Iftouching(player,PlayerX,PlayerY,shirinaOkna,vusotaOkna,PlayerWidth);
            while (1 == 1)
            {
                Controls();
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
            MoveRightFlag = false;
        }
        if (event2.Key == Key.Up)
        {
            MoveUpFlag = false;
        }
        if (event2.Key == Key.Down)
        {
            MoveDownFlag = false;
        }
        if (event2.Key == Key.Left)
        {
            MoveLeftFlag = false;
        }
        if (event2.Key == Key.LeftShift)
        {
            ShiftFlag = false;
        }
        event2.Handled = true;
    }
    void HandlingKeysDown(object Sender,KeyEventArgs event2)
    {
        if (event2.Key == Key.Right)
        {
            MoveRightFlag = true;
        }
        if (event2.Key == Key.Up)
        {
            MoveUpFlag = true;
        }
        if (event2.Key == Key.Down)
        {
            MoveDownFlag = true;
        }
        if (event2.Key == Key.Left)
        {
            MoveLeftFlag = true;
        }
        if (event2.Key == Key.LeftShift)
        {
            ShiftFlag = true;
        }
        event2.Handled = true;
    }
    void Controls()
    {
        if (ShiftFlag == true)
        {
            PlayerSpeed = 10;
        }
        else
        {
            PlayerSpeed = 5;
        }
        if (MoveLeftFlag == true)
        {
            Console.WriteLine("!left");
            PlayerX = Canvas.GetLeft(player);
            if ((PlayerX - PlayerSpeed) < 0)
            {
                PlayerX = 0;
                Console.WriteLine("!left_nope");
            }
            else
            {
                PlayerX = PlayerX-PlayerSpeed;
            }
            Canvas.SetLeft(player,PlayerX);
        }
        if (MoveRightFlag == true)
        {
            Console.WriteLine("!right");
            PlayerX = Canvas.GetLeft(player);
            if ((PlayerX + PlayerSpeed + PlayerWidth) >  shirinaOkna)
            {
                PlayerX = shirinaOkna-PlayerWidth;
                Console.WriteLine("!right_nope");
            }
            else
            {
                PlayerX = PlayerX+PlayerSpeed;          
            }
            Canvas.SetLeft(player,PlayerX);
        }
        if (MoveUpFlag == true)
        {
            Console.WriteLine("!up");
            PlayerY = Canvas.GetTop(player);
            if ((PlayerY - PlayerSpeed) < 0)
            {
                PlayerY = 0;
                Console.WriteLine("!up_nope");
            }
            else
            {
                PlayerY = PlayerY-PlayerSpeed;
            }
            Canvas.SetTop(player,PlayerY);
        }
        if (MoveDownFlag == true)
        {
            PlayerY = Canvas.GetTop(player);
            Console.WriteLine("!down");

            Console.WriteLine(PlayerHeight+PlayerSpeed+PlayerY);
            Console.WriteLine(PlayerHeight);
            Console.WriteLine(PlayerSpeed);
            Console.WriteLine(PlayerY );
            Console.WriteLine(vusotaOkna);
            if ((PlayerY + PlayerSpeed + PlayerHeight) > vusotaOkna)
            {
                PlayerY = vusotaOkna-PlayerHeight;
                Console.WriteLine("!down_nope");
            }
            else
            {
                PlayerY = PlayerY+PlayerSpeed;
            }
            Canvas.SetTop(player,PlayerY);
        }
    }
    void CreateMeteors(double value)
    {
        for (int i = 0;i < value; i++)
        {
            meteors.Add(new Rectangle {Width = 100,Height = 100,Fill = Brushes.Red});
        }
    }
}