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
    double meteorsvalue = 20;
    List<Meteor> meteors = new List<Meteor>{};
    Rectangle playersprite;
    double shirinaOkna;
    double vusotaOkna;
    Player player;

    Random random = new Random();
    public Okoshkatwo() // ничо не исправлять
    {
        // Озон . Настройка окна
        var gcanvas = new Canvas{};
        Content = gcanvas;
        MessageBox.Show("Version 1.7");
        Title = "Squre";
        Width = 1000;
        Height = 1000;
        Icon = new BitmapImage(new Uri("pack://application:,,,/assets/app.ico"));

        // Короче это привазка функции к клавиатуре и создаём Loaded
        this.KeyDown += HandlingKeysDown;
        this.KeyUp += HandlingKeysUp;
        this.Focusable = true;
        this.Focus();
        Loaded += async (_,__) => // :0
        // MAIN CODE HERE
        {
            shirinaOkna = this.ActualWidth-15; // вычесление реальных размеров окна
            vusotaOkna = this.ActualHeight-38; // круто

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

            CreateMeteors(meteorsvalue);
            foreach (Meteor meteor in meteors)
            {
                gcanvas.Children.Add(meteor.Sprite);
                Canvas.SetLeft(meteor.Sprite,meteor.X);
                Canvas.SetTop(meteor.Sprite,meteor.Y);
            }
            while (1 == 1)
            {
                shirinaOkna = this.ActualWidth-15; // вычесление реальных размеров окна
                vusotaOkna = this.ActualHeight-38; // круто

                player.Controls(shirinaOkna,vusotaOkna);
                Canvas.SetLeft(player.Sprite,player.X);
                Canvas.SetTop(player.Sprite,player.Y);


                foreach (Meteor meteor in meteors)
                {
                    meteor.Undertale();
                    Canvas.SetTop(meteor.Sprite,meteor.Y);
                    if (meteor.Y > vusotaOkna)
                    {

                        meteor.X = random.Next(0,Convert.ToInt32(shirinaOkna));
                        meteor.Y = random.Next(-6000,-500);

                        Canvas.SetLeft(meteor.Sprite,meteor.X);
                        Canvas.SetTop(meteor.Sprite,meteor.Y);
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
            Rectangle meteorsprite = new Rectangle{Width = random.Next(70,100),Height = random.Next(70,100),Fill = Brushes.Red};
            Meteor meteor1 = new Meteor(meteorsprite,random.Next(0,Convert.ToInt32(shirinaOkna)),random.Next(-1000,1000),meteorsprite.Width,meteorsprite.Height,random.Next(15,25));
            meteors.Add(meteor1);
        }
    }
}